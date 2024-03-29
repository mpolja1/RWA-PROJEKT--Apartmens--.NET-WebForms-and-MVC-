USE [master]
GO
/****** Object:  Database [RwaProjektApartmani]    Script Date: 8.7.2022. 17:44:56 ******/
CREATE DATABASE [RwaProjektApartmani]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'RWA', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER1\MSSQL\DATA\RWA.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'RWA_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER1\MSSQL\DATA\RWA_log.ldf' , SIZE = 73728KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [RwaProjektApartmani] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [RwaProjektApartmani].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [RwaProjektApartmani] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [RwaProjektApartmani] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [RwaProjektApartmani] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [RwaProjektApartmani] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [RwaProjektApartmani] SET ARITHABORT OFF 
GO
ALTER DATABASE [RwaProjektApartmani] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [RwaProjektApartmani] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [RwaProjektApartmani] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [RwaProjektApartmani] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [RwaProjektApartmani] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [RwaProjektApartmani] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [RwaProjektApartmani] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [RwaProjektApartmani] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [RwaProjektApartmani] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [RwaProjektApartmani] SET  DISABLE_BROKER 
GO
ALTER DATABASE [RwaProjektApartmani] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [RwaProjektApartmani] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [RwaProjektApartmani] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [RwaProjektApartmani] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [RwaProjektApartmani] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [RwaProjektApartmani] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [RwaProjektApartmani] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [RwaProjektApartmani] SET RECOVERY FULL 
GO
ALTER DATABASE [RwaProjektApartmani] SET  MULTI_USER 
GO
ALTER DATABASE [RwaProjektApartmani] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [RwaProjektApartmani] SET DB_CHAINING OFF 
GO
ALTER DATABASE [RwaProjektApartmani] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [RwaProjektApartmani] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [RwaProjektApartmani] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [RwaProjektApartmani] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [RwaProjektApartmani] SET QUERY_STORE = OFF
GO
USE [RwaProjektApartmani]
GO
/****** Object:  Table [dbo].[Apartment]    Script Date: 8.7.2022. 17:44:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Apartment](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Guid] [uniqueidentifier] NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[DeletedAt] [datetime2](7) NULL,
	[OwnerId] [int] NOT NULL,
	[TypeId] [int] NOT NULL,
	[StatusId] [int] NOT NULL,
	[CityId] [int] NULL,
	[Address] [nvarchar](250) NULL,
	[Name] [nvarchar](250) NOT NULL,
	[NameEng] [nvarchar](250) NOT NULL,
	[Price] [money] NOT NULL,
	[MaxAdults] [int] NULL,
	[MaxChildren] [int] NULL,
	[TotalRooms] [int] NULL,
	[BeachDistance] [int] NULL,
 CONSTRAINT [PK_Apartment] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ApartmentOwner]    Script Date: 8.7.2022. 17:44:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ApartmentOwner](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Guid] [uniqueidentifier] NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[Name] [nvarchar](250) NOT NULL,
 CONSTRAINT [PK_ApartmentOwner] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ApartmentPicture]    Script Date: 8.7.2022. 17:44:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ApartmentPicture](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Guid] [uniqueidentifier] NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[DeletedAt] [datetime2](7) NULL,
	[ApartmentId] [int] NULL,
	[Path] [nvarchar](250) NULL,
	[Base64Content] [varchar](max) NULL,
	[Name] [nvarchar](250) NOT NULL,
	[IsRepresentative] [bit] NULL,
 CONSTRAINT [PK_ApartmentPicture] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ApartmentReservation]    Script Date: 8.7.2022. 17:44:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ApartmentReservation](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Guid] [uniqueidentifier] NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[ApartmentId] [int] NOT NULL,
	[Details] [nvarchar](1000) NULL,
	[UserId] [int] NULL,
	[UserName] [nvarchar](250) NULL,
	[UserEmail] [nvarchar](250) NULL,
	[UserPhone] [nchar](20) NULL,
	[UserAddress] [nvarchar](1000) NULL,
 CONSTRAINT [PK_ApartmentReservation] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ApartmentReview]    Script Date: 8.7.2022. 17:44:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ApartmentReview](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Guid] [uniqueidentifier] NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[ApartmentId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
	[Details] [nvarchar](1000) NULL,
	[Stars] [int] NULL,
 CONSTRAINT [PK_ApartmentReview] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ApartmentStatus]    Script Date: 8.7.2022. 17:44:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ApartmentStatus](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Guid] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](250) NOT NULL,
	[NameEng] [nvarchar](250) NOT NULL,
 CONSTRAINT [PK_ApartmentStatus] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 8.7.2022. 17:44:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 8.7.2022. 17:44:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 8.7.2022. 17:44:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](128) NOT NULL,
	[ProviderKey] [nvarchar](128) NOT NULL,
	[UserId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC,
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 8.7.2022. 17:44:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [int] NOT NULL,
	[RoleId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 8.7.2022. 17:44:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Guid] [uniqueidentifier] NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[DeletedAt] [datetime2](7) NULL,
	[Email] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[LockoutEndDateUtc] [datetime] NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[UserName] [nvarchar](256) NOT NULL,
	[Address] [nvarchar](1000) NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[City]    Script Date: 8.7.2022. 17:44:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[City](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Guid] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](250) NOT NULL,
 CONSTRAINT [PK_City] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 8.7.2022. 17:44:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tag]    Script Date: 8.7.2022. 17:44:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tag](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Guid] [uniqueidentifier] NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[TypeId] [int] NOT NULL,
	[Name] [nvarchar](250) NOT NULL,
	[NameEng] [nvarchar](250) NULL,
 CONSTRAINT [PK_Tag] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TaggedApartment]    Script Date: 8.7.2022. 17:44:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TaggedApartment](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Guid] [uniqueidentifier] NOT NULL,
	[ApartmentId] [int] NOT NULL,
	[TagId] [int] NOT NULL,
 CONSTRAINT [PK_TaggedApartment] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TagType]    Script Date: 8.7.2022. 17:44:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TagType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Guid] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](250) NOT NULL,
	[NameEng] [nvarchar](250) NOT NULL,
 CONSTRAINT [PK_TagType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Apartment] ADD  CONSTRAINT [DF_Apartment_Guid]  DEFAULT (newid()) FOR [Guid]
GO
ALTER TABLE [dbo].[Apartment] ADD  CONSTRAINT [DF_Apartment_CreatedAt]  DEFAULT (sysutcdatetime()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[ApartmentOwner] ADD  CONSTRAINT [DF_ApartmentOwner_Guid]  DEFAULT (newid()) FOR [Guid]
GO
ALTER TABLE [dbo].[ApartmentOwner] ADD  CONSTRAINT [DF_ApartmentOwner_CreatedAt]  DEFAULT (sysutcdatetime()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[ApartmentPicture] ADD  CONSTRAINT [DF_ApartmentPicture_Guid]  DEFAULT (newid()) FOR [Guid]
GO
ALTER TABLE [dbo].[ApartmentPicture] ADD  CONSTRAINT [DF_ApartmentPicture_CreatedAt]  DEFAULT (sysutcdatetime()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[ApartmentReservation] ADD  CONSTRAINT [DF_ApartmentReservation_Guid]  DEFAULT (newid()) FOR [Guid]
GO
ALTER TABLE [dbo].[ApartmentReservation] ADD  CONSTRAINT [DF_ApartmentReservation_CreatedAt]  DEFAULT (sysutcdatetime()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[ApartmentReview] ADD  CONSTRAINT [DF_ApartmentReview_Guid]  DEFAULT (newid()) FOR [Guid]
GO
ALTER TABLE [dbo].[ApartmentReview] ADD  CONSTRAINT [DF_ApartmentReview_CreatedAt]  DEFAULT (sysutcdatetime()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[ApartmentStatus] ADD  CONSTRAINT [DF_ApartmentStatus_Guid]  DEFAULT (newid()) FOR [Guid]
GO
ALTER TABLE [dbo].[AspNetUsers] ADD  CONSTRAINT [DF_User_Guid]  DEFAULT (newid()) FOR [Guid]
GO
ALTER TABLE [dbo].[AspNetUsers] ADD  CONSTRAINT [DF_User_CreatedAt]  DEFAULT (sysutcdatetime()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[AspNetUsers] ADD  CONSTRAINT [DF_AspNetUsers_Address]  DEFAULT ((1)) FOR [Address]
GO
ALTER TABLE [dbo].[City] ADD  CONSTRAINT [DF_City_Guid]  DEFAULT (newid()) FOR [Guid]
GO
ALTER TABLE [dbo].[Tag] ADD  CONSTRAINT [DF_Tag_Guid]  DEFAULT (newid()) FOR [Guid]
GO
ALTER TABLE [dbo].[Tag] ADD  CONSTRAINT [DF_Tag_CreatedAt]  DEFAULT (sysutcdatetime()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[TaggedApartment] ADD  CONSTRAINT [DF_TaggedApartment_Guid]  DEFAULT (newid()) FOR [Guid]
GO
ALTER TABLE [dbo].[TagType] ADD  CONSTRAINT [DF_TagType_Guid]  DEFAULT (newid()) FOR [Guid]
GO
ALTER TABLE [dbo].[Apartment]  WITH CHECK ADD  CONSTRAINT [FK_Apartment_ApartmentOwner] FOREIGN KEY([OwnerId])
REFERENCES [dbo].[ApartmentOwner] ([Id])
GO
ALTER TABLE [dbo].[Apartment] CHECK CONSTRAINT [FK_Apartment_ApartmentOwner]
GO
ALTER TABLE [dbo].[Apartment]  WITH CHECK ADD  CONSTRAINT [FK_Apartment_ApartmentStatus] FOREIGN KEY([StatusId])
REFERENCES [dbo].[ApartmentStatus] ([Id])
GO
ALTER TABLE [dbo].[Apartment] CHECK CONSTRAINT [FK_Apartment_ApartmentStatus]
GO
ALTER TABLE [dbo].[Apartment]  WITH CHECK ADD  CONSTRAINT [FK_Apartment_City] FOREIGN KEY([CityId])
REFERENCES [dbo].[City] ([Id])
GO
ALTER TABLE [dbo].[Apartment] CHECK CONSTRAINT [FK_Apartment_City]
GO
ALTER TABLE [dbo].[ApartmentPicture]  WITH CHECK ADD  CONSTRAINT [FK_ApartmentPicture_Apartment] FOREIGN KEY([ApartmentId])
REFERENCES [dbo].[Apartment] ([Id])
GO
ALTER TABLE [dbo].[ApartmentPicture] CHECK CONSTRAINT [FK_ApartmentPicture_Apartment]
GO
ALTER TABLE [dbo].[ApartmentReservation]  WITH CHECK ADD  CONSTRAINT [FK_ApartmentReservation_Apartment] FOREIGN KEY([ApartmentId])
REFERENCES [dbo].[Apartment] ([Id])
GO
ALTER TABLE [dbo].[ApartmentReservation] CHECK CONSTRAINT [FK_ApartmentReservation_Apartment]
GO
ALTER TABLE [dbo].[ApartmentReservation]  WITH CHECK ADD  CONSTRAINT [FK_ApartmentReservation_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[ApartmentReservation] CHECK CONSTRAINT [FK_ApartmentReservation_User]
GO
ALTER TABLE [dbo].[ApartmentReview]  WITH CHECK ADD  CONSTRAINT [FK_ApartmentReview_Apartment] FOREIGN KEY([ApartmentId])
REFERENCES [dbo].[Apartment] ([Id])
GO
ALTER TABLE [dbo].[ApartmentReview] CHECK CONSTRAINT [FK_ApartmentReview_Apartment]
GO
ALTER TABLE [dbo].[ApartmentReview]  WITH CHECK ADD  CONSTRAINT [FK_ApartmentReview_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[ApartmentReview] CHECK CONSTRAINT [FK_ApartmentReview_User]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[Tag]  WITH CHECK ADD  CONSTRAINT [FK_Tag_TagType] FOREIGN KEY([TypeId])
REFERENCES [dbo].[TagType] ([Id])
GO
ALTER TABLE [dbo].[Tag] CHECK CONSTRAINT [FK_Tag_TagType]
GO
ALTER TABLE [dbo].[TaggedApartment]  WITH CHECK ADD  CONSTRAINT [FK_TaggedApartment_Apartment] FOREIGN KEY([ApartmentId])
REFERENCES [dbo].[Apartment] ([Id])
GO
ALTER TABLE [dbo].[TaggedApartment] CHECK CONSTRAINT [FK_TaggedApartment_Apartment]
GO
ALTER TABLE [dbo].[TaggedApartment]  WITH CHECK ADD  CONSTRAINT [FK_TaggedApartment_Tag] FOREIGN KEY([TagId])
REFERENCES [dbo].[Tag] ([Id])
GO
ALTER TABLE [dbo].[TaggedApartment] CHECK CONSTRAINT [FK_TaggedApartment_Tag]
GO
/****** Object:  StoredProcedure [dbo].[AddApartmentTag]    Script Date: 8.7.2022. 17:44:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[AddApartmentTag]
	@idapartment int,
	@idTag int
as
begin
	insert into TaggedApartment(Guid,ApartmentId,TagId)values(NEWID(),@idapartment,@idTag)
end
GO
/****** Object:  StoredProcedure [dbo].[AuthEmployee]    Script Date: 8.7.2022. 17:44:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create proc [dbo].[AuthEmployee]
	@username nvarchar(50),
	@password nvarchar(50)
as
begin
	select * from Employee as e
	where e.Username = @username and e.Password=@password
end
GO
/****** Object:  StoredProcedure [dbo].[AuthUser]    Script Date: 8.7.2022. 17:44:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[AuthUser]
	@email nvarchar(70),
	@PasswordHash nvarchar(max)
as
begin
	select* from AspNetUsers where Email=@email and PasswordHash=@PasswordHash and DeletedAt is null
end
GO
/****** Object:  StoredProcedure [dbo].[DeleteApartmentPicture]    Script Date: 8.7.2022. 17:44:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[DeleteApartmentPicture]
	@id int
as
if exists(select*from ApartmentPicture where Id=@id)
delete from ApartmentPicture
where Id=@id
GO
/****** Object:  StoredProcedure [dbo].[DeleteApartmentSoft]    Script Date: 8.7.2022. 17:44:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[DeleteApartmentSoft]
	@id int
as
update Apartment
set DeletedAt=GETDATE()
where Apartment.Id=@id
GO
/****** Object:  StoredProcedure [dbo].[deleteApartmentTag]    Script Date: 8.7.2022. 17:44:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[deleteApartmentTag]
	@idApartment int,
	@idTag int
as
delete from TaggedApartment
where ApartmentId=@idApartment and TagId=@idTag
GO
/****** Object:  StoredProcedure [dbo].[DeleteTag]    Script Date: 8.7.2022. 17:44:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[DeleteTag]
	@id int
as
begin
	delete from Tag
	where @id = Tag.Id
end
GO
/****** Object:  StoredProcedure [dbo].[GetApartmantStatus]    Script Date: 8.7.2022. 17:44:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[GetApartmantStatus]
as
begin
	select*from ApartmentStatus
end
GO
/****** Object:  StoredProcedure [dbo].[GetApartmentById]    Script Date: 8.7.2022. 17:44:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[GetApartmentById]
	@id int
as
begin
	select a.Id,a.Guid,a.CreatedAt,a.DeletedAt,ow.Id as OwnerId,ow.Guid as OwnerGuid,ow.CreatedAt as OwnerCreatedAt,ow.Name as OwnerName,aps.Id as StatusID,aps.Guid
	as StatusGuid,aps.Name as StatusName,aps.NameEng as StatusNameEng,c.Id as CityId,c.Guid as CityGuid,c.Name as CityName,a.Address,a.Name,a.NameEng,a.Price,a.MaxAdults,a.MaxChildren,a.TotalRooms,a.BeachDistance
	from Apartment as a
	inner join ApartmentOwner as ow on ow.Id = a.OwnerId
	inner join City as c on c.Id = a.CityId
	inner join ApartmentStatus as aps on aps.Id = a.StatusId
	where a.DeletedAt is null and a.Id=@id
end
GO
/****** Object:  StoredProcedure [dbo].[GetApartmentPictures]    Script Date: 8.7.2022. 17:44:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[GetApartmentPictures]
	@Id int
as
begin
	select Id,Guid,CreatedAt,ApartmentId,Path,Name,IsRepresentative,Base64Content from ApartmentPicture
	where ApartmentPicture.ApartmentId=@id and ApartmentPicture.DeletedAt is null
end
GO
/****** Object:  StoredProcedure [dbo].[GetApartments]    Script Date: 8.7.2022. 17:44:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[GetApartments]
as
begin
	select a.Id,a.Guid,a.CreatedAt,a.DeletedAt,ow.Id as OwnerId,ow.Guid as OwnerGuid,ow.CreatedAt as OwnerCreatedAt,ow.Name as OwnerName,aps.Id as StatusID,aps.Guid
	as StatusGuid,aps.Name as StatusName,aps.NameEng as StatusNameEng,c.Id as CityId,c.Guid as CityGuid,c.Name as CityName,a.Address,a.Name,a.NameEng,a.Price,a.MaxAdults,a.MaxChildren,a.TotalRooms,a.BeachDistance
	from Apartment as a
	inner join ApartmentOwner as ow on ow.Id = a.OwnerId
	inner join City as c on c.Id = a.CityId
	inner join ApartmentStatus as aps on aps.Id = a.StatusId	
	where a.DeletedAt is null	
end
GO
/****** Object:  StoredProcedure [dbo].[GetApartmentsByCity]    Script Date: 8.7.2022. 17:44:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[GetApartmentsByCity]
	@IdCity int
as
begin
	select*from Apartment
	where Apartment.CityId=@IdCity and DeletedAt is  null
end
GO
/****** Object:  StoredProcedure [dbo].[GetApartmentsReview]    Script Date: 8.7.2022. 17:44:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[GetApartmentsReview]
as
select*
from ApartmentReview
GO
/****** Object:  StoredProcedure [dbo].[GetApartmentsReviewById]    Script Date: 8.7.2022. 17:44:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[GetApartmentsReviewById]
as
select*
from ApartmentReview
inner join AspNetUsers as ans on ans.Id=ApartmentReview.UserId
GO
/****** Object:  StoredProcedure [dbo].[GetApartmentStatus]    Script Date: 8.7.2022. 17:44:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[GetApartmentStatus]
as
begin
	select*from ApartmentStatus
end
GO
/****** Object:  StoredProcedure [dbo].[GetAvgStarsReview]    Script Date: 8.7.2022. 17:44:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[GetAvgStarsReview]
	@id int
as
select isnull(avg(stars),0) as AvgStars
from Apartment
inner join ApartmentReview as ar on ar.ApartmentId=Apartment.Id
where Apartment.Id=@id
GO
/****** Object:  StoredProcedure [dbo].[GetCities]    Script Date: 8.7.2022. 17:44:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[GetCities]
as
begin
	select* from City
end
GO
/****** Object:  StoredProcedure [dbo].[GetStarsReview]    Script Date: 8.7.2022. 17:44:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[GetStarsReview]
as
select a.Name,AVG(ApartmentReview.Stars) as AvgStars
from ApartmentReview
inner join AspNetUsers as ans on ans.Id=ApartmentReview.UserId
full join Apartment as a on a.Id=ApartmentReview.ApartmentId
group by a.Name
GO
/****** Object:  StoredProcedure [dbo].[GetTagCount]    Script Date: 8.7.2022. 17:44:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[GetTagCount]
as
begin
select t.Id,t.Name, COUNT(ta.Id) as TagCount
from Tag as t
left join TaggedApartment as ta on ta.TagId = t.Id
group by t.Id,t.Name
end
GO
/****** Object:  StoredProcedure [dbo].[GetTagsByApartment]    Script Date: 8.7.2022. 17:44:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[GetTagsByApartment]
	@Id int
as
select t.Id, ta.Guid,t.Name   
from TaggedApartment as ta
inner join tag as t on ta.TagId= t.Id
where ta.ApartmentId=@id 
GO
/****** Object:  StoredProcedure [dbo].[GetTagsByApartmentId]    Script Date: 8.7.2022. 17:44:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[GetTagsByApartmentId]
	@Id int
as
select ta.Id,ta.Guid,t.Name as TagName
from TaggedApartment as ta
inner join Apartment as a on a.Id=ta.ApartmentId
inner join Tag as t on t.Id=ta.TagId
where ta.ApartmentId=@id and a.DeletedAt is null
GO
/****** Object:  StoredProcedure [dbo].[GetTagType]    Script Date: 8.7.2022. 17:44:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[GetTagType]
as
begin
	select*from TagType
end
GO
/****** Object:  StoredProcedure [dbo].[GetTagTypes]    Script Date: 8.7.2022. 17:44:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[GetTagTypes]
as
begin
	select*from TagType
end
GO
/****** Object:  StoredProcedure [dbo].[GetUnusedApartmentTag]    Script Date: 8.7.2022. 17:44:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[GetUnusedApartmentTag]
	@id int
as
select distinct Tag.Name,Tag.Id
from Tag
left join TaggedApartment as ta on ta.TagId= Tag.Id
where Tag.Id not in(select ta.TagId from TaggedApartment as ta where ta.ApartmentId=@id)
order by Tag.Name
GO
/****** Object:  StoredProcedure [dbo].[GetUserById]    Script Date: 8.7.2022. 17:44:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[GetUserById]
	@id int
as
select*
from AspNetUsers
where AspNetUsers.Id=@id
GO
/****** Object:  StoredProcedure [dbo].[GetUserReservation]    Script Date: 8.7.2022. 17:44:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[GetUserReservation]
	@id int
as
select* from ApartmentReservation
where ApartmentReservation.UserId=@id
GO
/****** Object:  StoredProcedure [dbo].[GetUsers]    Script Date: 8.7.2022. 17:44:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[GetUsers]
as
begin
	select*from AspNetUsers
	where AspNetUsers.DeletedAt is null
end
GO
/****** Object:  StoredProcedure [dbo].[SaveApartment]    Script Date: 8.7.2022. 17:44:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[SaveApartment]
	@OwnerName nvarchar(50),
	@StatusId int,
	@CityId int,
	@Address nvarchar(70),
	@Name nvarchar(70),
	@NameEng nvarchar(70),
	@Price money,
	@MaxAdults int,
	@MaxChildren int,
	@TotalRooms int,
	@BeachDistance int
as
begin
	if not exists(select* from ApartmentOwner where ApartmentOwner.Name = @OwnerName)
	insert into ApartmentOwner(Guid,CreatedAt,Name)values(NEWID(),GETDATE(),@OwnerName)
end
begin
declare @OwnerId int
	set @OwnerId=(select ApartmentOwner.Id from ApartmentOwner where ApartmentOwner.Name=@OwnerName) 
	insert into Apartment(Guid, CreatedAt, OwnerId, TypeId, StatusId, CityId, Address, Name, NameEng, Price, MaxAdults, MaxChildren, TotalRooms, BeachDistance)
	values(NEWID(),GETDATE(),@OwnerId,999,@StatusId,@CityId,@Address,@Name,@NameEng,@Price,@MaxAdults,@MaxChildren,@TotalRooms,@BeachDistance)
end
GO
/****** Object:  StoredProcedure [dbo].[SaveApartmentImages]    Script Date: 8.7.2022. 17:44:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[SaveApartmentImages]
	@id int,
	@Path nvarchar(250),
	@Name nvarchar(50)
as
begin
	insert into ApartmentPicture(Guid, CreatedAt,ApartmentId, Path, Base64Content, Name, IsRepresentative)values(NEWID(),GETDATE(),@id,@Path,null,@Name,0)
end
GO
/****** Object:  StoredProcedure [dbo].[SaveApartmentOwner]    Script Date: 8.7.2022. 17:44:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[SaveApartmentOwner]
	@Name nvarchar(50)
as
begin
	if not exists(select* from ApartmentOwner where ApartmentOwner.Name = @Name)
	insert into ApartmentOwner(Guid,CreatedAt,Name)values(NEWID(),GETDATE(),@Name)
end
GO
/****** Object:  StoredProcedure [dbo].[SaveApartmentReservation]    Script Date: 8.7.2022. 17:44:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[SaveApartmentReservation]
	@idApartment int,
	@Details nvarchar(1000),
	@UserName nvarchar(50),
	@UserEmail nvarchar(50),
	@UserPhone nvarchar(50),
	@UserAdress nvarchar(50)
as
if exists(select*from AspNetUsers where AspNetUsers.UserName=@UserName and AspNetUsers.Email=@UserEmail)
	begin
		declare @UserId int
		set @UserId=(select AspNetUsers.Id from AspNetUsers where AspNetUsers.UserName=@UserName and AspNetUsers.Email=@UserEmail)

		insert into ApartmentReservation(Guid, CreatedAt, ApartmentId, Details, UserId, UserName, UserEmail, UserPhone, UserAddress)
							values(NEWID(),GETDATE(),@idApartment,@Details,@UserId,null,null,null,null)
	end
else
	begin
		insert into ApartmentReservation(Guid, CreatedAt, ApartmentId, Details, UserId, UserName, UserEmail, UserPhone, UserAddress)
										values(NEWID(),GETDATE(),@idApartment,@Details,null,@UserName,@UserEmail,@UserPhone,@UserAdress)
	end
GO
/****** Object:  StoredProcedure [dbo].[SaveTag]    Script Date: 8.7.2022. 17:44:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[SaveTag]
	@TypeId int,
	@Name nvarchar(50),
	@nameEng nvarchar(50)
as
begin
	insert into Tag (Guid,CreatedAt,TypeId,Name,NameEng) values(NEWID(),GETDATE(),@TypeId,@Name,@nameEng)
end
GO
/****** Object:  StoredProcedure [dbo].[SaveUser]    Script Date: 8.7.2022. 17:44:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[SaveUser]
	@Email nvarchar(100),
	@Passwordhash nvarchar(max),
	@PhoneNumber nvarchar(100),
	@UserName nvarchar(250),
	@Address nvarchar(1000)
as
begin
if not exists(select*from AspNetUsers where Email=@Email and PasswordHash = @Passwordhash)
	insert into AspNetUsers(Guid,CreatedAt,Email,EmailConfirmed,PasswordHash,PhoneNumber,PhoneNumberConfirmed,LockoutEnabled,AccessFailedCount,UserName,Address)
	values(NEWID(),GETDATE(),@Email,1,@Passwordhash,@PhoneNumber,1,0,0,@UserName,@Address)
end
GO
/****** Object:  StoredProcedure [dbo].[SetApartmentReview]    Script Date: 8.7.2022. 17:44:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[SetApartmentReview]
	@idapartment int,
	@UserId int,
	@Details nvarchar(1000),
	@stars int
as
begin
	insert into ApartmentReview(Guid,CreatedAt,ApartmentId,UserId,Details,Stars)values(NEWID(),GETDATE(),@idapartment,@UserId,@Details,@stars)
end
GO
/****** Object:  StoredProcedure [dbo].[SetRepresentativePicture]    Script Date: 8.7.2022. 17:44:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[SetRepresentativePicture]
	@id int
as
update ApartmentPicture
set IsRepresentative =(case when Id=@id then 1 else 0 end)
where Id=@id
GO
/****** Object:  StoredProcedure [dbo].[UpdateApartment]    Script Date: 8.7.2022. 17:44:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[UpdateApartment]
	@id int,
	@OwnerName nvarchar(50),
	@StatusId int,
	@CityId int,
	@Address nvarchar(70),
	@Name nvarchar(50),
	@NameEng nvarchar(50),
	@Price money,
	@MaxAdults int,
	@MaxChildren int,
	@TotalRooms int,
	@BeachDistance int
as
begin
	if exists(select * from ApartmentOwner where ApartmentOwner.Name = @OwnerName)
		update ApartmentOwner
		set Name = @OwnerName
		where Name = @OwnerName
	else
		insert into ApartmentOwner(Name) values(@OwnerName)
end
begin
declare @OwnerId int
set @OwnerId=(select ApartmentOwner.Id from ApartmentOwner where Name=@OwnerName)
	update Apartment
	set OwnerId= @OwnerId,
		StatusId = @StatusId,
		CityId = @CityId,
		Address = @Address,
		Name = @Name,
		NameEng = @NameEng,
		Price = @Price,
		MaxAdults = @MaxAdults,
		MaxChildren = @MaxChildren,
		TotalRooms = @TotalRooms,
		BeachDistance = @BeachDistance
where Id = @id
end
		
GO
USE [master]
GO
ALTER DATABASE [RwaProjektApartmani] SET  READ_WRITE 
GO
