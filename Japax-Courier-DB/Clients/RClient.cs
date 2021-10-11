using Japax_Courier_DB.DBModels.CommonModels.Response;
using Japax_Courier_DB.DBModels.Courier.RequestModels;
using Japax_Courier_DB.DBModels.Courier.ResponseModels;
using Japax_Courier_DB.Repositories.Courier;
using Japax_Courier_DB.Cipher;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Japax_Courier_DB.Repositories.Auth;
using Japax_Courier_DB.DBModels.Auth.Models.Response;
using Newtonsoft.Json;
using Japax_Courier_DB.DBModels.CommonModels;
using System.Linq;
using Japax_Courier_DB.DBModels.Courier;

namespace Japax_Courier_DB.Clients
{
    //Request Client
    public class RClient
    {
        public async Task<PayLoadModel> AddRequest(PayLoadModel _Request)
        {
            //Get Start Time
            DateTime StartTime = DateTime.Now;

            JpxUserLoginInfoRepo _UserRepo = new JpxUserLoginInfoRepo();
            JpxUserLoginInfoModel _UserAuth = await _UserRepo.GetUserById(Convert.ToInt64(_Request.SenderID));
            CipherClient _CipherClient = new CipherClient(_UserAuth.UserInfo.DeviceId, _UserAuth.UserInfo.SecretKey);
            JcdPickupAndDeliveryRequestRepo _RequestRepo = new JcdPickupAndDeliveryRequestRepo();

            //Decrypt Payload
            CipherPayload _CipherPayload = await _CipherClient.DecryptText(_Request.PayLoad);

            if(_CipherPayload.Status == "Success")
            {
                PickupRequestModel _RequestModel = JsonConvert.DeserializeObject<PickupRequestModel>(_CipherPayload.PayLoad);
                CommonResponseModel _Response = await _RequestRepo.AddRequest(_RequestModel);

                CipherPayload _EncryptPayload = await _CipherClient.EncryptText(JsonConvert.SerializeObject(_Response));

                PayLoadModel _PayloadModel = new PayLoadModel
                {
                    SenderID = _Request.SenderID,
                    ExecutionTime = (DateTime.Now - StartTime).TotalMilliseconds.ToString() + " ms",
                    PayLoad = _EncryptPayload.PayLoad
                };

                return await Task.FromResult(_PayloadModel);
            } else
            {
                PayLoadModel ResponsePayload = new PayLoadModel
                {
                    SenderID = _Request.SenderID,
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
        public async Task<PayLoadModel> UpdateRequest(PayLoadModel _Request, List<string> ProductImage)
        {
            //Get Start Time
            DateTime StartTime = DateTime.Now;

            JpxUserLoginInfoRepo _UserRepo = new JpxUserLoginInfoRepo();
            JpxUserLoginInfoModel _UserAuth = await _UserRepo.GetUserById(Convert.ToInt64(_Request.SenderID));
            CipherClient _CipherClient = new CipherClient(_UserAuth.UserInfo.DeviceId, _UserAuth.UserInfo.SecretKey);
            JcdPickupAndDeliveryRequestRepo _RequestRepo = new JcdPickupAndDeliveryRequestRepo();

            //Decrypt Payload
            CipherPayload _CipherPayload = await _CipherClient.DecryptText(_Request.PayLoad);

            if (_CipherPayload.Status == "Success")
            {
                PickupRequestModel _RequestModel = JsonConvert.DeserializeObject<PickupRequestModel>(_CipherPayload.PayLoad);

                //Update ImageName
                List<ProductImageModel> ProductImageModel = await FormatProductImage(ProductImage);

                if(ProductImageModel.Count > 0)
                {
                    foreach(ProductImageModel ProductImageName in ProductImageModel)
                    {
                        foreach(ProductDetails ProdDetails in _RequestModel.ProductDetails)
                        {
                            if(ProdDetails.RequestId == ProductImageName.RequestId && ProdDetails.SlNo == ProductImageName.ProductSL)
                            {
                                if(ProdDetails.ProductImage == "")
                                {
                                    ProdDetails.ProductImage = ProductImageName.RequestId + "_" + ProductImageName.ProductSL + "_" + ProductImageName.ImageId + ".jpg";
                                } else
                                {
                                    ProdDetails.ProductImage += ";" + ProductImageName.RequestId + "_" + ProductImageName.ProductSL + "_" + ProductImageName.ImageId + ".jpg";
                                }
                            }
                        }
                        //_RequestModel.ProductDetails.Where
                        //    (x => x.RequestId == ProductImageName.RequestId && x.SLNo == ProductImageName.ProductSL).ToList().ForEach
                        //    (y => y.ProductImage = "/Images/ProductImage/" + ProductImageName.RequestId + "_" + ProductImageName.ProductSL + "_" + ProductImageName.ImageId + ".jpg");
                    }
                }
                CommonResponseModel _Response = await _RequestRepo.UpdateRequest(_RequestModel);

                CipherPayload _EncryptPayload = await _CipherClient.EncryptText(JsonConvert.SerializeObject(_Response));

                PayLoadModel _PayloadModel = new PayLoadModel
                {
                    SenderID = _Request.SenderID,
                    ExecutionTime = (DateTime.Now - StartTime).TotalMilliseconds.ToString() + " ms",
                    PayLoad = _EncryptPayload.PayLoad
                };

                return await Task.FromResult(_PayloadModel);
            }
            else
            {
                PayLoadModel ResponsePayload = new PayLoadModel
                {
                    SenderID = _Request.SenderID,
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
        public async Task<PayLoadModel> AddProductImage(PayLoadModel _Request, List<string> ProductImage)
        {
            //Get Start Time
            DateTime StartTime = DateTime.Now;

            JpxUserLoginInfoRepo _UserRepo = new JpxUserLoginInfoRepo();
            JpxUserLoginInfoModel _UserAuth = await _UserRepo.GetUserById(Convert.ToInt64(_Request.SenderID));
            CipherClient _CipherClient = new CipherClient(_UserAuth.UserInfo.DeviceId, _UserAuth.UserInfo.SecretKey);
            JcdPickupAndDeliveryRequestRepo _RequestRepo = new JcdPickupAndDeliveryRequestRepo();

            //Decrypt Payload
            CipherPayload _CipherPayload = await _CipherClient.DecryptText(_Request.PayLoad);

            if (_CipherPayload.Status == "Success")
            {
                List<ProductImageRequestModel> Request = JsonConvert.DeserializeObject<List<ProductImageRequestModel>>(_CipherPayload.PayLoad);
                List<ProductImageModel> ProductImageModel = await FormatProductImage(ProductImage);

                if (ProductImageModel.Count > 0)
                {
                    foreach(ProductImageModel Image in ProductImageModel)
                    {
                        string imageName = Image.RequestId + "_" + Image.ProductSL + "_" + Image.ImageId + ".jpg";
                        Request.Where(x => x.RequestId == Image.RequestId && x.ProductSL == Image.ProductSL).ToList()
                               .ForEach(c =>{ c.ProductImage = string.IsNullOrEmpty(c.ProductImage) ? imageName : c.ProductImage + ";" + imageName;});
                    }
                    JcdProductDetailsRepo ProductRepo = new JcdProductDetailsRepo();
                    CommonResponseModel Result = await ProductRepo.AddProductImage(Request);

                    CipherPayload _EncryptPayload = await _CipherClient.EncryptText(JsonConvert.SerializeObject(Result));

                    PayLoadModel _PayloadModel = new PayLoadModel
                    {
                        SenderID = _Request.SenderID,
                        ExecutionTime = (DateTime.Now - StartTime).TotalMilliseconds.ToString() + " ms",
                        PayLoad = _EncryptPayload.PayLoad
                    };

                    return await Task.FromResult(_PayloadModel);
                } else
                {
                    PayLoadModel ResponsePayload = new PayLoadModel
                    {
                        SenderID = _Request.SenderID,
                        ExecutionTime = (DateTime.Now - StartTime).TotalMilliseconds.ToString() + " ms",
                        PayLoad = JsonConvert.SerializeObject(new ErrorModel
                        {
                            ErrorCode = "511",
                            Message = "No Image Found.",
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
                    SenderID = _Request.SenderID,
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
        public async Task<PayLoadModel> CancelRequest(PayLoadModel _Request)
        {
            JpxUserLoginInfoRepo _UserRepo = new JpxUserLoginInfoRepo();
            JpxUserLoginInfoModel _UserAuth = await _UserRepo.GetUserById(Convert.ToInt64(_Request.SenderID));
            CipherClient _CipherClient = new CipherClient(_UserAuth.UserInfo.DeviceId, _UserAuth.UserInfo.SecretKey);
            JcdPickupAndDeliveryRequestRepo _RequestRepo = new JcdPickupAndDeliveryRequestRepo();

            //Decrypt Payload
            CipherPayload _CipherPayload = await _CipherClient.DecryptText(_Request.PayLoad);

            if (_CipherPayload.Status == "Success")
            {
                CancelRequestModel _RequestModel = JsonConvert.DeserializeObject<CancelRequestModel>(_CipherPayload.PayLoad);

                CommonResponseModel _Response = await _RequestRepo.CancelRequest(_RequestModel);

                CipherPayload _EncryptPayload = await _CipherClient.EncryptText(JsonConvert.SerializeObject(_Response));

                PayLoadModel _PayloadModel = new PayLoadModel
                {
                    SenderID = _Request.SenderID,
                    PayLoad = _EncryptPayload.PayLoad
                };

                return await Task.FromResult(_PayloadModel);
            } else
            {
                PayLoadModel ResponsePayload = new PayLoadModel
                {
                    SenderID = _Request.SenderID,
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
        public async Task<PayLoadModel> CalculateRate(PayLoadModel _Request)
        {
            //Get Start Time
            DateTime StartTime = DateTime.Now;

            JpxUserLoginInfoRepo _UserRepo = new JpxUserLoginInfoRepo();
            JpxUserLoginInfoModel _UserAuth = await _UserRepo.GetUserById(Convert.ToInt64(_Request.SenderID));
            CipherClient _CipherClient = new CipherClient(_UserAuth.UserInfo.DeviceId, _UserAuth.UserInfo.SecretKey);
            JcdPickupAndDeliveryRequestRepo _RequestRepo = new JcdPickupAndDeliveryRequestRepo();
            
            //Decrypt Payload
            CipherPayload _CipherPayload = await _CipherClient.DecryptText(_Request.PayLoad);

            if (_CipherPayload.Status == "Success")
            {
                ChargeCalculateRequestModel ChargeModel = JsonConvert.DeserializeObject<ChargeCalculateRequestModel>(_CipherPayload.PayLoad);
                CalculateChargeResponse ChargeResponse = await _RequestRepo.CalculateCharge(ChargeModel, Convert.ToInt64(_Request.SenderID));
                PayLoadModel Response = await GeneratePayload(_CipherClient, _Request.SenderID, 1, ChargeResponse);

                Response.ExecutionTime = (DateTime.Now - StartTime).TotalMilliseconds.ToString() + " ms";

                return await Task.FromResult(Response);
            }
            else
            {
                PayLoadModel Response = await GeneratePayload(_CipherClient, _Request.SenderID, 2);

                Response.ExecutionTime = (DateTime.Now - StartTime).TotalMilliseconds.ToString() + " ms";

                return await Task.FromResult(Response);
            }
        }
        public async Task<PayLoadModel> CalculateRateV2(PayLoadModel _Request)
        {
            //Get Start Time
            DateTime StartTime = DateTime.Now;

            JpxUserLoginInfoRepo _UserRepo = new JpxUserLoginInfoRepo();
            JpxUserLoginInfoModel _UserAuth = await _UserRepo.GetUserById(Convert.ToInt64(_Request.SenderID));
            CipherClient _CipherClient = new CipherClient(_UserAuth.UserInfo.DeviceId, _UserAuth.UserInfo.SecretKey);
            JcdPickupAndDeliveryRequestRepo _RequestRepo = new JcdPickupAndDeliveryRequestRepo();

            //Decrypt Payload
            CipherPayload _CipherPayload = await _CipherClient.DecryptText(_Request.PayLoad);

            if (_CipherPayload.Status == "Success")
            {
                ChargeCalculateRequestModelV2 ChargeModel = JsonConvert.DeserializeObject<ChargeCalculateRequestModelV2>(_CipherPayload.PayLoad);
                CalculateChargeResponseV2 ChargeResponse = await _RequestRepo.CalculateChargeV2(ChargeModel, Convert.ToInt64(_Request.SenderID));
                PayLoadModel Response = await GeneratePayload(_CipherClient, _Request.SenderID, 1, ChargeResponse);

                Response.ExecutionTime = (DateTime.Now - StartTime).TotalMilliseconds.ToString() + " ms";

                return await Task.FromResult(Response);
            }
            else
            {
                PayLoadModel Response = await GeneratePayload(_CipherClient, _Request.SenderID, 2);

                Response.ExecutionTime = (DateTime.Now - StartTime).TotalMilliseconds.ToString() + " ms";

                return await Task.FromResult(Response);
            }
        }
        private async Task<PayLoadModel> GeneratePayload(CipherClient _CipherClient, string SenderId, int Mode, Object Response = null)
        {
            //Mode => 1 = Success | 2 = Error
            if (Mode == 1)
            {
                CipherPayload _EncryptPayload = await _CipherClient.EncryptText(JsonConvert.SerializeObject(Response));

                PayLoadModel _PayloadModel = new PayLoadModel
                {
                    SenderID = SenderId,
                    PayLoad = _EncryptPayload.PayLoad
                };

                return await Task.FromResult(_PayloadModel);
            }
            else if (Mode == 2)
            {
                PayLoadModel ResponsePayload = new PayLoadModel
                {
                    SenderID = SenderId,
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
            else
            {
                PayLoadModel ResponsePayload = new PayLoadModel
                {
                    SenderID = SenderId,
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
        public async Task<List<ProductImageModel>> FormatProductImage(List<string> ProductImages)
        {
            List<ProductImageModel> PrductImageModelList = new List<ProductImageModel>();
            foreach (string ProductImage in ProductImages)
            {
                List<string> ImageNamePart = ProductImage.Split("_").ToList();

                PrductImageModelList.Add(
                    new ProductImageModel
                    {
                        RequestId = Convert.ToInt64(ImageNamePart[0]),
                        ProductSL = Convert.ToInt32(ImageNamePart[1]),
                        ImageId = Convert.ToInt32(ImageNamePart[2])
                    }
                );
            }
            return await Task.FromResult(PrductImageModelList);
        }
        public async Task<PayLoadModel> GetUserRequests(long SenderId, byte Condition, int PageNumber)
        {
            //Condition => 1 = Show All | 2 = Show Deliered Data | 3 = Delivery Pending Data | 4 = Cancelled Data | 5 = Complained By Sender | 6 = Complained By Receiver
            JpxUserLoginInfoRepo _UserRepo = new JpxUserLoginInfoRepo();
            JpxUserLoginInfoModel _UserAuth = await _UserRepo.GetUserById(Convert.ToInt64(SenderId));
            CipherClient _CipherClient = new CipherClient(_UserAuth.UserInfo.DeviceId, _UserAuth.UserInfo.SecretKey);
            JcdPickupAndDeliveryRequestRepo RequestRepo = new JcdPickupAndDeliveryRequestRepo();

            UserRequestListModel RequestList = await RequestRepo.GetUserRequests(SenderId, Condition, PageNumber);

            CipherPayload _CipherPayload = await _CipherClient.EncryptText(JsonConvert.SerializeObject(RequestList));

            if(_CipherPayload.Status == "Success")
            {
                PayLoadModel ResponsePayload = new PayLoadModel
                {
                    SenderID = SenderId.ToString(),
                    PayLoad = _CipherPayload.PayLoad
                };

                return await Task.FromResult(ResponsePayload);
            } else
            {
                PayLoadModel ResponsePayload = new PayLoadModel
                {
                    SenderID = SenderId.ToString(),
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
        public async Task<ProductDetailsResponseModel> GetProductDetailsByRequestId(long RequestId)
        {
            JcdProductDetailsRepo ProductRepo = new JcdProductDetailsRepo();

            return await ProductRepo.GetProductDetailsByRequestId(RequestId);
        }
        public async Task<TrackingDetailsResponseModel> GetTrackingDetails(string TrackingId)
        {
            JcdPickupAndDeliveryRequestRepo _RequestRepo = new JcdPickupAndDeliveryRequestRepo();

            return await _RequestRepo.GetTrackingDetails(TrackingId);
        }
    }
}
