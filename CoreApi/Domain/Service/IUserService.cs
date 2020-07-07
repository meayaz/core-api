using CoreApi.Domain.Response;

namespace CoreApi.Domain.Service
{
    public interface IUserService
    {
        BaseResponse<User> AddUser(User user);

        BaseResponse<User> FindById(int userId);

        BaseResponse<User> FindEmailAndPassword(string email, string password);

        void SaveRefreshToken(int userId, string refreshToken);

        BaseResponse<User> GetUserWithRefreshToken(string refreshToken);

        void RemoveRefreshToken(User user);
    }
}