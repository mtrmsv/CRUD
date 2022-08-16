using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CRUD.Infrastructure;

namespace EndPoint.Site.Pages
{
    public class DeleteModel : BasePageModelWithDatabase
    {
        
        public DeleteModel(CRUD.Persistance.Contexts.DataBaseContext dataBaseContext) : base (dataBaseContext)
        {

            ViewModel = new();

        }
        
        public ViewModels.Users.DeleteUserViewModel ViewModel { get; set; } 

        public async Task OnGet(Guid id )
        {
            try
            {
                ViewModel = await DataBaseContext.Users
                    .Where(Current => Current.Id == id)
                    .Select(Current => new ViewModels.Users.DeleteUserViewModel
                    {
                        Role = Current.Role.Name,
                        Id = Current.Id,
                        Email = Current.Email,
                        FullName = Current.FullName,
                        IsActive = Current.IsActive,
                        UserName = Current.UserName,

                    }).FirstAsync();
            }
            catch (Exception ex)
            {
            }
            
            finally 
            {
                await DisposeDataBaseContextAsync();
            }
         
        }

        public async Task<IActionResult> OnPost (Guid id) 
        {
            var foundedItem = await DataBaseContext.Users
                .Where(Current => Current.Id == id)
                .FirstOrDefaultAsync();
            
            if (foundedItem != null) 
            {
                DataBaseContext.Remove(foundedItem);
                await DataBaseContext.SaveChangesAsync();
            }

            return Page();
        }


    }
}
