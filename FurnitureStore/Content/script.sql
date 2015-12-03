USE [FurnitureStore]
GO
/****** Object:  Table [dbo].[Carts]    Script Date: 03.12.2015 14:47:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Carts](
	[Id] [nvarchar](50) NOT NULL,
	[UserId] [nvarchar](50) NOT NULL,
	[PayDate] [date] NULL,
	[IsPayed] [bit] NULL,
 CONSTRAINT [PK_Carts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Goods]    Script Date: 03.12.2015 14:47:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Goods](
	[Id] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](250) NOT NULL,
	[Material] [nvarchar](250) NOT NULL,
	[Color] [nvarchar](100) NOT NULL,
	[Manufacturer] [nvarchar](250) NOT NULL,
	[Length] [float] NOT NULL,
	[Width] [float] NOT NULL,
	[Height] [float] NOT NULL,
	[Price] [decimal](18, 0) NOT NULL,
	[AdditionalInformation] [nvarchar](500) NOT NULL,
	[TypeId] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Goods] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Orders]    Script Date: 03.12.2015 14:47:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[CartId] [nvarchar](50) NOT NULL,
	[GoodsId] [nvarchar](50) NOT NULL,
	[Position] [int] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Roles]    Script Date: 03.12.2015 14:47:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[Id] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](250) NOT NULL,
	[AddedDate] [date] NOT NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Types]    Script Date: 03.12.2015 14:47:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Types](
	[Id] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](250) NOT NULL,
 CONSTRAINT [PK_Types] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Users]    Script Date: 03.12.2015 14:47:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[FirstName] [nvarchar](150) NOT NULL,
	[MiddleName] [nvarchar](150) NOT NULL,
	[LastName] [nvarchar](150) NOT NULL,
	[RegistrationDate] [date] NOT NULL,
	[RoleId] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Carts]  WITH CHECK ADD  CONSTRAINT [FK_Carts_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Carts] CHECK CONSTRAINT [FK_Carts_Users]
GO
ALTER TABLE [dbo].[Goods]  WITH CHECK ADD  CONSTRAINT [FK_Goods_Types] FOREIGN KEY([TypeId])
REFERENCES [dbo].[Types] ([Id])
GO
ALTER TABLE [dbo].[Goods] CHECK CONSTRAINT [FK_Goods_Types]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Carts] FOREIGN KEY([CartId])
REFERENCES [dbo].[Carts] ([Id])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Carts]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Goods] FOREIGN KEY([GoodsId])
REFERENCES [dbo].[Goods] ([Id])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Goods]
GO
ALTER TABLE [dbo].[Types]  WITH CHECK ADD  CONSTRAINT [FK_Types_Goods] FOREIGN KEY([Id])
REFERENCES [dbo].[Types] ([Id])
GO
ALTER TABLE [dbo].[Types] CHECK CONSTRAINT [FK_Types_Goods]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Roles] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Roles] ([Id])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_Roles]
GO

INSERT INTO [dbo].[Roles] values ('BB8E94C7-6533-4E1E-B71A-EADCB68B3E31','Administrator','2015-12-02');

INSERT INTO [dbo].[Types] VALUES ('418C9A7E-DA2F-4149-B1EC-117452C7783D','Cupboard');

INSERT INTO [dbo].[Types] VALUES ('CB1ABB26-08F9-40D7-9150-64ED9EED34D8','Chair');

INSERT INTO [dbo].[Types] VALUES ('DA3EF387-0AA1-43B1-9D09-4B1234DE450B','Bed');

INSERT INTO [dbo].[Types] VALUES ('FFA2BBD5-F614-456F-97CB-A3554E036232','Table');

INSERT INTO [dbo].[Goods] VALUES ('5B335C86-2888-4DB6-AE7F-558329376BDB','Wooden chair','Wood','Brown','Karaganda','40','40','55','3500','Without backs','CB1ABB26-08F9-40D7-9150-64ED9EED34D8');

INSERT INTO [dbo].[Goods] VALUES ('72F337F2-2524-4373-8806-20EFFBF6703E','Wooden table','Wood','Brown','Karaganda','100','100','85','3500','Transformable','FFA2BBD5-F614-456F-97CB-A3554E036232');

INSERT INTO [dbo].[Users] VALUES ('0AE60EB7-4F4A-43EE-9B21-95ACAFDD18E8','test@mail.ru','123456','Imya','Otchestvo','Familia','2015-12-03','BB8E94C7-6533-4E1E-B71A-EADCB68B3E31');