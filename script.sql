USE [master]
GO
/****** Object:  Database [HotelSQLBasSim]    Script Date: 31.03.2020 11:33:49 ******/
CREATE DATABASE [HotelSQLBasSim]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'HotelSQLBasSim', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\HotelSQLBasSim.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'HotelSQLBasSim_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\HotelSQLBasSim_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 COLLATE Cyrillic_General_CS_AS
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [HotelSQLBasSim] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [HotelSQLBasSim].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [HotelSQLBasSim] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [HotelSQLBasSim] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [HotelSQLBasSim] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [HotelSQLBasSim] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [HotelSQLBasSim] SET ARITHABORT OFF 
GO
ALTER DATABASE [HotelSQLBasSim] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [HotelSQLBasSim] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [HotelSQLBasSim] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [HotelSQLBasSim] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [HotelSQLBasSim] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [HotelSQLBasSim] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [HotelSQLBasSim] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [HotelSQLBasSim] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [HotelSQLBasSim] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [HotelSQLBasSim] SET  DISABLE_BROKER 
GO
ALTER DATABASE [HotelSQLBasSim] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [HotelSQLBasSim] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [HotelSQLBasSim] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [HotelSQLBasSim] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [HotelSQLBasSim] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [HotelSQLBasSim] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [HotelSQLBasSim] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [HotelSQLBasSim] SET RECOVERY FULL 
GO
ALTER DATABASE [HotelSQLBasSim] SET  MULTI_USER 
GO
ALTER DATABASE [HotelSQLBasSim] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [HotelSQLBasSim] SET DB_CHAINING OFF 
GO
ALTER DATABASE [HotelSQLBasSim] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [HotelSQLBasSim] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [HotelSQLBasSim] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'HotelSQLBasSim', N'ON'
GO
ALTER DATABASE [HotelSQLBasSim] SET QUERY_STORE = OFF
GO
USE [HotelSQLBasSim]
GO
/****** Object:  Table [dbo].[Clients]    Script Date: 31.03.2020 11:33:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clients](
	[id_Client] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) COLLATE Cyrillic_General_CS_AS NULL,
	[SurName] [nvarchar](50) COLLATE Cyrillic_General_CS_AS NULL,
	[Patronymic] [nvarchar](50) COLLATE Cyrillic_General_CS_AS NULL,
	[Address] [nvarchar](50) COLLATE Cyrillic_General_CS_AS NULL,
	[Date_Of_Bithday] [date] NULL,
	[Number_Passport] [int] NULL,
	[Date_of_arrival] [date] NULL,
	[Date_of_departure] [date] NULL,
	[User_id] [int] NULL,
 CONSTRAINT [PK_Clients] PRIMARY KEY CLUSTERED 
(
	[id_Client] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Distribution_rooms]    Script Date: 31.03.2020 11:33:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Distribution_rooms](
	[id_DR] [int] IDENTITY(1,1) NOT NULL,
	[Client] [int] NULL,
	[Room] [int] NULL,
 CONSTRAINT [PK_Distribution_rooms] PRIMARY KEY CLUSTERED 
(
	[id_DR] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[List_of_services]    Script Date: 31.03.2020 11:33:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[List_of_services](
	[id_los] [int] IDENTITY(1,1) NOT NULL,
	[Client] [int] NULL,
	[Service] [int] NULL,
	[num_of_service_render] [int] NULL,
	[Staff_id] [int] NULL,
 CONSTRAINT [PK_List_of_services] PRIMARY KEY CLUSTERED 
(
	[id_los] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Positions]    Script Date: 31.03.2020 11:33:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Positions](
	[id_Codep] [int] IDENTITY(1,1) NOT NULL,
	[Name_position] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Salary] [decimal](18, 0) NULL,
 CONSTRAINT [PK_Positions] PRIMARY KEY CLUSTERED 
(
	[id_Codep] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 31.03.2020 11:33:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[id_Role] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[id_Role] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rooms]    Script Date: 31.03.2020 11:33:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rooms](
	[id_Room] [int] IDENTITY(1,1) NOT NULL,
	[Num_of_beds_room] [int] NULL,
	[Busy_room] [bit] NULL,
	[Price_room] [decimal](18, 0) NULL,
	[Category] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [PK_Rooms] PRIMARY KEY CLUSTERED 
(
	[id_Room] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rooms_service]    Script Date: 31.03.2020 11:33:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rooms_service](
	[id_RS] [int] IDENTITY(1,1) NOT NULL,
	[Staff] [int] NULL,
	[Room] [int] NULL,
 CONSTRAINT [PK_Rooms_service] PRIMARY KEY CLUSTERED 
(
	[id_RS] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Services]    Script Date: 31.03.2020 11:33:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Services](
	[id_service] [int] IDENTITY(1,1) NOT NULL,
	[Name_Services] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Price_Services] [decimal](18, 0) NULL,
 CONSTRAINT [PK_Services] PRIMARY KEY CLUSTERED 
(
	[id_service] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Staff]    Script Date: 31.03.2020 11:33:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Staff](
	[id_Staff] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[SurName] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Patronymic] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Address] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Number_Phone] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Code_Positions] [int] NULL,
	[User_id] [int] NULL,
 CONSTRAINT [PK_Staff] PRIMARY KEY CLUSTERED 
(
	[id_Staff] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 31.03.2020 11:33:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[id_User] [int] IDENTITY(1,1) NOT NULL,
	[Login] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Password] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Role] [int] NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[id_User] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Clients] ON 

INSERT [dbo].[Clients] ([id_Client], [Name], [SurName], [Patronymic], [Address], [Date_Of_Bithday], [Number_Passport], [Date_of_arrival], [Date_of_departure], [User_id]) VALUES (1, N'Клиент', N'Клиентов', N'Клиентович', N'клиентовская 16', CAST(N'2000-09-28' AS Date), 38126489, NULL, NULL, 4)
SET IDENTITY_INSERT [dbo].[Clients] OFF
SET IDENTITY_INSERT [dbo].[Positions] ON 

INSERT [dbo].[Positions] ([id_Codep], [Name_position], [Salary]) VALUES (1, N'Партье', CAST(17000 AS Decimal(18, 0)))
INSERT [dbo].[Positions] ([id_Codep], [Name_position], [Salary]) VALUES (2, N'Менеджер', CAST(22000 AS Decimal(18, 0)))
INSERT [dbo].[Positions] ([id_Codep], [Name_position], [Salary]) VALUES (3, N'Горнечная', CAST(15000 AS Decimal(18, 0)))
INSERT [dbo].[Positions] ([id_Codep], [Name_position], [Salary]) VALUES (4, N'Управляющий', CAST(25000 AS Decimal(18, 0)))
SET IDENTITY_INSERT [dbo].[Positions] OFF
SET IDENTITY_INSERT [dbo].[Roles] ON 

INSERT [dbo].[Roles] ([id_Role], [Name]) VALUES (1, N'Client')
INSERT [dbo].[Roles] ([id_Role], [Name]) VALUES (2, N'Staff')
INSERT [dbo].[Roles] ([id_Role], [Name]) VALUES (3, N'Admin')
SET IDENTITY_INSERT [dbo].[Roles] OFF
SET IDENTITY_INSERT [dbo].[Rooms] ON 

INSERT [dbo].[Rooms] ([id_Room], [Num_of_beds_room], [Busy_room], [Price_room], [Category]) VALUES (1, 2, 0, CAST(1600 AS Decimal(18, 0)), N'Standart')
INSERT [dbo].[Rooms] ([id_Room], [Num_of_beds_room], [Busy_room], [Price_room], [Category]) VALUES (2, 1, 0, CAST(2600 AS Decimal(18, 0)), N'Luxury')
INSERT [dbo].[Rooms] ([id_Room], [Num_of_beds_room], [Busy_room], [Price_room], [Category]) VALUES (3, 3, 0, CAST(3000 AS Decimal(18, 0)), N'Family')
SET IDENTITY_INSERT [dbo].[Rooms] OFF
SET IDENTITY_INSERT [dbo].[Services] ON 

INSERT [dbo].[Services] ([id_service], [Name_Services], [Price_Services]) VALUES (1, N'Бытовые услуги', CAST(600 AS Decimal(18, 0)))
INSERT [dbo].[Services] ([id_service], [Name_Services], [Price_Services]) VALUES (2, N'Массаж', CAST(5000 AS Decimal(18, 0)))
INSERT [dbo].[Services] ([id_service], [Name_Services], [Price_Services]) VALUES (3, N'Услуга беллбой', CAST(3000 AS Decimal(18, 0)))
INSERT [dbo].[Services] ([id_service], [Name_Services], [Price_Services]) VALUES (4, N'Предоставление сейфа', CAST(5000 AS Decimal(18, 0)))
INSERT [dbo].[Services] ([id_service], [Name_Services], [Price_Services]) VALUES (5, N'Доступ в интернет', CAST(100 AS Decimal(18, 0)))
INSERT [dbo].[Services] ([id_service], [Name_Services], [Price_Services]) VALUES (6, N'Заказ еды в номер', CAST(950 AS Decimal(18, 0)))
SET IDENTITY_INSERT [dbo].[Services] OFF
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([id_User], [Login], [Password], [Role]) VALUES (3, N'Admin', N'parol', 3)
INSERT [dbo].[Users] ([id_User], [Login], [Password], [Role]) VALUES (4, N'Client1', N'Client123!', 2)
SET IDENTITY_INSERT [dbo].[Users] OFF
ALTER TABLE [dbo].[Clients]  WITH CHECK ADD  CONSTRAINT [FK_Clients_Users] FOREIGN KEY([User_id])
REFERENCES [dbo].[Users] ([id_User])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Clients] CHECK CONSTRAINT [FK_Clients_Users]
GO
ALTER TABLE [dbo].[Distribution_rooms]  WITH CHECK ADD  CONSTRAINT [FK_Distribution_rooms_Clients] FOREIGN KEY([Client])
REFERENCES [dbo].[Clients] ([id_Client])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Distribution_rooms] CHECK CONSTRAINT [FK_Distribution_rooms_Clients]
GO
ALTER TABLE [dbo].[Distribution_rooms]  WITH CHECK ADD  CONSTRAINT [FK_Distribution_rooms_Rooms] FOREIGN KEY([Room])
REFERENCES [dbo].[Rooms] ([id_Room])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Distribution_rooms] CHECK CONSTRAINT [FK_Distribution_rooms_Rooms]
GO
ALTER TABLE [dbo].[List_of_services]  WITH CHECK ADD  CONSTRAINT [FK_List_of_services_Clients] FOREIGN KEY([Client])
REFERENCES [dbo].[Clients] ([id_Client])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[List_of_services] CHECK CONSTRAINT [FK_List_of_services_Clients]
GO
ALTER TABLE [dbo].[List_of_services]  WITH CHECK ADD  CONSTRAINT [FK_List_of_services_Services] FOREIGN KEY([Client])
REFERENCES [dbo].[Services] ([id_service])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[List_of_services] CHECK CONSTRAINT [FK_List_of_services_Services]
GO
ALTER TABLE [dbo].[Rooms_service]  WITH CHECK ADD  CONSTRAINT [FK_Rooms_service_Rooms] FOREIGN KEY([Room])
REFERENCES [dbo].[Rooms] ([id_Room])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Rooms_service] CHECK CONSTRAINT [FK_Rooms_service_Rooms]
GO
ALTER TABLE [dbo].[Rooms_service]  WITH CHECK ADD  CONSTRAINT [FK_Rooms_service_Staff] FOREIGN KEY([Staff])
REFERENCES [dbo].[Staff] ([id_Staff])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Rooms_service] CHECK CONSTRAINT [FK_Rooms_service_Staff]
GO
ALTER TABLE [dbo].[Staff]  WITH CHECK ADD  CONSTRAINT [FK_Staff_Positions] FOREIGN KEY([Code_Positions])
REFERENCES [dbo].[Positions] ([id_Codep])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Staff] CHECK CONSTRAINT [FK_Staff_Positions]
GO
ALTER TABLE [dbo].[Staff]  WITH CHECK ADD  CONSTRAINT [FK_Staff_Users] FOREIGN KEY([User_id])
REFERENCES [dbo].[Users] ([id_User])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Staff] CHECK CONSTRAINT [FK_Staff_Users]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Roles] FOREIGN KEY([Role])
REFERENCES [dbo].[Roles] ([id_Role])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_Roles]
GO
USE [master]
GO
ALTER DATABASE [HotelSQLBasSim] SET  READ_WRITE 
GO
