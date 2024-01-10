using AutoMapper;
using BLL.DTOS;
using DAL;
using DAL.EF.Models;
using System.Collections.Generic;

namespace BLL.Services
{
    public class DestinationCountryCityService
    {
        public static DestinationCountryCityDTO Create(DestinationCountryCityDTO dto)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<DestinationCountryCityDTO, DestinationCountryCity>();
            });

            var mapper = new Mapper(config);
            var data = mapper.Map<DestinationCountryCity>(dto);

            var checkCity = DataAccessFactory.DestinationCountryCityData().CheckCity(data);
            if (checkCity == null)
            {
                DataAccessFactory.DestinationCountryCityData().Create(data);
                return dto;
            }
            else
            {
                return null;
            }
        }

        public static DestinationCountryCityDTO GetDestinationCountryCity(int id)
        {
            var data = DataAccessFactory.DestinationCountryCityData().Get(id);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<DestinationCountryCity, DestinationCountryCityDTO>();
            });
            var mapper = new Mapper(config);
            var value = mapper.Map<DestinationCountryCityDTO>(data);
            return value;
        }

        public static List<DestinationCountryCityDTO> GetAll()
        {
            var data = DataAccessFactory.DestinationCountryCityData().GetAll();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<DestinationCountryCity, DestinationCountryCityDTO>();
            });
            var mapper = new Mapper(config);
            var value = mapper.Map<List<DestinationCountryCityDTO>>(data);
            return value;
        }

        public static bool Update(DestinationCountryCityDTO dto)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<DestinationCountryCityDTO, DestinationCountryCity>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<DestinationCountryCity>(dto);

            var updatedDestinationCountryCity = DataAccessFactory.DestinationCountryCityData().Update(data);

            return updatedDestinationCountryCity != null;
        }

        public static bool Delete(int id)
        {
            var data = DataAccessFactory.DestinationCountryCityData().Get(id);
            if (data != null)
            {
                var deletedDestinationCountryCity = DataAccessFactory.DestinationCountryCityData().Delete(id);
                return deletedDestinationCountryCity != null;
            }
            else
            {
                return false;
            }
        }
    }

}
