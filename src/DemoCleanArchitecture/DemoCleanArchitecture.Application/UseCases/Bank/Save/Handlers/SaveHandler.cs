using System;
using DemoCleanArchitecture.Application.Repositories;


namespace DemoCleanArchitecture.Application.UseCases.Bank.Save.Handlers
{
    public class SaveHandler : Handler<BankSaveRequest>
    {
        private readonly IBankWriteOnlyRepository bankWriteOnlyRepository;

        public SaveHandler(IBankWriteOnlyRepository bankWriteOnlyRepository)
        {
            this.bankWriteOnlyRepository = bankWriteOnlyRepository;
        }

        public override void ProcessRequest(BankSaveRequest request)
        {
            var ret = bankWriteOnlyRepository.Save(request.Bank);
            if (ret == 0)
                throw new ArgumentException("Problem to save model");

            if (sucessor != null)
                sucessor.ProcessRequest(request);
        }
    }
}
