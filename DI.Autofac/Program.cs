﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Autofac;
using Autofac.Core;
using DI.Autofac.Classes;
using DI.Autofac.Interfaces;

namespace DI.Autofac
{
    internal class Program
    {
        public static IContainer Container;

        private static void Main(string[] args)
        {
            bool exit = false;
            
            while (!exit)
            {
                Console.WriteLine();
                Console.WriteLine("1 - Regular DI usage");
                Console.WriteLine("2 - Specific service locator");
                Console.WriteLine("3 - General service locator");
                Console.WriteLine("4 - Lifetime scope");
                Console.WriteLine("5 - Assembly scanning");
                Console.WriteLine("6 - Module usage");
                Console.WriteLine("7 - One-to-many");
                Console.WriteLine("8 - Post-construction resolve & Property injection");
                Console.WriteLine("9 - Constructor finder");
                Console.WriteLine("0 - Exit");
                Console.WriteLine();
                Console.Write("Select demo initialization: ");
                
                string choice = Console.ReadLine();
                
                if (choice == "0")
                    exit = true;
                else
                {
                    OrderInfo orderInfo = new OrderInfo()
                    {
                        CustomerName = "Miguel Castro",
                        Email = "miguelcastro67@gmail.com",
                        Product = "Laptop",
                        Price = 1200,
                        CreditCard = "1234567890"
                    };

                    Console.WriteLine();
                    Console.WriteLine("Order Processing:");
                    Console.WriteLine();

                    ContainerBuilder builder = new ContainerBuilder();

                    switch (choice)
                    {
                        case "1":
                            #region regular container usage

                            builder.RegisterType<Commerce1>();
                            builder.RegisterType<BillingService>().As<IBillingService>();
                            builder.RegisterType<InventoryService>().As<IInventoryService>();
                            builder.RegisterType<NotificationService>().As<INotificationService>();
                            builder.RegisterType<LoggingService>().As<ILoggingService>();
                            
                            Container = builder.Build();

                            Commerce1 commerce1 = Container.Resolve<Commerce1>();

                            commerce1.ProcessOrder(orderInfo);

                            #endregion

                            break;
                        
                        case "2":
                            #region specific service locator (Commerce2)
                            
                            builder.RegisterType<Commerce2>();
                            builder.RegisterType<BillingService>().As<IBillingService>();
                            builder.RegisterType<InventoryService>().As<IInventoryService>();
                            builder.RegisterType<NotificationService>().As<INotificationService>();
                            builder.RegisterType<LoggingService>().As<ILoggingService>();

                            builder.RegisterType<BillingServiceLocator>().As<IBillingServiceLocator>();

                            Container = builder.Build();

                            Commerce2 commerce2 = Container.Resolve<Commerce2>();

                            commerce2.ProcessOrder(orderInfo);
                            
                            #endregion

                            break;
                        
                        case "3":
                            #region general service locator (Commerce3)
                            
                            builder.RegisterType<Commerce3>();

                            builder.RegisterType<BillingService>().As<IBillingService>();
                            builder.RegisterType<InventoryService>().As<IInventoryService>();
                            builder.RegisterType<NotificationService>().As<INotificationService>();
                            builder.RegisterType<LoggingService>().As<ILoggingService>();

                            builder.RegisterType<ServiceLocator>().As<IServiceLocator>();

                            Container = builder.Build();

                            Commerce3 commerce3 = Container.Resolve<Commerce3>();

                            commerce3.ProcessOrder(orderInfo);
                            
                            #endregion

                            break;
                        
                        case "4":
                            #region lifetime scope & singleton (Commerce4)
                            
                            builder.RegisterType<Commerce4>();

                            builder.RegisterType<BillingService>().As<IBillingService>().InstancePerLifetimeScope();
                            builder.RegisterType<InventoryService>().As<IInventoryService>().InstancePerLifetimeScope();
                            builder.RegisterType<NotificationService>().As<INotificationService>().InstancePerLifetimeScope();
                            builder.RegisterType<LoggingService>().As<ILoggingService>().InstancePerLifetimeScope();
                            builder.RegisterType<ServiceLocator2>().As<IServiceLocator2>();

                            //builder.RegisterType<SingleTester>().As<ISingleTester>();
                            builder.RegisterType<SingleTester>().As<ISingleTester>().SingleInstance();

                            Container = builder.Build();

                            #region sample lifetime scope resolving
                            //using (ILifetimeScope scope = Container.BeginLifetimeScope())
                            //{
                            //    Commerce4 scopedCommerce = scope.Resolve<Commerce4>();
                            //}
                            
                            // if dependencies were 'Disposable', they would now be disposed and released
                            // without lifetime scope, the container would hold on to disposable components
                            #endregion

                            Commerce4 commerce4 = Container.Resolve<Commerce4>();
                            commerce4.ProcessOrder(orderInfo);

                            Console.WriteLine("Press 'Enter' to process again...");
                            Console.ReadLine();

                            commerce4 = Container.Resolve<Commerce4>();
                            commerce4.ProcessOrder(orderInfo);
                            
                            #endregion

                            break;
                        
                        case "5":
                            #region assembly scanning (Commerce5)
                            
                            builder.RegisterType<Commerce5>();

                            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                                .Where(t => t.Name.EndsWith("Service"))
                                .As(t => t.GetInterfaces().FirstOrDefault(i => i.Name == "I" + t.Name));

                            Container = builder.Build();

                            Commerce5 commerce5 = Container.Resolve<Commerce5>();

                            commerce5.ProcessOrder(orderInfo);
                            
                            #endregion

                            break;
                        
                        case "6":
                            #region module usage (Commerce6)
                            
                            builder.RegisterType<Commerce6>();

                            builder.RegisterModule<ServicesRegistrationModule>();

                            Container = builder.Build();

                            Commerce6 commerce6 = Container.Resolve<Commerce6>();

                            commerce6.ProcessOrder(orderInfo);
                            
                            #endregion

                            break;
                        
                        case "7":
                            #region one-to-many (Commerce7)
                            
                            builder.RegisterType<Commerce7>();

                            // Individual types' registrations
                            //builder.RegisterType<BillingService>().As<IBillingService>();
                            //builder.RegisterType<InventoryService>().As<IInventoryService>();
                            //builder.RegisterType<NotificationService>().As<INotificationService>();
                            //builder.RegisterType<LoggingService>().As<ILoggingService>();

                            // Assembly types' registration
                            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                                .Where(t => t.Name.EndsWith("Service"))
                                .As(t => t.GetInterfaces().FirstOrDefault(i => i.Name == "I" + t.Name));

                            //builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                            //    .Where(t => t.Name.StartsWith("Service"))
                            //    .As(t => t.GetInterfaces().FirstOrDefault(i => i.Name == "I" + t.Name));

                            builder.RegisterType<ServiceLocator>().As<IServiceLocator>();

                            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                                .Where(t => t.Name.StartsWith("Plugin"))
                                .As<IPostOrderPlugin>();

                            Container = builder.Build();

                            Commerce7 commerce7 = Container.Resolve<Commerce7>();

                            commerce7.ProcessOrder(orderInfo);
                            
                            #endregion

                            break;
                        
                        case "8":
                            #region post-construction resolve & property injection (Commerce8)
                            
                            //builder.RegisterType<Commerce8>().PropertiesAutowired();

                            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                                .Where(t => t.Name.EndsWith("Service"))
                                .As(t => t.GetInterfaces().FirstOrDefault(i => i.Name == "I" + t.Name));

                            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                                .Where(t => t.Name.StartsWith("Plugin"))
                                .As<IPostOrderPlugin>();

                            builder.RegisterType<ServiceLocator>().As<IServiceLocator>();
                            
                            Container = builder.Build();

                            Commerce8 commerce8 = new Commerce8();
                            //Commerce8 commerce8 = Container.Resolve<Commerce8>();

                            commerce8.ProcessOrder(orderInfo);
                            
                            #endregion

                            break;
                        
                        case "9":
                            #region constructor finder (Commerce9)
                            
                            //builder.RegisterType<Commerce9>().WithParameters(new List<Autofac.Core.Parameter>() {
                            //new NamedParameter("a", 1), 
                            //new NamedParameter("b", 1),
                            //new NamedParameter("c", 1), 
                            //new NamedParameter("d", 1) });
                            
                            #region fix
                            builder.RegisterType<Commerce9>().WithParameters(
                                new List<Parameter> {
                                    new NamedParameter("a", 1), 
                                    new NamedParameter("b", 1),
                                    new NamedParameter("c", 1), 
                                    new NamedParameter("d", 1) 
                                }).FindConstructorsWith(new AwesomeConstructorFinder());
                            #endregion
                            
                            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                                .Where(t => t.Name.EndsWith("Service"))
                                .As(t => t.GetInterfaces().FirstOrDefault(i => i.Name == "I" + t.Name));
                            
                            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                                .Where(t => t.Name.StartsWith("Plugin"))
                                .As<IPostOrderPlugin>();
                            
                            builder.RegisterType<ServiceLocator>().As<IServiceLocator>();

                            Container = builder.Build();

                            Commerce9 commerce9 = Container.Resolve<Commerce9>();

                            commerce9.ProcessOrder(orderInfo);
                            
                            #endregion

                            break;
                    }

                    Container.Dispose();

                    Console.WriteLine();
                    Console.WriteLine("Press 'Enter' for menu.");
                    Console.ReadLine();
                    Console.Clear();
                }
            }
        }
    }
}
