using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ChatHost
{
	internal class Program
	{
		static void Main(string[] args)
		{
			/*
			 System.InvalidOperationException: "Не удалось найти имя контракта "IMetadataExchange" в списке контрактов, реализуемых службой ServiceMy.
			Чтобы обеспечить поддержку данного контракта, добавьте ServiceMetadataBehavior в файл конфигурации или напрямую в ServiceHost."

			 */
			using (var host = new ServiceHost(typeof(ClassLibraryWCF.ServiceMy)))
			{
				host.Open();
                Console.WriteLine("Хост стартовал!");
                Console.ReadLine();
            }
		}
	}
}
