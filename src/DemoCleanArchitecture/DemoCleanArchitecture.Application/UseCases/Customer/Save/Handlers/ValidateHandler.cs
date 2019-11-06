using System;

namespace DemoCleanArchitecture.Application.UseCases.Customer.Save.Handlers
{
    public class ValidateHandler : Handler<CustomerSaveRequest>
    {
        public override void ProcessRequest(CustomerSaveRequest request)
        {
            if (!request.Customer.IsValid)
                throw new ArgumentException("Model invalid");            

            if (sucessor != null)
                sucessor.ProcessRequest(request);
        }
    }
}
