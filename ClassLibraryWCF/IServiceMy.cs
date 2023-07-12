using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ClassLibraryWCF
{
	// ПРИМЕЧАНИЕ. Можно использовать команду "Переименовать" в меню "Рефакторинг", чтобы изменить имя интерфейса "IServiceMy" в коде и файле конфигурации.
	[ServiceContract]
	public interface IServiceMy
	{
		[OperationContract]
		void DoWork();
	}
}
