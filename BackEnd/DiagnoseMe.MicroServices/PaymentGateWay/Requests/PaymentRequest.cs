namespace PaymentGateWay.Requests;

public record PaymentRequest(
    string Nonce,
    string Id
);
