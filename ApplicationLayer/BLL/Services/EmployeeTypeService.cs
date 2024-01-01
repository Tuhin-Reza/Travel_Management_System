using AutoMapper;
using BLL.DTOS;
using DAL;
using DAL.EF.Models;
using System.Collections.Generic;

namespace BLL.Services
{
    public class EmployeeTypeService
    {
        public static EmployeeTypeDTO Create(EmployeeTypeDTO dto)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<EmployeeTypeDTO, EmployeeType>();
            });

            var mapper = new Mapper(config);
            var data = mapper.Map<EmployeeType>(dto);

            var nameCheck = DataAccessFactory.EmployeeTypeData().Name(dto.EmployeeTypeName);
            if (nameCheck == null)
            {
                DataAccessFactory.EmployeeTypeData().Create(data);
                return dto;
            }
            else
            {
                return null;
            }

        }

        public static EmployeeTypeDTO GetEmployeeType(int id)
        {
            var data = DataAccessFactory.EmployeeTypeData().Get(id);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<EmployeeType, EmployeeTypeDTO>();
            });
            var mapper = new Mapper(config);
            var value = mapper.Map<EmployeeTypeDTO>(data);
            return value;
        }

        public static List<EmployeeTypeEmployeeDTO> GetAll()
        {
            var data = DataAccessFactory.EmployeeTypeData().GetAll();
            var config = new MapperConfiguration(cfg =>
            {
                //cfg.CreateMap<EmployeeType, EmployeeTypeDTO>();
                cfg.CreateMap<Employee, EmployeeDTO>();
                cfg.CreateMap<EmployeeType, EmployeeTypeEmployeeDTO>();
            });
            var mapper = new Mapper(config);
            var value = mapper.Map<List<EmployeeTypeEmployeeDTO>>(data);
            return value;
        }

        public static bool Update(EmployeeTypeDTO dto)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<EmployeeTypeDTO, EmployeeType>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<EmployeeType>(dto);

            var updatedEmployeeType = DataAccessFactory.EmployeeTypeData().Update(data);

            return updatedEmployeeType != null;
        }

        public static bool Delete(int id)
        {
            var data = DataAccessFactory.EmployeeTypeData().Get(id);
            if (data != null)
            {
                var deletedEmployeeType = DataAccessFactory.EmployeeTypeData().Delete(id);
                return deletedEmployeeType != null;
            }
            else
            {
                return false;
            }
        }

    }
}
