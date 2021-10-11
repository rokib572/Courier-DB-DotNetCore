using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Japax_Courier_DB.GeoLocation.ResponseModel;
using Newtonsoft.Json;
using Japax_Courier_DB.DBModels.CommonModels.Response;
using Japax_Courier_DB.Repositories.Courier;
using Japax_Courier_DB.DBModels.Courier;
using Japax_Courier_DB.DBModels.Courier.ResponseModels;
using System.Drawing;
using Japax_Courier_DB.Clients;

namespace Japax_Courier_DB.GeoLocation
{
    public class GoogleClient
    {
        private string GOOGLE_API_KEY;
        private string GOOGLE_GEOCODE_URL = "https://maps.googleapis.com/maps/api/geocode/json?";

        public GoogleClient(string googleApiKey)
        {
            GOOGLE_API_KEY = googleApiKey;
        }
        public async Task<GeocodingModel> GetGeocode(JcdSenderAddress _AddressModel)
        {
            try
            {
                JcdSenderAddressRepo _JcdSenderAddressRepo = new JcdSenderAddressRepo();
                string Address = await _JcdSenderAddressRepo.FormatAddress(_AddressModel);
                string googleURL = GOOGLE_GEOCODE_URL + "address=" + Address + " &key=" + GOOGLE_API_KEY + "&sensor=true_or_false";
                WebRequest httpWebRequest = WebRequest.Create(googleURL);

                httpWebRequest.Method = "GET";

                WebResponse httpResponse = await httpWebRequest.GetResponseAsync();
                using (StreamReader streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    string result = streamReader.ReadToEnd();
                    return await Task.FromResult(JsonConvert.DeserializeObject<GeocodingModel>(result));
                }
            }
            catch (Exception ex)
            {
                GeocodingModel _GeocodingModel = new GeocodingModel
                {
                    status = "error",
                    Error = new ErrorModel
                    {
                        ErrorCode = "513",
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
                    ErrMethodPayload = "GetActiveCountries",
                    ErrProcedure = (ex.Source != null) ? ex.Source.ToString() : "",
                    ErrRaisedDate = DateTime.Now,
                    ErrStackTrace = (ex.StackTrace != null) ? ex.StackTrace.ToString() : "",
                    UserId = 0
                };
                await _LogRepo.AddLog(_ErrorLog);
                //<<<<<End Register Log>>>>>

                return await Task.FromResult(_GeocodingModel);
            }
        }        
        public bool IsInPolygon_Old(List<CoordinatePoint> poly, float pointX, float pointY)
        {
            var coef = poly.Skip(1).Select((p, i) =>
                                            (pointY - poly[i].pointY) * (p.pointX - poly[i].pointX)
                                          - (pointX - poly[i].pointX) * (p.pointY - poly[i].pointY))
                                    .ToList();

            if (coef.Any(p => p == 0))
                return true;

            for (int i = 1; i < coef.Count(); i++)
            {
                if (coef[i] * coef[i - 1] < 0)
                    return false;
            }
            return true;
        }
        public async Task<int> GetAreaFromPolygon(float Latitude, float Longitude)
        {
            JcdPickupAndDeliveryAreaRepo _AreaRepo = new JcdPickupAndDeliveryAreaRepo();
            PickupAndDeliveryAreaModel AreaList = await _AreaRepo.GetActiveAreas();
            int AreaIdResponse = 0;

            foreach(AreaInfo _AreaInfo in AreaList.Areas)
            {
                List<CoordinatePoint> _Polygon = new List<CoordinatePoint>();

                List<string> _PointList = _AreaInfo.AreaPolygon.Split(";").ToList();

                foreach (string str in _PointList)
                {
                    List<string> coordinate = str.Split(",").ToList();

                    if (coordinate.Count == 2)
                    {
                        _Polygon.Add(new CoordinatePoint
                        {
                            pointX = Convert.ToSingle(Convert.ToSingle(coordinate[0]).ToString("0.######")),
                            pointY = Convert.ToSingle(Convert.ToSingle(coordinate[1]).ToString("0.######"))
                        });
                    }
                }

                if(_Polygon.Count > 0)
                {
                    if(await IsPointInPolygonNew(_Polygon, Latitude, Longitude) == true)
                    {
                        AreaIdResponse = _AreaInfo.AreaId;
                        break;
                    }
                }
            }

            return await Task.FromResult(AreaIdResponse);
        }
        public async Task<bool> IsPointInPolygonNew(List<CoordinatePoint> polygon, float pointX, float pointY)
        {
            bool isInside = false;
            for (int i = 0, j = polygon.Count - 1; i < polygon.Count; j = i++)
            {
                if (((polygon[i].pointY > pointY) != (polygon[j].pointY > pointY)) &&
                (pointX < (polygon[j].pointX - polygon[i].pointX) * (pointY - polygon[i].pointY) / (polygon[j].pointY - polygon[i].pointY) + polygon[i].pointX))
                {
                    isInside = !isInside;
                }
            }
            return await Task.FromResult(isInside);
        }
        public async Task<GeocodingModel> GetAddressFromGeoCode(float Latitude, float Longitude)
        {
            try
            {
                string googleURL = GOOGLE_GEOCODE_URL + "latlng=" + Latitude + "," + Longitude + " &key=" + GOOGLE_API_KEY + "&sensor=false";
                WebRequest httpWebRequest = WebRequest.Create(googleURL);

                httpWebRequest.Method = "GET";

                WebResponse httpResponse = await httpWebRequest.GetResponseAsync();
                using (StreamReader streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    string result = await streamReader.ReadToEndAsync();
                    return await Task.FromResult(JsonConvert.DeserializeObject<GeocodingModel>(result));
                }
            } catch (Exception ex)
            {
                GeocodingModel _GeocodingModel = new GeocodingModel
                {
                    status = "error",
                    Error = new ErrorModel
                    {
                        ErrorCode = "513",
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
                    ErrMethodPayload = "GetActiveCountries",
                    ErrProcedure = (ex.Source != null) ? ex.Source.ToString() : "",
                    ErrRaisedDate = DateTime.Now,
                    ErrStackTrace = (ex.StackTrace != null) ? ex.StackTrace.ToString() : "",
                    UserId = 0
                };
                await _LogRepo.AddLog(_ErrorLog);
                //<<<<<End Register Log>>>>>

                return await Task.FromResult(_GeocodingModel);
            }           
        }
    }
}
