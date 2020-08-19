using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace RuntimeCircularDependencyInjection.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IPaymentService _paymentService;

        [BindProperty]
        public decimal Amount { get; set; }

        public IndexModel(
            ILogger<IndexModel> logger,
            IPaymentService paymentService)
        {
            _logger = logger;
            _paymentService = paymentService;
        }

        public void OnGet()
        {

        }

        public void OnPost()
        {
            _paymentService.Capture(Amount);
        }
    }
}
