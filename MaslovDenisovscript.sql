USE [Маслов/Денисов_КомпьютерныйСалон]
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 24.10.2021 21:44:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[ID_customer] [int] NOT NULL,
	[FirstName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	[Phone_number] [nvarchar](50) NULL,
	[Adress] [nvarchar](max) NULL,
 CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED 
(
	[ID_customer] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employees]    Script Date: 24.10.2021 21:44:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employees](
	[ID_Employer] [int] NOT NULL,
	[FirstName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	[Position] [nvarchar](50) NULL,
	[Phone_number] [nvarchar](50) NULL,
 CONSTRAINT [PK_Employees] PRIMARY KEY CLUSTERED 
(
	[ID_Employer] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 24.10.2021 21:44:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[ID_product] [int] NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Price] [money] NULL,
	[Count] [int] NULL,
	[Guarantee] [date] NULL,
	[Photo] [nvarchar](max) NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[ID_product] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Selling Details]    Script Date: 24.10.2021 21:44:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Selling Details](
	[ID_sell] [int] NOT NULL,
	[ID_product] [int] NOT NULL,
	[Price] [money] NULL,
	[Count] [int] NULL,
	[Discount] [float] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sellings]    Script Date: 24.10.2021 21:44:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sellings](
	[ID_sell] [int] NOT NULL,
	[ID_customer] [int] NOT NULL,
	[ID_employer] [int] NOT NULL,
	[Date] [datetime] NULL,
 CONSTRAINT [PK_Sellings] PRIMARY KEY CLUSTERED 
(
	[ID_sell] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Suppliers]    Script Date: 24.10.2021 21:44:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Suppliers](
	[ID_supplier] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[INN] [int] NULL,
	[Adress] [nvarchar](max) NULL,
	[Phone_Number] [nvarchar](50) NULL,
 CONSTRAINT [PK_Suppliers] PRIMARY KEY CLUSTERED 
(
	[ID_supplier] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Supplies]    Script Date: 24.10.2021 21:44:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Supplies](
	[ID_supply] [int] NOT NULL,
	[ID_suppliers] [int] NOT NULL,
	[ID_employer] [int] NOT NULL,
	[Date] [datetime] NULL,
 CONSTRAINT [PK_Supplies] PRIMARY KEY CLUSTERED 
(
	[ID_supply] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Supplies Details]    Script Date: 24.10.2021 21:44:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Supplies Details](
	[ID_supply] [int] NOT NULL,
	[ID_products] [int] NOT NULL,
	[Price] [money] NULL,
	[Count] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 24.10.2021 21:44:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Login] [nvarchar](50) NULL,
	[Password] [nvarchar](50) NULL,
	[Role] [nvarchar](max) NULL,
	[FIO] [nvarchar](max) NULL,
	[ID] [int] NOT NULL,
	[Photo] [nvarchar](max) NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[Customers] ([ID_customer], [FirstName], [LastName], [Phone_number], [Adress]) VALUES (0, N'Екатерина', N'Петровна', N'12321321', N'Москва')
