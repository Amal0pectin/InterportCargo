using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Interport_Amal.Application.Interfaces;
using Interport_Amal.BusinessLogic.Entities;

namespace Interport_Amal.Pages.Employee
{
    public class EManageRequestsModel : PageModel
    {
        private readonly IQuotationRequestAppService _quotationRequestAppService;

        public EManageRequestsModel(IQuotationRequestAppService quotationRequestAppService)
        {
            _quotationRequestAppService = quotationRequestAppService;
        }

        public List<QuotationRequest> AllRequests { get; set; }

        public void OnGet()
        {
            AllRequests = _quotationRequestAppService.GetAll();
        }

        public IActionResult OnPostAccept(int requestId)
        {
            var request = _quotationRequestAppService.GetById(requestId);
            if (request == null) return NotFound();

            request.Status = RequestStatus.Accepted;
            _quotationRequestAppService.Update(request);

            return RedirectToPage();
        }

        public IActionResult OnPostReject(int requestId)
        {
            var request = _quotationRequestAppService.GetById(requestId);
            if (request == null) return NotFound();

            request.Status = RequestStatus.Rejected;
            _quotationRequestAppService.Update(request);

            return RedirectToPage();
        }
    }
}
