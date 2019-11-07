using System;
using System.ComponentModel.DataAnnotations;

namespace DemoCleanArchitecture.WebApi.UseCases.Customer.Update
{
    public class InputCustomer
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public string Email { get; set; }
    }
}
