namespace GatewayPagamentos.Models.DTO
{
    public class CartaoCredito
    {
        public string Token { get; set; }
        public int Parcelas { get; set; }
        public string TipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
    }
}
