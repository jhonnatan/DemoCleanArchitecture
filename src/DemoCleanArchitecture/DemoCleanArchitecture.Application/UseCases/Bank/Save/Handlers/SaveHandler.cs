using DemoCleanArchitecture.Application.Repositories;
using System;

namespace DemoCleanArchitecture.Application.UseCases.Bank.Save.Handlers
{
    public class SaveHandler : Handler<BankSaveRequest>
    {
        private readonly IBankWriteOnlyRepository BankWriteOnlyRepository;

        public SaveHandler(IBankWriteOnlyRepository BankWriteOnlyRepository)
        {
            this.BankWriteOnlyRepository = BankWriteOnlyRepository;
        }

        public override void ProcessRequest(BankSaveRequest request)
        {
            var ret = BankWriteOnlyRepository.Save(request.Bank);
            if (ret == 0)
                throw new ArgumentException("Problem to save model");

            if (sucessor != null)
                sucessor.ProcessRequest(request);
        }
    }
}
