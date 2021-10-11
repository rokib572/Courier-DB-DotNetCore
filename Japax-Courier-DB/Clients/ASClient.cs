using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Japax_Courier_DB.DBModels.CommonModels.Response;
using Japax_Courier_DB.DBModels.Courier;
using Japax_Courier_DB.DBModels.Courier.RequestModels;
using Japax_Courier_DB.DBModels.Courier.ResponseModels;
using Japax_Courier_DB.Repositories.Courier;
using Newtonsoft.Json;

namespace Japax_Courier_DB.Clients
{
    public class ASClient
    {
        private JcdAssignedRequestRepo AssignRepo = new JcdAssignedRequestRepo();
        private JcdDeliveryHeroInfoRepo DhRepo = new JcdDeliveryHeroInfoRepo();
        public async Task<CommonResponseModel> AssignRequestToDh(AssignRequestModel RequestModel)
        {
            JcdDeliveryHeroInfo DhInfo = await DhRepo.GetActiveDhById(RequestModel.DhId);

            if (DhInfo != null)
            {
                return await AssignRepo.AssignRequestToDh(RequestModel);
            }
            else
            {
                CommonResponseModel Response = new CommonResponseModel
                {
                    Status = "Error",
                    Error = new ErrorModel
                    {
                        ErrorCode = "519",
                        InnerException = "",
                        Message = "Delivery Hero ID Invalid.",
                        StackTrace = ""
                    }
                };

                return await Task.FromResult(Response);
            }
        }
        public async Task<CommonResponseModel> RevokeAssignment(long RequestId)
        {
            JcdFeedbacksRepo FeedbackRepo = new JcdFeedbacksRepo();

            List<JcdFeedbacks> FeedBackList = await FeedbackRepo.GetFeedbackByRequest(RequestId);

            if (FeedBackList.Count == 0)
            {
                JcdAssignedRequestRepo AssignRepo = new JcdAssignedRequestRepo();

                return await AssignRepo.RevokeAssignment(RequestId);
            }
            else
            {
                CommonResponseModel Response = new CommonResponseModel
                {
                    Status = "Error",
                    Error = new ErrorModel
                    {
                        ErrorCode = "519",
                        InnerException = "",
                        Message = "There are some feedbacks for the request. Cannot be revoked.",
                        StackTrace = ""
                    }
                };

                return await Task.FromResult(Response);
            }
        }
        public async Task<CommonResponseModel> OverrideAssignment(AssignRequestModel OverrideRequest)
        {
            JcdDeliveryHeroInfoRepo DhRepo = new JcdDeliveryHeroInfoRepo();
            JcdDeliveryHeroInfo DhInfo = await DhRepo.GetActiveDhById(OverrideRequest.DhId);

            if (DhInfo != null)
            {
                JcdAssignedRequestRepo AssignRepo = new JcdAssignedRequestRepo();
                return await AssignRepo.OverrideAssignment(OverrideRequest);
            }
            else
            {
                CommonResponseModel Response = new CommonResponseModel
                {
                    Status = "Error",
                    Error = new ErrorModel
                    {
                        ErrorCode = "520",
                        InnerException = "",
                        Message = "Delivery Hero not found",
                        StackTrace = ""
                    }
                };

                return await Task.FromResult(Response);
            }
        }
        public async Task<RequestListForAssignmentResponse> GetRequestForAssignment(int AtcPointId, int PageNumber, string Operation)
        {
            return await AssignRepo.GetRequestForAssignment(AtcPointId, PageNumber, Operation);
        }
    }
}
