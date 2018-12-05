using ETM.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETM.Service.Interfaces
{
	public interface IClientService
	{
		Task<List<Client>> GetClients();
		Task<Client> Get(int projectID);
		Task<Client> AddClient(Client client);
	}
}
