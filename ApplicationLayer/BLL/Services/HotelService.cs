using AutoMapper;
using BLL.DTOS;
using DAL;
using DAL.EF.Models;
using System.Collections.Generic;

namespace BLL.Services
{
    public class HotelService
    {
        public static HotelDTO Create(HotelDTO dto)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<HotelDTO, Hotel>();
            });

            var mapper = new Mapper(config);
            var data = mapper.Map<Hotel>(dto);

            var nameCheck = DataAccessFactory.HotelData().Name(dto.HotelName);
            if (nameCheck == null)
            {
                DataAccessFactory.HotelData().Create(data);
                return dto;
            }
            else
            {
                return null;
            }
        }

        public static HotelDTO GetHotel(int id)
        {
            var data = DataAccessFactory.HotelData().Get(id);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Hotel, HotelDTO>();
            });
            var mapper = new Mapper(config);
            var value = mapper.Map<HotelDTO>(data);
            return value;
        }

        public static List<HotelDTO> GetAllHotels()
        {
            var data = DataAccessFactory.HotelData().GetAll();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Hotel, HotelDTO>();
            });
            var mapper = new Mapper(config);
            var value = mapper.Map<List<HotelDTO>>(data);
            return value;
        }

        public static bool UpdateHotel(HotelDTO dto)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<HotelDTO, Hotel>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<Hotel>(dto);

            var updatedHotel = DataAccessFactory.HotelData().Update(data);

            return updatedHotel != null;
        }

        public static bool DeleteHotel(int id)
        {
            var data = DataAccessFactory.HotelData().Get(id);
            if (data != null)
            {
                var deletedHotel = DataAccessFactory.HotelData().Delete(id);
                return deletedHotel != null;
            }
            else
            {
                return false;
            }
        }

    }
}
