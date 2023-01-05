using EventManagement.Demo.DTOs;
using System;
using System.Windows;

namespace EventManagement.Demo.Dialogs;

public partial class AddSponsorDialog : Window
{
    public SponsorWithMoneyDTO SponsorDTO { get; set; } = new();

    public AddSponsorDialog() => InitializeComponent();

    private void OkButton_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            SponsorDTO.Sponsor = new();

            SponsorDTO.Sponsor.Name = NameTextBox.Text;
            SponsorDTO.Sponsor.DomainOfWork = DomainTextBox.Text;
            SponsorDTO.Sponsor.CurrentCEO = CeoTextBox.Text;
            SponsorDTO.Sponsor.EstablishmentYear = Convert.ToInt32(EstablishmentTextBox.Text);
            SponsorDTO.Sponsor.Headquarters = HeadquartersTextBox.Text;
            SponsorDTO.Sponsor.Motto = MottoTextBox.Text;
            SponsorDTO.Sponsor.Email = EmailTextBox.Text;

            SponsorDTO.MoneyProvided = Convert.ToDecimal(MoneyTextBox.Text);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }

        this.DialogResult = true;
    }

    private void CancelButton_Click(object sender, RoutedEventArgs e) =>
        this.DialogResult = false;
}
