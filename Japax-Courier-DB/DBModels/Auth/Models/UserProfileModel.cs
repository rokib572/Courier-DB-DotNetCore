using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Japax_Courier_DB.DBModels.CommonModels.Response;

namespace Japax_Courier_DB.DBModels.Auth.Models
{
    public class UserProfileModel
    {
        [Required(ErrorMessage = "{0} is required")]
        public string Status { get; set; }
        public string UserEmail { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public string ProfilePicture { get; set; }
        public DateTime? RegistrationDate { get; set; }
        public byte? ActiveStatus { get; set; }
        public byte CourierApp { get; set; }
        public byte RideshareApp { get; set; }
        public byte? SenderType { get; set; }
        public ErrorModel Error { get; set; }
    }
}
