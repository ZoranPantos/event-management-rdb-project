using EventManagement.Demo.Models;
using System;
using System.Windows;

namespace EventManagement.Demo.Dialogs;

public partial class AddLocationDialog : Window
{
    public Location Location { get; set; } = new();

    public AddLocationDialog() => InitializeComponent();

    private void OkButton_Click(object sender, RoutedEventArgs e)
    {
        Location.City = CityTextBox.Text;
        Location.Street = StreetTextBox.Text;
        
        try
        {
            Location.Number = Convert.ToInt32(NumberTextBox.Text);
            Location.Latitude = Convert.ToDecimal(LatitudeTextBox.Text);
            Location.Longitude = Convert.ToDecimal(LongitudeTextBox.Text);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);

            this.DialogResult = false;
            return;
        }

        this.DialogResult = true;
    }

    private void CancelButton_Click(object sender, RoutedEventArgs e) =>
        this.DialogResult = false;
}
