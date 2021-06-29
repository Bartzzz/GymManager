﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GymManager.Core.DTOs.Users;
using GymManager.Core.Services.UserService;
using Microsoft.AspNetCore.Mvc;

namespace GymManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : Controller
    {
        private readonly IUserService _userService;

        public ClientController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("getAll")]
        public IActionResult GetUsers()
        {
            var users = _userService.GetClients();

            if (users == null)
            {
                return NotFound();
            }

            return Ok(users);
        }


        [HttpGet("getClient")]
        public IActionResult GetClient(int userId)
        {
            var client = _userService.GetClient(userId);

            if (client == null)
            {
                return NotFound();
            }

            return Ok(client);
        }
        [HttpPost("addClient")]
        public IActionResult Addclient(ClientDto client)
        {
            var addedClient = _userService.AddClient(client);

            if (addedClient == null)
            {
                return NotFound();
            }

            return Ok(addedClient);
        }

        [HttpPut("updateClient")]
        public IActionResult Updateclient(ClientDto client)
        {
            var updatedClient = _userService.UpdateClient(client);

            if (updatedClient == null)
            {
                return NotFound();
            }

            return Ok(updatedClient);
        }

        [HttpDelete("removeClient")]
        public IActionResult RemoveClient(int clientId)
        {
            var removedClient = _userService.RemoveClient(clientId);

            if (removedClient == null)
            {
                return NotFound();
            }

            return Ok(removedClient);
        }
    }
}
