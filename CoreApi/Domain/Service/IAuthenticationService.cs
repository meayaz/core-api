using CoreApi.Domain.Response;
using CoreApi.Security.Token;

namespace CoreApi.Domain.Service
{
    public interface IAuthenticationService
    {
        BaseResponse<AccessToken> CreateAccessToken(string email, string password);

        BaseResponse<AccessToken> CreateAccessTokenByRefreshToken(string refreshToken);

        BaseResponse<AccessToken> RevokeRefreshToken(string refreshToken);
    }
}