# IEventBus.Confluent.Kafka

#### 介绍
基于 Confluent.Kafka 实现进程内事件总线

#### 快速开始

1. 安装

- [Package Manager](https://www.nuget.org/packages/IEventBus.Confluent.Kafka)

```
Install-Package IEventBus.Confluent.Kafka
```

- [.NET CLI](https://www.nuget.org/packages/IEventBus.Confluent.Kafka)

```
dotnet add package IEventBus.Confluent.Kafka
```

2. 注册服务

```c#
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

