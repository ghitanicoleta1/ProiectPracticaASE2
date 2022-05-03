﻿using Microsoft.EntityFrameworkCore;
using ProiectPractica_ASE.Models;
using System.Threading.Tasks;

namespace ProiectPractica_ASE.Services
{
    public interface ICodeSnippetService
    {
        public Task<DbSet<CodeSnippet>> Get();

        public Task Post(CodeSnippet codeSnippet);
        public Task Delete(CodeSnippet codeSnippet);
        public Task Put(CodeSnippet codeSnippet);
    }
}
