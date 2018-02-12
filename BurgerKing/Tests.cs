using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;
using System.Threading;

namespace BurgerKing
{
	[TestFixture(Platform.Android)]
	[TestFixture(Platform.iOS)]
	public class Tests
	{
		IApp app;
		Platform platform;

		public Tests(Platform platform)
		{
			this.platform = platform;
		}

		[SetUp]
		public void BeforeEachTest()
		{
			app = AppInitializer.StartApp(platform);
			app.Screenshot("App Launched");
		}

		[Test]
		public void Repl()
		{
			app.Repl();
		}

		[Test]
		public void FirstTest()
		{
			app.Tap(x => x.Class("XWalkCordovaView").Css(".text-center").Index(1));
			app.Screenshot("Let's start by Tapping on the Zip Code Field");
			app.ClearText();
			app.Screenshot("Then we cleared the Zip Code");
			app.EnterText("94111");
			app.Screenshot("Next we entered our Zip Code, '94111'");
			app.DismissKeyboard();
			app.Screenshot("Dismissed Keyboard");
			app.Tap(x => x.Class("XWalkCordovaView").Css(".button.button-theme-unified.ng-binding"));
			app.Screenshot("We Tapped on the Continue Button");

			app.Tap(x => x.Class("XWalkCordovaView").Css(".skip.ng-binding"));
			app.Screenshot("Then we Tapped the 'Skip Button'");

			app.Tap(x => x.Class("XWalkCordovaView").Css(".tab-item.ng-binding").Index(1));
			app.Screenshot("We Tapped on the 'Menu' Tab");

			app.Tap(x => x.Class("XWalkCordovaView").Css(".col.col-center.text-center.col-title.ng-binding"));
			app.Screenshot("Then we Tapped on 'Sandwiches'");

			app.Tap(x => x.Class("XWalkCordovaView").Css(".col.col-50.col-center.col-title"));
			app.Screenshot("Next we Tapped on 'Sausage, Egg, and Cheese'");

         

			Thread.Sleep(8000);
			app.ScrollDown();
			app.Screenshot("Then we Scrolled Down for more information");
		}

	}
}
