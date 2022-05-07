﻿using System;
using System.Collections.ObjectModel;
using System.Linq;
using ioList.Common;
using ioList.Domain;
using ioList.Observers;
using ioList.Services;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;

namespace ioList.ViewModels
{
    public class ListViewModel : BindableBase
    {
        private readonly IListFileService _listFileService;
        private readonly IDialogService _dialogService;
        private readonly IRegionManager _regionManager;
        private DelegateCommand _createListCommand;
        private DelegateCommand _deleteListCommand;
        private ObservableCollection<ListFileObserver> _lists;
        private ListFileObserver _selectedList;

        public ListViewModel()
        {
            Lists = new ObservableCollection<ListFileObserver>
            {
                new(new ListFile("Path To File")),
                new(new ListFile("Path To File")),
                new(new ListFile("Path To File"))
            };
        }

        public ListViewModel(IListFileService listFileService,
            IDialogService dialogService, IRegionManager regionManager)
        {
            _listFileService = listFileService;
            _dialogService = dialogService;
            _regionManager = regionManager;

            Lists = new ObservableCollection<ListFileObserver>();

            Load();
        }

        public ObservableCollection<ListFileObserver> Lists
        {
            get => _lists;
            private set => SetProperty(ref _lists, value);
        }

        public ListFileObserver SelectedList
        {
            get => _selectedList;
            set
            {
                SetProperty(ref _selectedList, value);
                OpenList(_selectedList.Entity);
            }
        }

        public DelegateCommand NewListCommand =>
            _createListCommand ??= new DelegateCommand(ExecuteCreateListCommand);

        public DelegateCommand DeleteListCommand =>
            _deleteListCommand ??= new DelegateCommand(ExecuteDeleteListCommand, CanExecuteDeleteListCommand)
                .ObservesProperty(() => SelectedList);

        private void ExecuteDeleteListCommand()
        {
            var file = SelectedList.Entity;

            //todo confirmation...

            _listFileService.Remove(file);

            Load();
        }

        private bool CanExecuteDeleteListCommand()
        {
            return SelectedList is not null;
        }

        private void ExecuteCreateListCommand()
        {
            _dialogService.ShowDialog(DialogNames.NewListDialog);
        }

        private void Load()
        {
            Lists.Clear();
            var lists = _listFileService.GetAll().Select(m => new ListFileObserver(m));
            Lists = new ObservableCollection<ListFileObserver>(lists);
        }

        private void OnListCreated(ListFile file)
        {
            _listFileService.Add(file);
            Load();
            OpenList(file);
        }

        private void OpenList(ListFile listFile)
        {
            var parameters = new NavigationParameters { { "ListFile", listFile } };

            if (!listFile.Exists)
            {
                _regionManager.RequestNavigate(RegionNames.ContentRegion, "ListInvalidView", parameters);
                return;
            }

            _regionManager.RequestNavigate(RegionNames.ContentRegion, "ContentView", parameters);
        }
    }
}