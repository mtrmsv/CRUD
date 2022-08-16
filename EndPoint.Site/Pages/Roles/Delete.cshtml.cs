using CRUD.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace EndPoint.Site.Pages.Roles
{
    public class DeleteModel : BasePageModelWithDatabase
    {

        public DeleteModel(CRUD.Persistance.Contexts.DataBaseContext DataBaseContext) : base(DataBaseContext) 
        {
            RoleViewModel = new();
        }

        [Microsoft.AspNetCore.Mvc.BindProperty]
        public ViewModels.Roles.CreateRoleViewModel RoleViewModel { get; set; }

        public async Task<IActionResult> OnGet(Guid Id)
        {
            try
            {
                RoleViewModel = await DataBaseContext.Roles
                      .Where(Current => Current.Id == Id)
                      .Select(Current => new ViewModels.Roles.CreateRoleViewModel()
                      {
                          Id = Current.Id,
                          IsActive = Current.IsActive,
                          Name = Current.Name,
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

        public async Task<IActionResult> OnPost(Guid id)
        {
            try
            {

                var foundenItem = await DataBaseContext.Roles
                     .Where(Current => Current.Id == id)
                     .Select(Current => Current).FirstAsync();

                DataBaseContext.Remove(foundenItem);
                await DataBaseContext.SaveChangesAsync();
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

    }
}
