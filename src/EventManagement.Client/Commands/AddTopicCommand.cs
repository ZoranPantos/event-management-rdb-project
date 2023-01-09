using EventManagement.Demo.Dialogs;
using EventManagement.Demo.ViewModels;
using System;

namespace EventManagement.Demo.Commands;

public class AddTopicCommand : CommandBase
{
    private CreateEventViewModel viewModel;

    public AddTopicCommand(CreateEventViewModel viewModel) =>
        this.viewModel = viewModel;

    public override void Execute(object? parameter)
    {
        var addTopicDialog = new AddTopicDialog();

        if (addTopicDialog.ShowDialog() == false)
            return;

        viewModel.TmpTopics.Add(addTopicDialog.Topic);
        viewModel.Topics += $"{addTopicDialog.Topic.Title}   ";
    }
}
