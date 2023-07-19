# Confluent.Kafka.EventBus.AspNetCore

#### 介绍
基于 Confluent.Kafka 实现进程内事件总线

#### 快速开始

1. 安装

- [Package Manager](https://www.nuget.org/packages/Confluent.Kafka.EventBus.AspNetCore)

```
Install-Package Confluent.Kafka.EventBus.AspNetCore
```

- [.NET CLI](https://www.nuget.org/packages/Confluent.Kafka.EventBus.AspNetCore)

```
dotnet add package Confluent.Kafka.EventBus.AspNetCore
```

2. 注册服务

```c#
builder.Services.AddConfluentKafkaEventBus();
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

