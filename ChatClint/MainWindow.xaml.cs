using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ChatClint.ServiceChat;

namespace ChatClint
{
	/// <summary>
	/// Логика взаимодействия для MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window, IServiceMyCallback
	{
		bool isConnected = false;
		ServiceMyClient client;
		int ID;
		public MainWindow()
		{
			InitializeComponent();
		}

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			//client = new ServiceMyClient(new System.ServiceModel.InstanceContext(this));
		}

		void ConnectUser()
		{
			if (!isConnected)
			{
				client = new ServiceMyClient(new System.ServiceModel.InstanceContext(this));
				ID = client.Connect(tbUserName.Text);
				tbUserName.IsEnabled = false;
				bConnDicon.Content = "Disconnect";
				isConnected = true;
			}
		}

		void DisconnectUser() 
		{
			if (isConnected)
			{
				client.Disconnect(ID);
				client = null;
				tbUserName.IsEnabled = true;
				bConnDicon.Content = "Connect";
				isConnected = false;
			}
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			if (isConnected)
			{
				DisconnectUser();
			}
			else
			{
				ConnectUser();
			}
		}

		public void MsgCallback(string msg)
		{
			lbChat.Items.Add(msg);
		}

		private void Window_Closing(object sender, EventArgs e)
		{
			DisconnectUser();
		}

		private void tbMessage_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.Key == Key.Enter)
			{
				if (client != null)
				{
					client.SendMsg(thMessage.Text, ID);
					thMessage.Text = "";
				}
			}
		}
	}
}
