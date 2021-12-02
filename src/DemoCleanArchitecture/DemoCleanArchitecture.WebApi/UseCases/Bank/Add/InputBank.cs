using System.ComponentModel.DataAnnotations;


namespace DemoCleanArchitecture.WebApi.UseCases.Bank.Add
{
    public class InputBank
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Number { get; set; }
    }
}
