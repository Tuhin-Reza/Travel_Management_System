using AutoMapper;
using BLL.DTOS;
using DAL;
using DAL.EF.Models;
using System.Collections.Generic;

namespace BLL.Services
{
    public class EmployeeService
    {
        public static EmployeeDTO Create(EmployeeDTO dto)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<EmployeeDTO, Employee>();
            });

            var mapper = new Mapper(config);
            var data = mapper.Map<Employee>(dto);

            var emailCheck = DataAccessFactory.EmployeeData().email(data.EmailAddress);
            if (emailCheck == null)
            {
                var value = DataAccessFactory.EmployeeData().Create(data);

                string concatenatedValue = string.Join("", data.LastName, data.PhoneNumber.Substring(data.PhoneNumber.Length - 4));
                string concatenatedValuePassword = string.Join("", data.LastName, data.PhoneNumber.Substring(data.PhoneNumber.Length - 3), value.Id);

                var userDTO = new UserDTO();
                userDTO.RoleId = dto.RoleID;
                var config2 = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<UserDTO, User>();
                });

                var mapper2 = new Mapper(config2);
                var data2 = mapper2.Map<UserDTO, User>(userDTO);



                var user = new User();
                user.Username = concatenatedValue;
                user.Password = concatenatedValuePassword;
                user.EmpId = value.Id;
                user.RoleId = data2.RoleId;


                DataAccessFactory.UserData().create(user);

                return dto;
            }
            else
            {
                return null;
            }
        }


        public static EmployeeDTO GetEmployee(int id)
        {
            var data = DataAccessFactory.EmployeeData().Get(id);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Employee, EmployeeDTO>();
            });
            var mapper = new Mapper(config);
            var value = mapper.Map<EmployeeDTO>(data);
            return value;
        }

        public static List<EmployeeDTO> GetAll()
        {
            var data = DataAccessFactory.EmployeeData().GetAll();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Employee, EmployeeDTO>();
            });
            var mapper = new Mapper(config);
            var value = mapper.Map<List<EmployeeDTO>>(data);
            return value;
        }


        public static bool Update(EmployeeDTO dto)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<EmployeeDTO, Employee>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<Employee>(dto);

            var data2 = DataAccessFactory.EmployeeData().Get(data.Id);
            if (data2 == null)
            {
                return false;
            }
            DataAccessFactory.EmployeeData().Update(data);
            return true;
        }

        public static bool DeleteEmployee(int id)
        {
            var data = DataAccessFactory.EmployeeData().Get(id);

            if (data != null)
            {
                DataAccessFactory.EmployeeData().Delete(id);
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool UpdateStatus(EmployeeStatusDTO dto)
        {
            var data = DataAccessFactory.EmployeeData().Get(dto.Id);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<EmployeeDTO, Employee>();
            });
            var mapper = new Mapper(config);
            var data2 = mapper.Map<Employee>(data);

            if (data2 == null)
            {
                return false;
            }
            DataAccessFactory.EmployeeData().UpdateStatus(data2.Id, dto.Status);
            return true;
        }

        public static List<EmployeeDTO> GetAllByStatus(string status)
        {
            var data = DataAccessFactory.EmployeeData().GetByStatus(status);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Employee, EmployeeDTO>();
            });
            var mapper = new Mapper(config);
            var value = mapper.Map<List<EmployeeDTO>>(data);
            return value;
        }



    }
}
