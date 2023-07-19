using EventBus.Abstractions;
using EventBus.AspNetCore;
using EventBus.Events;
using EventBus.SubsManager;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventBusSample.Controllers;
[Route("api/[controller]")]
[ApiController]
public class EventBusController : ControllerBase
{
    private readonly IEventBus _eventBus;

    public EventBusController(IEventBus eventBus)
    {
        _eventBus = eventBus;
    }
    [HttpGet]
    public async Task Test()
    {
        await _eventBus.PublishAsync("mc", new Test { Msg = "zxc" });
    }
}

[Subscribe("mc")]
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