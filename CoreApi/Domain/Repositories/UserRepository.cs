using CoreApi.Security.Token;
using Microsoft.Extensions.Options;
using System;
using System.Linq;

namespace CoreApi.Domain.Repositories
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        private readonly TokenOptions tokenOptions;
        public UserRepository(ShoppingContext context, IOptions<TokenOptions> tokenOptions) : base(context)
        {
            this.tokenOptions = tokenOptions.Value;
        }

        public void AddUser(User user)
        {
            context.User.Add(user);
        }

        public User FindByEmailAndPassword(string email, string password)
        {
            return context.User.Where(u => u.Email == email && u.Password == password).FirstOrDefault();
        }

        public User FindById(int userId)
        {
            return context.User.Find(userId);
        }

        public User GetUserWithRefreshToken(string refreshToken)
        {
            return context.User.FirstOrDefault(a => a.RefreshToken == refreshToken);
        }

        public void RemoveRefreshToken(User user)
        {
            User newUser = FindById(user.Id);

            newUser.RefreshToken = null;

            newUser.RefreshTokenExpiredDate = null;
        }

        public void SaveRefreshToken(int userId, string refreshToken)
        {
            User newUser = FindById(userId);

            newUser.RefreshToken = refreshToken;

            newUser.RefreshTokenExpiredDate = DateTime.Now.AddDays(tokenOptions.RefreshTokenExpiration);
        }
    }
}
