using System;
using Entity.Model.Base;


namespace Entity.Model
{
    public class Person : BaseEntity
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public int Document { get; set; }
        public int PhoneNumber { get; set; }
        public required string Email { get; set; }
   }
}