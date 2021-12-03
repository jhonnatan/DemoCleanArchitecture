using DemoCleanArchitecture.Application.Boundaries.Bank;
using DemoCleanArchitecture.Application.UseCases.Bank.Save.Handlers;
using System;

namespace DemoCleanArchitecture.Application.UseCases.Bank.Save
{
    public class BankSaveUseCase : IBankSaveUseCase
    {
        private readonly IOutputPort output;
        private readonly ValidateHandler validateHandler;

        public BankSaveUseCase(IOutputPort output, ValidateHandler validateHandler, SaveHandler saveHandler)
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