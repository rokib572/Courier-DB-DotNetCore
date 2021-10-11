using System;
using System.Collections.Generic;

namespace Japax_Courier_DB.DBModels.Courier
{
    public partial class JcdDeliveryHeroEdu
    {
        public long Id { get; set; }
        public long DhId { get; set; }
        public string AcademicOrganization { get; set; }
        public string QualificationName { get; set; }
        public string FieldOfStudy { get; set; }
        public string Gpa { get; set; }
        public string EducationYear { get; set; }
        public int UserId { get; set; }
        public DateTime? SetDate { get; set; }

        public virtual JcdDeliveryHeroInfo Dh { get; set; }
        public virtual AdmnUserInfo User { get; set; }
    }
}
