using System;

namespace DemoCleanArchitecture.Application.UseCases.Bank.Save.Handlers
{
    public class ValidateHandler : Handler<BankSaveRequest>
    {
        public override void ProcessRequest(BankSaveRequest request)
        {
            if (!request.Bank.IsValid)
                throw new ArgumentException("Model invalid");

            if (sucessor != null)
                sucessor.ProcessRequest(request);
        }
    }
}
