using CRUD.Domain;

namespace AutoMapperProfiles
{
    public class RoleProfile: AutoMapper.Profile
    {
        public RoleProfile() 
        {
            CreateMap<ViewModels.Roles.CreateRoleViewModel,CRUD.Domain.Entities.Roles.Role >();
            CreateMap<CRUD.Domain.Entities.Roles.Role, ViewModels.Roles.CreateRoleViewModel>();
        }
    }
}