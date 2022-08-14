using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Infrastructure
{
    public class BasePageModelWithDatabase :PageModel
    {
        public Persistance.Contexts.DataBaseContext DataBaseContext { get;}

        public BasePageModelWithDatabase(Persistance.Contexts.DataBaseContext dataBaseContext) 
        {
            DataBaseContext = dataBaseContext;
        }

        public async Task DisposeDataBaseContextAsync() 
        {
            if (DataBaseContext != null) 
            {
                await DataBaseContext.DisposeAsync();
            }
        }

    }
}
