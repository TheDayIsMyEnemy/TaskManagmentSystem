using System.ComponentModel.DataAnnotations;

namespace TaskManagmentSystem.Web.ViewModels.Account
{
    public class ExternalLoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
