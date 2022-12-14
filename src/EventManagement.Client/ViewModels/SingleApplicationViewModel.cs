using EventManagement.Demo.Commands;
using EventManagement.Demo.DTOs;
using EventManagement.Demo.Infrastructure.Repositories;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace EventManagement.Demo.ViewModels;

public class SingleApplicationViewModel : ViewModelBase
{
    private readonly SingleApplicationDTO applicationDTO;

    public int UserId => applicationDTO.UserId;
    public int EventId => applicationDTO.EventId;
    public string Group => applicationDTO.Group;
    public string Event => applicationDTO.Event;
    public DateTime EventDate => applicationDTO.EventDate;

    public ICommand RemoveCommand { get; }

    public SingleApplicationViewModel(
        SingleApplicationDTO applicationDTO,
        IEventManagementRepository repository,
        ObservableCollection<SingleApplicationViewModel> applications)
    {
        this.applicationDTO = applicationDTO;

        RemoveCommand = new RemoveApplicationCommand(UserId, EventId, repository, applications, this);
    }
}