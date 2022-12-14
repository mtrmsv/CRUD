using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CRUD.Infrastructure;
using CRUD.Persistance.Contexts;
using Microsoft.EntityFrameworkCore;

namespace EndPoint.Site.Pages.Roles
{
    public class UpdateModel : BasePageModelWithDatabase
    {
        public UpdateModel(DataBaseContext dataBaseContext, AutoMapper.IMapper mapper) : base(dataBaseContext)
        {
            RoleViewModel = new();
            Mapper = mapper;
        }

        [Microsoft.AspNetCore.Mvc.BindProperty]
        public ViewModels.Roles.CreateRoleViewModel RoleViewModel { set; get; }

        public AutoMapper.IMapper Mapper { get; }

        public async Task<IActionResult> OnGetAsync(Guid Id)
        {
            try
            {
                RoleViewModel = await DataBaseContext.Roles
                     .Where(Current => Current.Id == Id)
                     .Select(Current => new ViewModels.Roles.CreateRoleViewModel()
                     {
                         Id = Current.Id,
                         Name = Current.Name,
                         IsActive = Current.IsActive,

                     }).FirstAsync();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                await DisposeDataBaseContextAsync();
            }
            return Page();   
        }

        //public async Task<IActionResult> OnPostAsync(Guid Id)
        //{
        //    try
        //    {
        //        var foundedItem = await DataBaseContext.Roles


        //          .Where(Current => Current.Id == Id)
        //            .FirstOrDefaultAsync();

        //        if (foundedItem != null)
        //        {
        //            foundedItem.IsActive = RoleViewModel.IsActive;
        //            foundedItem.Name = RoleViewModel.Name;
        //        }

        //        await DataBaseContext.SaveChangesAsync();
        //    }
        //    catch (Exception ex) 
        //    {

        //    }   

        //    finally 
        //    { 
        //        await DisposeDataBaseContextAsync(); 
        //    }   

        //    return Redirect("index");
        //}

        //public async Task<IActionResult> OnPostAsync(Guid Id)
        //{
        //    try
        //    {
        //        var role = new CRUD.Domain.Entities.Roles.Role()
        //        {
        //            Id = Id,
        //            Name = RoleViewModel.Name,
        //            IsActive = RoleViewModel.IsActive
        //        };

        //        DataBaseContext.Roles.Attach(role);

        //        DataBaseContext.Roles.Attach(role).State = EntityState.Modified;

        //        DataBaseContext.SaveChanges();
        //    }
        //    catch (Exception ex)
        //    {
        //    }

        //    finally
        //    {
        //        await DisposeDataBaseContextAsync();
        //    }

        //    return Redirect("/roles/");
        //}

        public async Task<IActionResult> OnPostAsync(Guid Id)
        {
            try
            {
                //var config = new AutoMapper.MapperConfiguration(cnf =>
                //{
                //    cnf.CreateMap<CRUD.Domain.Entities.Roles.Role, ViewModels.Roles.CreateRoleViewModel>();
                //    cnf.CreateMap<ViewModels.Roles.CreateRoleViewModel, CRUD.Domain.Entities.Roles.Role>();
                //}
                //);

                //AutoMapper.IMapper mapper = config.CreateMapper();


                CRUD.Domain.Entities.Roles.Role role = 
                    Mapper.Map<CRUD.Domain.Entities.Roles.Role>(RoleViewModel);
                
                role.Id= Id;    

                DataBaseContext.Roles.Attach(role);

                DataBaseContext.Roles.Attach(role).State = EntityState.Modified;

                DataBaseContext.SaveChanges();
            }
            catch (Exception ex)
            {
            }
            
            finally
            {
                await DisposeDataBaseContextAsync();
            }

            return Redirect("/roles/");
        }
    }
}
