using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Japax_Courier_DB.DBModels.Courier;
using Japax_Courier_DB.DBModels.CommonModels.Response;
using Japax_Courier_DB.DBModels.Courier.RequestModels;
using Japax_Courier_DB.DBModels.Courier.ResponseModels;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Newtonsoft.Json;
using Microsoft.Data.SqlClient;
using System.Data;
using Japax_Courier_DB.DBModels.CommonModels;
using System.Net.Http;

namespace Japax_Courier_DB.Repositories.Courier
{
    public class JcdPickupAndDeliveryRequestRepo
    {
        JpxCourierContext _Context = new JpxCourierContext();

        private double PageSize = 10;
        private string AdminNotificationUrl = "http://admin.atc.co.bd/api/Notification/GetNotification";
        public async Task<CommonResponseModel> AddRequest(PickupRequestModel _Request)
        {
            try
            {
                if (_Request.RequestInfo != null ^ _Request.ProductDetails != null ^ _Request.ProductDetails.Count > 0)
                {
                    string RequestInfo = JsonConvert.SerializeObject(_Request.RequestInfo, Formatting.None, new JsonSerializerSettings
                    {
                        NullValueHandling = NullValueHandling.Ignore
                    });

                    string ProductInfo = JsonConvert.SerializeObject(_Request.ProductDetails, Formatting.None, new JsonSerializerSettings
                    {
                        NullValueHandling = NullValueHandling.Ignore
                    });

                    //await _Context.Database.ExecuteSqlRawAsync($"SP_JSON_PICKUP_AND_DELIVERY_REQ @P_OPT = 'I'," +
                    //                                           $"@P_JSON_REQUEST_DET = '{RequestInfo}'," +
                    //                                           $"@P_JSON_PRODUCT_DET = '{ProductInfo}'");

                    using (var command = _Context.Database.GetDbConnection().CreateCommand())
                    {
                        command.CommandText = "SP_JSON_PICKUP_AND_DELIVERY_REQ";

                        SqlParameter OperationParam = new SqlParameter();
                        OperationParam.ParameterName = "@P_OPT";
                        OperationParam.Value = "I";

                        SqlParameter RequestInfoParam = new SqlParameter();
                        RequestInfoParam.ParameterName = "@P_JSON_REQUEST_DET";
                        RequestInfoParam.Value = RequestInfo;

                        SqlParameter ProductDetailsParam = new SqlParameter();
                        ProductDetailsParam.ParameterName = "@P_JSON_PRODUCT_DET";
                        ProductDetailsParam.Value = ProductInfo;

                        SqlParameter AcknowledgeByIdParam = new SqlParameter();
                        AcknowledgeByIdParam.ParameterName = "@P_ACKNOWLEDGE_BY_IN";
                        AcknowledgeByIdParam.Value = _Request.AcknowledgeByIn;

                        command.Parameters.Add(OperationParam);
                        command.Parameters.Add(RequestInfoParam);
                        command.Parameters.Add(ProductDetailsParam);
                        command.Parameters.Add(AcknowledgeByIdParam);

                        command.CommandType = CommandType.StoredProcedure;

                        await _Context.Database.OpenConnectionAsync();

                        await command.ExecuteReaderAsync();
                    }

                    CommonResponseModel _ResponseModel = new CommonResponseModel
                    {
                        Status = "Success"
                    };

                    //Send Notification to Admin
                    AdminNotificationPayloadModel PayLoad = new AdminNotificationPayloadModel
                    {
                        NotificationTitle = "Attention!",
                        NotificationMessage = "A new request received."
                    };

                    var formData = new StringContent(JsonConvert.SerializeObject(PayLoad), Encoding.UTF8, "application/json");

                    var request = new HttpRequestMessage(HttpMethod.Post, AdminNotificationUrl)
                    {
                        Content = formData
                    };

                    HttpClient client = new HttpClient();

                    //await client.SendAsync(request);

                    return await Task.FromResult(_ResponseModel);
                }
                else
                {
                    CommonResponseModel _ResponseModel = new CommonResponseModel
                    {
                        Status = "error",
                        Error = new ErrorModel
                        {
                            ErrorCode = "515",
                            InnerException = "",
                            Message = "Invalid Data!",
                            StackTrace = ""
                        }
                    };
                    return await Task.FromResult(_ResponseModel);
                }
            }
            catch (Exception ex)
            {
                CommonResponseModel _ResponseModel = new CommonResponseModel
                {
                    Status = "error",
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
                    ErrMethod = "AddRequest",
                    ErrMethodPayload = JsonConvert.SerializeObject(_Request),
                    ErrProcedure = (ex.Source != null) ? ex.Source.ToString() : "",
                    ErrRaisedDate = DateTime.Now,
                    ErrStackTrace = (ex.StackTrace != null) ? ex.StackTrace.ToString() : "",
                    UserId = 0
                };
                await _LogRepo.AddLog(_ErrorLog);
                //<<<<<End Register Log>>>>>

                return await Task.FromResult(_ResponseModel);
            }
        }
        public async Task<CommonResponseModel> UpdateRequest(PickupRequestModel _Request)
        {
            try
            {
                if (_Request.RequestInfo != null ^ _Request.ProductDetails != null ^ _Request.ProductDetails.Count > 0)
                {
                    //PickupDeliveryRequestModel _PickupDeliveryRequestModel = await GetFormattedPickupRequestModel(_Request);

                    string RequestInfo = JsonConvert.SerializeObject(_Request.RequestInfo);
                    string ProductInfo = JsonConvert.SerializeObject(_Request.ProductDetails);

                    //await _Context.Database.ExecuteSqlRawAsync($"SP_JSON_PICKUP_AND_DELIVERY_REQ @P_OPT = 'U'," +
                    //                                           $"@P_JSON_REQUEST_DET = {RequestInfo}," +
                    //                                           $"@P_JSON_PRODUCT_DET = {ProductInfo}");

                    using (var command = _Context.Database.GetDbConnection().CreateCommand())
                    {
                        command.CommandText = "SP_JSON_PICKUP_AND_DELIVERY_REQ";

                        SqlParameter OperationParam = new SqlParameter();
                        OperationParam.ParameterName = "@P_OPT";
                        OperationParam.Value = "U";

                        SqlParameter RequestInfoParam = new SqlParameter();
                        RequestInfoParam.ParameterName = "@P_JSON_REQUEST_DET";
                        RequestInfoParam.Value = RequestInfo;

                        SqlParameter ProductDetailsParam = new SqlParameter();
                        ProductDetailsParam.ParameterName = "@P_JSON_PRODUCT_DET";
                        ProductDetailsParam.Value = ProductInfo;

                        SqlParameter AcknowledgeByIdParam = new SqlParameter();
                        AcknowledgeByIdParam.ParameterName = "@P_ACKNOWLEDGE_BY_IN";
                        AcknowledgeByIdParam.Value = _Request.AcknowledgeByIn;

                        command.Parameters.Add(OperationParam);
                        command.Parameters.Add(RequestInfoParam);
                        command.Parameters.Add(ProductDetailsParam);
                        command.Parameters.Add(AcknowledgeByIdParam);

                        command.CommandType = CommandType.StoredProcedure;

                        await _Context.Database.OpenConnectionAsync();

                        await command.ExecuteReaderAsync();
                    }

                    CommonResponseModel _ResponseModel = new CommonResponseModel
                    {
                        Status = "Success"
                    };

                    return await Task.FromResult(_ResponseModel);
                }
                else
                {
                    CommonResponseModel _ResponseModel = new CommonResponseModel
                    {
                        Status = "error",
                        Error = new ErrorModel
                        {
                            ErrorCode = "515",
                            InnerException = "",
                            Message = "Invalid Data!",
                            StackTrace = ""
                        }
                    };
                    return await Task.FromResult(_ResponseModel);
                }
            }
            catch (Exception ex)
            {
                CommonResponseModel _ResponseModel = new CommonResponseModel
                {
                    Status = "error",
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
                    ErrMethod = "UpdateRequest",
                    ErrMethodPayload = JsonConvert.SerializeObject(_Request),
                    ErrProcedure = (ex.Source != null) ? ex.Source.ToString() : "",
                    ErrRaisedDate = DateTime.Now,
                    ErrStackTrace = (ex.StackTrace != null) ? ex.StackTrace.ToString() : "",
                    UserId = 0
                };
                await _LogRepo.AddLog(_ErrorLog);
                //<<<<<End Register Log>>>>>

                return await Task.FromResult(_ResponseModel);
            }
        }
        public async Task<CommonResponseModel> CancelRequest(CancelRequestModel CancelModel)
        {
            try
            {
                var parameters = new[] {
                        new SqlParameter("@P_REQUEST_ID", SqlDbType.NVarChar) { Direction = ParameterDirection.Input, Value = CancelModel.RequestIds },
                        new SqlParameter("@P_CANCELLED_REASON", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = CancelModel.CancelReason },
                        new SqlParameter("@P_CANCELLED_BY", SqlDbType.TinyInt) { Direction = ParameterDirection.Input, Value = CancelModel.CancelledBy },
                        new SqlParameter("@P_CANCELLED_USER_ID", SqlDbType.Int) { Direction = ParameterDirection.Input, Value = CancelModel.CancelledUserId },
                        new SqlParameter("@P_COMPLAINED_BY", SqlDbType.TinyInt) { Direction = ParameterDirection.Input, Value = 0 },
                        new SqlParameter("@P_COMPLAINED_AGAINST", SqlDbType.TinyInt) { Direction = ParameterDirection.Input, Value = 0 },
                        new SqlParameter("@P_COMPLAINED_DET", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = "" },
                        new SqlParameter("@P_OPT", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = "C" }
                    };

                await _Context.Database.ExecuteSqlRawAsync($"SP_JCD_CANCEL_OR_COMPLAIN_REQUEST @P_REQUEST_ID, " +
                                                           $"@P_CANCELLED_REASON, @P_CANCELLED_BY, " +
                                                           $"@P_CANCELLED_USER_ID, @P_COMPLAINED_BY, @P_COMPLAINED_AGAINST," +
                                                           "@P_COMPLAINED_DET, @P_OPT", parameters);

                CommonResponseModel _ResponseModel = new CommonResponseModel
                {
                    Status = "Success"
                };

                if(CancelModel.CancelledBy == 1)
                {
                    JcdNotificationSmsMasterRepo NotificationRepo = new JcdNotificationSmsMasterRepo();
                    List<long> RequestIds = new List<long>(Array.ConvertAll(CancelModel.RequestIds.Split(','), Int64.Parse));
                    await NotificationRepo.SendNotification(15, 0, RequestIds);
                } else
                {
                    JcdNotificationSmsMasterRepo NotificationRepo = new JcdNotificationSmsMasterRepo();
                    List<long> RequestIds = new List<long>(Array.ConvertAll(CancelModel.RequestIds.Split(','), Int64.Parse));
                    await NotificationRepo.SendNotification(16, 0, RequestIds);
                }

                return await Task.FromResult(_ResponseModel);
            }
            catch (Exception ex)
            {
                CommonResponseModel _ResponseModel = new CommonResponseModel
                {
                    Status = "error",
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
                    ErrMethod = "CancelRequest",
                    ErrMethodPayload = JsonConvert.SerializeObject(CancelModel),
                    ErrProcedure = (ex.Source != null) ? ex.Source.ToString() : "",
                    ErrRaisedDate = DateTime.Now,
                    ErrStackTrace = (ex.StackTrace != null) ? ex.StackTrace.ToString() : "",
                    UserId = 0
                };
                await _LogRepo.AddLog(_ErrorLog);
                //<<<<<End Register Log>>>>>

                return await Task.FromResult(_ResponseModel);
            }
        }
        public async Task<CalculateChargeResponse> CalculateCharge(ChargeCalculateRequestModel _Request, long SenderId)
        {
            try
            {
                JcdAtcPickupAndDeliveryPointRepo AtcPointRepo = new JcdAtcPickupAndDeliveryPointRepo();

                foreach (ProductDetailsRequestModel Product in _Request.ProductDetails)
                {
                    //Convert Weight to kg
                    UmConvertModel Conversion;
                    Conversion = await ConvertUm(Product.PackageWeight, Product.PackageWeightUM);
                    Product.PackageWeightUM = Conversion.UM;
                    Product.PackageWeight = Conversion.value;

                    //Convert Dimension to inch
                    Conversion = await ConvertUm(Product.PackageHeight, Product.PackageDimensionUM);
                    Product.PackageHeight = Conversion.value;

                    Conversion = await ConvertUm(Product.PackageLength, Product.PackageDimensionUM);
                    Product.PackageLength = Conversion.value;

                    Conversion = await ConvertUm(Product.PackageWidth, Product.PackageDimensionUM);
                    Product.PackageDimensionUM = Conversion.UM;
                    Product.PackageWidth = Conversion.value;                    
                }

                //Check Package Dimension
                

                JcdSenderAddressRepo AddressRepo = new JcdSenderAddressRepo();

                AddressAreaModel SenderAddress = await Task.FromResult(_Context.AddressAreaModel
                                                         .FromSqlRaw($"SP_JCD_GET_ADDRESS_MODEL_BY_AREA_ID {_Request.SenderAreaId}")
                                                         .AsEnumerable()
                                                         .FirstOrDefault());
                AddressAreaModel ReceiverAddress = null;

                if (_Request.DropOutletId > 1)
                {

                    AtcPointModel DropOutlet = await AtcPointRepo.GetAtcOutletById(_Request.DropOutletId);

                    ReceiverAddress = await Task.FromResult(_Context.AddressAreaModel
                                                                             .FromSqlRaw($"SP_JCD_GET_ADDRESS_MODEL_BY_AREA_ID {DropOutlet.AtcPointList[0].AreaId}")
                                                                             .AsEnumerable()
                                                                             .FirstOrDefault());

                }
                else
                {
                    if (_Request.ReceiverAreaId > 0)
                    {
                        ReceiverAddress = await Task.FromResult(_Context.AddressAreaModel
                                                                                 .FromSqlRaw($"SP_JCD_GET_ADDRESS_MODEL_BY_AREA_ID {_Request.ReceiverAreaId}")
                                                                                 .AsEnumerable()
                                                                                 .FirstOrDefault());
                    }
                    else
                    {
                        CalculateChargeResponse _Response = new CalculateChargeResponse
                        {
                            Status = "error",
                            Error = new ErrorModel
                            {
                                ErrorCode = "523",
                                InnerException = "",
                                Message = "Receiver Area Id cannot be 0 (zero)",
                                StackTrace = ""
                            }
                        };
                        return await Task.FromResult(_Response);
                    }
                }


                int CityDistrictId = SenderAddress.DistrictCityId;
                int DestinationId = 0;
                List<CalculateChargeModel> ResponseList = new List<CalculateChargeModel>();
                //Define Destination ID
                if (SenderAddress.ProvinceId == ReceiverAddress.ProvinceId)
                {
                    if (SenderAddress.DistrictCityId == ReceiverAddress.DistrictCityId)
                    {
                        DestinationId = 1;
                    }
                    else
                    {
                        DestinationId = 2;
                    }
                }
                else
                {
                    DestinationId = 3;
                }

                //Define Pickup point
                int PickupPoint = 0;
                if (_Request.PickupOutletId > 1)
                {
                    PickupPoint = 1;
                }
                else
                {
                    if (SenderAddress.UnderCityCorporation == 1)
                    {
                        PickupPoint = 2;
                    }
                    else
                    {
                        PickupPoint = 3;
                    }
                }

                //Define DeliveryPoint
                int DeliveryPoint = 0;
                if (_Request.DropOutletId > 1)
                {
                    DeliveryPoint = 1;
                }
                else
                {
                    if (ReceiverAddress.UnderCityCorporation == 1)
                    {
                        DeliveryPoint = 2;
                    }
                    else
                    {
                        DeliveryPoint = 3;
                    }
                }

                ChargeCalculateSPModel ChargeSpModelList = await GetPackageChargeModel(_Request.ProductDetails, DestinationId);

                string JsonChargesId = JsonConvert.SerializeObject(ChargeSpModelList);

                var parameters = new[] {
                    new SqlParameter("@P_JSON_CHARGES_ID", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = JsonChargesId },
                    new SqlParameter("@P_CITY_DIST_ID", SqlDbType.Int) { Direction = ParameterDirection.Input, Value = CityDistrictId },
                    new SqlParameter("@P_PICKUP_POINT", SqlDbType.Int) { Direction = ParameterDirection.Input, Value = PickupPoint },
                    new SqlParameter("@P_DELIVERY_POINT", SqlDbType.Int) { Direction = ParameterDirection.Input, Value = DeliveryPoint },
                    new SqlParameter("@P_SENDER_ID", SqlDbType.Int) { Direction = ParameterDirection.Input, Value = SenderId }
                };

                PacakgeChargeJson ChargeJson = await Task.FromResult(_Context.Set<PacakgeChargeJson>()
                                                         .FromSqlRaw("SP_JCD_GET_AND_CALCULATE_ALL_CHARGES @P_JSON_CHARGES_ID, @P_CITY_DIST_ID, @P_PICKUP_POINT, @P_DELIVERY_POINT, @P_SENDER_ID", parameters)
                                                         .AsEnumerable()
                                                         .FirstOrDefault());

                List<CalculateChargeDetails> ChargeDetails = JsonConvert.DeserializeObject<List<CalculateChargeDetails>>(ChargeJson.PacakgeDetails);

                CalculateChargeResponse Response = new CalculateChargeResponse
                {
                    Status = "Success",
                    ChargeDetails = ChargeDetails
                };

                return await Task.FromResult(Response);
            }
            catch (Exception ex)
            {
                CalculateChargeResponse _Response = new CalculateChargeResponse
                {
                    Status = "error",
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
                    ErrMethodPayload = "CalculateCharge",
                    ErrProcedure = (ex.Source != null) ? ex.Source.ToString() : "",
                    ErrRaisedDate = DateTime.Now,
                    ErrStackTrace = (ex.StackTrace != null) ? ex.StackTrace.ToString() : "",
                    UserId = 0
                };
                await _LogRepo.AddLog(_ErrorLog);
                //<<<<<End Register Log>>>>>
                return await Task.FromResult(_Response);
            }
        }
        public async Task<CalculateChargeResponseV2> CalculateChargeV2(ChargeCalculateRequestModelV2 _Request, long SenderId)
        {
            try
            {
                JcdAtcPickupAndDeliveryPointRepo AtcPointRepo = new JcdAtcPickupAndDeliveryPointRepo();

                foreach (ProductDetailsRequestModel Product in _Request.ProductDetails)
                {
                    //Convert Weight to kg
                    UmConvertModel Conversion;
                    Conversion = await ConvertUm(Product.PackageWeight, Product.PackageWeightUM);
                    Product.PackageWeightUM = Conversion.UM;
                    Product.PackageWeight = Conversion.value;

                    //Convert Dimension to inch
                    Conversion = await ConvertUm(Product.PackageHeight, Product.PackageDimensionUM);
                    Product.PackageHeight = Conversion.value;

                    Conversion = await ConvertUm(Product.PackageLength, Product.PackageDimensionUM);
                    Product.PackageLength = Conversion.value;

                    Conversion = await ConvertUm(Product.PackageWidth, Product.PackageDimensionUM);
                    Product.PackageDimensionUM = Conversion.UM;
                    Product.PackageWidth = Conversion.value;
                }

                //Check Package Dimension


                JcdSenderAddressRepo AddressRepo = new JcdSenderAddressRepo();

                AddressAreaModel SenderAddress = await Task.FromResult(_Context.AddressAreaModel
                                                         .FromSqlRaw($"SP_JCD_GET_ADDRESS_MODEL_BY_AREA_ID {_Request.SenderAreaId}")
                                                         .AsEnumerable()
                                                         .FirstOrDefault());
                AddressAreaModel ReceiverAddress = null;

                if (_Request.DropOutletId > 1)
                {

                    AtcPointModel DropOutlet = await AtcPointRepo.GetAtcOutletById(_Request.DropOutletId);

                    ReceiverAddress = await Task.FromResult(_Context.AddressAreaModel
                                                                             .FromSqlRaw($"SP_JCD_GET_ADDRESS_MODEL_BY_AREA_ID {DropOutlet.AtcPointList[0].AreaId}")
                                                                             .AsEnumerable()
                                                                             .FirstOrDefault());

                }
                else
                {
                    if (_Request.ReceiverAreaId > 0)
                    {
                        ReceiverAddress = await Task.FromResult(_Context.AddressAreaModel
                                                                                 .FromSqlRaw($"SP_JCD_GET_ADDRESS_MODEL_BY_AREA_ID {_Request.ReceiverAreaId}")
                                                                                 .AsEnumerable()
                                                                                 .FirstOrDefault());
                    }
                    else
                    {
                        CalculateChargeResponseV2 _Response = new CalculateChargeResponseV2
                        {
                            Status = "error",
                            Error = new ErrorModel
                            {
                                ErrorCode = "523",
                                InnerException = "",
                                Message = "Receiver Area Id cannot be 0 (zero)",
                                StackTrace = ""
                            }
                        };
                        return await Task.FromResult(_Response);
                    }
                }


                int CityDistrictId = SenderAddress.DistrictCityId;
                int DestinationId = 0;
                List<CalculateChargeModel> ResponseList = new List<CalculateChargeModel>();
                //Define Destination ID
                if (SenderAddress.ProvinceId == ReceiverAddress.ProvinceId)
                {
                    if (SenderAddress.DistrictCityId == ReceiverAddress.DistrictCityId)
                    {
                        DestinationId = 1;
                    }
                    else
                    {
                        DestinationId = 2;
                    }
                }
                else
                {
                    DestinationId = 3;
                }

                //Define Pickup point
                int PickupPoint = 0;
                if (_Request.PickupOutletId > 1)
                {
                    PickupPoint = 1;
                }
                else
                {
                    if (SenderAddress.UnderCityCorporation == 1)
                    {
                        PickupPoint = 2;
                    }
                    else
                    {
                        PickupPoint = 3;
                    }
                }

                //Define DeliveryPoint
                int DeliveryPoint = 0;
                if (_Request.DropOutletId > 1)
                {
                    DeliveryPoint = 1;
                }
                else
                {
                    if (ReceiverAddress.UnderCityCorporation == 1)
                    {
                        DeliveryPoint = 2;
                    }
                    else
                    {
                        DeliveryPoint = 3;
                    }
                }

                ChargeCalculateSPModel ChargeSpModelList = await GetPackageChargeModel(_Request.ProductDetails, DestinationId);

                string JsonChargesId = JsonConvert.SerializeObject(ChargeSpModelList);

                var parameters = new[] {
                    new SqlParameter("@P_JSON_CHARGES_ID", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = JsonChargesId },
                    new SqlParameter("@P_CITY_DIST_ID", SqlDbType.Int) { Direction = ParameterDirection.Input, Value = CityDistrictId },
                    new SqlParameter("@P_PICKUP_POINT", SqlDbType.Int) { Direction = ParameterDirection.Input, Value = PickupPoint },
                    new SqlParameter("@P_DELIVERY_POINT", SqlDbType.Int) { Direction = ParameterDirection.Input, Value = DeliveryPoint },
                    new SqlParameter("@P_SENDER_ID", SqlDbType.Int) { Direction = ParameterDirection.Input, Value = SenderId },
                    new SqlParameter("@P_REQUEST_BEFORE", SqlDbType.Time) { Direction = ParameterDirection.Input, Value = _Request.RequestBefore }
                };

                PacakgeChargeJson ChargeJson = await Task.FromResult(_Context.Set<PacakgeChargeJson>()
                                                         .FromSqlRaw("SP_JCD_GET_AND_SHOW_DELIVERY_SLOTS @P_JSON_CHARGES_ID, @P_CITY_DIST_ID, @P_PICKUP_POINT, @P_DELIVERY_POINT, @P_SENDER_ID, @P_REQUEST_BEFORE", parameters)
                                                         .AsEnumerable()
                                                         .FirstOrDefault());

                List<CalculateChargeDetailsV2> ChargeDetails = JsonConvert.DeserializeObject<List<CalculateChargeDetailsV2>>(ChargeJson.PacakgeDetails);

                CalculateChargeResponseV2 Response = new CalculateChargeResponseV2
                {
                    Status = "Success",
                    ChargeDetails = ChargeDetails
                };

                return await Task.FromResult(Response);
            }
            catch (Exception ex)
            {
                CalculateChargeResponseV2 _Response = new CalculateChargeResponseV2
                {
                    Status = "error",
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
                    ErrMethodPayload = "CalculateCharge",
                    ErrProcedure = (ex.Source != null) ? ex.Source.ToString() : "",
                    ErrRaisedDate = DateTime.Now,
                    ErrStackTrace = (ex.StackTrace != null) ? ex.StackTrace.ToString() : "",
                    UserId = 0
                };
                await _LogRepo.AddLog(_ErrorLog);
                //<<<<<End Register Log>>>>>
                return await Task.FromResult(_Response);
            }
        }
        private async Task<PickupDeliveryRequestModel> GetFormattedPickupRequestModel(PickupRequestModel _Request)
        {
            JcdPickupAndDeliveryRequest _PickupRequest = new JcdPickupAndDeliveryRequest
            {
                RequestId = _Request.RequestInfo.RequestId,
                SenderFirstName = _Request.RequestInfo.SenderFirstName,
                SenderLastName = _Request.RequestInfo.SenderLastName,
                SenderLatitudesData = _Request.RequestInfo.SenderLat,
                SenderLongitudesData = _Request.RequestInfo.SenderLang,
                SenderMobileNo = _Request.RequestInfo.SenderMobileNo,
                SenderId = _Request.RequestInfo.SenderId,
                ChargeAmount = _Request.RequestInfo.ChargeAmount,
                ChargeAmountPayby = _Request.RequestInfo.ChargeAmountPayBy,
                DeliveryBefore = _Request.RequestInfo.DeliveryBefore,
                AtcPickupPoint = _Request.RequestInfo.AtcPickupPoint,
                PickupPostalCode = _Request.RequestInfo.PickupPostalCode,
                PickupAddressLine1 = _Request.RequestInfo.PickupAddress1,
                PickupAddressLine2 = _Request.RequestInfo.PickupAddress2,
                PGeocodingStatus = _Request.RequestInfo.PGeocodingStatus,
                PickupAreaId = _Request.RequestInfo.PickupAreaId,
                PickupHouseOrRoadNo = _Request.RequestInfo.PickupHouseOrRoad,
                PickupLandmark = _Request.RequestInfo.PickupLandMark,
                PickupStreet = _Request.RequestInfo.PickupStreet,
                PickupBefore = _Request.RequestInfo.PickupBefore,
                AtcDeliveryPoint = _Request.RequestInfo.AtcDeliveryPoint,
                ReceiverAddressLine1 = _Request.RequestInfo.ReceiverAddress1,
                ReceiverAddressLine2 = _Request.RequestInfo.ReceiverAddress2,
                ReceiverAreaId = _Request.RequestInfo.ReceiverAreaId,
                ReceiverFirstName = _Request.RequestInfo.ReceiverFirstName,
                ReceiverHouseOrRoadNo = _Request.RequestInfo.ReceiverHouseOrRoad,
                ReceiverLandmark = _Request.RequestInfo.ReceiverLandMark,
                ReceiverLastName = _Request.RequestInfo.ReceiverLastName,
                ReceiverPostalCode = _Request.RequestInfo.ReceiverPostalCode,
                ReceiverMobileNo = _Request.RequestInfo.ReceiverMobileNo,
                ReceiverStreet = _Request.RequestInfo.ReceiverStreet,
                ReceiverLatitudesData = _Request.RequestInfo.ReceiverLat,
                ReceiverLongitudesData = _Request.RequestInfo.ReceiverLong,
                RequestDate = DateTime.Now,
                RequestTypeId = _Request.RequestInfo.RequestTypeId,
                RGeocodingStatus = _Request.RequestInfo.RGeocodingStatus,
                DeliveryCharge = _Request.RequestInfo.DeliveryCharge,
                DestinationCharge = _Request.RequestInfo.DestinationCharge,
                DestinationId = _Request.RequestInfo.DestinationId,
                PickupCharge = _Request.RequestInfo.PickupCharge,
                IsCancelled = 0,
                IsComplained = 0,
                IsDelivered = 0,
            };

            List<JcdProductDetails> _ProductDetailsList = new List<JcdProductDetails>();
            byte productCount = 1;
            if (_Request.ProductDetails != null)
            {
                if (_Request.ProductDetails.Count > 0)
                {
                    foreach (ProductDetails Product in _Request.ProductDetails)
                    {
                        _ProductDetailsList.Add(new JcdProductDetails
                        {
                            RequestId = Product.RequestId,
                            SlNo = productCount,
                            ProductTypeId = Product.ProductTypeId,
                            ProductDescription = Product.ProductDescription,
                            ProductImage = Product.ProductImage,
                            ProductCode = Product.ProductCode,
                            PackageChargeId = Product.PackageChargeId,
                            ExtraPackagingId = Product.ExtraPackagingId,
                            HandlingCharge = Product.HandlingCharge,
                            PackagingCharge = Product.ExtraPackagingCharge,
                            PackageCharge = Product.PackageCharge,
                            GiftWrappingId = Product.GiftWrappingId,
                            InsuranceCharge = Product.InsuranceCharge,
                            InsuranceId = Product.InsuranceId,
                            WrappingCharge = Product.WrappingCharge
                        });
                        productCount += 1;
                    }
                }
            }

            PickupDeliveryRequestModel _PickupDeliveryRequestModel = new PickupDeliveryRequestModel
            {
                PickupDelvieryRequest = _PickupRequest,
                ProductDetails = _ProductDetailsList
            };

            return await Task.FromResult(_PickupDeliveryRequestModel);
        }
        public async Task<JcdPickupAndDeliveryRequest> GetRequestById(long requestId)
        {
            return await _Context.JcdPickupAndDeliveryRequest.Where(x => x.RequestId == requestId).FirstOrDefaultAsync();
        }
        public async Task<long> GetSenderIdByRequest(long requestId)
        {
            return await _Context.JcdPickupAndDeliveryRequest.Where(x => x.RequestId == requestId)
                                                             .Select(y => y.SenderId).FirstOrDefaultAsync();
        }
        public async Task<string> GetReceiverPhoneByRequest(long requestId)
        {
            return await _Context.JcdPickupAndDeliveryRequest.Where(x => x.RequestId == requestId)
                                                             .Select(y => y.ReceiverMobileNo).FirstOrDefaultAsync();
        }
        public async Task<UserRequestListModel> GetUserRequests(long SenderId, byte Condition, int PageNumber)
        {
            //Condition => 1 = Show All | 2 = Show Deliered Data | 3 = Delivery Pending Data | 4 = Cancelled Data | 5 = Complained By Sender | 6 = Complained By Receiver

            try
            {
                double TotalResults = await Task.FromResult(_Context.Set<UserRequestInfo>()
                                   .FromSqlRaw("SP_JCD_GET_PICKUP_AND_DELIVERY_INFO @P_SENDER_ID =" + SenderId + ", @P_SHOW_DATA =" + Condition + "")
                                   .AsEnumerable()
                                   .Where(x => x.RequestId != 1)
                                   .Count());

                if (TotalResults > 0)
                {
                    List<UserRequestInfo> Result = await Task.FromResult(_Context.Set<UserRequestInfo>()
                                                         .FromSqlRaw("SP_JCD_GET_PICKUP_AND_DELIVERY_INFO @P_SENDER_ID =" + SenderId + ", @P_SHOW_DATA =" + Condition + "")
                                                         .AsEnumerable()
                                                         .Where(x => x.RequestId != 1)
                                                         .Skip((int)(PageSize * (PageNumber - 1)))
                                                         .Take((int)(PageSize))
                                                         .ToList());

                    double TotalPage = Math.Ceiling((TotalResults / PageSize));
                    if (PageNumber > TotalPage)
                    {
                        UserRequestListModel RequestList = new UserRequestListModel
                        {
                            Status = "Error",
                            Error = new ErrorModel
                            {
                                ErrorCode = "522",
                                InnerException = "",
                                Message = "Page not found.",
                                StackTrace = ""
                            }
                        };
                        return await Task.FromResult(RequestList);
                    }
                    else
                    {
                        bool HasNextPage = false;

                        if (TotalPage > PageNumber)
                        {
                            HasNextPage = true;
                        }

                        UserRequestListModel RequestList = new UserRequestListModel
                        {
                            Status = "Success",
                            RequestInfo = Result,
                            TotalPage = TotalPage,
                            CurrentPage = PageNumber,
                            HasNexPage = HasNextPage
                        };
                        return await Task.FromResult(RequestList);
                    }
                }
                else
                {
                    UserRequestListModel RequestList = new UserRequestListModel
                    {
                        Status = "Error",
                        Error = new ErrorModel
                        {
                            ErrorCode = "522",
                            InnerException = "",
                            Message = "No Records found.",
                            StackTrace = ""
                        }
                    };
                    return await Task.FromResult(RequestList);
                }
            }
            catch (Exception ex)
            {
                UserRequestListModel RequestList = new UserRequestListModel
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
                    ErrMethodPayload = "GetUserRequests",
                    ErrProcedure = (ex.Source != null) ? ex.Source.ToString() : "",
                    ErrRaisedDate = DateTime.Now,
                    ErrStackTrace = (ex.StackTrace != null) ? ex.StackTrace.ToString() : "",
                    UserId = 0
                };
                await _LogRepo.AddLog(_ErrorLog);
                //<<<<<End Register Log>>>>>

                return await Task.FromResult(RequestList);
            }
        }
        public async Task<UmConvertModel> ConvertUm(decimal value, string um)
        {
            if (um.ToLower() == "gm")
            {
                UmConvertModel Response = new UmConvertModel
                {
                    UM = "kg",
                    value = Math.Round(value / 1000, 2)
                };
                return await Task.FromResult(Response);
            }
            else if (um.ToLower() == "lb")
            {
                UmConvertModel Response = new UmConvertModel
                {
                    UM = "kg",
                    value = Math.Round(value * (decimal)0.453592, 2)
                };
                return await Task.FromResult(Response);
            }
            else if (um.ToLower() == "in")
            {
                UmConvertModel Response = new UmConvertModel
                {
                    UM = "mm",
                    value = Math.Round(value / (decimal)0.0393701, 2)
                };
                return await Task.FromResult(Response);
            }
            else if (um.ToLower() == "ft")
            {
                UmConvertModel Response = new UmConvertModel
                {
                    UM = "mm",
                    value = Math.Round(value * (decimal)304.8, 2)
                };
                return await Task.FromResult(Response);
            }
            else if (um.ToLower() == "m")
            {
                UmConvertModel Response = new UmConvertModel
                {
                    UM = "mm",
                    value = Math.Round(value * (decimal)1000, 2)
                };
                return await Task.FromResult(Response);
            }
            else
            {
                UmConvertModel Response = new UmConvertModel
                {
                    UM = um,
                    value = value
                };
                return await Task.FromResult(Response);
            }
        }
        public async Task<ChargeCalculateSPModel> GetPackageChargeModel(List<ProductDetailsRequestModel> ProductDetails, int DestinationId)
        {
            decimal PackageWidth = 0;
            decimal PackageHeight = 0;
            decimal PackageLength = 0;
            decimal PackageWeight = 0;
            ChargeCalculateSPModel ChargeCalculateModel = null;

            //Assume Package Side By Side (Width sum | Length Max | Height Max)
            PackageWidth = ProductDetails.Sum(x => x.PackageWidth);
            PackageHeight = ProductDetails.Max(x => x.PackageHeight);
            PackageLength = ProductDetails.Max(x => x.PackageLength);
            PackageWeight = ProductDetails.Sum(x => x.PackageWeight);

            //Find Related Package
            List<PackageWithChargeInfo> Packages = await _Context.PackageWithChargeInfo
                                                                .FromSqlRaw($"SP_JCD_PACKAGE_WITH_CHARGE_OPERATION @P_OPT_ID = 'A'")
                                                                .ToListAsync();

            decimal MaximumDimension = Math.Max(Math.Max(PackageHeight, PackageWidth), PackageLength);
            decimal MinimumDimension = Math.Min(Math.Min(PackageHeight, PackageWidth), PackageLength);
            decimal MedianDimension = await GetMedian(PackageHeight, PackageWidth, PackageLength);

            List<PackageWithChargeInfo> EligiblePackages = Packages.Where(x => Math.Max(Math.Max(x.PackageHeight, x.PackageWidth), x.PackageLength) >= MaximumDimension
                                           && Math.Min(Math.Min(x.PackageHeight, x.PackageWidth), x.PackageLength) >= MinimumDimension
                                           && GetMedian(x.PackageHeight, x.PackageWidth, x.PackageLength).Result >= MedianDimension
                                           && x.PackageWeight >= PackageWeight).ToList();
            if (EligiblePackages.Count > 0)
            {
                PackageWithChargeInfo FinalPackage = EligiblePackages.Aggregate((curMin, x) => curMin == null || x.PackageCharge < curMin.PackageCharge ? x : curMin);

                ChargeCalculateModel = new ChargeCalculateSPModel
                {
                    DestinationType = DestinationId,
                    DimensionUnit = FinalPackage.DimensionUnit,
                    ExtraPackagingId = string.Join(",",ProductDetails.Select(x=> x.ExtraPackagingId)),
                    GiftWrappingId = string.Join(",", ProductDetails.Select(x => x.GiftWrapId)),
                    PackageChargeId = FinalPackage.PackageTypeId,
                    PackageHeight = FinalPackage.PackageHeight,
                    PackageLength = FinalPackage.PackageLength,
                    PackageWidth = FinalPackage.PackageWidth,
                    PackageWeight = FinalPackage.PackageWeight,
                    ProductTypeId = string.Join(",", ProductDetails.Select(x => x.ProductTypeId)),
                    WeightUnit = FinalPackage.WeightUnit
                };

                return await Task.FromResult(ChargeCalculateModel);
            }
            else
            {
                //Assume Package Stacked on Top (Width Max | Length Max | Height Sum)
                PackageWidth = ProductDetails.Max(x => x.PackageWidth);
                PackageHeight = ProductDetails.Sum(x => x.PackageHeight);
                PackageLength = ProductDetails.Max(x => x.PackageLength);
                PackageWeight = ProductDetails.Sum(x => x.PackageWeight);

                MaximumDimension = Math.Max(Math.Max(PackageHeight, PackageWidth), PackageLength);
                MinimumDimension = Math.Min(Math.Min(PackageHeight, PackageWidth), PackageLength);
                MedianDimension = await GetMedian(PackageHeight, PackageWidth, PackageLength);

                EligiblePackages = Packages.Where(x => Math.Max(Math.Max(x.PackageHeight, x.PackageWidth), x.PackageLength) >= MaximumDimension
                                   && Math.Min(Math.Min(x.PackageHeight, x.PackageWidth), x.PackageLength) >= MaximumDimension
                                   && GetMedian(x.PackageHeight, x.PackageWidth, x.PackageLength).Result >= MedianDimension
                                   && x.PackageWeight >= PackageWeight).ToList();

                if (EligiblePackages.Count > 0)
                {
                    PackageWithChargeInfo FinalPackage = EligiblePackages.Aggregate((curMin, x) => curMin == null || x.PackageCharge < curMin.PackageCharge ? x : curMin);

                    ChargeCalculateModel = new ChargeCalculateSPModel
                    {
                        DestinationType = DestinationId,
                        DimensionUnit = FinalPackage.DimensionUnit,
                        ExtraPackagingId = string.Join(",", ProductDetails.Select(x => x.ExtraPackagingId)),
                        GiftWrappingId = string.Join(",", ProductDetails.Select(x => x.GiftWrapId)),
                        PackageChargeId = FinalPackage.PackageTypeId,
                        PackageHeight = FinalPackage.PackageHeight,
                        PackageLength = FinalPackage.PackageLength,
                        PackageWidth = FinalPackage.PackageWidth,
                        PackageWeight = FinalPackage.PackageWeight,
                        ProductTypeId = string.Join(",", ProductDetails.Select(x => x.ProductTypeId)),
                        WeightUnit = FinalPackage.WeightUnit
                    };

                    return await Task.FromResult(ChargeCalculateModel);
                } else
                {
                    //Assume Package Stacked Horizontally (Width Max | Length Sum | Height Max)
                    PackageWidth = ProductDetails.Max(x => x.PackageWidth);
                    PackageHeight = ProductDetails.Max(x => x.PackageHeight);
                    PackageLength = ProductDetails.Sum(x => x.PackageLength);
                    PackageWeight = ProductDetails.Sum(x => x.PackageWeight);

                    MaximumDimension = Math.Max(Math.Max(PackageHeight, PackageWidth), PackageLength);
                    MinimumDimension = Math.Min(Math.Min(PackageHeight, PackageWidth), PackageLength);
                    MedianDimension = await GetMedian(PackageHeight, PackageWidth, PackageLength);

                    EligiblePackages = Packages.Where(x => Math.Max(Math.Max(x.PackageHeight, x.PackageWidth), x.PackageLength) >= MaximumDimension
                                       && Math.Min(Math.Min(x.PackageHeight, x.PackageWidth), x.PackageLength) >= MaximumDimension
                                       && GetMedian(x.PackageHeight, x.PackageWidth, x.PackageLength).Result >= MedianDimension
                                       && x.PackageWeight >= PackageWeight).ToList();

                    if (EligiblePackages.Count > 0)
                    {
                        PackageWithChargeInfo FinalPackage = EligiblePackages.Aggregate((curMin, x) => curMin == null || x.PackageCharge < curMin.PackageCharge ? x : curMin);

                        ChargeCalculateModel = new ChargeCalculateSPModel
                        {
                            DestinationType = DestinationId,
                            DimensionUnit = FinalPackage.DimensionUnit,
                            ExtraPackagingId = string.Join(",", ProductDetails.Select(x => x.ExtraPackagingId)),
                            GiftWrappingId = string.Join(",", ProductDetails.Select(x => x.GiftWrapId)),
                            PackageChargeId = FinalPackage.PackageTypeId,
                            PackageHeight = FinalPackage.PackageHeight,
                            PackageLength = FinalPackage.PackageLength,
                            PackageWidth = FinalPackage.PackageWidth,
                            PackageWeight = FinalPackage.PackageWeight,
                            ProductTypeId = string.Join(",", ProductDetails.Select(x => x.ProductTypeId)),
                            WeightUnit = FinalPackage.WeightUnit
                        };

                        return await Task.FromResult(ChargeCalculateModel);
                    } else
                    {
                        PackageWidth = ProductDetails.Sum(x => x.PackageWidth);
                        PackageHeight = ProductDetails.Max(x => x.PackageHeight);
                        PackageLength = ProductDetails.Max(x => x.PackageLength);
                        PackageWeight = ProductDetails.Sum(x => x.PackageWeight);

                        ChargeCalculateModel = new ChargeCalculateSPModel
                        {
                            DestinationType = DestinationId,
                            DimensionUnit = "in",
                            ExtraPackagingId = string.Join(",", ProductDetails.Select(x => x.ExtraPackagingId)),
                            GiftWrappingId = string.Join(",", ProductDetails.Select(x => x.GiftWrapId)),
                            PackageChargeId = 0,
                            PackageHeight = PackageHeight,
                            PackageLength = PackageLength,
                            PackageWidth = PackageWidth,
                            PackageWeight = PackageWeight,
                            ProductTypeId = string.Join(",", ProductDetails.Select(x => x.ProductTypeId)),
                            WeightUnit = "kg"
                        };

                        return await Task.FromResult(ChargeCalculateModel);
                    }
                }                
            }
        }
        public async Task<decimal> GetMedian(decimal PackageHeight, decimal PackageWidth, decimal PackageLenght)
        {
            List<decimal> sourceNumbers = new List<decimal>();
            sourceNumbers.Add(PackageHeight);
            sourceNumbers.Add(PackageWidth);
            sourceNumbers.Add(PackageLenght);

            //Framework 2.0 version of this method. there is an easier way in F4        
            if (sourceNumbers == null || sourceNumbers.Count == 0)
                throw new System.Exception("Median of empty array not defined.");

            //make sure the list is sorted, but use a new array
            decimal[] sortedPNumbers = sourceNumbers.ToArray();
            Array.Sort(sortedPNumbers);

            //get the median
            int size = sortedPNumbers.Length;
            int mid = size / 2;
            decimal median = (size % 2 != 0) ? (decimal)sortedPNumbers[mid] : ((decimal)sortedPNumbers[mid] + (decimal)sortedPNumbers[mid - 1]) / 2;
            return await Task.FromResult(median);
        }
        public async Task<TrackingDetailsResponseModel> GetTrackingDetails (string TrackingId)
        {
            try
            {
                List<TrackingDetails> TrackingDetails = await _Context.TrackingDetails
                                                                .FromSqlRaw($"SP_JCD_GET_TRACKING_DET @P_TRACKING_NO='{TrackingId}'")
                                                                .ToListAsync();

                if(TrackingDetails.Count > 0)
                {
                    TrackingDetailsResponseModel Response = new TrackingDetailsResponseModel
                    {
                        Status = "Success",
                        TrackingDetails = TrackingDetails
                    };

                    return await Task.FromResult(Response);
                } else
                {
                    TrackingDetailsResponseModel Response = new TrackingDetailsResponseModel
                    {
                        Status = "Error",
                        Error = new ErrorModel
                        {
                            ErrorCode ="533",
                            InnerException = "",
                            Message = "No record found",
                            StackTrace = ""
                        }
                    };

                    return await Task.FromResult(Response);
                }
            } catch (Exception ex)
            {
                TrackingDetailsResponseModel _ResponseModel = new TrackingDetailsResponseModel
                {
                    Status = "error",
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
                    ErrMethod = "GetTrackingDetails",
                    ErrMethodPayload = "Tracking ID => " + TrackingId,
                    ErrProcedure = (ex.Source != null) ? ex.Source.ToString() : "",
                    ErrRaisedDate = DateTime.Now,
                    ErrStackTrace = (ex.StackTrace != null) ? ex.StackTrace.ToString() : "",
                    UserId = 0
                };
                await _LogRepo.AddLog(_ErrorLog);
                //<<<<<End Register Log>>>>>

                return await Task.FromResult(_ResponseModel);
            }
        }
    }

    public class UmConvertModel
    {
        public string UM { get; set; }
        public decimal value { get; set; }
    }
}
