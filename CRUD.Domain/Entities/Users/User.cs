using CRUD.Domain.SeedWork;
namespace CRUD.Domain.Entities.Users
{
    public class User: CRUD.Domain.SeedWork.BaseEntity
    {
        
        
        [System.ComponentModel.DataAnnotations.Display
            (Name = nameof(Resources.DataDictionary.FullName),
            ResourceType = typeof(Resources.DataDictionary))]

        [System.ComponentModel.DataAnnotations.Required(
            AllowEmptyStrings = false ,
            ErrorMessageResourceType = typeof(Resources.ErrorMessage),
            ErrorMessageResourceName = nameof(Resources.ErrorMessage.RequiredField))]

        public string? FullName { get; set; }

        //*****************************************************************************************

        [System.ComponentModel.DataAnnotations.Display
            (Name = nameof(Resources.DataDictionary.UserName),
             ResourceType = typeof(Resources.DataDictionary))]
        
        [System.ComponentModel.DataAnnotations.Required(
            AllowEmptyStrings = false, 
            ErrorMessageResourceType = typeof(Resources.ErrorMessage), 
            ErrorMessageResourceName = nameof( Resources.ErrorMessage.RequiredField))]

        [System.ComponentModel.DataAnnotations.MaxLength(
            length: Constants.MaxLengh.UserName ,
            ErrorMessageResourceName = nameof(Resources.ErrorMessage.MaxLength) , 
            ErrorMessageResourceType = typeof(Resources.ErrorMessage))]

        [System.ComponentModel.DataAnnotations.MinLength(
            length:Constants.MinLengh.UserName, 
            ErrorMessageResourceName = nameof(Resources.ErrorMessage.MinLength) , 
            ErrorMessageResourceType = typeof(Resources.ErrorMessage))]

        public string UserName { get; set; }

        //*****************************************************************************************
     
        [System.ComponentModel.DataAnnotations.Display(
            Name = nameof(Resources.DataDictionary.Password),
            ResourceType = typeof(Resources.DataDictionary))]

        [System.ComponentModel.DataAnnotations.DataType
            (System.ComponentModel.DataAnnotations.DataType.Password)]

        [System.ComponentModel.DataAnnotations.MinLength(
            Constants.MaxLengh.Password , 
            ErrorMessageResourceName = nameof(Resources.ErrorMessage.MinLength),
            ErrorMessageResourceType = typeof(Resources.ErrorMessage))]

        [System.ComponentModel.DataAnnotations.MaxLength( 
            length:Constants.MaxLengh.Password, 
            ErrorMessageResourceName = nameof(Resources.ErrorMessage.MaxLength), 
            ErrorMessageResourceType = typeof(Resources.ErrorMessage))]
        
        public string Password { get; set; }

        //****************************************************************************************
        
        [System.ComponentModel.DataAnnotations.Display(
             Name = nameof(Resources.DataDictionary.IsActive) ,
            ResourceType =typeof(Resources.DataDictionary))]
     
        public bool IsActive { get; set; }
        
        //****************************************************************************************
        
        [System.ComponentModel.DataAnnotations.Display(
           Name = nameof(Resources.DataDictionary.EmailAddress),
           ResourceType = typeof(Resources.DataDictionary))]
     
        [System.ComponentModel.DataAnnotations.Required(
            AllowEmptyStrings = false , 
            ErrorMessageResourceName = nameof(Resources.ErrorMessage.RequiredField), 
            ErrorMessageResourceType = typeof(Resources.ErrorMessage))]
        
        [System.ComponentModel.DataAnnotations.RegularExpression(
            Constants.RegulalExpression.Email)]

        public string Email { get; set; }

        //***************************************************************************************
        
        [System.ComponentModel.DataAnnotations.Display
            (Name = nameof(Resources.DataDictionary.RoleName ), 
            ResourceType = typeof(Resources.DataDictionary))]

        public Guid RoleId { get; set; }

        //***************************************************************************************

        [System.ComponentModel.DataAnnotations.Display
            (Name = nameof(Resources.DataDictionary.RoleName),
            ResourceType = typeof(Resources.DataDictionary))]

        public virtual Roles.Role Role { get; set; }


    }
}
