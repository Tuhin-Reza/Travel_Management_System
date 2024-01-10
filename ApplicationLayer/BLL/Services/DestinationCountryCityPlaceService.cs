using AutoMapper;
using BLL.DTOS;
using DAL;
using DAL.EF.Models;
using System.Collections.Generic;

namespace BLL.Services
{
    public class DestinationCountryCityPlaceService
    {
        public static DestinationCountryCityPlaceDTO Create(DestinationCountryCityPlaceDTO dto)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<DestinationCountryCityPlaceDTO, DestinationCountryCityPlace>();
            });

            var mapper = new Mapper(config);
            var data = mapper.Map<DestinationCountryCityPlace>(dto);

            var nameCheck = DataAccessFactory.DestinationCountryCityPlaceData().CheckCityPlace(data);
            if (nameCheck == null)
            {
                DataAccessFactory.DestinationCountryCityPlaceData().Create(data);
                return dto;
            }
            else
            {
                return null;
            }
        }

        public static DestinationCountryCityPlaceDTO GetDestinationCountryCityPlace(int id)
        {
            var data = DataAccessFactory.DestinationCountryCityPlaceData().Get(id);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<DestinationCountryCityPlace, DestinationCountryCityPlaceDTO>();
            });
            var mapper = new Mapper(config);
            var value = mapper.Map<DestinationCountryCityPlaceDTO>(data);
            return value;
        }

        public static List<DestinationCountryCityPlaceDTO> GetAllDestinationCountryCityPlaces()
        {
            var data = DataAccessFactory.DestinationCountryCityPlaceData().GetAll();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<DestinationCountryCityPlace, DestinationCountryCityPlaceDTO>();
            });
            var mapper = new Mapper(config);
            var value = mapper.Map<List<DestinationCountryCityPlaceDTO>>(data);
            return value;
        }

        public static bool Update(DestinationCountryCityPlaceDTO dto)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<DestinationCountryCityPlaceDTO, DestinationCountryCityPlace>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<DestinationCountryCityPlace>(dto);

            var updatedDestinationCountryCityPlace = DataAccessFactory.DestinationCountryCityPlaceData().Update(data);

            return updatedDestinationCountryCityPlace != null;
        }

        public static bool DeleteDestinationCountryCityPlace(int id)
        {
            var data = DataAccessFactory.DestinationCountryCityPlaceData().Get(id);
            if (data != null)
            {
                var deletedDestinationCountryCityPlace = DataAccessFactory.DestinationCountryCityPlaceData().Delete(id);
                return deletedDestinationCountryCityPlace != null;
            }
            else
            {
                return false;
            }
        }

    }
}
