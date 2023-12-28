using Android.Content;
using Android.Graphics;
using Android.Widget;
using MobileToDoList.Helper;
using MobileToDoList.Models;
using Newtonsoft.Json;

namespace MobileToDoList;

public partial class ToDoPage : ContentPage
{
	public ToDoPage()
	{
		InitializeComponent();
        deviceId.Text = ApplicationHelper.deviceId;
	}

    private async void OnSaveClicked(object sender, EventArgs e)
    {
        var loginResult = await RestHelper.LoginMethod(new Login() { username = usernameEntry.Text, password = passwordEntry.Text });

        
        if (loginResult != null)
        {
            try
            {
                var deseriliazeJson = JsonConvert.DeserializeObject<LoginResponse>(loginResult.ToString());

                if (deseriliazeJson != null)
                {
                    richTextBox.Text = deseriliazeJson.token;
                }
            }
            catch (Exception)
            {
                richTextBox.Text = loginResult.ToString();
            }
        }
        else { richTextBox.Text = "�ifre Hatas�"; }

    }
    private void OnShowPasswordClicked(object sender, EventArgs e)
    {
        passwordEntry.IsPassword = !passwordEntry.IsPassword;
    }
    private async void ReturnMainMenu(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MainPage());
    }
    private async void OnTakePhotoClicked(object sender, EventArgs e)
    {
        var result = await MediaPicker.CapturePhotoAsync();

        if (result != null)
        {
            ShowCapturedImage(result);
        }
        else
        {
            // Foto�raf �ekilemedi
        }
    }
    private async void OnTakePhotoBackgroundClicked(object sender, EventArgs e)
    {
        var result = await MediaPicker.CapturePhotoAsync();

        if (result != null)
        {
            var mainActivity = new MainActivity();
            Bitmap bitmap = BitmapFactory.DecodeFile(result.FullPath);
            mainActivity.SetWallpaper(bitmap);
            //mainActivity.OnCreate(new Android.OS.Bundle(),result.FullPath);
            //SetBackgroundImage(result.FullPath);
        }
        else
        {
            // Foto�raf �ekilemedi
        }
    }
    private void ShowCapturedImage(FileResult result)
    {
        // Kameradan �ekilen resmi ImageView kontrol�ne y�kle
        if (result != null)
        {
            var stream = result.OpenReadAsync().Result;
            var imageBytes = new byte[stream.Length];
            stream.Read(imageBytes, 0, imageBytes.Length);

            capturedImage.Source = ImageSource.FromStream(() => new MemoryStream(imageBytes));
            //ContentMainPage.BackgroundImageSource= ImageSource.FromStream(() => new MemoryStream(imageBytes));
        }
    }
    void SetBackgroundImage(string imagePath)
    {
        var currentActivity = Platform.CurrentActivity;
        var mainActivity = new MainActivity();


        Bitmap bitmap = BitmapFactory.DecodeFile(imagePath);
        mainActivity.SetWallpaper(bitmap);

        if (currentActivity is MainActivity mainActivity1)
        {
            //mainActivity.setWalpaper(imagePath);
        }
        else
        {
            // MainActivity t�r�nde bir de�er yok, hata mesaj�n� g�ster
            Toast.MakeText(currentActivity, "MainActivity is not available.", ToastLength.Short).Show();
        }
        // Arka plan resmini de�i�tirmek i�in platforma �zg� kod
        //var mainActivity = Platform.CurrentActivity as MainActivity;
        //if (mainActivity != null)
        //{
        //    mainActivity.setWalpaper(imagePath);
        //}
    }

    
}