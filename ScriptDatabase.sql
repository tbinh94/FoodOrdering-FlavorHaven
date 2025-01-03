USE [master]
GO
/****** Object:  Database [Test]    Script Date: 03/01/2025 9:15:32 SA ******/
CREATE DATABASE [Test]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'1', FILENAME = N'C:\Users\Admin\1.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'1_log', FILENAME = N'C:\Users\Admin\1_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [Test] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Test].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Test] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Test] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Test] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Test] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Test] SET ARITHABORT OFF 
GO
ALTER DATABASE [Test] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Test] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Test] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Test] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Test] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Test] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Test] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Test] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Test] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Test] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Test] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Test] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Test] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Test] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Test] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Test] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Test] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Test] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Test] SET  MULTI_USER 
GO
ALTER DATABASE [Test] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Test] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Test] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Test] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Test] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Test] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [Test] SET QUERY_STORE = ON
GO
ALTER DATABASE [Test] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [Test]
GO
/****** Object:  Table [dbo].[Cart_Item]    Script Date: 03/01/2025 9:15:33 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cart_Item](
	[UserID] [int] NULL,
	[ProductID] [int] NULL,
	[Quantity] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 03/01/2025 9:15:33 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[CategoryID] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[CategoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Discount]    Script Date: 03/01/2025 9:15:33 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Discount](
	[DiscountID] [int] IDENTITY(1,1) NOT NULL,
	[ProductID] [int] NOT NULL,
	[DiscountRate] [float] NOT NULL,
	[StartDate] [date] NOT NULL,
	[EndDate] [date] NOT NULL,
	[IsActive] [bit] NULL,
	[Description] [nvarchar](255) NULL,
	[Image] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[DiscountID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 03/01/2025 9:15:33 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[OrderID] [int] IDENTITY(1,1) NOT NULL,
	[CustomerID] [int] NULL,
	[OrderDate] [datetime] NULL,
	[OrderItemsList] [nvarchar](max) NULL,
	[TotalAmount] [decimal](10, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[OrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 03/01/2025 9:15:33 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[ProductID] [int] IDENTITY(1,1) NOT NULL,
	[ProductName] [nvarchar](100) NULL,
	[Price] [decimal](10, 2) NULL,
	[Description] [nvarchar](255) NULL,
	[CategoryID] [int] NULL,
	[Image] [nvarchar](255) NULL,
	[Address] [nvarchar](255) NULL,
	[SellerID] [int] NULL,
	[Inventory] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Seller]    Script Date: 03/01/2025 9:15:33 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Seller](
	[SellerID] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](100) NULL,
	[PhoneNumber] [nvarchar](15) NULL,
	[Address] [nvarchar](255) NULL,
	[StoreName] [nvarchar](50) NULL,
	[Avatar] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[SellerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 03/01/2025 9:15:33 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](50) NULL,
	[Password] [nvarchar](50) NULL,
	[Email] [nvarchar](100) NULL,
	[PhoneNumber] [nvarchar](15) NULL,
	[Address] [nvarchar](255) NULL,
	[Avatar] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[Cart_Item] ([UserID], [ProductID], [Quantity]) VALUES (1, 9, 1)
INSERT [dbo].[Cart_Item] ([UserID], [ProductID], [Quantity]) VALUES (2002, 1, 1)
INSERT [dbo].[Cart_Item] ([UserID], [ProductID], [Quantity]) VALUES (2002, 2, 1)
INSERT [dbo].[Cart_Item] ([UserID], [ProductID], [Quantity]) VALUES (1, 1, 1)
INSERT [dbo].[Cart_Item] ([UserID], [ProductID], [Quantity]) VALUES (5002, 1, 1)
INSERT [dbo].[Cart_Item] ([UserID], [ProductID], [Quantity]) VALUES (5002, 5, 1)
INSERT [dbo].[Cart_Item] ([UserID], [ProductID], [Quantity]) VALUES (4002, 3, 1)
INSERT [dbo].[Cart_Item] ([UserID], [ProductID], [Quantity]) VALUES (1, 12, 1)
INSERT [dbo].[Cart_Item] ([UserID], [ProductID], [Quantity]) VALUES (4002, 13, 1)
INSERT [dbo].[Cart_Item] ([UserID], [ProductID], [Quantity]) VALUES (1, 15, 1)
INSERT [dbo].[Cart_Item] ([UserID], [ProductID], [Quantity]) VALUES (5002, 19, 1)
INSERT [dbo].[Cart_Item] ([UserID], [ProductID], [Quantity]) VALUES (5002, 4, 1)
GO
SET IDENTITY_INSERT [dbo].[Categories] ON 

INSERT [dbo].[Categories] ([CategoryID], [CategoryName]) VALUES (1, N'Đồ ăn nhanh')
INSERT [dbo].[Categories] ([CategoryID], [CategoryName]) VALUES (2, N'Đồ uống')
INSERT [dbo].[Categories] ([CategoryID], [CategoryName]) VALUES (3, N'Món ăn chính')
INSERT [dbo].[Categories] ([CategoryID], [CategoryName]) VALUES (4, N'Tráng miệng')
INSERT [dbo].[Categories] ([CategoryID], [CategoryName]) VALUES (5, N'Đồ chay')
INSERT [dbo].[Categories] ([CategoryID], [CategoryName]) VALUES (6, N'Khai vị')
INSERT [dbo].[Categories] ([CategoryID], [CategoryName]) VALUES (7, N'Đồ hải sản')
INSERT [dbo].[Categories] ([CategoryID], [CategoryName]) VALUES (8, N'Salad')
INSERT [dbo].[Categories] ([CategoryID], [CategoryName]) VALUES (9, N'Súp')
INSERT [dbo].[Categories] ([CategoryID], [CategoryName]) VALUES (10, N'Bánh ngọt')
SET IDENTITY_INSERT [dbo].[Categories] OFF
GO
SET IDENTITY_INSERT [dbo].[Discount] ON 

INSERT [dbo].[Discount] ([DiscountID], [ProductID], [DiscountRate], [StartDate], [EndDate], [IsActive], [Description], [Image]) VALUES (1, 1, 0.4, CAST(N'2024-11-20' AS Date), CAST(N'2024-12-20' AS Date), 1, N'Giảm giá 40k', N'Discount_40.png')
INSERT [dbo].[Discount] ([DiscountID], [ProductID], [DiscountRate], [StartDate], [EndDate], [IsActive], [Description], [Image]) VALUES (2, 2, 0.5, CAST(N'2024-11-25' AS Date), CAST(N'2024-12-01' AS Date), 1, N'Giảm giá 50k', N'Discount_50.png')
INSERT [dbo].[Discount] ([DiscountID], [ProductID], [DiscountRate], [StartDate], [EndDate], [IsActive], [Description], [Image]) VALUES (3, 3, 0.5, CAST(N'2024-12-01' AS Date), CAST(N'2024-12-05' AS Date), 0, N'Giảm giá 50k Thứ 4', N'Discount_50_Wednesday.png')
INSERT [dbo].[Discount] ([DiscountID], [ProductID], [DiscountRate], [StartDate], [EndDate], [IsActive], [Description], [Image]) VALUES (4, 4, 0.25, CAST(N'2024-11-28' AS Date), CAST(N'2024-11-30' AS Date), 1, N'Giảm giá 199k', N'Discount_199.jpg')
INSERT [dbo].[Discount] ([DiscountID], [ProductID], [DiscountRate], [StartDate], [EndDate], [IsActive], [Description], [Image]) VALUES (5, 5, 0.05, CAST(N'2024-11-29' AS Date), CAST(N'2024-12-05' AS Date), 1, N'Freeship mỗi đơn hàng', N'Freeship.png')
INSERT [dbo].[Discount] ([DiscountID], [ProductID], [DiscountRate], [StartDate], [EndDate], [IsActive], [Description], [Image]) VALUES (6, 6, 0.1, CAST(N'2024-11-20' AS Date), CAST(N'2024-12-20' AS Date), 1, N'Freeship đơn 35k', N'Freeship_35.png')
INSERT [dbo].[Discount] ([DiscountID], [ProductID], [DiscountRate], [StartDate], [EndDate], [IsActive], [Description], [Image]) VALUES (7, 7, 0.15, CAST(N'2024-11-25' AS Date), CAST(N'2024-12-01' AS Date), 1, N'Freeship đơn 60k', N'Freeship_60.png')
SET IDENTITY_INSERT [dbo].[Discount] OFF
GO
SET IDENTITY_INSERT [dbo].[Orders] ON 

INSERT [dbo].[Orders] ([OrderID], [CustomerID], [OrderDate], [OrderItemsList], [TotalAmount]) VALUES (1, 1, CAST(N'2024-12-31T18:43:53.690' AS DateTime), N'[{"Item1":1,"Item2":1,"Item3":45000.0}]', CAST(45000.00 AS Decimal(10, 2)))
INSERT [dbo].[Orders] ([OrderID], [CustomerID], [OrderDate], [OrderItemsList], [TotalAmount]) VALUES (2, 1, CAST(N'2024-12-31T18:44:27.353' AS DateTime), N'[{"Item1":9,"Item2":3,"Item3":55000.0}]', CAST(165000.00 AS Decimal(10, 2)))
INSERT [dbo].[Orders] ([OrderID], [CustomerID], [OrderDate], [OrderItemsList], [TotalAmount]) VALUES (1002, 4002, CAST(N'2025-01-01T15:54:15.080' AS DateTime), N'[{"Item1":13,"Item2":1,"Item3":30000.0},{"Item1":3,"Item2":1,"Item3":30000.0}]', CAST(60000.00 AS Decimal(10, 2)))
INSERT [dbo].[Orders] ([OrderID], [CustomerID], [OrderDate], [OrderItemsList], [TotalAmount]) VALUES (2002, 1, CAST(N'2025-01-02T16:22:25.377' AS DateTime), N'[{"Item1":1,"Item2":1,"Item3":45000.0},{"Item1":9,"Item2":1,"Item3":55000.0}]', CAST(100000.00 AS Decimal(10, 2)))
SET IDENTITY_INSERT [dbo].[Orders] OFF
GO
SET IDENTITY_INSERT [dbo].[Products] ON 

INSERT [dbo].[Products] ([ProductID], [ProductName], [Price], [Description], [CategoryID], [Image], [Address], [SellerID], [Inventory]) VALUES (1, N'Burger', CAST(45000.00 AS Decimal(10, 2)), N'Burger bò truyền thống', 1, N'burger.jpg', N'Quận 1', 1, 90)
INSERT [dbo].[Products] ([ProductID], [ProductName], [Price], [Description], [CategoryID], [Image], [Address], [SellerID], [Inventory]) VALUES (2, N'Pizza', CAST(120000.00 AS Decimal(10, 2)), N'Pizza thập cẩm', 1, N'pizza.jpg', N'Quận 1', 1, 36)
INSERT [dbo].[Products] ([ProductID], [ProductName], [Price], [Description], [CategoryID], [Image], [Address], [SellerID], [Inventory]) VALUES (3, N'Trà sữa', CAST(30000.00 AS Decimal(10, 2)), N'Trà sữa trân châu', 2, N'tra_sua.jpg', N'Quận 2', 1, 36)
INSERT [dbo].[Products] ([ProductID], [ProductName], [Price], [Description], [CategoryID], [Image], [Address], [SellerID], [Inventory]) VALUES (4, N'Cơm tấm', CAST(40000.00 AS Decimal(10, 2)), N'Cơm tấm sườn bì chả', 3, N'com_tam.jpg', N'Quận 8', 1, 58)
INSERT [dbo].[Products] ([ProductID], [ProductName], [Price], [Description], [CategoryID], [Image], [Address], [SellerID], [Inventory]) VALUES (5, N'Bánh flan', CAST(15000.00 AS Decimal(10, 2)), N'Bánh flan caramel', 4, N'banh_flan.jpg', N'Quận 8', 1, 71)
INSERT [dbo].[Products] ([ProductID], [ProductName], [Price], [Description], [CategoryID], [Image], [Address], [SellerID], [Inventory]) VALUES (6, N'Bún chay', CAST(30000.00 AS Decimal(10, 2)), N'Bún chay đầy đủ', 5, N'bun_chay.jpg', N'Quận 2', 1, 80)
INSERT [dbo].[Products] ([ProductID], [ProductName], [Price], [Description], [CategoryID], [Image], [Address], [SellerID], [Inventory]) VALUES (7, N'Gà rán', CAST(50000.00 AS Decimal(10, 2)), N'Gà rán giòn rụm', 1, N'ga_ran.jpg', N'Quận 2', 1, 82)
INSERT [dbo].[Products] ([ProductID], [ProductName], [Price], [Description], [CategoryID], [Image], [Address], [SellerID], [Inventory]) VALUES (8, N'Cafe sữa', CAST(25000.00 AS Decimal(10, 2)), N'Cafe sữa đá', 2, N'ca_phe_sua.jpg', N'Quận 9', 1, 7)
INSERT [dbo].[Products] ([ProductID], [ProductName], [Price], [Description], [CategoryID], [Image], [Address], [SellerID], [Inventory]) VALUES (9, N'Cơm chiên dương châu', CAST(55000.00 AS Decimal(10, 2)), N'Cơm chiên với rau củ và thịt', 3, N'com_chien.jpg', N'Quận 9', 1, 72)
INSERT [dbo].[Products] ([ProductID], [ProductName], [Price], [Description], [CategoryID], [Image], [Address], [SellerID], [Inventory]) VALUES (10, N'Tôm hùm nướng', CAST(350000.00 AS Decimal(10, 2)), N'Tôm hùm nướng bơ tỏi', 7, N'tom_hum.jpg', N'Quận 10', 3, 77)
INSERT [dbo].[Products] ([ProductID], [ProductName], [Price], [Description], [CategoryID], [Image], [Address], [SellerID], [Inventory]) VALUES (11, N'Nước ép cam', CAST(20000.00 AS Decimal(10, 2)), N'Nước ép cam tươi', 2, N'nuoc_ep.png', N'Quận 3', 1, 55)
INSERT [dbo].[Products] ([ProductID], [ProductName], [Price], [Description], [CategoryID], [Image], [Address], [SellerID], [Inventory]) VALUES (12, N'Phở bò', CAST(60000.00 AS Decimal(10, 2)), N'Phở bò truyền thống', 3, N'pho_bo.jpg', N'Quận 3', 2, 16)
INSERT [dbo].[Products] ([ProductID], [ProductName], [Price], [Description], [CategoryID], [Image], [Address], [SellerID], [Inventory]) VALUES (13, N'Chả giò', CAST(30000.00 AS Decimal(10, 2)), N'Chả giò chiên giòn', 6, N'cha_gio.jpg', N'Quận 11', 1, 16)
INSERT [dbo].[Products] ([ProductID], [ProductName], [Price], [Description], [CategoryID], [Image], [Address], [SellerID], [Inventory]) VALUES (14, N'Súp cua', CAST(35000.00 AS Decimal(10, 2)), N'Súp cua bổ dưỡng', 9, N'sup_cua.jpg', N'Quận 11', 3, 31)
INSERT [dbo].[Products] ([ProductID], [ProductName], [Price], [Description], [CategoryID], [Image], [Address], [SellerID], [Inventory]) VALUES (15, N'Salad rau củ', CAST(25000.00 AS Decimal(10, 2)), N'Salad rau củ quả tươi', 8, N'salad_rau.jpg', N'Quận 11', 2, 82)
INSERT [dbo].[Products] ([ProductID], [ProductName], [Price], [Description], [CategoryID], [Image], [Address], [SellerID], [Inventory]) VALUES (16, N'Bánh cupcake', CAST(20000.00 AS Decimal(10, 2)), N'Cupcake socola', 10, N'cupcake.jpg', N'Quận 4', 1, 27)
INSERT [dbo].[Products] ([ProductID], [ProductName], [Price], [Description], [CategoryID], [Image], [Address], [SellerID], [Inventory]) VALUES (17, N'Tôm chiên xù', CAST(80000.00 AS Decimal(10, 2)), N'Tôm chiên giòn rụm', 7, N'tom_chien.jpg', N'Quận 4', 2, 8)
INSERT [dbo].[Products] ([ProductID], [ProductName], [Price], [Description], [CategoryID], [Image], [Address], [SellerID], [Inventory]) VALUES (18, N'Bánh mì thịt', CAST(15000.00 AS Decimal(10, 2)), N'Bánh mì thịt nướng', 1, N'banh_mi_thit.jpg', N'Quận 12', 1, 98)
INSERT [dbo].[Products] ([ProductID], [ProductName], [Price], [Description], [CategoryID], [Image], [Address], [SellerID], [Inventory]) VALUES (19, N'Sinh tố dâu', CAST(35000.00 AS Decimal(10, 2)), N'Sinh tố dâu tươi', 2, N'sinh_to.jpg', N'Quận 12', 3, 17)
INSERT [dbo].[Products] ([ProductID], [ProductName], [Price], [Description], [CategoryID], [Image], [Address], [SellerID], [Inventory]) VALUES (20, N'Cà phê đen', CAST(20000.00 AS Decimal(10, 2)), N'Cà phê đen đậm đà', 2, N'ca_phe_den.jpg', N'Quận 12', 2, 9)
INSERT [dbo].[Products] ([ProductID], [ProductName], [Price], [Description], [CategoryID], [Image], [Address], [SellerID], [Inventory]) VALUES (21, N'Mì xào bò', CAST(45000.00 AS Decimal(10, 2)), N'Mì xào thịt bò', 3, N'mi_xao_bo.jpg', N'Quận 5', 1, 76)
INSERT [dbo].[Products] ([ProductID], [ProductName], [Price], [Description], [CategoryID], [Image], [Address], [SellerID], [Inventory]) VALUES (22, N'Bánh su kem', CAST(15000.00 AS Decimal(10, 2)), N'Bánh su kem thơm ngon', 10, N'banh_xu_kem.jpg', N'Quận 5', 2, 57)
INSERT [dbo].[Products] ([ProductID], [ProductName], [Price], [Description], [CategoryID], [Image], [Address], [SellerID], [Inventory]) VALUES (23, N'Salad ức gà', CAST(45000.00 AS Decimal(10, 2)), N'Salad ức gà', 8, N'salad_ga.jpg', N'Quận 10', 1, 13)
INSERT [dbo].[Products] ([ProductID], [ProductName], [Price], [Description], [CategoryID], [Image], [Address], [SellerID], [Inventory]) VALUES (24, N'Xôi gà', CAST(30000.00 AS Decimal(10, 2)), N'Xôi gà nướng', 3, N'xoi_ga.jpg', N'Quận 10', 2, 86)
INSERT [dbo].[Products] ([ProductID], [ProductName], [Price], [Description], [CategoryID], [Image], [Address], [SellerID], [Inventory]) VALUES (25, N'Sữa chua dâu', CAST(20000.00 AS Decimal(10, 2)), N'Sữa chua dâu', 4, N'sua_chua.jpg', N'Quận 10', 1, 34)
INSERT [dbo].[Products] ([ProductID], [ProductName], [Price], [Description], [CategoryID], [Image], [Address], [SellerID], [Inventory]) VALUES (26, N'Mì Ý sốt bò', CAST(60000.00 AS Decimal(10, 2)), N'Mì Ý sốt bò bằm', 3, N'mi_y.jpg', N'Quận 6', 1, 89)
INSERT [dbo].[Products] ([ProductID], [ProductName], [Price], [Description], [CategoryID], [Image], [Address], [SellerID], [Inventory]) VALUES (27, N'Thịt heo quay', CAST(70000.00 AS Decimal(10, 2)), N'Thịt heo quay giòn', 3, N'heo_quay.jpg', N'Quận 6', 3, 97)
INSERT [dbo].[Products] ([ProductID], [ProductName], [Price], [Description], [CategoryID], [Image], [Address], [SellerID], [Inventory]) VALUES (28, N'Bánh xèo', CAST(40000.00 AS Decimal(10, 2)), N'Bánh xèo miền Tây', 1, N'banh_xeo.jpg', N'Quận 7', 2, 84)
INSERT [dbo].[Products] ([ProductID], [ProductName], [Price], [Description], [CategoryID], [Image], [Address], [SellerID], [Inventory]) VALUES (29, N'Trứng vịt lộn', CAST(10000.00 AS Decimal(10, 2)), N'Trứng vịt lộn', 1, N'trung_vit_lon.jpg', N'Quận 7', 1, 73)
INSERT [dbo].[Products] ([ProductID], [ProductName], [Price], [Description], [CategoryID], [Image], [Address], [SellerID], [Inventory]) VALUES (31, N'Mì gói', CAST(15000.00 AS Decimal(10, 2)), N'Mì gói ăn liền', 3, N'migoi.jpg', N'Quận Tân Phú', 3, 49)
INSERT [dbo].[Products] ([ProductID], [ProductName], [Price], [Description], [CategoryID], [Image], [Address], [SellerID], [Inventory]) VALUES (32, N'Sườn nướng', CAST(80000.00 AS Decimal(10, 2)), N'Sườn nướng thơm ngon', 1, N'suonnuong.jpg', N'Quận Thủ Đức', 4, 35)
INSERT [dbo].[Products] ([ProductID], [ProductName], [Price], [Description], [CategoryID], [Image], [Address], [SellerID], [Inventory]) VALUES (33, N'Mì xào hải sản', CAST(75000.00 AS Decimal(10, 2)), N'Mì xào hải sản tươi ngon', 3, N'mixaohs.jpg', N'Quận 1', 5, 20)
INSERT [dbo].[Products] ([ProductID], [ProductName], [Price], [Description], [CategoryID], [Image], [Address], [SellerID], [Inventory]) VALUES (34, N'Bánh tráng trộn', CAST(20000.00 AS Decimal(10, 2)), N'Bánh tráng trộn mặn ngọt', 4, N'banhtrangtron.jpg', N'Quận 2', 6, 63)
INSERT [dbo].[Products] ([ProductID], [ProductName], [Price], [Description], [CategoryID], [Image], [Address], [SellerID], [Inventory]) VALUES (35, N'Gỏi cuốn', CAST(35000.00 AS Decimal(10, 2)), N'Gỏi cuốn tôm thịt', 3, N'goicuon.jpg', N'Quận 3', 7, 24)
INSERT [dbo].[Products] ([ProductID], [ProductName], [Price], [Description], [CategoryID], [Image], [Address], [SellerID], [Inventory]) VALUES (36, N'Bánh bèo', CAST(25000.00 AS Decimal(10, 2)), N'Bánh bèo nóng hổi', 4, N'banhbeo.jpg', N'Quận 4', 8, 52)
INSERT [dbo].[Products] ([ProductID], [ProductName], [Price], [Description], [CategoryID], [Image], [Address], [SellerID], [Inventory]) VALUES (37, N'Cháo gà', CAST(40000.00 AS Decimal(10, 2)), N'Cháo gà thơm ngon', 3, N'chaoga.jpg', N'Quận 5', 1, 9)
INSERT [dbo].[Products] ([ProductID], [ProductName], [Price], [Description], [CategoryID], [Image], [Address], [SellerID], [Inventory]) VALUES (38, N'Bánh canh', CAST(45000.00 AS Decimal(10, 2)), N'Bánh canh cua đặc biệt', 3, N'banhcanh.jpg', N'Quận 6', 2, 15)
INSERT [dbo].[Products] ([ProductID], [ProductName], [Price], [Description], [CategoryID], [Image], [Address], [SellerID], [Inventory]) VALUES (39, N'Cháo lòng', CAST(30000.00 AS Decimal(10, 2)), N'Cháo lòng ngon, bổ', 3, N'chaolong.jpg', N'Quận 7', 3, 10)
INSERT [dbo].[Products] ([ProductID], [ProductName], [Price], [Description], [CategoryID], [Image], [Address], [SellerID], [Inventory]) VALUES (40, N'Cơm gà xối mỡ', CAST(70000.00 AS Decimal(10, 2)), N'Cơm gà xối mỡ giòn', 3, N'comgaxmo.jpg', N'Quận 8', 4, 59)
INSERT [dbo].[Products] ([ProductID], [ProductName], [Price], [Description], [CategoryID], [Image], [Address], [SellerID], [Inventory]) VALUES (41, N'Mỳ Ý hải sản', CAST(90000.00 AS Decimal(10, 2)), N'Mỳ Ý sốt hải sản', 3, N'miyhaysan.jpg', N'Quận 9', 5, 57)
INSERT [dbo].[Products] ([ProductID], [ProductName], [Price], [Description], [CategoryID], [Image], [Address], [SellerID], [Inventory]) VALUES (42, N'Bánh pía', CAST(22000.00 AS Decimal(10, 2)), N'Bánh pía ngọt ngào', 4, N'banhpia.jpg', N'Quận 10', 6, 36)
INSERT [dbo].[Products] ([ProductID], [ProductName], [Price], [Description], [CategoryID], [Image], [Address], [SellerID], [Inventory]) VALUES (43, N'Ba khía', CAST(60000.00 AS Decimal(10, 2)), N'Ba khía miền Tây', 2, N'bakhia.jpg', N'Quận 11', 7, 31)
INSERT [dbo].[Products] ([ProductID], [ProductName], [Price], [Description], [CategoryID], [Image], [Address], [SellerID], [Inventory]) VALUES (44, N'Mực nướng', CAST(120000.00 AS Decimal(10, 2)), N'Mực nướng sa tế', 1, N'mucnuong.jpg', N'Quận 12', 8, 14)
INSERT [dbo].[Products] ([ProductID], [ProductName], [Price], [Description], [CategoryID], [Image], [Address], [SellerID], [Inventory]) VALUES (45, N'Cơm rang thập cẩm', CAST(65000.00 AS Decimal(10, 2)), N'Cơm rang thập cẩm', 3, N'comrangthapcam.jpg', N'Quận Bình Thạnh', 1, 27)
INSERT [dbo].[Products] ([ProductID], [ProductName], [Price], [Description], [CategoryID], [Image], [Address], [SellerID], [Inventory]) VALUES (46, N'Tôm rang me', CAST(90000.00 AS Decimal(10, 2)), N'Tôm rang me thơm ngon', 1, N'tomrangme.jpg', N'Quận Gò Vấp', 2, 48)
INSERT [dbo].[Products] ([ProductID], [ProductName], [Price], [Description], [CategoryID], [Image], [Address], [SellerID], [Inventory]) VALUES (47, N'Bánh đúc', CAST(25000.00 AS Decimal(10, 2)), N'Bánh đúc dân dã', 4, N'banhduc.jpg', N'Quận Phú Nhuận', 3, 97)
INSERT [dbo].[Products] ([ProductID], [ProductName], [Price], [Description], [CategoryID], [Image], [Address], [SellerID], [Inventory]) VALUES (48, N'Gà quay', CAST(70000.00 AS Decimal(10, 2)), N'Gà quay thơm ngon', 1, N'gacquay.jpg', N'Quận Tân Bình', 4, 35)
INSERT [dbo].[Products] ([ProductID], [ProductName], [Price], [Description], [CategoryID], [Image], [Address], [SellerID], [Inventory]) VALUES (49, N'Cơm chiên hải sản', CAST(70000.00 AS Decimal(10, 2)), N'Cơm chiên hải sản đậm đà', 3, N'comchienhaisanhd.jpg', N'Quận Tân Phú', 5, 68)
INSERT [dbo].[Products] ([ProductID], [ProductName], [Price], [Description], [CategoryID], [Image], [Address], [SellerID], [Inventory]) VALUES (50, N'Bánh mì xíu mại', CAST(45000.00 AS Decimal(10, 2)), N'Bánh mì xíu mại ngon', 1, N'banhmixiumai.jpg', N'Quận Thủ Đức', 6, 41)
INSERT [dbo].[Products] ([ProductID], [ProductName], [Price], [Description], [CategoryID], [Image], [Address], [SellerID], [Inventory]) VALUES (51, N'Sushi', CAST(100000.00 AS Decimal(10, 2)), N'Sushi tươi ngon', 1, N'sushi.jpg', N'Quận 1', 7, 67)
SET IDENTITY_INSERT [dbo].[Products] OFF
GO
SET IDENTITY_INSERT [dbo].[Seller] ON 

INSERT [dbo].[Seller] ([SellerID], [Username], [Password], [Email], [PhoneNumber], [Address], [StoreName], [Avatar]) VALUES (1, N'seller1', N'2', N'seller1@example.com', N'0901234567', N'123 Seller St, HCM', N'Cửa Hàng A', N'D:\Study\Lap trinh CSDL\FoodOrdering-FlavorHaven\FoodOrdering-FlavorHaven\foodordering\bin\Debug\UserAvatar\seller1_avatar_temp.jpg')
INSERT [dbo].[Seller] ([SellerID], [Username], [Password], [Email], [PhoneNumber], [Address], [StoreName], [Avatar]) VALUES (2, N'seller2', N'1', N'seller2@example.com', N'0912345678', N'456 Vendor Rd, HCM', N'Cửa Hàng B', N'D:\Study\Lap trinh CSDL\Flavor Haven\project\foodordering\bin\Debug\UserAvatar\seller2_avatar_temp.jpg')
INSERT [dbo].[Seller] ([SellerID], [Username], [Password], [Email], [PhoneNumber], [Address], [StoreName], [Avatar]) VALUES (3, N'seller3', N'pass3', N'seller3@example.com', N'0923456789', N'789 Trader Ave, HCM', N'Cửa Hàng C', NULL)
INSERT [dbo].[Seller] ([SellerID], [Username], [Password], [Email], [PhoneNumber], [Address], [StoreName], [Avatar]) VALUES (4, N'seller4', N'pass4', N'seller4@example.com', N'0934567890', N'101 Dealer Blvd, HCM', N'Cửa Hàng D', NULL)
INSERT [dbo].[Seller] ([SellerID], [Username], [Password], [Email], [PhoneNumber], [Address], [StoreName], [Avatar]) VALUES (5, N'seller5', N'pass5', N'seller5@example.com', N'0945678901', N'202 Merchant Ln, HCM', N'Cửa Hàng E', NULL)
INSERT [dbo].[Seller] ([SellerID], [Username], [Password], [Email], [PhoneNumber], [Address], [StoreName], [Avatar]) VALUES (1002, N's12', N'123', N'Sell@gmail.com', N'09231', N'BBB', N'Cửa Hàng Khác', NULL)
INSERT [dbo].[Seller] ([SellerID], [Username], [Password], [Email], [PhoneNumber], [Address], [StoreName], [Avatar]) VALUES (1003, N's12', N'123', N'Sell@gmail.com', N'09231', N'BBB', N'Cửa Hàng Khác', NULL)
INSERT [dbo].[Seller] ([SellerID], [Username], [Password], [Email], [PhoneNumber], [Address], [StoreName], [Avatar]) VALUES (1004, N's12', N'123', N'Sell@gmail.com', N'09231', N'BBB', N'Cửa Hàng Khác', NULL)
INSERT [dbo].[Seller] ([SellerID], [Username], [Password], [Email], [PhoneNumber], [Address], [StoreName], [Avatar]) VALUES (1005, N'sell22', N'23', N'b@gmail', N'23', N'123213', N'Cửa Hàng Khác', NULL)
INSERT [dbo].[Seller] ([SellerID], [Username], [Password], [Email], [PhoneNumber], [Address], [StoreName], [Avatar]) VALUES (1006, N'sell22', N'23', N'b@gmail', N'23', N'123213', N'Cửa Hàng Khác', NULL)
INSERT [dbo].[Seller] ([SellerID], [Username], [Password], [Email], [PhoneNumber], [Address], [StoreName], [Avatar]) VALUES (1007, N'sell22', N'321', N'ha@gmail.com', N'231', N'231', N'Cửa Hàng Khác', NULL)
INSERT [dbo].[Seller] ([SellerID], [Username], [Password], [Email], [PhoneNumber], [Address], [StoreName], [Avatar]) VALUES (1008, N'sell22', N'321', N'ha@gmail.com', N'231', N'231', N'Cửa Hàng Khác', NULL)
INSERT [dbo].[Seller] ([SellerID], [Username], [Password], [Email], [PhoneNumber], [Address], [StoreName], [Avatar]) VALUES (1009, N'sell223', N'1', N'2@g', N'213', N'1212', N'Cửa Hàng Khác', NULL)
INSERT [dbo].[Seller] ([SellerID], [Username], [Password], [Email], [PhoneNumber], [Address], [StoreName], [Avatar]) VALUES (1010, N'tbinh2', N'123', N'binh@gmail.com', N'123', N'123', N'Cửa Hàng Khác', NULL)
INSERT [dbo].[Seller] ([SellerID], [Username], [Password], [Email], [PhoneNumber], [Address], [StoreName], [Avatar]) VALUES (2002, N'binh', N'1', N'thanh@gmail.com', N'0833537895', N'Quận 1', NULL, N'D:\Study\Lap trinh CSDL\Flavor Haven\project\foodordering\bin\Debug\UserAvatar\binh_avatar.jpg')
SET IDENTITY_INSERT [dbo].[Seller] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([UserID], [Username], [Password], [Email], [PhoneNumber], [Address], [Avatar]) VALUES (1, N'user1', N'password1', N'user1@example.com', N'0123456789', N'123 Main St, HCM City', NULL)
INSERT [dbo].[Users] ([UserID], [Username], [Password], [Email], [PhoneNumber], [Address], [Avatar]) VALUES (2, N'user2', N'password2', N'user2@example.com', N'0987654321', N'456 High St, HCM City', NULL)
INSERT [dbo].[Users] ([UserID], [Username], [Password], [Email], [PhoneNumber], [Address], [Avatar]) VALUES (3, N'user3', N'password3', N'user3@example.com', N'0112233445', N'789 Low St, HCM City', NULL)
INSERT [dbo].[Users] ([UserID], [Username], [Password], [Email], [PhoneNumber], [Address], [Avatar]) VALUES (4, N'user4', N'password4', N'user4@example.com', N'0223344556', N'123 Middle St, HCM City', NULL)
INSERT [dbo].[Users] ([UserID], [Username], [Password], [Email], [PhoneNumber], [Address], [Avatar]) VALUES (5, N'user5', N'password5', N'user5@example.com', N'0334455667', N'321 Another St, HCM City', NULL)
INSERT [dbo].[Users] ([UserID], [Username], [Password], [Email], [PhoneNumber], [Address], [Avatar]) VALUES (6, N'user6', N'password6', N'user6@example.com', N'0445566778', N'654 River St, HCM City', NULL)
INSERT [dbo].[Users] ([UserID], [Username], [Password], [Email], [PhoneNumber], [Address], [Avatar]) VALUES (7, N'user7', N'password7', N'user7@example.com', N'0556677889', N'987 Ocean St, HCM City', NULL)
INSERT [dbo].[Users] ([UserID], [Username], [Password], [Email], [PhoneNumber], [Address], [Avatar]) VALUES (8, N'user8', N'password8', N'user8@example.com', N'0667788990', N'159 Liberty St, HCM City', NULL)
INSERT [dbo].[Users] ([UserID], [Username], [Password], [Email], [PhoneNumber], [Address], [Avatar]) VALUES (9, N'user9', N'password9', N'user9@example.com', N'0778899001', N'753 Bridge St, HCM City', NULL)
INSERT [dbo].[Users] ([UserID], [Username], [Password], [Email], [PhoneNumber], [Address], [Avatar]) VALUES (10, N'user10', N'password10', N'user10@example.com', N'0889900112', N'951 Elm St, HCM City', NULL)
INSERT [dbo].[Users] ([UserID], [Username], [Password], [Email], [PhoneNumber], [Address], [Avatar]) VALUES (1002, N'haha', N'hahaha', NULL, NULL, NULL, NULL)
INSERT [dbo].[Users] ([UserID], [Username], [Password], [Email], [PhoneNumber], [Address], [Avatar]) VALUES (2002, N'tbinh', N'99', N'binh@gmail.com', N'0923333', N'Nguyen Trai', NULL)
INSERT [dbo].[Users] ([UserID], [Username], [Password], [Email], [PhoneNumber], [Address], [Avatar]) VALUES (3002, N'tbbb', N'123', NULL, NULL, NULL, NULL)
INSERT [dbo].[Users] ([UserID], [Username], [Password], [Email], [PhoneNumber], [Address], [Avatar]) VALUES (3003, N'tbb', N'123', NULL, NULL, NULL, NULL)
INSERT [dbo].[Users] ([UserID], [Username], [Password], [Email], [PhoneNumber], [Address], [Avatar]) VALUES (4002, N'tbinh99', N'2', NULL, NULL, NULL, N'D:\Study\Lap trinh CSDL\FoodOrdering-FlavorHaven\FoodOrdering-FlavorHaven\foodordering\bin\Debug\UserAvatar\tbinh99_avatar_temp.jpg')
INSERT [dbo].[Users] ([UserID], [Username], [Password], [Email], [PhoneNumber], [Address], [Avatar]) VALUES (5002, N'ha', N'321', NULL, NULL, NULL, NULL)
INSERT [dbo].[Users] ([UserID], [Username], [Password], [Email], [PhoneNumber], [Address], [Avatar]) VALUES (6002, N'sell1', N'123', N'sell@gmail.com', N'213213', N'Nguyen', NULL)
INSERT [dbo].[Users] ([UserID], [Username], [Password], [Email], [PhoneNumber], [Address], [Avatar]) VALUES (6003, N'sell3', N'123', N'sell@gmail.com', N'213213', N'Nguyen', NULL)
INSERT [dbo].[Users] ([UserID], [Username], [Password], [Email], [PhoneNumber], [Address], [Avatar]) VALUES (6004, N'sell12', N'123', N'sell@gmail.com', N'21312321', N'Nguyen', NULL)
INSERT [dbo].[Users] ([UserID], [Username], [Password], [Email], [PhoneNumber], [Address], [Avatar]) VALUES (6005, N's', N'2', N'2@gm', N'123213', N'2154', NULL)
INSERT [dbo].[Users] ([UserID], [Username], [Password], [Email], [PhoneNumber], [Address], [Avatar]) VALUES (6006, N'sell2', N'23', N'b@gmail', N'23', N'123213', NULL)
INSERT [dbo].[Users] ([UserID], [Username], [Password], [Email], [PhoneNumber], [Address], [Avatar]) VALUES (7002, N'tbinh3', N'99', N'tb@gmail.com', N'34234', N'4234234', NULL)
INSERT [dbo].[Users] ([UserID], [Username], [Password], [Email], [PhoneNumber], [Address], [Avatar]) VALUES (8002, N'testAvatar', N'123', N'test@gmail.com', N'123', N'Quận 3', N'UserAvatar/avatar.jpg')
INSERT [dbo].[Users] ([UserID], [Username], [Password], [Email], [PhoneNumber], [Address], [Avatar]) VALUES (8003, N'testAva2', N'1', N't@gmail.com', N'123', N'Quận 1', N'D:\Study\Lap trinh CSDL\Flavor Haven\project\foodordering\bin\Debug\UserAvatar\testAva2_avatar.jpg')
INSERT [dbo].[Users] ([UserID], [Username], [Password], [Email], [PhoneNumber], [Address], [Avatar]) VALUES (8004, N'goku', N'3', N'goku@gmail.com', N'999', N'132', N'D:\Study\Lap trinh CSDL\Flavor Haven\project\foodordering\bin\Debug\UserAvatar\goku_avatar_temp.jpg')
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
ALTER TABLE [dbo].[Discount] ADD  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[Orders] ADD  DEFAULT (getdate()) FOR [OrderDate]
GO
ALTER TABLE [dbo].[Cart_Item]  WITH CHECK ADD FOREIGN KEY([ProductID])
REFERENCES [dbo].[Products] ([ProductID])
GO
ALTER TABLE [dbo].[Cart_Item]  WITH CHECK ADD FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[Discount]  WITH CHECK ADD  CONSTRAINT [FK_Discount_Product] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Products] ([ProductID])
GO
ALTER TABLE [dbo].[Discount] CHECK CONSTRAINT [FK_Discount_Product]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD FOREIGN KEY([CategoryID])
REFERENCES [dbo].[Categories] ([CategoryID])
GO
ALTER TABLE [dbo].[Discount]  WITH CHECK ADD CHECK  (([DiscountRate]>(0) AND [DiscountRate]<=(1)))
GO
USE [master]
GO
ALTER DATABASE [Test] SET  READ_WRITE 
GO
