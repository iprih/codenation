using System;
using System.ComponentModel.DataAnnotations;

namespace Codenation.Challenge.DTOs
{
    public class UserDTO
    {
        public int Id { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Nickname { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }
    }
}