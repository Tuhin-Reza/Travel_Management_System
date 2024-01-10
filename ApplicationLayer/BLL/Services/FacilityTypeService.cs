using AutoMapper;
using BLL.DTOS;
using DAL;
using DAL.EF.Models;
using System.Collections.Generic;

namespace BLL.Services
{
    public class FacilityTypeService
    {

        public static FacilityTypeDTO Create(FacilityTypeDTO dto)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<FacilityTypeDTO, FacilityType>();
            });

            var mapper = new Mapper(config);
            var data = mapper.Map<FacilityType>(dto);

            var nameCheck = DataAccessFactory.FacilityTypeData().Name(dto.FacilityName);
            if (nameCheck == null)
            {
                DataAccessFactory.FacilityTypeData().Create(data);
                return dto;
            }
            else
            {
                return null;
            }
        }

        public static FacilityTypeDTO GetFacilityType(int id)
        {
            var data = DataAccessFactory.FacilityTypeData().Get(id);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<FacilityType, FacilityTypeDTO>();
            });
            var mapper = new Mapper(config);
            var value = mapper.Map<FacilityTypeDTO>(data);
            return value;
        }

        public static List<FacilityTypeDTO> GetAll()
        {
            var data = DataAccessFactory.FacilityTypeData().GetAll();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<FacilityType, FacilityTypeDTO>();
            });
            var mapper = new Mapper(config);
            var value = mapper.Map<List<FacilityTypeDTO>>(data);
            return value;
        }

        public static bool Update(FacilityTypeDTO dto)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<FacilityTypeDTO, FacilityType>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<FacilityType>(dto);

            var updatedFacilityType = DataAccessFactory.FacilityTypeData().Update(data);

            return updatedFacilityType != null;
        }

        public static bool Delete(int id)
        {
            var data = DataAccessFactory.FacilityTypeData().Get(id);
            if (data != null)
            {
                var deletedFacilityType = DataAccessFactory.FacilityTypeData().Delete(id);
                return deletedFacilityType != null;
            }
            else
            {
                return false;
            }
        }
    }

}
