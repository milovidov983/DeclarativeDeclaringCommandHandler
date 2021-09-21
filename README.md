# Декларативное объявление обработчиков команд в диалоге

Идея в том что бы собрать все обработчики команд класса-диалога в одном месте, это позволит централизованно контролировать их запуск и позволит наращивать функциональность вокруг обработчкиов команд, не затрагивая их внутреннее устройство:

```csharp

// Не обязательный обработчик, запускаеться до того как будет запущен главный
[BeforeCommandHandler(DialogCommandCode.Example1Command)]
public Task BeforeHandleExample1CommandHandler(IDialogContext context, IActivityCommand command)
{
    // First handle
    return Task.CompletedTask;
}

// Главный и обязательный обработчик команды, в нём основная логика
// По усти это заменитель того что мы сейчас делаем в методе HandleCommandAsync в switch (command?.Code) итд
// в качестве case тут [CommandHandler(DialogCommandCode.Example1Command)]
[CommandHandler(DialogCommandCode.Example1Command)]
public Task Example1CommandHandler(IDialogContext context, IActivityCommand command)
{
    // Main handle
    return Task.CompletedTask;
}

// Не обязательный обработчик, запускаеться после того как основной отработал
[AfterCommandHandler(DialogCommandCode.Example1Command)]
public Task AfterHandleExample1CommandHandler(IDialogContext context, IActivityCommand command)
{
    // Final handle
    return Task.CompletedTask;
}

```
