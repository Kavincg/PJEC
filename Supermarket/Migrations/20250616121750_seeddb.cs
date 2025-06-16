using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Supermarket.Migrations
{
    /// <inheritdoc />
    public partial class seeddb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CategoryId", "Description", "Name", "imgURL", "price" },
                values: new object[] { 1, "Mila, the seal, has found a special rock in the middle of the sea. One day, after a funny accident, she meets Charlie the seagull. The two become friends and together they share precious time on the rock until Charlie has to leave with his family. What will become of Mila and what will become of their friendship?", "rock in the ocean", "rock_in_the_ocean.jpg", 400 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "Discount", "IsFavorited", "Name", "imgURL", "price" },
                values: new object[,]
                {
                    { 2, 1, "Angie Ross, aged fifteen, sadistic, brutal, evil, wicked...\r\n\r\nThe press had been the first to brand this teenager with all the usual condemnations and who could blame them? But, what drove Angie to commit such horrendous crimes? It was Susan Raynor's job to unravel the human story behind the monstrous act and to assess whether Angie was the sadistic beast that society believed she was. Angie’s dreams of her 'cotton candy' home, far away from the horrors of her childhood, depended solely on the outcome of this assessment but how could she tell a story so carefully locked away?\r\n\r\nThis is a complex and harrowing narrative of misplaced trust and lost innocence that takes you on a journey outside of your emotional comfort zone.", null, false, "cotton candy", "cotton_candy.jpg", 370 },
                    { 3, 1, "This book is based on true events, turned into a fictional story. On her journey to Idaho, in the late 1860's's, with her husband and adopted daughter, Philomena is captured by a war party of Sioux. She does not know if her husband is alive or dead, when Ottawa, takes her, her daughter, her friend, Milly and Milly's son as captives. As Philomena tries to deal with the horrors that befall her, an adopted son of Chief Ottawa, Wechela, whom the Sioux captured as a child from the Shoshone, befriends her and helps lift her burden. Philomena is not certain who to trust or what to believe, since the Indians seem to lie constantly, and change their threats of killing her daily. Her only desire is to escape from the tribe, but will that be possible, when she discovers what the chief has in store for her?", null, false, "vanish in the sunset", "vanish_in_the_sunset.jpg", 700 },
                    { 4, 2, "The French fashion brings her famous wedge sneaker concept to the premium Chuck 70, giving the iconic silhouette a unique elevated stance. Blending effortless luxury style cues with classic Converse details, the limited-edition design captures the essence of Isabel Marant’s laid back but elevated aesthetic. Sophisticated materials, raw edge overlays and vibrant swirls of color create a distinctive carefree vibe.", null, false, "Converse X OFF-WHITE", "converse.jpg", 6699 },
                    { 5, 2, "Relive the glamour of the Golden Age of Hollywood with these classic Ray-Ban aviator sunglasses. The legendary gold frame and tortoiseshell tips lend a versatile vintage look. With adjustable nose pads.", null, false, "Rayban Aviator", "Rayban.jfif", 3000 },
                    { 6, 2, "The Seiko Presage SRPK75J1, also known as the “Cocktail Time Star Bar Purple Sunset,” is a sophisticated men’s watch made in Japan. This limited edition timepiece, with only 9,000 pieces available, features a 23-jewel automatic movement with the Seiko Cal. 4R35 engine, offering a power reserve of up to 41 hours. The 40.5 mm stainless steel case, with a thickness of 11.8 mm, houses a captivating gradated navy blue and purple dial with a pressed pattern and gloss finish, protected by a box-shaped Hardlex crystal. The dial is adorned with elegant dagger indexes and a date display at the 3 o’clock position. The watch is water-resistant up to 50 meters (165 feet) and boasts an accuracy of +45 to -35 seconds per day.", null, false, "Seiko Presage", "seiko.jpg", 27899 },
                    { 7, 3, "The Nilkamal Tokyo Calipso Queen Bed elevates your bedroom with its contemporary design, perfectly blending style and functionality. Its PVC-upholstered cushioned headboard featuresan open-close storage compartment on each side, making organisation effortless. The headboard also includes five open shelves, giving easy access to everyday essentials. Ideal for those who appreciate minimalist aesthetics, this bed eliminates under-bed storage, creating a clean and uncluttered look. Crafted from premium engineered wood, it ensures exceptional durability and long-lasting performance, making it a perfect fit for modern homes.", null, false, "Bed", "Bed.webp", 35999 },
                    { 8, 3, "This dark grey U-shaped sectional sleeper sofa combines multifunctional design with premium comfort. Featuring a sturdy hardwood frame, steel pull-out bed supporting 500 lbs per seat, and a spacious storage chaise, it comfortably seats 6 and sleeps 3. Upholstered in easy-care microfiber with detachable cushions, it’s perfect for modern living rooms seeking style, versatility, and convenience.", null, false, "Sofa", "Sofa.jpg", 90000 },
                    { 9, 3, "The TV stand is designed for TVs up to 70\" and features a  high gloss white finish , with a durable construction using high-density chipboard. It has  built-in LED lighting with over 6 million colors and 29 flashing modes . The stand includes  2 large drawers for storage  and  tempered glass shelving . It measures 63\" L x 13.78\" W x 17.91\" H, weighs 72.8 lbs, and has a  load-bearing capacity of 110 lbs . The package includes a TV cabinet, remote control, and instruction manual. Suitable for TVs between 32-70 inches, it is compatible with various rooms such as bedrooms, lounges, and living rooms.", null, false, "TV Stand", "TVS.webp", 15999 }
                });

            migrationBuilder.UpdateData(
                table: "categories",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "Name", "logoUrl" },
                values: new object[] { "Books", "book.jpeg" });

            migrationBuilder.UpdateData(
                table: "categories",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "DisplayOrder", "Name", "logoUrl" },
                values: new object[] { 2, "Fashion", "fashion.jfif" });

            migrationBuilder.UpdateData(
                table: "categories",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "Name", "logoUrl" },
                values: new object[] { "Furniture", "Furniture.webp" });

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "id", "DisplayOrder", "Name", "logoUrl" },
                values: new object[,]
                {
                    { 4, 4, "Media", "Media.jfif" },
                    { 5, 5, "Groceries", "groceries.jfif" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "Discount", "IsFavorited", "Name", "imgURL", "price" },
                values: new object[,]
                {
                    { 10, 4, "Call of Duty: Black Ops III combines three unique game modes: Campaign, Multiplayer and Zombies, providing fans with the deepest and most ambitious Call of Duty ever. ", null, false, "Call Of Duty: Black OPS 3 SPECIAL EDITION", "COD_BO3.jpg", 5899 },
                    { 11, 4, "The Boys is an American media franchise that includes action-drama / satirical black comedy superhero streaming television series. The show is set in a world where superpowered individuals called Supes are recognized as heroes by the general public and work for a powerful corporation known as Vought International. However, most of these Supes are selfish and corrupt outside of their heroic personas. The show follows a CIA team called The Boys who monitor and deal with these superheroes.", null, false, "The Boys", "Boys.jpg", 399 },
                    { 12, 4, "\"Let It Happen\" is a song by Tame Impala, the project of Australian rock artist Kevin Parker. It was released as the lead single from his third studio album under the moniker, Currents (2015), on 10 March 2015. The song explores themes of personal transition and was developed in various locations around the world. ", null, false, "Let It Happen - Tame Impala", "LetItHappen.jfif", 99 },
                    { 13, 5, "Experiece the taste of barbeque sauce melting on your tongue with the new lays barbecue flavoured chips.", null, false, "Lays", "lays.webp", 40 },
                    { 14, 5, "The worlds sweetest fruit also known of queen of fruits, now for your tongue", null, false, "Mango", "mango.jfif", 200 },
                    { 15, 5, "This vegetable is commonly avoided, but its benefits are known to few. Try it out and experience brand new health", null, false, "Broccoli", "broc.jpg", 27899 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "id",
                keyValue: 5);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CategoryId", "Description", "Name", "imgURL", "price" },
                values: new object[] { 2, "", "Tomato", "", 60 });

            migrationBuilder.UpdateData(
                table: "categories",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "Name", "logoUrl" },
                values: new object[] { "Fruits", "fruits.jpeg" });

            migrationBuilder.UpdateData(
                table: "categories",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "DisplayOrder", "Name", "logoUrl" },
                values: new object[] { 3, "Vegetables", "vegetables.jpeg" });

            migrationBuilder.UpdateData(
                table: "categories",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "Name", "logoUrl" },
                values: new object[] { "Drinks", "drinks.png" });
        }
    }
}
