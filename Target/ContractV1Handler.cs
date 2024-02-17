namespace Target;

using Common;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Wolverine;

public class ContractV1Handler
{
    public void Handle(
        ContractV1 request,
        IMessageContext context,
        Envelope envelope,
        ILogger logger
    )
    {
        logger.LogInformation(
            "Got header from envelop: '{Headers}'",
            JsonConvert.SerializeObject(envelope.Headers)
        );
        logger.LogInformation(
            "Got header from context: '{Headers}'",
            JsonConvert.SerializeObject(context.Envelope.Headers)
        );
    }
}