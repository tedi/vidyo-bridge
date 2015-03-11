using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
//using VidyoClient;
using System.Runtime.InteropServices;

namespace VideoApp
{
	[Activity (Label = "Video App", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
	
//		typedef void *VidyoVoidPtr;

		unsafe public void callEvents(VidyoClientOutEvent passedEvent,
							   void* param,
							   uint paramSize,
							   void* data)
		{
			Console.WriteLine ("--------------got here!");
		}

		unsafe delegate void VidyoClientOutEventCallback(VidyoClientOutEvent passedEvent,
												  void* param,
												  uint paramSize,
												  void* data);
			

		int count = 1;

		[DllImport("VidyoClientApp")]
		unsafe public extern static bool VidyoClientInitialize (Delegate VidyoClientOutEventCallback,
														void* data,
		                                                VidyoClientLogParams* logParams);

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			
			Console.WriteLine ("========================");
//			Java.Lang.JavaSystem.LoadLibrary ("VidyoClientApp");

			// Can be null
			// Log Struct
			VidyoClientLogParams logParams = new VidyoClientLogParams ();

//			VidyoClientOutEvent myEvent = new VidyoClientOutEvent ();

			Console.WriteLine ("Getting there========================");
			unsafe {
				void* data;
				VidyoClientOutEventCallback delegateToPass = new VidyoClientOutEventCallback(callEvents);
				// Should come back as VIDYO_FALSE or VIDYO_TRUE)
				if (VidyoClientInitialize (delegateToPass, &data, &logParams) == false) {
					Console.WriteLine ("Could not initialize connection");
				} else {
					Console.WriteLine ("Connection initialized!");
				}
			}
				
			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			// Get our button from the layout resource,
			// and attach an event to it
			Button button = FindViewById<Button> (Resource.Id.myButton);
			
			button.Click += delegate {
				button.Text = string.Format ("{0} clicks!", count++);
			};
			Button testB = FindViewById<Button> (Resource.Id.testButton);

			testB.Click += delegate {
				testB.Text = string.Format ("{0} clicks!", count++);
				Console.WriteLine("Writing debugging click: {0}", count);
			};


		}
	}
}


