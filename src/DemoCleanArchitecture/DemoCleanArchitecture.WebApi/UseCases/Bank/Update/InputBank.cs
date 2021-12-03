using System;
using System.ComponentModel.DataAnnotations;

namespace DemoCleanArchitecture.WebApi.UseCases.Bank.Update
{
    public class InputBank
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Number { get; set; }
    }
}
