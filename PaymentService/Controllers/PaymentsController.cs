using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaymentService.Data;
using PaymentService.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PaymentService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private readonly IPayment _payment;
        private readonly IMapper _mapper;

        public PaymentsController(IPayment payment,
        IMapper mapper)
        {
            _payment = payment;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<PaymentDto>> GetAllBills(string name)
        {
            var results = await _payment.GetTagihan(name);
            var dtos = _mapper.Map<IEnumerable<PaymentDto>>(results);
            return dtos;
        }
    }
}
