USE [BirdTradingDB]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 6/12/2023 3:24:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[OriginalPrice] [decimal](18, 2) NOT NULL,
	[DiscountPrice] [decimal](18, 2) NULL,
	[Quantity] [int] NOT NULL,
	[ImageUrl] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[IsRemoved] [bit] NOT NULL,
	[CategoryId] [int] NOT NULL,
	[ShopId] [int] NOT NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Products] ON 

INSERT [dbo].[Products] ([Id], [Name], [OriginalPrice], [DiscountPrice], [Quantity], [ImageUrl], [Description], [IsRemoved], [CategoryId], [ShopId]) VALUES (6, N'Cockatiel', CAST(4000000.00 AS Decimal(18, 2)), NULL, 3, N'img/birds/bird-cockatiel.png', N'Cockatiels are easy birds to care for, making them a desirable pet. Their endless affection facilitates their natural ability to bond with their pet parents. Playpens are a great way to allow them to interact with you outside of their habitat!', 0, 1, 5)
INSERT [dbo].[Products] ([Id], [Name], [OriginalPrice], [DiscountPrice], [Quantity], [ImageUrl], [Description], [IsRemoved], [CategoryId], [ShopId]) VALUES (8, N'Sun Conure', CAST(3500000.00 AS Decimal(18, 2)), NULL, 5, N'img/birds/bird-sun-conure.png', N'The Sun Conure is one of the most popular birds due to their beautiful coloration and fantastic disposition. These vocal and inquisitive birds are content to be with their pet parents for hours.', 0, 1, 5)
INSERT [dbo].[Products] ([Id], [Name], [OriginalPrice], [DiscountPrice], [Quantity], [ImageUrl], [Description], [IsRemoved], [CategoryId], [ShopId]) VALUES (9, N'Blue Parakeet', CAST(3700000.00 AS Decimal(18, 2)), NULL, 4, N'img/birds/bird-blue-parakeet.png', N'Parakeets are small, social, and intelligent birds. Eating a variety of seeds, plants, fruits, and vegetables, parakeets are known to live approximately 15 years in captivity.', 0, 1, 5)
INSERT [dbo].[Products] ([Id], [Name], [OriginalPrice], [DiscountPrice], [Quantity], [ImageUrl], [Description], [IsRemoved], [CategoryId], [ShopId]) VALUES (10, N'Quaker Parakeet', CAST(4200000.00 AS Decimal(18, 2)), NULL, 8, N'img/birds/bird-quaker-parakeet.png', N'Quaker (or Monk) Parakeets are beautiful and intelligent birds. They come in a variety of colors and are larger than the typical Parakeet. The term Parakeet is actually a descriptive term for the body type of these parrots.', 0, 1, 5)
INSERT [dbo].[Products] ([Id], [Name], [OriginalPrice], [DiscountPrice], [Quantity], [ImageUrl], [Description], [IsRemoved], [CategoryId], [ShopId]) VALUES (11, N'Fancy Parakeet', CAST(7300000.00 AS Decimal(18, 2)), NULL, 6, N'img/birds/bird-fancy-parakeet.png', N'Fancy Parakeets are small, social, and intelligent birds. Eating a variety of seeds, plants, fruits, and vegetables. Parakeets are known to live approximately 20 years in captivity.', 0, 1, 5)
INSERT [dbo].[Products] ([Id], [Name], [OriginalPrice], [DiscountPrice], [Quantity], [ImageUrl], [Description], [IsRemoved], [CategoryId], [ShopId]) VALUES (13, N'Green Parakeet', CAST(3700000.00 AS Decimal(18, 2)), NULL, 10, N'img/birds/bird-green-parakeet.png', N'Parakeets are small, social, and intelligent birds. eating a variety of seeds, plants, fruits, and vegetables. Parakeets are known to live approximately 20 years in captivity.', 0, 1, 5)
INSERT [dbo].[Products] ([Id], [Name], [OriginalPrice], [DiscountPrice], [Quantity], [ImageUrl], [Description], [IsRemoved], [CategoryId], [ShopId]) VALUES (15, N'Green Cheek Conure', CAST(4300000.00 AS Decimal(18, 2)), NULL, 8, N'img/birds/bird-green-cheek-conure.png', N'Green cheek conures are highly inquisitive, bold, and engaging birds. Like other conures, they can be playful and affectionate. Their voices are softer than many Conures.', 0, 1, 5)
INSERT [dbo].[Products] ([Id], [Name], [OriginalPrice], [DiscountPrice], [Quantity], [ImageUrl], [Description], [IsRemoved], [CategoryId], [ShopId]) VALUES (16, N'Yellow Canary', CAST(6900000.00 AS Decimal(18, 2)), NULL, 9, N'img/birds/bird-yellow-canary.png', N'Canaries are well known for their beauty and varied colors. Male canaries are loved for their sweet singing.', 0, 1, 5)
INSERT [dbo].[Products] ([Id], [Name], [OriginalPrice], [DiscountPrice], [Quantity], [ImageUrl], [Description], [IsRemoved], [CategoryId], [ShopId]) VALUES (17, N'Zebra Finch', CAST(6800000.00 AS Decimal(18, 2)), NULL, 11, N'img/birds/bird-zebra-finches.png', N'Finches are small, gentle birds that come in a dazzling variety of colors. This bird is brightly colored and very social making it a fan favorite. Their song consists of chirping and "beeping" rather than squawking.', 0, 1, 5)
INSERT [dbo].[Products] ([Id], [Name], [OriginalPrice], [DiscountPrice], [Quantity], [ImageUrl], [Description], [IsRemoved], [CategoryId], [ShopId]) VALUES (18, N'Society Finch', CAST(4300000.00 AS Decimal(18, 2)), NULL, 12, N'img/birds/bird-society-finch.png', N'These birds are a domesticated species as they do not exist in the wild. Society Finches will sing and chirp once acclimated to their surroundings. They can be housed in groups or mixed with other finches.', 0, 1, 5)
INSERT [dbo].[Products] ([Id], [Name], [OriginalPrice], [DiscountPrice], [Quantity], [ImageUrl], [Description], [IsRemoved], [CategoryId], [ShopId]) VALUES (19, N'You & Me Finch Rectangle Flight Cage', CAST(69.99 AS Decimal(18, 2)), NULL, 10, N'img/finch-and-canary-cages/you-me-finch-rectangle-flight-cage.png', N'The You & Me Finch Habitat provides a secure, comfortable home for small birds. Includes four doors for easy access to your pet, dishes and clean up, plus two perches, two covered dishes and a pullout tray for easy cleaning.', 0, 2, 5)
INSERT [dbo].[Products] ([Id], [Name], [OriginalPrice], [DiscountPrice], [Quantity], [ImageUrl], [Description], [IsRemoved], [CategoryId], [ShopId]) VALUES (20, N'Hagen Vision Bird Cage for Canaries', CAST(244.99 AS Decimal(18, 2)), NULL, 10, N'img/finch-and-canary-cages/hagen-vision-bird-cage-for-canaries.png', N'Perfect for canaries and similar sized bids. Small wire size, double height. Terracotta perches and dishes included.', 0, 2, 5)
INSERT [dbo].[Products] ([Id], [Name], [OriginalPrice], [DiscountPrice], [Quantity], [ImageUrl], [Description], [IsRemoved], [CategoryId], [ShopId]) VALUES (21, N'Prevue Pet Products Classic Round Red Bird Cage, 24" H X 13" D', CAST(36.99 AS Decimal(18, 2)), NULL, 5, N'img/finch-and-canary-cages/prevue-pet-products-classic-round-red-bird-cage.png', N'Our Classic Round Bird Cage pays tribute to a traditional style of bird cages. Ideal for finches, canaries, parakeets and other small birds.', 0, 2, 5)
INSERT [dbo].[Products] ([Id], [Name], [OriginalPrice], [DiscountPrice], [Quantity], [ImageUrl], [Description], [IsRemoved], [CategoryId], [ShopId]) VALUES (22, N'Prevue Pet Products Round Roof Bird Cage Kit, 13" L X 11" W X 16" H', CAST(48.24 AS Decimal(18, 2)), NULL, 12, N'img/finch-and-canary-cages/prevue-pet-products-round-roof-bird-cage-kit-13l.png', N'Our Prevue Hendryx Round Roof Bird Cage Kit has everything your bird needs. Cups, perches, treats and toys are included. Ideal cage for small sized birds. Toys and accessories may vary from picture.', 0, 2, 5)
INSERT [dbo].[Products] ([Id], [Name], [OriginalPrice], [DiscountPrice], [Quantity], [ImageUrl], [Description], [IsRemoved], [CategoryId], [ShopId]) VALUES (23, N'Prevue Pet Products Double Roof Bird Cage Kit, 14" L X 11" W X 19" H', CAST(44.78 AS Decimal(18, 2)), NULL, 9, N'img/finch-and-canary-cages/prevue-pet-products-double-roof-bird-cage-kit-14l.png', N'Our Prevue Hendryx Double Roof Bird Cage Kit has everything your bird needs. Cups, perches, treats and toys are included. Ideal cage for small sized birds. Toys and accessories may vary from picture.', 0, 2, 5)
INSERT [dbo].[Products] ([Id], [Name], [OriginalPrice], [DiscountPrice], [Quantity], [ImageUrl], [Description], [IsRemoved], [CategoryId], [ShopId]) VALUES (26, N'YML Large White Breeding Bird Cage, 23.5" L X 10.5" W X 15.5" H', CAST(56.64 AS Decimal(18, 2)), NULL, 10, N'img/finch-and-canary-cages/yml-large-white-breeding-bird-cage-23.5l.png', N'YML Large White Breeding Bird Cage, 23.5" L X 10.5" W X 15.5" H', 0, 2, 5)
INSERT [dbo].[Products] ([Id], [Name], [OriginalPrice], [DiscountPrice], [Quantity], [ImageUrl], [Description], [IsRemoved], [CategoryId], [ShopId]) VALUES (27, N'Prevue Pet Products Classic Round Yellow Bird Cage, 24" H X 13" D', CAST(34.99 AS Decimal(18, 2)), NULL, 11, N'img/finch-and-canary-cages/prevue-pet-products-classic-round-yellow-bird-cage-24l.png', N'Our Classic Round Bird Cage pays tribute to a traditional style of bird cages. Ideal for finches, canaries, parakeets and other small birds.', 0, 2, 5)
INSERT [dbo].[Products] ([Id], [Name], [OriginalPrice], [DiscountPrice], [Quantity], [ImageUrl], [Description], [IsRemoved], [CategoryId], [ShopId]) VALUES (28, N'TRIXIE Natura Aviary Bird Cage, 30.5 X 30.5 X 70.75 in.', CAST(270.78 AS Decimal(18, 2)), NULL, 8, N'img/finch-and-canary-cages/trixie-natura-aviary-bird-cage,-30.5-x-30.5-x-70.75-in.png', N'Ideal for small birds such as parakeets and finches. Includes 2 perches, 1 climbing frame, 1 ladder, 1 feeding tray and 2 stainless steel bowls. Pull out plastic tray and extra floor grid for easy maintenance.', 0, 2, 5)
INSERT [dbo].[Products] ([Id], [Name], [OriginalPrice], [DiscountPrice], [Quantity], [ImageUrl], [Description], [IsRemoved], [CategoryId], [ShopId]) VALUES (29, N'You & Me Gable Playtop Parrot Habitat, 24.75" L X 20.75" W X 32" H', CAST(92.66 AS Decimal(18, 2)), NULL, 14, N'img/conure-cages/you-and-me-gable-playtop-parrot-habitat-24.75l.png', N'You & Me Gable Playtop Parrot Habitat, 24.75" L X 20.75" W X 32" H', 0, 3, 5)
INSERT [dbo].[Products] ([Id], [Name], [OriginalPrice], [DiscountPrice], [Quantity], [ImageUrl], [Description], [IsRemoved], [CategoryId], [ShopId]) VALUES (30, N'You & Me Bird Habitat Cover, Medium/Large', CAST(13.19 AS Decimal(18, 2)), NULL, 10, N'img/conure-cages/you-me-bird-habitat-cover-medium-large.png', N'You & Me Bird Habitat Cover\n- Helps birds rest comfortably', 0, 3, 5)
INSERT [dbo].[Products] ([Id], [Name], [OriginalPrice], [DiscountPrice], [Quantity], [ImageUrl], [Description], [IsRemoved], [CategoryId], [ShopId]) VALUES (31, N'You & Me Parrot Open Top Cage', CAST(149.99 AS Decimal(18, 2)), NULL, 12, N'img/conure-cages/you-and-me-parrot-open-top-cage.png', N'Provide a secure, comfortable home for your bird with the You & Me Convertible Conure Habitat. Made for birds like Cockatiels, it easily converts from a dome-top to a play-top habitat. Featuring four access doors, three perches and two covered dishes for food and water for a spacious, accommodating home. You''ll love the pull-out base tray and removable grate for quick, easy cleaning.', 0, 3, 5)
INSERT [dbo].[Products] ([Id], [Name], [OriginalPrice], [DiscountPrice], [Quantity], [ImageUrl], [Description], [IsRemoved], [CategoryId], [ShopId]) VALUES (32, N'A&E Cage Company Sandstone Classico Dometop Medium Bird Cage, 24" L X 22" W X 61" H', CAST(549.99 AS Decimal(18, 2)), NULL, 15, N'img/conure-cages/ae-cage-company-sandstone-classico-dometop-medium-bird-cage-24l.png', N'Medium, 24"; L X 22"; W X 61"; H, Sandstone. The perfect home for your feathered friend. Our dometop bird cage features bird proof front door and feeder door locks. Slide-out grill and tray for easy cleaning.', 0, 3, 5)
SET IDENTITY_INSERT [dbo].[Products] OFF
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_Categories_CategoryId] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Categories] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_Categories_CategoryId]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_Shops_ShopId] FOREIGN KEY([ShopId])
REFERENCES [dbo].[Shops] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_Shops_ShopId]
GO
