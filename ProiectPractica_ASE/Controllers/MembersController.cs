﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProiectPractica_ASE.Models;
using ProiectPractica_ASE.Services;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectPractica_ASE.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MembersController : ControllerBase
    {
        private readonly IMembersService _membersService;

        public MembersController(IMembersService membersService)
        {
            _membersService = membersService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            DbSet<Member> members = await _membersService.Get();
            if (members != null)
            {
                if (members.ToList().Count > 0)
                    return StatusCode(200, members);
                else return StatusCode(404, "Nu este niciun membru in tabel!");
            }
            return StatusCode(404);
        }
    }
}