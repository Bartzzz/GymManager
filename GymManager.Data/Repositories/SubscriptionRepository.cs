using GymManager.Core.Entities;
using GymManager.Core.Services.SubscriptionService;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GymManager.Data.Repositories
{
    public class SubscriptionRepository : ISubscriptionRepository
    {
        private readonly AppDbContext _context;

        public SubscriptionRepository(AppDbContext context)
        {
            _context = context;
        }
        public Subscription Add(Subscription subscription)
        {
            _context.Add(subscription);

            return Commit(subscription);
        }

        public Subscription Delete(int id)
        {
            var subscription = GetById(id);
            if (subscription != null)
            {
                _context.Subscriptions.Remove(subscription);
            }

            return Commit(subscription);
        }

        public Subscription GetById(int id)
        {
            return _context.Subscriptions.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Subscription> GetEntities(int id = 0)
        {
            return id == 0
                ? _context.Subscriptions.ToList()
                : _context.Subscriptions.Where(x => x.UserId == id).ToList();
        }

        public Subscription Update(Subscription updatedSubscription)
        {
            _context.Update(updatedSubscription);

            return Commit(updatedSubscription);
        }

        private Subscription Commit(Subscription subscription)
        {
            var commit = _context.SaveChanges();

            return commit > 0 ? subscription : null;
        }
    }
}