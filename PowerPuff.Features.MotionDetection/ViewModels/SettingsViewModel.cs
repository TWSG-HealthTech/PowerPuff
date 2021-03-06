﻿using PowerPuff.Features.MotionDetection.Models;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PowerPuff.Features.MotionDetection.ViewModels
{
    public class SettingsViewModel
    {
        private readonly IMotionDetectionModel _motionDetectionModel;

        public SettingsViewModel(IMotionDetectionModel motionDetectionModel)
        {
            _motionDetectionModel = motionDetectionModel;
            Durations.Add(new DurationOption {TimeText = "10 Seconds", Duration = TimeSpan.FromSeconds(10)});
            Durations.Add(new DurationOption {TimeText = "10 Minutes", Duration = TimeSpan.FromMinutes(10)});
            Durations.Add(new DurationOption {TimeText = "30 Minutes", Duration = TimeSpan.FromMinutes(30)});
            Durations.Add(new DurationOption {TimeText = "1 Hour", Duration = TimeSpan.FromHours(1)});
            Durations.Add(new DurationOption {TimeText = "10 Hours", Duration = TimeSpan.FromHours(10)});
            Durations.Add(new DurationOption {TimeText = "24 Hours", Duration = TimeSpan.FromHours(24)});
            Durations.Add(new DurationOption {TimeText = "48 Hours", Duration = TimeSpan.FromHours(48)});

            SelectedDuration = Durations.FirstOrDefault(d => d.Duration == _motionDetectionModel.TimeOut);

            DurationSelectionChanged = DelegateCommand.FromAsyncHandler(UpdateSelection);
        }

        public DelegateCommand DurationSelectionChanged { get; private set; }

        private Task UpdateSelection()
        {
            _motionDetectionModel.TimeOut = SelectedDuration.Duration;
            return Task.CompletedTask;
        }

        public List<DurationOption> Durations { get; } = new List<DurationOption>();

        public DurationOption SelectedDuration { get; set; }
    }

    public struct DurationOption
    {
        public string TimeText { get; set; }
        public TimeSpan Duration { get; set; } 
    }
}
