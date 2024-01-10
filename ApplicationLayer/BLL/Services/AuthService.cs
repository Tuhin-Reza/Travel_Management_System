using AutoMapper;
using BLL.DTOS;
using DAL;
using DAL.EF.Models;
using System;

namespace BLL.Services
{
    public class AuthService
    {
        public static TokenDTO Login(UserDTO dto)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<UserDTO, User>();
            });

            var mapper = new Mapper(config);
            var data = mapper.Map<User>(dto);
            var res = DataAccessFactory.UserLoginData().Auth(data);

            if (res.Id != null)
            {
                var tokenData = DataAccessFactory.TokenData().Get(res.Id);
                if (tokenData.Expired == null)
                {
                    var token = new Token();
                    token.TKey = Guid.NewGuid().ToString();
                    token.Created = DateTime.Now;
                    token.UserId = res.Id;
                    DataAccessFactory.TokenData().Create(token);
                }
                if (tokenData != null)
                {
                    var cfg = new MapperConfiguration(c =>
                    {
                        c.CreateMap<Token, TokenDTO>();
                    });
                    var mapper2 = new Mapper(cfg);
                    return mapper.Map<TokenDTO>(tokenData);
                }

            }
            return null;
        }
    }
}
