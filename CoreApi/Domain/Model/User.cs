using System;

namespace CoreApi.Domain
{
    public partial class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string RefreshToken { get; set; }
        public DateTime? RefreshTokenExpiredDate { get; set; }
    }
}
