using AdSupport;
using Foundation;
using MobileToDoList.Helper;

namespace MobileToDoList
{
    [Register("AppDelegate")]
    public class AppDelegate : MauiUIApplicationDelegate
    {
        public void getDeviceId()
        {
            NSUuid adId = ASIdentifierManager.SharedManager.AdvertisingIdentifier;
            ApplicationHelper.deviceId = adId.ToString();
        }
        protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();
    }
}