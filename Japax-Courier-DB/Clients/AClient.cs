using Japax_Courier_DB.Cipher;
using Japax_Courier_DB.DBModels.Auth.Models.Response;
using Japax_Courier_DB.DBModels.CommonModels.Response;
using Japax_Courier_DB.DBModels.Courier;
using Japax_Courier_DB.DBModels.Courier.ResponseModels;
using Japax_Courier_DB.Repositories.Auth;
using Japax_Courier_DB.Repositories.Courier;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Japax_Courier_DB.Clients
{
    //Address Client
    public class AClient
    {
        public async Task<PayLoadModel> GetSenderAddressById(string SenderId)
        {
            //Get Start Time
            DateTime StartTime = DateTime.Now;

            JpxUserLoginInfoRepo _UserRepo = new JpxUserLoginInfoRepo();
            JpxUserLoginInfoModel _UserAuth = await _UserRepo.GetUserById(Convert.ToInt64(SenderId));
            CipherClient _CipherClient = new CipherClient(_UserAuth.UserInfo.DeviceId, _UserAuth.UserInfo.SecretKey);

            JcdSenderAddressRepo jcdSenderAddress = new JcdSenderAddressRepo();

            SenderAddressModel SenderAddress = await jcdSenderAddress.GetAddressById(SenderId + "");

            string senderAddressJson = JsonConvert.SerializeObject(SenderAddress.SenderAddressList);

            CipherPayload _CipherPayload = await _CipherClient.EncryptText(senderAddressJson.ToString());

            if (_CipherPayload.Status == "Success")
            {
                PayLoadModel _PayloadModel = new PayLoadModel
                {
                    SenderID = SenderId + "",
                    ExecutionTime = (DateTime.Now - StartTime).TotalMilliseconds.ToString() + " ms",
                    PayLoad = _CipherPayload.PayLoad
                };

                return await Task.FromResult(_PayloadModel);
            }
            else
            {
                PayLoadModel _PayLoadModel = new PayLoadModel
                {
                    SenderID = SenderId + "",
                    PayLoad = JsonConvert.SerializeObject(new ErrorModel
                    {
                        ErrorCode = "511",
                        Message = "Invalid user info or data not found. Please contact with admin.",
                        InnerException = "",
                        StackTrace = ""
                    })
                };
                return await Task.FromResult(_PayLoadModel);
            }
        }
        public async Task<PayLoadModel> AddSenderAddress(PayLoadModel _payLoad)
        {
            //Get Start Time
            DateTime StartTime = DateTime.Now;

            JpxUserLoginInfoRepo _UserRepo = new JpxUserLoginInfoRepo();
            JpxUserLoginInfoModel _UserAuth = await _UserRepo.GetUserById(Convert.ToInt64(_payLoad.SenderID));
            CipherClient _CipherClient = new CipherClient(_UserAuth.UserInfo.DeviceId, _UserAuth.UserInfo.SecretKey);
            CipherPayload _CipherPayload;

            _CipherPayload = await _CipherClient.DecryptText(_payLoad.PayLoad);

            if (_CipherPayload.Status == "Success")
            {
                JcdSenderAddress __addressModel = JsonConvert.DeserializeObject<JcdSenderAddress>(_CipherPayload.PayLoad);

                JcdSenderAddressRepo _SenderAddressRepo = new JcdSenderAddressRepo();

                SenderAddressModel AddressModel = await _SenderAddressRepo.AddNew(__addressModel);

                _CipherPayload = await _CipherClient.EncryptText(JsonConvert.SerializeObject(AddressModel));

                if (_CipherPayload.Status == "Success")
                {
                    PayLoadModel ResponsePayload = new PayLoadModel
                    {
                        SenderID = _payLoad.SenderID,
                        ExecutionTime = (DateTime.Now - StartTime).TotalMilliseconds.ToString() + " ms",
                        PayLoad = _CipherPayload.PayLoad
                    };

                    return await Task.FromResult(ResponsePayload);
                }
                else
                {
                    PayLoadModel ResponsePayload = new PayLoadModel
                    {
                        SenderID = _payLoad.SenderID,
                        ExecutionTime = (DateTime.Now - StartTime).TotalMilliseconds.ToString() + " ms",
                        PayLoad = JsonConvert.SerializeObject(new ErrorModel
                        {
                            ErrorCode = "511",
                            Message = "Invalid user info or data not found. Please contact with admin.",
                            InnerException = "",
                            StackTrace = ""
                        })
                    };

                    return await Task.FromResult(ResponsePayload);
                }
            }
            else
            {
                PayLoadModel ResponsePayload = new PayLoadModel
                {
                    SenderID = _payLoad.SenderID,
                    ExecutionTime = (DateTime.Now - StartTime).TotalMilliseconds.ToString() + " ms",
                    PayLoad = JsonConvert.SerializeObject(new ErrorModel
                    {
                        ErrorCode = "511",
                        Message = "Invalid user info or data not found. Please contact with admin.",
                        InnerException = "",
                        StackTrace = ""
                    })
                };

                return await Task.FromResult(ResponsePayload);
            }
        }
        public async Task<PayLoadModel> UpdateSenderAddress(PayLoadModel _payLoad)
        {
            //Get Start Time
            DateTime StartTime = DateTime.Now;

            JpxUserLoginInfoRepo _UserRepo = new JpxUserLoginInfoRepo();
            JpxUserLoginInfoModel _UserAuth = await _UserRepo.GetUserById(Convert.ToInt64(_payLoad.SenderID));
            CipherClient _CipherClient = new CipherClient(_UserAuth.UserInfo.DeviceId, _UserAuth.UserInfo.SecretKey);
            CipherPayload _CipherPayload;

            _CipherPayload = await _CipherClient.DecryptText(_payLoad.PayLoad);

            if (_CipherPayload.Status == "Success")
            {
                JcdSenderAddress __addressModel = JsonConvert.DeserializeObject<JcdSenderAddress>(_CipherPayload.PayLoad);
                JcdSenderAddressRepo _SenderAddressRepo = new JcdSenderAddressRepo();

                if(__addressModel.SenderId !=0)
                {
                    SenderAddressModel AddressModel = await _SenderAddressRepo.Update(__addressModel);

                    _CipherPayload = await _CipherClient.EncryptText(JsonConvert.SerializeObject(AddressModel));

                    if (_CipherPayload.Status == "Success")
                    {
                        PayLoadModel ResponsePayload = new PayLoadModel
                        {
                            SenderID = _payLoad.SenderID,
                            ExecutionTime = (DateTime.Now - StartTime).TotalMilliseconds.ToString() + " ms",
                            PayLoad = _CipherPayload.PayLoad
                        };

                        return await Task.FromResult(ResponsePayload);
                    }
                    else
                    {
                        PayLoadModel ResponsePayload = new PayLoadModel
                        {
                            SenderID = _payLoad.SenderID,
                            ExecutionTime = (DateTime.Now - StartTime).TotalMilliseconds.ToString() + " ms",
                            PayLoad = JsonConvert.SerializeObject(new ErrorModel
                            {
                                ErrorCode = "511",
                                Message = "Invalid user info or data not found. Please contact with admin.",
                                InnerException = "",
                                StackTrace = ""
                            })
                        };

                        return await Task.FromResult(ResponsePayload);
                    }
                } else
                {
                    PayLoadModel ResponsePayload = new PayLoadModel
                    {
                        SenderID = _payLoad.SenderID,
                        ExecutionTime = (DateTime.Now - StartTime).TotalMilliseconds.ToString() + " ms",
                        PayLoad = JsonConvert.SerializeObject(new ErrorModel
                        {
                            ErrorCode = "514",
                            Message = "Sender ID required.",
                            InnerException = "",
                            StackTrace = ""
                        })
                    };

                    return await Task.FromResult(ResponsePayload);
                }                
            }
            else
            {
                PayLoadModel ResponsePayload = new PayLoadModel
                {
                    SenderID = _payLoad.SenderID,
                    ExecutionTime = (DateTime.Now - StartTime).TotalMilliseconds.ToString() + " ms",
                    PayLoad = JsonConvert.SerializeObject(new ErrorModel
                    {
                        ErrorCode = "511",
                        Message = "Invalid user info or data not found. Please contact with admin.",
                        InnerException = "",
                        StackTrace = ""
                    })
                };

                return await Task.FromResult(ResponsePayload);
            }
        }
        public async Task<CommonResponseModel> DeleteSenderAddress(PayLoadModel _payLoad)
        {
            //Get Start Time
            DateTime StartTime = DateTime.Now;

            JpxUserLoginInfoRepo _UserRepo = new JpxUserLoginInfoRepo();
            JpxUserLoginInfoModel _UserAuth = await _UserRepo.GetUserById(Convert.ToInt64(_payLoad.SenderID));
            CipherClient _CipherClient = new CipherClient(_UserAuth.UserInfo.DeviceId, _UserAuth.UserInfo.SecretKey);

            CipherPayload _CipherPayload = await _CipherClient.DecryptText(_payLoad.PayLoad);

            if (_CipherPayload.Status == "Success")
            {
                JcdSenderAddress __addressModel = JsonConvert.DeserializeObject<JcdSenderAddress>(_CipherPayload.PayLoad);
                JcdSenderAddressRepo _SenderAddressRepo = new JcdSenderAddressRepo();

                return await _SenderAddressRepo.Remove(__addressModel);
            }
            else
            {
                CommonResponseModel _responseModel = new CommonResponseModel
                {
                    Status = "Error",
                    ExecutionTime = (DateTime.Now - StartTime).TotalMilliseconds.ToString() + " ms",
                    Error = new ErrorModel
                    {
                        ErrorCode = "505",
                        InnerException = "",
                        Message = "Invalid user info or data not found. Please contact with admin.",
                        StackTrace = "",
                    }
                };

                return await Task.FromResult(_responseModel);
            }
        }
        public async Task<PayLoadModel> DeactivateAddress(long AddressId, string SenderID)
        {
            //Get Start Time
            DateTime StartTime = DateTime.Now;

            JpxUserLoginInfoRepo _UserRepo = new JpxUserLoginInfoRepo();
            JpxUserLoginInfoModel _UserAuth = await _UserRepo.GetUserById(Convert.ToInt64(SenderID));
            CipherClient _CipherClient = new CipherClient(_UserAuth.UserInfo.DeviceId, _UserAuth.UserInfo.SecretKey);

            JcdSenderAddressRepo _AddressRepo = new JcdSenderAddressRepo();
            CommonResponseModel ResponseModel = await _AddressRepo.DeactivateAddress(AddressId);

            CipherPayload _CipherPayload = await _CipherClient.EncryptText(JsonConvert.SerializeObject(ResponseModel));

            if (_CipherPayload.Status == "Success")
            {
                PayLoadModel PayLoad = new PayLoadModel
                {
                    PayLoad = _CipherPayload.PayLoad,
                    ExecutionTime = (DateTime.Now - StartTime).TotalMilliseconds.ToString() + " ms",
                    SenderID = SenderID
                };

                return await Task.FromResult(PayLoad);
            }
            else
            {
                PayLoadModel PayLoad = new PayLoadModel
                {
                    SenderID = SenderID,
                    ExecutionTime = (DateTime.Now - StartTime).TotalMilliseconds.ToString() + " ms",
                    PayLoad = JsonConvert.SerializeObject(new ErrorModel
                    {
                        ErrorCode = "511",
                        Message = "Invalid user info or data not found. Please contact with admin.",
                        InnerException = "",
                        StackTrace = ""
                    })
                };

                return await Task.FromResult(PayLoad);
            }
        }
        public async Task<CombinedAddressModel> GetAddressModel()
        {
            //Get Start Time
            DateTime StartTime = DateTime.Now;

            JcdCountryInfoRepo _CountryRepo = new JcdCountryInfoRepo();
            CountryInfoModel _CountryModel = await _CountryRepo.GetActiveCounties();

            JcdProvinceStateDivisionRepo _StateRepo = new JcdProvinceStateDivisionRepo();
            ProvinceModel _StateModel = await _StateRepo.GetActiveStates();

            JcdCityDistrictRepo _DistrictRepo = new JcdCityDistrictRepo();
            CityDistrictModel _DistrictModel = await _DistrictRepo.GetActiveCities();

            JcdPsUpazilaRepo _UpazillaRepo = new JcdPsUpazilaRepo();
            UpazillaModel _UpazillaModel = await _UpazillaRepo.GetActiveUpazilla();

            JcdPickupAndDeliveryZoneRepo _ZoneRepo = new JcdPickupAndDeliveryZoneRepo();
            PickupAndDeliveryZoneModel _ZoneModel = await _ZoneRepo.GetActiveZones();

            JcdPickupAndDeliveryAreaRepo _AreaRepo = new JcdPickupAndDeliveryAreaRepo();
            PickupAndDeliveryAreaModel _AreaModel = await _AreaRepo.GetActiveAreas();

            CombinedAddressModel _AddressModel = new CombinedAddressModel
            {
                ExecutionTime = (DateTime.Now - StartTime).TotalMilliseconds.ToString() + " ms",
                Countries = _CountryModel,
                Divisions = _StateModel,
                Districts = _DistrictModel,
                PoliceStations_Upazillas = _UpazillaModel,
                Zones = _ZoneModel,
                Areas = _AreaModel
            };

            return await Task.FromResult(_AddressModel);
        }
        public async Task<PayLoadModel> GetAddressFromGeoCode(long SenderId, float Latitude, float Longitude)
        {
            //Get Start Time
            DateTime StartTime = DateTime.Now;

            JpxUserLoginInfoRepo _UserRepo = new JpxUserLoginInfoRepo();
            JpxUserLoginInfoModel _UserAuth = await _UserRepo.GetUserById(Convert.ToInt64(SenderId));
            CipherClient _CipherClient = new CipherClient(_UserAuth.UserInfo.DeviceId, _UserAuth.UserInfo.SecretKey);

            JcdSenderAddressRepo _AddressRepo = new JcdSenderAddressRepo();
            SenderAddressModel _AddressModel = await _AddressRepo.GetAddressFromGeoCode(SenderId, Latitude, Longitude);

            CipherPayload _CipherPayload = await _CipherClient.EncryptText(JsonConvert.SerializeObject(_AddressModel));

            if (_CipherPayload.Status == "Success")
            {
                PayLoadModel ResponsePayload = new PayLoadModel
                {
                    SenderID = SenderId.ToString(),
                    ExecutionTime = (DateTime.Now - StartTime).TotalMilliseconds.ToString() + " ms",
                    PayLoad = _CipherPayload.PayLoad
                };

                return await Task.FromResult(ResponsePayload);
            } else
            {
                PayLoadModel ResponsePayload = new PayLoadModel
                {
                    SenderID = SenderId + "",
                    ExecutionTime = (DateTime.Now - StartTime).TotalMilliseconds.ToString() + " ms",
                    PayLoad = JsonConvert.SerializeObject(new ErrorModel
                    {
                        ErrorCode = "511",
                        Message = "Invalid user info or data not found. Please contact with admin.",
                        InnerException = "",
                        StackTrace = ""
                    })
                };
                return await Task.FromResult(ResponsePayload);
            }
        }
    }
}
