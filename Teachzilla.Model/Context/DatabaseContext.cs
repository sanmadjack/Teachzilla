using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teachzilla.Model
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Homework> Homework { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Note> Notes { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> o): base(o) {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            if (Database.ProviderName == "Microsoft.EntityFrameworkCore.Sqlite")
            {
                // SQLite does not have proper support for DateTimeOffset via Entity Framework Core, see the limitations
                // here: https://docs.microsoft.com/en-us/ef/core/providers/sqlite/limitations#query-limitations
                // To work around this, when the Sqlite database provider is used, all model properties of type DateTimeOffset
                // use the DateTimeOffsetToBinaryConverter
                // Based on: https://github.com/aspnet/EntityFrameworkCore/issues/10784#issuecomment-415769754
                // This only supports millisecond precision, but should be sufficient for most use cases.
                foreach (var entityType in modelBuilder.Model.GetEntityTypes())
                {
                    var properties = entityType.ClrType.GetProperties().Where(p => p.PropertyType == typeof(DateTimeOffset)
                                                                                   || p.PropertyType == typeof(DateTimeOffset?));
                    foreach (var property in properties)
                    {
                        modelBuilder
                            .Entity(entityType.Name)
                            .Property(property.Name)
                            .HasConversion(new DateTimeOffsetToBinaryConverter());
                    }
                }
            }

            modelBuilder.Entity<Student>(_ =>
            {
                _.HasMany(e => e.Lessons).WithOne(e => e.Student).HasForeignKey(e=>e.StudentID);
                _.HasMany(e => e.Homework).WithOne(e => e.Student).HasForeignKey(e=>e.StudentID);
                _.HasMany(e => e.Notes).WithOne(e => e.Student).IsRequired(false);
            });
            modelBuilder.Entity<Lesson>(_ =>
            {
                _.HasMany(e => e.Notes).WithOne(e=>e.Lesson).IsRequired(false);
            });
            modelBuilder.Entity<Homework>(_ =>
            {
                _.HasMany(e => e.Notes).WithOne(e => e.Homework).IsRequired(false);
            });
        }
    }
}
