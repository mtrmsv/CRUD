using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRUD.Domain.SeedWork;
namespace ViewModels.Roles
{
    public class CreateRoleViewModel
    {
        public CreateRoleViewModel() { }

        //********************************************************************************

        [System.ComponentModel.DataAnnotations.Display
            (Name = nameof(Resources.DataDictionary.Id), 
            ResourceType = typeof(Resources.DataDictionary))]

        public Guid Id { get; set; }

        //********************************************************************************

        [System.ComponentModel.DataAnnotations.Display
            (Name = nameof(Resources.DataDictionary.RoleName),
            ResourceType = typeof(Resources.DataDictionary))]

        [System.ComponentModel.DataAnnotations.Required
            (AllowEmptyStrings = false,
            ErrorMessageResourceName = nameof(Resources.ErrorMessage.RequiredField),
            ErrorMessageResourceType = typeof(Resources.ErrorMessage))]

        [System.ComponentModel.DataAnnotations.MaxLength
            (Constants.MaxLengh.RoleName,
            ErrorMessageResourceName = nameof(Resources.ErrorMessage.MaxLength),
            ErrorMessageResourceType = typeof(Resources.ErrorMessage))]

        public string Name { get; set; }

        //****************************************************************************

        [System.ComponentModel.DataAnnotations.Display
            (Name = nameof(Resources.DataDictionary.IsActive),
            ResourceType = typeof(Resources.DataDictionary))]

        public bool IsActive { get; set; }

    }
}
