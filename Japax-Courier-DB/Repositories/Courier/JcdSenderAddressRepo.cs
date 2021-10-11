using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Japax_Courier_DB.Clients;
using Japax_Courier_DB.DBModels.CommonModels.Response;
using Japax_Courier_DB.DBModels.Courier;
using Japax_Courier_DB.DBModels.Courier.ResponseModels;
using Japax_Courier_DB.GeoLocation;
using Japax_Courier_DB.GeoLocation.ResponseModel;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Japax_Courier_DB.Repositories.Courier
{
    public class JcdSenderAddressRepo
    {
        public string GOOGLE_MAPS_API_KEY = "AIzaSyB9aiE-enfBpVjFI5vpOllWfr0EojNYOio";
        JpxCourierContext _Context = new JpxCourierContext();

        public async Task<SenderAddressModel> AddNew(JcdSenderAddress _Address)
        {
            try
            {
                int allowaedAddresses = 0;
                List<JcdSenderAddress> _SenderAddresses = await _Context.JcdSenderAddress.Where(x => x.SenderId == _Address.SenderId && x.ActiveStatus == 1).ToListAsync();
                int NumberOfSavedAddresses = _SenderAddresses.Count();

                JcdSenderInfo _SenderInfo = await _Context.JcdSenderInfo.Where(x => x.SenderId == _Address.SenderId).FirstOrDefaultAsync();
                allowaedAddresses = _SenderInfo.AllowableAddress;

                if (_SenderAddresses.Count >= allowaedAddresses)
                {
                    SenderAddressModel _responseModel = new SenderAddressModel
                    {
                        Status = "Error",
                        Error = new ErrorModel
                        {
                            ErrorCode = "514",
                            InnerException = "",
                            Message = "Sorry! You can add maximum " + allowaedAddresses + " addresses.",
                            StackTrace = "",
                        }
                    };
                    return await Task.FromResult(_responseModel);
                } else
                {
                    if (_Address.LatitudesData == null && _Address.LongitudesData == null)
                    {
                        GoogleClient _GoogleClient = new GoogleClient(GOOGLE_MAPS_API_KEY);

                        GeocodingModel _GeocodingModel = await _GoogleClient.GetGeocode(_Address);

                        if (_GeocodingModel.status == "OK")
                        {
                            if (_GeocodingModel.results[0].partial_match == true)
                            {
                                //Address matched partially
                                _Address.GeolocationStatus = 1;
                            }
                            else
                            {
                                //Address matched exactly
                                _Address.GeolocationStatus = 2;
                            }

                            _Address.LatitudesData = (decimal)_GeocodingModel.results[0].geometry.location.lat;
                            _Address.LongitudesData = (decimal)_GeocodingModel.results[0].geometry.location.lng;

                        }
                        else
                        {
                            //Address Not found
                            _Address.GeolocationStatus = 0;
                        }
                    }
                    _Address.ActiveStatus = 1;
                    _Context.JcdSenderAddress.Add(_Address);
                    await _Context.SaveChangesAsync();

                    AddressAreaModel _AreaAddressModel = await Task.FromResult(_Context.AddressAreaModel
                                                         .FromSqlRaw($"SP_JCD_GET_ADDRESS_MODEL_BY_AREA_ID {_Address.AreaId}")
                                                         .AsEnumerable()
                                                         .FirstOrDefault());

                    SenderAddressModel Response = new SenderAddressModel
                    {
                        Status = "Success",
                        SenderAddress = new AddressModel
                        {
                            ActiveStatus = _Address.ActiveStatus,
                            AddressLine1 = _Address.AddressLine1,
                            AddressLine2 = _Address.AddressLine2,
                            AddressType = _Address.AddressType,
                            AreaId = _AreaAddressModel.AreaId,
                            AreaName = _AreaAddressModel.AreaName,
                            CountryId = _AreaAddressModel.CountryId,
                            CountryName = _AreaAddressModel.CountryName,
                            DistrictCityId = _AreaAddressModel.DistrictCityId,
                            DistrictCityName = _AreaAddressModel.DistrictCityName,
                            EntryDate = _Address.EntryDate,
                            HouseOrRoadNo = _Address.HouseOrRoadNo,
                            LandMark = _Address.HouseOrRoadNo,
                            Lang = _Address.LongitudesData,
                            Lat = _Address.LatitudesData,
                            PostalCode = _Address.PostalCode,
                            ProvinceId = _AreaAddressModel.ProvinceId,
                            ProvinceName = _AreaAddressModel.ProvinceName,
                            PsUpazillaId = _AreaAddressModel.PsUpazillaId,
                            PsUpazillaName = _AreaAddressModel.PsUpazillaName,
                            SenderId = _Address.SenderId,
                            ID = _Address.Id,
                            Street = _Address.Street
                        }
                    };
                    return await Task.FromResult(Response);
                }                
            }
            catch (Exception ex)
            {
                SenderAddressModel _responseModel = new SenderAddressModel
                {
                    Status = "Error",
                    Error = new ErrorModel
                    {
                        ErrorCode = "505",
                        InnerException = (ex.InnerException != null) ? ex.InnerException.Message.ToString() : "",
                        Message = (ex.Message != null) ? ex.Message.ToString() : "",
                        StackTrace = (ex.StackTrace != null) ? ex.StackTrace.ToString() : "",
                    }
                };

                //<<<<<Start Register Log>>>>>
                JcdErrorLogRepo _LogRepo = new JcdErrorLogRepo();
                JcdErrorLog _ErrorLog = new JcdErrorLog
                {
                    ErrEntity = (ex.Message != null) ? ex.Message.ToString() : "",
                    ErrInnerException = (ex.InnerException != null) ? ex.InnerException.Message.ToString() : "",
                    ErrMessage = (ex.Message != null) ? ex.Message.ToString() : "",
                    ErrMethod = "AddNew_SenderAddress | SenderId = " + _Address.SenderId,
                    ErrMethodPayload = JsonConvert.SerializeObject(_Address),
                    ErrProcedure = (ex.Source != null) ? ex.Source.ToString() : "",
                    ErrRaisedDate = DateTime.Now,
                    ErrStackTrace = (ex.StackTrace != null) ? ex.StackTrace.ToString() : "",
                    UserId = 0
                };
                await _LogRepo.AddLog(_ErrorLog);
                //<<<<<End Register Log>>>>>

                return await Task.FromResult(_responseModel);
            }

        }
        public async Task<SenderAddressModel> Update(JcdSenderAddress Address)
        {
            try
            {
                if (Address.LatitudesData == null && Address.LongitudesData == null)
                {
                    GoogleClient _GoogleClient = new GoogleClient(GOOGLE_MAPS_API_KEY);

                    GeocodingModel _GeocodingModel = await _GoogleClient.GetGeocode(Address);

                    if (_GeocodingModel.status == "OK")
                    {
                        if (_GeocodingModel.results[0].partial_match == true)
                        {
                            //Address matched partially
                            Address.GeolocationStatus = 1;
                        }
                        else
                        {
                            //Address matched exactly
                            Address.GeolocationStatus = 2;
                        }

                        Address.LatitudesData = (decimal)_GeocodingModel.results[0].geometry.location.lat;
                        Address.LongitudesData = (decimal)_GeocodingModel.results[0].geometry.location.lng;

                    }
                    else
                    {
                        //Address Not found
                        Address.GeolocationStatus = 0;
                    }
                }

                // updating new values
                _Context.JcdSenderAddress.Update(Address);
                await _Context.SaveChangesAsync();

                AddressAreaModel _AreaAddressModel = await Task.FromResult(_Context.AddressAreaModel
                                                         .FromSqlRaw($"SP_JCD_GET_ADDRESS_MODEL_BY_AREA_ID {Address.AreaId}")
                                                         .AsEnumerable()
                                                         .FirstOrDefault());

                SenderAddressModel Response = new SenderAddressModel
                {
                    Status = "Success",
                    SenderAddress = new AddressModel
                    {
                        ActiveStatus = Address.ActiveStatus,
                        AddressLine1 = Address.AddressLine1,
                        AddressLine2 = Address.AddressLine2,
                        AddressType = Address.AddressType,
                        AreaId = _AreaAddressModel.AreaId,
                        AreaName = _AreaAddressModel.AreaName,
                        CountryId = _AreaAddressModel.CountryId,
                        CountryName = _AreaAddressModel.CountryName,
                        DistrictCityId = _AreaAddressModel.DistrictCityId,
                        DistrictCityName = _AreaAddressModel.DistrictCityName,
                        EntryDate = Address.EntryDate,
                        HouseOrRoadNo = Address.HouseOrRoadNo,
                        LandMark = Address.HouseOrRoadNo,
                        Lang = Address.LongitudesData,
                        Lat = Address.LatitudesData,
                        PostalCode = Address.PostalCode,
                        ProvinceId = _AreaAddressModel.ProvinceId,
                        ProvinceName = _AreaAddressModel.ProvinceName,
                        PsUpazillaId = _AreaAddressModel.PsUpazillaId,
                        PsUpazillaName = _AreaAddressModel.PsUpazillaName,
                        SenderId = Address.SenderId,
                        ID = Address.Id,
                        Street = Address.Street
                    }
                };
                return await Task.FromResult(Response);
            }
            catch (Exception ex)
            {
                SenderAddressModel _responseModel = new SenderAddressModel
                {
                    Status = "Error",
                    Error = new ErrorModel
                    {
                        ErrorCode = "505",
                        InnerException = (ex.InnerException != null) ? ex.InnerException.Message.ToString() : "",
                        Message = (ex.Message != null) ? ex.Message.ToString() : "",
                        StackTrace = (ex.StackTrace != null) ? ex.StackTrace.ToString() : "",
                    }
                };

                //<<<<<Start Register Log>>>>>
                JcdErrorLogRepo _LogRepo = new JcdErrorLogRepo();
                JcdErrorLog _ErrorLog = new JcdErrorLog
                {
                    ErrEntity = (ex.Message != null) ? ex.Message.ToString() : "",
                    ErrInnerException = (ex.InnerException != null) ? ex.InnerException.Message.ToString() : "",
                    ErrMessage = (ex.Message != null) ? ex.Message.ToString() : "",
                    ErrMethod = "Update_SenderAddress",
                    ErrMethodPayload = JsonConvert.SerializeObject(Address),
                    ErrProcedure = (ex.Source != null) ? ex.Source.ToString() : "",
                    ErrRaisedDate = DateTime.Now,
                    ErrStackTrace = (ex.StackTrace != null) ? ex.StackTrace.ToString() : "",
                    UserId = 0
                };
                return await Task.FromResult(_responseModel);
            }

        }
        public async Task<CommonResponseModel> Remove(JcdSenderAddress Address)
        {
            //Get Start Time
            DateTime StartTime = DateTime.Now;
            try
            {                
                _Context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

                JcdSenderAddress _Address = _Context.JcdSenderAddress
                      .Where(s => s.Id == Address.Id)
                              .FirstOrDefault<JcdSenderAddress>();

                if (_Address != null)
                {
                    // updating new values
                    _Address = Address;

                    _Context.Entry<JcdSenderAddress>(_Address).State = EntityState.Deleted;
                    _Context.SaveChanges();

                }

                CommonResponseModel _responseModel = new CommonResponseModel
                {
                    Status = "Success",
                    ExecutionTime = (DateTime.Now - StartTime).TotalMilliseconds.ToString() + " ms"
                };
                return await Task.FromResult(_responseModel);
            }
            catch (Exception ex)
            {
                CommonResponseModel _responseModel = new CommonResponseModel
                {
                    Status = "Error",
                    ExecutionTime = (DateTime.Now - StartTime).TotalMilliseconds.ToString() + " ms",
                    Error = new ErrorModel
                    {
                        ErrorCode = "505",
                        InnerException = (ex.InnerException != null) ? ex.InnerException.Message.ToString() : "",
                        Message = (ex.Message != null) ? ex.Message.ToString() : "",
                        StackTrace = (ex.StackTrace != null) ? ex.StackTrace.ToString() : "",
                    }
                };

                //<<<<<Start Register Log>>>>>
                JcdErrorLogRepo _LogRepo = new JcdErrorLogRepo();
                JcdErrorLog _ErrorLog = new JcdErrorLog
                {
                    ErrEntity = (ex.Message != null) ? ex.Message.ToString() : "",
                    ErrInnerException = (ex.InnerException != null) ? ex.InnerException.Message.ToString() : "",
                    ErrMessage = (ex.Message != null) ? ex.Message.ToString() : "",
                    ErrMethod = "Remove_SenderAddress",
                    ErrMethodPayload = JsonConvert.SerializeObject(Address),
                    ErrProcedure = (ex.Source != null) ? ex.Source.ToString() : "",
                    ErrRaisedDate = DateTime.Now,
                    ErrStackTrace = (ex.StackTrace != null) ? ex.StackTrace.ToString() : "",
                    UserId = 0
                };

                return await Task.FromResult(_responseModel);
            }

        }
        public async Task<SenderAddressModel> GetAddressById(string senderId)
        {
            try
            {
                List<AddressModel> AddressList = await _Context.AddressModel
                                                         .FromSqlRaw($"SP_JCD_GET_ADDRESSES_BY_SENDER_ID {senderId}")
                                                         .ToListAsync();

                SenderAddressModel Response = new SenderAddressModel
                {
                    Status = "Success",
                    SenderAddressList = AddressList
                };

                return await Task.FromResult(Response);
            }
            catch (Exception ex)
            {
                SenderAddressModel SenderAddressModel = new SenderAddressModel
                {
                    Status = "Error",
                    Error = new ErrorModel
                    {
                        ErrorCode = "505",
                        InnerException = (ex.InnerException != null) ? ex.InnerException.Message.ToString() : "",
                        Message = (ex.Message != null) ? ex.Message.ToString() : "",
                        StackTrace = (ex.StackTrace != null) ? ex.StackTrace.ToString() : ""
                    }
                };
                //<<<<<Start Register Log>>>>>
                JcdErrorLogRepo _LogRepo = new JcdErrorLogRepo();
                JcdErrorLog _ErrorLog = new JcdErrorLog
                {
                    ErrEntity = (ex.Message != null) ? ex.Message.ToString() : "",
                    ErrInnerException = (ex.InnerException != null) ? ex.InnerException.Message.ToString() : "",
                    ErrMessage = (ex.Message != null) ? ex.Message.ToString() : "",
                    ErrMethod = (ex.TargetSite != null) ? ex.TargetSite.Name.ToString() : "",
                    ErrMethodPayload = "GetAddressById",
                    ErrProcedure = (ex.Source != null) ? ex.Source.ToString() : "",
                    ErrRaisedDate = DateTime.Now,
                    ErrStackTrace = (ex.StackTrace != null) ? ex.StackTrace.ToString() : "",
                    UserId = 0
                };
                await _LogRepo.AddLog(_ErrorLog);
                //<<<<<End Register Log>>>>>

                return await Task.FromResult(SenderAddressModel);
            }
        }
        public async Task<CommonResponseModel> DeactivateAddress(long AddressId)
        {
            //Get Start Time
            DateTime StartTime = DateTime.Now;

            try
            {                
                JcdSenderAddress _AddressModel = await _Context.JcdSenderAddress.Where(x => x.Id == AddressId).FirstOrDefaultAsync();
                if(_AddressModel != null)
                {
                    _AddressModel.ActiveStatus = 0;
                    await _Context.SaveChangesAsync();

                    CommonResponseModel ResponseModel = new CommonResponseModel
                    {
                        Status = "Success",
                        ExecutionTime = (DateTime.Now - StartTime).TotalMilliseconds.ToString() + " ms"
                    };

                    return await Task.FromResult(ResponseModel);
                } else
                {
                    CommonResponseModel ResponseModel = new CommonResponseModel
                    {
                        Status = "error",
                        ExecutionTime = (DateTime.Now - StartTime).TotalMilliseconds.ToString() + " ms",
                        Error = new ErrorModel
                        {
                            ErrorCode = "510",
                            Message = "Address not found.",
                            InnerException = "",
                            StackTrace = ""
                        }
                    };

                    return await Task.FromResult(ResponseModel);
                }
            } catch(Exception ex)
            {
                CommonResponseModel ResponseModel = new CommonResponseModel
                {
                    Status = "error",
                    ExecutionTime = (DateTime.Now - StartTime).TotalMilliseconds.ToString() + " ms",
                    Error = new ErrorModel
                    {
                        ErrorCode = "505",
                        InnerException = (ex.InnerException != null) ? ex.InnerException.Message.ToString() : "",
                        Message = (ex.Message != null) ? ex.Message.ToString() : "",
                        StackTrace = (ex.StackTrace != null) ? ex.StackTrace.ToString() : "",
                    }
                };

                //<<<<<Start Register Log>>>>>
                JcdErrorLogRepo _LogRepo = new JcdErrorLogRepo();
                JcdErrorLog _ErrorLog = new JcdErrorLog
                {
                    ErrEntity = (ex.Message != null) ? ex.Message.ToString() : "",
                    ErrInnerException = (ex.InnerException != null) ? ex.InnerException.Message.ToString() : "",
                    ErrMessage = (ex.Message != null) ? ex.Message.ToString() : "",
                    ErrMethod = "DeactivateAddress",
                    ErrMethodPayload = "Address ID: " + AddressId,
                    ErrProcedure = (ex.Source != null) ? ex.Source.ToString() : "",
                    ErrRaisedDate = DateTime.Now,
                    ErrStackTrace = (ex.StackTrace != null) ? ex.StackTrace.ToString() : "",
                    UserId = 0
                };

                return await Task.FromResult(ResponseModel);
            }
        }
        public async Task<SenderAddressModel> GetFormattedAddress(JcdSenderAddress _Address)
        {
            try
            {
                JcdPickupAndDeliveryAreaRepo _AreaRepo = new JcdPickupAndDeliveryAreaRepo();
                PickupAndDeliveryAreaModel _AreaModel = await _AreaRepo.GetAreaById(_Address.AreaId);

                JcdPsUpazilaRepo _PsUpazilaRepo = new JcdPsUpazilaRepo();
                UpazillaModel _UpazilaModel = await _PsUpazilaRepo.GetUpazillaById(_AreaModel.Area.PsUpazilaId);

                JcdCityDistrictRepo _CityDistrictRepo = new JcdCityDistrictRepo();
                CityDistrictModel _CityDistrictModel = await _CityDistrictRepo.GetCityById(_UpazilaModel.Upazilla.CityDistrictId);

                JcdProvinceStateDivisionRepo _StateRepo = new JcdProvinceStateDivisionRepo();
                ProvinceModel _StateModel = await _StateRepo.GetStateById(_CityDistrictModel.City.ProvinceId);

                JcdCountryInfoRepo _CountryRepo = new JcdCountryInfoRepo();
                CountryInfoModel _CountryModel = await _CountryRepo.GetCountryById(_StateModel.State.CountryId);

                SenderAddressModel _SenderAddress = new SenderAddressModel
                {
                    Status = "Success",
                    SenderAddress = new AddressModel
                    {
                        ID = _Address.Id,
                        AddressLine1 = _Address.AddressLine1,
                        AddressLine2 = _Address.AddressLine2,
                        AddressType = _Address.AddressType,
                        EntryDate = _Address.EntryDate,
                        HouseOrRoadNo = _Address.HouseOrRoadNo,
                        LandMark = _Address.Landmark,
                        PostalCode = _Address.PostalCode,
                        SenderId = _Address.SenderId,
                        Street = _Address.Street,
                        Lat = _Address.LatitudesData,
                        Lang = _Address.LongitudesData,
                        AreaId = _AreaModel.Area.AreaId,
                        AreaName = _AreaModel.Area.AreaName,
                        PsUpazillaId = _UpazilaModel.Upazilla.PsUpazilaId,
                        PsUpazillaName = _UpazilaModel.Upazilla.PsUpazilaName,
                        DistrictCityId = _CityDistrictModel.City.CityDistrictId,
                        DistrictCityName = _CityDistrictModel.City.CityDistrictName,
                        ProvinceId = _StateModel.State.ProvinceId,
                        ProvinceName = _StateModel.State.ProvinceName,
                        CountryId = _CountryModel.Country.CountryId,
                        CountryName = _CountryModel.Country.CountryName,
                        ActiveStatus = _Address.ActiveStatus
                    }
                };
                return await Task.FromResult(_SenderAddress);
            } catch (Exception ex)
            {
                SenderAddressModel _SenderAddress = new SenderAddressModel
                {
                    Status = "error",
                    Error = new ErrorModel
                    {
                        ErrorCode = "505",
                        InnerException = (ex.InnerException != null) ? ex.InnerException.Message.ToString() : "",
                        Message = (ex.Message != null) ? ex.Message.ToString() : "",
                        StackTrace = (ex.StackTrace != null) ? ex.StackTrace.ToString() : "",
                    }
                };

                //<<<<<Start Register Log>>>>>
                JcdErrorLogRepo _LogRepo = new JcdErrorLogRepo();
                JcdErrorLog _ErrorLog = new JcdErrorLog
                {
                    ErrEntity = (ex.Message != null) ? ex.Message.ToString() : "",
                    ErrInnerException = (ex.InnerException != null) ? ex.InnerException.Message.ToString() : "",
                    ErrMessage = (ex.Message != null) ? ex.Message.ToString() : "",
                    ErrMethod = "GetFormattedAddress | SenderID = " + _Address.SenderId,
                    ErrMethodPayload = JsonConvert.SerializeObject(_Address),
                    ErrProcedure = (ex.Source != null) ? ex.Source.ToString() : "",
                    ErrRaisedDate = DateTime.Now,
                    ErrStackTrace = (ex.StackTrace != null) ? ex.StackTrace.ToString() : "",
                    UserId = 0
                };
                await _LogRepo.AddLog(_ErrorLog);
                //<<<<<End Register Log>>>>>

                return await Task.FromResult(_SenderAddress);
            }
        }
        public async Task<SenderAddressModel> GetFormattedAddress(List<JcdSenderAddress> AddressList)
        {
            if(AddressList.Count>0)
            {
                List<AddressModel> senderAddressList = new List<AddressModel>();
                foreach (JcdSenderAddress _Address in AddressList)
                {
                    try
                    {
                        JcdPickupAndDeliveryAreaRepo _AreaRepo = new JcdPickupAndDeliveryAreaRepo();
                        PickupAndDeliveryAreaModel _AreaModel = await _AreaRepo.GetAreaById(_Address.AreaId);

                        JcdPsUpazilaRepo _PsUpazilaRepo = new JcdPsUpazilaRepo();
                        UpazillaModel _UpazilaModel = await _PsUpazilaRepo.GetUpazillaById(_AreaModel.Area.PsUpazilaId);

                        JcdCityDistrictRepo _CityDistrictRepo = new JcdCityDistrictRepo();
                        CityDistrictModel _CityDistrictModel = await _CityDistrictRepo.GetCityById(_UpazilaModel.Upazilla.CityDistrictId);

                        JcdProvinceStateDivisionRepo _StateRepo = new JcdProvinceStateDivisionRepo();
                        ProvinceModel _StateModel = await _StateRepo.GetStateById(_CityDistrictModel.City.ProvinceId);

                        JcdCountryInfoRepo _CountryRepo = new JcdCountryInfoRepo();
                        CountryInfoModel _CountryModel = await _CountryRepo.GetCountryById(_StateModel.State.CountryId);

                        senderAddressList.Add(new AddressModel
                        {
                            ID = _Address.Id,
                            AddressLine1 = _Address.AddressLine1,
                            AddressLine2 = _Address.AddressLine2,
                            AddressType = _Address.AddressType,
                            EntryDate = _Address.EntryDate,
                            HouseOrRoadNo = _Address.HouseOrRoadNo,
                            LandMark = _Address.Landmark,
                            PostalCode = _Address.PostalCode,
                            SenderId = _Address.SenderId,
                            Street = _Address.Street,
                            Lat = _Address.LatitudesData,
                            Lang = _Address.LongitudesData,
                            AreaId = _AreaModel.Area.AreaId,
                            AreaName = _AreaModel.Area.AreaName,
                            PsUpazillaId = _UpazilaModel.Upazilla.PsUpazilaId,
                            PsUpazillaName = _UpazilaModel.Upazilla.PsUpazilaName,
                            DistrictCityId = _CityDistrictModel.City.CityDistrictId,
                            DistrictCityName = _CityDistrictModel.City.CityDistrictName,
                            ProvinceId = _StateModel.State.ProvinceId,
                            ProvinceName = _StateModel.State.ProvinceName,
                            CountryId = _CountryModel.Country.CountryId,
                            CountryName = _CountryModel.Country.CountryName,
                            ActiveStatus = _Address.ActiveStatus
                        });
                    }
                    catch (Exception ex)
                    {
                        SenderAddressModel _SenderAddress = new SenderAddressModel
                        {
                            Status = "error",
                            Error = new ErrorModel
                            {
                                ErrorCode = "505",
                                InnerException = (ex.InnerException != null) ? ex.InnerException.Message.ToString() : "",
                                Message = (ex.Message != null) ? ex.Message.ToString() : "",
                                StackTrace = (ex.StackTrace != null) ? ex.StackTrace.ToString() : "",
                            }
                        };

                        //<<<<<Start Register Log>>>>>
                        JcdErrorLogRepo _LogRepo = new JcdErrorLogRepo();
                        JcdErrorLog _ErrorLog = new JcdErrorLog
                        {
                            ErrEntity = (ex.Message != null) ? ex.Message.ToString() : "",
                            ErrInnerException = (ex.InnerException != null) ? ex.InnerException.Message.ToString() : "",
                            ErrMessage = (ex.Message != null) ? ex.Message.ToString() : "",
                            ErrMethod = "GetFormattedAddress | SenderID = " + _Address.SenderId,
                            ErrMethodPayload = JsonConvert.SerializeObject(_Address),
                            ErrProcedure = (ex.Source != null) ? ex.Source.ToString() : "",
                            ErrRaisedDate = DateTime.Now,
                            ErrStackTrace = (ex.StackTrace != null) ? ex.StackTrace.ToString() : "",
                            UserId = 0
                        };
                        await _LogRepo.AddLog(_ErrorLog);
                        //<<<<<End Register Log>>>>>

                        return await Task.FromResult(_SenderAddress);
                    }
                }

                SenderAddressModel SenderAddressModel = new SenderAddressModel
                {
                    Status = "Success",
                    SenderAddressList = senderAddressList
                };
                return await Task.FromResult(SenderAddressModel);
            } else
            {
                SenderAddressModel _SenderAddress = new SenderAddressModel
                {
                    Status = "error",
                    Error = new ErrorModel
                    {
                        ErrorCode = "515",
                        InnerException =  "",
                        Message = "No Address found!",
                        StackTrace = "",
                    }
                };
                return await Task.FromResult(_SenderAddress);
            }                        
        }
        public async Task<string> FormatAddress(JcdSenderAddress _AddressModel)
        {
            string address = "";
            JcdPickupAndDeliveryAreaRepo _AreaRepo = new JcdPickupAndDeliveryAreaRepo();
            PickupAndDeliveryAreaModel _Area = await _AreaRepo.GetAreaById(_AddressModel.AreaId);

            JcdPsUpazilaRepo _UpazillaRepo = new JcdPsUpazilaRepo();
            UpazillaModel _UpazillaModel = await _UpazillaRepo.GetUpazillaById(_Area.Area.PsUpazilaId);

            JcdCityDistrictRepo _CityRepo = new JcdCityDistrictRepo();
            CityDistrictModel _CityModel = await _CityRepo.GetCityById(_UpazillaModel.Upazilla.CityDistrictId);

            JcdProvinceStateDivisionRepo _ProvinceRepo = new JcdProvinceStateDivisionRepo();
            ProvinceModel _ProvinceModel = await _ProvinceRepo.GetStateById(_CityModel.City.ProvinceId);

            JcdCountryInfoRepo _CountryRepo = new JcdCountryInfoRepo();
            CountryInfoModel _CountryModel = await _CountryRepo.GetCountryById(_ProvinceModel.State.CountryId);

            if (_AddressModel.Landmark != "" | _AddressModel.Landmark != null)
            {
                address += _AddressModel.Landmark;
            }

            if (_AddressModel.HouseOrRoadNo != "" | _AddressModel.HouseOrRoadNo != null)
            {
                if (address != "")
                {
                    address += ", " + _AddressModel.HouseOrRoadNo;
                }
                else
                {
                    address = _AddressModel.HouseOrRoadNo;
                }
            }

            if (_AddressModel.Street != "" | _AddressModel.Street != null)
            {
                if (address != "")
                {
                    address += ", " + _AddressModel.Street;
                }
                else
                {
                    address = _AddressModel.Street;
                }
            }

            if (_AddressModel.AddressLine1 != "" | _AddressModel.AddressLine1 != null)
            {
                if (address != "")
                {
                    address += ", " + _AddressModel.AddressLine1;
                }
                else
                {
                    address = _AddressModel.AddressLine1;
                }
            }

            if (_Area.Status == "Success")
            {
                if (address != "")
                {
                    address += ", " + _Area.Area.AreaName;
                }
                else
                {
                    address = _Area.Area.AreaName;
                }
            }

            if (_UpazillaModel.Status == "Success")
            {
                if (address != "")
                {
                    address += ", " + _UpazillaModel.Upazilla.PsUpazilaName;
                }
                else
                {
                    address = _UpazillaModel.Upazilla.PsUpazilaName;
                }
            }

            if (_CityModel.Status == "Success")
            {
                if (address != "")
                {
                    address += ", " + _CityModel.City.CityDistrictName;
                }
                else
                {
                    address = _CityModel.City.CityDistrictName;
                }
            }

            if (_ProvinceModel.Status == "Success")
            {
                if (address != "")
                {
                    address += ", " + _ProvinceModel.State.ProvinceName + " Division";
                }
                else
                {
                    address = _ProvinceModel.State.ProvinceName + " Division";
                }
            }

            if (_CountryModel.Status == "Success")
            {
                if (address != "")
                {
                    address += ", " + _CountryModel.Country.CountryName;
                }
                else
                {
                    address = _CountryModel.Country.CountryName;
                }
            }

            return await Task.FromResult(WebUtility.UrlEncode(address));
        }
        public async Task<CombinedAddressModel> GetAddressModelByArea(int AreaId)
        {
            JcdPickupAndDeliveryAreaRepo _AreaRepo = new JcdPickupAndDeliveryAreaRepo();
            PickupAndDeliveryAreaModel _AreaModel = await _AreaRepo.GetAreaById(AreaId);

            JcdPickupAndDeliveryZoneRepo _ZoneRepo = new JcdPickupAndDeliveryZoneRepo();
            PickupAndDeliveryZoneModel _ZoneModel = await _ZoneRepo.GetZoneById((int)_AreaModel.Area.ZoneId);

            JcdPsUpazilaRepo _UpazillaRepo = new JcdPsUpazilaRepo();
            UpazillaModel _UpazillaModel = await _UpazillaRepo.GetUpazillaById(_AreaModel.Area.PsUpazilaId);

            JcdCityDistrictRepo _DistrictRepo = new JcdCityDistrictRepo();
            CityDistrictModel _DistrictModel = await _DistrictRepo.GetCityById(_UpazillaModel.Upazilla.CityDistrictId);

            JcdProvinceStateDivisionRepo _StateRepo = new JcdProvinceStateDivisionRepo();
            ProvinceModel _StateModel = await _StateRepo.GetStateById(_DistrictModel.City.ProvinceId);

            JcdCountryInfoRepo _CountryRepo = new JcdCountryInfoRepo();
            CountryInfoModel _CountryModel = await _CountryRepo.GetCountryById(_StateModel.State.CountryId);

            CombinedAddressModel _AddressModel = new CombinedAddressModel
            {
                Countries = _CountryModel,
                Divisions = _StateModel,
                Districts = _DistrictModel,
                PoliceStations_Upazillas = _UpazillaModel,
                Zones = _ZoneModel,
                Areas = _AreaModel
            };

            return await Task.FromResult(_AddressModel);
        }
        public async Task<SenderAddressModel> GetAddressFromGeoCode(long SenderId, float Latitude, float Longitude)
        {
            try
            {
                GoogleClient _GoogleClient = new GoogleClient(GOOGLE_MAPS_API_KEY);
                int AreaId = await _GoogleClient.GetAreaFromPolygon(Latitude, Longitude);
                if (AreaId != 0)
                {
                    AddressAreaModel _AreaAddressModel = await Task.FromResult(_Context.AddressAreaModel
                                                         .FromSqlRaw($"SP_JCD_GET_ADDRESS_MODEL_BY_AREA_ID {AreaId}")
                                                         .AsEnumerable()
                                                         .FirstOrDefault());

                    GeocodingModel _GeoCodingModel = await _GoogleClient.GetAddressFromGeoCode(Latitude, Longitude);

                    AddressModel _AddressInfo = new AddressModel
                    {
                        AddressType = "Other",
                        AreaId = AreaId,
                        AreaName = _AreaAddressModel.AreaName,
                        CountryId = _AreaAddressModel.CountryId,
                        CountryName = _AreaAddressModel.CountryName,
                        DistrictCityId = _AreaAddressModel.DistrictCityId,
                        DistrictCityName = _AreaAddressModel.DistrictCityName,
                        Lang = (decimal)Longitude,
                        Lat = (decimal)Latitude,
                        ProvinceId = _AreaAddressModel.ProvinceId,
                        ProvinceName = _AreaAddressModel.ProvinceName,
                        PsUpazillaId = _AreaAddressModel.PsUpazillaId,
                        PsUpazillaName = _AreaAddressModel.PsUpazillaName,
                        SenderId = SenderId,
                        Street = "",
                        ActiveStatus = 1,
                        AddressLine1 = "",
                        AddressLine2 = "",
                        HouseOrRoadNo = "",
                        LandMark = "",
                        PostalCode = "",
                        FormattedAddress = _GeoCodingModel.results[0].formatted_address,
                        EntryDate = DateTime.Today
                    };


                    foreach (AddressComponent _Component in _GeoCodingModel.results[0].address_components)
                    {
                        if (_Component.types.Contains("premise"))
                        {
                            _AddressInfo.LandMark = _Component.long_name;
                        }
                        else if (_Component.types.Contains("street_number"))
                        {
                            _AddressInfo.Street = _Component.long_name;
                        }
                        else if (_Component.types.Contains("street_address"))
                        {
                            if (_AddressInfo.Street == "")
                            {
                                _AddressInfo.Street = _Component.long_name;
                            }
                            else
                            {
                                _AddressInfo.Street += ", " + _Component.long_name;
                            }
                        }
                        else if (_Component.types.Contains("route"))
                        {
                            if (_AddressInfo.Street == "")
                            {
                                _AddressInfo.Street = _Component.long_name;
                            }
                            else
                            {
                                _AddressInfo.Street += ", " + _Component.long_name;
                            }
                        }
                        else if (_Component.types.Contains("sublocality"))
                        {
                            _AddressInfo.AddressLine1 = _Component.long_name;
                        }
                        else if (_Component.types.Contains("postal_code"))
                        {
                            _AddressInfo.PostalCode = _Component.long_name;
                        }
                    }

                    SenderAddressModel _SenderAddressModel = new SenderAddressModel
                    {
                        Status = "Success",
                        SenderAddress = _AddressInfo
                    };

                    return await Task.FromResult(_SenderAddressModel);
                }
                else
                {
                    SenderAddressModel _SenderAddressModel = new SenderAddressModel
                    {
                        Status = "error",
                        Error = new ErrorModel
                        {
                            ErrorCode = "520",
                            InnerException = "",
                            Message = "Out of service zone",
                            StackTrace = ""
                        }
                    };

                    return await Task.FromResult(_SenderAddressModel);
                }
            } catch(Exception ex)
            {
                SenderAddressModel _SenderAddress = new SenderAddressModel
                {
                    Status = "error",
                    Error = new ErrorModel
                    {
                        ErrorCode = "505",
                        InnerException = (ex.InnerException != null) ? ex.InnerException.Message.ToString() : "",
                        Message = (ex.Message != null) ? ex.Message.ToString() : "",
                        StackTrace = (ex.StackTrace != null) ? ex.StackTrace.ToString() : "",
                    }
                };

                //<<<<<Start Register Log>>>>>
                JcdErrorLogRepo _LogRepo = new JcdErrorLogRepo();
                JcdErrorLog _ErrorLog = new JcdErrorLog
                {
                    ErrEntity = (ex.Message != null) ? ex.Message.ToString() : "",
                    ErrInnerException = (ex.InnerException != null) ? ex.InnerException.Message.ToString() : "",
                    ErrMessage = (ex.Message != null) ? ex.Message.ToString() : "",
                    ErrMethod = "GetAddressFromGeoCode",
                    ErrMethodPayload = "SenderId = " + SenderId + ", Latitude= " + Latitude + ", Longitude= " + Longitude,
                    ErrProcedure = (ex.Source != null) ? ex.Source.ToString() : "",
                    ErrRaisedDate = DateTime.Now,
                    ErrStackTrace = (ex.StackTrace != null) ? ex.StackTrace.ToString() : "",
                    UserId = 0
                };
                await _LogRepo.AddLog(_ErrorLog);
                //<<<<<End Register Log>>>>>

                return await Task.FromResult(_SenderAddress);
            }
        }
    }
}
