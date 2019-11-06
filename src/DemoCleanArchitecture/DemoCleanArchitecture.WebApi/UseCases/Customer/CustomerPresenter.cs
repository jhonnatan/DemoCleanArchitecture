using DemoCleanArchitecture.Application.Boundaries.Customer;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace DemoCleanArchitecture.WebApi.UseCases.Customer
{
    public class CustomerPresenter : IOutputPort
    {
        public IActionResult ViewModel { get; private set; }

        public void Error(string message)
        {
            var problemDetails = new ProblemDetails()
            {
                Title = "An error occurred",
                Detail = message
            };

            ViewModel = new BadRequestObjectResult(problemDetails);
        }

        public void NotFound(string message)
            => ViewModel = new NotFoundObjectResult(message);

        public void Standard(Guid id)
            => ViewModel = new OkObjectResult(id);

        public void Standard(Domain.Customer.Customer customer)
            => ViewModel = new OkObjectResult(new CustomerResponse(customer.Id, customer.Name, customer.Age, customer.Email));

        public void Standard(IList<Domain.Customer.Customer> customer)
        {
            var customersResponse = new List<CustomerResponse>();
            customersResponse.ForEach(s => customersResponse.Add(new CustomerResponse(s.Id, s.Name, s.Age, s.Email)));
            ViewModel = new OkObjectResult(customersResponse);
        }
    }
}
