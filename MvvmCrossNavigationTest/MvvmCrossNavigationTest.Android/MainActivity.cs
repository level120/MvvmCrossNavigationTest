using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;
using Microsoft.Extensions.Logging;
using MvvmCross.Forms.Platforms.Android.Core;
using MvvmCross.ViewModels;

namespace MvvmCrossNavigationTest.Droid
{
    [Activity(Label = "MvvmCrossNavigationTest", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize )]
    public class MainActivity : MvvmCross.Forms.Platforms.Android.Views.MvxFormsAppCompatActivity<MvxSetup, MvxApp, App>
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            Xamarin.Forms.Forms.Init(this, savedInstanceState);
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }

    public class MvxSetup : MvxFormsAndroidSetup<MvxApp, App>
    {
        protected override ILoggerProvider CreateLogProvider() => null;

        protected override ILoggerFactory CreateLogFactory() => null;
    }

    public class MvxApp : MvxApplication
    {
    }
}