using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Infrastructure.AutoMapperProfiles
{
    public class RoleProfile: AutoMapper.Profile
    {
        public RoleProfile() 
        {
            CreateMap<ViewModels.Roles.CreateRoleViewModel, CRUD.Domain.Entities.Roles.Role>();
            CreateMap<CRUD.Domain.Entities.Roles.Role, ViewModels.Roles.CreateRoleViewModel>();
        }
        
    }
}