INSERT [dbo].[Customers] ([ID_customer], [FirstName], [LastName], [Phone_number], [Adress]) VALUES (1, N'Михаил', N'Иванов', N'1234567', N'Москва')
INSERT [dbo].[Customers] ([ID_customer], [FirstName], [LastName], [Phone_number], [Adress]) VALUES (2, N'Петр', N'Петров', N'1232456', N'Санкт-Петербург')
INSERT [dbo].[Customers] ([ID_customer], [FirstName], [LastName], [Phone_number], [Adress]) VALUES (3, N'Мария', N'Иванова', N'12342155', N'Москва')
GO
INSERT [dbo].[Employees] ([ID_Employer], [FirstName], [LastName], [Position], [Phone_number]) VALUES (0, N'Сергей', N'Сергеев', N'Продавец', N'123123123')
INSERT [dbo].[Employees] ([ID_Employer], [FirstName], [LastName], [Position], [Phone_number]) VALUES (1, N'Александр', N'Серый', N'Бухгалтер', N'12321415')
INSERT [dbo].[Employees] ([ID_Employer], [FirstName], [LastName], [Position], [Phone_number]) VALUES (2, N'Екатерина', N'Белая', N'Бухгалтер', N'214214214')
INSERT [dbo].[Employees] ([ID_Employer], [FirstName], [LastName], [Position], [Phone_number]) VALUES (3, N'Сергей', N'Михайлов', N'Директор', N'24214124214')
GO
INSERT [dbo].[Products] ([ID_product], [Name], [Price], [Count], [Guarantee], [Photo]) VALUES (0, N'ОЗУ', 5000.0000, 1000, CAST(N'2022-11-11' AS Date), N'https://ocompah.ru/wp-content/uploads/2015/09/opredelit-ozu.png')
INSERT [dbo].[Products] ([ID_product], [Name], [Price], [Count], [Guarantee], [Photo]) VALUES (1, N'Видеокарта', 25000.0000, 50, CAST(N'2022-11-11' AS Date), N'https://sidex.ru/images_offers/4099/4099645/thumb/imggigabyte_geforce_gtx_1660super_1860mhz_pcie_30_6144mb_14000mhz_192_bit_hdmi_hdcp_gaming_oc_gvn16_5.jpg')
INSERT [dbo].[Products] ([ID_product], [Name], [Price], [Count], [Guarantee], [Photo]) VALUES (2, N'Процессор', 20000.0000, 50, CAST(N'2022-11-11' AS Date), N'https://static.nix.ru/autocatalog/intel/425883_3159_draft.jpg')
INSERT [dbo].[Products] ([ID_product], [Name], [Price], [Count], [Guarantee], [Photo]) VALUES (3, N'Материнская плата', 10000.0000, 250, CAST(N'2022-11-11' AS Date), NULL)
INSERT [dbo].[Products] ([ID_product], [Name], [Price], [Count], [Guarantee], [Photo]) VALUES (4, N'123', 123.0000, 123, CAST(N'2021-10-08' AS Date), NULL)
GO
INSERT [dbo].[Selling Details] ([ID_sell], [ID_product], [Price], [Count], [Discount]) VALUES (1, 1, 30000.0000, 1, 0.25)
INSERT [dbo].[Selling Details] ([ID_sell], [ID_product], [Price], [Count], [Discount]) VALUES (2, 2, 20000.0000, 1, NULL)
INSERT [dbo].[Selling Details] ([ID_sell], [ID_product], [Price], [Count], [Discount]) VALUES (3, 3, 10000.0000, 2, 0.1)
GO
INSERT [dbo].[Sellings] ([ID_sell], [ID_customer], [ID_employer], [Date]) VALUES (1, 1, 1, CAST(N'2021-10-10T00:00:00.000' AS DateTime))
INSERT [dbo].[Sellings] ([ID_sell], [ID_customer], [ID_employer], [Date]) VALUES (2, 2, 1, CAST(N'2021-10-10T00:00:00.000' AS DateTime))
INSERT [dbo].[Sellings] ([ID_sell], [ID_customer], [ID_employer], [Date]) VALUES (3, 3, 1, CAST(N'2021-10-05T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[Suppliers] ([ID_supplier], [Name], [INN], [Adress], [Phone_Number]) VALUES (1, N'Nvidia', 123213, N'США', N'123213123')
INSERT [dbo].[Suppliers] ([ID_supplier], [Name], [INN], [Adress], [Phone_Number]) VALUES (2, N'AMD', 123214, N'Корея', N'123213213')
INSERT [dbo].[Suppliers] ([ID_supplier], [Name], [INN], [Adress], [Phone_Number]) VALUES (3, N'ASUS', 123124, N'США', N'123213213')
GO
INSERT [dbo].[Supplies] ([ID_supply], [ID_suppliers], [ID_employer], [Date]) VALUES (1, 1, 2, CAST(N'2021-09-10T00:00:00.000' AS DateTime))
INSERT [dbo].[Supplies] ([ID_supply], [ID_suppliers], [ID_employer], [Date]) VALUES (2, 2, 2, CAST(N'2021-09-11T00:00:00.000' AS DateTime))
INSERT [dbo].[Supplies] ([ID_supply], [ID_suppliers], [ID_employer], [Date]) VALUES (3, 3, 2, CAST(N'2021-09-12T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[Supplies Details] ([ID_supply], [ID_products], [Price], [Count]) VALUES (1, 1, 28000.0000, 100)
INSERT [dbo].[Supplies Details] ([ID_supply], [ID_products], [Price], [Count]) VALUES (2, 2, 18000.0000, 50)
INSERT [dbo].[Supplies Details] ([ID_supply], [ID_products], [Price], [Count]) VALUES (3, 3, 5000.0000, 250)
GO
INSERT [dbo].[User] ([Login], [Password], [Role], [FIO], [ID], [Photo]) VALUES (N'Sellsman', N'12345QWE_', N'Seller', N'Иванов Иван Иванович', 0, N'https://cdn1.flamp.ru/1d1ce0c080c93ab960950fc28d524b80_300_300.jpeg')
INSERT [dbo].[User] ([Login], [Password], [Role], [FIO], [ID], [Photo]) VALUES (N'admin', N'admin', N'Director', N'Иванов Иван Иванович', 1, NULL)
INSERT [dbo].[User] ([Login], [Password], [Role], [FIO], [ID], [Photo]) VALUES (N'cutsomer', N'customer', N'Customer', N'Петр Петров Петрович', 2, NULL)
INSERT [dbo].[User] ([Login], [Password], [Role], [FIO], [ID], [Photo]) VALUES (N'Aknas', N'14112002Sm_-', N'Customer', N'123', 3, NULL)
INSERT [dbo].[User] ([Login], [Password], [Role], [FIO], [ID], [Photo]) VALUES (N'123', N'14112002Sm_-', N'Customer', N'123', 4, NULL)
INSERT [dbo].[User] ([Login], [Password], [Role], [FIO], [ID], [Photo]) VALUES (N'AK', N'14112002Sm_-', N'Director', N'AK', 5, NULL)
GO
ALTER TABLE [dbo].[Selling Details]  WITH CHECK ADD  CONSTRAINT [FK_Selling Details_Products] FOREIGN KEY([ID_product])
REFERENCES [dbo].[Products] ([ID_product])
GO
ALTER TABLE [dbo].[Selling Details] CHECK CONSTRAINT [FK_Selling Details_Products]
GO
ALTER TABLE [dbo].[Selling Details]  WITH CHECK ADD  CONSTRAINT [FK_Selling Details_Sellings] FOREIGN KEY([ID_sell])
REFERENCES [dbo].[Sellings] ([ID_sell])
GO
ALTER TABLE [dbo].[Selling Details] CHECK CONSTRAINT [FK_Selling Details_Sellings]
GO
ALTER TABLE [dbo].[Sellings]  WITH CHECK ADD  CONSTRAINT [FK_Sellings_Customers] FOREIGN KEY([ID_customer])
REFERENCES [dbo].[Customers] ([ID_customer])
GO
ALTER TABLE [dbo].[Sellings] CHECK CONSTRAINT [FK_Sellings_Customers]
GO
ALTER TABLE [dbo].[Sellings]  WITH CHECK ADD  CONSTRAINT [FK_Sellings_Employees] FOREIGN KEY([ID_employer])
REFERENCES [dbo].[Employees] ([ID_Employer])
GO
ALTER TABLE [dbo].[Sellings] CHECK CONSTRAINT [FK_Sellings_Employees]
GO
ALTER TABLE [dbo].[Supplies]  WITH CHECK ADD  CONSTRAINT [FK_Supplies_Employees] FOREIGN KEY([ID_employer])
REFERENCES [dbo].[Employees] ([ID_Employer])
GO
ALTER TABLE [dbo].[Supplies] CHECK CONSTRAINT [FK_Supplies_Employees]
GO
ALTER TABLE [dbo].[Supplies]  WITH CHECK ADD  CONSTRAINT [FK_Supplies_Suppliers] FOREIGN KEY([ID_suppliers])
REFERENCES [dbo].[Suppliers] ([ID_supplier])
GO
ALTER TABLE [dbo].[Supplies] CHECK CONSTRAINT [FK_Supplies_Suppliers]
GO
ALTER TABLE [dbo].[Supplies Details]  WITH CHECK ADD  CONSTRAINT [FK_Supplies Details_Products] FOREIGN KEY([ID_products])
REFERENCES [dbo].[Products] ([ID_product])
GO
ALTER TABLE [dbo].[Supplies Details] CHECK CONSTRAINT [FK_Supplies Details_Products]
GO
ALTER TABLE [dbo].[Supplies Details]  WITH CHECK ADD  CONSTRAINT [FK_Supplies Details_Supplies] FOREIGN KEY([ID_supply])
REFERENCES [dbo].[Supplies] ([ID_supply])
GO
ALTER TABLE [dbo].[Supplies Details] CHECK CONSTRAINT [FK_Supplies Details_Supplies]
GO
