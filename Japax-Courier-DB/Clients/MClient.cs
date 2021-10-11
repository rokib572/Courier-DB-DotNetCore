using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Japax_Courier_DB.DBModels.Auth.Models.Request;
using Japax_Courier_DB.DBModels.CommonModels.Response;
using Japax_Courier_DB.Repositories.Courier;

namespace Japax_Courier_DB.Clients
{
    public class MClient
    {
        private JcdMerchantOrStarUserDetRepo MerchantRepo = new JcdMerchantOrStarUserDetRepo();
        public async Task<CommonResponseModel> AddMerchant(MerchantRegistrationRequestModel Request)
        {
            return await MerchantRepo.AddMerchant(Request);
        }
        public async Task<CommonResponseModel> UpdateMerchant(MerchantUpdateRequestModel Request)
        {
            return await MerchantRepo.UpdateMerchant(Request);
        }
    }
}
