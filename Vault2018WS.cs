using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using WebSocketSharp;
using WebSocketSharp.Server;
using CustomRec.GameSessions;
using CustomRec.API;
using CustomRec.Menu;
using CustomRec.Server;
using CustomRec.Storefront;
using CustomRec.Vault;

namespace CustomRec.WebSocket
{
	public class Late2018WebSock
	{
		public Late2018WebSock()
		{
			Late2018WebSock.instance = this;
			this.WebSock.AddWebSocketService<Late2018WebSock.NotificationWS>("/api/notification/v2");
			this.WebSock.AddWebSocketService<Late2018WebSock.HubWS>("/hub/v1");
			this.WebSock.Start();
			Console.WriteLine("[LateWebSocket.cs] has started.");
			Console.WriteLine("[LateWebSocket.cs] is listening.");
		}

		public void Broadcast(CustomRec.API.Notification.Reponse res)
		{
			Console.WriteLine(string.Concat(new string[]
			{
				"Broadcasting ",
				JsonConvert.SerializeObject(res),
				" to ",
				this.WebSock.WebSocketServices["/api/notification/v2"].Sessions.Count.ToString(),
				" clients."
			}));

			WebSock.WebSocketServices["/api/notification/v2"].Sessions.Broadcast(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(res)));
		}

		public static Late2018WebSock instance;

		public WebSocketServer WebSock = new WebSocketServer("ws://localhost:20161/");

		public class HubWS : WebSocketBehavior
		{
			protected override void OnMessage(MessageEventArgs e)
			{
				Console.WriteLine("LateWebSocket.cs Hub Requested.");
				base.Send(JsonConvert.SerializeObject(new Late2018WebSock.Hub()));
			}

			public HubWS()
			{
			}
		}

		public class Hub : WebSocketBehavior
		{
			public Hub()
			{
				this.accessToken = "AccessDeezNuts";
				this.SupportedTransports = new List<string>();
				this.negotiateVersion = 0;
				this.url = new Uri(string.Format("http://localhost:{0}/", "2018"));
			}

			public Uri url { get; set; }

			public string accessToken { get; set; }

			public List<string> SupportedTransports { get; set; }

			public int negotiateVersion { get; set; }
		}

		public class NotificationWS : WebSocketBehavior
		{
			protected override void OnMessage(MessageEventArgs p0)
			{
				bool flag = new WebClient().DownloadString("https://raw.githubusercontent.com/recroom2016/OpenRec/master/Update/banned.txt").Contains(File.ReadAllText("SaveData\\Profile\\userid.txt"));
				if (flag)
				{
					Console.WriteLine("You are banned from playing CustomRec. Please update your game to play.");
					Menu.Menu.isBanned = true;
					Late2018WebSock.instance.Broadcast(CustomRec.API.Notification.Reponse.createBannedResponse());
				}
				Console.WriteLine("LateWebSocket.cs Notif Requested.");
				bool flag2 = p0.Data == null;
				bool flag3 = flag2;
				bool flag4 = flag3;
				if (flag4)
				{
					base.Send(string.Empty);
				}
				else
				{
					base.Send(API.Notification2018.ProcessRequest(p0.Data));
				}
			}

			public NotificationWS()
			{
			}
		}
	}
}
