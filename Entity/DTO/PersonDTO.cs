using System;
using Entity.Model.Base;


namespace Entity.DTO
{
    public class PersonDTO
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int Document { get; set; }
        public long PhoneNumber { get; set; }
        public string? Email { get; set; }
    }
}