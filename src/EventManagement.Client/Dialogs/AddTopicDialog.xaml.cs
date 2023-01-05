using EventManagement.Demo.Models;
using System.Windows;

namespace EventManagement.Demo.Dialogs;

public partial class AddTopicDialog : Window
{
    public Topic Topic { get; set; } = new();

    public AddTopicDialog() => InitializeComponent();

    private void OkButton_Click(object sender, RoutedEventArgs e)
    {
        Topic.Title = NameTextBox.Text;
        Topic.Description = DescriptionTextBox.Text;

        this.DialogResult = true;
    }

    private void CancelButton_Click(object sender, RoutedEventArgs e) =>
        this.DialogResult = false;
}
