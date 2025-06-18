using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Supermarket.Migrations
{
    /// <inheritdoc />
    public partial class initialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(21)", maxLength: 21, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StreetAdress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false),
                    logoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categories", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderHeaders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OrderTotal = table.Column<double>(type: "float", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OrderStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SessionId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentIntentId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StreetAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderHeaders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderHeaders_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    imgURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    price = table.Column<int>(type: "int", nullable: false),
                    Discount = table.Column<int>(type: "int", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    IsFavorited = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "categories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Favourites",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Favourites", x => new { x.ProductId, x.UserId });
                    table.ForeignKey(
                        name: "FK_Favourites_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Favourites_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderHeaderId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderDetails_OrderHeaders_OrderHeaderId",
                        column: x => x.OrderHeaderId,
                        principalTable: "OrderHeaders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "shoppingCarts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    quantity = table.Column<int>(type: "int", nullable: false),
                    productId = table.Column<int>(type: "int", nullable: false),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_shoppingCarts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_shoppingCarts_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_shoppingCarts_Products_productId",
                        column: x => x.productId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "id", "DisplayOrder", "Name", "logoUrl" },
                values: new object[,]
                {
                    { 1, 1, "Books", "book.png" },
                    { 2, 2, "Fashion", "fashion.jfif" },
                    { 3, 3, "Furniture", "Furniture.webp" },
                    { 4, 4, "Media", "Media.jfif" },
                    { 5, 5, "Groceries", "groceries.jfif" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "Discount", "IsFavorited", "Name", "imgURL", "price" },
                values: new object[,]
                {
                    { 1, 1, "Mila, the seal, has found a special rock in the middle of the sea. One day, after a funny accident, she meets Charlie the seagull. The two become friends and together they share precious time on the rock until Charlie has to leave with his family. What will become of Mila and what will become of their friendship?", null, false, "rock in the ocean", "rock_in_the_ocean.jpg", 400 },
                    { 2, 1, "Angie Ross, aged fifteen, sadistic, brutal, evil, wicked...\r\n\r\nThe press had been the first to brand this teenager with all the usual condemnations and who could blame them? But, what drove Angie to commit such horrendous crimes? It was Susan Raynor's job to unravel the human story behind the monstrous act and to assess whether Angie was the sadistic beast that society believed she was. Angie’s dreams of her 'cotton candy' home, far away from the horrors of her childhood, depended solely on the outcome of this assessment but how could she tell a story so carefully locked away?\r\n\r\nThis is a complex and harrowing narrative of misplaced trust and lost innocence that takes you on a journey outside of your emotional comfort zone.", null, false, "cotton candy", "cotton_candy.jpg", 370 },
                    { 3, 1, "This book is based on true events, turned into a fictional story. On her journey to Idaho, in the late 1860's's, with her husband and adopted daughter, Philomena is captured by a war party of Sioux. She does not know if her husband is alive or dead, when Ottawa, takes her, her daughter, her friend, Milly and Milly's son as captives. As Philomena tries to deal with the horrors that befall her, an adopted son of Chief Ottawa, Wechela, whom the Sioux captured as a child from the Shoshone, befriends her and helps lift her burden. Philomena is not certain who to trust or what to believe, since the Indians seem to lie constantly, and change their threats of killing her daily. Her only desire is to escape from the tribe, but will that be possible, when she discovers what the chief has in store for her?", null, false, "vanish in the sunset", "vanish_in_the_sunset.jpg", 700 },
                    { 4, 2, "The French fashion brings her famous wedge sneaker concept to the premium Chuck 70, giving the iconic silhouette a unique elevated stance. Blending effortless luxury style cues with classic Converse details, the limited-edition design captures the essence of Isabel Marant’s laid back but elevated aesthetic. Sophisticated materials, raw edge overlays and vibrant swirls of color create a distinctive carefree vibe.", null, false, "Converse X OFF-WHITE", "converse.jpg", 6699 },
                    { 5, 2, "Relive the glamour of the Golden Age of Hollywood with these classic Ray-Ban aviator sunglasses. The legendary gold frame and tortoiseshell tips lend a versatile vintage look. With adjustable nose pads.", null, false, "Rayban Aviator", "Rayban.jfif", 3000 },
                    { 6, 2, "The Seiko Presage SRPK75J1, also known as the “Cocktail Time Star Bar Purple Sunset,” is a sophisticated men’s watch made in Japan. This limited edition timepiece, with only 9,000 pieces available, features a 23-jewel automatic movement with the Seiko Cal. 4R35 engine, offering a power reserve of up to 41 hours. The 40.5 mm stainless steel case, with a thickness of 11.8 mm, houses a captivating gradated navy blue and purple dial with a pressed pattern and gloss finish, protected by a box-shaped Hardlex crystal. The dial is adorned with elegant dagger indexes and a date display at the 3 o’clock position. The watch is water-resistant up to 50 meters (165 feet) and boasts an accuracy of +45 to -35 seconds per day.", null, false, "Seiko Presage", "seiko.jpg", 27899 },
                    { 7, 3, "The Nilkamal Tokyo Calipso Queen Bed elevates your bedroom with its contemporary design, perfectly blending style and functionality. Its PVC-upholstered cushioned headboard featuresan open-close storage compartment on each side, making organisation effortless. The headboard also includes five open shelves, giving easy access to everyday essentials. Ideal for those who appreciate minimalist aesthetics, this bed eliminates under-bed storage, creating a clean and uncluttered look. Crafted from premium engineered wood, it ensures exceptional durability and long-lasting performance, making it a perfect fit for modern homes.", null, false, "Bed", "Bed.webp", 35999 },
                    { 8, 3, "This dark grey U-shaped sectional sleeper sofa combines multifunctional design with premium comfort. Featuring a sturdy hardwood frame, steel pull-out bed supporting 500 lbs per seat, and a spacious storage chaise, it comfortably seats 6 and sleeps 3. Upholstered in easy-care microfiber with detachable cushions, it’s perfect for modern living rooms seeking style, versatility, and convenience.", null, false, "Sofa", "Sofa.jpg", 90000 },
                    { 9, 3, "The TV stand is designed for TVs up to 70\" and features a  high gloss white finish , with a durable construction using high-density chipboard. It has  built-in LED lighting with over 6 million colors and 29 flashing modes . The stand includes  2 large drawers for storage  and  tempered glass shelving . It measures 63\" L x 13.78\" W x 17.91\" H, weighs 72.8 lbs, and has a  load-bearing capacity of 110 lbs . The package includes a TV cabinet, remote control, and instruction manual. Suitable for TVs between 32-70 inches, it is compatible with various rooms such as bedrooms, lounges, and living rooms.", null, false, "TV Stand", "TVS.webp", 15999 },
                    { 10, 4, "Call of Duty: Black Ops III combines three unique game modes: Campaign, Multiplayer and Zombies, providing fans with the deepest and most ambitious Call of Duty ever. ", null, false, "Call Of Duty: Black OPS 3 SPECIAL EDITION", "COD_BO3.jpg", 5899 },
                    { 11, 4, "The Boys is an American media franchise that includes action-drama / satirical black comedy superhero streaming television series. The show is set in a world where superpowered individuals called Supes are recognized as heroes by the general public and work for a powerful corporation known as Vought International. However, most of these Supes are selfish and corrupt outside of their heroic personas. The show follows a CIA team called The Boys who monitor and deal with these superheroes.", null, false, "The Boys", "Boys.jpg", 399 },
                    { 12, 4, "\"Let It Happen\" is a song by Tame Impala, the project of Australian rock artist Kevin Parker. It was released as the lead single from his third studio album under the moniker, Currents (2015), on 10 March 2015. The song explores themes of personal transition and was developed in various locations around the world. ", null, false, "Let It Happen - Tame Impala", "LetItHappen.jfif", 99 },
                    { 13, 5, "Experiece the taste of barbeque sauce melting on your tongue with the new lays barbecue flavoured chips.", null, false, "Lays", "lays.webp", 40 },
                    { 14, 5, "The worlds sweetest fruit also known of queen of fruits, now for your tongue", null, false, "Mango", "mango.jfif", 200 },
                    { 15, 5, "This vegetable is commonly avoided, but its benefits are known to few. Try it out and experience brand new health", null, false, "Broccoli", "broc.jpg", 27899 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Favourites_UserId",
                table: "Favourites",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderHeaderId",
                table: "OrderDetails",
                column: "OrderHeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_ProductId",
                table: "OrderDetails",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderHeaders_ApplicationUserId",
                table: "OrderHeaders",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_shoppingCarts_ApplicationUserId",
                table: "shoppingCarts",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_shoppingCarts_productId",
                table: "shoppingCarts",
                column: "productId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Favourites");

            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "shoppingCarts");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "OrderHeaders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "categories");
        }
    }
}
