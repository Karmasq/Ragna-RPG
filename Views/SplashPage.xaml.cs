using Microsoft.Maui.Controls;
using System.Threading.Tasks;

namespace Ragna_RPG.Views
{
    public partial class SplashPage : ContentPage
    {
        public SplashPage()
        {
            InitializeComponent();
            AnimateLogo();
            NavigateToStartPage();
        }

        private async void AnimateLogo()
        {
            await LogoImage.FadeTo(1, 4000); // Fade in over 4 seconds
        }

        private async void NavigateToStartPage()
        {
            // Wait for 5 seconds
            await Task.Delay(5000);
            // Navigate to StartPage
            await Shell.Current.GoToAsync("//StartPage");
        }
    }
}
