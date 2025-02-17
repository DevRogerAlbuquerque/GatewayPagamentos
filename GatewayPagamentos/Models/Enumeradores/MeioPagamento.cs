using System.ComponentModel;

namespace GatewayPagamentos.Models.Enumeradores
{
    public enum MeioPagamento
    {
        [Description("pix")]
        pix,
        [Description("credit_card")]
        CartaoCredito,
        [Description("debit_card")]
        CartaoDebito,
        [Description("google_pay")]
        GooglePay
    }
}
