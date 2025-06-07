using Interport_Amal.BusinessLogic.Entities;

namespace Interport_Amal.DataAccess.Interfaces
{
    public interface IQuotationRepository
    {
        List<Quotation> GetAll();
        Quotation GetById(int quotationId);
        void Add(Quotation quotation);
        void Update(Quotation quotation);
        void Delete(int quotationId);
    }
}
