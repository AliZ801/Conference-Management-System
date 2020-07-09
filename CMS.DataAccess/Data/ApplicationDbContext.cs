using System;
using System.Collections.Generic;
using System.Text;
using CMS.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CMS.DataAccess.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Conference> Conference { get; set; }

        public DbSet<Tracks> Tracks { get; set; }

        public DbSet<Attendees> Attendees { get; set; }

        public DbSet<ConfAttendees> ConferenceAttendees { get; set; }

        public DbSet<ApplicationUser> ApplicationUser { get; set; }

        public DbSet<Speakers> Speakers { get; set; }

        public DbSet<Sessions> Sessions { get; set; }

        public DbSet<Tags> Tags { get; set; }
    }
}
