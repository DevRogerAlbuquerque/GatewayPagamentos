using MercadoPago.Resource.Payment;

public class PagamentoResponse
{
    public long Id { get; set; }
    public string Status { get; set; }
    public string StatusDetail { get; set; }
    public string QrCode { get; set; }
    public string QrCodeBase64 { get; set; }

    public PagamentoResponse(Payment payment)
    {
        Id = payment.Id.Value;
        Status = payment.Status;
        StatusDetail = payment.StatusDetail;
        QrCode = payment.PaymentMethodId == "pix" ? payment.PointOfInteraction?.TransactionData?.QrCode : null;
        QrCodeBase64 = payment.PaymentMethodId == "pix" ? payment.PointOfInteraction?.TransactionData?.QrCodeBase64 : null;
    }
}