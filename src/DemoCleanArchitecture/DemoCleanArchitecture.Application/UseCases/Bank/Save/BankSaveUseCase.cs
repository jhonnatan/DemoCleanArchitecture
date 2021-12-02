using System;
using DemoCleanArchitecture.Application.Boundaries.Bank;

namespace DemoCleanArchitecture.Application.UseCases.Bank.Save
{
    class BankSaveUseCase : IBankSaveUseCase
    {
        private readonly IOutputPort output;
        private readonly Handlers.ValidateHandler validateHandler;

        public BankSaveUseCase(IOutputPort output, Handlers.ValidateHandler validateHandler, Handlers.SaveHandler saveHandler)
        {
            this.output = output;
            this.validateHandler = validateHandler;
            this.validateHandler.SetSucessor(saveHandler);
        }

        public void Execute(BankSaveRequest request)
        {
            try
            {
                validateHandler.ProcessRequest(request);
                output.Standard(request.Bank.Id);
            }
            catch (Exception ex)
            {
                output.Error($"Error on process: {ex.Message}");
            }
        }

    }

}
