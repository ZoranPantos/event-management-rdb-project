﻿using EventManagement.Demo.ViewModels;
using System.Windows;

namespace EventManagement.Client;

public partial class App : Application
{
    protected override void OnStartup(StartupEventArgs e)
    {
        MainWindow = new MainWindow()
        {
            DataContext = new MainViewModel()
        };

        MainWindow.Show();

        base.OnStartup(e);
    }
}
