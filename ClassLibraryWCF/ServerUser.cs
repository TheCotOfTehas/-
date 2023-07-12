using System.ServiceModel;

namespace ClassLibraryWCF
{
	public class ServerUser
	{
		public int ID { get; set; }
		public string Name { get; set; }
		public int ee { get; set; }
		public OperationContext operationContext { get; set; }
	}
}
