namespace Source;

using Common;
using Microsoft.Extensions.Hosting;
using Wolverine;

public class SendContractV1(IMessageBus bus) : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken token) =>
        await bus.PublishAsync(
            new ContractV1("super-admin"),
            new DeliveryOptions { Headers = { { "x-my-header", "This is some message context" } } }
        );
}