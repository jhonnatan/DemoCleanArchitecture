namespace DemoCleanArchitecture.WebApi.UseCases.Customer.Add
{
    public class InputCustomer
    {
        public string Name { get; private set; }
        public int Age { get; private set; }
        public string Email { get; private set; }

        public InputCustomer(string name, int age, string email)
        {
            Name = name;
            Age = age;
            Email = email;
        }
    }
}
