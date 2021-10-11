using System;
using Japax_Courier_DB.DBModels.CommonModels;
using Japax_Courier_DB.DBModels.Courier.ResponseModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Japax_Courier_DB.DBModels.Courier
{
    public partial class JpxCourierContext : DbContext
    {
        public JpxCourierContext()
        {
        }

        public JpxCourierContext(DbContextOptions<JpxCourierContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Abc> Abc { get; set; }
        public virtual DbSet<AdmnCompanyInfo> AdmnCompanyInfo { get; set; }
        public virtual DbSet<AdmnCompanyUnitInfo> AdmnCompanyUnitInfo { get; set; }
        public virtual DbSet<AdmnDepartmentInfo> AdmnDepartmentInfo { get; set; }
        public virtual DbSet<AdmnModuleInfo> AdmnModuleInfo { get; set; }
        public virtual DbSet<AdmnScreenInfo> AdmnScreenInfo { get; set; }
        public virtual DbSet<AdmnUserInfo> AdmnUserInfo { get; set; }
        public virtual DbSet<AdmnUserRole> AdmnUserRole { get; set; }
        public virtual DbSet<AdmnUserUnitPermission> AdmnUserUnitPermission { get; set; }
        public virtual DbSet<ApplErrorLog> ApplErrorLog { get; set; }
        public virtual DbSet<JcdAdditionalPackagingCharge> JcdAdditionalPackagingCharge { get; set; }
        public virtual DbSet<JcdAssignRequest> JcdAssignRequest { get; set; }
        public virtual DbSet<JcdAtcPickupAndDeliveryPoint> JcdAtcPickupAndDeliveryPoint { get; set; }
        public virtual DbSet<JcdAtcPointWiseInventory> JcdAtcPointWiseInventory { get; set; }
        public virtual DbSet<JcdBannerDet> JcdBannerDet { get; set; }
        public virtual DbSet<JcdBannerInfo> JcdBannerInfo { get; set; }
        public virtual DbSet<JcdCityDistrict> JcdCityDistrict { get; set; }
        public virtual DbSet<JcdCountryInfo> JcdCountryInfo { get; set; }
        public virtual DbSet<JcdCustomerComplained> JcdCustomerComplained { get; set; }
        public virtual DbSet<JcdDeliveryHeroDocs> JcdDeliveryHeroDocs { get; set; }
        public virtual DbSet<JcdDeliveryHeroEdu> JcdDeliveryHeroEdu { get; set; }
        public virtual DbSet<JcdDeliveryHeroExp> JcdDeliveryHeroExp { get; set; }
        public virtual DbSet<JcdDeliveryHeroInfo> JcdDeliveryHeroInfo { get; set; }
        public virtual DbSet<JcdDeliveryTimeSlots> JcdDeliveryTimeSlots { get; set; }
        public virtual DbSet<JcdDestinationCharge> JcdDestinationCharge { get; set; }
        public virtual DbSet<JcdDhLocationStatus> JcdDhLocationStatus { get; set; }
        public virtual DbSet<JcdDiscountOfferDet> JcdDiscountOfferDet { get; set; }
        public virtual DbSet<JcdDiscountOfferInfo> JcdDiscountOfferInfo { get; set; }
        public virtual DbSet<JcdErrorLog> JcdErrorLog { get; set; }
        public virtual DbSet<JcdFeedbacks> JcdFeedbacks { get; set; }
        public virtual DbSet<JcdGiftWrappingCharge> JcdGiftWrappingCharge { get; set; }
        public virtual DbSet<JcdInitialDiscountForMerchant> JcdInitialDiscountForMerchant { get; set; }
        public virtual DbSet<JcdLedgerInfo> JcdLedgerInfo { get; set; }
        public virtual DbSet<JcdManifestDetailsNoNeed> JcdManifestDetailsNoNeed { get; set; }
        public virtual DbSet<JcdManifestInfo> JcdManifestInfo { get; set; }
        public virtual DbSet<JcdMasterDataLastEntryDate> JcdMasterDataLastEntryDate { get; set; }
        public virtual DbSet<JcdMerchantOrStarUserDet> JcdMerchantOrStarUserDet { get; set; }
        public virtual DbSet<JcdMerchantOrStarUserTran> JcdMerchantOrStarUserTran { get; set; }
        public virtual DbSet<JcdNotificationMessages> JcdNotificationMessages { get; set; }
        public virtual DbSet<JcdNotificationSmsMaster> JcdNotificationSmsMaster { get; set; }
        public virtual DbSet<JcdPackageWithWeightCharge> JcdPackageWithWeightCharge { get; set; }
        public virtual DbSet<JcdPickupAndDeliveryArea> JcdPickupAndDeliveryArea { get; set; }
        public virtual DbSet<JcdPickupAndDeliveryCharge> JcdPickupAndDeliveryCharge { get; set; }
        public virtual DbSet<JcdPickupAndDeliveryLog> JcdPickupAndDeliveryLog { get; set; }
        public virtual DbSet<JcdPickupAndDeliveryRequest> JcdPickupAndDeliveryRequest { get; set; }
        public virtual DbSet<JcdPickupAndDeliveryZone> JcdPickupAndDeliveryZone { get; set; }
        public virtual DbSet<JcdPickupDeliveryTimePeriods> JcdPickupDeliveryTimePeriods { get; set; }
        public virtual DbSet<JcdProductDetails> JcdProductDetails { get; set; }
        public virtual DbSet<JcdProductType> JcdProductType { get; set; }
        public virtual DbSet<JcdProvinceStateDivision> JcdProvinceStateDivision { get; set; }
        public virtual DbSet<JcdPsUpazila> JcdPsUpazila { get; set; }
        public virtual DbSet<JcdQuestionwareForFeedback> JcdQuestionwareForFeedback { get; set; }
        public virtual DbSet<JcdRequestType> JcdRequestType { get; set; }
        public virtual DbSet<JcdRestaurantInfo> JcdRestaurantInfo { get; set; }
        public virtual DbSet<JcdSenderAddress> JcdSenderAddress { get; set; }
        public virtual DbSet<JcdSenderInfo> JcdSenderInfo { get; set; }
        public virtual DbSet<JcdTempChargesId> JcdTempChargesId { get; set; }
        public virtual DbSet<TempRequest> TempRequest { get; set; }
        public virtual DbSet<View1> View1 { get; set; }
        public virtual DbSet<VwAdmnUserwiseUnitPermission> VwAdmnUserwiseUnitPermission { get; set; }
        public virtual DbSet<VwAllCharges> VwAllCharges { get; set; }
        public virtual DbSet<VwCharges> VwCharges { get; set; }
        public virtual DbSet<VwFinsChartOfAccounts> VwFinsChartOfAccounts { get; set; }
        public virtual DbSet<VwFinsVoucherDet> VwFinsVoucherDet { get; set; }

        //Custom Declaration
        public virtual DbSet<ProductDetailsInfo> ProductDetailsInfo { get; set; }
        public virtual DbSet<AddressModel> AddressModel { get; set; }
        public virtual DbSet<AddressAreaModel> AddressAreaModel { get; set; }
        public virtual DbSet<CountryInfo> CountryInfo { get; set; }
        public virtual DbSet<CityDistrictInfo> CityDistrictInfo { get; set; }
        public virtual DbSet<DeliveryHeroInfo> DeliveryHeroInfo { get; set; }
        public virtual DbSet<DeliveryHero> DeliveryHero { get; set; }
        public virtual DbSet<CountryDetails> CountryDetails { get; set; }
        public virtual DbSet<ProvinceDetails> ProvinceDetails { get; set; }
        public virtual DbSet<CityDistrictDetails> CityDistrictDetails { get; set; }
        public virtual DbSet<UpazillaDetails> UpazillaDetails { get; set; }
        public virtual DbSet<AreaDetails> AreaDetails { get; set; }
        public virtual DbSet<RequestListForAssignment> RequestListForAssignment { get; set; }
        public virtual DbSet<DhAssignmentResponseInfo> DhAssignmentResponseInfo { get; set; }
        public virtual DbSet<ExtraPackagingTypeInfo> ExtraPackagingTypeInfo { get; set; }
        public virtual DbSet<ProductTypeInfo> ProductTypeInfo { get; set; }
        public virtual DbSet<PackageWithChargeInfo> PackageWithChargeInfo { get; set; }
        public virtual DbSet<DeliveryTimeSlotsInfo> DeliveryTimeSlotsInfo { get; set; }
        public virtual DbSet<PickupAndDeliveryChargeInfo> PickupAndDeliveryChargeInfo { get; set; }
        public virtual DbSet<AtcPoints> AtcPoints { get; set; }
        public virtual DbSet<NotificationSmsInfo> NotificationSmsInfo { get; set; }
        public virtual DbSet<NotificationMesasge> NotificationMesasge { get; set; }
        public virtual DbSet<ManifestInfo> ManifestInfo { get; set; }
        public virtual DbSet<AssignmentInfoForNotificationModel> AssignmentInfoForNotificationModel { get; set; }
        public virtual DbSet<PickupAndDeliveryTimePeriodInfo> PickupAndDeliveryTimePeriodInfo { get; set; }
        public virtual DbSet<SenderDetailsResponseModel> SenderDetailsResponseModel { get; set; }
        public virtual DbSet<TrackingDetails> TrackingDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=174.138.184.42;Database=JPX_COURIER_DB;user id=jpx_auth_user;password=fS0b8?w0");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:DefaultSchema", "jpx_auth_user");

            modelBuilder.Entity<Abc>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ABC", "dbo");
            });

            modelBuilder.Entity<AdmnCompanyInfo>(entity =>
            {
                entity.HasKey(e => e.CompanyCode);

                entity.ToTable("ADMN_COMPANY_INFO", "dbo");

                entity.Property(e => e.CompanyCode)
                    .HasColumnName("COMPANY_CODE")
                    .ValueGeneratedNever();

                entity.Property(e => e.CompanyName)
                    .IsRequired()
                    .HasColumnName("COMPANY_NAME")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EntryDate)
                    .HasColumnName("ENTRY_DATE")
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.EntryUser).HasColumnName("ENTRY_USER");

                entity.Property(e => e.Notes)
                    .HasColumnName("NOTES")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Website)
                    .HasColumnName("WEBSITE")
                    .HasMaxLength(112)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<AdmnCompanyUnitInfo>(entity =>
            {
                entity.HasKey(e => e.UnitCode);

                entity.ToTable("ADMN_COMPANY_UNIT_INFO", "dbo");

                entity.Property(e => e.UnitCode)
                    .HasColumnName("UNIT_CODE")
                    .HasComment("2 Digit Company Code+Incremental Serial 0001 i.e. 6 Digit")
                    .ValueGeneratedNever();

                entity.Property(e => e.Address)
                    .HasColumnName("ADDRESS")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.CityDist)
                    .IsRequired()
                    .HasColumnName("CITY_DIST")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.CompanyCode).HasColumnName("COMPANY_CODE");

                entity.Property(e => e.ContactPerson)
                    .HasColumnName("CONTACT_PERSON")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasColumnName("COUNTRY")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Designation)
                    .HasColumnName("DESIGNATION")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasColumnName("EMAIL")
                    .HasMaxLength(55)
                    .IsUnicode(false);

                entity.Property(e => e.EntryDate)
                    .HasColumnName("ENTRY_DATE")
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.EntryUser).HasColumnName("ENTRY_USER");

                entity.Property(e => e.MobileNos)
                    .HasColumnName("MOBILE_NOS")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Notes)
                    .HasColumnName("NOTES")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.OtherNos)
                    .HasColumnName("OTHER_NOS")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PostalCode)
                    .HasColumnName("POSTAL_CODE")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.StateProvince)
                    .HasColumnName("STATE_PROVINCE")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.TelephoneNos)
                    .HasColumnName("TELEPHONE_NOS")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UnitLocation)
                    .HasColumnName("UNIT_LOCATION")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UnitName)
                    .IsRequired()
                    .HasColumnName("UNIT_NAME")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.CompanyCodeNavigation)
                    .WithMany(p => p.AdmnCompanyUnitInfo)
                    .HasForeignKey(d => d.CompanyCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ADMN_COMPANY_UNIT_INFO_ADMN_COMPANY_UNIT_INFO");
            });

            modelBuilder.Entity<AdmnDepartmentInfo>(entity =>
            {
                entity.HasKey(e => e.DeptId);

                entity.ToTable("ADMN_DEPARTMENT_INFO", "dbo");

                entity.HasIndex(e => e.DeptShortName)
                    .HasName("IX_ADMN_DEPARTMENT_INFO")
                    .IsUnique();

                entity.Property(e => e.DeptId)
                    .HasColumnName("DEPT_ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.DeptIncharge)
                    .HasColumnName("DEPT_INCHARGE")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.DeptName)
                    .IsRequired()
                    .HasColumnName("DEPT_NAME")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.DeptShortName)
                    .IsRequired()
                    .HasColumnName("DEPT_SHORT_NAME")
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.EntryUser).HasColumnName("ENTRY_USER");

                entity.HasOne(d => d.EntryUserNavigation)
                    .WithMany(p => p.AdmnDepartmentInfo)
                    .HasForeignKey(d => d.EntryUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ADMN_DEPARTMENT_INFO_ADMN_USER_INFO");
            });

            modelBuilder.Entity<AdmnModuleInfo>(entity =>
            {
                entity.HasKey(e => e.ModuleId);

                entity.ToTable("ADMN_MODULE_INFO", "dbo");

                entity.HasIndex(e => e.ModuleName)
                    .HasName("IX_ADMN_MODULE_INFO")
                    .IsUnique();

                entity.Property(e => e.ModuleId)
                    .HasColumnName("MODULE_ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.ModuleName)
                    .IsRequired()
                    .HasColumnName("MODULE_NAME")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ModuleSorting).HasColumnName("MODULE_SORTING");

                entity.Property(e => e.ModuleStatus)
                    .HasColumnName("MODULE_STATUS")
                    .HasComment("0=Active  1=Inactive");
            });

            modelBuilder.Entity<AdmnScreenInfo>(entity =>
            {
                entity.HasKey(e => e.ScreenId);

                entity.ToTable("ADMN_SCREEN_INFO", "dbo");

                entity.Property(e => e.ScreenId)
                    .HasColumnName("SCREEN_ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.FormName)
                    .IsRequired()
                    .HasColumnName("FORM_NAME")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('NA')");

                entity.Property(e => e.ModuleId).HasColumnName("MODULE_ID");

                entity.Property(e => e.ParentScreenId).HasColumnName("PARENT_SCREEN_ID");

                entity.Property(e => e.ScreenSorting).HasColumnName("SCREEN_SORTING");

                entity.Property(e => e.ScreenStatus)
                    .HasColumnName("SCREEN_STATUS")
                    .HasComment("0=Active  1=Inactive");

                entity.Property(e => e.ScreenTitle)
                    .IsRequired()
                    .HasColumnName("SCREEN_TITLE")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ScreenType)
                    .IsRequired()
                    .HasColumnName("SCREEN_TYPE")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.Url)
                    .IsRequired()
                    .HasColumnName("URL")
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('#')");

                entity.HasOne(d => d.Module)
                    .WithMany(p => p.AdmnScreenInfo)
                    .HasForeignKey(d => d.ModuleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ADMN_SCREEN_INFO_ADMN_MODULE_INFO");
            });

            modelBuilder.Entity<AdmnUserInfo>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.ToTable("ADMN_USER_INFO", "dbo");

                entity.HasIndex(e => e.UserName)
                    .HasName("IX_ADMN_USER_INFO")
                    .IsUnique();

                entity.Property(e => e.UserId)
                    .HasColumnName("USER_ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.ActiveStatus)
                    .HasColumnName("ACTIVE_STATUS")
                    .HasComment("0=Active  1=Inactive");

                entity.Property(e => e.EntryDate)
                    .HasColumnName("ENTRY_DATE")
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.PassHint)
                    .HasColumnName("PASS_HINT")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Salt)
                    .IsRequired()
                    .HasColumnName("SALT")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasColumnName("USER_NAME")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.UserPass)
                    .IsRequired()
                    .HasColumnName("USER_PASS")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<AdmnUserRole>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.UnitCode, e.ScreenId });

                entity.ToTable("ADMN_USER_ROLE", "dbo");

                entity.Property(e => e.UserId).HasColumnName("USER_ID");

                entity.Property(e => e.UnitCode).HasColumnName("UNIT_CODE");

                entity.Property(e => e.ScreenId).HasColumnName("SCREEN_ID");

                entity.Property(e => e.ApprovePerm)
                    .HasColumnName("APPROVE_PERM")
                    .HasDefaultValueSql("((1))")
                    .HasComment("1=Permitted  0=Not Permitted");

                entity.Property(e => e.DeletePerm)
                    .HasColumnName("DELETE_PERM")
                    .HasDefaultValueSql("((1))")
                    .HasComment("1=Permitted  0=Not Permitted");

                entity.Property(e => e.InsertPerm)
                    .HasColumnName("INSERT_PERM")
                    .HasDefaultValueSql("((1))")
                    .HasComment("1=Permitted  0=Not Permitted");

                entity.Property(e => e.PermitDate)
                    .HasColumnName("PERMIT_DATE")
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.PermittedBy).HasColumnName("PERMITTED_BY");

                entity.Property(e => e.UpdatePerm)
                    .HasColumnName("UPDATE_PERM")
                    .HasDefaultValueSql("((1))")
                    .HasComment("1=Permitted  0=Not Permitted");

                entity.Property(e => e.ViewPerm)
                    .HasColumnName("VIEW_PERM")
                    .HasDefaultValueSql("((1))")
                    .HasComment("1=Permitted  0=Not Permitted");

                entity.HasOne(d => d.Screen)
                    .WithMany(p => p.AdmnUserRole)
                    .HasForeignKey(d => d.ScreenId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ADMN_USER_ROLE_ADMN_SCREEN_INFO");

                entity.HasOne(d => d.UnitCodeNavigation)
                    .WithMany(p => p.AdmnUserRole)
                    .HasForeignKey(d => d.UnitCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ADMN_USER_ROLE_ADMN_COMPANY_UNIT_INFO");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AdmnUserRole)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ADMN_USER_ROLE_ADMN_USER_INFO");
            });

            modelBuilder.Entity<AdmnUserUnitPermission>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.UnitCode });

                entity.ToTable("ADMN_USER_UNIT_PERMISSION", "dbo");

                entity.Property(e => e.UserId).HasColumnName("USER_ID");

                entity.Property(e => e.UnitCode).HasColumnName("UNIT_CODE");

                entity.HasOne(d => d.UnitCodeNavigation)
                    .WithMany(p => p.AdmnUserUnitPermission)
                    .HasForeignKey(d => d.UnitCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ADMN_USER_UNIT_PERMISSION_ADMN_COMPANY_UNIT_INFO");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AdmnUserUnitPermission)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ADMN_USER_UNIT_PERMISSION_ADMN_USER_INFO");
            });

            modelBuilder.Entity<ApplErrorLog>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("APPL_ERROR_LOG", "dbo");

                entity.Property(e => e.ErrDt)
                    .HasColumnName("ERR_DT")
                    .HasColumnType("date")
                    .HasComment("SQL Message");

                entity.Property(e => e.ErrId)
                    .HasColumnName("ERR_ID")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasComment("Error Code");

                entity.Property(e => e.ErrMsgLgcy)
                    .HasColumnName("ERR_MSG_LGCY")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("User generated message");

                entity.Property(e => e.ErrMsgOra)
                    .HasColumnName("ERR_MSG_ORA")
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasComment("SQL generated message");

                entity.Property(e => e.ErrRaisedIn)
                    .HasColumnName("ERR_RAISED_IN")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("From which Table or Stored Prcedure");

                entity.Property(e => e.ErrType)
                    .HasColumnName("ERR_TYPE")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasComment("Insert/Update/Delete Error");

                entity.Property(e => e.ModuleName)
                    .HasColumnName("MODULE_NAME")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<JcdAdditionalPackagingCharge>(entity =>
            {
                entity.HasKey(e => e.ExtraPackagingId);

                entity.ToTable("JCD_ADDITIONAL_PACKAGING_CHARGE", "dbo");

                entity.Property(e => e.ExtraPackagingId)
                    .HasColumnName("EXTRA_PACKAGING_ID")
                    .HasDefaultValueSql("((1))")
                    .HasComment("0=No Extra Packing By Default");

                entity.Property(e => e.ActiveStatus)
                    .HasColumnName("ACTIVE_STATUS")
                    .HasDefaultValueSql("((1))")
                    .HasComment("1=Active  0=Inactive");

                entity.Property(e => e.PackagingCharge)
                    .HasColumnName("PACKAGING_CHARGE")
                    .HasColumnType("decimal(6, 2)");

                entity.Property(e => e.PackagingType)
                    .IsRequired()
                    .HasColumnName("PACKAGING_TYPE")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasComment("Box / Poly / Bag");
            });

            modelBuilder.Entity<JcdAssignRequest>(entity =>
            {
                entity.ToTable("JCD_ASSIGN_REQUEST", "dbo");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasComment("");

                entity.Property(e => e.AcceptDate)
                    .HasColumnName("ACCEPT_DATE")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('1900-01-01 00:00:00.000')")
                    .HasComment("Accept Date & Time");

                entity.Property(e => e.AcceptStatus)
                    .HasColumnName("ACCEPT_STATUS")
                    .HasDefaultValueSql("((0))")
                    .HasComment("1=If Accepted by Delivery Hero  0=Not Accepted by Delivey Hero");

                entity.Property(e => e.AssignBy)
                    .HasColumnName("ASSIGN_BY")
                    .HasComment("User ID From Admin");

                entity.Property(e => e.AssignDate)
                    .HasColumnName("ASSIGN_DATE")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())")
                    .HasComment("Assign Date & Time");

                entity.Property(e => e.AssignFor)
                    .HasColumnName("ASSIGN_FOR")
                    .HasComment(@"1=Assigned for Pickup & Drop 
(Pickup from Customer Or from ATC Point/Warehouse & Drop at Nearest Pickup Point/Warehouse)  
2=Assigned for Pickup & Delivery 
(Pickup from Customer Or from ATC Point & Delivery to Customer)");

                entity.Property(e => e.AssignStatus)
                    .HasColumnName("ASSIGN_STATUS")
                    .HasDefaultValueSql("((0))")
                    .HasComment(@"0=Pending  
1=Pickup from ATC Point or Warehouse or Sender Completed by Delivery Hero  
2=Drop at ATC Point or Warehouse 
3= Delivery to Customer Completed by Delivery Hero  after Acknowledge by Receiver (Customer)
4=Acknowledge from ATC Point or Warehouse
");

                entity.Property(e => e.CustomerFeedback)
                    .HasColumnName("CUSTOMER_FEEDBACK")
                    .HasDefaultValueSql("((0))")
                    .HasComment("Customer Feedback Against Delivery Hero (0=Not Feedback ) 1=Send Feedback and data insert into JCD_FEEDBACKS table");

                entity.Property(e => e.DeliveredTime)
                    .HasColumnName("DELIVERED_TIME")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('1900-01-01 00:00:00.000')")
                    .HasComment("Delivered or Drop Time  during Delivered to Customer or Drop at ATC Point/Warehouse");

                entity.Property(e => e.DhId)
                    .HasColumnName("DH_ID")
                    .HasComment("1 by Default No Delivery Hero");

                entity.Property(e => e.DropPointId)
                    .HasColumnName("DROP_POINT_ID")
                    .HasComment("1 By Default No Point e.g. Delivery to Customer Directly  >1 Drop at ATC Point or Warehouse");

                entity.Property(e => e.ManifestId)
                    .HasColumnName("MANIFEST_ID")
                    .HasDefaultValueSql("((1))")
                    .HasComment("1 by Default No Manifest");

                entity.Property(e => e.PickupPointId)
                    .HasColumnName("PICKUP_POINT_ID")
                    .HasDefaultValueSql("((1))")
                    .HasComment("1 By Default No Point e.g. Pickup from Sender  >1 Pickup from ATC Point or Warehouse");

                entity.Property(e => e.PickupTime)
                    .HasColumnName("PICKUP_TIME")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('1900-01-01 00:00:00.000')")
                    .HasComment("Pickup Time  during Pickup from Sender or Pickup Point");

                entity.Property(e => e.RequestId)
                    .HasColumnName("REQUEST_ID")
                    .HasComment("1 by Default If Multiple Request Assign According To One Manifest ID");

                entity.HasOne(d => d.AssignByNavigation)
                    .WithMany(p => p.JcdAssignRequest)
                    .HasForeignKey(d => d.AssignBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_JCD_ASSIGN_REQUEST_ADMN_USER_INFO");

                entity.HasOne(d => d.AssignForNavigation)
                    .WithMany(p => p.JcdAssignRequest)
                    .HasForeignKey(d => d.AssignFor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_JCD_ASSIGN_REQUEST_JCD_REQUEST_TYPE");

                entity.HasOne(d => d.DropPoint)
                    .WithMany(p => p.JcdAssignRequestDropPoint)
                    .HasForeignKey(d => d.DropPointId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_JCD_ASSIGN_REQUEST_JCD_ATC_PICKUP_AND_DELIVERY_POINT");

                entity.HasOne(d => d.Manifest)
                    .WithMany(p => p.JcdAssignRequest)
                    .HasForeignKey(d => d.ManifestId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_JCD_ASSIGN_REQUEST_JCD_MANIFEST_INFO");

                entity.HasOne(d => d.PickupPoint)
                    .WithMany(p => p.JcdAssignRequestPickupPoint)
                    .HasForeignKey(d => d.PickupPointId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_JCD_ASSIGN_REQUEST_JCD_ATC_PICKUP_AND_DELIVERY_POINT1");

                entity.HasOne(d => d.Request)
                    .WithMany(p => p.JcdAssignRequest)
                    .HasForeignKey(d => d.RequestId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_JCD_ASSIGN_REQUEST_JCD_PICKUP_AND_DELIVERY_REQUEST");
            });

            modelBuilder.Entity<JcdAtcPickupAndDeliveryPoint>(entity =>
            {
                entity.HasKey(e => e.AtcPointId);

                entity.ToTable("JCD_ATC_PICKUP_AND_DELIVERY_POINT", "dbo");

                entity.Property(e => e.AtcPointId)
                    .HasColumnName("ATC_POINT_ID")
                    .HasComment("1 By Default No Point")
                    .ValueGeneratedNever();

                entity.Property(e => e.ActiveStatus)
                    .HasColumnName("ACTIVE_STATUS")
                    .HasDefaultValueSql("((1))")
                    .HasComment("1=Active  0=Inactive");

                entity.Property(e => e.AtcPointAddress)
                    .IsRequired()
                    .HasColumnName("ATC_POINT_ADDRESS")
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('ATC')")
                    .HasComment(@"1. For goods receive at i.e. If Request Type is not Pickup &     Delivery Then By Default ATC address
2. For Food Delivery - Restaurant Address From     JCD_RESTAURANT_INFO Table");

                entity.Property(e => e.AtcPointAreaId).HasColumnName("ATC_POINT_AREA_ID");

                entity.Property(e => e.AtcPointGeocodingStatus)
                    .HasColumnName("ATC_POINT_GEOCODING_STATUS")
                    .HasComment("0 = Not Found | 1 = Partial Match | 2 = Exact Match");

                entity.Property(e => e.AtcPointLandmark)
                    .HasColumnName("ATC_POINT_LANDMARK")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment(@"1. For goods receive at i.e. If Request Type is not Pickup &     Delivery Then By Default ATC address
2. For Food Delivery - Restaurant Landmark From     JCD_RESTAURANT_INFO Table");

                entity.Property(e => e.AtcPointLatitudesData)
                    .HasColumnName("ATC_POINT_LATITUDES_DATA")
                    .HasColumnType("decimal(10, 8)");

                entity.Property(e => e.AtcPointLongitudesData)
                    .HasColumnName("ATC_POINT_LONGITUDES_DATA")
                    .HasColumnType("decimal(11, 8)");

                entity.Property(e => e.AtcPointMobileNo)
                    .IsRequired()
                    .HasColumnName("ATC_POINT_MOBILE_NO")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasComment("");

                entity.Property(e => e.AtcPointName)
                    .IsRequired()
                    .HasColumnName("ATC_POINT_NAME")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('ATC')")
                    .HasComment(@"1. For goods receive at i.e. If Request Type is not Pickup &     Delivery Then By Default ATC address
2. For Food Delivery - Restaurant Address From     JCD_RESTAURANT_INFO Table");

                entity.Property(e => e.AtcPointPostalCode)
                    .HasColumnName("ATC_POINT_POSTAL_CODE")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasComment(@"1. For goods receive at i.e. If Request Type is not Pickup &     Delivery Then By Default ATC address
2. For Food Delivery - Restaurant Postal Code From     JCD_RESTAURANT_INFO Table");

                entity.Property(e => e.AtcPointStreet)
                    .HasColumnName("ATC_POINT_STREET")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasComment(@"1. For goods receive at i.e. If Request Type is not Pickup &     Delivery Then By Default ATC address
2. For Food Delivery - Restaurant Street From     JCD_RESTAURANT_INFO Table");

                entity.Property(e => e.AtcPointType)
                    .HasColumnName("ATC_POINT_TYPE")
                    .HasDefaultValueSql("((1))")
                    .HasComment("1=Pickup Point  2=Warehouse");

                entity.Property(e => e.HouseOrRoadNo)
                    .HasColumnName("HOUSE_OR_ROAD_NO")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasComment(@"1. For goods receive at i.e. If Request Type is not Pickup &     Delivery Then By Default ATC address
2. For Food Delivery - Restaurant Houser or Road No From     JCD_RESTAURANT_INFO Table");

                entity.Property(e => e.SetDate)
                    .HasColumnName("SET_DATE")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UserId).HasColumnName("USER_ID");

                entity.HasOne(d => d.AtcPointArea)
                    .WithMany(p => p.JcdAtcPickupAndDeliveryPoint)
                    .HasForeignKey(d => d.AtcPointAreaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_JCD_ATC_PICKUP_AND_DELIVERY_POINT_JCD_PICKUP_AND_DELIVERY_AREA");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.JcdAtcPickupAndDeliveryPoint)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_JCD_ATC_PICKUP_AND_DELIVERY_POINT_ADMN_USER_INFO");
            });

            modelBuilder.Entity<JcdAtcPointWiseInventory>(entity =>
            {
                entity.HasKey(e => e.TranId);

                entity.ToTable("JCD_ATC_POINT_WISE_INVENTORY", "dbo");

                entity.HasIndex(e => new { e.AtcPointId, e.AssignId, e.RequestId })
                    .HasName("IX_JCD_ATC_POINT_WISE_INVENTORY")
                    .IsUnique();

                entity.Property(e => e.TranId)
                    .HasColumnName("TRAN_ID")
                    .HasComment("Auto ID");

                entity.Property(e => e.AcknowledgeByIn)
                    .HasColumnName("ACKNOWLEDGE_BY_IN")
                    .HasComment("0 by Default or Admin User ID From ATC Point or Warehouse During Stock In");

                entity.Property(e => e.AcknowledgeByOut)
                    .HasColumnName("ACKNOWLEDGE_BY_OUT")
                    .HasComment("0 by Default or Admin User ID From ATC Point or Warehouse During Stock Out");

                entity.Property(e => e.AssignId)
                    .HasColumnName("ASSIGN_ID")
                    .HasComment("Auto ID");

                entity.Property(e => e.AtcPointId)
                    .HasColumnName("ATC_POINT_ID")
                    .HasDefaultValueSql("((1))")
                    .HasComment("1 By Default No Point");

                entity.Property(e => e.InTime)
                    .HasColumnName("IN_TIME")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('1900-01-01 00:00:00.000')");

                entity.Property(e => e.ManifestIdIn)
                    .HasColumnName("MANIFEST_ID_IN")
                    .HasDefaultValueSql("((1))")
                    .HasComment("1 by Default No Manifest / >1 Manifest ID For More Than One Request In");

                entity.Property(e => e.ManifestIdOut)
                    .HasColumnName("MANIFEST_ID_OUT")
                    .HasDefaultValueSql("((1))")
                    .HasComment("1 by Default No Manifest / >1 Manifest ID For More Than One Request Out");

                entity.Property(e => e.OutTime)
                    .HasColumnName("OUT_TIME")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('1900-01-01 00:00:00.000')")
                    .HasComment("Pickup or Delivery Time");

                entity.Property(e => e.RequestId)
                    .HasColumnName("REQUEST_ID")
                    .HasComment("");

                entity.Property(e => e.SetDate)
                    .HasColumnName("SET_DATE")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.StockStatus)
                    .HasColumnName("STOCK_STATUS")
                    .HasDefaultValueSql("((0))")
                    .HasComment("0=Stock in Hand  1=Assigned  2=Outbound (Stock Out)");

                entity.HasOne(d => d.AcknowledgeByInNavigation)
                    .WithMany(p => p.JcdAtcPointWiseInventoryAcknowledgeByInNavigation)
                    .HasForeignKey(d => d.AcknowledgeByIn)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_JCD_ATC_POINT_WISE_INVENTORY_ADMN_USER_INFO");

                entity.HasOne(d => d.AcknowledgeByOutNavigation)
                    .WithMany(p => p.JcdAtcPointWiseInventoryAcknowledgeByOutNavigation)
                    .HasForeignKey(d => d.AcknowledgeByOut)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_JCD_ATC_POINT_WISE_INVENTORY_ADMN_USER_INFO1");

                entity.HasOne(d => d.Assign)
                    .WithMany(p => p.JcdAtcPointWiseInventory)
                    .HasForeignKey(d => d.AssignId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_JCD_ATC_POINT_WISE_INVENTORY_JCD_ASSIGN_REQUEST");

                entity.HasOne(d => d.AtcPoint)
                    .WithMany(p => p.JcdAtcPointWiseInventory)
                    .HasForeignKey(d => d.AtcPointId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_JCD_ATC_POINT_WISE_INVENTORY_JCD_ATC_PICKUP_AND_DELIVERY_POINT");

                entity.HasOne(d => d.ManifestIdInNavigation)
                    .WithMany(p => p.JcdAtcPointWiseInventoryManifestIdInNavigation)
                    .HasForeignKey(d => d.ManifestIdIn)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_JCD_ATC_POINT_WISE_INVENTORY_JCD_MANIFEST_INFO");

                entity.HasOne(d => d.ManifestIdOutNavigation)
                    .WithMany(p => p.JcdAtcPointWiseInventoryManifestIdOutNavigation)
                    .HasForeignKey(d => d.ManifestIdOut)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_JCD_ATC_POINT_WISE_INVENTORY_JCD_MANIFEST_INFO1");

                entity.HasOne(d => d.Request)
                    .WithMany(p => p.JcdAtcPointWiseInventory)
                    .HasForeignKey(d => d.RequestId)
                    .HasConstraintName("FK_JCD_ATC_POINT_WISE_INVENTORY_JCD_PICKUP_AND_DELIVERY_REQUEST");
            });

            modelBuilder.Entity<JcdBannerDet>(entity =>
            {
                entity.HasKey(e => new { e.BannerId, e.SlNo });

                entity.ToTable("JCD_BANNER_DET", "dbo");

                entity.Property(e => e.BannerId).HasColumnName("BANNER_ID");

                entity.Property(e => e.SlNo).HasColumnName("SL_NO");

                entity.Property(e => e.ActiveStatus)
                    .HasColumnName("ACTIVE_STATUS")
                    .HasDefaultValueSql("((1))")
                    .HasComment("1=Active  0=Inactive");

                entity.Property(e => e.BannerImageLocation)
                    .IsRequired()
                    .HasColumnName("BANNER_IMAGE_LOCATION")
                    .HasMaxLength(100);

                entity.HasOne(d => d.Banner)
                    .WithMany(p => p.JcdBannerDet)
                    .HasForeignKey(d => d.BannerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_JCD_BANNER_DET_JCD_BANNER_INFO");
            });

            modelBuilder.Entity<JcdBannerInfo>(entity =>
            {
                entity.HasKey(e => e.BannerId);

                entity.ToTable("JCD_BANNER_INFO", "dbo");

                entity.Property(e => e.BannerId).HasColumnName("BANNER_ID");

                entity.Property(e => e.ActiveStatus)
                    .HasColumnName("ACTIVE_STATUS")
                    .HasDefaultValueSql("((1))")
                    .HasComment("1=Active  0=Inactive");

                entity.Property(e => e.BannerFor)
                    .HasColumnName("BANNER_FOR")
                    .HasDefaultValueSql("((0))")
                    .HasComment("0=Banner for Courier  1=Banner for Food");

                entity.Property(e => e.BannerType)
                    .IsRequired()
                    .HasColumnName("BANNER_TYPE")
                    .HasMaxLength(20)
                    .HasComment("Pull-Up / Retractable");

                entity.Property(e => e.DateFrom)
                    .HasColumnName("DATE_FROM")
                    .HasColumnType("date")
                    .HasComment("Display Period From");

                entity.Property(e => e.DateTo)
                    .HasColumnName("DATE_TO")
                    .HasColumnType("date")
                    .HasComment("Display Period To");

                entity.Property(e => e.SetDate)
                    .HasColumnName("SET_DATE")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ShowInPage)
                    .HasColumnName("SHOW_IN_PAGE")
                    .HasMaxLength(20)
                    .HasComment("Home Page");

                entity.Property(e => e.TemplateName)
                    .IsRequired()
                    .HasColumnName("TEMPLATE_NAME")
                    .HasMaxLength(50)
                    .HasComment(@"1=Discount Allowed Based on Total Charges Amount Within Given Days Limit
2=Discount Allowed Based on Total Request Quantity Within Given Days Limit");

                entity.Property(e => e.UserId).HasColumnName("USER_ID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.JcdBannerInfo)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_JCD_COURIER_BANNER_INFO_ADMN_USER_INFO");
            });

            modelBuilder.Entity<JcdCityDistrict>(entity =>
            {
                entity.HasKey(e => e.CityDistrictId);

                entity.ToTable("JCD_CITY_DISTRICT", "dbo");

                entity.Property(e => e.CityDistrictId)
                    .HasColumnName("CITY_DISTRICT_ID")
                    .HasComment("0=No District By Default")
                    .ValueGeneratedNever();

                entity.Property(e => e.ActiveStatus)
                    .HasColumnName("ACTIVE_STATUS")
                    .HasDefaultValueSql("((1))")
                    .HasComment("1=Active  0=Inactive");

                entity.Property(e => e.CityDistrictName)
                    .IsRequired()
                    .HasColumnName("CITY_DISTRICT_NAME")
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasComment("(There are 11 major cities in Bangladesh which are governed by 12 City Corporations. Eight (8) of the aforementioned major cities are also part of eight bigger metropolitan areas. )");

                entity.Property(e => e.ProvinceId).HasColumnName("PROVINCE_ID");

                entity.Property(e => e.SetDate)
                    .HasColumnName("SET_DATE")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UserId).HasColumnName("USER_ID");

                entity.HasOne(d => d.Province)
                    .WithMany(p => p.JcdCityDistrict)
                    .HasForeignKey(d => d.ProvinceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_JCD_CITY_DISTRICT_JCD_PROVINCE_STATE_DIVISION");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.JcdCityDistrict)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_JCD_CITY_DISTRICT_ADMN_USER_INFO");
            });

            modelBuilder.Entity<JcdCountryInfo>(entity =>
            {
                entity.HasKey(e => e.CountryId);

                entity.ToTable("JCD_COUNTRY_INFO", "dbo");

                entity.Property(e => e.CountryId)
                    .HasColumnName("COUNTRY_ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.ActiveStatus)
                    .HasColumnName("ACTIVE_STATUS")
                    .HasDefaultValueSql("((1))")
                    .HasComment("1=Active  0=Inactive");

                entity.Property(e => e.CountryCode)
                    .IsRequired()
                    .HasColumnName("COUNTRY_CODE")
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasComment("BD/USA");

                entity.Property(e => e.CountryName)
                    .IsRequired()
                    .HasColumnName("COUNTRY_NAME")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EntryUser).HasColumnName("ENTRY_USER");

                entity.Property(e => e.Notes)
                    .HasColumnName("NOTES")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.TelephoneCode)
                    .IsRequired()
                    .HasColumnName("TELEPHONE_CODE")
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.HasOne(d => d.EntryUserNavigation)
                    .WithMany(p => p.JcdCountryInfo)
                    .HasForeignKey(d => d.EntryUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_JCD_COUNTRY_INFO_ADMN_USER_INFO");
            });

            modelBuilder.Entity<JcdCustomerComplained>(entity =>
            {
                entity.HasKey(e => new { e.RequestId, e.ComplainedBy })
                    .HasName("PK_JCD_CUSTOMER_COMPLAINED_1");

                entity.ToTable("JCD_CUSTOMER_COMPLAINED", "dbo");

                entity.Property(e => e.RequestId)
                    .HasColumnName("REQUEST_ID")
                    .HasComment("");

                entity.Property(e => e.ComplainedBy)
                    .HasColumnName("COMPLAINED_BY")
                    .HasComment("1=Sender  2=Receiver");

                entity.Property(e => e.ComplainedAgainst)
                    .HasColumnName("COMPLAINED_AGAINST")
                    .HasComment("1=Against Delivery Hero  2=Other Complain");

                entity.Property(e => e.ComplainedDet)
                    .IsRequired()
                    .HasColumnName("COMPLAINED_DET")
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasComment("Complained details from Sender/Receiver");

                entity.Property(e => e.ComplainedStatus)
                    .HasColumnName("COMPLAINED_STATUS")
                    .HasDefaultValueSql("((1))")
                    .HasComment("1=Opened  0=Closed");

                entity.Property(e => e.StepTakenBy)
                    .HasColumnName("STEP_TAKEN_BY")
                    .HasDefaultValueSql("((0))")
                    .HasComment("Admin User ID");

                entity.Property(e => e.WhatStepTaken)
                    .HasColumnName("WHAT_STEP_TAKEN")
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasComment("Necssary step taken against Delivery Hero for complained.");

                entity.HasOne(d => d.Request)
                    .WithMany(p => p.JcdCustomerComplained)
                    .HasForeignKey(d => d.RequestId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_JCD_CUSTOMER_COMPLAINED_JCD_PICKUP_AND_DELIVERY_REQUEST");

                entity.HasOne(d => d.StepTakenByNavigation)
                    .WithMany(p => p.JcdCustomerComplained)
                    .HasForeignKey(d => d.StepTakenBy)
                    .HasConstraintName("FK_JCD_CUSTOMER_COMPLAINED_ADMN_USER_INFO");
            });

            modelBuilder.Entity<JcdDeliveryHeroDocs>(entity =>
            {
                entity.ToTable("JCD_DELIVERY_HERO_DOCS", "dbo");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasComment("Auto ID");

                entity.Property(e => e.DhId).HasColumnName("DH_ID");

                entity.Property(e => e.DocumentLocation)
                    .IsRequired()
                    .HasColumnName("DOCUMENT_LOCATION")
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasComment("Document (Image) Location in Web Folder with DH ID-SL_NO");

                entity.Property(e => e.DocumentType)
                    .IsRequired()
                    .HasColumnName("DOCUMENT_TYPE")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("e.g. Educational Certificates (MBA) / Experience Certificates / NID etc.");

                entity.Property(e => e.SetDate)
                    .HasColumnName("SET_DATE")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UserId).HasColumnName("USER_ID");

                entity.HasOne(d => d.Dh)
                    .WithMany(p => p.JcdDeliveryHeroDocs)
                    .HasForeignKey(d => d.DhId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_JCD_DELIVERY_HERO_DOCS_JCD_DELIVERY_HERO_INFO");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.JcdDeliveryHeroDocs)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_JCD_DELIVERY_HERO_DOCS_ADMN_USER_INFO");
            });

            modelBuilder.Entity<JcdDeliveryHeroEdu>(entity =>
            {
                entity.ToTable("JCD_DELIVERY_HERO_EDU", "dbo");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasComment("Auto ID");

                entity.Property(e => e.AcademicOrganization)
                    .IsRequired()
                    .HasColumnName("ACADEMIC_ORGANIZATION")
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasComment("Name of School/University with location separated by coma e.g. Chattogram University, Chattogram.");

                entity.Property(e => e.DhId).HasColumnName("DH_ID");

                entity.Property(e => e.EducationYear)
                    .IsRequired()
                    .HasColumnName("EDUCATION_YEAR")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.FieldOfStudy)
                    .HasColumnName("FIELD_OF_STUDY")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("Areas of Specialization");

                entity.Property(e => e.Gpa)
                    .HasColumnName("GPA")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.QualificationName)
                    .IsRequired()
                    .HasColumnName("QUALIFICATION_NAME")
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasComment("MBA");

                entity.Property(e => e.SetDate)
                    .HasColumnName("SET_DATE")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UserId).HasColumnName("USER_ID");

                entity.HasOne(d => d.Dh)
                    .WithMany(p => p.JcdDeliveryHeroEdu)
                    .HasForeignKey(d => d.DhId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_JCD_DELIVERY_HERO_EDU_JCD_DELIVERY_HERO_INFO");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.JcdDeliveryHeroEdu)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_JCD_DELIVERY_HERO_EDU_ADMN_USER_INFO");
            });

            modelBuilder.Entity<JcdDeliveryHeroExp>(entity =>
            {
                entity.ToTable("JCD_DELIVERY_HERO_EXP", "dbo");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasComment("Auto ID");

                entity.Property(e => e.CompanyAddress)
                    .IsRequired()
                    .HasColumnName("COMPANY_ADDRESS")
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasComment("Address & Phone Nos");

                entity.Property(e => e.CompanyName)
                    .IsRequired()
                    .HasColumnName("COMPANY_NAME")
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasComment("Name of Employeer");

                entity.Property(e => e.DhId).HasColumnName("DH_ID");

                entity.Property(e => e.ExperiencePeriod)
                    .IsRequired()
                    .HasColumnName("EXPERIENCE_PERIOD")
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasComment("(e.g. 2010-08 To Present or 2008-05 To 2010-07)");

                entity.Property(e => e.JobTitle)
                    .IsRequired()
                    .HasColumnName("JOB_TITLE")
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasComment("Designation");

                entity.Property(e => e.KeyResponsibilities)
                    .IsRequired()
                    .HasColumnName("KEY_RESPONSIBILITIES")
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasComment("Role");

                entity.Property(e => e.SetDate)
                    .HasColumnName("SET_DATE")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UserId).HasColumnName("USER_ID");

                entity.HasOne(d => d.Dh)
                    .WithMany(p => p.JcdDeliveryHeroExp)
                    .HasForeignKey(d => d.DhId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_JCD_DELIVERY_HERO_EXP_JCD_DELIVERY_HERO_INFO");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.JcdDeliveryHeroExp)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_JCD_DELIVERY_HERO_EXP_ADMN_USER_INFO");
            });

            modelBuilder.Entity<JcdDeliveryHeroInfo>(entity =>
            {
                entity.HasKey(e => e.DhId);

                entity.ToTable("JCD_DELIVERY_HERO_INFO", "dbo");

                entity.HasIndex(e => e.DhCode)
                    .HasName("IX_JCD_DELIVERY_HERO_INFO")
                    .IsUnique();

                entity.Property(e => e.DhId)
                    .HasColumnName("DH_ID")
                    .HasComment("1 by Default No Delivery Hero");

                entity.Property(e => e.ActiveStatus)
                    .HasColumnName("ACTIVE_STATUS")
                    .HasDefaultValueSql("((1))")
                    .HasComment("1=Active  0=Inactive");

                entity.Property(e => e.AreaIdPmt)
                    .HasColumnName("AREA_ID_PMT")
                    .HasComment("1 For No Area");

                entity.Property(e => e.AreaIdPr)
                    .HasColumnName("AREA_ID_PR")
                    .HasComment("1 For No Area");

                entity.Property(e => e.AssignTeam)
                    .HasColumnName("ASSIGN_TEAM")
                    .HasComment("0=Default Team");

                entity.Property(e => e.DefaultAssignRole)
                    .HasColumnName("DEFAULT_ASSIGN_ROLE")
                    .HasComment("Default Role 0=Pickup & Delivery  1=Only Pickup  2=Only Delivery");

                entity.Property(e => e.DeviceId)
                    .HasColumnName("DEVICE_ID")
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.DhCode)
                    .IsRequired()
                    .HasColumnName("DH_CODE")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.DhEmailAddr)
                    .HasColumnName("DH_EMAIL_ADDR")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DhFirstName)
                    .IsRequired()
                    .HasColumnName("DH_FIRST_NAME")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DhImage)
                    .HasColumnName("DH_IMAGE")
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasComment("Image Location in Web Folder with DH ID");

                entity.Property(e => e.DhLastName)
                    .IsRequired()
                    .HasColumnName("DH_LAST_NAME")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DhMiddleName)
                    .HasColumnName("DH_MIDDLE_NAME")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.DhMobNo)
                    .IsRequired()
                    .HasColumnName("DH_MOB_NO")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.DhNationality)
                    .IsRequired()
                    .HasColumnName("DH_NATIONALITY")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.DhNid)
                    .IsRequired()
                    .HasColumnName("DH_NID")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasComment("Social Security Number");

                entity.Property(e => e.DhPassword)
                    .IsRequired()
                    .HasColumnName("DH_PASSWORD")
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.DhStatus)
                    .HasColumnName("DH_STATUS")
                    .HasComment("0=Idle 1=In Transit 2=Offline 3=Blocked 4=Inactive (It will update thruough Delivery App using by Delivery Hero)");

                entity.Property(e => e.DhType)
                    .HasColumnName("DH_TYPE")
                    .HasComment("0=Permanent  1=Freelanceer");

                entity.Property(e => e.EmergencyMobNo)
                    .HasColumnName("EMERGENCY_MOB_NO")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.FcmToken)
                    .HasColumnName("FCM_TOKEN")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.HouseNoPmt)
                    .IsRequired()
                    .HasColumnName("HOUSE_NO_PMT")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.HouseNoPr)
                    .IsRequired()
                    .HasColumnName("HOUSE_NO_PR")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.JoiningDate)
                    .HasColumnName("JOINING_DATE")
                    .HasColumnType("date");

                entity.Property(e => e.LatitudesData)
                    .HasColumnName("LATITUDES_DATA")
                    .HasColumnType("decimal(10, 8)")
                    .HasComment("Current Latitudes Data");

                entity.Property(e => e.LicencePlate)
                    .HasColumnName("LICENCE_PLATE")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.LocationPmt)
                    .HasColumnName("LOCATION_PMT")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LocationPr)
                    .IsRequired()
                    .HasColumnName("LOCATION_PR")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LongitudesData)
                    .HasColumnName("LONGITUDES_DATA")
                    .HasColumnType("decimal(11, 8)")
                    .HasComment("Current Longitudes Data");

                entity.Property(e => e.PermenantAddress)
                    .HasColumnName("PERMENANT_ADDRESS")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PostalCodePmt)
                    .IsRequired()
                    .HasColumnName("POSTAL_CODE_PMT")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PostalCodePr)
                    .IsRequired()
                    .HasColumnName("POSTAL_CODE_PR")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PresentAddress)
                    .HasColumnName("PRESENT_ADDRESS")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PsUpazlaIdPmt).HasColumnName("PS_UPAZLA_ID_PMT");

                entity.Property(e => e.PsUpazlaIdPr).HasColumnName("PS_UPAZLA_ID_PR");

                entity.Property(e => e.SetDate)
                    .HasColumnName("SET_DATE")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.StreetPmt)
                    .IsRequired()
                    .HasColumnName("STREET_PMT")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StreetPr)
                    .IsRequired()
                    .HasColumnName("STREET_PR")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TransportColor)
                    .HasColumnName("TRANSPORT_COLOR")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.TransportDescription)
                    .HasColumnName("TRANSPORT_DESCRIPTION")
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasComment("Year, Model etc.");

                entity.Property(e => e.TransportType)
                    .HasColumnName("TRANSPORT_TYPE")
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasComment("Bike / Cycle / Covered Van etc.");

                entity.Property(e => e.UserId).HasColumnName("USER_ID");

                entity.HasOne(d => d.AreaIdPmtNavigation)
                    .WithMany(p => p.JcdDeliveryHeroInfoAreaIdPmtNavigation)
                    .HasForeignKey(d => d.AreaIdPmt)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_JCD_DELIVERY_HERO_INFO_JCD_PICKUP_AND_DELIVERY_AREA");

                entity.HasOne(d => d.AreaIdPrNavigation)
                    .WithMany(p => p.JcdDeliveryHeroInfoAreaIdPrNavigation)
                    .HasForeignKey(d => d.AreaIdPr)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_JCD_DELIVERY_HERO_INFO_JCD_PICKUP_AND_DELIVERY_AREA1");

                entity.HasOne(d => d.PsUpazlaIdPmtNavigation)
                    .WithMany(p => p.JcdDeliveryHeroInfoPsUpazlaIdPmtNavigation)
                    .HasForeignKey(d => d.PsUpazlaIdPmt)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_JCD_DELIVERY_HERO_INFO_JCD_PS_UPAZILA");

                entity.HasOne(d => d.PsUpazlaIdPrNavigation)
                    .WithMany(p => p.JcdDeliveryHeroInfoPsUpazlaIdPrNavigation)
                    .HasForeignKey(d => d.PsUpazlaIdPr)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_JCD_DELIVERY_HERO_INFO_JCD_PS_UPAZILA1");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.JcdDeliveryHeroInfo)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_JCD_DELIVERY_HERO_INFO_ADMN_USER_INFO");
            });

            modelBuilder.Entity<JcdDeliveryTimeSlots>(entity =>
            {
                entity.HasKey(e => e.DeliverySlotsId);

                entity.ToTable("JCD_DELIVERY_TIME_SLOTS", "dbo");

                entity.Property(e => e.DeliverySlotsId)
                    .HasColumnName("DELIVERY_SLOTS_ID")
                    .HasDefaultValueSql("((1))")
                    .HasComment(@"Regular (2-3 Days)
Same Day (within 10 hour)
Next Day (within 24 hour)");

                entity.Property(e => e.ActiveStatus)
                    .HasColumnName("ACTIVE_STATUS")
                    .HasDefaultValueSql("((1))")
                    .HasComment("1=Active  0=Inactive");

                entity.Property(e => e.DeliveryTime)
                    .HasColumnName("DELIVERY_TIME")
                    .HasComment("Delivery Hour Within");

                entity.Property(e => e.DeliveryType)
                    .IsRequired()
                    .HasColumnName("DELIVERY_TYPE")
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasComment(@"Regular (2-3 Days)
Same Day (within 10 hour)
Next Day (within 24 hour)
");

                entity.Property(e => e.Disclaimer)
                    .HasColumnName("DISCLAIMER")
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasComment("e.g. For Regular (within 12 hour) Disclaimer: Request after 3 PM will be consider as next day delivery within 12 hours");

                entity.Property(e => e.RequestBefore)
                    .HasColumnName("REQUEST_BEFORE")
                    .HasDefaultValueSql("('00:00:00')")
                    .HasComment("Request before Start Time");

                entity.Property(e => e.SetDate)
                    .HasColumnName("SET_DATE")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UserId).HasColumnName("USER_ID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.JcdDeliveryTimeSlots)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_JCD_DELIVERY_TIME_SLOTS_ADMN_USER_INFO");
            });

            modelBuilder.Entity<JcdDestinationCharge>(entity =>
            {
                entity.HasKey(e => e.DestinationId);

                entity.ToTable("JCD_DESTINATION_CHARGE", "dbo");

                entity.HasIndex(e => new { e.DeliverySlotsId, e.DestinationType })
                    .HasName("IX_JCD_DESTINATION_CHARGE")
                    .IsUnique();

                entity.Property(e => e.DestinationId)
                    .HasColumnName("DESTINATION_ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.ActiveStatus)
                    .HasColumnName("ACTIVE_STATUS")
                    .HasDefaultValueSql("((1))")
                    .HasComment("1=Active  0=Inactive");

                entity.Property(e => e.DeliverySlotsId)
                    .HasColumnName("DELIVERY_SLOTS_ID")
                    .HasDefaultValueSql("((1))")
                    .HasComment("Regular (within 12 hour) / Regular (within 24 hour)/ Express (on time) /Regular (2-3 Days)");

                entity.Property(e => e.DestinationCharge)
                    .HasColumnName("DESTINATION_CHARGE")
                    .HasColumnType("decimal(6, 2)");

                entity.Property(e => e.DestinationType)
                    .HasColumnName("DESTINATION_TYPE")
                    .HasComment(@"1 = Delivery within Same District
2 = Delivery within Same Province But Different District
3 = Delivery To One Province To Other Province");

                entity.Property(e => e.SetDate)
                    .HasColumnName("SET_DATE")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UserId).HasColumnName("USER_ID");

                entity.HasOne(d => d.DeliverySlots)
                    .WithMany(p => p.JcdDestinationCharge)
                    .HasForeignKey(d => d.DeliverySlotsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_JCD_DESTINATION_CHARGE_JCD_DELIVERY_TIME_SLOTS");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.JcdDestinationCharge)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_JCD_DESTINATION_CHARGE_ADMN_USER_INFO");
            });

            modelBuilder.Entity<JcdDhLocationStatus>(entity =>
            {
                entity.HasKey(e => e.LatLongId);

                entity.ToTable("JCD_DH_LOCATION_STATUS", "dbo");

                entity.Property(e => e.LatLongId)
                    .HasColumnName("LAT_LONG_ID")
                    .HasComment("Delivery hero's last location will identify by max LAT_LONG_ID");

                entity.Property(e => e.AssignId)
                    .HasColumnName("ASSIGN_ID")
                    .HasComment("Auto ID");

                entity.Property(e => e.DhId).HasColumnName("DH_ID");

                entity.Property(e => e.LatLongTime)
                    .HasColumnName("LAT_LONG_TIME")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())")
                    .HasComment("Assign Date & Time");

                entity.Property(e => e.LatitudesData)
                    .HasColumnName("LATITUDES_DATA")
                    .HasColumnType("decimal(10, 8)");

                entity.Property(e => e.LongitudesData)
                    .HasColumnName("LONGITUDES_DATA")
                    .HasColumnType("decimal(11, 8)");

                entity.Property(e => e.NotificationId)
                    .HasColumnName("NOTIFICATION_ID")
                    .HasComment("Present Status (Notification Status ID From JCD_NOTIFICATION_MESSAGES Table) e.g. Assigned / Picked Up");

                entity.Property(e => e.RequestId)
                    .HasColumnName("REQUEST_ID")
                    .HasDefaultValueSql("((1))")
                    .HasComment("1=For No Request Assign To Delivery Hero");

                entity.HasOne(d => d.Dh)
                    .WithMany(p => p.JcdDhLocationStatus)
                    .HasForeignKey(d => d.DhId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_JCD_DH_LOCATION_STATUS_JCD_DH_LOCATION_STATUS");

                entity.HasOne(d => d.Request)
                    .WithMany(p => p.JcdDhLocationStatus)
                    .HasForeignKey(d => d.RequestId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_JCD_DH_LOCATION_STATUS_JCD_PICKUP_AND_DELIVERY_REQUEST");
            });

            modelBuilder.Entity<JcdDiscountOfferDet>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("JCD_DISCOUNT_OFFER_DET", "dbo");

                entity.Property(e => e.DiscountAmtOrPer)
                    .HasColumnName("DISCOUNT_AMT_OR_PER")
                    .HasColumnType("money");

                entity.Property(e => e.DiscountId).HasColumnName("DISCOUNT_ID");

                entity.Property(e => e.RangeFrom)
                    .HasColumnName("RANGE_FROM")
                    .HasColumnType("money");

                entity.Property(e => e.RangeTo)
                    .HasColumnName("RANGE_TO")
                    .HasColumnType("money");

                entity.HasOne(d => d.Discount)
                    .WithMany()
                    .HasForeignKey(d => d.DiscountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_JCD_DISCOUNT_OFFER_DET_JCD_DISCOUNT_OFFER_INFO");
            });

            modelBuilder.Entity<JcdDiscountOfferInfo>(entity =>
            {
                entity.HasKey(e => e.DiscountId);

                entity.ToTable("JCD_DISCOUNT_OFFER_INFO", "dbo");

                entity.Property(e => e.DiscountId).HasColumnName("DISCOUNT_ID");

                entity.Property(e => e.ActiveStatus)
                    .HasColumnName("ACTIVE_STATUS")
                    .HasDefaultValueSql("((1))")
                    .HasComment("1=Active  0=Inactive");

                entity.Property(e => e.CalculateBy)
                    .HasColumnName("CALCULATE_BY")
                    .HasComment("1=By Fixed Amount  2=By Percentage");

                entity.Property(e => e.DateFrom)
                    .HasColumnName("DATE_FROM")
                    .HasColumnType("date");

                entity.Property(e => e.DateTo)
                    .HasColumnName("DATE_TO")
                    .HasColumnType("date");

                entity.Property(e => e.DiscountOn)
                    .HasColumnName("DISCOUNT_ON")
                    .HasComment(@"1=Discount Allowed Based on Total Charges Amount Within Given Days Limit
2=Discount Allowed Based on Total Request Quantity Within Given Days Limit");

                entity.Property(e => e.SenderId)
                    .HasColumnName("SENDER_ID")
                    .HasComment("Sender ID From Sender Info Table");

                entity.Property(e => e.SetDate)
                    .HasColumnName("SET_DATE")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UserId).HasColumnName("USER_ID");

                entity.HasOne(d => d.Sender)
                    .WithMany(p => p.JcdDiscountOfferInfo)
                    .HasForeignKey(d => d.SenderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_JCD_DISCOUNT_OFFER_INFO_JCD_SENDER_INFO");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.JcdDiscountOfferInfo)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_JCD_DISCOUNT_OFFER_INFO_ADMN_USER_INFO");
            });

            modelBuilder.Entity<JcdErrorLog>(entity =>
            {
                entity.HasKey(e => e.ErrId);

                entity.ToTable("JCD_ERROR_LOG", "dbo");

                entity.Property(e => e.ErrId).HasColumnName("ERR_ID");

                entity.Property(e => e.ErrEntity)
                    .HasColumnName("ERR_ENTITY")
                    .HasMaxLength(4000);

                entity.Property(e => e.ErrInnerException)
                    .HasColumnName("ERR_INNER_EXCEPTION")
                    .HasMaxLength(4000)
                    .HasComment("C# exception handling during the execution of a program");

                entity.Property(e => e.ErrLineNo)
                    .HasColumnName("ERR_LINE_NO")
                    .HasComment("returns the line number at which an error occurred.");

                entity.Property(e => e.ErrMessage)
                    .HasColumnName("ERR_MESSAGE")
                    .HasMaxLength(4000)
                    .HasComment("returns the message text of the error that caused the error (database generated message) ");

                entity.Property(e => e.ErrMethod)
                    .HasColumnName("ERR_METHOD")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("returns the event name at which an error occurred.");

                entity.Property(e => e.ErrMethodPayload)
                    .HasColumnName("ERR_METHOD_PAYLOAD")
                    .HasMaxLength(4000)
                    .HasComment("Input data, which caused an error due to data entry");

                entity.Property(e => e.ErrNo)
                    .HasColumnName("ERR_NO")
                    .HasComment("returns the error number that caused the error. ");

                entity.Property(e => e.ErrProcedure)
                    .HasColumnName("ERR_PROCEDURE")
                    .HasMaxLength(128)
                    .HasComment("returns the name of the Stored Procedure or trigger of where an error occurred.");

                entity.Property(e => e.ErrRaisedDate)
                    .HasColumnName("ERR_RAISED_DATE")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ErrStackTrace)
                    .HasColumnName("ERR_STACK_TRACE")
                    .HasMaxLength(4000)
                    .HasComment("line number in the method where the exception occurs in front-end");

                entity.Property(e => e.ErrStatus)
                    .HasColumnName("ERR_STATUS")
                    .HasDefaultValueSql("((0))")
                    .HasComment("0=Pending  1=Error Solved");

                entity.Property(e => e.UserId).HasColumnName("USER_ID");
            });

            modelBuilder.Entity<JcdFeedbacks>(entity =>
            {
                entity.HasKey(e => new { e.RequestId, e.EvaluateBy, e.EvaluationId });

                entity.ToTable("JCD_FEEDBACKS", "dbo");

                entity.Property(e => e.RequestId)
                    .HasColumnName("REQUEST_ID")
                    .HasComment("");

                entity.Property(e => e.EvaluateBy)
                    .HasColumnName("EVALUATE_BY")
                    .HasComment("1=By Sender  2=By Receiver  3=By Delivery Hero Against Customer");

                entity.Property(e => e.EvaluationId)
                    .HasColumnName("EVALUATION_ID")
                    .HasComment("Evaluation ID will be 0 For Other Evaluation (Other than fixed questionware if customer wants to give another feedbac)");

                entity.Property(e => e.EvaluationRating)
                    .HasColumnName("EVALUATION_RATING")
                    .HasComment(@"Rating is * (star) or Yes/No, depends on EVALUATION_METHOD of table JCD_CUSTOMER_FEEDBACK_QUESTIONWARE

Evaluation Method 1=Show Star Mark  0=Show Yes/No 
Star Mark Rating 5 or 4 or 3 or 2 or 1
Yes/No Rating 1=Yes  0=No");

                entity.Property(e => e.OtherEvaluation)
                    .HasColumnName("OTHER_EVALUATION")
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasComment("Other than fixed questionware if customer wants to give another feedback against Delivery Hero or Services");

                entity.HasOne(d => d.Evaluation)
                    .WithMany(p => p.JcdFeedbacks)
                    .HasForeignKey(d => d.EvaluationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_JCD_FEEDBACKS_JCD_QUESTIONWARE_FOR_FEEDBACK");

                entity.HasOne(d => d.Request)
                    .WithMany(p => p.JcdFeedbacks)
                    .HasForeignKey(d => d.RequestId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_JCD_FEEDBACKS_JCD_PICKUP_AND_DELIVERY_REQUEST");
            });

            modelBuilder.Entity<JcdGiftWrappingCharge>(entity =>
            {
                entity.HasKey(e => e.GiftWrappingId);

                entity.ToTable("JCD_GIFT_WRAPPING_CHARGE", "dbo");

                entity.Property(e => e.GiftWrappingId)
                    .HasColumnName("GIFT_WRAPPING_ID")
                    .HasComment("0=No Extra Wrapping By Default");

                entity.Property(e => e.ActiveStatus)
                    .HasColumnName("ACTIVE_STATUS")
                    .HasDefaultValueSql("((1))")
                    .HasComment("1=Active  0=Inactive");

                entity.Property(e => e.WrappingCharge)
                    .HasColumnName("WRAPPING_CHARGE")
                    .HasColumnType("decimal(6, 2)");

                entity.Property(e => e.WrappingType)
                    .IsRequired()
                    .HasColumnName("WRAPPING_TYPE")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasComment("Box / Poly / Bag");
            });

            modelBuilder.Entity<JcdInitialDiscountForMerchant>(entity =>
            {
                entity.HasKey(e => e.InitialDiscountId);

                entity.ToTable("JCD_INITIAL_DISCOUNT_FOR_MERCHANT", "dbo");

                entity.HasIndex(e => new { e.SenderId, e.CityDistrictId, e.DestinationType, e.PickupPoint, e.DeliveryPoint })
                    .HasName("IX_JCD_INITIAL_DISCOUNT_FOR_MERCHANT")
                    .IsUnique();

                entity.Property(e => e.InitialDiscountId).HasColumnName("INITIAL_DISCOUNT_ID");

                entity.Property(e => e.ActiveStatus)
                    .HasColumnName("ACTIVE_STATUS")
                    .HasDefaultValueSql("((1))")
                    .HasComment("1=Active  0=Inactive");

                entity.Property(e => e.CalculateBy)
                    .HasColumnName("CALCULATE_BY")
                    .HasComment("1=By Fixed Amount  2=By Percentage");

                entity.Property(e => e.CityDistrictId)
                    .HasColumnName("CITY_DISTRICT_ID")
                    .HasComment("0=No District By Default");

                entity.Property(e => e.DeliveryPoint)
                    .HasColumnName("DELIVERY_POINT")
                    .HasComment("1 = Delivery From ATC Outlet   2 = Delivery To Inside City   3 = Delivery To Outside City");

                entity.Property(e => e.DestinationType)
                    .HasColumnName("DESTINATION_TYPE")
                    .HasComment(@"1 = Delivery within Same District
2 = Delivery within Same Province But Different District
3 = Delivery To One Province To Other Province");

                entity.Property(e => e.DiscountAmtOrPer)
                    .HasColumnName("DISCOUNT_AMT_OR_PER")
                    .HasColumnType("money");

                entity.Property(e => e.PickupPoint)
                    .HasColumnName("PICKUP_POINT")
                    .HasComment("1 = Drop at ATC Outlet   2 = Pickup From Inside City   3 = Pickup From Outside City");

                entity.Property(e => e.SenderId).HasColumnName("SENDER_ID");

                entity.Property(e => e.SetDate)
                    .HasColumnName("SET_DATE")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UserId).HasColumnName("USER_ID");

                entity.HasOne(d => d.Sender)
                    .WithMany(p => p.JcdInitialDiscountForMerchant)
                    .HasForeignKey(d => d.SenderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_JCD_INITIAL_DISCOUNT_FOR_MERCHANT_JCD_SENDER_INFO");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.JcdInitialDiscountForMerchant)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_JCD_INITIAL_DISCOUNT_FOR_MERCHANT_ADMN_USER_INFO");
            });

            modelBuilder.Entity<JcdLedgerInfo>(entity =>
            {
                entity.HasKey(e => e.LedgerId);

                entity.ToTable("JCD_LEDGER_INFO", "dbo");

                entity.Property(e => e.LedgerId).HasColumnName("LEDGER_ID");

                entity.Property(e => e.LedgerName)
                    .IsRequired()
                    .HasColumnName("LEDGER_NAME")
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasComment("For Every Voucher Start From 1");

                entity.Property(e => e.SysDefine)
                    .HasColumnName("SYS_DEFINE")
                    .HasComment("1=System Defined (cannot be change)");
            });

            modelBuilder.Entity<JcdManifestDetailsNoNeed>(entity =>
            {
                entity.HasKey(e => new { e.ManifestId, e.RequestId })
                    .HasName("PK_JCD_MANIFEST_DETAILS");

                entity.ToTable("JCD_MANIFEST_DETAILS_no_need", "dbo");

                entity.Property(e => e.ManifestId)
                    .HasColumnName("MANIFEST_ID")
                    .HasComment("1 by Default No Manifest");

                entity.Property(e => e.RequestId)
                    .HasColumnName("REQUEST_ID")
                    .HasComment("");

                entity.HasOne(d => d.Manifest)
                    .WithMany(p => p.JcdManifestDetailsNoNeed)
                    .HasForeignKey(d => d.ManifestId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_JCD_MANIFEST_DETAILS_JCD_MANIFEST_INFO");

                entity.HasOne(d => d.Request)
                    .WithMany(p => p.JcdManifestDetailsNoNeed)
                    .HasForeignKey(d => d.RequestId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_JCD_MANIFEST_DETAILS_JCD_PICKUP_AND_DELIVERY_REQUEST");
            });

            modelBuilder.Entity<JcdManifestInfo>(entity =>
            {
                entity.HasKey(e => e.ManifestId);

                entity.ToTable("JCD_MANIFEST_INFO", "dbo");

                entity.HasIndex(e => e.TrackingNo)
                    .HasName("IX_JCD_MANIFEST_INFO")
                    .IsUnique();

                entity.Property(e => e.ManifestId)
                    .HasColumnName("MANIFEST_ID")
                    .HasComment("1 by Default No Manifest");

                entity.Property(e => e.DropPointId)
                    .HasColumnName("DROP_POINT_ID")
                    .HasComment(">1 Drop at ATC Point or Warehouse");

                entity.Property(e => e.ManifestStatus)
                    .HasColumnName("MANIFEST_STATUS")
                    .HasDefaultValueSql("((0))")
                    .HasComment("0=Stock in Hand  1=Outbound (Stock Out)  2=Cancel Manifest");

                entity.Property(e => e.NoOfRequest)
                    .HasColumnName("NO_OF_REQUEST")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.PickupPointId)
                    .HasColumnName("PICKUP_POINT_ID")
                    .HasComment(">1 Pickup from ATC Point or Warehouse");

                entity.Property(e => e.SetDate)
                    .HasColumnName("SET_DATE")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TrackingNo)
                    .IsRequired()
                    .HasColumnName("TRACKING_NO")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UserId).HasColumnName("USER_ID");

                entity.HasOne(d => d.DropPoint)
                    .WithMany(p => p.JcdManifestInfoDropPoint)
                    .HasForeignKey(d => d.DropPointId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_JCD_MANIFEST_INFO_JCD_ATC_PICKUP_AND_DELIVERY_POINT1");

                entity.HasOne(d => d.PickupPoint)
                    .WithMany(p => p.JcdManifestInfoPickupPoint)
                    .HasForeignKey(d => d.PickupPointId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_JCD_MANIFEST_INFO_JCD_ATC_PICKUP_AND_DELIVERY_POINT");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.JcdManifestInfo)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_JCD_MANIFEST_INFO_ADMN_USER_INFO");
            });

            modelBuilder.Entity<JcdMasterDataLastEntryDate>(entity =>
            {
                entity.ToTable("JCD_MASTER_DATA_LAST_ENTRY_DATE", "dbo");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AtcPickupAndDeliveryPoint)
                    .HasColumnName("ATC_PICKUP_AND_DELIVERY_POINT")
                    .HasColumnType("datetime")
                    .HasComment("Last Insert/Update Date for Feedback Questionware into JCD_QUESTIONWARE_FOR_FEEDBACK Table ");

                entity.Property(e => e.CityDistrict)
                    .HasColumnName("CITY_DISTRICT")
                    .HasColumnType("datetime")
                    .HasComment("Last Insert/Update Date for City or District into JCD_CITY_DISTRICT table");

                entity.Property(e => e.CountryName)
                    .HasColumnName("COUNTRY_NAME")
                    .HasColumnType("datetime");

                entity.Property(e => e.DeliverySlots)
                    .HasColumnName("DELIVERY_SLOTS")
                    .HasColumnType("datetime")
                    .HasComment("Last Insert/Update Date for Delivery Slots into JCD_DELIVERY_TIME_SLOTS table");

                entity.Property(e => e.ExtraPackagingType)
                    .HasColumnName("EXTRA_PACKAGING_TYPE")
                    .HasColumnType("datetime")
                    .HasComment("Last Insert/Update Date for Extra Packaging (Box/Poly) into JCD_ADDITIONAL_PACKAGING_CHARGE table");

                entity.Property(e => e.FeedbackQuestionware)
                    .HasColumnName("FEEDBACK_QUESTIONWARE")
                    .HasColumnType("datetime")
                    .HasComment("Last Insert/Update Date for Feedback Questionware into JCD_QUESTIONWARE_FOR_FEEDBACK Table ");

                entity.Property(e => e.NotificationMsg)
                    .HasColumnName("NOTIFICATION_MSG")
                    .HasColumnType("datetime")
                    .HasComment("Last Insert/Update Date for Notification Messages into JCD_NOTIFICATION_MESSAGES table");

                entity.Property(e => e.PackageType)
                    .HasColumnName("PACKAGE_TYPE")
                    .HasColumnType("datetime")
                    .HasComment("Last Insert/Update Date for Pickup & Delivery Package Type into JCD_PICKUP_AND_DELIVERY_CHARGE table");

                entity.Property(e => e.PickupAndDeliveryArea)
                    .HasColumnName("PICKUP_AND_DELIVERY_AREA")
                    .HasColumnType("datetime")
                    .HasComment("Last Insert/Update Date for Pickup & Delivery Area into JCD_PICKUP_AND_DELIVERY_AREA table");

                entity.Property(e => e.PickupAndDeliveryTimeSlots)
                    .HasColumnName("PICKUP_AND_DELIVERY_TIME_SLOTS")
                    .HasColumnType("datetime")
                    .HasComment("Last Insert/Update Date for Pickup & Delivery Time Slots into JCD_PICKUP_DELIVERY_TIME_PERIODS Table ");

                entity.Property(e => e.ProductType)
                    .HasColumnName("PRODUCT_TYPE")
                    .HasColumnType("datetime")
                    .HasComment("Last Insert/Update Date for Product Type into JCD_PRODUCT_TYPE table");

                entity.Property(e => e.ProvinceDivision)
                    .HasColumnName("PROVINCE_DIVISION")
                    .HasColumnType("datetime")
                    .HasComment("Last Insert/Update Date for Proince or Division into JCD_PROVINCE_STATE_DIVISION table");

                entity.Property(e => e.PsUpazla)
                    .HasColumnName("PS_UPAZLA")
                    .HasColumnType("datetime")
                    .HasComment("Last Insert/Update Date for Police Station or Upazila into JCD_PS_UPAZILA table");

                entity.Property(e => e.RequestType)
                    .HasColumnName("REQUEST_TYPE")
                    .HasColumnType("datetime")
                    .HasComment("Last Insert/Update Date for Request Type into JCD_REQUEST_TYPE table");

                entity.Property(e => e.ZoneName)
                    .HasColumnName("ZONE_NAME")
                    .HasColumnType("datetime")
                    .HasComment("Last Insert/Update Date for Pickup & Delivery Zone into JCD_PICKUP_AND_DELIVERY_ZONE table");
            });

            modelBuilder.Entity<JcdMerchantOrStarUserDet>(entity =>
            {
                entity.HasKey(e => e.SenderId);

                entity.ToTable("JCD_MERCHANT_OR_STAR_USER_DET", "dbo");

                entity.Property(e => e.SenderId)
                    .HasColumnName("SENDER_ID")
                    .HasComment("Sender ID From Sender Info Table")
                    .ValueGeneratedNever();

                entity.Property(e => e.Bin).HasColumnName("BIN");

                entity.Property(e => e.ClientEmail)
                    .HasColumnName("CLIENT_EMAIL")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ClientFirstName)
                    .IsRequired()
                    .HasColumnName("CLIENT_FIRST_NAME")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ClientLastName)
                    .IsRequired()
                    .HasColumnName("CLIENT_LAST_NAME")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ClientLogo)
                    .HasColumnName("CLIENT_LOGO")
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasComment("Image location");

                entity.Property(e => e.ClientMobileNo)
                    .IsRequired()
                    .HasColumnName("CLIENT_MOBILE_NO")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasComment("");

                entity.Property(e => e.CompanyName)
                    .IsRequired()
                    .HasColumnName("COMPANY_NAME")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreditDays)
                    .HasColumnName("CREDIT_DAYS")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CreditLimit)
                    .HasColumnName("CREDIT_LIMIT")
                    .HasColumnType("money")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.DefaultPaymentMethod)
                    .HasColumnName("DEFAULT_PAYMENT_METHOD")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasComment("Cash / Mobile (MFS)/ Bank / bKash /Nagad etc");

                entity.Property(e => e.DrivingLicenseNo)
                    .HasColumnName("DRIVING_LICENSE_NO")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FacebookLink)
                    .HasColumnName("FACEBOOK_LINK")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Nid).HasColumnName("NID");

                entity.Property(e => e.OthersLink)
                    .HasColumnName("OTHERS_LINK")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Remarks)
                    .HasColumnName("REMARKS")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.TradeLicenseNo).HasColumnName("TRADE_LICENSE_NO");

                entity.Property(e => e.Twiter)
                    .HasColumnName("TWITER")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Website)
                    .HasColumnName("WEBSITE")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Sender)
                    .WithOne(p => p.JcdMerchantOrStarUserDet)
                    .HasForeignKey<JcdMerchantOrStarUserDet>(d => d.SenderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_JCD_MERCHANT_OR_STAR_USER_DET_JCD_SENDER_INFO");
            });

            modelBuilder.Entity<JcdMerchantOrStarUserTran>(entity =>
            {
                entity.HasKey(e => e.SysVrno);

                entity.ToTable("JCD_MERCHANT_OR_STAR_USER_TRAN", "dbo");

                entity.Property(e => e.SysVrno).HasColumnName("SYS_VRNO");

                entity.Property(e => e.CreditAmt)
                    .HasColumnName("CREDIT_AMT")
                    .HasColumnType("money");

                entity.Property(e => e.DebitAmt)
                    .HasColumnName("DEBIT_AMT")
                    .HasColumnType("money");

                entity.Property(e => e.Description)
                    .HasColumnName("DESCRIPTION")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.LedgerId).HasColumnName("LEDGER_ID");

                entity.Property(e => e.LedgerName)
                    .IsRequired()
                    .HasColumnName("LEDGER_NAME")
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasComment("For Every Voucher Start From 1");

                entity.Property(e => e.RequestId)
                    .HasColumnName("REQUEST_ID")
                    .HasComment("1 by Default No Request");

                entity.Property(e => e.SenderId)
                    .HasColumnName("SENDER_ID")
                    .HasComment("Sender ID From Sender Info Table");

                entity.Property(e => e.TranDate)
                    .HasColumnName("TRAN_DATE")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.Ledger)
                    .WithMany(p => p.JcdMerchantOrStarUserTran)
                    .HasForeignKey(d => d.LedgerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_JCD_MERCHANT_OR_STAR_USER_TRAN_JCD_LEDGER_INFO");

                entity.HasOne(d => d.Request)
                    .WithMany(p => p.JcdMerchantOrStarUserTran)
                    .HasForeignKey(d => d.RequestId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_JCD_MERCHANT_OR_STAR_USER_TRAN_JCD_PICKUP_AND_DELIVERY_REQUEST");

                entity.HasOne(d => d.Sender)
                    .WithMany(p => p.JcdMerchantOrStarUserTran)
                    .HasForeignKey(d => d.SenderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_JCD_MERCHANT_OR_STAR_USER_TRAN_JCD_SENDER_INFO");
            });

            modelBuilder.Entity<JcdNotificationMessages>(entity =>
            {
                entity.HasKey(e => e.NotificationId);

                entity.ToTable("JCD_NOTIFICATION_MESSAGES", "dbo");

                entity.Property(e => e.NotificationId)
                    .HasColumnName("NOTIFICATION_ID")
                    .HasComment("");

                entity.Property(e => e.ActiveStatus)
                    .HasColumnName("ACTIVE_STATUS")
                    .HasDefaultValueSql("((1))")
                    .HasComment("1=Active  0=Inactive");

                entity.Property(e => e.NotificationMsg)
                    .IsRequired()
                    .HasColumnName("NOTIFICATION_MSG")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("Unassigned / Assigned / On The Way / Completed");

                entity.Property(e => e.ShowToClient)
                    .HasColumnName("SHOW_TO_CLIENT")
                    .HasDefaultValueSql("((1))")
                    .HasComment("1=Yes  0=No");

                entity.Property(e => e.SysDefine)
                    .HasColumnName("SYS_DEFINE")
                    .HasComment("1=System Defined (cannot be change)");
            });

            modelBuilder.Entity<JcdNotificationSmsMaster>(entity =>
            {
                entity.ToTable("JCD_NOTIFICATION_SMS_MASTER", "dbo");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ActiveStatus)
                    .HasColumnName("ACTIVE_STATUS")
                    .HasDefaultValueSql("((1))")
                    .HasComment("0 = Inactive | 1 = Active");

                entity.Property(e => e.NotificationId).HasColumnName("NOTIFICATION_ID");

                entity.Property(e => e.NotificationMessage)
                    .IsRequired()
                    .HasColumnName("NOTIFICATION_MESSAGE")
                    .HasMaxLength(160);

                entity.Property(e => e.NotificationTitle)
                    .IsRequired()
                    .HasColumnName("NOTIFICATION_TITLE")
                    .HasMaxLength(50)
                    .HasDefaultValueSql("(N'N/A')");

                entity.Property(e => e.SendNotification)
                    .HasColumnName("SEND_NOTIFICATION")
                    .HasComment("0 = NO | 1 = YES");

                entity.Property(e => e.SendNotificationTo)
                    .IsRequired()
                    .HasColumnName("SEND_NOTIFICATION_TO")
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasDefaultValueSql("((0))")
                    .HasComment("0 = None | 1 = SENDER | 2 = RECEIVER | 3 = DELIVERY HERO | 4 = ADMIN");

                entity.Property(e => e.SendSms)
                    .HasColumnName("SEND_SMS")
                    .HasComment("0 = NO | 1 = YES");

                entity.Property(e => e.SendSmsTo)
                    .IsRequired()
                    .HasColumnName("SEND_SMS_TO")
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasDefaultValueSql("((0))")
                    .HasComment("1 = SENDER | 2 = RECEIVER | 3 = DELIVERY HERO | 4 = ADMIN");

                entity.Property(e => e.SetDate)
                    .HasColumnName("SET_DATE")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.SmsMessage)
                    .IsRequired()
                    .HasColumnName("SMS_MESSAGE")
                    .HasMaxLength(160);

                entity.Property(e => e.UserId).HasColumnName("USER_ID");

                entity.HasOne(d => d.Notification)
                    .WithMany(p => p.JcdNotificationSmsMaster)
                    .HasForeignKey(d => d.NotificationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_JCD_NOTIFICATION_SMS_MASTER_JCD_NOTIFICATION_SMS_MASTER");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.JcdNotificationSmsMaster)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_JCD_NOTIFICATION_SMS_MASTER_ADMN_USER_INFO");
            });

            modelBuilder.Entity<JcdPackageWithWeightCharge>(entity =>
            {
                entity.HasKey(e => e.PackageChargeId);

                entity.ToTable("JCD_PACKAGE_WITH_WEIGHT_CHARGE", "dbo");

                entity.Property(e => e.PackageChargeId)
                    .HasColumnName("PACKAGE_CHARGE_ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.ActiveStatus)
                    .HasColumnName("ACTIVE_STATUS")
                    .HasDefaultValueSql("((1))")
                    .HasComment("1=Active  0=Inactive");

                entity.Property(e => e.DimensionUnit)
                    .IsRequired()
                    .HasColumnName("DIMENSION_UNIT")
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasComment("In / Cm/ M");

                entity.Property(e => e.ExtraPerDimensionCharge)
                    .HasColumnName("EXTRA_PER_DIMENSION_CHARGE")
                    .HasColumnType("decimal(8, 6)")
                    .HasDefaultValueSql("((0))")
                    .HasComment("For Custom Package If Dimension More Than Our Packages Then Calculation will be (Given Custom Dimension-Maximum Package Rate of Dimension x Extra Per Dimension Charge)");

                entity.Property(e => e.ExtraPerKgWeightCharge)
                    .HasColumnName("EXTRA_PER_KG_WEIGHT_CHARGE")
                    .HasColumnType("decimal(8, 6)")
                    .HasDefaultValueSql("((0))")
                    .HasComment("For Custom Package If Weight More Than Our Packages Then Calculation will be (Given Custom Weight-Maximum Package Rate of Weight x Extra Per Kg Weight Charge)");

                entity.Property(e => e.PackageCharge)
                    .HasColumnName("PACKAGE_CHARGE")
                    .HasColumnType("decimal(6, 2)");

                entity.Property(e => e.PackageDetails)
                    .HasColumnName("PACKAGE_DETAILS")
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasComment(@"e.g. For Standard Box below condition applied:

Dimension: 8X3X2
Weight: Upto 5Kg");

                entity.Property(e => e.PackageHeight)
                    .HasColumnName("PACKAGE_HEIGHT")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.PackageLength)
                    .HasColumnName("PACKAGE_LENGTH")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.PackageType)
                    .IsRequired()
                    .HasColumnName("PACKAGE_TYPE")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasComment("Letter/Document / Standard Box");

                entity.Property(e => e.PackageWeight)
                    .HasColumnName("PACKAGE_WEIGHT")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.PackageWidth)
                    .HasColumnName("PACKAGE_WIDTH")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.SetDate)
                    .HasColumnName("SET_DATE")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UserId).HasColumnName("USER_ID");

                entity.Property(e => e.WeightUnit)
                    .IsRequired()
                    .HasColumnName("WEIGHT_UNIT")
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasComment("Kg / Gm");
            });

            modelBuilder.Entity<JcdPickupAndDeliveryArea>(entity =>
            {
                entity.HasKey(e => e.AreaId);

                entity.ToTable("JCD_PICKUP_AND_DELIVERY_AREA", "dbo");

                entity.Property(e => e.AreaId)
                    .HasColumnName("AREA_ID")
                    .HasComment("Ward or Union ID / 1=No Area By Default");

                entity.Property(e => e.ActiveStatus)
                    .HasColumnName("ACTIVE_STATUS")
                    .HasDefaultValueSql("((1))")
                    .HasComment("1=Active  0=Inactive");

                entity.Property(e => e.AreaName)
                    .IsRequired()
                    .HasColumnName("AREA_NAME")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("Ward or Union Name (Under Police Station Ward & Under Upazila Union)");

                entity.Property(e => e.Polygon)
                    .HasColumnName("POLYGON")
                    .IsUnicode(false)
                    .HasComment("geographic information that consists of polygons, i.e. closed areas including the boundaries making up the areas");

                entity.Property(e => e.PsUpazlaId)
                    .HasColumnName("PS_UPAZLA_ID")
                    .HasComment("Under City Corporation=Police Station & Under Outside City Corporation=Upazila");

                entity.Property(e => e.SetDate)
                    .HasColumnName("SET_DATE")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UserId).HasColumnName("USER_ID");

                entity.Property(e => e.ZoneId)
                    .HasColumnName("ZONE_ID")
                    .HasDefaultValueSql("((0))")
                    .HasComment("0=No Zone");

                entity.HasOne(d => d.PsUpazla)
                    .WithMany(p => p.JcdPickupAndDeliveryArea)
                    .HasForeignKey(d => d.PsUpazlaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_JCD_PICKUP_AND_DELIVERY_AREA_JCD_PS_UPAZILA");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.JcdPickupAndDeliveryArea)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_JCD_PICKUP_AND_DELIVERY_AREA_ADMN_USER_INFO");

                entity.HasOne(d => d.Zone)
                    .WithMany(p => p.JcdPickupAndDeliveryArea)
                    .HasForeignKey(d => d.ZoneId)
                    .HasConstraintName("FK_JCD_PICKUP_AND_DELIVERY_AREA_JCD_PICKUP_AND_DELIVERY_ZONE");
            });

            modelBuilder.Entity<JcdPickupAndDeliveryCharge>(entity =>
            {
                entity.HasKey(e => e.ChargeId);

                entity.ToTable("JCD_PICKUP_AND_DELIVERY_CHARGE", "dbo");

                entity.HasIndex(e => new { e.CityDistrictId, e.PickupPoint, e.DeliveryPoint })
                    .HasName("IX_JCD_PICKUP_AND_DELIVERY_CHARGE_1")
                    .IsUnique();

                entity.Property(e => e.ChargeId)
                    .HasColumnName("CHARGE_ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.ActiveStatus)
                    .HasColumnName("ACTIVE_STATUS")
                    .HasDefaultValueSql("((1))")
                    .HasComment("1=Active  0=Inactive");

                entity.Property(e => e.CityDistrictId)
                    .HasColumnName("CITY_DISTRICT_ID")
                    .HasComment("0=No District By Default");

                entity.Property(e => e.DeliveryCharge)
                    .HasColumnName("DELIVERY_CHARGE")
                    .HasColumnType("decimal(6, 2)");

                entity.Property(e => e.DeliveryPoint)
                    .HasColumnName("DELIVERY_POINT")
                    .HasComment("1 = Delivery From ATC Outlet   2 = Delivery To Inside City   3 = Delivery To Outside City");

                entity.Property(e => e.PickupCharge)
                    .HasColumnName("PICKUP_CHARGE")
                    .HasColumnType("decimal(6, 2)");

                entity.Property(e => e.PickupPoint)
                    .HasColumnName("PICKUP_POINT")
                    .HasComment("1 = Drop At ATC Outlet   2 = Pickup From Inside City   3 = Pickup From Outside City");

                entity.Property(e => e.SetDate)
                    .HasColumnName("SET_DATE")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UserId).HasColumnName("USER_ID");

                entity.HasOne(d => d.CityDistrict)
                    .WithMany(p => p.JcdPickupAndDeliveryCharge)
                    .HasForeignKey(d => d.CityDistrictId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_JCD_PICKUP_AND_DELIVERY_CHARGE_JCD_CITY_DISTRICT");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.JcdPickupAndDeliveryCharge)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_JCD_PICKUP_AND_DELIVERY_CHARGE_ADMN_USER_INFO");
            });

            modelBuilder.Entity<JcdPickupAndDeliveryLog>(entity =>
            {
                entity.HasKey(e => e.LogId);

                entity.ToTable("JCD_PICKUP_AND_DELIVERY_LOG", "dbo");

                entity.Property(e => e.LogId)
                    .HasColumnName("LOG_ID")
                    .HasComment("Auto ID");

                entity.Property(e => e.AssignId)
                    .HasColumnName("ASSIGN_ID")
                    .HasComment("Auto ID");

                entity.Property(e => e.DhId)
                    .HasColumnName("DH_ID")
                    .HasComment("1 by Default for No Delivery Boy (During cancel request before Assign)");

                entity.Property(e => e.NotificationId)
                    .HasColumnName("NOTIFICATION_ID")
                    .HasComment("Present Status (Notification Status ID From JCD_NOTIFICATION_MESSAGES Table) e.g. Assigned / Picked Up");

                entity.Property(e => e.NotificationTime)
                    .HasColumnName("NOTIFICATION_TIME")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())")
                    .HasComment("Assign Date & Time");

                entity.Property(e => e.RequestId)
                    .HasColumnName("REQUEST_ID")
                    .HasComment("1 by Default If Multiple Request Assign According To One Manifest ID");

                entity.HasOne(d => d.Assign)
                    .WithMany(p => p.JcdPickupAndDeliveryLog)
                    .HasForeignKey(d => d.AssignId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_JCD_PICKUP_AND_DELIVERY_LOG_JCD_ASSIGN_REQUEST");

                entity.HasOne(d => d.Notification)
                    .WithMany(p => p.JcdPickupAndDeliveryLog)
                    .HasForeignKey(d => d.NotificationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_JCD_PICKUP_AND_DELIVERY_LOG_JCD_NOTIFICATION_MESSAGES");

                entity.HasOne(d => d.Request)
                    .WithMany(p => p.JcdPickupAndDeliveryLog)
                    .HasForeignKey(d => d.RequestId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_JCD_PICKUP_AND_DELIVERY_LOG_JCD_PICKUP_AND_DELIVERY_REQUEST");
            });

            modelBuilder.Entity<JcdPickupAndDeliveryRequest>(entity =>
            {
                entity.HasKey(e => e.RequestId);

                entity.ToTable("JCD_PICKUP_AND_DELIVERY_REQUEST", "dbo");

                entity.Property(e => e.RequestId)
                    .HasColumnName("REQUEST_ID")
                    .HasComment("1 by Default No Request");

                entity.Property(e => e.AtcDeliveryPoint)
                    .HasColumnName("ATC_DELIVERY_POINT")
                    .HasDefaultValueSql("((1))")
                    .HasComment("1 By Default No Point");

                entity.Property(e => e.AtcPickupPoint)
                    .HasColumnName("ATC_PICKUP_POINT")
                    .HasDefaultValueSql("((1))")
                    .HasComment("1 By Default No Point");

                entity.Property(e => e.CancelledBy)
                    .HasColumnName("CANCELLED_BY")
                    .HasDefaultValueSql("((0))")
                    .HasComment("0=Not Cancelled  1=Cancelled by Sender  2=Cancelled by ATC Admin  3=Cancelled by System Due To Encryption Error");

                entity.Property(e => e.CancelledReason)
                    .HasColumnName("CANCELLED_REASON")
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasComment("Reason for cancel");

                entity.Property(e => e.CancelledUserId)
                    .HasColumnName("CANCELLED_USER_ID")
                    .HasDefaultValueSql("((0))")
                    .HasComment("ATC Admin User ID");

                entity.Property(e => e.ChargeAmount)
                    .HasColumnName("CHARGE_AMOUNT")
                    .HasColumnType("decimal(6, 2)")
                    .HasComment("Total Charge Amount (Pickup & Delivery Charge+Weight Charge+Brittle Product Charge+Packaging Charge+Cash on Delivery Charge");

                entity.Property(e => e.ChargeAmountPayby)
                    .HasColumnName("CHARGE_AMOUNT_PAYBY")
                    .HasDefaultValueSql("((1))")
                    .HasComment("1=Sender  2=Receiver  3=Adjust with Reward Points");

                entity.Property(e => e.DeliveryBefore)
                    .HasColumnName("DELIVERY_BEFORE")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('1900-01-01 00:00:00.000')");

                entity.Property(e => e.DeliveryCharge)
                    .HasColumnName("DELIVERY_CHARGE")
                    .HasColumnType("decimal(6, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.DestinationCharge)
                    .HasColumnName("DESTINATION_CHARGE")
                    .HasColumnType("decimal(6, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.DestinationId).HasColumnName("DESTINATION_ID");

                entity.Property(e => e.IsCancelled)
                    .HasColumnName("IS_CANCELLED")
                    .HasDefaultValueSql("((0))")
                    .HasComment("0=Not Cancelled  1=Cancelled");

                entity.Property(e => e.IsComplained)
                    .HasColumnName("IS_COMPLAINED")
                    .HasDefaultValueSql("((0))")
                    .HasComment("0=Not Complained  1=Reported (Complained by Sender)  2=Reported (Complained by Receiver))");

                entity.Property(e => e.IsDelivered)
                    .HasColumnName("IS_DELIVERED")
                    .HasDefaultValueSql("((0))")
                    .HasComment("0=Pending  1=Completed (only when goods picked up and delivered)");

                entity.Property(e => e.PGeocodingStatus)
                    .HasColumnName("P_GEOCODING_STATUS")
                    .HasComment("0 = Not Found | 1 = Partial Match | 2 = Exact Match");

                entity.Property(e => e.PickupAddressLine1)
                    .HasColumnName("PICKUP_ADDRESS_LINE_1")
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('ATC')")
                    .HasComment(@"1. For goods receive at i.e. If Request Type is not Pickup &     Delivery Then By Default ATC address
2. For Food Delivery - Restaurant Address From     JCD_RESTAURANT_INFO Table");

                entity.Property(e => e.PickupAddressLine2)
                    .HasColumnName("PICKUP_ADDRESS_LINE_2")
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasComment("For Food Delivery - Restaurant Address From JCD_RESTAURANT_INFO Table");

                entity.Property(e => e.PickupAreaId).HasColumnName("PICKUP_AREA_ID");

                entity.Property(e => e.PickupBefore)
                    .HasColumnName("PICKUP_BEFORE")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('1900-01-01 00:00:00.000')");

                entity.Property(e => e.PickupCharge)
                    .HasColumnName("PICKUP_CHARGE")
                    .HasColumnType("decimal(6, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.PickupHouseOrRoadNo)
                    .HasColumnName("PICKUP_HOUSE_OR_ROAD_NO")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasComment(@"1. For goods receive at i.e. If Request Type is not Pickup &     Delivery Then By Default ATC address
2. For Food Delivery - Restaurant Houser or Road No From     JCD_RESTAURANT_INFO Table");

                entity.Property(e => e.PickupLandmark)
                    .HasColumnName("PICKUP_LANDMARK")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment(@"1. For goods receive at i.e. If Request Type is not Pickup &     Delivery Then By Default ATC address
2. For Food Delivery - Restaurant Landmark From     JCD_RESTAURANT_INFO Table");

                entity.Property(e => e.PickupPostalCode)
                    .HasColumnName("PICKUP_POSTAL_CODE")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasComment(@"1. For goods receive at i.e. If Request Type is not Pickup &     Delivery Then By Default ATC address
2. For Food Delivery - Restaurant Postal Code From     JCD_RESTAURANT_INFO Table");

                entity.Property(e => e.PickupStreet)
                    .HasColumnName("PICKUP_STREET")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasComment(@"1. For goods receive at i.e. If Request Type is not Pickup &     Delivery Then By Default ATC address
2. For Food Delivery - Restaurant Street From     JCD_RESTAURANT_INFO Table");

                entity.Property(e => e.RGeocodingStatus)
                    .HasColumnName("R_GEOCODING_STATUS")
                    .HasComment("0 = Not Found | 1 = Partial Match | 2 = Exact Match");

                entity.Property(e => e.ReceiverAddressLine1)
                    .HasColumnName("RECEIVER_ADDRESS_LINE_1")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ReceiverAddressLine2)
                    .HasColumnName("RECEIVER_ADDRESS_LINE_2")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ReceiverAreaId).HasColumnName("RECEIVER_AREA_ID");

                entity.Property(e => e.ReceiverFirstName)
                    .IsRequired()
                    .HasColumnName("RECEIVER_FIRST_NAME")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ReceiverHouseOrRoadNo)
                    .HasColumnName("RECEIVER_HOUSE_OR_ROAD_NO")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ReceiverLandmark)
                    .HasColumnName("RECEIVER_LANDMARK")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("Nearby Location");

                entity.Property(e => e.ReceiverLastName)
                    .IsRequired()
                    .HasColumnName("RECEIVER_LAST_NAME")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ReceiverLatitudesData)
                    .HasColumnName("RECEIVER_LATITUDES_DATA")
                    .HasColumnType("decimal(10, 8)");

                entity.Property(e => e.ReceiverLongitudesData)
                    .HasColumnName("RECEIVER_LONGITUDES_DATA")
                    .HasColumnType("decimal(11, 8)");

                entity.Property(e => e.ReceiverMobileNo)
                    .IsRequired()
                    .HasColumnName("RECEIVER_MOBILE_NO")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasComment("");

                entity.Property(e => e.ReceiverPostalCode)
                    .HasColumnName("RECEIVER_POSTAL_CODE")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ReceiverStreet)
                    .HasColumnName("RECEIVER_STREET")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.RequestDate)
                    .HasColumnName("REQUEST_DATE")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.RequestTypeId)
                    .HasColumnName("REQUEST_TYPE_ID")
                    .HasComment(@"ID From JCD_REQUEST_TYPE Table
 
1=Pickup & Delivery 2=Delivery Only 34=Delivery & Money Collection
");

                entity.Property(e => e.SenderFirstName)
                    .HasColumnName("SENDER_FIRST_NAME")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SenderId)
                    .HasColumnName("SENDER_ID")
                    .HasComment("Default 1 If Request Type is Delivery Only (Drop at ATC)");

                entity.Property(e => e.SenderLastName)
                    .HasColumnName("SENDER_LAST_NAME")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SenderLatitudesData)
                    .HasColumnName("SENDER_LATITUDES_DATA")
                    .HasColumnType("decimal(10, 8)");

                entity.Property(e => e.SenderLongitudesData)
                    .HasColumnName("SENDER_LONGITUDES_DATA")
                    .HasColumnType("decimal(11, 8)");

                entity.Property(e => e.SenderMobileNo)
                    .HasColumnName("SENDER_MOBILE_NO")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasComment("");

                entity.Property(e => e.SenderNotes)
                    .HasColumnName("SENDER_NOTES")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.SetDate)
                    .HasColumnName("SET_DATE")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TrackingId)
                    .HasColumnName("TRACKING_ID")
                    .HasMaxLength(15)
                    .HasComment("Auto / Insert by User");

                entity.HasOne(d => d.AtcDeliveryPointNavigation)
                    .WithMany(p => p.JcdPickupAndDeliveryRequestAtcDeliveryPointNavigation)
                    .HasForeignKey(d => d.AtcDeliveryPoint)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_JCD_PICKUP_AND_DELIVERY_REQUEST_JCD_ATC_PICKUP_AND_DELIVERY_POINT1");

                entity.HasOne(d => d.AtcPickupPointNavigation)
                    .WithMany(p => p.JcdPickupAndDeliveryRequestAtcPickupPointNavigation)
                    .HasForeignKey(d => d.AtcPickupPoint)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_JCD_PICKUP_AND_DELIVERY_REQUEST_JCD_ATC_PICKUP_AND_DELIVERY_POINT");

                entity.HasOne(d => d.Destination)
                    .WithMany(p => p.JcdPickupAndDeliveryRequest)
                    .HasForeignKey(d => d.DestinationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_JCD_PICKUP_AND_DELIVERY_REQUEST_JCD_DESTINATION_CHARGE");

                entity.HasOne(d => d.PickupArea)
                    .WithMany(p => p.JcdPickupAndDeliveryRequestPickupArea)
                    .HasForeignKey(d => d.PickupAreaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_JCD_PICKUP_AND_DELIVERY_REQUEST_JCD_PICKUP_AND_DELIVERY_AREA");

                entity.HasOne(d => d.ReceiverArea)
                    .WithMany(p => p.JcdPickupAndDeliveryRequestReceiverArea)
                    .HasForeignKey(d => d.ReceiverAreaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_JCD_PICKUP_AND_DELIVERY_REQUEST_JCD_PICKUP_AND_DELIVERY_AREA1");

                entity.HasOne(d => d.RequestType)
                    .WithMany(p => p.JcdPickupAndDeliveryRequest)
                    .HasForeignKey(d => d.RequestTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_JCD_PICKUP_AND_DELIVERY_REQUEST_JCD_REQUEST_TYPE");

                entity.HasOne(d => d.Sender)
                    .WithMany(p => p.JcdPickupAndDeliveryRequest)
                    .HasForeignKey(d => d.SenderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_JCD_PICKUP_AND_DELIVERY_REQUEST_JCD_SENDER_INFO");
            });

            modelBuilder.Entity<JcdPickupAndDeliveryZone>(entity =>
            {
                entity.HasKey(e => e.ZoneId);

                entity.ToTable("JCD_PICKUP_AND_DELIVERY_ZONE", "dbo");

                entity.Property(e => e.ZoneId)
                    .HasColumnName("ZONE_ID")
                    .HasComment("0=No Zone By Default");

                entity.Property(e => e.ActiveStatus)
                    .HasColumnName("ACTIVE_STATUS")
                    .HasDefaultValueSql("((1))")
                    .HasComment("1=Active  0=Inactive");

                entity.Property(e => e.CityDistrictId).HasColumnName("CITY_DISTRICT_ID");

                entity.Property(e => e.ZoneName)
                    .IsRequired()
                    .HasColumnName("ZONE_NAME")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment(@"Chittagong North Zone
Chittagong South Zone
Dhaka Central Zone
Dhaka East Zone
Dhaka South Zone
Barisal Zone
");

                entity.HasOne(d => d.CityDistrict)
                    .WithMany(p => p.JcdPickupAndDeliveryZone)
                    .HasForeignKey(d => d.CityDistrictId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_JCD_PICKUP_AND_DELIVERY_ZONE_JCD_CITY_DISTRICT");
            });

            modelBuilder.Entity<JcdPickupDeliveryTimePeriods>(entity =>
            {
                entity.HasKey(e => e.TimePeriodId)
                    .HasName("PK__JCD_PICK__3214EC27FA8C5D34");

                entity.ToTable("JCD_PICKUP_DELIVERY_TIME_PERIODS", "dbo");

                entity.Property(e => e.TimePeriodId).HasColumnName("TIME_PERIOD_ID");

                entity.Property(e => e.EndTime).HasColumnName("END_TIME");

                entity.Property(e => e.RequestBefore)
                    .HasColumnName("REQUEST_BEFORE")
                    .HasComment("Request before Start Time");

                entity.Property(e => e.RequestBeforeUm)
                    .IsRequired()
                    .HasColumnName("REQUEST_BEFORE_UM")
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('hr')")
                    .HasComment("hr / mn");

                entity.Property(e => e.StartTime).HasColumnName("START_TIME");

                entity.Property(e => e.Status)
                    .HasColumnName("STATUS")
                    .HasDefaultValueSql("((1))")
                    .HasComment("1 = Active | 2 = Inactive");
            });

            modelBuilder.Entity<JcdProductDetails>(entity =>
            {
                entity.HasKey(e => new { e.SlNo, e.RequestId });

                entity.ToTable("JCD_PRODUCT_DETAILS", "dbo");

                entity.Property(e => e.SlNo).HasColumnName("SL_NO");

                entity.Property(e => e.RequestId)
                    .HasColumnName("REQUEST_ID")
                    .HasComment("");

                entity.Property(e => e.DimensionUnit)
                    .HasColumnName("DIMENSION_UNIT")
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasComment("In / Cm/ M");

                entity.Property(e => e.ExtraPackagingId)
                    .HasColumnName("EXTRA_PACKAGING_ID")
                    .HasComment("0=No Extra Packing By Default");

                entity.Property(e => e.GiftWrappingId)
                    .HasColumnName("GIFT_WRAPPING_ID")
                    .HasComment("0=No Extra Packing By Default");

                entity.Property(e => e.HandlingCharge)
                    .HasColumnName("HANDLING_CHARGE")
                    .HasColumnType("decimal(6, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.InsuranceCharge)
                    .HasColumnName("INSURANCE_CHARGE")
                    .HasColumnType("decimal(6, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.InsuranceId)
                    .HasColumnName("INSURANCE_ID")
                    .HasDefaultValueSql("((0))")
                    .HasComment("0=No Insurance By Default");

                entity.Property(e => e.PackageCharge)
                    .HasColumnName("PACKAGE_CHARGE")
                    .HasColumnType("decimal(6, 2)")
                    .HasDefaultValueSql("((0))")
                    .HasComment("Predefine Package Weight Charge");

                entity.Property(e => e.PackageChargeId)
                    .HasColumnName("PACKAGE_CHARGE_ID")
                    .HasComment("Package Charge From JCD_PACKAGE_WITH_WEIGHT_CHARGE Table");

                entity.Property(e => e.PackageHeight)
                    .HasColumnName("PACKAGE_HEIGHT")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.PackageLength)
                    .HasColumnName("PACKAGE_LENGTH")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.PackageWeight)
                    .HasColumnName("PACKAGE_WEIGHT")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.PackageWidth)
                    .HasColumnName("PACKAGE_WIDTH")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.PackagingCharge)
                    .HasColumnName("PACKAGING_CHARGE")
                    .HasColumnType("decimal(6, 2)")
                    .HasDefaultValueSql("((0))")
                    .HasComment("Extra Packaging Charge");

                entity.Property(e => e.ProductCode)
                    .HasColumnName("PRODUCT_CODE")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasComment("For Food Delivery Restaurant's Product Code");

                entity.Property(e => e.ProductDescription)
                    .IsRequired()
                    .HasColumnName("PRODUCT_DESCRIPTION")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProductImage)
                    .HasColumnName("PRODUCT_IMAGE")
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasComment("Image Location in Web Folder with SL_NO & REQUEST_ID ");

                entity.Property(e => e.ProductTypeId)
                    .HasColumnName("PRODUCT_TYPE_ID")
                    .HasComment("Handling Charge From JCD_PRODUCT_TYPE");

                entity.Property(e => e.WeightUnit)
                    .HasColumnName("WEIGHT_UNIT")
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasComment("Kg / Gm");

                entity.Property(e => e.WrappingCharge)
                    .HasColumnName("WRAPPING_CHARGE")
                    .HasColumnType("decimal(6, 2)")
                    .HasDefaultValueSql("((0))");

                entity.HasOne(d => d.ExtraPackaging)
                    .WithMany(p => p.JcdProductDetails)
                    .HasForeignKey(d => d.ExtraPackagingId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_JCD_PRODUCT_DETAILS_JCD_ADDITIONAL_PACKAGING_CHARGE");

                entity.HasOne(d => d.GiftWrapping)
                    .WithMany(p => p.JcdProductDetails)
                    .HasForeignKey(d => d.GiftWrappingId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_JCD_PRODUCT_DETAILS_JCD_GIFT_WRAPPING_CHARGE");

                entity.HasOne(d => d.PackageChargeNavigation)
                    .WithMany(p => p.JcdProductDetails)
                    .HasForeignKey(d => d.PackageChargeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_JCD_PRODUCT_DETAILS_JCD_PACKAGE_WITH_WEIGHT_CHARGE");

                entity.HasOne(d => d.ProductType)
                    .WithMany(p => p.JcdProductDetails)
                    .HasForeignKey(d => d.ProductTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_JCD_PRODUCT_DETAILS_JCD_PRODUCT_TYPE");

                entity.HasOne(d => d.Request)
                    .WithMany(p => p.JcdProductDetails)
                    .HasForeignKey(d => d.RequestId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_JCD_PRODUCT_DETAILS_JCD_PICKUP_AND_DELIVERY_REQUEST");
            });

            modelBuilder.Entity<JcdProductType>(entity =>
            {
                entity.HasKey(e => e.ProductTypeId);

                entity.ToTable("JCD_PRODUCT_TYPE", "dbo");

                entity.Property(e => e.ProductTypeId)
                    .HasColumnName("PRODUCT_TYPE_ID")
                    .HasComment("")
                    .ValueGeneratedNever();

                entity.Property(e => e.ActiveStatus)
                    .HasColumnName("ACTIVE_STATUS")
                    .HasDefaultValueSql("((1))")
                    .HasComment("1=Active  0=Inactive");

                entity.Property(e => e.HandlingCharge)
                    .HasColumnName("HANDLING_CHARGE")
                    .HasColumnType("decimal(6, 2)");

                entity.Property(e => e.ProductType)
                    .IsRequired()
                    .HasColumnName("PRODUCT_TYPE")
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasComment("General Parcel / Documents / Fragile Product");
            });

            modelBuilder.Entity<JcdProvinceStateDivision>(entity =>
            {
                entity.HasKey(e => e.ProvinceId);

                entity.ToTable("JCD_PROVINCE_STATE_DIVISION", "dbo");

                entity.Property(e => e.ProvinceId)
                    .HasColumnName("PROVINCE_ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.ActiveStatus)
                    .HasColumnName("ACTIVE_STATUS")
                    .HasDefaultValueSql("((1))")
                    .HasComment("1=Active  0=Inactive");

                entity.Property(e => e.CountryId)
                    .HasColumnName("COUNTRY_ID")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.ProvinceName)
                    .IsRequired()
                    .HasColumnName("PROVINCE_NAME")
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasComment("Name of Province/State/Division ");

                entity.Property(e => e.SetDate)
                    .HasColumnName("SET_DATE")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UserId).HasColumnName("USER_ID");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.JcdProvinceStateDivision)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_JCD_PROVINCE_STATE_DIVISION_JCD_COUNTRY_INFO");
            });

            modelBuilder.Entity<JcdPsUpazila>(entity =>
            {
                entity.HasKey(e => e.PsUpazlaId);

                entity.ToTable("JCD_PS_UPAZILA", "dbo");

                entity.Property(e => e.PsUpazlaId)
                    .HasColumnName("PS_UPAZLA_ID")
                    .HasComment("0=No PS/Upazila By Default / Under City Corporation=Police Station & Under Outside City Corporation=Upazila ")
                    .ValueGeneratedNever();

                entity.Property(e => e.ActiveStatus)
                    .HasColumnName("ACTIVE_STATUS")
                    .HasDefaultValueSql("((1))")
                    .HasComment("1=Active  0=Inactive");

                entity.Property(e => e.CityDistrictId).HasColumnName("CITY_DISTRICT_ID");

                entity.Property(e => e.PsUpazlaName)
                    .IsRequired()
                    .HasColumnName("PS_UPAZLA_NAME")
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasComment("Under City Corporation=Police Station & Under Outside City Corporation=Upazila");

                entity.Property(e => e.SetDate)
                    .HasColumnName("SET_DATE")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UnderCityCorporation)
                    .HasColumnName("UNDER_CITY_CORPORATION")
                    .HasComment("1=Under City Corporation/Police Station & 2=Under Outside City Corporation/Upazila");

                entity.Property(e => e.UserId).HasColumnName("USER_ID");

                entity.HasOne(d => d.CityDistrict)
                    .WithMany(p => p.JcdPsUpazila)
                    .HasForeignKey(d => d.CityDistrictId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_JCD_PS_UPAZILA_JCD_CITY_DISTRICT");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.JcdPsUpazila)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_JCD_PS_UPAZILA_ADMN_USER_INFO");
            });

            modelBuilder.Entity<JcdQuestionwareForFeedback>(entity =>
            {
                entity.HasKey(e => e.EvaluationId);

                entity.ToTable("JCD_QUESTIONWARE_FOR_FEEDBACK", "dbo");

                entity.HasIndex(e => e.SortingOrder)
                    .HasName("IX_JCD_CUSTOMER_FEEDBACK_QUESTIONWARE")
                    .IsUnique();

                entity.Property(e => e.EvaluationId)
                    .HasColumnName("EVALUATION_ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.AspectsOfEvaluation)
                    .IsRequired()
                    .HasColumnName("ASPECTS_OF_EVALUATION")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.EvaluationFor)
                    .HasColumnName("EVALUATION_FOR")
                    .HasComment("1=Questionware For Our Services For Customer  2=Questionware For Delivery Hero Against Customer");

                entity.Property(e => e.EvaluationMethod)
                    .HasColumnName("EVALUATION_METHOD")
                    .HasComment("1=Show Star Mark  0=Show Yes/No ");

                entity.Property(e => e.EvaluationStatus)
                    .HasColumnName("EVALUATION_STATUS")
                    .HasDefaultValueSql("((1))")
                    .HasComment("1=Active  0=Inactive");

                entity.Property(e => e.SortingOrder)
                    .HasColumnName("SORTING_ORDER")
                    .HasComment("By Default Evaluation ID will be Sorting Order");
            });

            modelBuilder.Entity<JcdRequestType>(entity =>
            {
                entity.HasKey(e => e.RequestTypeId);

                entity.ToTable("JCD_REQUEST_TYPE", "dbo");

                entity.Property(e => e.RequestTypeId)
                    .HasColumnName("REQUEST_TYPE_ID")
                    .HasComment(@"0=No Request By Default 
1=Pickup Only 2=Pickup & Delivery
 
3=Delivery Only 4=Delivery & Money Collection
");

                entity.Property(e => e.ActiveStatus)
                    .HasColumnName("ACTIVE_STATUS")
                    .HasDefaultValueSql("((1))")
                    .HasComment("1=Active  0=Inactive");

                entity.Property(e => e.RequestType)
                    .IsRequired()
                    .HasColumnName("REQUEST_TYPE")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment(@"0=No Request By Default 1=Pickup & Delivery
2=Delivery Only
3=Delivery & Money Collection
");

                entity.Property(e => e.ShowToClient)
                    .HasColumnName("SHOW_TO_CLIENT")
                    .HasDefaultValueSql("((1))")
                    .HasComment("1=Yes  0=No");

                entity.Property(e => e.ShowToDh)
                    .HasColumnName("SHOW_TO_DH")
                    .HasDefaultValueSql("((1))")
                    .HasComment("If Status is 1 Then Show in Assign To Delivery Hero Form");

                entity.Property(e => e.SysDefine)
                    .HasColumnName("SYS_DEFINE")
                    .HasComment("1=System Defined (cannot be change)");
            });

            modelBuilder.Entity<JcdRestaurantInfo>(entity =>
            {
                entity.HasKey(e => e.RestaurantId);

                entity.ToTable("JCD_RESTAURANT_INFO", "dbo");

                entity.Property(e => e.RestaurantId)
                    .HasColumnName("RESTAURANT_ID")
                    .HasComment("ACC_ID related to Chart of Accounts (500003 is default restaurant for link purpose)")
                    .ValueGeneratedNever();

                entity.Property(e => e.AddressLine1)
                    .HasColumnName("ADDRESS_LINE_1")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.AddressLine2)
                    .HasColumnName("ADDRESS_LINE_2")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.AreaId).HasColumnName("AREA_ID");

                entity.Property(e => e.CommissionRate)
                    .HasColumnName("COMMISSION_RATE")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.ContactPerson)
                    .HasColumnName("CONTACT_PERSON")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.CreditDays)
                    .HasColumnName("CREDIT_DAYS")
                    .HasDefaultValueSql("((3))");

                entity.Property(e => e.CreditLimit)
                    .HasColumnName("CREDIT_LIMIT")
                    .HasColumnType("money")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Designation)
                    .HasColumnName("DESIGNATION")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.HouseOrRoadNo)
                    .IsRequired()
                    .HasColumnName("HOUSE_OR_ROAD_NO")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Landmarjk)
                    .HasColumnName("LANDMARJK")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("Nearby Location");

                entity.Property(e => e.MobileNo)
                    .IsRequired()
                    .HasColumnName("MOBILE_NO")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PostalCode)
                    .HasColumnName("POSTAL_CODE")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.PsUpazlaId).HasColumnName("PS_UPAZLA_ID");

                entity.Property(e => e.RegistrationDate)
                    .HasColumnName("REGISTRATION_DATE")
                    .HasColumnType("date");

                entity.Property(e => e.RestaurantImage)
                    .HasColumnName("RESTAURANT_IMAGE")
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasComment("Image Location in Web Folder with DH ID");

                entity.Property(e => e.RestaurantName)
                    .IsRequired()
                    .HasColumnName("RESTAURANT_NAME")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.SetDate)
                    .HasColumnName("SET_DATE")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Street)
                    .IsRequired()
                    .HasColumnName("STREET")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UserId).HasColumnName("USER_ID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.JcdRestaurantInfo)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_JCD_RESTAURANT_INFO_ADMN_USER_INFO");
            });

            modelBuilder.Entity<JcdSenderAddress>(entity =>
            {
                entity.ToTable("JCD_SENDER_ADDRESS", "dbo");

                entity.HasIndex(e => new { e.AddressType, e.Id })
                    .HasName("IX_JCD_SENDER_ADDRESS")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ActiveStatus)
                    .HasColumnName("ACTIVE_STATUS")
                    .HasDefaultValueSql("((1))")
                    .HasComment("1=Active  0=Inactive");

                entity.Property(e => e.AddressLine1)
                    .IsRequired()
                    .HasColumnName("ADDRESS_LINE_1")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.AddressLine2)
                    .HasColumnName("ADDRESS_LINE_2")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.AddressType)
                    .IsRequired()
                    .HasColumnName("ADDRESS_TYPE")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasComment("Home / Office / Other");

                entity.Property(e => e.AreaId).HasColumnName("AREA_ID");

                entity.Property(e => e.EnteredBy)
                    .IsRequired()
                    .HasColumnName("ENTERED_BY")
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('USER')")
                    .HasComment("USER / ATC (if entered from ATC)");

                entity.Property(e => e.EntryDate)
                    .HasColumnName("ENTRY_DATE")
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.GeolocationStatus)
                    .HasColumnName("GEOLOCATION_STATUS")
                    .HasComment("0 = Not Found | 1 = Partial Match | 2 = Exact Match");

                entity.Property(e => e.HouseOrRoadNo)
                    .HasColumnName("HOUSE_OR_ROAD_NO")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Landmark)
                    .HasColumnName("LANDMARK")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("Nearby Location");

                entity.Property(e => e.LatitudesData)
                    .HasColumnName("LATITUDES_DATA")
                    .HasColumnType("decimal(10, 8)");

                entity.Property(e => e.LongitudesData)
                    .HasColumnName("LONGITUDES_DATA")
                    .HasColumnType("decimal(11, 8)");

                entity.Property(e => e.PostalCode)
                    .HasColumnName("POSTAL_CODE")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SenderId)
                    .HasColumnName("SENDER_ID")
                    .HasComment("");

                entity.Property(e => e.Street)
                    .HasColumnName("STREET")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Area)
                    .WithMany(p => p.JcdSenderAddress)
                    .HasForeignKey(d => d.AreaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_JCD_SENDER_ADDRESS_JCD_PICKUP_AND_DELIVERY_AREA");

                entity.HasOne(d => d.Sender)
                    .WithMany(p => p.JcdSenderAddress)
                    .HasForeignKey(d => d.SenderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_JCD_SENDER_ADDRESS_JCD_SENDER_INFO");
            });

            modelBuilder.Entity<JcdSenderInfo>(entity =>
            {
                entity.HasKey(e => e.SenderId);

                entity.ToTable("JCD_SENDER_INFO", "dbo");

                entity.Property(e => e.SenderId)
                    .HasColumnName("SENDER_ID")
                    .HasComment("Auto ID (Login ID From JPX_USER_AUTHENTICATION Table")
                    .ValueGeneratedNever();

                entity.Property(e => e.ActiveStatus)
                    .HasColumnName("ACTIVE_STATUS")
                    .HasDefaultValueSql("((1))")
                    .HasComment("1=Active  0=Inactive");

                entity.Property(e => e.AllowableAddress)
                    .HasColumnName("ALLOWABLE_ADDRESS")
                    .HasDefaultValueSql("((3))")
                    .HasComment("Number of Address Allowed For Saving");

                entity.Property(e => e.RewardPoint).HasColumnName("REWARD_POINT");

                entity.Property(e => e.SenderType)
                    .HasColumnName("SENDER_TYPE")
                    .HasDefaultValueSql("((1))")
                    .HasComment("1=General User  2=Merchant  3=Star User");

                entity.Property(e => e.SetDate)
                    .HasColumnName("SET_DATE")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<JcdTempChargesId>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("JCD_TEMP_CHARGES_ID", "dbo");

                entity.Property(e => e.DeliveryCharge)
                    .HasColumnName("DELIVERY_CHARGE")
                    .HasColumnType("decimal(6, 2)")
                    .HasDefaultValueSql("((0))")
                    .HasComment("Delivery Charge will update into First row only by Calculation from Stored Procedure since Delivery charge is single for one request");

                entity.Property(e => e.DestinationType)
                    .HasColumnName("DESTINATION_TYPE")
                    .HasComment(@"1 = Delivery within Same District
2 = Delivery within Same Province But Different District
3 = Delivery To One Province To Other Province");

                entity.Property(e => e.DimensionUnit)
                    .HasColumnName("DIMENSION_UNIT")
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasComment("In / Cm/ M");

                entity.Property(e => e.ExtraPackagingId)
                    .HasColumnName("EXTRA_PACKAGING_ID")
                    .HasDefaultValueSql("((1))")
                    .HasComment("0=No Extra Packing By Default");

                entity.Property(e => e.GiftWrappingId)
                    .HasColumnName("GIFT_WRAPPING_ID")
                    .HasComment("0=No Extra Wrapping By Default");

                entity.Property(e => e.PackageCharge)
                    .HasColumnName("PACKAGE_CHARGE")
                    .HasColumnType("decimal(6, 2)")
                    .HasDefaultValueSql("((0))")
                    .HasComment("For Custom Package Charge will update by Calculation from Stored Procedure since Custom Package charge is by default 0");

                entity.Property(e => e.PackageChargeId).HasColumnName("PACKAGE_CHARGE_ID");

                entity.Property(e => e.PackageHeight)
                    .HasColumnName("PACKAGE_HEIGHT")
                    .HasColumnType("decimal(12, 2)");

                entity.Property(e => e.PackageLength)
                    .HasColumnName("PACKAGE_LENGTH")
                    .HasColumnType("decimal(12, 2)");

                entity.Property(e => e.PackageWeight)
                    .HasColumnName("PACKAGE_WEIGHT")
                    .HasColumnType("decimal(12, 2)");

                entity.Property(e => e.PackageWidth)
                    .HasColumnName("PACKAGE_WIDTH")
                    .HasColumnType("decimal(12, 2)");

                entity.Property(e => e.PickupCharge)
                    .HasColumnName("PICKUP_CHARGE")
                    .HasColumnType("decimal(6, 2)")
                    .HasDefaultValueSql("((0))")
                    .HasComment("Pickup Charge will update into First row only by Calculation from Stored Procedure since Pickup charge is single for one request");

                entity.Property(e => e.ProductTypeId)
                    .HasColumnName("PRODUCT_TYPE_ID")
                    .HasComment("");

                entity.Property(e => e.SlNo).HasColumnName("SL_NO");

                entity.Property(e => e.WeightUnit)
                    .HasColumnName("WEIGHT_UNIT")
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasComment("Kg / Gm");

                entity.HasOne(d => d.PackageChargeNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.PackageChargeId)
                    .HasConstraintName("FK_JCD_TEMP_CHARGES_ID_JCD_PACKAGE_WITH_WEIGHT_CHARGE");
            });

            modelBuilder.Entity<TempRequest>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("TempRequest", "dbo");

                entity.Property(e => e.TempAssignBy).HasColumnName("tempAssignBy");

                entity.Property(e => e.TempAssignDate)
                    .HasColumnName("tempAssignDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.TempAssignFor).HasColumnName("tempAssignFor");

                entity.Property(e => e.TempDhId).HasColumnName("tempDhId");

                entity.Property(e => e.TempDropPointId).HasColumnName("tempDropPointId");

                entity.Property(e => e.TempManifestId).HasColumnName("tempManifestId");

                entity.Property(e => e.TempPickupPointId).HasColumnName("tempPickupPointId");

                entity.Property(e => e.TempRequestId).HasColumnName("tempRequestId");
            });

            modelBuilder.Entity<View1>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("View_1", "dbo");

                entity.Property(e => e.DeliveryCharge)
                    .HasColumnName("DELIVERY_CHARGE")
                    .HasColumnType("decimal(6, 2)");

                entity.Property(e => e.DestinationCharge)
                    .HasColumnName("DESTINATION_CHARGE")
                    .HasColumnType("decimal(6, 2)");

                entity.Property(e => e.HandlingCharge)
                    .HasColumnName("HANDLING_CHARGE")
                    .HasColumnType("decimal(6, 2)");

                entity.Property(e => e.PackagingCharge)
                    .HasColumnName("PACKAGING_CHARGE")
                    .HasColumnType("decimal(6, 2)");

                entity.Property(e => e.PickupCharge)
                    .HasColumnName("PICKUP_CHARGE")
                    .HasColumnType("decimal(6, 2)");
            });

            modelBuilder.Entity<VwAdmnUserwiseUnitPermission>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("VW_ADMN_USERWISE_UNIT_PERMISSION", "dbo");

                entity.Property(e => e.Address)
                    .HasColumnName("ADDRESS")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.CityDist)
                    .HasColumnName("CITY_DIST")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.CompanyCode).HasColumnName("COMPANY_CODE");

                entity.Property(e => e.CompanyName)
                    .HasColumnName("COMPANY_NAME")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Country)
                    .HasColumnName("COUNTRY")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.PassHint)
                    .HasColumnName("PASS_HINT")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PostalCode)
                    .HasColumnName("POSTAL_CODE")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Salt)
                    .IsRequired()
                    .HasColumnName("SALT")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.StateProvince)
                    .HasColumnName("STATE_PROVINCE")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.UnitCode).HasColumnName("UNIT_CODE");

                entity.Property(e => e.UnitLocation)
                    .HasColumnName("UNIT_LOCATION")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UnitName)
                    .HasColumnName("UNIT_NAME")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserId).HasColumnName("USER_ID");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasColumnName("USER_NAME")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.UserPass)
                    .IsRequired()
                    .HasColumnName("USER_PASS")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Website)
                    .HasColumnName("WEBSITE")
                    .HasMaxLength(112)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<VwAllCharges>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("VW_ALL_CHARGES", "dbo");

                entity.Property(e => e.DeliveryCharge).HasColumnType("decimal(38, 2)");

                entity.Property(e => e.DeliverySlot)
                    .HasMaxLength(280)
                    .IsUnicode(false);

                entity.Property(e => e.DeliveryType)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.DestinationCharge).HasColumnType("decimal(6, 2)");

                entity.Property(e => e.Disclaimer)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.HandlingCharge).HasColumnType("decimal(38, 2)");

                entity.Property(e => e.PackageCharge).HasColumnType("decimal(38, 2)");

                entity.Property(e => e.PackagingCharge).HasColumnType("decimal(38, 2)");

                entity.Property(e => e.PickupCharge).HasColumnType("decimal(38, 2)");

                entity.Property(e => e.TotalCharge).HasColumnType("decimal(38, 2)");

                entity.Property(e => e.WrappingCharge).HasColumnType("decimal(38, 2)");
            });

            modelBuilder.Entity<VwCharges>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("VW_CHARGES", "dbo");

                entity.Property(e => e.DimensionUnit)
                    .IsRequired()
                    .HasColumnName("DIMENSION_UNIT")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.ExtraPackagingId).HasColumnName("EXTRA_PACKAGING_ID");

                entity.Property(e => e.GiftWrappingId).HasColumnName("GIFT_WRAPPING_ID");

                entity.Property(e => e.HandlingCharge)
                    .HasColumnName("HANDLING_CHARGE")
                    .HasColumnType("decimal(6, 2)");

                entity.Property(e => e.PackageCharge).HasColumnType("decimal(6, 2)");

                entity.Property(e => e.PackageChargeId).HasColumnName("PACKAGE_CHARGE_ID");

                entity.Property(e => e.PackageDetails)
                    .HasColumnName("PACKAGE_DETAILS")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PackageDimension)
                    .HasMaxLength(24)
                    .IsUnicode(false);

                entity.Property(e => e.PackageHeight)
                    .HasColumnName("PACKAGE_HEIGHT")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.PackageLength)
                    .HasColumnName("PACKAGE_LENGTH")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.PackageType)
                    .IsRequired()
                    .HasColumnName("PACKAGE_TYPE")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PackageWeight)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.PackageWeight1)
                    .HasColumnName("PACKAGE_WEIGHT")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.PackageWidth)
                    .HasColumnName("PACKAGE_WIDTH")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.PackagingCharge)
                    .HasColumnName("PACKAGING_CHARGE")
                    .HasColumnType("decimal(6, 2)");

                entity.Property(e => e.PackagingType)
                    .IsRequired()
                    .HasColumnName("PACKAGING_TYPE")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ProductTypeId).HasColumnName("PRODUCT_TYPE_ID");

                entity.Property(e => e.WeightUnit)
                    .IsRequired()
                    .HasColumnName("WEIGHT_UNIT")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.WrappingCharge)
                    .HasColumnName("WRAPPING_CHARGE")
                    .HasColumnType("decimal(6, 2)");

                entity.Property(e => e.WrappingType)
                    .IsRequired()
                    .HasColumnName("WRAPPING_TYPE")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<VwFinsChartOfAccounts>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("VW_FINS_CHART_OF_ACCOUNTS", "dbo");

                entity.Property(e => e.AccId).HasColumnName("ACC_ID");

                entity.Property(e => e.AccName)
                    .IsRequired()
                    .HasColumnName("ACC_NAME")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasColumnName("ADDRESS")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.AddressLocation)
                    .IsRequired()
                    .HasColumnName("ADDRESS_LOCATION")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CityDist)
                    .IsRequired()
                    .HasColumnName("CITY_DIST")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ContactPerson)
                    .IsRequired()
                    .HasColumnName("CONTACT_PERSON")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasColumnName("COUNTRY")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.CreditDays).HasColumnName("CREDIT_DAYS");

                entity.Property(e => e.CreditLimit)
                    .HasColumnName("CREDIT_LIMIT")
                    .HasColumnType("money");

                entity.Property(e => e.CurrencyCode)
                    .IsRequired()
                    .HasColumnName("CURRENCY_CODE")
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.CurrencyId).HasColumnName("CURRENCY_ID");

                entity.Property(e => e.CurrencyName)
                    .IsRequired()
                    .HasColumnName("CURRENCY_NAME")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Designation)
                    .IsRequired()
                    .HasColumnName("DESIGNATION")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.DetEditDate)
                    .HasColumnName("DET_EDIT_DATE")
                    .HasColumnType("date");

                entity.Property(e => e.DetEditUser).HasColumnName("DET_EDIT_USER");

                entity.Property(e => e.DiscountDays).HasColumnName("DISCOUNT_DAYS");

                entity.Property(e => e.DiscountPercentage)
                    .HasColumnName("DISCOUNT_PERCENTAGE")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("EMAIL")
                    .HasMaxLength(55)
                    .IsUnicode(false);

                entity.Property(e => e.EntryBy)
                    .IsRequired()
                    .HasColumnName("ENTRY_BY")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.EntryDate)
                    .HasColumnName("ENTRY_DATE")
                    .HasColumnType("date");

                entity.Property(e => e.EntryUser).HasColumnName("ENTRY_USER");

                entity.Property(e => e.Ext)
                    .IsRequired()
                    .HasColumnName("EXT")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Fax)
                    .IsRequired()
                    .HasColumnName("FAX")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasColumnName("GENDER")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ManualId).HasColumnName("MANUAL_ID");

                entity.Property(e => e.Mobile)
                    .IsRequired()
                    .HasColumnName("MOBILE")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Notes)
                    .IsRequired()
                    .HasColumnName("NOTES")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.OtherContacts)
                    .IsRequired()
                    .HasColumnName("OTHER_CONTACTS")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ParentAccount)
                    .HasColumnName("PARENT_ACCOUNT")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.ParentId).HasColumnName("PARENT_ID");

                entity.Property(e => e.PostalCode)
                    .IsRequired()
                    .HasColumnName("POSTAL_CODE")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Religion)
                    .IsRequired()
                    .HasColumnName("RELIGION")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SortOrder).HasColumnName("SORT_ORDER");

                entity.Property(e => e.StateProvince)
                    .IsRequired()
                    .HasColumnName("STATE_PROVINCE")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Status).HasColumnName("STATUS");

                entity.Property(e => e.SysDefine).HasColumnName("SYS_DEFINE");

                entity.Property(e => e.Telephone)
                    .IsRequired()
                    .HasColumnName("TELEPHONE")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TermsAndCondition)
                    .IsRequired()
                    .HasColumnName("TERMS_AND_CONDITION")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.UnitCode).HasColumnName("UNIT_CODE");

                entity.Property(e => e.UserName)
                    .HasColumnName("USER_NAME")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Website)
                    .IsRequired()
                    .HasColumnName("WEBSITE")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<VwFinsVoucherDet>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("VW_FINS_VOUCHER_DET", "dbo");

                entity.Property(e => e.AccountName)
                    .HasColumnName("ACCOUNT_NAME")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.AccountNo)
                    .HasColumnName("ACCOUNT_NO")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasColumnName("ADDRESS")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.ApproveBy).HasColumnName("APPROVE_BY");

                entity.Property(e => e.ApproveDate)
                    .HasColumnName("APPROVE_DATE")
                    .HasColumnType("date");

                entity.Property(e => e.ApproveUserName)
                    .IsRequired()
                    .HasColumnName("APPROVE_USER_NAME")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.BankName)
                    .HasColumnName("BANK_NAME")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BranchName)
                    .HasColumnName("BRANCH_NAME")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.ChqAmountFc)
                    .HasColumnName("CHQ_AMOUNT_FC")
                    .HasColumnType("money");

                entity.Property(e => e.ChqAmountLocal)
                    .HasColumnName("CHQ_AMOUNT_LOCAL")
                    .HasColumnType("money");

                entity.Property(e => e.CityDist)
                    .IsRequired()
                    .HasColumnName("CITY_DIST")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CompanyCode).HasColumnName("COMPANY_CODE");

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasColumnName("COUNTRY")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.CrFc)
                    .HasColumnName("CR_FC")
                    .HasColumnType("money");

                entity.Property(e => e.CrLocal)
                    .HasColumnName("CR_LOCAL")
                    .HasColumnType("money");

                entity.Property(e => e.CurrencyCode)
                    .IsRequired()
                    .HasColumnName("CURRENCY_CODE")
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.CurrencyId).HasColumnName("CURRENCY_ID");

                entity.Property(e => e.DeptId).HasColumnName("DEPT_ID");

                entity.Property(e => e.DeptName)
                    .IsRequired()
                    .HasColumnName("DEPT_NAME")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.DeptShortName)
                    .IsRequired()
                    .HasColumnName("DEPT_SHORT_NAME")
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.DishonoredStatus).HasColumnName("DISHONORED_STATUS");

                entity.Property(e => e.DrFc)
                    .HasColumnName("DR_FC")
                    .HasColumnType("money");

                entity.Property(e => e.DrLocal)
                    .HasColumnName("DR_LOCAL")
                    .HasColumnType("money");

                entity.Property(e => e.EditDate)
                    .HasColumnName("EDIT_DATE")
                    .HasColumnType("date");

                entity.Property(e => e.EditUser).HasColumnName("EDIT_USER");

                entity.Property(e => e.EditUserName)
                    .IsRequired()
                    .HasColumnName("EDIT_USER_NAME")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.EndDate)
                    .HasColumnName("END_DATE")
                    .HasColumnType("date");

                entity.Property(e => e.EntryDate)
                    .HasColumnName("ENTRY_DATE")
                    .HasColumnType("date");

                entity.Property(e => e.EntryUser).HasColumnName("ENTRY_USER");

                entity.Property(e => e.ExchangeRate)
                    .HasColumnName("EXCHANGE_RATE")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.FiscalId).HasColumnName("FISCAL_ID");

                entity.Property(e => e.FiscalYear)
                    .IsRequired()
                    .HasColumnName("FISCAL_YEAR")
                    .HasMaxLength(9)
                    .IsUnicode(false);

                entity.Property(e => e.InstrumentDate)
                    .HasColumnName("INSTRUMENT_DATE")
                    .HasColumnType("date");

                entity.Property(e => e.InstrumentNo)
                    .HasColumnName("INSTRUMENT_NO")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.InstrumentStatus).HasColumnName("INSTRUMENT_STATUS");

                entity.Property(e => e.InstrumentType).HasColumnName("INSTRUMENT_TYPE");

                entity.Property(e => e.LedgerId).HasColumnName("LEDGER_ID");

                entity.Property(e => e.LedgerName)
                    .IsRequired()
                    .HasColumnName("LEDGER_NAME")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.ManualId).HasColumnName("MANUAL_ID");

                entity.Property(e => e.NameInInstrument)
                    .HasColumnName("NAME_IN_INSTRUMENT")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.ParentAccount)
                    .HasColumnName("PARENT_ACCOUNT")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.ParentId).HasColumnName("PARENT_ID");

                entity.Property(e => e.Particulars)
                    .HasColumnName("PARTICULARS")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.PostalCode)
                    .IsRequired()
                    .HasColumnName("POSTAL_CODE")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SlNo).HasColumnName("SL_NO");

                entity.Property(e => e.StartDate)
                    .HasColumnName("START_DATE")
                    .HasColumnType("date");

                entity.Property(e => e.StateProvince)
                    .IsRequired()
                    .HasColumnName("STATE_PROVINCE")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.SysVrno).HasColumnName("SYS_VRNO");

                entity.Property(e => e.TranDate)
                    .HasColumnName("TRAN_DATE")
                    .HasColumnType("date");

                entity.Property(e => e.UnitCode).HasColumnName("UNIT_CODE");

                entity.Property(e => e.UnitName)
                    .IsRequired()
                    .HasColumnName("UNIT_NAME")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasColumnName("USER_NAME")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.UserVrno)
                    .IsRequired()
                    .HasColumnName("USER_VRNO")
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.VrStatus).HasColumnName("VR_STATUS");

                entity.Property(e => e.VrType).HasColumnName("VR_TYPE");
            });

            //Custom Declaration
            modelBuilder.Entity<UserRequestInfo>().HasNoKey();
            modelBuilder.Entity<DhAssignmentResponseInfo>().HasNoKey();
            modelBuilder.Entity<AreaInfo>().HasNoKey();
            modelBuilder.Entity<CalculateChargeDetails>().HasNoKey();
            modelBuilder.Entity<PacakgeChargeJson>().HasNoKey();
            modelBuilder.Entity<ProductDetailsInfo>().HasNoKey();
            modelBuilder.Entity<AddressModel>().HasNoKey();
            modelBuilder.Entity<AddressAreaModel>().HasNoKey();
            modelBuilder.Entity<CountryInfo>().HasNoKey();
            modelBuilder.Entity<CityDistrictInfo>().HasNoKey();
            modelBuilder.Entity<DeliveryHeroInfo>().HasNoKey();
            modelBuilder.Entity<DeliveryHero>().HasNoKey();
            modelBuilder.Entity<CountryDetails>().HasNoKey();
            modelBuilder.Entity<ProvinceDetails>().HasNoKey();
            modelBuilder.Entity<CityDistrictDetails>().HasNoKey();
            modelBuilder.Entity<UpazillaDetails>().HasNoKey();
            modelBuilder.Entity<AreaDetails>().HasNoKey();
            modelBuilder.Entity<RequestListForAssignment>().HasNoKey();
            modelBuilder.Entity<ExtraPackagingTypeInfo>().HasNoKey(); ;
            modelBuilder.Entity<ProductTypeInfo>().HasNoKey();
            modelBuilder.Entity<PackageWithChargeInfo>().HasNoKey();
            modelBuilder.Entity<DeliveryTimeSlotsInfo>().HasNoKey();
            modelBuilder.Entity<PickupAndDeliveryChargeInfo>().HasNoKey();
            modelBuilder.Entity<AtcPoints>().HasNoKey();
            modelBuilder.Entity<NotificationSmsInfo>().HasNoKey();
            modelBuilder.Entity<NotificationMesasge>().HasNoKey();
            modelBuilder.Entity<ManifestInfo>().HasNoKey();
            modelBuilder.Entity<AssignmentInfoForNotificationModel>().HasNoKey();
            modelBuilder.Entity<PickupAndDeliveryTimePeriodInfo>().HasNoKey();
            modelBuilder.Entity<CourierBannerInfoResponseModel>().HasNoKey();
            modelBuilder.Entity<SenderDetailsResponseModel>().HasNoKey();
            modelBuilder.Entity<TrackingDetails>().HasNoKey();

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
