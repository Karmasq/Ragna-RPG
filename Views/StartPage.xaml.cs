using Microsoft.Maui.Controls;

namespace Ragna_RPG.Views
{
    public partial class StartPage : ContentPage
    {
        public StartPage()
        {
            InitializeComponent();
        }

        private async void OnPlayClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }

        private async void OnOptionsClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new OptionsPage());
        }

        private void OnExitClicked(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }
    }
}
