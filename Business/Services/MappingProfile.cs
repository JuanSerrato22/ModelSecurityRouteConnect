using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Entity.Model;
using Entity.DTO;

namespace Business.Services
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Rol, RolDTO>().ReverseMap();
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<Person, PersonDTO>().ReverseMap();
            CreateMap<Form, FormDTO>().ReverseMap();
            CreateMap<Module, ModuleDTO>().ReverseMap();
            CreateMap<Activity, ActivityDTO>().ReverseMap();
            CreateMap<ChangeLog, ChangeLogDTO>().ReverseMap();
            CreateMap<Destination, DestinationDTO>().ReverseMap();
            CreateMap<DestinationActivity, DestinationActivityDTO>().ReverseMap();
            CreateMap<FormModule, FormModuleDTO>().ReverseMap();
            CreateMap<Payment, PaymentDTO>().ReverseMap();
            CreateMap<Permission, PermissionDTO>().ReverseMap();
            CreateMap<RolFormPermission, RolFormPermissionDTO>().ReverseMap();
            CreateMap<RolPermission, RolPermissionDTO>().ReverseMap();
            CreateMap<UserActivity, UserActivityDTO>().ReverseMap();
            CreateMap<UserRol, UserRolDTO>().ReverseMap();
        }
    }
}
