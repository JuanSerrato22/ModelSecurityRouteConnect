using System;
using Entity.Model.Base;


namespace Entity.DTO
{
    public class PersonDTO : BaseEntity
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int Document { get; set; }
        public int PhoneNumber { get; set; }
        public string? Email { get; set; }
    }
}