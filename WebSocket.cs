using System;
using System.IO;
using System.Net;
using CustomRec.Menu;
using WebSocketSharp;
using WebSocketSharp.Server;

namespace CustomRec.WebSocket
{
	// Token: 0x02000010 RID: 16
	internal class WebSocket
	{
		// Token: 0x06000031 RID: 49 RVA: 0x000066D4 File Offset: 0x000048D4
		public WebSocket()
		{
			WebSocketServer webSocketServer = new WebSocketServer(string.Format("ws://localhost:" + Menu.Menu.version, Array.Empty<object>()));
			webSocketServer.AddWebSocketService<WebSocket.NotificationV2>("/api/notification/v2");
			webSocketServer.AddWebSocketService<WebSocket.NotificationV2>("/hub/v1");
			webSocketServer.Start();
			Console.WriteLine("[WebSocket.cs] has started.");
			Console.WriteLine("[WebSocket.cs] is listening.");
		}

		// Token: 0x02000058 RID: 88
		public class NotificationV2 : WebSocketBehavior
		{
			// Token: 0x0600023F RID: 575 RVA: 0x0000BDF8 File Offset: 0x00009FF8
			protected override void OnMessage(MessageEventArgs e)
			{
				Console.WriteLine("WebSocket.cs called for.");
				base.Send(CustomRec.API.Notification.ProcessRequest(e.Data));
				bool flag = new WebClient().DownloadString("https://raw.githubusercontent.com/liamdoesvr/CustomRec/main/Config/banned.txt").Contains(File.ReadAllText("CustomRecData\\Profile\\userid.txt"));
				if (flag)
				{
					Console.WriteLine("You are banned from playing CustomRec.");
					Menu.Menu.isBanned = true;
				}
			}
		}
	}
}
