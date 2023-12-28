using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Graphics;
using Android.OS;

namespace MobileToDoList
{

    [Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
    public class MainActivity : MauiAppCompatActivity
    {
        public void OnCreate(Bundle bundle,string imagePath)
        {
            base.OnCreate(bundle);


            // Fotoğraf yolunun boş olup olmadığını kontrol edin
            if (!string.IsNullOrEmpty(imagePath))
            {
                // Fotoğraf yolunu WallpaperManager'a ayarlamak için asenkron bir metot çağırın
                Task.Run(() => SetWallpaperAsync(imagePath));
            }
        }
        private async Task SetWallpaperAsync(string imagePath)
        {
            var bitmap = await BitmapFactory.DecodeFileAsync(imagePath);

            RunOnUiThread(() =>
            {
                var wallpaperManager = WallpaperManager.GetInstance(this.ApplicationContext);
                wallpaperManager.SetBitmap(bitmap);
            });
        }
        public void SetWindowBackground(string imagePath)
        {
            var bitmap = BitmapFactory.DecodeFile(imagePath);
            WallpaperManager.GetInstance(this).SetBitmap(bitmap);
        }

        public async Task SetWallpaperAsync(string photoPath, Context context)
        {
            if (context == null)
            {
                context = this;
            }

            var bitmap = await BitmapFactory.DecodeFileAsync(photoPath);

            try
            {
                WallpaperManager.GetInstance(context).SetBitmap(bitmap);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Wallpaper setting error: {ex.Message}");
            }
        }

    }
}