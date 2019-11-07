using System.ComponentModel.DataAnnotations;

namespace DemoCleanArchitecture.WebApi.UseCases.Customer.Add
{
    
    public class InputCustomer
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public string Email { get; set; }
    }
}
