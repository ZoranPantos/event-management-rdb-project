using EventManagement.Demo.Dialogs;
using EventManagement.Demo.ViewModels;
using System;

namespace EventManagement.Demo.Commands;

public class AddSponsorCommand : CommandBase
{
    private CreateEventViewModel viewModel;

    public AddSponsorCommand(CreateEventViewModel viewModel) =>
        this.viewModel = viewModel;

    public override void Execute(object? parameter)
    {
        var addSponsorDialog = new AddSponsorDialog();

        if (addSponsorDialog.ShowDialog() == false)
            return;

        viewModel.SponsorDTOs.Add(addSponsorDialog.SponsorDTO);
        viewModel.Sponsors += $"{addSponsorDialog.SponsorDTO.Sponsor.Name} ({addSponsorDialog.SponsorDTO.MoneyProvided})   ";
    }
}
