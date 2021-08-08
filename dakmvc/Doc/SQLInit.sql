/****** Object:  User [sa1]    Script Date: 8/8/2021 4:10:40 PM ******/
CREATE USER [sa1] FOR LOGIN [sa1] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [sa1]
GO
ALTER ROLE [db_ddladmin] ADD MEMBER [sa1]
GO
ALTER ROLE [db_datareader] ADD MEMBER [sa1]
GO
/****** Object:  Table [dbo].[dak_District]    Script Date: 8/8/2021 4:10:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[dak_District](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[_name] [nvarchar](200) NULL,
	[_prefix] [nvarchar](200) NULL,
	[_province_id] [int] NULL,
 CONSTRAINT [PK_dak_District] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[dak_Feature]    Script Date: 8/8/2021 4:10:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[dak_Feature](
	[ID] [int] NULL,
	[Name] [nvarchar](250) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[dak_HomeType]    Script Date: 8/8/2021 4:10:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[dak_HomeType](
	[ID] [int] NULL,
	[Name] [nvarchar](250) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[dak_images]    Script Date: 8/8/2021 4:10:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[dak_images](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Path] [varchar](500) NULL,
	[Datetime] [datetime] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[dak_Post]    Script Date: 8/8/2021 4:10:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[dak_Post](
	[ID] [int] NULL,
	[UserID] [int] NULL,
	[Address] [nvarchar](500) NULL,
	[DistrictID] [int] NULL,
	[CityID] [int] NULL,
	[WardID] [int] NULL,
	[StreetID] [int] NULL,
	[ProjectID] [int] NULL,
	[Price] [float] NULL,
	[PriceUnit] [int] NULL,
	[Square] [float] NULL,
	[Room] [int] NULL,
	[Toilet] [int] NULL,
	[HomeSubTypeID] [int] NULL,
	[SellOrRent] [int] NULL,
	[Direction] [int] NULL,
	[PinkBook] [int] NULL,
	[IsHost] [int] NULL,
	[MainImageID] [int] NULL,
	[lat] [float] NULL,
	[long] [float] NULL,
	[Datetime] [datetime] NULL,
	[UpdateDate] [datetime] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[dak_PostDetail]    Script Date: 8/8/2021 4:10:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[dak_PostDetail](
	[ID] [int] NULL,
	[PostID] [int] NULL,
	[width] [float] NULL,
	[height] [float] NULL,
	[images] [varchar](500) NULL,
	[imageCount] [int] NULL,
	[Description] [varchar](500) NULL,
	[BankSupport] [int] NULL,
	[FeatureIDs] [varchar](100) NULL,
	[FeatureValues] [varchar](500) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[dak_Story]    Script Date: 8/8/2021 4:10:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[dak_Story](
	[ID] [int] NULL,
	[UserID] [int] NULL,
	[PostID] [int] NULL,
	[DateTime] [datetime] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[project]    Script Date: 8/8/2021 4:10:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[project](
	[id] [int] NOT NULL,
	[_name] [nvarchar](200) NULL,
	[_province_id] [int] NULL,
	[_district_id] [int] NULL,
	[_lat] [float] NULL,
	[_lng] [float] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[province]    Script Date: 8/8/2021 4:10:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[province](
	[id] [int] NOT NULL,
	[_name] [nvarchar](50) NULL,
	[_code] [nvarchar](20) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[street]    Script Date: 8/8/2021 4:10:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[street](
	[id] [int] NOT NULL,
	[_name] [nvarchar](100) NULL,
	[_prefix] [nvarchar](20) NULL,
	[_province_id] [int] NULL,
	[_district_id] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ward]    Script Date: 8/8/2021 4:10:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ward](
	[id] [int] NOT NULL,
	[_name] [nvarchar](50) NOT NULL,
	[_prefix] [nvarchar](20) NULL,
	[_province_id] [int] NULL,
	[_district_id] [int] NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[dak_images] ADD  CONSTRAINT [DF_dak_images_Datetime]  DEFAULT (getdate()) FOR [Datetime]
GO
