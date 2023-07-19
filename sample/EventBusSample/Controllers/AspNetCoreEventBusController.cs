using EventBus.Abstractions;
using EventBus.AspNetCore;
using EventBus.Events;
using EventBus.SubsManager;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventBusSample.Controllers;
[Route("api/[controller]")]
[ApiController]
public class AspNetCoreEventBusController : ControllerBase
{
    private readonly IEventBus _eventBus;

    public AspNetCoreEventBusController(IEventBus eventBus)
    {
        _eventBus = eventBus;
    }
    [HttpGet]
    public async Task Test()
    {
        await _eventBus.PublishAsync("Test", new Test { Msg = "zxc" });
    }
}

[Subscribe("Test")]
public class TestHandler : IntegrationEventHandler<Test>
{
    public override async Task HandleAsync(string topic, Test? value)
    {
        Console.WriteLine(value?.Msg);
        await Task.Yield();
    }
}

public class Test : IntegrationEvent
{
    public string Msg { get; set; }
}