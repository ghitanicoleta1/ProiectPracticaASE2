﻿using Microsoft.EntityFrameworkCore;
using ProiectPractica_ASE.App_Data;
using ProiectPractica_ASE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectPractica_ASE.Services
{
    public class CodeSnippetService : ICodeSnippetService
    {
        private readonly ClubMembershipDbContext _context;

        public CodeSnippetService(ClubMembershipDbContext context)
        {
            _context = context;
        }

        public async Task Delete(CodeSnippet codeSnippet)
        {
            _context.Remove(codeSnippet);
            _context.SaveChanges();
        }

        public async Task<DbSet<CodeSnippet>> Get()
        {
            return _context.CodeSnippets;
        }

        public async Task Post(CodeSnippet codeSnippet)
        {
            var codeS = new CodeSnippet
            {
                IdCodeSnippet = Guid.NewGuid(),
                Title = codeSnippet.Title,
                ContentCode = codeSnippet.ContentCode,
                IdMember = codeSnippet.IdMember,
                Revision = codeSnippet.Revision,
                IsPublished = codeSnippet.IsPublished,
                DateTimeAdded = DateTime.Now,
            };
            _context.Entry(codeS).State = EntityState.Added;
            _context.SaveChanges();
        }

        public async Task Put(CodeSnippet codeSnippet)
        {
            _context.Update(codeSnippet);
            _context.SaveChanges();
        }
    }
}
