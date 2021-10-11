using Japax_Courier_DB.DBModels.CommonModels.Response;
using Japax_Courier_DB.DBModels.Courier;
using Japax_Courier_DB.DBModels.Courier.ResponseModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Japax_Courier_DB.Repositories.Courier
{
    public class JcdPickupAndDeliveryZoneRepo
    {
        JpxCourierContext _context = new JpxCourierContext();

        public async Task<PickupAndDeliveryZoneModel> GetActiveZones()
        {
            try
            {
                List<JcdPickupAndDeliveryZone> _Zones = await _context.JcdPickupAndDeliveryZone.Where(x => x.ActiveStatus == 1).OrderBy(y=> y.ZoneName).ToListAsync();

                PickupAndDeliveryZoneModel _ZoneModel = new PickupAndDeliveryZoneModel
                {
                    Status ="Success",
                    Zones = (from JcdPickupAndDeliveryZone _Zone in _Zones
                             select new ZoneInfo
                             {
                                 CityDistrictId = _Zone.CityDistrictId,
                                 ZoneId = _Zone.ZoneId,
                                 ZoneName = _Zone.ZoneName
                             }).ToList()
                };
                return await Task.FromResult(_ZoneModel);
            } catch(Exception ex)
            {
                PickupAndDeliveryZoneModel _ZoneModel = new PickupAndDeliveryZoneModel
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
                    ErrMethodPayload = "GetActiveZones",
                    ErrProcedure = (ex.Source != null) ? ex.Source.ToString() : "",
                    ErrRaisedDate = DateTime.Now,
                    ErrStackTrace = (ex.StackTrace != null) ? ex.StackTrace.ToString() : "",
                    UserId = 0
                };
                await _LogRepo.AddLog(_ErrorLog);
                //<<<<<End Register Log>>>>>

                return await Task.FromResult(_ZoneModel);
            }
        }
        public async Task<PickupAndDeliveryZoneModel> GetZoneById(int ZoneId)
        {
            try
            {
                JcdPickupAndDeliveryZone _Zone = await _context.JcdPickupAndDeliveryZone.Where(x => x.ZoneId == ZoneId).FirstOrDefaultAsync();

                PickupAndDeliveryZoneModel _ZoneModel = new PickupAndDeliveryZoneModel
                {
                    Status = "Success",
                    Zone = new ZoneInfo
                    {
                        CityDistrictId = _Zone.CityDistrictId,
                        ZoneId = _Zone.ZoneId,
                        ZoneName = _Zone.ZoneName
                    }
                };
                return await Task.FromResult(_ZoneModel);
            } catch (Exception ex)
            {
                PickupAndDeliveryZoneModel _ZoneModel = new PickupAndDeliveryZoneModel
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
                    ErrMethodPayload = "GetZoneById(ZoneId=" + ZoneId + ")" ,
                    ErrProcedure = (ex.Source != null) ? ex.Source.ToString() : "",
                    ErrRaisedDate = DateTime.Now,
                    ErrStackTrace = (ex.StackTrace != null) ? ex.StackTrace.ToString() : "",
                    UserId = 0
                };
                await _LogRepo.AddLog(_ErrorLog);
                //<<<<<End Register Log>>>>>

                return await Task.FromResult(_ZoneModel);
            }
        }
    }
}
