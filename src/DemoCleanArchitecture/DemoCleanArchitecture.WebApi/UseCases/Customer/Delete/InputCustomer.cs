using System;
using System.ComponentModel.DataAnnotations;

namespace DemoCleanArchitecture.WebApi.UseCases.Customer.Delete
{
    public class InputCustomer
    {
        [Required]
        public Guid CustomerId { get; set; }
    }
}
