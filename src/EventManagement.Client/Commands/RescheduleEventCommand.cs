using EventManagement.Demo.Dialogs;
using EventManagement.Demo.Infrastructure.Repositories;
using EventManagement.Demo.ViewModels;
using System;
using System.Windows;

namespace EventManagement.Demo.Commands;

public class RescheduleEventCommand : CommandBase
{
    private readonly EventDetailsViewModel currentViewModel;
    private readonly IEventManagementRepository repository;
    private readonly DateTime currentEventDate;
    private readonly int eventId;

    public RescheduleEventCommand(
        DateTime currentEventDate,
        IEventManagementRepository repository,
        int eventId,
        EventDetailsViewModel currentViewModel)
    {
        this.currentEventDate = currentEventDate;
        this.repository = repository;
        this.eventId = eventId;
        this.currentViewModel = currentViewModel;
    }

    public override void Execute(object? parameter)
    {
        var datePickDialog = new DatePickDialog();

        if (datePickDialog.ShowDialog() == false)
            return;
        
        var selectedDate = datePickDialog.SelectedDate;

        if (selectedDate <= DateTime.Now)
        {
            MessageBox.Show("Event cannot be resheculed to this date");
            return;
        }

        repository.RescheduleEvent(eventId, selectedDate);
        currentViewModel.Date = selectedDate;
    }
}
