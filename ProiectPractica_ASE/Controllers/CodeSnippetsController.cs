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
    public class CodeSnippetsController : ControllerBase
    {
        private readonly ICodeSnippetService _codeSnippetService;

        public CodeSnippetsController(ICodeSnippetService codeSnippetService)
        {
            _codeSnippetService = codeSnippetService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            DbSet<CodeSnippet> codeSnippets = await _codeSnippetService.Get();
            if (codeSnippets != null)
            {
                if (codeSnippets.ToList().Count > 0)
                    return StatusCode(200, codeSnippets);
                else return StatusCode(404, "Nu este niciun snippet adaugat in tabel");
            }
            return StatusCode(404);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CodeSnippet codeSnippet)
        {
            try
            {
                if (codeSnippet != null)
                {
                    await _codeSnippetService.Post(codeSnippet);
                    return StatusCode(201, "Code snippet-ul a fost adaugat in tabel");
                }
            }
            catch (Exception ex) { return StatusCode(500, ex); }
            return StatusCode(500);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] CodeSnippet codeSnippet) //stergem o inregistrare
        {
            if (codeSnippet != null)
            {
                await _codeSnippetService.Delete(codeSnippet);
                return StatusCode(200, "Code snippetul a fost sters!");
            }
            return StatusCode(500, "A aparut o eroare! Code snippetul nu a fost sters!");
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] CodeSnippet codeSnippet) //modificam o inregistrare
        {
            if (codeSnippet != null)
            {
                await _codeSnippetService.Put(codeSnippet);
                return StatusCode(200, "Code snippetul a fost modificat!");
            }
            return StatusCode(500, "A aparut o eroare! Code snippetul nu a fost modificat!");
        }
    }
}
