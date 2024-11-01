using System.ComponentModel.DataAnnotations;

namespace BlazorLabb.Models
{
    public class Address
    {
        [Required(ErrorMessage = "Street is required.")]
        public string Street { get; set; }

        [Required(ErrorMessage = "City is required.")]
        public string City { get; set; }

        [Required(ErrorMessage = "ZIP Code is required.")]
        [RegularExpression(@"^\d{5}(-\d{4})?$", ErrorMessage = "Invalid ZIP Code format.")]
        public string ZipCode { get; set; } //Leading zeros (e.g., "01234"), which would be lost if stored as an integer.
    }
}
