using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CRUD.Infrastructure;
namespace EndPoint.Site.Pages.Login
{
    public class loginModel : BasePageModelWithDatabase
    {
        public loginModel(CRUD.Persistance.Contexts.DataBaseContext dataBaseContext) : base(dataBaseContext)
        {
            LoginViewModel = new();
        }

        [Microsoft.AspNetCore.Mvc.BindProperty]
        public ViewModels.Login.LoginViewModel LoginViewModel { set; get; }

        public async Task<IActionResult> OnPostAsync()
        {
            try
            {

                if (ModelState.IsValid == false)
                {
                    return Page();
                }


                var foundedItem = await DataBaseContext.Users
                    .Where(Current => Current.UserName == LoginViewModel.UserName && Current.Password == LoginViewModel.Password)
                    .FirstOrDefaultAsync();


                if (foundedItem != null)
                {
                    return Redirect("/Users/index");
                }
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
