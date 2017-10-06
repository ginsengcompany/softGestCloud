using System;
using Newtonsoft.Json.Linq;
using PushNotification.Plugin;
using PushNotification.Plugin.Abstractions;

namespace SoftGestCloud.Droid
{
	public class CrossPushNotificationListener : IPushNotificationListener

	{
		public CrossPushNotificationListener()
		{
		}

		public void OnError(string message, DeviceType deviceType)
		{

		}

		public void OnMessage(global::Newtonsoft.Json.Linq.JObject values, DeviceType deviceType)
		{
			App.OnNotification(values);
		}

		public void OnRegistered(string token, DeviceType deviceType)
		{
			App.Impronta = token;
		}

		public void OnUnregistered(DeviceType deviceType)
		{

		}

		public bool ShouldShowNotification()
		{
			return true;
		}
	}
}
