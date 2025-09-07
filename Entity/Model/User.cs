using System;
using Entity.Model.Base;


namespace Entity.Model
{
    public class User : BaseEntity
    {
        public required string Username { get; set; }
        public required string Email  { get; set; }
        public DateTime RegistrationDate { get; set; }
        public required string Password { get; set; }
    }
}