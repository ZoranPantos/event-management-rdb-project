using EventManagement.Demo.Commands;
using EventManagement.Demo.DTOs;
using EventManagement.Demo.Infrastructure.Repositories;
using System;
using System.Windows.Input;

namespace EventManagement.Demo.ViewModels;

public class SingleForthcomingEventViewModel : ViewModelBase
{
    private readonly ForthcomingEventDTO airingEventDTO;

    public int EventId => airingEventDTO.EventId;
    public string Title => airingEventDTO.EventTitle;
    public string Description => airingEventDTO.Description;
    public string GroupName => airingEventDTO.GroupName;
    public DateTime AiringDate => airingEventDTO.Date;
    public string DailySchedule => airingEventDTO.DailySchedule;
    public string Topics => airingEventDTO.Topics;
    public string Sponsors => airingEventDTO.Sponsors;

    public string FullAddress { get; set; } = string.Empty;

    public ICommand ApplyToEventCommand { get; }

    public SingleForthcomingEventViewModel(ForthcomingEventDTO airingEventDTO, IEventManagementRepository repository)
    {
        this.airingEventDTO = airingEventDTO;

        FullAddress = $"{this.airingEventDTO.City}, {this.airingEventDTO.Street}, {this.airingEventDTO.Number}";

        ApplyToEventCommand = new ApplyToEventCommand(2, EventId, repository);
        
    }
}
