using Microsoft.EntityFrameworkCore;
using ProiectPractica_ASE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectPractica_ASE.App_Data
{
    public class ClubMembershipDbContext : DbContext //EntityFramework e un ORM(object-database mapper)
    {
        public ClubMembershipDbContext(DbContextOptions<ClubMembershipDbContext> options) : base(options) { }

        public DbSet<Announcement> Announcements { get; set; }

        public DbSet<CodeSnippet> CodeSnippets { get; set; }

        public DbSet<Member> Members { get; set; }
    }
}
