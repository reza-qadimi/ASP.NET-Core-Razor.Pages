namespace ViewModels.Pages.Account.Users
{
    public class UpdateProfileViewModel : object
    {
        public UpdateProfileViewModel() : base()
        {

        }

        // **********
        [System.ComponentModel.DataAnnotations.Display(
            Name = nameof(Resources.DataDictionary.Id),
            ResourceType = typeof(Resources.DataDictionary))]
        public System.Guid Id { get; set; }
        // **********

        // **********
        [System.ComponentModel.DataAnnotations.Display(
            Name = nameof(Resources.DataDictionary.Username),
            ResourceType = typeof(Resources.DataDictionary))]
        
        [System.ComponentModel.DataAnnotations.Required(
            AllowEmptyStrings = false,
            ErrorMessageResourceType = typeof(Resources.Messages.Validations),
            ErrorMessageResourceName = nameof(Resources.Messages.Validations.Required))]
        
        [System.ComponentModel.DataAnnotations.MaxLength
        (length: Domain.SeedWork.Constant.MaxLength.Username,
            ErrorMessageResourceType = typeof(Resources.Messages.Validations),
            ErrorMessageResourceName = nameof(Resources.Messages.Validations.MaxLength))]
        
        [System.ComponentModel.DataAnnotations.RegularExpression
        (pattern: Domain.SeedWork.Constant.RegularExpression.Username,
            ErrorMessageResourceType = typeof(Resources.Messages.Validations),
            ErrorMessageResourceName = nameof(Resources.Messages.Validations.Username))]
        public string? Username { get; set; }
        // **********

        // **********
        [System.ComponentModel.DataAnnotations.Display(
            Name = nameof(Resources.DataDictionary.Gender),
            ResourceType = typeof(Resources.DataDictionary))]
        public Domain.Account.Enumerations.Gender Gender { get; set; }
        // **********

        // **********
        [System.ComponentModel.DataAnnotations.Display(
            Name = nameof(Resources.DataDictionary.FirstName),
            ResourceType = typeof(Resources.DataDictionary))]

        [System.ComponentModel.DataAnnotations.MaxLength(
            length: Domain.SeedWork.Constant.MaxLength.FirstName,
            ErrorMessageResourceType = typeof(Resources.Messages.Validations),
            ErrorMessageResourceName = nameof(Resources.Messages.Validations.MaxLength))]
        public string? FirstName { get; set; }
        // **********

        // **********
        [System.ComponentModel.DataAnnotations.Display(
            Name = nameof(Resources.DataDictionary.LastName),
            ResourceType = typeof(Resources.DataDictionary))]

        [System.ComponentModel.DataAnnotations.MaxLength(
            length: Domain.SeedWork.Constant.MaxLength.LastName,
            ErrorMessageResourceType = typeof(Resources.Messages.Validations),
            ErrorMessageResourceName = nameof(Resources.Messages.Validations.MaxLength))]
        public string? LastName { get; set; }
        // **********

        // **********
        [System.ComponentModel.DataAnnotations.Display(
            Name = nameof(Resources.DataDictionary.BirthDate),
            ResourceType = typeof(Resources.DataDictionary))]
        public string? PersianBirthDate { get; set; }
        // **********
        // **********
        [System.ComponentModel.DataAnnotations.Display(
            Name = nameof(Resources.DataDictionary.BirthDate),
            ResourceType = typeof(Resources.DataDictionary))]
        public System.DateTime? EnglishBirthDate { get; set; }
        // **********

        // **********
        [System.ComponentModel.DataAnnotations.Display(
            Name = nameof(Resources.DataDictionary.NationalCode),
            ResourceType = typeof(Resources.DataDictionary))]

        [System.ComponentModel.DataAnnotations.MaxLength(
            length: Domain.SeedWork.Constant.MaxLength.NationalCode,
            ErrorMessageResourceType = typeof(Resources.Messages.Validations),
            ErrorMessageResourceName = nameof(Resources.Messages.Validations.MaxLength))]

        [System.ComponentModel.DataAnnotations.RegularExpression(
            pattern: Domain.SeedWork.Constant.RegularExpression.NationalCode,
            ErrorMessageResourceType = typeof(Resources.Messages.Validations),
            ErrorMessageResourceName = nameof(Resources.Messages.Validations.NationalCode))]
        public string? NationalCode { get; set; }
        // **********

        // **********
        [System.ComponentModel.DataAnnotations.Display(
            Name = nameof(Resources.DataDictionary.Description),
            ResourceType = typeof(Resources.DataDictionary))]

        [System.ComponentModel.DataAnnotations.DataType(
            dataType: System.ComponentModel.DataAnnotations.DataType.MultilineText)]
        public string? Description { get; set; }
        // **********

    }
}
