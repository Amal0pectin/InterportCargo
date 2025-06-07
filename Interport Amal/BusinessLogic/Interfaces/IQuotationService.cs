using Interport_Amal.BusinessLogic.Entities;

namespace Interport_Amal.BusinessLogic.Interfaces
{
    public interface IQuotationService
    {
        List<Quotation> GetAll();
        Quotation GetById(int id);
        void Add(Quotation quotation);
        void Update(Quotation quotation);
        void Delete(int id);
    }
}
