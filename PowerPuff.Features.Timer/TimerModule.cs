﻿using Autofac;
using PowerPuff.Common;
using PowerPuff.Common.Helpers;
using PowerPuff.Common.Speech;
using PowerPuff.Features.Timer.Model;
using PowerPuff.Features.Timer.Sound;
using PowerPuff.Features.Timer.Speech;
using PowerPuff.Features.Timer.ViewModels;
using PowerPuff.Features.Timer.Views;
using Prism.Autofac;
using Prism.Modularity;
using Prism.Mvvm;
using Prism.Regions;

namespace PowerPuff.Features.Timer
{
    public class TimerModule : IModule
    {
        private readonly IContainer _container;
        private readonly IRegionManager _regionManager;

        public TimerModule(IRegionManager regionManager, IContainer container)
        {
            _regionManager = regionManager;
            _container = container;
        }

        public void Initialize()
        {
            ConfigureDependencies();

            _regionManager.RegisterViewWithRegion(RegionNames.MainButtonsRegion, typeof(TimerMainButtonView));

            ViewModelLocationProvider.SetDefaultViewModelFactory(type => _container.Resolve(type));
        }

        private void ConfigureDependencies()
        {
            var updater = new ContainerBuilder();

            updater.RegisterType<TimerMainViewModel>().SingleInstance();
            updater.RegisterType<TimerMainButtonViewModel>().SingleInstance();
            updater.RegisterType<TimerIntentHandler>().As<IIntentHandler>().SingleInstance();
            updater.RegisterType<TimerModel>().SingleInstance();
            updater.RegisterType<Model.Timer>().As<ITimer>().SingleInstance();
            updater.RegisterType<Alerter>().As<IAlerter>().SingleInstance();

            updater.RegisterTypeForNavigation<TimerMainView>(NavigableViews.Timer.MainView.GetFullName());

            updater.Update(_container);
        }
    }
}
