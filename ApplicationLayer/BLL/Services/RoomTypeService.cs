using AutoMapper;
using BLL.DTOS;
using DAL;
using DAL.EF.Models;
using System.Collections.Generic;

namespace BLL.Services
{
    public class RoomTypeService
    {
        public static RoomTypeDTO Create(RoomTypeDTO dto)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<RoomTypeDTO, RoomType>();
            });

            var mapper = new Mapper(config);
            var data = mapper.Map<RoomType>(dto);

            var nameCheck = DataAccessFactory.RoomTypeData().Name(data.RoomTypeName);
            if (nameCheck == null)
            {
                DataAccessFactory.RoomTypeData().Create(data);
                return dto;
            }
            else
            {
                return null;
            }
        }


        public static RoomTypeDTO GetRoomType(int id)
        {
            var data = DataAccessFactory.RoomTypeData().Get(id);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<RoomType, RoomTypeDTO>();
            });
            var mapper = new Mapper(config);
            var value = mapper.Map<RoomTypeDTO>(data);
            return value;
        }

        public static List<RoomTypeDTO> GetAllRoomTypes()
        {
            var data = DataAccessFactory.RoomTypeData().GetAll();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<RoomType, RoomTypeDTO>();
            });
            var mapper = new Mapper(config);
            var value = mapper.Map<List<RoomTypeDTO>>(data);
            return value;
        }

        public static bool UpdateRoomType(RoomTypeDTO dto)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<RoomTypeDTO, RoomType>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<RoomType>(dto);

            var updatedRoomType = DataAccessFactory.RoomTypeData().Update(data);

            return updatedRoomType != null;
        }

        public static bool DeleteRoomType(int id)
        {
            var data = DataAccessFactory.RoomTypeData().Get(id);
            if (data != null)
            {
                var deletedRoomType = DataAccessFactory.RoomTypeData().Delete(id);
                return deletedRoomType != null;
            }
            else
            {
                return false;
            }
        }

    }
}
