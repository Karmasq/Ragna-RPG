using System;
using Microsoft.Maui.Controls;
using Ragna_RPG.Views;

namespace Ragna_RPG
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
            Routing.RegisterRoute(nameof(StartPage), typeof(StartPage));
            Routing.RegisterRoute(nameof(OptionsPage), typeof(OptionsPage));
            Routing.RegisterRoute(nameof(SplashPage), typeof(SplashPage));
        }
    }
}
