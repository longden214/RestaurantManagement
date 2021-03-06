USE [master]
GO
/****** Object:  Database [RestaurantManagement]    Script Date: 4/28/2021 3:25:50 PM ******/
CREATE DATABASE [RestaurantManagement]
go
use [RestaurantManagement]
go
ALTER DATABASE [RestaurantManagement] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [RestaurantManagement].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [RestaurantManagement] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [RestaurantManagement] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [RestaurantManagement] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [RestaurantManagement] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [RestaurantManagement] SET ARITHABORT OFF 
GO
ALTER DATABASE [RestaurantManagement] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [RestaurantManagement] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [RestaurantManagement] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [RestaurantManagement] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [RestaurantManagement] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [RestaurantManagement] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [RestaurantManagement] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [RestaurantManagement] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [RestaurantManagement] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [RestaurantManagement] SET  ENABLE_BROKER 
GO
ALTER DATABASE [RestaurantManagement] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [RestaurantManagement] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [RestaurantManagement] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [RestaurantManagement] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [RestaurantManagement] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [RestaurantManagement] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [RestaurantManagement] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [RestaurantManagement] SET RECOVERY FULL 
GO
ALTER DATABASE [RestaurantManagement] SET  MULTI_USER 
GO
ALTER DATABASE [RestaurantManagement] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [RestaurantManagement] SET DB_CHAINING OFF 
GO
ALTER DATABASE [RestaurantManagement] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [RestaurantManagement] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [RestaurantManagement] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'RestaurantManagement', N'ON'
GO
USE [RestaurantManagement]
GO
/****** Object:  UserDefinedFunction [dbo].[fuConvertToUnsign1]    Script Date: 4/28/2021 3:25:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE FUNCTION [dbo].[fuConvertToUnsign1] ( @strInput NVARCHAR(4000) ) RETURNS NVARCHAR(4000) AS BEGIN IF @strInput IS NULL RETURN @strInput IF @strInput = '' RETURN @strInput DECLARE @RT NVARCHAR(4000) DECLARE @SIGN_CHARS NCHAR(136) DECLARE @UNSIGN_CHARS NCHAR (136) SET @SIGN_CHARS = N'ăâđêôơưàảãạáằẳẵặắầẩẫậấèẻẽẹéềểễệế ìỉĩịíòỏõọóồổỗộốờởỡợớùủũụúừửữựứỳỷỹỵý Ă ĐÊÔƠƯÀẢÃẠÁẰẲẴẶẮẦẨẪẬẤÈẺẼẸÉỀỂỄỆẾÌỈĨỊÍ ÒỎÕỌÓỒỔỖỘỐỜỞỠỢỚÙỦŨỤÚỪỬỮỰỨỲỶỸỴÝ' +NCHAR(272)+ NCHAR(208) SET @UNSIGN_CHARS = N'aadeoouaaaaaaaaaaaaaaaeeeeeeeeee iiiiiooooooooooooooouuuuuuuuuuyyyyy AADEOOUAAAAAAAAAAAAAAAEEEEEEEEEEIIIII OOOOOOOOOOOOOOOUUUUUUUUUUYYYYYDD' DECLARE @COUNTER int DECLARE @COUNTER1 int SET @COUNTER = 1 WHILE (@COUNTER <=LEN(@strInput)) BEGIN SET @COUNTER1 = 1 WHILE (@COUNTER1 <=LEN(@SIGN_CHARS)+1) BEGIN IF UNICODE(SUBSTRING(@SIGN_CHARS, @COUNTER1,1)) = UNICODE(SUBSTRING(@strInput,@COUNTER ,1) ) BEGIN IF @COUNTER=1 SET @strInput = SUBSTRING(@UNSIGN_CHARS, @COUNTER1,1) + SUBSTRING(@strInput, @COUNTER+1,LEN(@strInput)-1) ELSE SET @strInput = SUBSTRING(@strInput, 1, @COUNTER-1) +SUBSTRING(@UNSIGN_CHARS, @COUNTER1,1) + SUBSTRING(@strInput, @COUNTER+1,LEN(@strInput)- @COUNTER) BREAK END SET @COUNTER1 = @COUNTER1 +1 END SET @COUNTER = @COUNTER +1 END SET @strInput = replace(@strInput,' ','-') RETURN @strInput END


GO
/****** Object:  Table [dbo].[Account]    Script Date: 4/28/2021 3:25:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Account](
	[userName] [nvarchar](100) NOT NULL,
	[displayName] [nvarchar](100) NOT NULL,
	[passWord] [nvarchar](1000) NOT NULL DEFAULT ((0)),
	[type] [int] NOT NULL DEFAULT ((2)),
PRIMARY KEY CLUSTERED 
(
	[userName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AccountType]    Script Date: 4/28/2021 3:25:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AccountType](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Bill]    Script Date: 4/28/2021 3:25:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bill](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[dateCheckIn] [date] NOT NULL DEFAULT (getdate()),
	[dateCheckOut] [date] NULL,
	[idTable] [int] NOT NULL,
	[status] [int] NOT NULL DEFAULT ((0)),
	[discount] [int] NULL,
	[totalPrice] [float] NULL DEFAULT ((0)),
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[BillInfo]    Script Date: 4/28/2021 3:25:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BillInfo](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idBill] [int] NOT NULL,
	[idFood] [int] NOT NULL,
	[count] [int] NOT NULL DEFAULT ((0)),
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Category]    Script Date: 4/28/2021 3:25:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](100) NOT NULL DEFAULT (N'Chưa đặt tên'),
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Food]    Script Date: 4/28/2021 3:25:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Food](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](100) NOT NULL DEFAULT (N'Chưa đặt tên'),
	[idCategory] [int] NOT NULL,
	[price] [float] NOT NULL DEFAULT ((0)),
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TableFood]    Script Date: 4/28/2021 3:25:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TableFood](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](100) NOT NULL DEFAULT (N'Bàn chưa có tên'),
	[status] [nvarchar](100) NOT NULL DEFAULT (N'Trống'),
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
INSERT [dbo].[Account] ([userName], [displayName], [passWord], [type]) VALUES (N'dat08', N'Tien Dat', N'37213902101311706410244100199109113607173', 2)
INSERT [dbo].[Account] ([userName], [displayName], [passWord], [type]) VALUES (N'hang2012', N'Hang Beo', N'20720532132149213101239102231223249249135100218', 2)
INSERT [dbo].[Account] ([userName], [displayName], [passWord], [type]) VALUES (N'quanglong', N'Long Den', N'37213902101311706410244100199109113607173', 1)
INSERT [dbo].[Account] ([userName], [displayName], [passWord], [type]) VALUES (N'quyetseven', N'Quyet08', N'9413410316457198143816922147203236240349', 2)
SET IDENTITY_INSERT [dbo].[AccountType] ON 

INSERT [dbo].[AccountType] ([id], [name]) VALUES (1, N'Admin')
INSERT [dbo].[AccountType] ([id], [name]) VALUES (2, N'Nhân viên')
SET IDENTITY_INSERT [dbo].[AccountType] OFF
SET IDENTITY_INSERT [dbo].[Bill] ON 

INSERT [dbo].[Bill] ([id], [dateCheckIn], [dateCheckOut], [idTable], [status], [discount], [totalPrice]) VALUES (31, CAST(N'2021-04-20' AS Date), CAST(N'2021-04-20' AS Date), 3, 1, 10, 158400)
INSERT [dbo].[Bill] ([id], [dateCheckIn], [dateCheckOut], [idTable], [status], [discount], [totalPrice]) VALUES (32, CAST(N'2021-04-20' AS Date), CAST(N'2021-04-20' AS Date), 6, 1, 20, 544800)
INSERT [dbo].[Bill] ([id], [dateCheckIn], [dateCheckOut], [idTable], [status], [discount], [totalPrice]) VALUES (33, CAST(N'2021-04-20' AS Date), CAST(N'2021-04-20' AS Date), 19, 1, 0, 752000)
INSERT [dbo].[Bill] ([id], [dateCheckIn], [dateCheckOut], [idTable], [status], [discount], [totalPrice]) VALUES (34, CAST(N'2021-04-20' AS Date), CAST(N'2021-04-20' AS Date), 14, 1, 25, 453750)
INSERT [dbo].[Bill] ([id], [dateCheckIn], [dateCheckOut], [idTable], [status], [discount], [totalPrice]) VALUES (35, CAST(N'2021-04-20' AS Date), CAST(N'2021-04-20' AS Date), 12, 1, 0, 276000)
INSERT [dbo].[Bill] ([id], [dateCheckIn], [dateCheckOut], [idTable], [status], [discount], [totalPrice]) VALUES (36, CAST(N'2021-04-20' AS Date), NULL, 14, 0, 0, 0)
INSERT [dbo].[Bill] ([id], [dateCheckIn], [dateCheckOut], [idTable], [status], [discount], [totalPrice]) VALUES (37, CAST(N'2021-04-20' AS Date), NULL, 20, 0, NULL, 0)
INSERT [dbo].[Bill] ([id], [dateCheckIn], [dateCheckOut], [idTable], [status], [discount], [totalPrice]) VALUES (38, CAST(N'2021-04-20' AS Date), CAST(N'2021-04-20' AS Date), 2, 1, 0, 454000)
INSERT [dbo].[Bill] ([id], [dateCheckIn], [dateCheckOut], [idTable], [status], [discount], [totalPrice]) VALUES (39, CAST(N'2021-04-22' AS Date), CAST(N'2021-04-22' AS Date), 2, 1, 20, 173600)
INSERT [dbo].[Bill] ([id], [dateCheckIn], [dateCheckOut], [idTable], [status], [discount], [totalPrice]) VALUES (40, CAST(N'2021-04-22' AS Date), CAST(N'2021-04-22' AS Date), 3, 1, 0, 2636000)
INSERT [dbo].[Bill] ([id], [dateCheckIn], [dateCheckOut], [idTable], [status], [discount], [totalPrice]) VALUES (41, CAST(N'2021-04-22' AS Date), NULL, 15, 0, 0, 0)
INSERT [dbo].[Bill] ([id], [dateCheckIn], [dateCheckOut], [idTable], [status], [discount], [totalPrice]) VALUES (42, CAST(N'2021-04-22' AS Date), CAST(N'2021-04-25' AS Date), 12, 1, 0, 129000)
INSERT [dbo].[Bill] ([id], [dateCheckIn], [dateCheckOut], [idTable], [status], [discount], [totalPrice]) VALUES (43, CAST(N'2021-04-24' AS Date), CAST(N'2021-04-24' AS Date), 9, 1, 0, 157000)
INSERT [dbo].[Bill] ([id], [dateCheckIn], [dateCheckOut], [idTable], [status], [discount], [totalPrice]) VALUES (44, CAST(N'2021-04-24' AS Date), CAST(N'2021-04-24' AS Date), 16, 1, 0, 118000)
INSERT [dbo].[Bill] ([id], [dateCheckIn], [dateCheckOut], [idTable], [status], [discount], [totalPrice]) VALUES (46, CAST(N'2021-04-24' AS Date), CAST(N'2021-04-24' AS Date), 1, 1, 0, 94000)
INSERT [dbo].[Bill] ([id], [dateCheckIn], [dateCheckOut], [idTable], [status], [discount], [totalPrice]) VALUES (47, CAST(N'2021-04-24' AS Date), CAST(N'2021-04-25' AS Date), 5, 1, 25, 114750)
INSERT [dbo].[Bill] ([id], [dateCheckIn], [dateCheckOut], [idTable], [status], [discount], [totalPrice]) VALUES (48, CAST(N'2021-04-24' AS Date), CAST(N'2021-04-25' AS Date), 16, 1, 0, 238000)
INSERT [dbo].[Bill] ([id], [dateCheckIn], [dateCheckOut], [idTable], [status], [discount], [totalPrice]) VALUES (49, CAST(N'2021-04-24' AS Date), CAST(N'2021-04-25' AS Date), 18, 1, 0, 158000)
INSERT [dbo].[Bill] ([id], [dateCheckIn], [dateCheckOut], [idTable], [status], [discount], [totalPrice]) VALUES (50, CAST(N'2021-04-25' AS Date), CAST(N'2021-04-25' AS Date), 2, 1, 25, 490500)
INSERT [dbo].[Bill] ([id], [dateCheckIn], [dateCheckOut], [idTable], [status], [discount], [totalPrice]) VALUES (51, CAST(N'2021-04-25' AS Date), CAST(N'2021-04-25' AS Date), 19, 1, 0, 188000)
INSERT [dbo].[Bill] ([id], [dateCheckIn], [dateCheckOut], [idTable], [status], [discount], [totalPrice]) VALUES (52, CAST(N'2021-04-25' AS Date), CAST(N'2021-04-25' AS Date), 16, 1, 0, 1517000)
INSERT [dbo].[Bill] ([id], [dateCheckIn], [dateCheckOut], [idTable], [status], [discount], [totalPrice]) VALUES (53, CAST(N'2021-04-25' AS Date), CAST(N'2021-04-25' AS Date), 12, 1, 0, 213000)
INSERT [dbo].[Bill] ([id], [dateCheckIn], [dateCheckOut], [idTable], [status], [discount], [totalPrice]) VALUES (54, CAST(N'2021-04-25' AS Date), CAST(N'2021-04-25' AS Date), 17, 1, 0, 591000)
INSERT [dbo].[Bill] ([id], [dateCheckIn], [dateCheckOut], [idTable], [status], [discount], [totalPrice]) VALUES (55, CAST(N'2021-04-25' AS Date), CAST(N'2021-04-25' AS Date), 18, 1, 0, 505000)
INSERT [dbo].[Bill] ([id], [dateCheckIn], [dateCheckOut], [idTable], [status], [discount], [totalPrice]) VALUES (56, CAST(N'2021-04-25' AS Date), CAST(N'2021-04-25' AS Date), 18, 1, 0, 365000)
INSERT [dbo].[Bill] ([id], [dateCheckIn], [dateCheckOut], [idTable], [status], [discount], [totalPrice]) VALUES (57, CAST(N'2021-04-26' AS Date), CAST(N'2021-04-26' AS Date), 10, 1, 0, 94000)
SET IDENTITY_INSERT [dbo].[Bill] OFF
SET IDENTITY_INSERT [dbo].[BillInfo] ON 

INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (48, 31, 1, 1)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (49, 31, 7, 2)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (50, 31, 10, 2)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (51, 32, 3, 3)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (52, 32, 10, 2)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (53, 32, 7, 2)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (54, 33, 7, 2)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (55, 33, 3, 4)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (56, 34, 2, 6)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (57, 34, 4, 3)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (58, 35, 1, 2)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (59, 35, 6, 2)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (60, 49, 6, 2)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (61, 38, 1, 1)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (62, 38, 2, 6)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (63, 38, 7, 2)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (64, 39, 4, 1)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (65, 39, 10, 1)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (66, 39, 1, 1)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (67, 40, 1, 2)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (68, 40, 11, 2)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (72, 42, 10, 2)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (73, 42, 1, 1)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (75, 43, 7, 2)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (80, 47, 10, 1)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (81, 47, 7, 2)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (82, 47, 1, 1)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (83, 48, 2, 6)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (84, 48, 4, 1)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (85, 50, 2, 6)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (86, 51, 7, 2)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (87, 51, 10, 2)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (88, 52, 10, 2)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (89, 52, 11, 1)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (90, 52, 4, 1)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (91, 52, 7, 2)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (92, 53, 7, 2)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (93, 53, 6, 1)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (94, 53, 17, 3)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (95, 54, 17, 3)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (96, 54, 4, 2)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (97, 54, 3, 2)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (98, 55, 2, 3)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (99, 55, 5, 2)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (100, 56, 7, 2)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (101, 56, 4, 1)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (102, 56, 1, 2)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (103, 57, 1, 1)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (104, 57, 10, 1)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (105, 41, 1, 3)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (106, 41, 7, 2)
SET IDENTITY_INSERT [dbo].[BillInfo] OFF
SET IDENTITY_INSERT [dbo].[Category] ON 

INSERT [dbo].[Category] ([id], [name]) VALUES (1, N'Khai vị')
INSERT [dbo].[Category] ([id], [name]) VALUES (17, N'MainCourse')
INSERT [dbo].[Category] ([id], [name]) VALUES (2, N'Salad')
INSERT [dbo].[Category] ([id], [name]) VALUES (3, N'Soup')
INSERT [dbo].[Category] ([id], [name]) VALUES (4, N'Thức uống')
SET IDENTITY_INSERT [dbo].[Category] OFF
SET IDENTITY_INSERT [dbo].[Food] ON 

INSERT [dbo].[Food] ([id], [name], [idCategory], [price]) VALUES (1, N'Khoai Tây Chiên', 1, 59000)
INSERT [dbo].[Food] ([id], [name], [idCategory], [price]) VALUES (2, N'Tôm Chiên Xù', 1, 109000)
INSERT [dbo].[Food] ([id], [name], [idCategory], [price]) VALUES (3, N'Chả Giò Hải Sản', 1, 129000)
INSERT [dbo].[Food] ([id], [name], [idCategory], [price]) VALUES (4, N'Salad Cá Hồi', 2, 129000)
INSERT [dbo].[Food] ([id], [name], [idCategory], [price]) VALUES (5, N'Salad Pháp', 2, 89000)
INSERT [dbo].[Food] ([id], [name], [idCategory], [price]) VALUES (6, N'Salad Cà Chua', 2, 79000)
INSERT [dbo].[Food] ([id], [name], [idCategory], [price]) VALUES (7, N'Soup Bí Đỏ', 3, 59000)
INSERT [dbo].[Food] ([id], [name], [idCategory], [price]) VALUES (8, N'Soup Rau Củ Kiểu ý', 3, 69000)
INSERT [dbo].[Food] ([id], [name], [idCategory], [price]) VALUES (9, N'Soup Gà Mạch Hoạch', 3, 89000)
INSERT [dbo].[Food] ([id], [name], [idCategory], [price]) VALUES (10, N'Rượu Hàn Quốc', 4, 35000)
INSERT [dbo].[Food] ([id], [name], [idCategory], [price]) VALUES (11, N'Rượu Chivas', 4, 1259000)
INSERT [dbo].[Food] ([id], [name], [idCategory], [price]) VALUES (12, N'Coca Cola', 4, 25000)
INSERT [dbo].[Food] ([id], [name], [idCategory], [price]) VALUES (17, N'Pepsi', 4, 25000)
INSERT [dbo].[Food] ([id], [name], [idCategory], [price]) VALUES (18, N'Salad Tôm Hùm', 2, 240000)
SET IDENTITY_INSERT [dbo].[Food] OFF
SET IDENTITY_INSERT [dbo].[TableFood] ON 

INSERT [dbo].[TableFood] ([id], [name], [status]) VALUES (1, N'Bàn 100', N'Trống')
INSERT [dbo].[TableFood] ([id], [name], [status]) VALUES (2, N'Bàn 101', N'Trống')
INSERT [dbo].[TableFood] ([id], [name], [status]) VALUES (3, N'Bàn 102', N'Trống')
INSERT [dbo].[TableFood] ([id], [name], [status]) VALUES (4, N'Bàn 103', N'Trống')
INSERT [dbo].[TableFood] ([id], [name], [status]) VALUES (5, N'Bàn 104', N'Trống')
INSERT [dbo].[TableFood] ([id], [name], [status]) VALUES (6, N'Bàn 105', N'Trống')
INSERT [dbo].[TableFood] ([id], [name], [status]) VALUES (7, N'Bàn 106', N'Trống')
INSERT [dbo].[TableFood] ([id], [name], [status]) VALUES (8, N'Bàn 107', N'Trống')
INSERT [dbo].[TableFood] ([id], [name], [status]) VALUES (9, N'Bàn 108', N'Trống')
INSERT [dbo].[TableFood] ([id], [name], [status]) VALUES (10, N'Bàn 109', N'Trống')
INSERT [dbo].[TableFood] ([id], [name], [status]) VALUES (12, N'Bàn 201', N'Trống')
INSERT [dbo].[TableFood] ([id], [name], [status]) VALUES (13, N'Bàn 202', N'Trống')
INSERT [dbo].[TableFood] ([id], [name], [status]) VALUES (14, N'Bàn 203', N'Trống')
INSERT [dbo].[TableFood] ([id], [name], [status]) VALUES (15, N'Bàn 204', N'Có người')
INSERT [dbo].[TableFood] ([id], [name], [status]) VALUES (16, N'Bàn 205', N'Trống')
INSERT [dbo].[TableFood] ([id], [name], [status]) VALUES (17, N'Bàn 206', N'Trống')
INSERT [dbo].[TableFood] ([id], [name], [status]) VALUES (18, N'Bàn 207', N'Trống')
INSERT [dbo].[TableFood] ([id], [name], [status]) VALUES (19, N'Bàn 208', N'Trống')
INSERT [dbo].[TableFood] ([id], [name], [status]) VALUES (20, N'Bàn 209', N'Trống')
SET IDENTITY_INSERT [dbo].[TableFood] OFF
SET ANSI_PADDING ON

GO
/****** Object:  Index [UQ__Category__72E12F1B02AC5233]    Script Date: 4/28/2021 3:25:52 PM ******/
ALTER TABLE [dbo].[Category] ADD UNIQUE NONCLUSTERED 
(
	[name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UQ__TableFoo__72E12F1BE2C31545]    Script Date: 4/28/2021 3:25:52 PM ******/
ALTER TABLE [dbo].[TableFood] ADD UNIQUE NONCLUSTERED 
(
	[name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Account]  WITH CHECK ADD FOREIGN KEY([type])
REFERENCES [dbo].[AccountType] ([id])
GO
ALTER TABLE [dbo].[Bill]  WITH CHECK ADD FOREIGN KEY([idTable])
REFERENCES [dbo].[TableFood] ([id])
GO
ALTER TABLE [dbo].[BillInfo]  WITH CHECK ADD FOREIGN KEY([idBill])
REFERENCES [dbo].[Bill] ([id])
GO
ALTER TABLE [dbo].[BillInfo]  WITH CHECK ADD FOREIGN KEY([idFood])
REFERENCES [dbo].[Food] ([id])
GO
ALTER TABLE [dbo].[Food]  WITH CHECK ADD FOREIGN KEY([idCategory])
REFERENCES [dbo].[Category] ([id])
GO
/****** Object:  StoredProcedure [dbo].[GetListMenuByTable]    Script Date: 4/28/2021 3:25:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[GetListMenuByTable]
	@idTable int
as
begin
	SELECT f.name, bi.count, f.price, f.price*bi.count AS totalPrice 
	FROM dbo.BillInfo AS bi, dbo.Bill AS b, dbo.Food AS f WHERE bi.idBill = b.id AND bi.idFood = f.id AND b.status = 0 AND b.idTable = @idTable
end

GO
/****** Object:  StoredProcedure [dbo].[USP_AddNewAccount]    Script Date: 4/28/2021 3:25:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[USP_AddNewAccount]
 @username nvarchar(100),
 @displayName nvarchar(100),
 @type int
as
begin
	INSERT dbo.Account( userName, displayName, type ,password) VALUES
		( @username,@displayName,@type,'20720532132149213101239102231223249249135100218')
end
GO
/****** Object:  StoredProcedure [dbo].[USP_AddNewFood]    Script Date: 4/28/2021 3:25:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[USP_AddNewFood]
 @name nvarchar(100),
 @idCategory int,
 @price float
as
begin
	INSERT dbo.Food ( name, idCategory, price ) VALUES
		( @name,@idCategory,@price)
end
GO
/****** Object:  StoredProcedure [dbo].[USP_GetAccountByUserName]    Script Date: 4/28/2021 3:25:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_GetAccountByUserName]
	@userName nvarchar(100)
AS 
BEGIN
	SELECT * FROM dbo.Account WHERE UserName = @userName
END

GO
/****** Object:  StoredProcedure [dbo].[USP_GetListBillByDate]    Script Date: 4/28/2021 3:25:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_GetListBillByDate]
	@checkIn datetime,
	@checkOut datetime
as
begin
	select  b.id as 'Mã Đơn hàng',
			tb.name as ' Tên bàn ',
			b.dateCheckIn as 'Ngày vào',
			b.dateCheckOut as 'Ngày ra',
			b.discount as 'Giảm giá',
			b.totalPrice as 'Tổng tiền'
	from Bill as b
	join TableFood as tb on b.idTable = tb.id
	where b.dateCheckIn >= @checkIn and b.dateCheckOut <= @checkOut and b.status = 1
end

GO
/****** Object:  StoredProcedure [dbo].[USP_GetListBillByDateAndPage]    Script Date: 4/28/2021 3:25:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_GetListBillByDateAndPage]
@checkIn date, @checkOut date, @page int
AS 
BEGIN
	DECLARE @pageRows INT = 10
	DECLARE @selectRows INT = @pageRows
	DECLARE @exceptRows INT = (@page - 1) * @pageRows
	
	;WITH BillShow AS( SELECT b.ID, t.name AS [Tên bàn], DateCheckIn AS [Ngày vào], DateCheckOut AS [Ngày ra], discount AS [Giảm giá], b.totalPrice AS [Tổng tiền]
	FROM dbo.Bill AS b,dbo.TableFood AS t
	WHERE DateCheckIn >= @checkIn AND DateCheckOut <= @checkOut AND b.status = 1
	AND t.id = b.idTable)
	
	SELECT TOP (@selectRows) * FROM BillShow WHERE id NOT IN (SELECT TOP (@exceptRows) id FROM BillShow)
END

GO
/****** Object:  StoredProcedure [dbo].[USP_GetListBillByDateForReport]    Script Date: 4/28/2021 3:25:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_GetListBillByDateForReport]
	@checkIn date,
	@checkOut date
as
begin
	select  b.id,
			tb.name ,
			b.discount,
			b.totalPrice,
			b.dateCheckIn,
			b.dateCheckOut
	from Bill as b
	join TableFood as tb on b.idTable = tb.id
	where b.dateCheckIn >= @checkIn and b.dateCheckOut <= @checkOut and b.status = 1
end

GO
/****** Object:  StoredProcedure [dbo].[USP_GetNumBillByDate]    Script Date: 4/28/2021 3:25:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[USP_GetNumBillByDate]
@checkIn date, @checkOut date
AS 
BEGIN
	SELECT COUNT(*)
	FROM dbo.Bill AS b,dbo.TableFood AS t
	WHERE DateCheckIn >= @checkIn AND DateCheckOut <= @checkOut AND b.status = 1
	AND t.id = b.idTable
END

GO
/****** Object:  StoredProcedure [dbo].[USP_GetTable]    Script Date: 4/28/2021 3:25:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_GetTable]
as
begin
	select * from TableFood
end

GO
/****** Object:  StoredProcedure [dbo].[USP_InsertBill]    Script Date: 4/28/2021 3:25:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_InsertBill]
	@idTable int
as
begin
	INSERT	dbo.Bill ( DateCheckIn ,DateCheckOut ,idTable ,status,discount) VALUES ( GETDATE() ,NULL , @idTable , 0,0)
end
GO
/****** Object:  StoredProcedure [dbo].[USP_InsertBillInfo]    Script Date: 4/28/2021 3:25:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_InsertBillInfo]
	@idBill int,
	@idFood int,
	@count int
as
begin
	DECLARE @isExitsBillInfo int
	DECLARE @foodCount int = 1

	select @isExitsBillInfo = id,@foodCount = b.count
	from BillInfo as b
	where idBill = @idBill and idFood = @idFood

	if(@isExitsBillInfo > 0)
	BEGIN
		Declare @newCount int = @foodCount + @count
		if(@newCount > 0)
			UPDATE BillInfo set count = @newCount where idFood = @idFood
		else
			DELETE BillInfo where idBill = @idBill and idFood = @idFood
	END
	else
	begin
		INSERT	dbo.BillInfo ( idBill, idFood, count )VALUES ( @idBill , @idFood , @count )
	end
end

GO
/****** Object:  StoredProcedure [dbo].[USP_Login]    Script Date: 4/28/2021 3:25:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[USP_Login]
	@userName nvarchar(100),
	@passWord nvarchar(100)
AS
BEGIN
	SELECT * FROM dbo.Account WHERE UserName = @userName AND PassWord = @passWord
END

GO
/****** Object:  StoredProcedure [dbo].[USP_searchCategory]    Script Date: 4/28/2021 3:25:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROC [dbo].[USP_searchCategory]
@name nvarchar(100)
as
begin
	SELECT * FROM Category WHERE dbo.fuConvertToUnsign1(name) LIKE N'%' + dbo.fuConvertToUnsign1(@name) + '%'
end

GO
/****** Object:  StoredProcedure [dbo].[USP_searchFood]    Script Date: 4/28/2021 3:25:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROC [dbo].[USP_searchFood]
@name nvarchar(100)
as
begin
	SELECT * FROM Food WHERE dbo.fuConvertToUnsign1(name) LIKE N'%' + dbo.fuConvertToUnsign1(@name) + '%'
end
GO
/****** Object:  StoredProcedure [dbo].[USP_searchTable]    Script Date: 4/28/2021 3:25:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create PROC [dbo].[USP_searchTable]
@name nvarchar(100)
as
begin
	SELECT * FROM TableFood WHERE dbo.fuConvertToUnsign1(name) LIKE N'%' + dbo.fuConvertToUnsign1(@name) + '%'
end

GO
/****** Object:  StoredProcedure [dbo].[USP_SwitchTabel]    Script Date: 4/28/2021 3:25:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_SwitchTabel]
@idTable1 INT, @idTable2 int
AS BEGIN

	DECLARE @idFirstBill int
	DECLARE @idSeconrdBill INT
	
	DECLARE @isFirstTablEmty INT = 1
	DECLARE @isSecondTablEmty INT = 1
	
	SELECT @idSeconrdBill = id FROM dbo.Bill WHERE idTable = @idTable2 AND status = 0
	SELECT @idFirstBill = id FROM dbo.Bill WHERE idTable = @idTable1 AND status = 0
	
	IF (@idFirstBill IS NULL)
	BEGIN
		
		INSERT dbo.Bill ( DateCheckIn , DateCheckOut , idTable , status )VALUES ( GETDATE() ,NULL , @idTable1 , 0)
		        
		SELECT @idFirstBill = MAX(id) FROM dbo.Bill WHERE idTable = @idTable1 AND status = 0
		
	END
	
	SELECT @isFirstTablEmty = COUNT(*) FROM dbo.BillInfo WHERE idBill = @idFirstBill
	
	IF (@idSeconrdBill IS NULL)
	BEGIN
		
		INSERT dbo.Bill
		        ( DateCheckIn ,
		          DateCheckOut ,
		          idTable ,
		          status
		        )
		VALUES  ( GETDATE() ,
		          NULL ,
		          @idTable2 ,
		          0
		        )
		SELECT @idSeconrdBill = MAX(id) FROM dbo.Bill WHERE idTable = @idTable2 AND status = 0
		
	END
	
	SELECT @isSecondTablEmty = COUNT(*) FROM dbo.BillInfo WHERE idBill = @idSeconrdBill

	SELECT id INTO IDBillInfoTable FROM dbo.BillInfo WHERE idBill = @idSeconrdBill
	
	UPDATE dbo.BillInfo SET idBill = @idSeconrdBill WHERE idBill = @idFirstBill
	
	UPDATE dbo.BillInfo SET idBill = @idFirstBill WHERE id IN (SELECT * FROM IDBillInfoTable)
	
	DROP TABLE IDBillInfoTable
	
	IF (@isFirstTablEmty = 0)
		UPDATE dbo.TableFood SET status = N'Trống' WHERE id = @idTable2
		
	IF (@isSecondTablEmty= 0)
		UPDATE dbo.TableFood SET status = N'Trống' WHERE id = @idTable1
END

GO
/****** Object:  StoredProcedure [dbo].[USP_UpdateAcc]    Script Date: 4/28/2021 3:25:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[USP_UpdateAcc]
 @username nvarchar(100),
 @displayName nvarchar(100),
 @type int
as
begin
	Update Account set displayName = @displayName,type = @type where userName = @username
end

GO
/****** Object:  StoredProcedure [dbo].[USP_UpdateAccount]    Script Date: 4/28/2021 3:25:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_UpdateAccount]
@userName NVARCHAR(100), @displayName NVARCHAR(100), @password NVARCHAR(100), @newPassword NVARCHAR(100)
AS
BEGIN
	DECLARE @isRightPass INT = 0
	
	SELECT @isRightPass = COUNT(*) FROM dbo.Account WHERE USERName = @userName AND PassWord = @password
	
	IF (@isRightPass = 1)
	BEGIN
		IF (@newPassword = NULL OR @newPassword = '2122914021714301784233128915223624866126')
		BEGIN
			UPDATE dbo.Account SET DisplayName = @displayName WHERE UserName = @userName
		END		
		ELSE
			UPDATE dbo.Account SET DisplayName = @displayName, PassWord = @newPassword WHERE UserName = @userName
	end
END

GO
/****** Object:  StoredProcedure [dbo].[USP_UpdateFood]    Script Date: 4/28/2021 3:25:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[USP_UpdateFood]
 @id int,
 @name nvarchar(100),
 @idCategory int,
 @price float
as
begin
	Update Food set name = @name,idCategory = @idCategory,price = @price where id = @id
end
GO
USE [master]
GO
ALTER DATABASE [RestaurantManagement] SET  READ_WRITE 
GO

create TRIGGER UTG_UpdateBillInfo
ON dbo.BillInfo FOR INSERT, UPDATE
AS
BEGIN
	DECLARE @idBill INT
	
	SELECT @idBill = idBill FROM Inserted
	
	DECLARE @idTable INT
	
	SELECT @idTable = idTable FROM dbo.Bill WHERE id = @idBill AND status = 0	
	
	DECLARE @count INT
	SELECT @count = COUNT(*) FROM dbo.BillInfo WHERE idBill = @idBill
	
	IF (@count > 0)
	BEGIN
		UPDATE dbo.TableFood SET status = N'Có người' WHERE id = @idTable		
	END
	ELSE
	BEGIN
		UPDATE dbo.TableFood SET status = N'Trống' WHERE id = @idTable	
	end
END
GO

CREATE TRIGGER UTG_UpdateBill
ON dbo.Bill FOR UPDATE
AS
BEGIN
	DECLARE @idBill INT
	
	SELECT @idBill = id FROM Inserted	
	
	DECLARE @idTable INT
	
	SELECT @idTable = idTable FROM dbo.Bill WHERE id = @idBill
	
	DECLARE @count int = 0
	
	SELECT @count = COUNT(*) FROM dbo.Bill WHERE idTable = @idTable AND status = 0
	
	IF (@count = 0)
		UPDATE dbo.TableFood SET status = N'Trống' WHERE id = @idTable
END
GO

CREATE TRIGGER UTG_DeleteBillInfo
ON dbo.BillInfo FOR DELETE
AS 
BEGIN
	DECLARE @idBillInfo INT
	DECLARE @idBill INT
	SELECT @idBillInfo = id, @idBill = Deleted.idBill FROM Deleted
	
	DECLARE @idTable INT
	SELECT @idTable = idTable FROM dbo.Bill WHERE id = @idBill
	
	DECLARE @count INT = 0
	
	SELECT @count = COUNT(*) FROM dbo.BillInfo AS bi, dbo.Bill AS b WHERE b.id = bi.idBill AND b.id = @idBill AND b.status = 0
	
	IF (@count = 0)
		UPDATE dbo.TableFood SET status = N'Trống' WHERE id = @idTable
END
GO

