USE [master]
GO

/****** Object:  Database [Test]    Script Date: 23.02.2016 10:32:08 ******/
CREATE DATABASE [Test]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Test', FILENAME = N'D:\VStudio\AllTests\Test.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Test_log', FILENAME = N'D:\VStudio\AllTests\Test_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
COLLATE SQL_Latin1_General_CP1251_CI_AS

GO

ALTER DATABASE [Test] SET COMPATIBILITY_LEVEL = 110
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

ALTER DATABASE [Test] SET AUTO_CREATE_STATISTICS ON 
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

ALTER DATABASE [Test] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO

ALTER DATABASE [Test] SET  READ_WRITE 
GO

USE [Test]
GO
/****** Object:  StoredProcedure [dbo].[EndDayShow]    Script Date: 22.02.2016 17:07:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[EndDayShow]
	-- Add the parameters for the stored procedure here
--	<@Numend, sysname, @p1> <Datatype_For_Param1, , int> = <Default_Value_For_Param1, , 0>, 
--	<@Param2, sysname, @p2> <Datatype_For_Param2, , int> = <Default_Value_For_Param2, , 0>
    @Numend int, @Kind int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT        /*Tov_all.Nomchk, Tov_all.Numend, */ Tov_all.Depart, Tov_all.Codfuel, cast(sum(1.0*Tov_all.Amount/Tov_all.Divide) as float) Amount, Tov_all.Price, sum(Tov_all.Pay) Pay, Tov_all.Kind, Tov_all.Termkind, 
                         Fuel.name
    FROM            Fuel INNER JOIN
                         Tov_all ON Fuel.codfuel = Tov_all.Codfuel
    where Numend = @Numend and kind = @Kind  
    group by Tov_all.Kind, Tov_all.Codfuel, Tov_all.Depart, Tov_all.Price, Tov_all.Termkind, Fuel.name
	
    
	
END

GO
/****** Object:  Table [dbo].[Config]    Script Date: 22.02.2016 17:07:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Config](
	[Id] [int] NOT NULL,
	[Data] [int] NULL,
	[Text] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Fuel]    Script Date: 22.02.2016 17:07:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Fuel](
	[Codfuel] [int] NOT NULL,
	[Name] [varchar](25) NULL,
	[F_stop] [smallint] NULL,
 CONSTRAINT [PK_Fuel] PRIMARY KEY CLUSTERED 
(
	[Codfuel] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Tov_all]    Script Date: 22.02.2016 17:07:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Tov_all](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nomchk] [int] NOT NULL,
	[Depart] [smallint] NOT NULL,
	[Datepay] [datetime] NOT NULL,
	[Num] [smallint] NULL,
	[Numend] [int] NOT NULL,
	[Codfuel] [int] NOT NULL,
	[Amount] [int] NOT NULL,
	[Price] [int] NOT NULL,
	[Pay] [int] NOT NULL,
	[Scpay] [int] NOT NULL,
	[Kind] [smallint] NOT NULL,
	[Divide] [smallint] NOT NULL,
	[Cardcode] [char](25) NULL,
	[Kod_city] [char](7) NULL,
	[Klient] [char](7) NULL,
	[Amountr] [int] NULL,
	[Termkind] [int] NOT NULL,
	[Bonuscurr] [int] NULL,
	[Bonussumm] [int] NULL,
	[Kod_pred] [char](4) NULL,
 CONSTRAINT [PK_Tov_all] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  View [dbo].[ViewEndDay]    Script Date: 22.02.2016 17:07:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[ViewEndDay]
AS
SELECT        dbo.Tov_all.Numend, dbo.Tov_all.Depart, dbo.Tov_all.Codfuel, iif(dbo.Tov_all.Kind > 0, 1, dbo.Tov_all.Kind) AS Kind, 
                         cast(sum(1.0 * dbo.Tov_all.Amount / dbo.Tov_all.Divide) AS float) AS Amount, dbo.Tov_all.Price, SUM(dbo.Tov_all.Pay) AS Pay, dbo.Fuel.Name
FROM            dbo.Tov_all INNER JOIN
                         dbo.Fuel ON dbo.Tov_all.Codfuel = dbo.Fuel.codfuel
GROUP BY dbo.Tov_all.Numend, Kind, dbo.Tov_all.Codfuel, dbo.Tov_all.Price, dbo.Tov_all.Depart, dbo.Fuel.Name

GO
ALTER TABLE [dbo].[Tov_all] ADD  DEFAULT ((0)) FOR [Price]
GO
ALTER TABLE [dbo].[Tov_all] ADD  DEFAULT ((0)) FOR [Pay]
GO
ALTER TABLE [dbo].[Tov_all] ADD  DEFAULT ((0)) FOR [Scpay]
GO
ALTER TABLE [dbo].[Tov_all] ADD  DEFAULT ((1000)) FOR [Divide]
GO
