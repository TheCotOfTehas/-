using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ClassLibraryWCF
{
	[ServiceBehavior(InstanceContextMode =InstanceContextMode.Single)]
	public class ServiceMy : IServiceMy
	{
		List<ServerUser> users =new List<ServerUser>();
		int nextId = 1;
		public int Connect(string name)
		{
			ServerUser user = new ServerUser()
			{
				ID = nextId++,
				Name = name,
				operationContext = OperationContext.Current
			};

			nextId++;
			SendMsg(user.Name + " приссоеденился к чату!", 0);
			users.Add(user);
			return user.ID;
		}

		public void Disconnect(int id)
		{
			var user = users.Find(x => x.ID == id);
			if (user != null)
			{
				users.Remove(user);
				SendMsg(user.Name + " покинул чат!", 0);
			}
		}

		public void SendMsg(string msg, int id)
		{
			foreach (ServerUser item in users)
			{
				string answer = DateTime.Now.ToShortTimeString();
				var user = users.Find(x => x.ID == id);

				if (user != null)
				{
					answer += ": " + user.Name + " ";
				}
				answer += msg;

				item.operationContext.GetCallbackChannel<IServerChatCallback>().MsgCallback(answer);
			}
		}
	}
}
