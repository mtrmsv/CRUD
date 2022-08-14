using CRUD.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace EndPoint.Site.Pages.Roles
{
    public class IndexModel : BasePageModelWithDatabase
    {


        public IndexModel( CRUD.Persistance.Contexts.DataBaseContext DataBaseContext) : base(DataBaseContext)
        { 
            RoleViewModel = new List<ViewModels.Roles.CreateRoleViewModel>();
        }

        public List<ViewModels.Roles.CreateRoleViewModel> RoleViewModel { get; set; }

        public async Task<IActionResult> OnGet()
        {
            RoleViewModel = await DataBaseContext.Roles
                .Select(r => new ViewModels.Roles.CreateRoleViewModel()
                {
                     Id = r.Id,
                     Name = r.Name,
                     IsActive = r.IsActive,

                }).ToListAsync();

            return Page();

        }
    }
}
