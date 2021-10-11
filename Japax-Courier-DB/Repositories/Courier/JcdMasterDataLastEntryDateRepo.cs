using Japax_Courier_DB.DBModels.CommonModels;
using Japax_Courier_DB.DBModels.CommonModels.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Japax_Courier_DB.DBModels.Courier;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Japax_Courier_DB.Repositories.Courier
{
    public class JcdMasterDataLastEntryDateRepo
    {
        JpxCourierContext Context = new JpxCourierContext();

        public async Task<CommonResponseModel> SetUpdateDate(DateTime UpdateDate, StaticDataEnumModel TblName)
        {
            try
            {
                JcdMasterDataLastEntryDate MasterData = await Context.JcdMasterDataLastEntryDate.FirstOrDefaultAsync();

                if (TblName == StaticDataEnumModel.Area)
                {
                    MasterData.PickupAndDeliveryArea = UpdateDate;
                }
                else if (TblName == StaticDataEnumModel.ATCPoint)
                {
                    MasterData.AtcPickupAndDeliveryPoint = UpdateDate;
                }
                else if (TblName == StaticDataEnumModel.City)
                {
                    MasterData.CityDistrict = UpdateDate;
                }
                else if (TblName == StaticDataEnumModel.Country)
                {
                    MasterData.CountryName = UpdateDate;
                }
                else if (TblName == StaticDataEnumModel.DeliverySlots)
                {
                    MasterData.DeliverySlots = UpdateDate;
                }
                else if (TblName == StaticDataEnumModel.ExtraPackage)
                {
                    MasterData.ExtraPackagingType = UpdateDate;
                }
                else if (TblName == StaticDataEnumModel.Feedback)
                {
                    MasterData.FeedbackQuestionware = UpdateDate;
                }
                else if (TblName == StaticDataEnumModel.Notification)
                {
                    MasterData.NotificationMsg = UpdateDate;
                }
                else if (TblName == StaticDataEnumModel.PackageType)
                {
                    MasterData.PackageType = UpdateDate;
                }
                else if (TblName == StaticDataEnumModel.PoliceStation)
                {
                    MasterData.PsUpazla = UpdateDate;
                }
                else if (TblName == StaticDataEnumModel.ProductType)
                {
                    MasterData.ProductType = UpdateDate;
                }
                else if (TblName == StaticDataEnumModel.Province)
                {
                    MasterData.ProvinceDivision = UpdateDate;
                }
                else if (TblName == StaticDataEnumModel.RequestType)
                {
                    MasterData.RequestType = UpdateDate;
                }
                else
                {
                    MasterData.ZoneName = UpdateDate;
                }

                await Context.SaveChangesAsync();

                CommonResponseModel Response = new CommonResponseModel
                {
                    Status = "Success"
                };

                return await Task.FromResult(Response);
            } catch (Exception ex)
            {
                CommonResponseModel _CityDistrictModel = new CommonResponseModel
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
                    ErrMethodPayload = "SetUpdateDate",
                    ErrProcedure = (ex.Source != null) ? ex.Source.ToString() : "",
                    ErrRaisedDate = DateTime.Now,
                    ErrStackTrace = (ex.StackTrace != null) ? ex.StackTrace.ToString() : "",
                    UserId = 0
                };
                await _LogRepo.AddLog(_ErrorLog);
                //<<<<<End Register Log>>>>>
                return await Task.FromResult(_CityDistrictModel);
            }            
        }
    }
}
