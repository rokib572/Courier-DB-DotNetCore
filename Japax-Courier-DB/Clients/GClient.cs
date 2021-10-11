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
        public string GOOGLE_MAPS_API_KEY = "AIzaSyB9aiE-enfBpVjFI5vpOllWfr0EojNYOio";
        public string FCM_Server_Key = "AAAAr_dqFqc:APA91bG5D9DtgJuFVszT0n5aNQtK74NJCjF9gG4Vm3qoZTRsU38aLuxADRFX0WzDo0dwMY1u2tZ6TTtDyuEfbV6jP9nGVg55VAxz8mwc4MvuczujPlWkSsZho3vya08-EWpg5qvqpQxW";
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
