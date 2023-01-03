using System;
using System.Windows;

namespace EventManagement.Demo.Dialogs;

public partial class DatePickDialog : Window
{
    public DatePickDialog() => InitializeComponent();

    public DateTime SelectedDate { get; set; } = new();

    private void OkButton_Click(object sender, RoutedEventArgs e)
    {
        if (EventDatePicker.SelectedDate != null)
            SelectedDate= (DateTime)EventDatePicker.SelectedDate;

        this.DialogResult = true;
    }

    private void CancelButton_Click(object sender, RoutedEventArgs e) =>
        this.DialogResult = false;
}
