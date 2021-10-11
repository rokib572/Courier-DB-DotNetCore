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
using Microsoft.EntityFrameworkCore;

namespace Japax_Courier_DB.Clients
{
    public class ADClient
    {
        private JcdPickupAndDeliveryAreaRepo AreaRepo = new JcdPickupAndDeliveryAreaRepo();
        private JcdCountryInfoRepo CountryRepo = new JcdCountryInfoRepo();
        private JcdCityDistrictRepo CityDistrictRepo = new JcdCityDistrictRepo();
        private JcdProvinceStateDivisionRepo StateRepo = new JcdProvinceStateDivisionRepo();
        private JcdAdditionalPackagingChargeRepo ExtraPackageRepo = new JcdAdditionalPackagingChargeRepo();
        private JcdQuestionwareForFeedbackRepo QuestionaireRepo = new JcdQuestionwareForFeedbackRepo();
        private JcdPackageWithWeightChargeRepo PackageRepo = new JcdPackageWithWeightChargeRepo();
        private JcdProductTypeRepo ProductTypeRepo = new JcdProductTypeRepo();
        private JcdPsUpazilaRepo UpazilaRepo = new JcdPsUpazilaRepo();
        private JcdRequestTypeRepo RequestTypeRepo = new JcdRequestTypeRepo();
        private JcdAtcPickupAndDeliveryPointRepo AtcPointRepo = new JcdAtcPickupAndDeliveryPointRepo();
        private JcdPickupAndDeliveryRequestRepo RequestRepo = new JcdPickupAndDeliveryRequestRepo();
        private JcdAssignedRequestRepo AssignRepo = new JcdAssignedRequestRepo();
        private JcdDeliveryTimeSlotsRepo TimeSlotRepo = new JcdDeliveryTimeSlotsRepo();
        private JcdPickupAndDeliveryChargeRepo PickupAndDeliveryChargeRepo = new JcdPickupAndDeliveryChargeRepo();
        private JcdNotificationSmsMasterRepo NotificationSmsMaterRepo = new JcdNotificationSmsMasterRepo();
        private JcdNotificationMessagesRepo NotficationMessgeRepo = new JcdNotificationMessagesRepo();
        private JcdManifestInfoRepo ManifestRepo = new JcdManifestInfoRepo();
        private JcdPickupDeliveryTimePeriodsRepo TimePeriodRepo = new JcdPickupDeliveryTimePeriodsRepo();
        private JcdCourierBannerRepo BannerRepo = new JcdCourierBannerRepo();
        private JcdSenderInfoRepo SenderInfoRepo = new JcdSenderInfoRepo();

