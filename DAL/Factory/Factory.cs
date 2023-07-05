using DAL.Contracts;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Factory
{

	public sealed class Factory
	{
		private readonly static Factory _instance = new Factory();

		public static Factory Current
		{
			get
			{
				return _instance;
			}
		}

		private Factory()
		{

		}

		public IGenericRepository<Cliente> GetClienteRepository() 
		{
			return new ClienteRepository();
		}

	}

}
