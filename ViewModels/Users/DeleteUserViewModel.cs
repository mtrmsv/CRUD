using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.Users
{
    public class DeleteUserViewModel
    {
        public DeleteUserViewModel() { }


        [System.ComponentModel.DataAnnotations.Display
            (Name = nameof(Resources.DataDictionary.Id),
            ResourceType = typeof(Resources.DataDictionary))]

        public Guid Id { get; set; }


        [System.ComponentModel.DataAnnotations.Display
            (Name = nameof(Resources.DataDictionary.FullName), 
            ResourceType = typeof(Resources.DataDictionary))]
        
        public string FullName { get; set; }
        
        
        [System.ComponentModel.DataAnnotations.Display
            (Name = nameof(Resources.DataDictionary.UserName),
            ResourceType = typeof(Resources.DataDictionary))]
        
        public string UserName { get; set; }


        [System.ComponentModel.DataAnnotations.Display
            (Name = nameof(Resources.DataDictionary.EmailAddress),
            ResourceType = typeof(Resources.DataDictionary))]
        
        public string Email { get; set; }


        [System.ComponentModel.DataAnnotations.Display
            (Name = nameof(Resources.DataDictionary.IsActive), 
            ResourceType =typeof(Resources.DataDictionary))]
            
        public bool IsActive { get; set; }


        [System.ComponentModel.DataAnnotations.Display
             (Name = nameof(Resources.DataDictionary.RoleName),
            ResourceType = typeof(Resources.DataDictionary))]
        
        public string Role { get; set; }
    }
}
