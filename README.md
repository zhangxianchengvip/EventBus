# IEventBus

#### 介绍
事件总线抽象接口

## IEventBus 

发布订阅接口

```C#
    public interface IEventBus
    {
        void Publish<T>(string topic, T data);
        Task PublishAsync<T>(string topic, T data);
        void Subscribe(params string[] topics);
    }
```

## ICallEventHandler

统一调用事件处理

```C#
    public interface ICallEventHandler
    {
        Task Handle(string topic, byte[] value);
    }
```

## IIntegrationEventHandler

事件处理

## IntegrationEventHandler<T>

泛型事件处理

## DynamicIntegrationEventHandler

动态类型事件处理

## IntegrationEvent

事件基类



## SubscribeAttribute

订阅特性

## SubscriptionsManager

订阅管理



---



# IEventBus.AspNetCore



#### 介绍
基于AspNetCore Channel 实现进程内事件总线

#### 快速开始

1. 安装

- [Package Manager](https://www.nuget.org/packages/IEventBus.AspNetCore)

```
Install-Package IEventBus.AspNetCore
```

- [.NET CLI](https://www.nuget.org/packages/IEventBus.AspNetCore)

```
dotnet add package IEventBus.AspNetCore
```

2. 注册服务

```c#
//version 1.0.0
builder.Services.AddAspNetCoreEventBus();
//version 2.0.0
builder.Services.AddEventBus
(
    options => { options.UseAspNetCore(); }
);
```

3. 配置管道

```c#
app.UseEventBus();
```

4. 定义事件类

```C#
//如果事件处理类继承IntegrationEventHandler<> 需要继承IntegrationEvent
public class Test 
{
    public string Msg { get; set; }
}
```

5. 定义事件处理类重写HandleAsync

```C#
//订阅主题
[Subscribe("Test")]
public class TestHandler : IntegrationEventHandler<Test>//Or DynamicIntegrationEventHandler
{
    public override async Task HandleAsync(string topic, Test? value)
    {
        Console.WriteLine(value?.Msg);
        await Task.Yield();
    }
}
```

6. 生产者通过IEventBus.PublishAsync 生产数据

```c#
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
```



---



# Confluent.Kafka.EventBus.AspNetCore(IEventBus.Confluent.Kafka)

#### 介绍
基于 Confluent.Kafka 实现事件总线

#### 快速开始

1. 安装

- [Package Manager](https://www.nuget.org/packages/Confluent.Kafka.EventBus.AspNetCore)

```
//version 1.0.0
Install-Package Confluent.Kafka.EventBus.AspNetCore
//version 2.0.0
Install-Package IEventBus.Confluent.Kafka

```

- [.NET CLI](https://www.nuget.org/packages/Confluent.Kafka.EventBus.AspNetCore)

```
//version 1.0.0
dotnet add package Confluent.Kafka.EventBus.AspNetCore
//version 2.0.0
dotnet add package IEventBus.Confluent.Kafka
```

2. 注册服务

```c#
//version 1.0.0
builder.Services.AddConfluentKafkaEventBus();
//version 2.0.0
builder.Services.AddEventBus
(
    options => { options.UseKafka(builder.Configuration); }
);
```

3. 配置管道

```c#
app.UseEventBus();
```

4. 定义事件类

```C#
//如果事件处理类继承IntegrationEventHandler<> 需要继承IntegrationEvent
public class Test 
{
    public string Msg { get; set; }
}
```

5. 定义事件处理类重写HandleAsync

```C#
//订阅主题
[Subscribe("Test")]
public class TestHandler : IntegrationEventHandler<Test>//Or DynamicIntegrationEventHandler
{
    public override async Task HandleAsync(string topic, Test? value)
    {
        Console.WriteLine(value?.Msg);
        await Task.Yield();
    }
}
```

6. 生产者通过IEventBus.PublishAsync 生产数据

```C#
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

```

