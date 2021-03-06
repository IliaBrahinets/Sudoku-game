﻿using System;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Web.Configuration;
using System.Web.Http;
using AutoMapper;
using FluentValidation;
using FluentValidation.WebApi;
using NLog;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using SimpleInjector.Lifestyles;

namespace EntertainmentPortal.Web
{
    public static class InjectorConfig
    {
        public static void Configure(HttpConfiguration config)
        {
            var container = new Container();
            container.Options.DefaultLifestyle = new AsyncScopedLifestyle();

            container.RegisterPackages(GetAssemblies());

            RegisterConfiguration(container);
            MapperSetup(container);
            ValidationSetup(config, container);
            LoggerSetup(container);

            container.RegisterWebApiControllers(config);
            container.Verify(VerificationOption.VerifyOnly);
            config.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);
        }

        private static void RegisterConfiguration(Container container)
        {
            container.Register<Configuration>(() =>
            {
                return WebConfigurationManager.OpenWebConfiguration("/");
            }, Lifestyle.Singleton);
        }

        private static Assembly[] GetAssemblies()
        {
            return AppDomain.CurrentDomain.GetAssemblies().Where(asm =>
                asm.FullName.StartsWith("EntertainmentPortal", StringComparison.OrdinalIgnoreCase)).ToArray();
        }

        private static void MapperSetup(Container container)
        {
            Mapper.Initialize(config => config.AddProfiles(GetAssemblies()));
            Mapper.AssertConfigurationIsValid();
            var mapper = Mapper.Configuration.CreateMapper(container.GetInstance);
            container.RegisterInstance(typeof(IMapper), mapper);
        }

        private static void ValidationSetup(HttpConfiguration config, Container container)
        {
            FluentValidationModelValidatorProvider.Configure(config, provider => provider.ValidatorFactory = new SimpleInjectorFactory(container));
            AssemblyScanner.FindValidatorsInAssemblies(GetAssemblies()).ForEach(result =>
                container.Register(result.InterfaceType, result.ValidatorType));
        }

        private static void LoggerSetup(Container container)
        {
            container.RegisterInstance<ILogger>(LogManager.GetLogger("Logger sample"));
        }
    }

    public class SimpleInjectorFactory : IValidatorFactory
    {
        private readonly Container _container;

        public SimpleInjectorFactory(Container container)
        {
            _container = container;
        }

        public IValidator<T> GetValidator<T>()
        {
            try
            {
                return (IValidator<T>)_container.GetInstance(typeof(T));
            }
            catch (Exception)
            {
                return null;
            }
        }

        public IValidator GetValidator(Type type)
        {
            try
            {
                return (IValidator)_container.GetInstance(type);
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}