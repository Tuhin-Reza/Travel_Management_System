using AutoMapper;
using BLL.DTOS;
using DAL;
using DAL.EF.Models;
using System.Collections.Generic;

namespace BLL.Services
{
    public class PropertyTypeService
    {
        public static PropertyTypeDTO Create(PropertyTypeDTO dto)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<PropertyTypeDTO, PropertyType>();
            });

            var mapper = new Mapper(config);
            var data = mapper.Map<PropertyType>(dto);

            var nameCheck = DataAccessFactory.PropertyTypeData().Name(dto.TypeName);
            if (nameCheck == null)
            {
                DataAccessFactory.PropertyTypeData().Create(data);
                return dto;
            }
            else
            {
                return null;
            }
        }

        public static PropertyTypeDTO GetPropertyType(int id)
        {
            var data = DataAccessFactory.PropertyTypeData().Get(id);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<PropertyType, PropertyTypeDTO>();
            });
            var mapper = new Mapper(config);
            var value = mapper.Map<PropertyTypeDTO>(data);
            return value;
        }

        //public static List<PropertyTypePropertyDTO> GetAll()
        //{
        //    var data = DataAccessFactory.PropertyTypeData().GetAll();
        //    var config = new MapperConfiguration(cfg =>
        //    {
        //        cfg.CreateMap<Property, PropertyDTO>();
        //        cfg.CreateMap<PropertyType, PropertyTypeDTO>();
        //    });
        //    var mapper = new Mapper(config);
        //    var value = mapper.Map<List<PropertyTypePropertyDTO>>(data);
        //    return value;
        //}

        public static List<PropertyTypeDTO> GetAll()
        {
            var data = DataAccessFactory.PropertyTypeData().GetAll();
            var config = new MapperConfiguration(cfg =>
            {

                cfg.CreateMap<PropertyType, PropertyTypeDTO>();
            });
            var mapper = new Mapper(config);
            var value = mapper.Map<List<PropertyTypeDTO>>(data);
            return value;
        }
        public static bool Update(PropertyTypeDTO dto)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<PropertyTypeDTO, PropertyType>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<PropertyType>(dto);

            var updatedPropertyType = DataAccessFactory.PropertyTypeData().Update(data);

            return updatedPropertyType != null;
        }

        public static bool Delete(int id)
        {
            var data = DataAccessFactory.PropertyTypeData().Get(id);
            if (data != null)
            {
                var deletedPropertyType = DataAccessFactory.PropertyTypeData().Delete(id);
                return deletedPropertyType != null;
            }
            else
            {
                return false;
            }
        }


    }
}
