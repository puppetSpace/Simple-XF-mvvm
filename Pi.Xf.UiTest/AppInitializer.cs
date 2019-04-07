using System;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace Pi.Xf.UiTest
{
    public class AppInitializer
    {
        public static IApp StartApp(Platform platform)
        {
            if (platform == Platform.Android)
            {
                return ConfigureApp
                    .Android
                    .ApkFile("../../../Pi.Xf.AppTest/Pi.Xf.AppTest.Android/bin/Release/com.companyname.Pi.Xf.AppTest.apk")
                    .StartApp();
            }

            return ConfigureApp.iOS.StartApp();
        }
    }
}