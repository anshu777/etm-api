using ETM.Repository.Models;
using ETM.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETM.Service.Services
{
	public class ClientService : IClientService
	{
		public Task<Client> AddClient(Client client)
		{
			throw new NotImplementedException();
		}

		public async Task<Client> Get(int clientId)
		{
			Client client = null;
			try
			{
				using (var _context = new DatabaseContext())
				{
					client = await _context.Client.Where(x => x.Id == clientId).FirstOrDefaultAsync<Client>();
				}
				return client;
			}
			catch (Exception)
			{
				throw;
			}
		}

		public async Task<List<Client>> GetClients()
		{
			List<Client> clients = null;
			try
			{
				using (var _context = new DatabaseContext())
				{
					clients = await _context.Client.ToListAsync<Client>();
				}
				return clients;
			}
			catch (Exception)
			{
				throw;
			}
		}
	}
}
