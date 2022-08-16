using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CRUD.Infrastructure;

namespace EndPoint.Site.Pages.Roles
{
    public class CreateModel : BasePageModelWithDatabase
    {

        public CreateModel(CRUD.Persistance.Contexts.DataBaseContext DataBaseContext) : base(DataBaseContext)
        {
            ViewModel = new();
        }

        [Microsoft.AspNetCore.Mvc.BindProperty]
        public ViewModels.Roles.CreateRoleViewModel ViewModel { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid == false)
            {
                return Page();
            }

            try
            {
                CRUD.Domain.Entities.Roles.Role Role = new()
                {
                    Name = ViewModel.Name,
                    IsActive = ViewModel.IsActive,
                };

                await DataBaseContext.AddAsync(Role);
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
