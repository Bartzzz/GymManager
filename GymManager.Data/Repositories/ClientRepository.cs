using GymManager.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using GymManager.Core.Services.UserService;

namespace GymManager.Data.Repositories
{
    public class ClientRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public ClientRepository(AppDbContext context)
        {
            _context = context;
        }
        public Client Add(Client client)
        {
            _context.Add(client);

            return Commit(client);
        }

        public Client Delete(int userId)
        {
            var client = GetById(userId);

            if (client != null)
            {
                _context.Clients.Remove(client);
            }

            return Commit(client);
        }

        public Client GetById(int id)
        {
           return _context.Clients.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Client> GetEntities(int id = 0)
        {
           return _context.Clients.ToList();
        }

        public Client Update(Client client)
        {
            _context.Clients.Update(client);

            return Commit(client);
        }

        private Client Commit(Client client)
        {
            var commit = _context.SaveChanges();

            return commit > 0 ? client : null;
        }
    }
}
