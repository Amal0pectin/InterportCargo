using Interport_Amal.BusinessLogic.Entities;

namespace Interport_Amal.Application.Interfaces
{
    public interface IQuotationAppService
    {
        List<Quotation> GetAllQuotations();
        Quotation GetQuotation(int id);
        Task CreateQuotationAsync(Quotation quotation);
        Task<decimal> CalculateTotalChargeAsync(Quotation quotation);
    }
}
