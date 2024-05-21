using Microsoft.Maui.Controls;
using System;
using System.Threading.Tasks;
using Plugin.Maui.Audio;

namespace Ragna_RPG.Views
{
    public partial class StartPage : ContentPage
    {
        private readonly IAudioManager _audioManager;
        private IAudioPlayer _audioPlayer;

        public StartPage()
        {
            InitializeComponent();
            _audioManager = AudioManager.Current;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            LoadAudio();
            AnimateElements();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            _audioPlayer?.Stop();
        }

        private async void AnimateElements()
        {
            // Reset Opacity and Scale
            LogoImage.Opacity = 0;
            LogoImage.Scale = 0;
            CustomButtonImage.Opacity = 0;
            CustomButtonImage.Scale = 0;
            PlayButton.Opacity = 0;
            PlayButton.Scale = 0;
            ExitButton.Opacity = 0;
            ExitButton.Scale = 0;

            // Animate logo and custom button image
            await Task.WhenAll(
                LogoImage.FadeTo(1, 2000),
                LogoImage.ScaleTo(1, 2000),
                CustomButtonImage.FadeTo(1, 2000),
                CustomButtonImage.ScaleTo(1, 2000)
            );

            // Animate buttons after logo and custom button
            await Task.WhenAll(
                PlayButton.FadeTo(1, 1000),
                PlayButton.ScaleTo(1, 1000),
                ExitButton.FadeTo(1, 1000),
                ExitButton.ScaleTo(1, 1000)
            );
        }

        private async void LoadAudio()
        {
            try
            {
                var audioFile = "RagnaRPGTheme.m4a";
                var stream = await FileSystem.OpenAppPackageFileAsync(audioFile);
                if (stream != null)
                {
                    _audioPlayer = _audioManager.CreatePlayer(stream);
                    _audioPlayer.Play();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception while loading audio: {ex.Message}");
            }
        }

        private async void OnPlayButtonClicked(object sender, EventArgs e)
        {
            // Navegar a la página del juego
            _audioPlayer?.Stop();
            await Shell.Current.GoToAsync(nameof(MainPage));
        }

        private void OnExitButtonClicked(object sender, EventArgs e)
        {
            // Cerrar la aplicación
            _audioPlayer?.Stop();
            System.Diagnostics.Process.GetCurrentProcess().CloseMainWindow();
        }
    }
}
