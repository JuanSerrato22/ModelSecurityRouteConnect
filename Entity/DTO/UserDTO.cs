using System;
using Entity.Model.Base;


namespace Entity.DTO
{
    public class UserDTO
    {
        public int Id { get; set; }
        public required string Username { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }

    }
}