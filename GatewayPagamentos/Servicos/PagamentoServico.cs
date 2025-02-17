using GatewayPagamentos.Models.DTO;
using GatewayPagamentos.Models.Enumeradores;
using GatewayPagamentos.Validadores;
using MercadoPago.Client.Payment;
using MercadoPago.Config;
using MercadoPago.Resource.Payment;
using Microsoft.OpenApi.Extensions;

namespace GatewayPagamentos.Servicos
{
    public class PagamentoServico
    {
        public async Task<Payment> CriarPagamentoAsync(Pagamento pagamento, string tokenMercadoPago)
        {
            var validacoes = ValidadorPagamento.Validar(pagamento);

            if (validacoes?.Any() == true)
                throw new Exception(string.Join(", ", validacoes));

            string meioPagamento = pagamento.Meio.GetDisplayName();
            MercadoPagoConfig.AccessToken = tokenMercadoPago;

            var paymentRequest = new PaymentCreateRequest
            {
                TransactionAmount = pagamento.Valor,
                Description = pagamento.Descricao,
                PaymentMethodId = meioPagamento,
                Payer = new PaymentPayerRequest
                {
                    Email = pagamento.Email
                }
            };

            /*   if (meioPagamento == "credit_card" || meioPagamento == "debit_card")
               {
                   paymentRequest.Token = pagamento.Cartao.Token;
                   paymentRequest.Installments = pagamento.Cartao.Parcelas;
                   paymentRequest.Payer.Identification = new Identification
                   {
                       Type = pagamento.Cartao.TipoDocumento.ToLower(),
                       Number = pagamento.Cartao.NumeroDocumento
                   };
               }
               else */
            if (meioPagamento == "google_pay")
                paymentRequest.Token = pagamento.GooglePayToken;

            var client = new PaymentClient();
            Payment payment = await client.CreateAsync(paymentRequest);

            return payment;
        }
    }
}
