using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProiectPractica_ASE.Models;
using ProiectPractica_ASE.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectPractica_ASE.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AnnouncementsController : ControllerBase
    {
        private readonly IAnnouncementsService _announcementsService;

        public AnnouncementsController(IAnnouncementsService announcementsService)
        {
            _announcementsService = announcementsService;
        }

        [HttpGet]
        public async Task<IActionResult> Get() //citim datele din tabel
        {
            DbSet<Announcement> announcements = await _announcementsService.Get();
            if (announcements != null)
            {
                if (announcements.ToList().Count > 0)
                    return StatusCode(200, announcements);
                else return StatusCode(400, "Nu s-au gasit anunturi in baza de date");
            }
            return StatusCode(404);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Announcement announcement) //adaugam o inregistrare in tabel
        {
            try
            {
                if (announcement != null)
                {
                    await _announcementsService.Post(announcement);
                    return StatusCode(201, "Anuntul a fost adaugat cu succes!");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
            return StatusCode(500, "Anuntul nu a fost adaugat!");
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] Announcement announcement) //stergem o inregistrare
        {
            if (announcement != null)
            {
                await _announcementsService.Delete(announcement);
                return StatusCode(200, "Anuntul a fost sters!");
            }
            return StatusCode(500, "A aparut o eroare! Anuntul nu a fost sters!");
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Announcement announcement) //modificam o inregistrare
        {
            if (announcement != null)
            {
                await _announcementsService.Put(announcement);
                return StatusCode(200, "Anuntul a fost modificat!");
            }
            return StatusCode(500, "A aparut o eroare! Anuntul nu a fost modificat!");
        }
    }
}
