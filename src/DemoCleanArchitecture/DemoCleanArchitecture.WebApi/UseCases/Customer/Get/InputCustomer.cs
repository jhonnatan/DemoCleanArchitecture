using System;
using System.ComponentModel.DataAnnotations;

namespace DemoCleanArchitecture.WebApi.UseCases.Customer.Get
{
    public class InputCustomer
    {
        [Required]
        public Guid CustomerId { get; set; }        
    }
}
