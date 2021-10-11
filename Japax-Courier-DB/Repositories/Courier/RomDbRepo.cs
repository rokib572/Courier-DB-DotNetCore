using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Japax_Courier_DB.DBModels.Courier;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Japax_Courier_DB.DBModels.CommonModels.Response;
using System.Data;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using Japax_Courier_DB.DBModels.Courier.ResponseModels;

namespace Japax_Courier_DB.Repositories.Courier
{
    public class RomDbRepo
    {
        JpxCourierContext _Context = new JpxCourierContext();
        public async Task<RomDbResponse> GetRomDB(DateTime LatestDate, int ActiveStatus)
        {
            RomDbResponse _Response = null;
            try
            {
                using (var command = _Context.Database.GetDbConnection().CreateCommand())
                {
                    command.CommandText = "SP_JCD_GET_MASTER_DATA_FOR_ROMDB";

                    SqlParameter LatestDateParam = new SqlParameter();
                    LatestDateParam.ParameterName = "@P_ROMDB_LAST_DATE";
                    LatestDateParam.Value = LatestDate.Date.ToString();

                    SqlParameter ActiveStatusParam = new SqlParameter();
                    ActiveStatusParam.ParameterName = "@P_ACTIVE_STATUS";
                    ActiveStatusParam.Value = ActiveStatus;

                    command.Parameters.Add(LatestDateParam);
                    command.Parameters.Add(ActiveStatusParam);

                    command.CommandType = CommandType.StoredProcedure;

                    await _Context.Database.OpenConnectionAsync();

                    var dataReader = await command.ExecuteReaderAsync();
                    
                    if (dataReader.Read())
                    {
                        _Response = new RomDbResponse
                        {
                            Status = "Success",
                            AreaInfo = (!dataReader.IsDBNull("AreaInfo")) ? JsonConvert.DeserializeObject<List<AreaInfo>>(dataReader.GetString("AreaInfo")) : null,
                            CountryInfo = (!dataReader.IsDBNull("CountryInfo")) ? JsonConvert.DeserializeObject<List<CountryInfo>>(dataReader.GetString("CountryInfo")) : null,
                            DeliverySlotsInfo = (!dataReader.IsDBNull("DeliverySlotsInfo")) ? JsonConvert.DeserializeObject<List<DeliverySlotsInfo>>(dataReader.GetString("DeliverySlotsInfo")) : null,
                            DistrictInfo = (!dataReader.IsDBNull("DistrictInfo")) ? JsonConvert.DeserializeObject<List<CityDistrictInfo>>(dataReader.GetString("DistrictInfo")) : null,
                            DivisionInfo = (!dataReader.IsDBNull("DivisionInfo")) ? JsonConvert.DeserializeObject<List<ProvicneInfo>>(dataReader.GetString("DivisionInfo")) : null,
                            ExtraPackagingTypeInfo = (!dataReader.IsDBNull("ExtraPackagingTypeInfo")) ? JsonConvert.DeserializeObject<List<ExtraPackagingTypeInfo>>(dataReader.GetString("ExtraPackagingTypeInfo")) : null,
                            FeedbackQuestionInfo = (!dataReader.IsDBNull("FeedbackQuestionInfo")) ? JsonConvert.DeserializeObject<List<FeedbackQuestionInfo>>(dataReader.GetString("FeedbackQuestionInfo")) : null,
                            NotificationMsgInfo = (!dataReader.IsDBNull("NotificationMsgInfo")) ? JsonConvert.DeserializeObject<List<NotificationMsgInfo>>(dataReader.GetString("NotificationMsgInfo")) : null,
                            PackageTypeInfo = (!dataReader.IsDBNull("PackageTypeInfo")) ? JsonConvert.DeserializeObject<List<PackageTypeInfo>>(dataReader.GetString("PackageTypeInfo")) : null,
                            ProductTypeInfo = (!dataReader.IsDBNull("ProductTypeInfo")) ? JsonConvert.DeserializeObject<List<ProductTypeInfo>>(dataReader.GetString("ProductTypeInfo")) : null,
                            PSUpazilaInfo = (!dataReader.IsDBNull("PSUpazilaInfo")) ? JsonConvert.DeserializeObject<List<UpazillaInfo>>(dataReader.GetString("PSUpazilaInfo")) : null,
                            RequestTypeInfo = (!dataReader.IsDBNull("RequestTypeInfo")) ? JsonConvert.DeserializeObject<List<RequestTypeInfo>>(dataReader.GetString("RequestTypeInfo")) : null,
                            ZoneInfo = (!dataReader.IsDBNull("ZoneInfo")) ? JsonConvert.DeserializeObject<List<ZoneInfo>>(dataReader.GetString("ZoneInfo")) : null,
                            AtcPointInfo = (!dataReader.IsDBNull("ATCPickupDeliveryPointInfo")) ? JsonConvert.DeserializeObject<List<AtcPointInfo>>(dataReader.GetString("ATCPickupDeliveryPointInfo")) : null,
                            PickupAndDeliveryTimeSlotsInfo = (!dataReader.IsDBNull("PickupAndDeliveryTimeSlotsInfo")) ? JsonConvert.DeserializeObject<List<PickupAndDeliveryTimeSlotsInfo>>(dataReader.GetString("PickupAndDeliveryTimeSlotsInfo")) : null
                        };
                    }
                }
                return await Task.FromResult(_Response);
            } catch (Exception ex)
            {
                _Response = new RomDbResponse
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
                    ErrMethodPayload = "GetRomDB",
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
    }
}
