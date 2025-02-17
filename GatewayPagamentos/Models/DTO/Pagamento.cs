using GatewayPagamentos.Models.Enumeradores;

namespace GatewayPagamentos.Models.DTO
{
    public class Pagamento
    {
        public decimal Valor { get; set; }
        public string Email { get; set; }
        public string Descricao { get; set; }
        public MeioPagamento Meio { get; set; }
        public CartaoCredito? Cartao { get; set; }
        public string? GooglePayToken { get; set; }
    }
}
