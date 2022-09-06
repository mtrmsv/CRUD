using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CRUD.Infrastructure;

namespace EndPoint.Site.Pages.Roles
{
    public class CreateModel : BasePageModelWithDatabase
    {

        public CreateModel
            (CRUD.Persistance.Contexts.DataBaseContext DataBaseContext, 
            AutoMapper.IMapper mapper) : base(DataBaseContext)
        {
            ViewModel = new();
            Mapper = mapper;
        }

        [Microsoft.AspNetCore.Mvc.BindProperty]
        public ViewModels.Roles.CreateRoleViewModel ViewModel { get; set; }

        public AutoMapper.IMapper Mapper { get;}  

        //public async Task<IActionResult> OnPostAsync()
        //{
        //    if (ModelState.IsValid == false)
        //    {
        //        return Page();
        //    }

        //    try
        //    {
        //        CRUD.Domain.Entities.Roles.Role Role = new()
        //        {
        //            Name = ViewModel.Name,
        //            IsActive = ViewModel.IsActive,
        //        };

        //        await DataBaseContext.AddAsync(Role);
        //        await DataBaseContext.SaveChangesAsync();
        //    }

        //    catch (Exception ex) 
        //    {
        //    }

        //    finally 
        //    {
        //        await DisposeDataBaseContextAsync();
        //    }
        //    return Page();

        //}

        public async Task<IActionResult> OnPostAsync()
        {
            //var config = new AutoMapper.MapperConfiguration(cfg =>
            //    {
            //        cfg.CreateMap<CRUD.Domain.Entities.Roles.Role, ViewModels.Roles.CreateRoleViewModel>();
            //        cfg.CreateMap<ViewModels.Roles.CreateRoleViewModel, CRUD.Domain.Entities.Roles.Role>();
            //    });

            //AutoMapper.IMapper mapper = config.CreateMapper();
            
            CRUD.Domain.Entities.Roles.Role role = 
                Mapper.Map<CRUD.Domain.Entities.Roles.Role>(ViewModel);

            await DataBaseContext.AddAsync(role);
            await DataBaseContext.SaveChangesAsync();

            return Redirect("index");
        }
    }
}
