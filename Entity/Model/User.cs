using System;
using Entity.Model.Base;


namespace Entity.Model
{
    public class User : GenericModel
    {
        public string? Username { get; set; }
        public string? Email  { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string? Password { get; set; }
    }
}