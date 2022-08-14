using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CRUD.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace EndPoint.Site.Pages
{
    public class CreateUserModel : BasePageModelWithDatabase
    {
        public CreateUserModel(CRUD.Persistance.Contexts.DataBaseContext dataBaseContext) : base(dataBaseContext)
        {
            UserViewModel = new();
            RoleViewModel = new List<ViewModels.Roles.CreateRoleViewModel>();
        }

        public IList<ViewModels.Roles.CreateRoleViewModel> RoleViewModel { get; set; }

        [Microsoft.AspNetCore.Mvc.BindProperty]
        public ViewModels.Users.CreateUserViewModel UserViewModel { get; set; }


        public async Task<IActionResult> OnGet() 
        {
            await GetRoles();

            return Page();
        }

        public async System.Threading.Tasks.Task
            <Microsoft.AspNetCore.Mvc.IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid == false)
            {
                return Page();
            }

            try
            {
                CRUD.Domain.Entities.Users.User user = new()
                {
                    FullName = UserViewModel.FullName,
                    Email = UserViewModel.Email,
                    IsActive = UserViewModel.IsActive,
                    Password = UserViewModel.Password,
                    UserName = UserViewModel.UserName,
                    RoleId = UserViewModel.RoleId,
                };

                await DataBaseContext.AddAsync(user);

                DataBaseContext.SaveChanges();
            }

            catch (Exception ex)
            {
            }

            return Redirect(url: "index.cshtml");

        }

        public async Task GetRoles() 
        {
           
            RoleViewModel = await DataBaseContext.Roles
                .OrderBy(Current => Current.Name)
                .Select (Current => new ViewModels.Roles.CreateRoleViewModel() 
                {
                    Name = Current.Name,  
                     Id = Current.Id, 
                   
                }).ToListAsync();
        }
    }
}
