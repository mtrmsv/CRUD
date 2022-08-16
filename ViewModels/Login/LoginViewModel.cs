using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.Login
{
    public class LoginViewModel
    {
        public LoginViewModel() { }

        [System.ComponentModel.DataAnnotations.Display
            (Name = nameof(Resources.DataDictionary.UserName),
            ResourceType = typeof(Resources.DataDictionary))]

        [System.ComponentModel.DataAnnotations.Required
            (AllowEmptyStrings = false,
            ErrorMessageResourceName = nameof(Resources.ErrorMessage.RequiredField),
            ErrorMessageResourceType = typeof(Resources.ErrorMessage))]

        [System.ComponentModel.DataAnnotations.MaxLength
            (CRUD.Domain.SeedWork.Constants.MaxLengh.UserName ,
            ErrorMessageResourceName = nameof(Resources.ErrorMessage.MaxLength), 
            ErrorMessageResourceType = typeof(Resources.ErrorMessage))]

        [System.ComponentModel.DataAnnotations.RegularExpression
            (CRUD.Domain.SeedWork.Constants.RegulalExpression.Username)]

        public string UserName { get; set; }

        //******************************************************************************

        [System.ComponentModel.DataAnnotations.DataType
            (System.ComponentModel.DataAnnotations.DataType.Password)]

        [System.ComponentModel.DataAnnotations.Display
            (Name = nameof(Resources.DataDictionary.Password) , 
            ResourceType = typeof(Resources.DataDictionary))]

        [System.ComponentModel.DataAnnotations.Required
            (AllowEmptyStrings = false ,
            ErrorMessageResourceName = nameof(Resources.ErrorMessage.RequiredField ) , 
            ErrorMessageResourceType = typeof (Resources.ErrorMessage))]

        [System.ComponentModel.DataAnnotations.RegularExpression
            (CRUD.Domain.SeedWork.Constants.RegulalExpression.Password)]

        [System.ComponentModel.DataAnnotations.MaxLength
            (CRUD.Domain.SeedWork.Constants.MaxLengh.Password,
            ErrorMessageResourceName = nameof(Resources.ErrorMessage.MaxLength),
            ErrorMessageResourceType = typeof(Resources.ErrorMessage))]

       
        public string Password { get; set; }
    }
}
