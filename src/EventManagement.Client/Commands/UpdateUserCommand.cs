﻿using EventManagement.Demo.Infrastructure.Repositories;
using EventManagement.Demo.Stores;
using EventManagement.Demo.ViewModels;
using System;
using System.ComponentModel;

namespace EventManagement.Demo.Commands;

public class UpdateUserCommand : CommandBase
{
    private readonly NavigationStore navigationStore;
    private readonly Func<ViewModelBase> createViewModel;

    private readonly UpdateProfileViewModel updateProfileViewModel;
    private readonly IEventManagementRepository eventManagementRepository;

    public UpdateUserCommand(
        UpdateProfileViewModel updateProfileViewModel,
        IEventManagementRepository eventManagementRepository,
        NavigationStore navigationStore,
        Func<ViewModelBase> createViewModel)
    {
        this.updateProfileViewModel = updateProfileViewModel;
        this.eventManagementRepository = eventManagementRepository;
        this.navigationStore = navigationStore;
        this.createViewModel = createViewModel;

        updateProfileViewModel.PropertyChanged += OnViewModelPropertyChanged;
    }

    private void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName.Equals(nameof(UpdateProfileViewModel.FirstName)) ||
            e.PropertyName.Equals(nameof(UpdateProfileViewModel.LastName)))
        {
            OnCanExecuteChanged();
        }
    }

    public override void Execute(object? parameter)
    {
        // TODO: get this user id from some upper layers
        eventManagementRepository.UpdateUserWithId(2, updateProfileViewModel);

        // After the message box dialog is completed
        navigationStore.CurrentViewModel = createViewModel();
    }

    public override bool CanExecute(object? parameter)
    {
        return !string.IsNullOrEmpty(updateProfileViewModel.FirstName) &&
            !string.IsNullOrEmpty(updateProfileViewModel.LastName) &&
            base.CanExecute(parameter);
    }
}
