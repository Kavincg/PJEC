using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Supermarket.Data.IRepository;
using Supermarket.Models;

namespace Supermarket.Data
{
    public class AppDbContext:IdentityDbContext
    {
       public DbSet<Category> categories {  get; set; }
       public DbSet<Product> Products { get; set; }
       public DbSet<ShoppingCart> shoppingCarts { get; set; }
        public DbSet<Favourite> Favourites { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<OrderHeader> OrderHeaders { get; set; }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    base.OnConfiguring(optionsBuilder);
        //    var Config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
        //    var ConnectionString = Config.GetSection("ConnectionString").Value;
        //    optionsBuilder.UseSqlServer(ConnectionString);
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Category>().HasData(
                new Category { id = 1, Name = "Books", DisplayOrder = 1, logoUrl = "book.png" },
                new Category { id = 2, Name = "Fashion", DisplayOrder = 2, logoUrl = "fashion.jfif" },
                new Category { id = 3, Name = "Furniture", DisplayOrder = 3, logoUrl = "Furniture.webp" },
                new Category { id = 4, Name = "Media", DisplayOrder = 4, logoUrl = "Media.jfif" },
                new Category { id = 5, Name = "Groceries", DisplayOrder = 5, logoUrl = "groceries.jfif" }
            );

            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "rock in the ocean", Description = "Mila, the seal, has found a special rock in the middle of the sea. One day, after a funny accident, she meets Charlie the seagull. The two become friends and together they share precious time on the rock until Charlie has to leave with his family. What will become of Mila and what will become of their friendship?", imgURL = "rock_in_the_ocean.jpg", price = 400, CategoryId = 1 },
                new Product { Id = 2, Name = "cotton candy", Description = "Angie Ross, aged fifteen, sadistic, brutal, evil, wicked...\r\n\r\nThe press had been the first to brand this teenager with all the usual condemnations and who could blame them? But, what drove Angie to commit such horrendous crimes? It was Susan Raynor's job to unravel the human story behind the monstrous act and to assess whether Angie was the sadistic beast that society believed she was. Angie’s dreams of her 'cotton candy' home, far away from the horrors of her childhood, depended solely on the outcome of this assessment but how could she tell a story so carefully locked away?\r\n\r\nThis is a complex and harrowing narrative of misplaced trust and lost innocence that takes you on a journey outside of your emotional comfort zone.", imgURL = "cotton_candy.jpg", price = 370, CategoryId = 1 },
                new Product { Id = 3, Name = "vanish in the sunset", Description = "This book is based on true events, turned into a fictional story. On her journey to Idaho, in the late 1860's's, with her husband and adopted daughter, Philomena is captured by a war party of Sioux. She does not know if her husband is alive or dead, when Ottawa, takes her, her daughter, her friend, Milly and Milly's son as captives. As Philomena tries to deal with the horrors that befall her, an adopted son of Chief Ottawa, Wechela, whom the Sioux captured as a child from the Shoshone, befriends her and helps lift her burden. Philomena is not certain who to trust or what to believe, since the Indians seem to lie constantly, and change their threats of killing her daily. Her only desire is to escape from the tribe, but will that be possible, when she discovers what the chief has in store for her?", imgURL = "vanish_in_the_sunset.jpg", price = 700, CategoryId = 1 },
                new Product { Id = 4, Name = "Converse X OFF-WHITE", Description = "The French fashion brings her famous wedge sneaker concept to the premium Chuck 70, giving the iconic silhouette a unique elevated stance. Blending effortless luxury style cues with classic Converse details, the limited-edition design captures the essence of Isabel Marant’s laid back but elevated aesthetic. Sophisticated materials, raw edge overlays and vibrant swirls of color create a distinctive carefree vibe.", imgURL = "converse.jpg", price = 6699, CategoryId = 2 },
                new Product { Id = 5, Name = "Rayban Aviator", Description = "Relive the glamour of the Golden Age of Hollywood with these classic Ray-Ban aviator sunglasses. The legendary gold frame and tortoiseshell tips lend a versatile vintage look. With adjustable nose pads.", imgURL = "Rayban.jfif", price = 3000, CategoryId = 2 },
                new Product { Id = 6, Name = "Seiko Presage", Description = "The Seiko Presage SRPK75J1, also known as the “Cocktail Time Star Bar Purple Sunset,” is a sophisticated men’s watch made in Japan. This limited edition timepiece, with only 9,000 pieces available, features a 23-jewel automatic movement with the Seiko Cal. 4R35 engine, offering a power reserve of up to 41 hours. The 40.5 mm stainless steel case, with a thickness of 11.8 mm, houses a captivating gradated navy blue and purple dial with a pressed pattern and gloss finish, protected by a box-shaped Hardlex crystal. The dial is adorned with elegant dagger indexes and a date display at the 3 o’clock position. The watch is water-resistant up to 50 meters (165 feet) and boasts an accuracy of +45 to -35 seconds per day.", imgURL = "seiko.jpg", price = 27899, CategoryId = 2 },
                new Product { Id = 7, Name = "Bed", Description = "The Nilkamal Tokyo Calipso Queen Bed elevates your bedroom with its contemporary design, perfectly blending style and functionality. Its PVC-upholstered cushioned headboard featuresan open-close storage compartment on each side, making organisation effortless. The headboard also includes five open shelves, giving easy access to everyday essentials. Ideal for those who appreciate minimalist aesthetics, this bed eliminates under-bed storage, creating a clean and uncluttered look. Crafted from premium engineered wood, it ensures exceptional durability and long-lasting performance, making it a perfect fit for modern homes.", imgURL = "Bed.webp", price = 35999, CategoryId = 3 },
                new Product { Id = 8, Name = "Sofa", Description = "This dark grey U-shaped sectional sleeper sofa combines multifunctional design with premium comfort. Featuring a sturdy hardwood frame, steel pull-out bed supporting 500 lbs per seat, and a spacious storage chaise, it comfortably seats 6 and sleeps 3. Upholstered in easy-care microfiber with detachable cushions, it’s perfect for modern living rooms seeking style, versatility, and convenience.", imgURL = "Sofa.jpg", price = 90000, CategoryId = 3 },
                new Product { Id = 9, Name = "TV Stand", Description = "The TV stand is designed for TVs up to 70\" and features a  high gloss white finish , with a durable construction using high-density chipboard. It has  built-in LED lighting with over 6 million colors and 29 flashing modes . The stand includes  2 large drawers for storage  and  tempered glass shelving . It measures 63\" L x 13.78\" W x 17.91\" H, weighs 72.8 lbs, and has a  load-bearing capacity of 110 lbs . The package includes a TV cabinet, remote control, and instruction manual. Suitable for TVs between 32-70 inches, it is compatible with various rooms such as bedrooms, lounges, and living rooms.", imgURL = "TVS.webp", price = 15999, CategoryId = 3 },
                new Product { Id = 10, Name = "Call Of Duty: Black OPS 3 SPECIAL EDITION", Description = "Call of Duty: Black Ops III combines three unique game modes: Campaign, Multiplayer and Zombies, providing fans with the deepest and most ambitious Call of Duty ever. ", imgURL = "COD_BO3.jpg", price = 5899, CategoryId = 4 },
                new Product { Id = 11, Name = "The Boys", Description = "The Boys is an American media franchise that includes action-drama / satirical black comedy superhero streaming television series. The show is set in a world where superpowered individuals called Supes are recognized as heroes by the general public and work for a powerful corporation known as Vought International. However, most of these Supes are selfish and corrupt outside of their heroic personas. The show follows a CIA team called The Boys who monitor and deal with these superheroes.", imgURL = "Boys.jpg", price = 399, CategoryId = 4 },
                new Product { Id = 12, Name = "Let It Happen - Tame Impala", Description = "\"Let It Happen\" is a song by Tame Impala, the project of Australian rock artist Kevin Parker. It was released as the lead single from his third studio album under the moniker, Currents (2015), on 10 March 2015. The song explores themes of personal transition and was developed in various locations around the world. ", imgURL = "LetItHappen.jfif", price = 99, CategoryId = 4 },
                new Product { Id = 13, Name = "Lays", Description = "Experiece the taste of barbeque sauce melting on your tongue with the new lays barbecue flavoured chips.", imgURL = "lays.webp", price = 40, CategoryId = 5 },
                new Product { Id = 14, Name = "Mango", Description = "The worlds sweetest fruit also known of queen of fruits, now for your tongue", imgURL = "mango.jfif", price = 200, CategoryId = 5 },
                new Product { Id = 15, Name = "Broccoli", Description = "This vegetable is commonly avoided, but its benefits are known to few. Try it out and experience brand new health", imgURL = "broc.jpg", price = 27899, CategoryId = 5 }
                );
           

        }

    }
}
