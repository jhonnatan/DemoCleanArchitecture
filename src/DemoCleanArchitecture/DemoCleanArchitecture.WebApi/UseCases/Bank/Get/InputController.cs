using System;
using System.ComponentModel.DataAnnotations;

namespace DemoCleanArchitecture.WebApi.UseCases.Bank.Get
{
    public class InputBank
    {
        [Required]
        public Guid BankId { get; set; }
    }
}
