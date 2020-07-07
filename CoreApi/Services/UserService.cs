using CoreApi.Domain;
using CoreApi.Domain.Repositories;
using CoreApi.Domain.Response;
using CoreApi.Domain.Service;
using CoreApi.Domain.UnitOfWork;
using System;

namespace CoreApi.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;

        private readonly IUnitOfWork unitOfWork;

        public UserService(IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            this.userRepository = userRepository;

            this.unitOfWork = unitOfWork;
        }

        public BaseResponse<User> AddUser(User user)
        {
            try
            {
                userRepository.AddUser(user);

                unitOfWork.Complete();

                return new BaseResponse<User>(user);
            }
            catch (Exception Ex)
            {
                return new BaseResponse<User>($"Kullanıcı eklenirken hata meydana geldi::{Ex.Message}");
            }
        }

        public BaseResponse<User> FindById(int userId)
        {
            try
            {
                User user = userRepository.FindById(userId);

                if (user == null)
                {
                    return new BaseResponse<User>("Kullanıcı bulunamadı!");
                }

                return new BaseResponse<User>(user);
            }
            catch (Exception Ex)
            {
                return new BaseResponse<User>($"Kullanıcı bulunurken hata meydana geldi::{Ex.Message}");
            }
        }

        public BaseResponse<User> FindEmailAndPassword(string email, string password)
        {
            try
            {
                User user = userRepository.FindByEmailAndPassword(email, password);

                if (user == null)
                {
                    return new BaseResponse<User>("Kullanıcı bulunamadı!");
                }

                return new BaseResponse<User>(user);
            }
            catch (Exception Ex)
            {
                return new BaseResponse<User>($"Kullanıcı bulunurken hata meydana geldi::{Ex.Message}");
            }
        }

        public BaseResponse<User> GetUserWithRefreshToken(string refreshToken)
        {
            try
            {
                User user = userRepository.GetUserWithRefreshToken(refreshToken);

                if (user == null)
                {
                    return new BaseResponse<User>("Kullanıcı bulunamadı!");
                }

                return new BaseResponse<User>(user);
            }
            catch (Exception Ex)
            {
                return new BaseResponse<User>($"Kullanıcı bulunurken hata meydana geldi::{Ex.Message}");
            }
        }

        public void RemoveRefreshToken(User user)
        {
            try
            {
                userRepository.RemoveRefreshToken(user);

                unitOfWork.Complete();
            }
            catch (Exception)
            {
                // Log
            }
        }

        public void SaveRefreshToken(int userId, string refreshToken)
        {
            try
            {
                userRepository.SaveRefreshToken(userId, refreshToken);

                unitOfWork.Complete();
            }
            catch (Exception)
            {
                // Log
            }
        }
    }
}
