﻿// See https://aka.ms/new-console-template for more information

using Microsoft.Extensions.Hosting;
using Oakton;
using Wolverine;
using Wolverine.AzureServiceBus;

var builder = Host.CreateDefaultBuilder();

var connectionString = "value";
var queueName = "value";

builder
    .UseWolverine(options =>
    {
        options.UseAzureServiceBus(connectionString).SystemQueuesAreEnabled(false);
        options.ListenToAzureServiceBusQueue(queueName);
    })
    .ApplyOaktonExtensions();

var app = builder.Build();

await app.RunOaktonCommands(args);