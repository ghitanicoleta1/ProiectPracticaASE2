using Microsoft.EntityFrameworkCore;
using ProiectPractica_ASE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectPractica_ASE.Services
{
    public interface IMembersService
    {
        public Task<DbSet<Member>> Get();
    }
}
