using Android.App;
using Android.Runtime;
using Android.OS;
using Android.Provider;
using Android.Content;
using static Android.Provider.Settings;
using MobileToDoList.Helper;

namespace MobileToDoList
{
    [Application]
    public class MainApplication : MauiApplication
    {
        public MainApplication(IntPtr handle, JniHandleOwnership ownership)
            : base(handle, ownership)
        {
            GetConnectedDeviceId();
            
            
        }

        public string GetConnectedDeviceId()
        {
            var context = Android.App.Application.Context;
            string id = Android.Provider.Settings.Secure.GetString(context.ContentResolver, Secure.AndroidId);
            ApplicationHelper.deviceId = id;
            return id;
        }
        protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();
    }
}