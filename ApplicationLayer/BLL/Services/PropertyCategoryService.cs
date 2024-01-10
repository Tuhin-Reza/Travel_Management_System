using AutoMapper;
using BLL.DTOS;
using DAL;
using DAL.EF.Models;
using System.Collections.Generic;

namespace BLL.Services
{
    public class PropertyCategoryService
    {
        public static PropertyCategoryDTO Create(PropertyCategoryDTO dto)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<PropertyCategoryDTO, PropertyCategory>();
            });

            var mapper = new Mapper(config);
            var data = mapper.Map<PropertyCategory>(dto);

            if (data != null)
            {

                var nameCheck = DataAccessFactory.PropertyCategoryData().Name(dto.CategoryName);
                if (nameCheck == null)
                {
                    DataAccessFactory.PropertyCategoryData().Create(data);
                    return dto;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        public static PropertyCategoryDTO GetPropertyCategory(int id)
        {
            var data = DataAccessFactory.PropertyCategoryData().Get(id);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<PropertyCategory, PropertyCategoryDTO>();
            });
            var mapper = new Mapper(config);
            var value = mapper.Map<PropertyCategoryDTO>(data);
            return value;
        }

        public static List<PropertyCategoryDTO> GetAllPropertyCategories()
        {
            var data = DataAccessFactory.PropertyCategoryData().GetAll();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Property, PropertyDTO>();
                cfg.CreateMap<PropertyCategory, PropertyCategoryDTO>();
            });
            var mapper = new Mapper(config);
            var value = mapper.Map<List<PropertyCategoryDTO>>(data);
            return value;
        }

        public static bool Update(PropertyCategoryDTO dto)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<PropertyCategoryDTO, PropertyCategory>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<PropertyCategory>(dto);

            var updatedPropertyCategory = DataAccessFactory.PropertyCategoryData().Update(data);

            return updatedPropertyCategory != null;
        }

        public static bool DeletePropertyCategory(int id)
        {
            var data = DataAccessFactory.PropertyCategoryData().Get(id);
            if (data != null)
            {
                var deletedPropertyCategory = DataAccessFactory.PropertyCategoryData().Delete(id);
                return deletedPropertyCategory != null;
            }
            else
            {
                return false;
            }
        }

    }
}
