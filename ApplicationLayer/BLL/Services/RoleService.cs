using AutoMapper;
using BLL.DTOS;
using DAL;
using DAL.EF.Models;
using System.Collections.Generic;

namespace BLL.Services
{
    public class RoleService
    {
        public static RoleDTO Create(RoleDTO dto)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<RoleDTO, Role>();
            });

            var mapper = new Mapper(config);
            var data = mapper.Map<Role>(dto);

            var nameCheck = DataAccessFactory.RoleData().Name(dto.RoleName);
            if (nameCheck == null)
            {
                DataAccessFactory.RoleData().Create(data);
                return dto;
            }
            else
            {
                return null;
            }
        }

        public static RoleDTO GetRole(int id)
        {
            var data = DataAccessFactory.RoleData().Get(id);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Role, RoleDTO>();
            });
            var mapper = new Mapper(config);
            var value = mapper.Map<RoleDTO>(data);
            return value;
        }

        public static List<RoleUserDTO> GetAll()
        {
            var data = DataAccessFactory.RoleData().GetAll();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, UserDTO>();
                cfg.CreateMap<Role, RoleUserDTO>();
            });
            var mapper = new Mapper(config);
            var value = mapper.Map<List<RoleUserDTO>>(data);
            return value;
        }

        public static bool Update(RoleDTO dto)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<RoleDTO, Role>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<Role>(dto);

            var data2 = DataAccessFactory.RoleData().Get(data.Id);
            if (data2 == null)
            {
                return false;
            }
            DataAccessFactory.RoleData().Update(data);
            return true;
        }

        public static bool Delete(int id)
        {
            var data = DataAccessFactory.RoleData().Get(id);

            if (data != null)
            {
                DataAccessFactory.RoleData().Delete(id);
                return true;
            }
            else
            {
                return false;
            }
        }


    }
}
