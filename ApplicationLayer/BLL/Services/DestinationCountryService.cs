using AutoMapper;
using BLL.DTOS;
using DAL;
using DAL.EF.Models;
using System.Collections.Generic;

namespace BLL.Services
{
    public class DestinationCountryService
    {
        public static DestinationCountryDTO Create(DestinationCountryDTO dto)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<DestinationCountryDTO, DestinationCountry>();
            });

            var mapper = new Mapper(config);
            var data = mapper.Map<DestinationCountry>(dto);

            var nameCheck = DataAccessFactory.DestinationCountryData().Name(dto.CountryName);
            if (nameCheck == null)
            {
                DataAccessFactory.DestinationCountryData().Create(data);
                return dto;
            }
            else
            {
                return null;
            }
        }

        public static DestinationCountryDTO GetDestinationCountry(int id)
        {
            var data = DataAccessFactory.DestinationCountryData().Get(id);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<DestinationCountry, DestinationCountryDTO>();
            });
            var mapper = new Mapper(config);
            var value = mapper.Map<DestinationCountryDTO>(data);
            return value;
        }

        public static List<DestinationCountryDTO> GetAll()
        {
            var data = DataAccessFactory.DestinationCountryData().GetAll();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<DestinationCountry, DestinationCountryDTO>();
            });
            var mapper = new Mapper(config);
            var value = mapper.Map<List<DestinationCountryDTO>>(data);
            return value;
        }

        public static bool Update(DestinationCountryDTO dto)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<DestinationCountryDTO, DestinationCountry>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<DestinationCountry>(dto);

            var updatedDestinationCountry = DataAccessFactory.DestinationCountryData().Update(data);

            return updatedDestinationCountry != null;
        }

        public static bool Delete(int id)
        {
            var data = DataAccessFactory.DestinationCountryData().Get(id);
            if (data != null)
            {
                var deletedDestinationCountry = DataAccessFactory.DestinationCountryData().Delete(id);
                return deletedDestinationCountry != null;
            }
            else
            {
                return false;
            }
        }
    }
}
