using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldNews.DataLayer.Models;

namespace WorldNews.DataLayer.Context
{
    public class WNewsContext : DbContext
    {
        public WNewsContext(DbContextOptions<WNewsContext> options) : base(options)
        {

        }


        public DbSet<News> News { get; set; }
        public DbSet<Section> Section { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Comments> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Seed Data

            modelBuilder.Entity<Section>().HasData(
                new Section()
                {
                    SectionId = 1,
                    SectionName = "جهان"
                },
                new Section()
                {
                    SectionId = 2,
                    SectionName = "اقتصادی"
                },
                new Section()
                {
                    SectionId = 3,
                    SectionName = "تکنولوژی"
                },
                new Section()
                {
                    SectionId = 4,
                    SectionName = "ورزشی"
                },
                new Section()
                {
                    SectionId = 5,
                    SectionName = "فرهنگی"
                });
            #endregion
        }
    }
}
