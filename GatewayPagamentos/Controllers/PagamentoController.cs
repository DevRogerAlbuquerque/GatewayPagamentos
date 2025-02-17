using GatewayPagamentos.Models.DTO;
using GatewayPagamentos.Servicos;
using MercadoPago.Client.Payment;
using MercadoPago.Config;
using MercadoPago.Resource.Payment;
using Microsoft.AspNetCore.Mvc;
using GatewayPagamentos.Models.Exception;

namespace MercadoPagoPixApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PagamentoController : ControllerBase
    {
        private readonly string tokenMercadoPago;

        public PagamentoController(IConfiguration configuration)
        {
            tokenMercadoPago = configuration["MercadoPago:AccessToken"];
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(Payment))]
        public async Task<IActionResult> Get([FromRoute] long id)
        {
            try
            {
                MercadoPagoConfig.AccessToken = tokenMercadoPago;
                var client = new PaymentClient();
                var payment = await client.GetAsync(id);

                return Ok(new PagamentoResponse(payment));
            }
            catch (Exception ex)
            {
                return BadRequest(new BadRequest { Validacao = "Erro ao consultar pagamento.", Detalhes = ex.Message });
            }
        }

        [HttpPost]
        [ProducesResponseType(200, Type = typeof(Payment))]
        [ProducesErrorResponseType(typeof(BadRequest))]
        public async Task<IActionResult> Post([FromBody] Pagamento pagamento)
        {
            var servico = new PagamentoServico();

            try
            {
                var payment = await servico.CriarPagamentoAsync(pagamento, tokenMercadoPago);

                return Ok(new PagamentoResponse(payment));
            }
            catch (Exception ex)
            {
                return BadRequest(new BadRequest { Validacao = "Erro ao processar pagamento.", Detalhes = ex.Message });
            }
        }
    }
}
