﻿using EventManagement.Demo.Commands;
using EventManagement.Demo.DTOs;
using EventManagement.Demo.Infrastructure.Repositories;
using EventManagement.Demo.Stores;
using System.Windows.Input;

namespace EventManagement.Demo.ViewModels;

public class SingleGroupViewModel : ViewModelBase
{
    private readonly SingleGroupDTO groupDTO;

    public int GroupId => groupDTO.GroupId;
    public string Group => groupDTO.Title;

    public ICommand VisitGroupCommand { get; }

    public SingleGroupViewModel(SingleGroupDTO groupDTO, IEventManagementRepository repository, NavigationStore navigationStore)
    {
        this.groupDTO = groupDTO;

        // When I add the CRUD for events from group view, I should probably have some kind of "navigate back" function here
        VisitGroupCommand = new NavigateCommand(navigationStore, () => new GroupDetailsViewModel(GroupId, repository));
    }
}
