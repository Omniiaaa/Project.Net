using Microsoft.EntityFrameworkCore;
using Project.Net.Models;
namespace Project.Net.Context
{
    public class CompanyContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=NetProject;Trusted_Connection=True;Encrypt=false");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var _Category = new List<Category>
            {
                new Category{CategoryId=1,Name="Toys & Games",Description=" Relive classic board games with our collection of vintage games. Enjoy hours of fun and family entertainment with games that have been enjoyed for generations."},
                new Category{CategoryId=2,Name=" Beauty & Personal Care",Description="Indulge in the luxury of handmade soap, crafted with natural ingredients and essential oils. Our soaps are gentle on the skin and offer a delightful sensory experience."},
                new Category{CategoryId=3,Name=" Jewelry ",Description="Create a truly unique and meaningful piece of jewelry with our personalized sterling silver necklaces. Choose from a variety of designs and customization options to create a necklace that's perfect for you.\r\n\r\n"},
                new Category{CategoryId=4,Name="Food & Beverage",Description="Boost your energy and focus with our organic matcha powder. This nutrient-rich green tea powder offers a natural and delicious way to enhance your health and well-being.\r\n\r\n"}

            };
            var _Product = new List<Product>
            {
                new Product{ProductId=1,Title="Organic Matcha Powder",Price=250,Description=" Our organic matcha powder is sourced from the highest quality tea leaves and is packed with antioxidants and amino acids. Enjoy a cup of matcha for a boost of energy and a calming effect.",Quantity=50,ImagePath="",CategoryId=4},
                new Product{ProductId=2,Title="Silver Necklace",Price=300,Description="This personalized sterling silver necklace is crafted from high-quality sterling silver and features a customizable pendant with your choice of engraving. It's the perfect gift for any occasion.",Quantity=40,ImagePath="",CategoryId=3 },
                new Product{ProductId=3,Title="Handmade Soap",Price=120,Description="This handmade soap is crafted with all-natural ingredients, including shea butter, coconut oil, and essential oils. It's gentle on the skin and leaves it feeling soft and hydrated.",Quantity=100,ImagePath="",CategoryId=2},
                new Product{ProductId=4,Title="Vintage Board Game",Price=500,Description="This vintage board game is a classic that's perfect for family game nights. It features simple rules, strategic gameplay, and hours of fun for all ages.",Quantity=50,ImagePath="",CategoryId=1},
                new Product{ProductId=5,Title="Silver bracelet",Price=100,Description="This personalized sterling silver bracelet is crafted from high-quality sterling silver and features a customizable pendant with your choice of engraving. It's the perfect gift for any occasion.",Quantity=60,ImagePath="",CategoryId=3 },
                new Product{ProductId=6,Title="Moisturizer",Price=150,Description="This Moisturizer is crafted with all-natural ingredients, including shea butter, coconut oil, and essential oils. It's gentle on the skin and leaves it feeling soft and hydrated.",Quantity=100,ImagePath="",CategoryId=2},
                new Product{ProductId=7,Title="scooter",Price=500,Description="This scooter is a classic that's perfect for Kids. It features easy to use, strategic gameplay, and hours of fun for all ages.",Quantity=50,ImagePath="",CategoryId=1},
            };
            var _User = new List<User>
            {
                new User{UserId=123,FirstName="Ahmed",LastName="samy",Email="Ahmed@gmail.com",Password="Ahmed123"},
                 new User{UserId=124,FirstName="Omar",LastName="Tamer",Email="Tamer@gmail.com",Password="Omar124"},
                  new User{UserId=125,FirstName="Nada",LastName="Khaled",Email="Nada@gmail.com",Password="Nada125"},
                   new User{UserId=126,FirstName="Hend",LastName="Fathi",Email="Hend@gmail.com",Password="Hend126"},
                    new User{UserId=127,FirstName="Ali",LastName="Ahmed",Email="Ali@gmail.com",Password="Ali127"}
            };

            modelBuilder.Entity<Category>().HasData(_Category);
            modelBuilder.Entity<Product>().HasData(_Product);
            modelBuilder.Entity<User>().HasData(_User);
        }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<User> Users { get; set; }


    }
    }


