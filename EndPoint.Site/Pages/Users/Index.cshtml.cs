using CRUD.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EndPoint.Site.Pages
{
    public class IndexModel : BasePageModelWithDatabase
    {
        public IndexModel (CRUD.Persistance.Contexts.DataBaseContext dataBaseContext) : base (dataBaseContext)
        {
            ViewModel = new List<ViewModels.Users.GetUsersViewModel> ();
        }
        

        [Microsoft.AspNetCore.Mvc.BindProperty]
        public IList<ViewModels.Users.GetUsersViewModel> ViewModel { get; set; } 

        public async Task<IActionResult> OnGet() 
        {
            try
            {
                ViewModel = DataBaseContext.Users
                    .OrderBy(current => current.Id)
                    .Select(current => new ViewModels.Users.GetUsersViewModel
                    {
                        Role = current.Role.Name,
                        Id = current.Id,
                        Email = current.Email,
                        FullName = current.FullName,
                        IsActive = current.IsActive,
                        UserName = current.UserName,

                    }).ToList();
            }
            
            catch (Exception ex) { }
            
            finally 
            { 
                await DisposeDataBaseContextAsync(); 
            }
            return Page();
        }


    }
}
