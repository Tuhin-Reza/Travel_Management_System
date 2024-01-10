using AutoMapper;
using BLL.DTOS;
using DAL;
using DAL.EF.Models;
using System.Collections.Generic;

namespace BLL.Services
{
    public class LeaveTypeService
    {
        public static LeaveTypeDTO Create(LeaveTypeDTO dto)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<LeaveTypeDTO, LeaveType>();
            });

            var mapper = new Mapper(config);
            var data = mapper.Map<LeaveType>(dto);

            var nameCheck = DataAccessFactory.LeaveTypeData().Name(dto.LeaveTypeName);
            if (nameCheck == null)
            {
                DataAccessFactory.LeaveTypeData().Create(data);
                return dto;
            }
            else
            {
                return null;
            }
        }

        public static LeaveTypeDTO GetLeaveType(int id)
        {
            var data = DataAccessFactory.LeaveTypeData().Get(id);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<LeaveType, LeaveTypeDTO>();
            });
            var mapper = new Mapper(config);
            var value = mapper.Map<LeaveTypeDTO>(data);
            return value;
        }

        public static List<LeaveTypeDTO> GetAllLeaveTypes()
        {
            var data = DataAccessFactory.LeaveTypeData().GetAll();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<LeaveType, LeaveTypeDTO>();
            });
            var mapper = new Mapper(config);
            var value = mapper.Map<List<LeaveTypeDTO>>(data);
            return value;
        }

        public static bool UpdateLeaveType(LeaveTypeDTO dto)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<LeaveTypeDTO, LeaveType>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<LeaveType>(dto);

            var updatedLeaveType = DataAccessFactory.LeaveTypeData().Update(data);

            return updatedLeaveType != null;
        }

        public static bool DeleteLeaveType(int id)
        {
            var data = DataAccessFactory.LeaveTypeData().Get(id);
            if (data != null)
            {
                var deletedLeaveType = DataAccessFactory.LeaveTypeData().Delete(id);
                return deletedLeaveType != null;
            }
            else
            {
                return false;
            }
        }

    }
}
