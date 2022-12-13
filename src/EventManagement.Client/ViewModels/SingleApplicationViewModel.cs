using EventManagement.Demo.DTOs;
using System;

namespace EventManagement.Demo.ViewModels;

public class SingleApplicationViewModel : ViewModelBase
{
    private readonly SingleApplicationDTO applicationDTO;

    public int UserId => applicationDTO.UserId;
    public int EventId => applicationDTO.EventId;
    public string Group => applicationDTO.Group;
    public string Event => applicationDTO.Event;
    public DateTime EventDate => applicationDTO.EventDate;

    public SingleApplicationViewModel(SingleApplicationDTO applicationDTO) =>
        this.applicationDTO = applicationDTO;
}