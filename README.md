# CommandHandlerFreamwork

Идея в том что бы собрать все обработчики команд диалога в одном месте, это позволит централизованно контролировать их запуск и позволит наращивать функциональность вокруг обработчкиов команд, не затрагивая их внутреннее устройство:

```csharp
[BeforeCommandHandler(DialogCommandCode.Example1Command)]
protected Task BeforeHandleExample1CommandHandlerFunction(IDialogContext context, IActivityCommand command)
{
    // First handle
    return Task.CompletedTask;
}

[CommandHandler(DialogCommandCode.Example1Command)]
public Task Example1CommandHandlerFunction(IDialogContext context, IActivityCommand command)
{
    // Main handle
    return Task.CompletedTask;
}


[AfterCommandHandler(DialogCommandCode.Example1Command)]
protected Task AfterHandleExample1CommandHandlerFunction(IDialogContext context, IActivityCommand command)
{
    // Final handle
    return Task.CompletedTask;
}```
