using CRUD.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EndPoint.Site.Pages
{
    public class IndexModel : BasePageModelWithDatabase
    {
        public IndexModel (CRUD.Persistance.Contexts.DataBaseContext dataBaseContext) : base (dataBaseContext)
        {
             
        }
        

        [Microsoft.AspNetCore.Mvc.BindProperty]
        public IList<ViewModels.Users.GetUsersViewModel> ViewModel { get; set; } 

        public async Task<IActionResult> OnGet() 
        {
            ViewModel =  DataBaseContext.Users
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

            return Page();
        }


    }
}
