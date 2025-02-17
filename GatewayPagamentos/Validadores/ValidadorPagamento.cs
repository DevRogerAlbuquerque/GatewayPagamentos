using GatewayPagamentos.Models.DTO;
using GatewayPagamentos.Models.Enumeradores;

namespace GatewayPagamentos.Validadores
{
    public class ValidadorPagamento
    {
        public static IEnumerable<string> Validar(Pagamento pagamento)
        {
            if (pagamento.Valor <= 0)
                 yield return "O valor do pagamento deve ser maior que zero.";

            if (string.IsNullOrWhiteSpace(pagamento.Email))
                yield return "O e-mail do pagador é obrigatório.";

            if (pagamento.Meio == MeioPagamento.CartaoCredito || pagamento.Meio == MeioPagamento.CartaoDebito)
            {
                if (pagamento.Cartao == null || string.IsNullOrWhiteSpace(pagamento.Cartao.Token))
                    yield return "Os dados do cartão são obrigatórios para pagamentos com cartão.";

                if (string.IsNullOrWhiteSpace(pagamento.Cartao.TipoDocumento) || string.IsNullOrWhiteSpace(pagamento.Cartao.NumeroDocumento))
                    yield return "Os dados de identificação do pagador são obrigatórios para pagamentos com cartão.";
            }
            if (pagamento.Meio == MeioPagamento.GooglePay && string.IsNullOrWhiteSpace(pagamento.GooglePayToken))
                yield return "O token do Google Pay é obrigatório.";
        }
    }
}
