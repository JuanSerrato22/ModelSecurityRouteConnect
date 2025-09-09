using System;
using Entity.Model.Base;


namespace Entity.Model
{
    public class Person : GenericModel
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int Document { get; set; }
        public long PhoneNumber { get; set; }
        public string? Email { get; set; }

    }
}