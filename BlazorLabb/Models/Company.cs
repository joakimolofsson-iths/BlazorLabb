using System.ComponentModel.DataAnnotations;

namespace BlazorLabb.Models
{
    public class Company
    {
        [Required(ErrorMessage = "Company name is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Company catchphrase is required.")]
        public string Catchphrase { get; set; }
    }
}
