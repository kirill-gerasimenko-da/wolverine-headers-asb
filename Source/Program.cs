// See https://aka.ms/new-console-template for more information

using Common;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Oakton;
using Source;
using Wolverine;
using Wolverine.AzureServiceBus;

var builder = Host.CreateDefaultBuilder();

var connectionString = "value";
var queueName = "value";

builder
    .UseWolverine(options =>
    {
        options.UseAzureServiceBus(connectionString).SystemQueuesAreEnabled(false);
        options.PublishMessage<ContractV1>().ToAzureServiceBusQueue(queueName);

        options.Services.AddHostedService<SendContractV1>();
    })
    .ApplyOaktonExtensions();

var app = builder.Build();

await app.RunOaktonCommands(args);