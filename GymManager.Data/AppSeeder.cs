using GymManager.Core.Entities;
using GymManager.Core.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace GymManager.Data
{
    public class AppSeeder
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _config;
        private readonly UserManager<Employee> _userManager;

        public AppSeeder(AppDbContext context, IConfiguration config, UserManager<Employee> userManager)
        {
            _context = context;
            _config = config;
            _userManager = userManager;
        }

        public async Task SeedAsync()
        {
            _context.Database.EnsureCreated();

            Employee user = await _userManager.FindByEmailAsync("admin@migusgym.com");
            if (user == null)
            {
                user = new Employee()
                {
                    Email = "admin@migusgym.com",
                    UserName = "admin@migusgym.com"
                };

                var result = await _userManager.CreateAsync(user, "P@ssw0rd!1");
                if (result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("Could not create new user");
                }
            }

            if (!_context.Clients.Any())
            {
                var clients = new List<Client>()
                {
                    new Client()
                    {
                        Name = "Andrzej",
                        Surname = "Kowalski",
                        Email = "akowalski@migusgym.com",
                        Subscriptions = new List<Subscription>()
                        {
                            new Subscription()
                            {
                                SubscriptionType = SubscriptionType.Monthly,
                                EntrancesLeft = 0,
                                StartDate = DateTime.Now
                            },
                            new Subscription()
                            {
                                SubscriptionType = SubscriptionType.Monthly,
                                EntrancesLeft = 0,
                                StartDate = DateTime.Now.AddMonths(-2)
                            }}
                    },
                    new Client()
                    {
                        Name = "Janko",
                        Surname = "Musykant",
                        Email = "jmuzykant@migusgym.com",
                        Subscriptions = new List<Subscription>()
                        {
                            new Subscription()
                            {
                                SubscriptionType = SubscriptionType.CountedEntrances,
                                EntrancesLeft = 10,
                                StartDate = DateTime.Now
                            },
                            new Subscription()
                            {
                                SubscriptionType = SubscriptionType.Monthly,
                                EntrancesLeft = 0,
                                StartDate = DateTime.Now.AddMonths(-2)
                            }

                        }
                    }
                };

                _context.AddRange(clients);
                _context.SaveChanges();
            }

        }
    }
}
