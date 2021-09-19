# Декларативное объявление обработчиков команд в диалоге

Идея в том что бы собрать все обработчики команд диалога в одном месте, это позволит централизованно контролировать их запуск и позволит наращивать функциональность вокруг обработчкиов команд, не затрагивая их внутреннее устройство:

```csharp

// Не обязательный обработчик, запускаеться до того как будет запущен главный
[BeforeCommandHandler(DialogCommandCode.Example1Command)]
protected Task BeforeHandleExample1CommandHandler(IDialogContext context, IActivityCommand command)
{
    // First handle
    return Task.CompletedTask;
}

// Главный и обязательный обработчик команды, в нём основная логика
[CommandHandler(DialogCommandCode.Example1Command)]
public Task Example1CommandHandler(IDialogContext context, IActivityCommand command)
{
    // Main handle
    return Task.CompletedTask;
}

// Не обязательный обработчик, запускаеться после того как основной отработал
[AfterCommandHandler(DialogCommandCode.Example1Command)]
protected Task AfterHandleExample1CommandHandler(IDialogContext context, IActivityCommand command)
{
    // Final handle
    return Task.CompletedTask;
}```
