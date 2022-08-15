using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CRUD.Infrastructure;
using CRUD.Persistance.Contexts;
using Microsoft.EntityFrameworkCore;

namespace EndPoint.Site.Pages.Roles
{
    public class UpdateRoleModel : BasePageModelWithDatabase
    {
        public UpdateRoleModel(DataBaseContext dataBaseContext) : base(dataBaseContext)
        {
            RoleViewModel = new();
        }

        [Microsoft.AspNetCore.Mvc.BindProperty]
        public ViewModels.Roles.CreateRoleViewModel RoleViewModel { set; get; }

        public async Task<IActionResult> OnGetAsync(Guid Id)
        {
            RoleViewModel = await DataBaseContext.Roles
                 .Where(Current => Current.Id == Id)
                 .Select(Current => new ViewModels.Roles.CreateRoleViewModel()
                 {
                      Id = Current.Id,
                      Name = Current.Name,
                      IsActive = Current.IsActive,
                 
                 }).FirstAsync();    
            
            
            return Page();   
        }

        public async Task<IActionResult> OnPostAsync(Guid Id)
        {
            var foundedItem = await DataBaseContext.Roles
                .Where(Current => Current.Id == Id)
                .FirstOrDefaultAsync();

            if (foundedItem != null)
            {
                foundedItem.IsActive = RoleViewModel.IsActive;
                foundedItem.Name = RoleViewModel.Name;
            }

            await DataBaseContext.SaveChangesAsync();

            return Redirect("index");
        }
    }
}
