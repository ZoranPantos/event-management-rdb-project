using EventManagement.Demo.Dialogs;
using EventManagement.Demo.Models;
using EventManagement.Demo.ViewModels;

namespace EventManagement.Demo.Commands;

public class AddLocationCommand : CommandBase
{
    private CreateEventViewModel viewModel;

    public AddLocationCommand(CreateEventViewModel viewModel)
    {
        this.viewModel = viewModel;
    }

    public override void Execute(object? parameter)
    {
        var addLocationDialog = new AddLocationDialog();

        if (addLocationDialog.ShowDialog() == false)
            return;

        viewModel.TmpLocation = addLocationDialog.Location;
        viewModel.Location = addLocationDialog.Location.ToString();
    }
}
