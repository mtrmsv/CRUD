using CRUD.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace EndPoint.Site.Pages
{
    public class UpdateModel : BasePageModelWithDatabase
    {

        public UpdateModel(CRUD.Persistance.Contexts.DataBaseContext dataBaseContext) : base(dataBaseContext)
        {
            ViewModel = new();
            RolesViewModel = new List<ViewModels.Roles.CreateRoleViewModel> ();
        }

        public List<ViewModels.Roles.CreateRoleViewModel> RolesViewModel { get; set; }

        [Microsoft.AspNetCore.Mvc.BindProperty]
        public ViewModels.Users.UpdateUserViewModel ViewModel { get; set; } 

        public async Task<IActionResult> OnGet(Guid id)
        {
            try
            {
                await GetRoles();

                ViewModel = await DataBaseContext.Users
                     .Where(Current => Current.Id == id)
                     .Select(Current => new ViewModels.Users.UpdateUserViewModel()
                     {
                         RoleId = Current.RoleId,
                         Id = Current.Id,
                         FullName = Current.FullName,
                         UserName = Current.UserName,
                         Email = Current.Email,
                         IsActive = Current.IsActive,
                     }).FirstAsync();
            }
            catch (Exception ex) { }
            
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

                var foundedItem = await DataBaseContext.Users
                    .Where(Current => Current.Id == id)
                    .FirstOrDefaultAsync();


                if (foundedItem != null)
                {
                    foundedItem.FullName = ViewModel.FullName;
                    foundedItem.UserName = ViewModel.UserName;
                    foundedItem.Email = ViewModel.Email;
                    foundedItem.IsActive = ViewModel.IsActive;
                    foundedItem.RoleId = ViewModel.RoleId;
                }
                await DataBaseContext.SaveChangesAsync();

            }
            catch(Exception ex) 
            {

            } 

            finally 
            { 
                await DisposeDataBaseContextAsync(); 
            }
            
            return Redirect("index");
        }

        public async Task GetRoles() 
        {
            try
            {
                RolesViewModel = await DataBaseContext.Roles
                    .OrderBy(Current => Current.Name)
                    .Select(Current => new ViewModels.Roles.CreateRoleViewModel
                    {

                        Id = Current.Id,
                        Name = Current.Name,

                    }).ToListAsync();
            }
            catch (Exception ex)
            {
            }
            finally 
            {
                await DisposeDataBaseContextAsync();
            }
        }
    }
}