        public async Task<PickupAndDeliveryAreaModel> GetAreaById(int AreaId)
        {   
            return await AreaRepo.GetAreaById(AreaId);
        }
        public async Task<PickupAndDeliveryAreaModel> GetAreaByPsUpazila(int PsUpazilaId)
        {
            return await AreaRepo.GetAreaByPsUpazilaId(PsUpazilaId);
        }
        public async Task<PickupAndDeliveryAreaModel> GetAreaByCityDistrictId(int CityDistrictId)
        {
            return await AreaRepo.GetAreaByCityDistrictId(CityDistrictId);
        }
        public async Task<CountryInfoModel> GetActiveCountries()
        {
            return await CountryRepo.GetActiveCounties();
        }
        public async Task<CountryInfoModel> GetCountryDetails()
        {
            return await CountryRepo.GetCountryDetails();
        }
        public async Task<CityDistrictModel> GetCityDistrictByState(int StateId)
        {
            return await CityDistrictRepo.GetCityByState(StateId);
        }
        public async Task<CityDistrictModel> GetCityDistrictDetails()
        {
            return await CityDistrictRepo.GetCityDetails();
        }
        public async Task<ProvinceModel> GetStateByCountry(int CountryId)
        {
            return await StateRepo.GetStatesByCountry(CountryId);
        }
        public async Task<ProvinceModel> GetStateDetails()
        {
            return await StateRepo.GetStateDetails();
        }
        public async Task<ExtraPackagingTypeModel> GetExtraPackagingTypes()
        {
            return await ExtraPackageRepo.GetExtraPackagingType();
        }
        public async Task<ExtraPackagingTypeModel> GetActiveExtraPackagingTypes()
        {
            return await ExtraPackageRepo.GetActiveExtraPackagingType();
        }
        public async Task<FeedbackQuestionaireInfoModel> GetFeedbackQuestionaire()
        {
            return await QuestionaireRepo.GetFeedbackQuestionaire();
        }
        public async Task<PackageWithChargeResponseModel> GetActivePacakgeTypes()
        {
            return await PackageRepo.GetActivePackageTypes();
        }
        public async Task<PackageWithChargeResponseModel> GetAllPackages()
        {
            return await PackageRepo.GetAllPackageTypes();
        }
        public async Task<PackageWithChargeResponseModel> GetPackageTypeById (int PackageTypeId)
        {
            return await PackageRepo.GetPackageTypeById(PackageTypeId);
        }
        public async Task<CommonResponseModel> AddPackageType(PackageWithChargeInfo PackageType)
        {
            return await PackageRepo.AddPackageType(PackageType);
        }
        public async Task<CommonResponseModel> UpdatePackageType(PackageWithChargeInfo PackageType)
        {
            return await PackageRepo.UpdatePackageType(PackageType);
        }
        public async Task<CommonResponseModel> ChangePackageTypeStatus(int PackageTypeId, byte Status)
        {
            return await PackageRepo.ChangePackageTypeStatus(PackageTypeId, Status);
        }
        public async Task<ProductTypeModel> GetAllProductType()
        {
            return await ProductTypeRepo.GetAllProducts();
        }
        public async Task<ProductTypeModel> GetActiveProductTypes()
        {
            return await ProductTypeRepo.GetActiveProductTypes();
        }
        public async Task<ProductTypeModel> GetProductTypeById(int ProductTypeId)
        {
            return await ProductTypeRepo.GetProductTypeById(ProductTypeId);
        }
        public async Task<CommonResponseModel> AddProductType(ProductTypeInfo ProductType)
        {
            return await ProductTypeRepo.AddProductType(ProductType);
        }
        public async Task<CommonResponseModel> UpdateProductType(ProductTypeInfo ProductType)
        {
            return await ProductTypeRepo.UpdateProductType(ProductType);
        }
        public async Task<CommonResponseModel> ChangeProductTypeStatus(int ProductTypeId, byte ActiveStatus)
        {
            return await ProductTypeRepo.ChangeProductTypeStatus(ProductTypeId, ActiveStatus);
        }
        public async Task<UpazillaModel> GetPsUpazilaByDistrict(int CityDistrictId)
        {
            return await UpazilaRepo.GetPsUpazilaByDistrict(CityDistrictId);
        }
        public async Task<RequestTypeModel> GetRequestTypes()
        {
            return await RequestTypeRepo.GetRequestTypes();
        }
        public async Task<AtcPointModel> GetAtcPointByArea(int AreaId)
        {
            return await AtcPointRepo.GetAtcOutletsByArea(AreaId);
        }
        public async Task<AtcPointModel> GetAtcPointById(int PointId)
        {
            return await AtcPointRepo.GetAtcOutletById(PointId);
        }
        public async Task<AtcPointModel> GetActiveAtcPoint()
        {
            return await AtcPointRepo.GetActiveAtcOutlet();
        }
        public async Task<AtcPointModel> GetAllAtcPoint()
        {
            return await AtcPointRepo.GetAllAtcOutlet();
        }
        public async Task<CommonResponseModel> AddOutlet(AtcPointRequestModel Request)
        {
            return await AtcPointRepo.AddOutlet(Request);
        }
        public async Task<CommonResponseModel> UpdateOutlet(AtcPointRequestModel Request)
        {
            return await AtcPointRepo.UpdateOutlet(Request);
        }
        public async Task<CommonResponseModel> ChangeOutletStatus(int PointId, byte Status, int UserId)
        {
            return await AtcPointRepo.ChangeOutletStatus(PointId, Status, UserId);
        }
        public async Task<CommonResponseModel> AddNewCity(CityDistrictRequestModel RequestModel)
        {
            return await CityDistrictRepo.AddNewCity(RequestModel);
        }
        public async Task<CommonResponseModel> UpdateCity(CityDistrictRequestModel RequestModel)
        {
            return await CityDistrictRepo.UpdateCity(RequestModel);
        }
        public async Task<CommonResponseModel> ChangeCityStatus(int CityDistrictId, byte Status, int UserId)
        {
            return await CityDistrictRepo.ChangeCityStatus(CityDistrictId, Status, UserId);
        }
        public async Task<CommonResponseModel> AddNewProvince(ProvinceRequestModel RequestModel)
        {
            return await StateRepo.AddNewState(RequestModel);
        }
        public async Task<CommonResponseModel> UpdateProvince(ProvinceRequestModel RequestModel)
        {
            return await StateRepo.UpdateState(RequestModel);
        }
        public async Task<CommonResponseModel> ChangeProvinceStatus(byte StateId, byte Status)
        {
            return await StateRepo.ChangeProvinceStatus(StateId, Status);
        }
        public async Task<CommonResponseModel> AddNewCountry(CountryRequestModel RequestModel)
        {
            return await CountryRepo.AddNewCountry(RequestModel);
        }
        public async Task<CommonResponseModel> UpdateCountry(CountryRequestModel RequestModel)
        {
            return await CountryRepo.UpdateCountry(RequestModel);
        }
        public async Task<CommonResponseModel> UpdateCountryStatus(int CountryId, byte Status, int UserId)
        {
            return await CountryRepo.ChangeCountryStatus(CountryId, Status, UserId);
        }
        public async Task<CommonResponseModel> AddNewArea(AreaRequestModel RequestModel)
        {
            return await AreaRepo.AddNewArea(RequestModel);
        }
        public async Task<CommonResponseModel> UpdateAreaStatus(AreaRequestModel RequestModel)
        {
            return await AreaRepo.UpdateAreaStatus(RequestModel);
        }
        public async Task<CommonResponseModel> AddNewPsUpazila(PsUpazilaRequestModel RequestModel)
        {
            return await UpazilaRepo.AddNewPsUpazila(RequestModel);
        }
        public async Task<CommonResponseModel> UpdatePsUpazilla(PsUpazilaRequestModel RequestModel)
        {
            return await UpazilaRepo.UpdatePsUpazilla(RequestModel);
        }
        public async Task<CommonResponseModel> UpdateUpazilaStatus(int PsUpazilaId, byte Status)
        {
            return await UpazilaRepo.UpdatePsUpazilaStatus(PsUpazilaId, Status);
        }
        public async Task<UpazillaModel> GetUpazillaDetails()
        {
            return await UpazilaRepo.GetUpazillaDetails();
        }
        public async Task<PickupAndDeliveryAreaModel> GetAreaDetails()
        {
            return await AreaRepo.GetAreaDetails();
        }
        public async Task<CommonResponseModel> CancelRequest(CancelRequestModel CancelModel)
        {
            return await RequestRepo.CancelRequest(CancelModel);
        }
        public async Task<DhAssignmentResponseModel> GetAssignmentByLatestStatus(long DhId, byte NotId, int PageNumber)
        {
            return await AssignRepo.GetAssignmentByLatestStatus(DhId, NotId, PageNumber);
        }
        public async Task<CommonResponseModel> AddNewExtraPackage(ExtraPackagingTypeInfo RequestModel)
        {
            return await ExtraPackageRepo.AddNewExtraPackage(RequestModel);
        }
        public async Task<CommonResponseModel> UpdateExtraPackage(ExtraPackagingTypeInfo RequestModel)
        {
            return await ExtraPackageRepo.UpdateExtraPackage(RequestModel);
        }
        public async Task<CommonResponseModel> ChangeExtraPackageStatus(byte ExtraPackageId, byte Status)
        {
            return await ExtraPackageRepo.ChangeExtraPackageStatus(ExtraPackageId, Status);
        }
        public async Task<ExtraPackagingTypeModel> GetExtraPackageById(byte ExtraPackageId)
        {
            return await ExtraPackageRepo.GetExtraPackingById(ExtraPackageId);
        }
        public async Task<DeliveryTimeSlotsResponseModel> GetActiveDeliveryTimeSlot()
        {
            return await TimeSlotRepo.GetActiveDeliveryTimeSlot();
        }
        public async Task<DeliveryTimeSlotsResponseModel> GetAllDeliveryTimeSlot()
        {
            return await TimeSlotRepo.GetAllDeliveryTimeSlot();
        }
        public async Task<DeliveryTimeSlotsResponseModel> GetDeliveryTimeSlotById(int DeliveryTimeStolId)
        {
            return await TimeSlotRepo.GetDeliveryTimeSlotById(DeliveryTimeStolId);
        }
        public async Task<CommonResponseModel> AddDeliveryTimeSlot(DeliveryTimeSlotsRequest DeliveryTimeSlot)
        {
            return await TimeSlotRepo.AddDeliveryTimeSlot(DeliveryTimeSlot);
        }
        public async Task<CommonResponseModel> UpdateDeliveryTimeSlot(DeliveryTimeSlotsRequest DeliveryTimeSlot)
        {
            return await TimeSlotRepo.UpdateDeliveryTimeSlot(DeliveryTimeSlot);
        }
        public async Task<CommonResponseModel> ChangeDeliveryTimeSlotStatus(int DeliveryTimeSlotId, int DestinationId, byte Status, int UserId)
        {
            return await TimeSlotRepo.ChangeDeliveryTimeSlotStatus(DeliveryTimeSlotId, DestinationId, Status, UserId);
        }
        public async Task<PickupAndDeliveryChargeResponseModel> GetPickupAndDeliveryChargeById(int ChargeId)
        {
            return await PickupAndDeliveryChargeRepo.GetPickupAndDeliveryChargeById(ChargeId);
        } 
        public async Task<PickupAndDeliveryChargeResponseModel> GetAllPickupAndDeliveryCharge()
        {
            return await PickupAndDeliveryChargeRepo.GetAllPickupAndDeliveryCharge();
        }
        public async Task<PickupAndDeliveryChargeResponseModel> GetActivePickupAndDeliveryCharge()
        {
            return await PickupAndDeliveryChargeRepo.GetActivePickupAndDeliveryCharge();
        }
        public async Task<CommonResponseModel> AddPickupAndDeliveryCharge(PickupAndDeliveryReqeustInfo ChargeModel)
        {
            return await PickupAndDeliveryChargeRepo.AddPickupAndDeliveryCharge(ChargeModel);
        }
        public async Task<CommonResponseModel> UpdatePickupAndDeliveryCharge(PickupAndDeliveryReqeustInfo ChargeModel)
        {
            return await PickupAndDeliveryChargeRepo.UpdatePickupAndDeliveryCharge(ChargeModel);
        }
        public async Task<CommonResponseModel> UpdatePickupAndDeliveryChargeStatus(int ChargeId, byte Status, int UserId)
        {
            return await PickupAndDeliveryChargeRepo.UpdatePickupAndDeliveryChargeStatus(ChargeId, Status, UserId);
        }
        public async Task<CommonResponseModel> AddNotificationSmsMaster(NotificationSmsRequestModel Request)
        {
            return await NotificationSmsMaterRepo.AddNotificationSmsMaster(Request);
        }
        public async Task<CommonResponseModel> UpdateNotificationSmsMaster(NotificationSmsRequestModel Request)
        {
            return await NotificationSmsMaterRepo.UpdateNotificationSmsMaster(Request);
        }
        public async Task<CommonResponseModel> ChangeNotificationSmsMasterStatus(int MasterId, byte Status, int UserId)
        {
            return await NotificationSmsMaterRepo.ChangeNotificationSmsMasterStatus(MasterId, Status, UserId);
        }
        public async Task<CommonResponseModel> AddNotificationMessage(NotificationMesasge Request)
        {
            return await NotficationMessgeRepo.AddNotificationMessage(Request);
        }
        public async Task<CommonResponseModel> UpdateNotificationMessage(NotificationMesasge Request)
        {
            return await NotficationMessgeRepo.UpdateNotificationMessage(Request);
        }
        public async Task<CommonResponseModel> ChangeNotificationMessageStatus(byte NotificationId, byte Status)
        {
            return await NotficationMessgeRepo.ChangeNotificationMessageStatus(NotificationId, Status);
        }
        public async Task<NotificationMsgModel> GetAllNotificationMessage()
        {
            return await NotficationMessgeRepo.GetAllNotificationMessage();
        }
        public async Task<NotificationMsgModel> GetActiveNotificationMessage()
        {
            return await NotficationMessgeRepo.GetActiveNotificationMessage();
        }
        public async Task<NotificationMsgModel> GetNotificationMessageById(byte NotificationId)
        {
            return await NotficationMessgeRepo.GetNotificationMessageById(NotificationId);
        }
        public async Task<NotificationSmsResponseModel> GetAllNotificationSmsMaster()
        {
            return await NotificationSmsMaterRepo.GetAllNotificationSmsMaster();
        }
        public async Task<NotificationSmsResponseModel> GetActiveNotificationSmsMaster()
        {
            return await NotificationSmsMaterRepo.GetActiveNotificationSmsMaster();
        }
        public async Task<NotificationSmsResponseModel> GetNotificationSmsMasterById(int MasterId)
        {
            return await NotificationSmsMaterRepo.GetNotificationSmsMasterById(MasterId);
        }
        public async Task<NotificationSmsResponseModel> GetNotificationSmsMasterByNotificationId(byte NotificationId)
        {
            return await NotificationSmsMaterRepo.GetNotificationSmsMasterByNotificationId(NotificationId);
        }
        public async Task<CommonResponseModel> CreateManifest(ManifestInfoRequestModel Request)
        {
            return await ManifestRepo.CreateManifest(Request);
        }
        public async Task<CommonResponseModel> UpdateManifest(ManifestInfoRequestModel Request)
        {
            return await ManifestRepo.UpdateManifest(Request);
        }
        public async Task<ManifestInfoResponseModel> GetManifestById(long ManifestId)
        {
            return await ManifestRepo.GetManifestById(ManifestId);
        }
        public async Task<ManifestInfoResponseModel> GetAllManifest()
        {
            return await ManifestRepo.GetAllManifest();
        }
        public async Task<ManifestInfoResponseModel> GetActiveManifest()
        {
            return await ManifestRepo.GetActiveManifest();
        }
        public async Task<CommonResponseModel> AddTimePeriods(PickupAndDeliveryTimePeriodRequestModel Request)
        {
            return await TimePeriodRepo.AddTimePeriods(Request);
        }
        public async Task<CommonResponseModel> UpdateTimePeriods(PickupAndDeliveryTimePeriodRequestModel Request)
        {
            return await TimePeriodRepo.UpdateTimePeriods(Request);
        }
        public async Task<CommonResponseModel> ChangeTimePeriodStatus(int TimePeriodId, int status)
        {
            return await TimePeriodRepo.ChangeTimePeriodStatus(TimePeriodId, status);
        }
        public async Task<PickupAndDeliveryTimePeriodResponseModel> GetTimePeriodById(int TimePeriodId)
        {
            return await TimePeriodRepo.GetTimePeriodById(TimePeriodId);
        }
        public async Task<PickupAndDeliveryTimePeriodResponseModel> GetActiveTimePeriod()
        {
            return await TimePeriodRepo.GetActiveTimePeriod();
        }
        public async Task<PickupAndDeliveryTimePeriodResponseModel> GetAllTimePeriod()
        {
            return await TimePeriodRepo.GetAllTimePeriod();
        }
        public async Task<CommonResponseModel> AddBanner(CourierBannerRequestModel BannerRequestModel)
        {
            return await BannerRepo.AddBanner(BannerRequestModel);
        }
        public async Task<CommonResponseModel> UpdateBanner(CourierBannerUpdateModel BannerUpdateModel)
        {
            return await BannerRepo.UpdateBanner(BannerUpdateModel);
        }
        public async Task<CourierBannerResponseModel> GetBannerDetails(byte BannerFor)
        {
            return await BannerRepo.GetBannerDetails(BannerFor);
        }
        public async Task<SenderDetailsRespModel> GetUserByType (byte SenderType, byte ActiveStatus)
        {
            return await SenderInfoRepo.GetUserByType(SenderType, ActiveStatus);
        }
        public async Task<SenderDetailsRespModel> GetUserById(long SenderId)
        {
            return await SenderInfoRepo.GetUserById(SenderId);
        }
    }
}
