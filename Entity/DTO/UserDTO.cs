using System;
using Entity.Model.Base;


namespace Entity.DTO
{
    public class UserDTO : BaseEntity
    {
        public required string Username { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }

    }
}