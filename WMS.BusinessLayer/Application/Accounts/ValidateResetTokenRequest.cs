using System.ComponentModel.DataAnnotations;

namespace WMS.BusinessLayer.Application.Accounts
{
    public class ValidateResetTokenRequest
    {
        [Required]
        public string Token { get; set; }
    }
}