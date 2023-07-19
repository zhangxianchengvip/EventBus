# EventBus

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



