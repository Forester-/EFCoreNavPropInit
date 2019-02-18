using System;
using Microsoft.EntityFrameworkCore;

namespace EFCoreNavPropInit
{
    class Program
    {
        static void Main(string[] args)
        {
            Case1();
            Case2();
        }

        static void Case1()
        {
            Console.WriteLine("Case 1");

            CleanDb();

            using (var db = CreateDb())
            {
                var entity = new Entity();

                db.Entities.Add(entity);
                db.SaveChanges();

                ReadEntity(db);
            }
        }

        static void Case2()
        {
            Console.WriteLine("Case 2");

            CleanDb();

            using (var db = CreateDb())
            {
                var entity = new Entity();

                db.Entities.Add(entity);
                db.SaveChanges();
            }

            using (var db = CreateDb())
            {
                ReadEntity(db);
            }
        }

        static void ReadEntity(DbContext db)
        {
            foreach(var entity in db.Entities)
            {
                if(entity.Children == null)
                {
                    Console.WriteLine("Children is null");
                }
                else
                {
                    Console.WriteLine("Children is NOT null");
                }
            }
        }

        static void CleanDb()
        {
            using (var db = CreateDb())
            {
                db.Entities.RemoveRange(db.Entities);
                db.SaveChanges();
            }
        }

        static DbContext CreateDb()
        {
            var optionsBuilder = new DbContextOptionsBuilder<DbContext>();
            optionsBuilder.UseInMemoryDatabase("EFCoreNavPropInit");
            var options = optionsBuilder.Options;

            var context = new DbContext(options);

            return context;
        }
    }
}
