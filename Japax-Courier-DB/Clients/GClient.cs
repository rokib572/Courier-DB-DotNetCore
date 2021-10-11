using Japax_Courier_DB.FcmMessaging;
using Japax_Courier_DB.GeoLocation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Japax_Courier_DB.Clients
{
    //Google Client
    
    public class GClient
    {
        public string GOOGLE_MAPS_API_KEY = "YOUR_MAPS_API_KEY";
        public string FCM_Server_Key = "YOUR FCM SERVER KEY";
        public async Task<bool> isWithinPolygon(List<CoordinatePoint> poly, float pointX, float pointY)
        {
            GoogleClient _GoogleClient = new GoogleClient(GOOGLE_MAPS_API_KEY);
            return await _GoogleClient.IsPointInPolygonNew(poly, pointX, pointY);
        }
        public async Task<string> SendNotification(List<string> FcmKey, string title, string body, object CustomPayload = null)
        {
            FcmClient fcmClient = new FcmClient();
            return await fcmClient.SendNotification(FcmKey, title, body, CustomPayload);
        }
    }
}
