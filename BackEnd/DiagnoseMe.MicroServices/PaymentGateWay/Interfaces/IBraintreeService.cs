using Braintree;

namespace  PaymentGateWay.Interfaces;

public interface IBraintreeService
{
    IBraintreeGateway CreateGateway();
    IBraintreeGateway GetGateway();
}