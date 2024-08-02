using System.Reflection;
using Autofac;
using AutofacTesting;

var builder = new ContainerBuilder();

builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
    .Where(t => typeof(IMyService).IsAssignableFrom(t) && !t.IsAbstract)
    .AsImplementedInterfaces()
    .SingleInstance()
    .Named<IMyService>(
        t =>
        {
            var instance = Activator.CreateInstance(t, null);
            var name = t.GetMethod(nameof(IMyService.GetName))?.Invoke(instance, null)?.ToString();

            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("Name must be provided");
            }

            return name;
        });

var container = builder.Build();

using var scope = container.BeginLifetimeScope();

var services = scope.Resolve<IEnumerable<IMyService>>();

foreach (var service in services)
{
    service.DoSomething();
}

var serviceA = scope.ResolveNamed<IMyService>("MyServiceA");

serviceA.DoSomething();

var serviceB = scope.ResolveNamed<IMyService>("MyServiceB");

serviceB.DoSomething();

Console.ReadLine();