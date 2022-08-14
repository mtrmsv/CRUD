using CRUD.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace EndPoint.Site.Pages.Roles
{
    public class DeleteRoleModel : BasePageModelWithDatabase
    {
        public DeleteRoleModel(CRUD.Persistance.Contexts.DataBaseContext DataBaseContext) : base(DataBaseContext) 
        {
            RoleViewModel = new();
        }


        [Microsoft.AspNetCore.Mvc.BindProperty]
        public ViewModels.Roles.CreateRoleViewModel RoleViewModel { get; set; }

        public async Task<IActionResult> OnGet(Guid Id)
        {
          RoleViewModel = await DataBaseContext.Roles
                .Where( Current => Current.Id == Id)
                .Select(Current =>  new ViewModels.Roles.CreateRoleViewModel()
                {
                     Id =  Current.Id,
                     IsActive = Current.IsActive,  
                     Name = Current.Name,
                }).FirstAsync();

            return Page();
        }
    }
}
