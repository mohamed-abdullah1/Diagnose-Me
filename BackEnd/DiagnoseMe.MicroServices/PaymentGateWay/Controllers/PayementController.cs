using Braintree;
using Microsoft.AspNetCore.Mvc;
using PaymentGateWay.Interfaces;
using PaymentGateWay.Requests;

namespace PaymentGateWay.Controllers;


public class PaymentController : ApiController
{
    private readonly IBraintreeService _braintreeService;
    public PaymentController(
        Serilog.ILogger logger,
        IBraintreeService braintreeService) : base(logger)
    {
        _braintreeService = braintreeService;
    }

    [HttpPost("payment")]
    public IActionResult Payment(PaymentRequest request)
    {
        var gateway = _braintreeService.GetGateway();
        var req = new TransactionRequest
            {
                Amount = Convert.ToDecimal("250"),
                PaymentMethodNonce = request.Nonce,
                Options = new TransactionOptionsRequest
                {
                    SubmitForSettlement = true
                }
            };
        
        Result<Transaction> result = gateway.Transaction.Sale(req);
        if (result.IsSuccess())
        {
            return Ok(result.Target);
        }
        else if (result.Transaction != null)
        {
            Console.WriteLine("Error processing transaction:");
            Console.WriteLine(result.Transaction.ProcessorResponseText);
            return Problem(result.Transaction.ProcessorResponseText);
        }
        else
        {
            return Problem("Error processing transaction:");
        }
        
    }

    [HttpGet("client-token")]
    public  IActionResult ClientToken()
    {
        var gateway = _braintreeService.GetGateway();
        var clientToken = gateway.ClientToken.Generate();
        return Ok(clientToken);
    }
}