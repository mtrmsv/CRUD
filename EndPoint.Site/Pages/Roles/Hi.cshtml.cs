using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace EndPoint.Site.Pages.Roles
{
    public class HiModel : PageModel
    {
        public HiModel(ILogger<HiModel> logger) 
        {
            Logger = logger;    
        }

        protected ILogger<HiModel> Logger { get; }   

        [Microsoft.AspNetCore.Mvc.BindProperty]
        public CRUD.Domain.Validators.Hi Hi { get; set; }

        public void OnGet()
        {
            Logger.LogTrace("OnGet Run");
        }
        public void OnPost() 
        {
            Logger.LogInformation("OnPost Run");
            //if (!ModelState.IsValid) 
            //{
            //    //return Page();
            //    var val = new CRUD.Domain.Validators.HiValidator();
            //    var result = val.Validate(Hi);
            //    List<string> errors = new List<string>();
            //    foreach (var item in result.Errors) 
            //    {
            //        errors.Add(item.ErrorMessage);  
            //    }    
            //}

           var name = Hi.FullNamess;
        
        }
    }
}
