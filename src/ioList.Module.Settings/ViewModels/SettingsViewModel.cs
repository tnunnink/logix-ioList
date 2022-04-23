﻿using System;
using System.Collections.Generic;
using CoreTools.WPF.Mvvm;
using ioList.Domain;
using ioList.Module.Settings.Views;
using ioList.Observers;
using ioList.Services;
using Prism.Commands;
using Prism.Regions;
using Prism.Services.Dialogs;

namespace ioList.Module.Settings.ViewModels
{
    public class SettingsViewModel : DialogViewModelBase
    {
        private readonly IListBuilder _builder;

        private static readonly List<string> SettingsViews = new()
        {
            nameof(FileSettingsView),
            nameof(ModuleSettingsView),
            nameof(FilterSettingsView),
            nameof(BufferSettingsView),
            nameof(ScalingSettingsView)
        };

        private int _selectedIndex;
        private DelegateCommand _saveCommand;

        public SettingsViewModel(IListBuilder builder)
        {
            _builder = builder;
            Settings = new SettingsObserver(new ListOption());
        }

        public override DelegateCommand SaveCommand => _saveCommand ??=
            new DelegateCommand(ExecuteSaveCommand, ExecuteCanSaveCommand)
                .ObservesProperty(() => Settings.HasErrors)
                .ObservesProperty(() => Settings.IsChanged);

        public int SelectedIndex
        {
            get => _selectedIndex;
            set
            {
                SetProperty(ref _selectedIndex, value);
                NavigateSetting(_selectedIndex);
            }
        }

        public SettingsObserver Settings { get; }

        protected override bool ExecuteCanSaveCommand()
        {
            return !string.IsNullOrEmpty(Settings.Name) 
                   && !string.IsNullOrEmpty(Settings.Directory) 
                   && !string.IsNullOrEmpty(Settings.SourceFile);
        }

        protected override void ExecuteSaveCommand()
        {
            try
            {
            }
            catch (Exception e)
            {
                //log error
                RaiseRequestClose(new DialogResult(ButtonResult.Abort));
            }

            RaiseRequestClose(new DialogResult(ButtonResult.OK));
        }

        public override void OnDialogOpened(IDialogParameters parameters)
        {
            SelectedIndex = 0;
        }

        private void NavigateSetting(int index)
        {
            var viewName = SettingsViews[index];

            var parameters = new NavigationParameters { { "Option", Settings } };

            RegionManager?.RequestNavigate("ContentRegion", viewName, parameters);
        }
    }
}