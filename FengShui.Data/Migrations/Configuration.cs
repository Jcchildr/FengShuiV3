namespace FengShui.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<FengShui.Data.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(FengShui.Data.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.Products.AddOrUpdate(
                new Product { ProductId = 1, UserId = Guid.Empty, ProductName = "Acapulco Leather Lounge Chair", Brandname = "Mexa", Height = 37, Length = 33, Width = 31, CategoryId = 1, HomeLocation = HomeLocationEnum.LivingRoom, PrimaryColor = ColorEnum.Leather, NumberInStock = 4, Price = 492.00M, ProductDescription = "Traditional Mexican craftsmanship and premium modern materials combine in a chair that’s one part work of art and one part comfortable seat", CreatedUtc = DateTimeOffset.UtcNow },
                new Product { ProductId = 2, UserId = Guid.Empty, ProductName = "Yellowstone 1878 Relief Map", Brandname = "Muir Way", Height = 0, Length = 28, Width = 24, CategoryId = 2, HomeLocation = HomeLocationEnum.GeneralDecor, PrimaryColor = ColorEnum.Orange, SecondaryColor = ColorEnum.Yellow, NumberInStock = 30, Price = 99.00M, ProductDescription = "We created this map with the illusion of 3D by applying Digital Elevation Data and meticulously adding shaded relief to the landscape of the original 1878 Yellowstone Geological map. The shading is printed on the paper and not a result of the map protruding from the surface.", CreatedUtc = DateTimeOffset.UtcNow },
                new Product { ProductId = 3, UserId = Guid.Empty,  ProductName = "Bear Hybrid Mattress - King", Brandname = "Bear", Height = 14, Length = 80, Width = 76, CategoryId = 3, HomeLocation = HomeLocationEnum.Bedroom, PrimaryColor = ColorEnum.White, SecondaryColor = ColorEnum.Grey, NumberInStock = 20, Price = 1399.00M, ProductDescription = "While providing just the right amount of support for your muscles and spine, the Bear Hybrid mattress lulls you into a deep slumber before you can get past the 10th sheep.", CreatedUtc = DateTimeOffset.UtcNow },
                new Product { ProductId = 4, UserId = Guid.Empty, ProductName = "Solid Scottish Oak Bench/coffee table", Brandname = "sticksandstonefurni", Height = 44, Length = 150, Width = 30, CategoryId = 4, HomeLocation = HomeLocationEnum.LivingRoom, PrimaryColor = ColorEnum.LightWoodAccent, NumberInStock = 1, Price = 400.92M, ProductDescription = "This one of a kind Solid Oak bench or coffee table was hand crafted by an artisan furniture creator.", CreatedUtc = DateTimeOffset.UtcNow },
                new Product { ProductId = 5, UserId = Guid.Empty, ProductName = "Pendant Light", Brandname = "Maymar Lighting", Height = 7, Length = 14, Width = 14, CategoryId = 5, HomeLocation = HomeLocationEnum.GeneralDecor, NumberInStock = 25, Price = 35.40M, PrimaryColor = ColorEnum.Black, ProductDescription = "This Matte Black Pendant Light is perfect in a cluster and on its own. The touch of matte gold that appears in the interior of the fixture adds a modern and dynamic touch to this pendant.", CreatedUtc = DateTimeOffset.UtcNow }
                );

            context.Categories.AddOrUpdate(
                new Category { CategoryId = 1, CategoryName = "Chairs & Sofas", CategoryDesc = "Place Holder" },
                new Category { CategoryId = 2, CategoryName = "Art & Decor", CategoryDesc = "Place Holder" },
                new Category { CategoryId = 3, CategoryName = "Bedding", CategoryDesc = "Place Holder" },
                new Category { CategoryId = 4, CategoryName = "Tables & Desks", CategoryDesc = "Place Holder" },
                new Category { CategoryId = 5, CategoryName = "Lighting", CategoryDesc = "Place Holder" }

                );

            context.Ambiences.AddOrUpdate(
                new Ambience { AmbienceId = 1, AmbienceName = "Lively", AmbienceDesription = "Place Holder" },
                new Ambience { AmbienceId = 2, AmbienceName = "Moody", AmbienceDesription = "Place Holder" },
                new Ambience { AmbienceId = 3, AmbienceName = "Log Cabin Vibes", AmbienceDesription = "Place Holder" },
                new Ambience { AmbienceId = 4, AmbienceName = "Wabi-Sabi", AmbienceDesription = "Place Holder" },
                new Ambience { AmbienceId = 5, AmbienceName = "Cozy", AmbienceDesription = "Place Holder" }
                );

            context.ProductAmbiences.AddOrUpdate(

                new ProductAmbience { ProductId = 1, AmbienceId = 1 },
                new ProductAmbience { ProductId = 1, AmbienceId = 4 },
                new ProductAmbience { ProductId = 2, AmbienceId = 3 },
                new ProductAmbience { ProductId = 3, AmbienceId = 5 },
                new ProductAmbience { ProductId = 4, AmbienceId = 4 },
                new ProductAmbience { ProductId = 4, AmbienceId = 3 },
                new ProductAmbience { ProductId = 4, AmbienceId = 1 },
                new ProductAmbience { ProductId = 5, AmbienceId = 2 }
                );


        }
    }
}
