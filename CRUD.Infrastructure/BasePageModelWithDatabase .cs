using Microsoft.AspNetCore.Mvc.RazorPages;


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
