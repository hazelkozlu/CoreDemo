using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class Context : DbContext
    {
        //context class ı Dbcontext classından  miras alır.  entityframworkcore eklenmelidir.
        //onnconfiguring adında bir methot tanımlanır ve paremetre olarak DbContextOptionsBuilder türünde
        //optionsBuilder adında parametre alır.

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer("server=DESKTOP-SHEVOM8; database=CoreBlogDB; integrated security=true;");
        }
        //     sınıf        property
        public DbSet<About> Abouts { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Writer> Writers { get; set; }
        //neden migration oluşturuyoruz. Context sınıfında çağırmış olduğum dbsetleri yine context sınıfında oluşturmuş
        //olduğum connectionstring üzerinden code first yaklaşımı ile veri tabanına yansıtmak istiyorum.
        //package manager console da default project seçilmiş olması gerekir çünkü bizim veritabanı bağlantı stringi ve bunun tutulduğu sınıf dataaccesslayer içerisinde.
        /*
          4 tane entityframeworkcore paketi core,tools,desing,sqlserver hem dataaccesslayer a hem UI yani projenin kendisine eklenir.
           presentationlayer CoreDemoya yani
         * PM> add-migration mig1
          Build started...
          Build succeeded.
          To undo this action, use Remove-Migration.
         PM> update-database*/
    }
}
