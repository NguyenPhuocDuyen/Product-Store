USE [TKDecor]
GO
/****** Object:  Table [dbo].[Cart]    Script Date: 3/20/2023 4:24:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cart](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[user_id] [int] NULL,
	[product_id] [int] NULL,
	[quantity] [int] NULL,
	[create_at] [datetime] NULL,
	[update_at] [datetime] NULL,
 CONSTRAINT [PK_Cart] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 3/20/2023 4:24:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[description] [nvarchar](255) NULL,
	[create_at] [datetime] NULL,
	[update_at] [datetime] NULL,
	[is_delete] [bit] NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order]    Script Date: 3/20/2023 4:24:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[user_id] [int] NULL,
	[order_address] [nvarchar](255) NULL,
	[status_id] [int] NULL,
	[create_at] [datetime] NULL,
	[update_at] [datetime] NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderDetail]    Script Date: 3/20/2023 4:24:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetail](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[product_id] [int] NULL,
	[order_id] [int] NULL,
	[amount] [int] NULL,
	[payment_price] [int] NULL,
	[create_at] [datetime] NULL,
	[update_at] [datetime] NULL,
 CONSTRAINT [PK_OrderDetail] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 3/20/2023 4:24:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[title] [nvarchar](255) NOT NULL,
	[description] [nvarchar](max) NOT NULL,
	[recent_price] [int] NOT NULL,
	[thumbnail] [nvarchar](255) NULL,
	[amount] [int] NOT NULL,
	[category_id] [int] NULL,
	[create_at] [datetime] NULL,
	[update_at] [datetime] NULL,
	[is_delete] [bit] NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Review]    Script Date: 3/20/2023 4:24:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Review](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[product_id] [int] NULL,
	[user_id] [int] NULL,
	[description] [nvarchar](255) NULL,
	[rate] [int] NULL,
	[create_at] [datetime] NULL,
	[update_at] [datetime] NULL,
	[is_delete] [bit] NULL,
 CONSTRAINT [PK_Review] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 3/20/2023 4:24:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[description] [nvarchar](255) NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Status]    Script Date: 3/20/2023 4:24:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Status](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[title] [nvarchar](255) NULL,
	[create_at] [datetime] NULL,
	[update_at] [datetime] NULL,
 CONSTRAINT [PK_Status] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 3/20/2023 4:24:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[email] [nvarchar](255) NULL,
	[password] [nvarchar](255) NULL,
	[full_name] [nvarchar](255) NULL,
	[phone] [nvarchar](255) NULL,
	[address] [nvarchar](255) NULL,
	[role_id] [int] NULL,
	[create_at] [datetime] NULL,
	[update_at] [datetime] NULL,
	[is_delete] [bit] NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[EmailConfirmationToken] [nvarchar](max) NULL,
	[EmailConfirmationSentAt] [datetime2](7) NULL,
	[IsPasswordResetRequired] [bit] NOT NULL,
	[ResetPasswordToken] [nvarchar](max) NULL,
	[ResetPasswordSentAt] [datetime2](7) NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Category] ON 

INSERT [dbo].[Category] ([id], [description], [create_at], [update_at], [is_delete]) VALUES (1, N'Bàn', CAST(N'2023-03-20T16:22:56.207' AS DateTime), CAST(N'2023-03-20T16:22:56.207' AS DateTime), 0)
INSERT [dbo].[Category] ([id], [description], [create_at], [update_at], [is_delete]) VALUES (2, N'Ly', CAST(N'2023-03-20T16:22:56.207' AS DateTime), CAST(N'2023-03-20T16:22:56.207' AS DateTime), 0)
INSERT [dbo].[Category] ([id], [description], [create_at], [update_at], [is_delete]) VALUES (3, N'Đồng hồ', CAST(N'2023-03-20T16:22:56.207' AS DateTime), CAST(N'2023-03-20T16:22:56.207' AS DateTime), 0)
INSERT [dbo].[Category] ([id], [description], [create_at], [update_at], [is_delete]) VALUES (4, N'Hồ cá', CAST(N'2023-03-20T16:22:56.207' AS DateTime), CAST(N'2023-03-20T16:22:56.207' AS DateTime), 0)
INSERT [dbo].[Category] ([id], [description], [create_at], [update_at], [is_delete]) VALUES (5, N'Tượng', CAST(N'2023-03-20T16:22:56.207' AS DateTime), CAST(N'2023-03-20T16:22:56.207' AS DateTime), 0)
INSERT [dbo].[Category] ([id], [description], [create_at], [update_at], [is_delete]) VALUES (6, N'Bình rượu', CAST(N'2023-03-20T16:22:56.207' AS DateTime), CAST(N'2023-03-20T16:22:56.207' AS DateTime), 0)
INSERT [dbo].[Category] ([id], [description], [create_at], [update_at], [is_delete]) VALUES (7, N'Giấy dán tường', CAST(N'2023-03-20T16:22:56.207' AS DateTime), CAST(N'2023-03-20T16:22:56.207' AS DateTime), 0)
INSERT [dbo].[Category] ([id], [description], [create_at], [update_at], [is_delete]) VALUES (8, N'Bình hoa', CAST(N'2023-03-20T16:22:56.207' AS DateTime), CAST(N'2023-03-20T16:22:56.207' AS DateTime), 0)
INSERT [dbo].[Category] ([id], [description], [create_at], [update_at], [is_delete]) VALUES (9, N'Gương', CAST(N'2023-03-20T16:22:56.207' AS DateTime), CAST(N'2023-03-20T16:22:56.207' AS DateTime), 0)
INSERT [dbo].[Category] ([id], [description], [create_at], [update_at], [is_delete]) VALUES (10, N'Thảm', CAST(N'2023-03-20T16:22:56.207' AS DateTime), CAST(N'2023-03-20T16:22:56.207' AS DateTime), 0)
INSERT [dbo].[Category] ([id], [description], [create_at], [update_at], [is_delete]) VALUES (11, N'Rèm', CAST(N'2023-03-20T16:22:56.207' AS DateTime), CAST(N'2023-03-20T16:22:56.207' AS DateTime), 0)
INSERT [dbo].[Category] ([id], [description], [create_at], [update_at], [is_delete]) VALUES (12, N'Đèn', CAST(N'2023-03-20T16:22:56.207' AS DateTime), CAST(N'2023-03-20T16:22:56.207' AS DateTime), 0)
INSERT [dbo].[Category] ([id], [description], [create_at], [update_at], [is_delete]) VALUES (13, N'Kệ', CAST(N'2023-03-20T16:22:56.207' AS DateTime), CAST(N'2023-03-20T16:22:56.207' AS DateTime), 0)
INSERT [dbo].[Category] ([id], [description], [create_at], [update_at], [is_delete]) VALUES (14, N'Tủ', CAST(N'2023-03-20T16:22:56.207' AS DateTime), CAST(N'2023-03-20T16:22:56.207' AS DateTime), 0)
INSERT [dbo].[Category] ([id], [description], [create_at], [update_at], [is_delete]) VALUES (15, N'Giường', CAST(N'2023-03-20T16:22:56.207' AS DateTime), CAST(N'2023-03-20T16:22:56.207' AS DateTime), 0)
INSERT [dbo].[Category] ([id], [description], [create_at], [update_at], [is_delete]) VALUES (16, N'Ghế', CAST(N'2023-03-20T16:22:56.207' AS DateTime), CAST(N'2023-03-20T16:22:56.207' AS DateTime), 0)
INSERT [dbo].[Category] ([id], [description], [create_at], [update_at], [is_delete]) VALUES (17, N'Đĩa', CAST(N'2023-03-20T16:22:56.207' AS DateTime), CAST(N'2023-03-20T16:22:56.207' AS DateTime), 0)
INSERT [dbo].[Category] ([id], [description], [create_at], [update_at], [is_delete]) VALUES (18, N'Quạt', CAST(N'2023-03-20T16:22:56.207' AS DateTime), CAST(N'2023-03-20T16:22:56.207' AS DateTime), 0)
SET IDENTITY_INSERT [dbo].[Category] OFF
GO
SET IDENTITY_INSERT [dbo].[Order] ON 

INSERT [dbo].[Order] ([id], [user_id], [order_address], [status_id], [create_at], [update_at]) VALUES (1, 10, N'Long An', 2, CAST(N'2020-04-06T00:00:00.000' AS DateTime), CAST(N'2023-03-20T16:22:56.997' AS DateTime))
INSERT [dbo].[Order] ([id], [user_id], [order_address], [status_id], [create_at], [update_at]) VALUES (2, 9, N'Lào Cai', 1, CAST(N'2022-01-02T00:00:00.000' AS DateTime), CAST(N'2023-03-20T16:22:56.997' AS DateTime))
INSERT [dbo].[Order] ([id], [user_id], [order_address], [status_id], [create_at], [update_at]) VALUES (3, 8, N'Lạng Sơn', 4, CAST(N'2021-09-30T00:00:00.000' AS DateTime), CAST(N'2023-03-20T16:22:56.997' AS DateTime))
INSERT [dbo].[Order] ([id], [user_id], [order_address], [status_id], [create_at], [update_at]) VALUES (4, 7, N'Lâm Đồng', 2, CAST(N'2021-02-07T00:00:00.000' AS DateTime), CAST(N'2023-03-20T16:22:56.997' AS DateTime))
INSERT [dbo].[Order] ([id], [user_id], [order_address], [status_id], [create_at], [update_at]) VALUES (5, 6, N'Lai Châu', 2, CAST(N'2021-06-21T00:00:00.000' AS DateTime), CAST(N'2023-03-20T16:22:56.997' AS DateTime))
INSERT [dbo].[Order] ([id], [user_id], [order_address], [status_id], [create_at], [update_at]) VALUES (6, 5, N'Kon Tum', 3, CAST(N'2022-06-04T00:00:00.000' AS DateTime), CAST(N'2023-03-20T16:22:56.997' AS DateTime))
INSERT [dbo].[Order] ([id], [user_id], [order_address], [status_id], [create_at], [update_at]) VALUES (7, 4, N'Kiên Giang', 3, CAST(N'2022-05-08T00:00:00.000' AS DateTime), CAST(N'2023-03-20T16:22:56.997' AS DateTime))
INSERT [dbo].[Order] ([id], [user_id], [order_address], [status_id], [create_at], [update_at]) VALUES (8, 3, N'Khánh Hòa', 1, CAST(N'2022-08-11T00:00:00.000' AS DateTime), CAST(N'2023-03-20T16:22:56.997' AS DateTime))
INSERT [dbo].[Order] ([id], [user_id], [order_address], [status_id], [create_at], [update_at]) VALUES (9, 2, N'Bình Phước', 4, CAST(N'2022-03-06T00:00:00.000' AS DateTime), CAST(N'2023-03-20T16:22:56.997' AS DateTime))
INSERT [dbo].[Order] ([id], [user_id], [order_address], [status_id], [create_at], [update_at]) VALUES (10, 1, N'', 3, CAST(N'2020-06-20T00:00:00.000' AS DateTime), CAST(N'2023-03-20T16:22:56.997' AS DateTime))
SET IDENTITY_INSERT [dbo].[Order] OFF
GO
SET IDENTITY_INSERT [dbo].[OrderDetail] ON 

INSERT [dbo].[OrderDetail] ([id], [product_id], [order_id], [amount], [payment_price], [create_at], [update_at]) VALUES (1, 10, 10, 5, 377000, CAST(N'2023-03-20T16:22:57.083' AS DateTime), CAST(N'2023-03-20T16:22:57.083' AS DateTime))
INSERT [dbo].[OrderDetail] ([id], [product_id], [order_id], [amount], [payment_price], [create_at], [update_at]) VALUES (2, 26, 5, 3, 221000, CAST(N'2023-03-20T16:22:57.083' AS DateTime), CAST(N'2023-03-20T16:22:57.083' AS DateTime))
INSERT [dbo].[OrderDetail] ([id], [product_id], [order_id], [amount], [payment_price], [create_at], [update_at]) VALUES (3, 24, 5, 19, 883000, CAST(N'2023-03-20T16:22:57.083' AS DateTime), CAST(N'2023-03-20T16:22:57.083' AS DateTime))
INSERT [dbo].[OrderDetail] ([id], [product_id], [order_id], [amount], [payment_price], [create_at], [update_at]) VALUES (4, 22, 5, 11, 30000, CAST(N'2023-03-20T16:22:57.083' AS DateTime), CAST(N'2023-03-20T16:22:57.083' AS DateTime))
INSERT [dbo].[OrderDetail] ([id], [product_id], [order_id], [amount], [payment_price], [create_at], [update_at]) VALUES (5, 25, 4, 1, 985000, CAST(N'2023-03-20T16:22:57.083' AS DateTime), CAST(N'2023-03-20T16:22:57.083' AS DateTime))
INSERT [dbo].[OrderDetail] ([id], [product_id], [order_id], [amount], [payment_price], [create_at], [update_at]) VALUES (6, 23, 4, 16, 387000, CAST(N'2023-03-20T16:22:57.083' AS DateTime), CAST(N'2023-03-20T16:22:57.083' AS DateTime))
INSERT [dbo].[OrderDetail] ([id], [product_id], [order_id], [amount], [payment_price], [create_at], [update_at]) VALUES (7, 21, 4, 9, 81000, CAST(N'2023-03-20T16:22:57.083' AS DateTime), CAST(N'2023-03-20T16:22:57.083' AS DateTime))
INSERT [dbo].[OrderDetail] ([id], [product_id], [order_id], [amount], [payment_price], [create_at], [update_at]) VALUES (8, 19, 4, 13, 333000, CAST(N'2023-03-20T16:22:57.083' AS DateTime), CAST(N'2023-03-20T16:22:57.083' AS DateTime))
INSERT [dbo].[OrderDetail] ([id], [product_id], [order_id], [amount], [payment_price], [create_at], [update_at]) VALUES (9, 17, 4, 1, 697000, CAST(N'2023-03-20T16:22:57.083' AS DateTime), CAST(N'2023-03-20T16:22:57.083' AS DateTime))
INSERT [dbo].[OrderDetail] ([id], [product_id], [order_id], [amount], [payment_price], [create_at], [update_at]) VALUES (10, 20, 3, 5, 491000, CAST(N'2023-03-20T16:22:57.083' AS DateTime), CAST(N'2023-03-20T16:22:57.083' AS DateTime))
INSERT [dbo].[OrderDetail] ([id], [product_id], [order_id], [amount], [payment_price], [create_at], [update_at]) VALUES (11, 18, 3, 8, 79000, CAST(N'2023-03-20T16:22:57.083' AS DateTime), CAST(N'2023-03-20T16:22:57.083' AS DateTime))
INSERT [dbo].[OrderDetail] ([id], [product_id], [order_id], [amount], [payment_price], [create_at], [update_at]) VALUES (12, 16, 3, 12, 209000, CAST(N'2023-03-20T16:22:57.083' AS DateTime), CAST(N'2023-03-20T16:22:57.083' AS DateTime))
INSERT [dbo].[OrderDetail] ([id], [product_id], [order_id], [amount], [payment_price], [create_at], [update_at]) VALUES (13, 14, 3, 8, 249000, CAST(N'2023-03-20T16:22:57.083' AS DateTime), CAST(N'2023-03-20T16:22:57.083' AS DateTime))
INSERT [dbo].[OrderDetail] ([id], [product_id], [order_id], [amount], [payment_price], [create_at], [update_at]) VALUES (14, 12, 3, 17, 501000, CAST(N'2023-03-20T16:22:57.083' AS DateTime), CAST(N'2023-03-20T16:22:57.083' AS DateTime))
INSERT [dbo].[OrderDetail] ([id], [product_id], [order_id], [amount], [payment_price], [create_at], [update_at]) VALUES (15, 15, 2, 3, 904000, CAST(N'2023-03-20T16:22:57.083' AS DateTime), CAST(N'2023-03-20T16:22:57.083' AS DateTime))
INSERT [dbo].[OrderDetail] ([id], [product_id], [order_id], [amount], [payment_price], [create_at], [update_at]) VALUES (16, 13, 2, 3, 185000, CAST(N'2023-03-20T16:22:57.083' AS DateTime), CAST(N'2023-03-20T16:22:57.083' AS DateTime))
INSERT [dbo].[OrderDetail] ([id], [product_id], [order_id], [amount], [payment_price], [create_at], [update_at]) VALUES (17, 11, 2, 18, 979000, CAST(N'2023-03-20T16:22:57.083' AS DateTime), CAST(N'2023-03-20T16:22:57.083' AS DateTime))
INSERT [dbo].[OrderDetail] ([id], [product_id], [order_id], [amount], [payment_price], [create_at], [update_at]) VALUES (18, 9, 2, 15, 440000, CAST(N'2023-03-20T16:22:57.083' AS DateTime), CAST(N'2023-03-20T16:22:57.083' AS DateTime))
INSERT [dbo].[OrderDetail] ([id], [product_id], [order_id], [amount], [payment_price], [create_at], [update_at]) VALUES (19, 7, 2, 3, 427000, CAST(N'2023-03-20T16:22:57.083' AS DateTime), CAST(N'2023-03-20T16:22:57.083' AS DateTime))
INSERT [dbo].[OrderDetail] ([id], [product_id], [order_id], [amount], [payment_price], [create_at], [update_at]) VALUES (20, 10, 1, 2, 377000, CAST(N'2023-03-20T16:22:57.083' AS DateTime), CAST(N'2023-03-20T16:22:57.083' AS DateTime))
INSERT [dbo].[OrderDetail] ([id], [product_id], [order_id], [amount], [payment_price], [create_at], [update_at]) VALUES (21, 8, 1, 2, 114000, CAST(N'2023-03-20T16:22:57.083' AS DateTime), CAST(N'2023-03-20T16:22:57.083' AS DateTime))
INSERT [dbo].[OrderDetail] ([id], [product_id], [order_id], [amount], [payment_price], [create_at], [update_at]) VALUES (22, 6, 1, 20, 952000, CAST(N'2023-03-20T16:22:57.083' AS DateTime), CAST(N'2023-03-20T16:22:57.083' AS DateTime))
INSERT [dbo].[OrderDetail] ([id], [product_id], [order_id], [amount], [payment_price], [create_at], [update_at]) VALUES (23, 28, 5, 8, 334000, CAST(N'2023-03-20T16:22:57.083' AS DateTime), CAST(N'2023-03-20T16:22:57.083' AS DateTime))
INSERT [dbo].[OrderDetail] ([id], [product_id], [order_id], [amount], [payment_price], [create_at], [update_at]) VALUES (24, 30, 5, 18, 993000, CAST(N'2023-03-20T16:22:57.083' AS DateTime), CAST(N'2023-03-20T16:22:57.083' AS DateTime))
INSERT [dbo].[OrderDetail] ([id], [product_id], [order_id], [amount], [payment_price], [create_at], [update_at]) VALUES (25, 27, 6, 13, 60000, CAST(N'2023-03-20T16:22:57.083' AS DateTime), CAST(N'2023-03-20T16:22:57.083' AS DateTime))
INSERT [dbo].[OrderDetail] ([id], [product_id], [order_id], [amount], [payment_price], [create_at], [update_at]) VALUES (26, 29, 6, 17, 203000, CAST(N'2023-03-20T16:22:57.083' AS DateTime), CAST(N'2023-03-20T16:22:57.083' AS DateTime))
INSERT [dbo].[OrderDetail] ([id], [product_id], [order_id], [amount], [payment_price], [create_at], [update_at]) VALUES (27, 8, 10, 2, 114000, CAST(N'2023-03-20T16:22:57.083' AS DateTime), CAST(N'2023-03-20T16:22:57.083' AS DateTime))
INSERT [dbo].[OrderDetail] ([id], [product_id], [order_id], [amount], [payment_price], [create_at], [update_at]) VALUES (28, 6, 10, 9, 952000, CAST(N'2023-03-20T16:22:57.083' AS DateTime), CAST(N'2023-03-20T16:22:57.083' AS DateTime))
INSERT [dbo].[OrderDetail] ([id], [product_id], [order_id], [amount], [payment_price], [create_at], [update_at]) VALUES (29, 4, 10, 1, 233000, CAST(N'2023-03-20T16:22:57.083' AS DateTime), CAST(N'2023-03-20T16:22:57.083' AS DateTime))
INSERT [dbo].[OrderDetail] ([id], [product_id], [order_id], [amount], [payment_price], [create_at], [update_at]) VALUES (30, 2, 10, 2, 956000, CAST(N'2023-03-20T16:22:57.083' AS DateTime), CAST(N'2023-03-20T16:22:57.083' AS DateTime))
INSERT [dbo].[OrderDetail] ([id], [product_id], [order_id], [amount], [payment_price], [create_at], [update_at]) VALUES (31, 50, 9, 16, 702000, CAST(N'2023-03-20T16:22:57.083' AS DateTime), CAST(N'2023-03-20T16:22:57.083' AS DateTime))
INSERT [dbo].[OrderDetail] ([id], [product_id], [order_id], [amount], [payment_price], [create_at], [update_at]) VALUES (32, 48, 9, 15, 255000, CAST(N'2023-03-20T16:22:57.083' AS DateTime), CAST(N'2023-03-20T16:22:57.083' AS DateTime))
INSERT [dbo].[OrderDetail] ([id], [product_id], [order_id], [amount], [payment_price], [create_at], [update_at]) VALUES (33, 46, 9, 20, 735000, CAST(N'2023-03-20T16:22:57.083' AS DateTime), CAST(N'2023-03-20T16:22:57.083' AS DateTime))
INSERT [dbo].[OrderDetail] ([id], [product_id], [order_id], [amount], [payment_price], [create_at], [update_at]) VALUES (34, 44, 9, 2, 228000, CAST(N'2023-03-20T16:22:57.083' AS DateTime), CAST(N'2023-03-20T16:22:57.083' AS DateTime))
INSERT [dbo].[OrderDetail] ([id], [product_id], [order_id], [amount], [payment_price], [create_at], [update_at]) VALUES (35, 42, 9, 10, 459000, CAST(N'2023-03-20T16:22:57.083' AS DateTime), CAST(N'2023-03-20T16:22:57.083' AS DateTime))
INSERT [dbo].[OrderDetail] ([id], [product_id], [order_id], [amount], [payment_price], [create_at], [update_at]) VALUES (36, 45, 8, 12, 867000, CAST(N'2023-03-20T16:22:57.083' AS DateTime), CAST(N'2023-03-20T16:22:57.083' AS DateTime))
INSERT [dbo].[OrderDetail] ([id], [product_id], [order_id], [amount], [payment_price], [create_at], [update_at]) VALUES (37, 4, 1, 5, 233000, CAST(N'2023-03-20T16:22:57.083' AS DateTime), CAST(N'2023-03-20T16:22:57.083' AS DateTime))
INSERT [dbo].[OrderDetail] ([id], [product_id], [order_id], [amount], [payment_price], [create_at], [update_at]) VALUES (38, 43, 8, 19, 649000, CAST(N'2023-03-20T16:22:57.083' AS DateTime), CAST(N'2023-03-20T16:22:57.083' AS DateTime))
INSERT [dbo].[OrderDetail] ([id], [product_id], [order_id], [amount], [payment_price], [create_at], [update_at]) VALUES (39, 39, 8, 19, 554000, CAST(N'2023-03-20T16:22:57.083' AS DateTime), CAST(N'2023-03-20T16:22:57.083' AS DateTime))
INSERT [dbo].[OrderDetail] ([id], [product_id], [order_id], [amount], [payment_price], [create_at], [update_at]) VALUES (40, 37, 8, 9, 769000, CAST(N'2023-03-20T16:22:57.083' AS DateTime), CAST(N'2023-03-20T16:22:57.083' AS DateTime))
INSERT [dbo].[OrderDetail] ([id], [product_id], [order_id], [amount], [payment_price], [create_at], [update_at]) VALUES (41, 40, 7, 13, 477000, CAST(N'2023-03-20T16:22:57.083' AS DateTime), CAST(N'2023-03-20T16:22:57.083' AS DateTime))
INSERT [dbo].[OrderDetail] ([id], [product_id], [order_id], [amount], [payment_price], [create_at], [update_at]) VALUES (42, 38, 7, 8, 526000, CAST(N'2023-03-20T16:22:57.083' AS DateTime), CAST(N'2023-03-20T16:22:57.083' AS DateTime))
INSERT [dbo].[OrderDetail] ([id], [product_id], [order_id], [amount], [payment_price], [create_at], [update_at]) VALUES (43, 36, 7, 5, 233000, CAST(N'2023-03-20T16:22:57.083' AS DateTime), CAST(N'2023-03-20T16:22:57.083' AS DateTime))
INSERT [dbo].[OrderDetail] ([id], [product_id], [order_id], [amount], [payment_price], [create_at], [update_at]) VALUES (44, 34, 7, 18, 959000, CAST(N'2023-03-20T16:22:57.083' AS DateTime), CAST(N'2023-03-20T16:22:57.083' AS DateTime))
INSERT [dbo].[OrderDetail] ([id], [product_id], [order_id], [amount], [payment_price], [create_at], [update_at]) VALUES (45, 32, 7, 16, 935000, CAST(N'2023-03-20T16:22:57.083' AS DateTime), CAST(N'2023-03-20T16:22:57.083' AS DateTime))
INSERT [dbo].[OrderDetail] ([id], [product_id], [order_id], [amount], [payment_price], [create_at], [update_at]) VALUES (46, 35, 6, 9, 974000, CAST(N'2023-03-20T16:22:57.083' AS DateTime), CAST(N'2023-03-20T16:22:57.083' AS DateTime))
INSERT [dbo].[OrderDetail] ([id], [product_id], [order_id], [amount], [payment_price], [create_at], [update_at]) VALUES (47, 33, 6, 17, 44000, CAST(N'2023-03-20T16:22:57.083' AS DateTime), CAST(N'2023-03-20T16:22:57.083' AS DateTime))
INSERT [dbo].[OrderDetail] ([id], [product_id], [order_id], [amount], [payment_price], [create_at], [update_at]) VALUES (48, 31, 6, 7, 781000, CAST(N'2023-03-20T16:22:57.083' AS DateTime), CAST(N'2023-03-20T16:22:57.083' AS DateTime))
INSERT [dbo].[OrderDetail] ([id], [product_id], [order_id], [amount], [payment_price], [create_at], [update_at]) VALUES (49, 41, 8, 9, 778000, CAST(N'2023-03-20T16:22:57.083' AS DateTime), CAST(N'2023-03-20T16:22:57.083' AS DateTime))
INSERT [dbo].[OrderDetail] ([id], [product_id], [order_id], [amount], [payment_price], [create_at], [update_at]) VALUES (50, 2, 1, 3, 956000, CAST(N'2023-03-20T16:22:57.083' AS DateTime), CAST(N'2023-03-20T16:22:57.083' AS DateTime))
SET IDENTITY_INSERT [dbo].[OrderDetail] OFF
GO
SET IDENTITY_INSERT [dbo].[Product] ON 

INSERT [dbo].[Product] ([id], [title], [description], [recent_price], [thumbnail], [amount], [category_id], [create_at], [update_at], [is_delete]) VALUES (1, N'Quạt nan treo tường', N' Gây ấn tượng với họa tiết được cách điệu từ nhân vật mang điệu múa dân tộc Chăm, chiếc quạt được trang trí mang đậm tính dân tộc', 88000, N'/images/products/quat-nan-treo-tuong.jpg', 876, 18, CAST(N'2020-11-19T00:00:00.000' AS DateTime), CAST(N'2023-03-20T16:22:56.760' AS DateTime), 0)
INSERT [dbo].[Product] ([id], [title], [description], [recent_price], [thumbnail], [amount], [category_id], [create_at], [update_at], [is_delete]) VALUES (2, N'Ghế đẩu', N'Ghế gỗ mang hình thức đẹp, trang nhã rất thích hợp dùng để trang trí.Sản phẩm có độ bền và chắc chắn, có tuổi thọ cao.Thể hiện được gu thẩm mỹ và phong cách cá nhân của người sử dụng.Rất tiện lợi vì độ gọn nhẹ và dễ dàng sử dụng ở bất kì đâu', 956000, N'/images/products/ghe-dau.jpg', 212, 16, CAST(N'2021-01-21T00:00:00.000' AS DateTime), CAST(N'2023-03-20T16:22:56.760' AS DateTime), 0)
INSERT [dbo].[Product] ([id], [title], [description], [recent_price], [thumbnail], [amount], [category_id], [create_at], [update_at], [is_delete]) VALUES (3, N'Bàn phấn', N'Bàn trang điểm hay còn với tên cái dân dã là bàn phấn. Đây không chỉ là món nội thất tạo điểm nhấn thu hút giúp không gian trở nên sang trọng và tinh tế hơn. Mà bàn trang điểm còn mang lại cho các nàng một góc làm đẹp hoàn hảo.', 673000, N'/images/products/ban-phan.jpg', 859, 1, CAST(N'2022-06-28T00:00:00.000' AS DateTime), CAST(N'2023-03-20T16:22:56.760' AS DateTime), 0)
INSERT [dbo].[Product] ([id], [title], [description], [recent_price], [thumbnail], [amount], [category_id], [create_at], [update_at], [is_delete]) VALUES (4, N'Kệ trang trí', N'Kệ trang trí đang là một xu hướng được yêu thích, thay thế cho những chiếc tủ cồng kềnh nhằm tiết kiệm diện tích không gian nhằm tối đa hóa nhu cầu sử dụng.', 233000, N'/images/products/ke-trang-tri.jpg', 311, 13, CAST(N'2021-10-10T00:00:00.000' AS DateTime), CAST(N'2023-03-20T16:22:56.760' AS DateTime), 0)
INSERT [dbo].[Product] ([id], [title], [description], [recent_price], [thumbnail], [amount], [category_id], [create_at], [update_at], [is_delete]) VALUES (5, N'Kệ sách', N'Kệ Sách Gỗ Trang Trí Để Sàn Cao Cấp với thiết kế mới lạ và vô cùng độc đáo mang vẻ đẹp hiện đại với nhiều tính năng vượt trội đáp ứng đầy đủ nhu cầu khách hàng. Sản phẩm được sử dụng trong trang trí phòng khách, phòng làm việc tại nhà và cả các văn phòng.', 217000, N'/images/products/ke-sach.jpg', 180, 13, CAST(N'2022-10-12T00:00:00.000' AS DateTime), CAST(N'2023-03-20T16:22:56.760' AS DateTime), 0)
INSERT [dbo].[Product] ([id], [title], [description], [recent_price], [thumbnail], [amount], [category_id], [create_at], [update_at], [is_delete]) VALUES (6, N'Ghế văn phòng', N'Đôi khi là những chiếc ghế chân quỳ sử dụng trong phòng họp. Ghế làm việc hiện đại thường sử dụng một chân chịu lực duy nhất bên dưới ghế.
Ghế văn phòng Hòa Phát là dòng sản phẩm ghế làm việc được thiết kế phù hợp với nhu cầu sử dụng của mọi người, chính vì thế ai cũng có thể sử dụng được, ngay cả khi bạn ngồi thư giản, ngồi làm việc đều có thể sử dụng được.', 952000, N'/images/products/ghe-van-phong.jpg', 20, 16, CAST(N'2020-09-18T00:00:00.000' AS DateTime), CAST(N'2023-03-20T16:22:56.760' AS DateTime), 0)
INSERT [dbo].[Product] ([id], [title], [description], [recent_price], [thumbnail], [amount], [category_id], [create_at], [update_at], [is_delete]) VALUES (7, N'Bàn làm việc', N'Bàn làm việc tại nhà là một đồ dùng nội thất cá nhân, là nơi bạn có thể làm việc với máy tính, đọc sách, làm báo cáo… ', 427000, N'/images/products/ban-lam-viec.jpg', 352, 1, CAST(N'2020-11-25T00:00:00.000' AS DateTime), CAST(N'2023-03-20T16:22:56.760' AS DateTime), 0)
INSERT [dbo].[Product] ([id], [title], [description], [recent_price], [thumbnail], [amount], [category_id], [create_at], [update_at], [is_delete]) VALUES (8, N'Tủ quần áo', N'Tủ quần áo âm tường không chỉ tiết kiệm diện tích mà còn có tính thẩm mỹ cao đem lại một phòng ngủ hiện đại, tinh tế nhưng không kém phần sang trọng.', 114000, N'/images/products/tu-quan-ao.jpg', 451, 14, CAST(N'2023-01-10T00:00:00.000' AS DateTime), CAST(N'2023-03-20T16:22:56.760' AS DateTime), 0)
INSERT [dbo].[Product] ([id], [title], [description], [recent_price], [thumbnail], [amount], [category_id], [create_at], [update_at], [is_delete]) VALUES (9, N'Ghế ăn', N'Ghế ăn giá rẻ được làm từ chất liệu gỗ tự nhiên, gỗ công nghiệp đang được khách hàng ưu tiên lựa chọn. Mỗi một loại gỗ lại có đặc điểm riêng thu hút khách hàng.', 440000, N'/images/products/ghe-an.jpg', 842, 16, CAST(N'2020-04-27T00:00:00.000' AS DateTime), CAST(N'2023-03-20T16:22:56.760' AS DateTime), 0)
INSERT [dbo].[Product] ([id], [title], [description], [recent_price], [thumbnail], [amount], [category_id], [create_at], [update_at], [is_delete]) VALUES (10, N'Bàn ăn', N'Bàn ăn cho gia đình người Việt có rất nhiều kiểu hình dáng khác nhau, và tùy theo không gian sống mà chúng ta có những lựa chọn kích thước bàn ăn tiêu chuẩn phù hợp nhất.', 377000, N'/images/products/ban-an.jpg', 102, 1, CAST(N'2021-05-15T00:00:00.000' AS DateTime), CAST(N'2023-03-20T16:22:56.760' AS DateTime), 0)
INSERT [dbo].[Product] ([id], [title], [description], [recent_price], [thumbnail], [amount], [category_id], [create_at], [update_at], [is_delete]) VALUES (11, N'Bàn trà', N'Bàn trà Hoa lê sản xuất đi theo phong cách hiện đại, đa dạng về mẫu mã dễ dàng phối hợp với bất kỳ mẫu ghế sofa hiện đại nào.Chất liệu chúng tôi sử dụng chủ yếu làm bàn trà.', 979000, N'/images/products/ban-tra.jpg', 21, 1, CAST(N'2020-11-29T00:00:00.000' AS DateTime), CAST(N'2023-03-20T16:22:56.760' AS DateTime), 0)
INSERT [dbo].[Product] ([id], [title], [description], [recent_price], [thumbnail], [amount], [category_id], [create_at], [update_at], [is_delete]) VALUES (12, N'Kệ tròn', N'Còn được gọi ụ tròn khuyến mãi – một sản phẩm được phân phối và sản xuất với mục đích trưng bày sản phẩm ở các cửa hàng, siêu thị. Tên gọi của kệ cũng bắt nguồn từ hình dáng đặc trưng với những mâm tròn xếp thành tầng.Cấu tạo của kệ siêu thị tròn cũng khá đơn giản, bao gồm mâm đáy, các mâm tầng hình tròn, cột trụ, và các phụ kiện đi kèm. Phần rào chắn bên ngoài sẽ giúp cho sản phẩm trưng bày không bị rơi, đồng thời tăng tính thẩm mỹ cho gian hàng.', 501000, N'/images/products/ke-tron.jpg', 813, 13, CAST(N'2022-07-30T00:00:00.000' AS DateTime), CAST(N'2023-03-20T16:22:56.760' AS DateTime), 0)
INSERT [dbo].[Product] ([id], [title], [description], [recent_price], [thumbnail], [amount], [category_id], [create_at], [update_at], [is_delete]) VALUES (13, N'Kệ Gỗ', N'Kết cấu kệ treo tường không giá đỡ (giấu chân âm kệ) rất chắn chắn và đẹp (không lộ phụ kiện ra ngoài).Gỗ công nghiệp HMR hay còn gọi là MDF lõi xanh chống ẩm. Bề mặt được phủ melamine có khả năng chống trầy xước, chịu nhiệt tốt và dễ dàng vệ sinh. Dễ dàng lắp ráp: Sản phẩm được gia công bằng CNC tự động, các vị trí liên kết đều có độ chuẩn xác nên rất dễ dàng trong quá trình lắp ráp sản phẩm.', 185000, N'/images/products/ke-go.jpg', 9, 13, CAST(N'2021-12-21T00:00:00.000' AS DateTime), CAST(N'2023-03-20T16:22:56.760' AS DateTime), 0)
INSERT [dbo].[Product] ([id], [title], [description], [recent_price], [thumbnail], [amount], [category_id], [create_at], [update_at], [is_delete]) VALUES (14, N'Kệ Kho Hàng', N'kệ kho hàng với các tải trọng khác nhau, giúp cho doanh nghiệp, khách hàng có thể lựa chọn thoải mái hơn: kệ trung tải, kệ selective, kệ drive in, kệ double deep, kệ pallet, kệ pallet trượt, kệ sàn…', 249000, N'/images/products/ke-kho-hang.jpg', 935, 13, CAST(N'2020-12-26T00:00:00.000' AS DateTime), CAST(N'2023-03-20T16:22:56.760' AS DateTime), 0)
INSERT [dbo].[Product] ([id], [title], [description], [recent_price], [thumbnail], [amount], [category_id], [create_at], [update_at], [is_delete]) VALUES (15, N'Tủ Tài Liệu', N'Tủ tài liệu sắt đã và đang trở thành nội thất không thể thiếu cho mọi không gian sinh hoạt, làm việc. Tủ sắt mang rất nhiều đặc điểm vượt trội dùng để lưu trữ tài liệu, thông tin của công ty và văn phòng. Hiện nay, có rất nhiều mẫu tủ sắt đựng tài liệu có mặt trên thị trường, mỗi thiết kế lại phù hợp với những không gian, nhiệm vụ khác nhau, làm thế nào để lựa chọn được mẫu tủ phù hợp với văn phòng, khiến nó có thể phát huy được ưu điểm vượt trội', 904000, N'/images/products/tu-tai-lieu.jpg', 966, 14, CAST(N'2023-03-02T00:00:00.000' AS DateTime), CAST(N'2023-03-20T16:22:56.760' AS DateTime), 0)
INSERT [dbo].[Product] ([id], [title], [description], [recent_price], [thumbnail], [amount], [category_id], [create_at], [update_at], [is_delete]) VALUES (16, N'Tủ 3 Ngăn', N'Kích thước: (Rộng 38cm x Sâu 45.5cm x Cao 81cm),Màu sắc: Nhiều màu,Thiết kế: 3 tầng, 3 ngăn kéo,', 209000, N'/images/products/tu-3-ngan.jpg', 141, 14, CAST(N'2022-06-18T00:00:00.000' AS DateTime), CAST(N'2023-03-20T16:22:56.760' AS DateTime), 0)
INSERT [dbo].[Product] ([id], [title], [description], [recent_price], [thumbnail], [amount], [category_id], [create_at], [update_at], [is_delete]) VALUES (17, N'Tủ tròn', N'Phong cách: đơn giản và hiện đại. Loại vật liệu: ABS. Please confirm that you can wait. Đây là sản phẩm đặt trước và mất khoảng 7-10 ngày để nhận hàng. Cảm ơn bạn. Shop chúng tôi bảo hành sản phẩm trong vòng 3 ngày kể từ ngày khách hàng nhận được sản phẩm. Shop sẽ đổi sản phẩm hoặc', 697000, N'/images/products/tu-tron.jpg', 454, 14, CAST(N'2023-02-09T00:00:00.000' AS DateTime), CAST(N'2023-03-20T16:22:56.760' AS DateTime), 0)
INSERT [dbo].[Product] ([id], [title], [description], [recent_price], [thumbnail], [amount], [category_id], [create_at], [update_at], [is_delete]) VALUES (18, N'Giường Gỗ', N'Sử dụng gỗ tự nhiên để thiết kế giường ngủ sẽ đem đến cho bạn sự chắc chắn, an toàn, tuổi thọ của giường cao. Ngoài ra, giường ngủ bằng gỗ tự nhiên có thể chạm trổ, điêu khắc nhiều kiểu kết hợp cùng các vân gỗ tạo nên sự sang trọng cho căn phòng. Tuy nhiên, sử dụng gỗ tự nhiên thì chi phí cao về vật liệu lẫn gia công.', 79000, N'/images/products/giuong-go.jpg', 568, 15, CAST(N'2022-01-14T00:00:00.000' AS DateTime), CAST(N'2023-03-20T16:22:56.760' AS DateTime), 0)
INSERT [dbo].[Product] ([id], [title], [description], [recent_price], [thumbnail], [amount], [category_id], [create_at], [update_at], [is_delete]) VALUES (19, N'Giường Đôi', N'Giường đôi là loại giường được sử dụng phổ biến nhất, dành cho nhiều đối tượng khác nhau, có chiều rộng khoảng từ 1,4m đến 2,2m và chiều dài khoảng 2m.Kích thước phổ biến của loại giường này là 1,8m2m được gọi là King size. Ngoài ra còn có giường đôi có kích thước 1,6m2m (Queen size) và 2m2m hay 2,2m2m (Super king size).', 333000, N'/images/products/giuong-doi.jpg', 123, 15, CAST(N'2022-08-29T00:00:00.000' AS DateTime), CAST(N'2023-03-20T16:22:56.760' AS DateTime), 0)
INSERT [dbo].[Product] ([id], [title], [description], [recent_price], [thumbnail], [amount], [category_id], [create_at], [update_at], [is_delete]) VALUES (20, N'Giường tròn', N'Là siêu phẫm mang hơi hướng Tây hóa vào thị trường Việt Nam từ nhiều năm nay,hình dáng bên ngoài đẹp, bắt mắt. Nó có nhiều mẫu mã ấn tượng, giường tròn có kết cấu tròn đều,có vài mẫu có kiểu giật nút bắt mắt, nệm bên trong cao 10 phân hay 20 phân tùy theo sở thích gia chủ.', 491000, N'/images/products/giuong-tron.jpg', 305, 15, CAST(N'2021-08-16T00:00:00.000' AS DateTime), CAST(N'2023-03-20T16:22:56.760' AS DateTime), 0)
INSERT [dbo].[Product] ([id], [title], [description], [recent_price], [thumbnail], [amount], [category_id], [create_at], [update_at], [is_delete]) VALUES (21, N'Ghế sofa', N'Khung gỗ sử dụng thường xuyên nhất đối với các bộ ghế sofa. Cấu tạo khung ghế sofa khá đơn giản. Chúng bao gồm các thanh gỗ được kết nối với nhau. Tạo thành hệ thống trợ lực nâng đỡ cho nhau. Đảm bảo lực được phân tán đều lên các thanh chịu lực. Tránh hiện tượng bị gãy khung khi sử dụng. Với ghế sofa sử dụng khung gỗ thông thường có thể chịu được từ 5-7 người sử dụng cùng lúc hoặc có thể hơn. Tương ứng với trọng lượng người sử dụng từ 350-400kg.', 81000, N'/images/products/ghe-sofa.jpg', 906, 16, CAST(N'2022-09-27T00:00:00.000' AS DateTime), CAST(N'2023-03-20T16:22:56.760' AS DateTime), 0)
INSERT [dbo].[Product] ([id], [title], [description], [recent_price], [thumbnail], [amount], [category_id], [create_at], [update_at], [is_delete]) VALUES (22, N'Ghế 3 chân', N'Ghế gỗ tròn gồm có 3 chân nên tạo sự chắc chắn và mạnh mẽ trong từng góc nhìn.Thiết kế cao phù hợp ngồi tại quầy bar, rượu.Ghế 3 chân gỗ có màu nâu gỗ đi cùng với vàng/đỏ ở các chi tiết mặt ghế và chân ghế giúp nổi bật. Thiết kế đơn giản, gọn nhẹ dễ di chuyển và xếp gọn. Mặt ghế ngồi hình tròn bằng nhựa cứng được uốn cong bo xuống tạo thiết kế mềm mại.', 30000, N'/images/products/ghe-3-chan.jpg', 224, 16, CAST(N'2022-12-29T00:00:00.000' AS DateTime), CAST(N'2023-03-20T16:22:56.760' AS DateTime), 0)
INSERT [dbo].[Product] ([id], [title], [description], [recent_price], [thumbnail], [amount], [category_id], [create_at], [update_at], [is_delete]) VALUES (23, N'Ghế tròn', N'Kích thước: Cao 55 cm; mặt ghế tròn đường kính 32 cm . Đặc điểm:  + Mặt ghế được tạo hình bằng máy ép thuỷ lực 250 tấn, đường nét sắc sảo, chắc chắn. Có sần chống trơn trượt. Trên mặt dập logo “Inox Nam Việt”. Chân ghế tròn phi 19, sử dụng máy uốn chuyên dụng, nhanh, đẹp, chính xác.Dưới mặt ghế có đệm cao su giúp ghế không bị lõm sau một thời gian sử dụng, không phát ra tiếng kêu khi ngồi như các loại ghế thông thường trên thị trường.Các mối hàn được thực hiện bằng công nghệ hàn TIG có khí Ar bảo vệ chống oxi hóa.', 387000, N'/images/products/ghe-tron.jpg', 478, 16, CAST(N'2020-04-07T00:00:00.000' AS DateTime), CAST(N'2023-03-20T16:22:56.760' AS DateTime), 0)
INSERT [dbo].[Product] ([id], [title], [description], [recent_price], [thumbnail], [amount], [category_id], [create_at], [update_at], [is_delete]) VALUES (24, N'Bàn Nhựa', N'Kích thước: Dài x Rộng x Cao (120 x 60 x 48/52)cm, Màu sắc: Đỏ, vàng, xanh lá và xanh dương , Chất liệu: Nhựa PP + sắt sơn tĩnh điện chắc chắn, bền đẹp, không phai màu…', 883000, N'/images/products/ban-nhua.jpg', 578, 1, CAST(N'2021-08-16T00:00:00.000' AS DateTime), CAST(N'2023-03-20T16:22:56.760' AS DateTime), 0)
INSERT [dbo].[Product] ([id], [title], [description], [recent_price], [thumbnail], [amount], [category_id], [create_at], [update_at], [is_delete]) VALUES (25, N'Bàn cafe', N'bàn Cafe chân sắt với mặt bàn tròn hoặc vuông kích thước từ 60-80cm đa dạng chất liệu mặt bàn như mặt bàn gỗ tre, gỗ me tây nguyên tấm, gỗ cao su,', 985000, N'/images/products/ban-cafe.jpg', 229, 1, CAST(N'2021-07-10T00:00:00.000' AS DateTime), CAST(N'2023-03-20T16:22:56.760' AS DateTime), 0)
INSERT [dbo].[Product] ([id], [title], [description], [recent_price], [thumbnail], [amount], [category_id], [create_at], [update_at], [is_delete]) VALUES (26, N'Đèn bàn', N'Đèn bàn RD-RL-60 sử dụng chip LED SunLike ánh sáng tương tự ánh sáng mặt trời kết hợp chậu cây tô điểm cho căn phòng, tăng hiệu quả học tập, làm việc.', 221000, N'/images/products/den-ban.jpg', 219, 1, CAST(N'2021-08-20T00:00:00.000' AS DateTime), CAST(N'2023-03-20T16:22:56.760' AS DateTime), 0)
INSERT [dbo].[Product] ([id], [title], [description], [recent_price], [thumbnail], [amount], [category_id], [create_at], [update_at], [is_delete]) VALUES (27, N'đèn trần', N'Đèn trần phòng khách hiện đại 3 màu độc đáo kết hợp công nghệ Led tiết kiêm điện năng và ý tưởng mới lạ của nghệ nhân đèn đã tạo nên tác phẩm xuất sắc.
', 60000, N'/images/products/den-tran.jpg', 993, 12, CAST(N'2023-02-02T00:00:00.000' AS DateTime), CAST(N'2023-03-20T16:22:56.760' AS DateTime), 0)
INSERT [dbo].[Product] ([id], [title], [description], [recent_price], [thumbnail], [amount], [category_id], [create_at], [update_at], [is_delete]) VALUES (28, N'rèm cửa', N'Rèm cửa phòng khách là 1 loại phụ kiện quan trọng để hoàn thiện đồ nội thất trong phòng cũng như tạo ra một loại tâm trạng tích cực và không khí vui tươi.
', 334000, N'/images/products/rem-cua.jpg', 236, 11, CAST(N'2020-08-27T00:00:00.000' AS DateTime), CAST(N'2023-03-20T16:22:56.760' AS DateTime), 0)
INSERT [dbo].[Product] ([id], [title], [description], [recent_price], [thumbnail], [amount], [category_id], [create_at], [update_at], [is_delete]) VALUES (29, N'Quạt vải treo tường', N' Gây ấn tượng với họa tiết được cách điệu từ nhân vật mang điệu múa dân tộc Chăm, chiếc quạt được trang trí mang đậm tính dân tộc', 203000, N'/images/products/quat-vai-treo-tuong.jpg', 358, 18, CAST(N'2021-12-07T00:00:00.000' AS DateTime), CAST(N'2023-03-20T16:22:56.760' AS DateTime), 0)
INSERT [dbo].[Product] ([id], [title], [description], [recent_price], [thumbnail], [amount], [category_id], [create_at], [update_at], [is_delete]) VALUES (30, N'Đĩa trang trí vẽ hoa cúc', N'Mẫu đĩa sứ trang trí này không chỉ đẹp, độc đáo, mang giá trị cao về mặt thẩm mĩ mà còn có ý nghĩa giúp giữ gìn và lưu truyền văn hóa dân tộc', 993000, N'/images/products/dia-su-trang-tri-gia-co-ve-hoa-cuc.jpg', 466, 17, CAST(N'2022-03-15T00:00:00.000' AS DateTime), CAST(N'2023-03-20T16:22:56.760' AS DateTime), 0)
INSERT [dbo].[Product] ([id], [title], [description], [recent_price], [thumbnail], [amount], [category_id], [create_at], [update_at], [is_delete]) VALUES (31, N'Đĩa trang trí hình chim công', N'Mẫu đĩa sứ trang trí này không chỉ đẹp, độc đáo, mang giá trị cao về mặt thẩm mĩ mà còn có ý nghĩa giúp giữ gìn và lưu truyền văn hóa dân tộc', 781000, N'/images/products/dia-chim-cong.jpg', 284, 17, CAST(N'2023-03-10T00:00:00.000' AS DateTime), CAST(N'2023-03-20T16:22:56.760' AS DateTime), 0)
INSERT [dbo].[Product] ([id], [title], [description], [recent_price], [thumbnail], [amount], [category_id], [create_at], [update_at], [is_delete]) VALUES (32, N'Đĩa trang trí', N'Mẫu đĩa sứ trang trí này không chỉ đẹp, độc đáo, mang giá trị cao về mặt thẩm mĩ mà còn có ý nghĩa giúp giữ gìn và lưu truyền văn hóa dân tộc', 935000, N'/images/products/dia-trang-tri.jpg', 174, 17, CAST(N'2022-12-16T00:00:00.000' AS DateTime), CAST(N'2023-03-20T16:22:56.760' AS DateTime), 0)
INSERT [dbo].[Product] ([id], [title], [description], [recent_price], [thumbnail], [amount], [category_id], [create_at], [update_at], [is_delete]) VALUES (33, N'Ly sứ trang trí', N'Chiếc Ly Đơn Giản/Tinh Tế,', 44000, N'/images/products/ly-su-trang-tri.jpg', 1, 2, CAST(N'2020-10-05T00:00:00.000' AS DateTime), CAST(N'2023-03-20T16:22:56.760' AS DateTime), 0)
INSERT [dbo].[Product] ([id], [title], [description], [recent_price], [thumbnail], [amount], [category_id], [create_at], [update_at], [is_delete]) VALUES (34, N'Ly trang trí', N'Chiếc Ly Đơn Giản/Tinh Tế,', 959000, N'/images/products/ly-trang-tri.jpg', 573, 2, CAST(N'2020-01-22T00:00:00.000' AS DateTime), CAST(N'2023-03-20T16:22:56.760' AS DateTime), 0)
INSERT [dbo].[Product] ([id], [title], [description], [recent_price], [thumbnail], [amount], [category_id], [create_at], [update_at], [is_delete]) VALUES (35, N'Đồng hồ treo tường con thuyền', N'Ý nghĩa đồng hồ trang trí . Mỗi đồn hồ mang ý nghĩa khác nhau , mang đến không gian thêm đẹp , mang sự may mắn hạnh phúc . và hợp không gian.', 974000, N'/images/products/dong-ho-treo-tuong-con-thuyen.jpg', 479, 3, CAST(N'2020-04-06T00:00:00.000' AS DateTime), CAST(N'2023-03-20T16:22:56.760' AS DateTime), 0)
INSERT [dbo].[Product] ([id], [title], [description], [recent_price], [thumbnail], [amount], [category_id], [create_at], [update_at], [is_delete]) VALUES (36, N'Đồng hồ treo tường 3d', N'Ý nghĩa đồng hồ trang trí . Mỗi đồn hồ mang ý nghĩa khác nhau , mang đến không gian thêm đẹp , mang sự may mắn hạnh phúc . và hợp không gian.', 233000, N'/images/products/dong-ho-treo-tuong-3d.jpg', 603, 3, CAST(N'2023-01-25T00:00:00.000' AS DateTime), CAST(N'2023-03-20T16:22:56.760' AS DateTime), 0)
INSERT [dbo].[Product] ([id], [title], [description], [recent_price], [thumbnail], [amount], [category_id], [create_at], [update_at], [is_delete]) VALUES (37, N'Đồng hồ treo tường decor vườn chim', N'Ý nghĩa đồng hồ trang trí . Mỗi đồn hồ mang ý nghĩa khác nhau , mang đến không gian thêm đẹp , mang sự may mắn hạnh phúc . và hợp không gian.', 769000, N'/images/products/dong-ho-treo-tuong-decor-vuon-chim.jpg', 173, 3, CAST(N'2020-02-15T00:00:00.000' AS DateTime), CAST(N'2023-03-20T16:22:56.760' AS DateTime), 0)
INSERT [dbo].[Product] ([id], [title], [description], [recent_price], [thumbnail], [amount], [category_id], [create_at], [update_at], [is_delete]) VALUES (38, N'Đồng hồ trang trí giọt nước', N'Ý nghĩa đồng hồ trang trí . Mỗi đồn hồ mang ý nghĩa khác nhau , mang đến không gian thêm đẹp , mang sự may mắn hạnh phúc . và hợp không gian.', 526000, N'/images/products/dong-ho-trang-tri-giot-nuoc.jpg', 884, 3, CAST(N'2023-02-07T00:00:00.000' AS DateTime), CAST(N'2023-03-20T16:22:56.760' AS DateTime), 0)
INSERT [dbo].[Product] ([id], [title], [description], [recent_price], [thumbnail], [amount], [category_id], [create_at], [update_at], [is_delete]) VALUES (39, N'Hồ cá xi măng', N' Không gian xanh ngoài trời của gia đình bạn sẽ tăng thêm vẻ đẹp khi có thêm sự xuất hiện của bể cá xi măng. Thiết kế này sẽ giúp khu vườn trông ...', 554000, N'/images/products/ho-ca-xi-mang.jpg', 476, 4, CAST(N'2022-05-14T00:00:00.000' AS DateTime), CAST(N'2023-03-20T16:22:56.760' AS DateTime), 0)
INSERT [dbo].[Product] ([id], [title], [description], [recent_price], [thumbnail], [amount], [category_id], [create_at], [update_at], [is_delete]) VALUES (40, N'Bàn chữ Z', N'Kích thước bàn: Dài = 120cm ; Rộng = 60cm ; Cao = 75cm.Mặt bàn: Được làm bằng gỗ MDF cao cấp có độ dày 17 li. Mặt bàn phue melamine chống thấm, chống xước và có độ bền đẹp cao.Khung bàn: Được làm bằng sắt có kết cấu chắc chắn. Bên ngoài được sơn phủ bởi lớp sơn tĩnh điện có thẩm mỹ cực cao. Sơn tĩnh điện chống xước, chống han rỉ. Lớp sơn bảo vệ cho khung sắt có độ bền len tới 10 năm.Bàn được đóng hộp carton dày 8 lii chắc chắn và chuyên nghiệp', 477000, N'/images/products/ban-chu-z.jpg', 727, 1, CAST(N'2021-03-03T00:00:00.000' AS DateTime), CAST(N'2023-03-20T16:22:56.760' AS DateTime), 0)
INSERT [dbo].[Product] ([id], [title], [description], [recent_price], [thumbnail], [amount], [category_id], [create_at], [update_at], [is_delete]) VALUES (41, N'Hồ cá thủy sinh', N' Bể cá thủy sinh luôn mang đến cho mỗi người chúng ta một cảm giác rất đặc biệt về tâm lý và thị giác. Một không gian xanh, tươi mới', 778000, N'/images/products/ho-ca-thuy-sinh.jpg', 15, 4, CAST(N'2022-10-18T00:00:00.000' AS DateTime), CAST(N'2023-03-20T16:22:56.760' AS DateTime), 0)
INSERT [dbo].[Product] ([id], [title], [description], [recent_price], [thumbnail], [amount], [category_id], [create_at], [update_at], [is_delete]) VALUES (42, N'Bình rượu vang', N'Rượu vang là một thức uống có cồn làm từ nho lên men . Nấm men tiêu thụ đường trong nho và chuyển đổi nó thành ethanol , carbon dioxide và nhiệt. Các giống nho và chủng nấm men khác nhau tạo ra các kiểu rượu khác nhau. Những biến thể này là kết quả của sự tương tác phức tạp giữa sự phát triển sinh hóa của nho, các phản ứng liên quan đến quá trình lên men, terroir và quá trình sản xuất. Nhiều quốc gia ban hành tên gọi pháp lý nhằm xác định phong cách và chất lượng của rượu vang', 459000, N'/images/products/binh-ruou-vang.jpg', 664, 6, CAST(N'2020-12-10T00:00:00.000' AS DateTime), CAST(N'2023-03-20T16:22:56.760' AS DateTime), 0)
INSERT [dbo].[Product] ([id], [title], [description], [recent_price], [thumbnail], [amount], [category_id], [create_at], [update_at], [is_delete]) VALUES (43, N'Bình rượu ngâm trang trí', N'Màu sắc trang trí họa tiết trên bình ngâm rượu thường đơn giản, không lòe loẹt, nhưng vô cùng bắt mắt và tinh sảo. Cấu tạo bên trong và bên ngoài của bình ngâm', 649000, N'/images/products/binh-ruou-ngam-trang-tri.jpg', 449, 6, CAST(N'2021-06-08T00:00:00.000' AS DateTime), CAST(N'2023-03-20T16:22:56.760' AS DateTime), 0)
INSERT [dbo].[Product] ([id], [title], [description], [recent_price], [thumbnail], [amount], [category_id], [create_at], [update_at], [is_delete]) VALUES (44, N'Giấy dán tường đen nhám', N'Giấy dán tường là vật liệu dùng để trang trí nội thất. Nó có cấu tạo bề mặt dưới là giấy và ở mặt trên là nhựa. Mặt trên được in các hoa văn hoa tiết đầy đủ màu', 228000, N'/images/products/giay-dan-tuong-den-nham.jpg', 914, 7, CAST(N'2020-01-04T00:00:00.000' AS DateTime), CAST(N'2023-03-20T16:22:56.760' AS DateTime), 0)
INSERT [dbo].[Product] ([id], [title], [description], [recent_price], [thumbnail], [amount], [category_id], [create_at], [update_at], [is_delete]) VALUES (45, N'Giấy dán tường giả gạch', N'Giấy dán tường là vật liệu dùng để trang trí nội thất. Nó có cấu tạo bề mặt dưới là giấy và ở mặt trên là nhựa. Mặt trên được in các hoa văn hoa tiết đầy đủ màu', 867000, N'/images/products/giay-dan-tuong-gia-gach.jpg', 71, 7, CAST(N'2022-10-09T00:00:00.000' AS DateTime), CAST(N'2023-03-20T16:22:56.760' AS DateTime), 0)
INSERT [dbo].[Product] ([id], [title], [description], [recent_price], [thumbnail], [amount], [category_id], [create_at], [update_at], [is_delete]) VALUES (46, N'Giấy dán tường retro', N'Giấy dán tường là vật liệu dùng để trang trí nội thất. Nó có cấu tạo bề mặt dưới là giấy và ở mặt trên là nhựa. Mặt trên được in các hoa văn hoa tiết đầy đủ màu', 735000, N'/images/products/giay-dan-tuong-retro.jpg', 353, 7, CAST(N'2022-07-30T00:00:00.000' AS DateTime), CAST(N'2023-03-20T16:22:56.760' AS DateTime), 0)
INSERT [dbo].[Product] ([id], [title], [description], [recent_price], [thumbnail], [amount], [category_id], [create_at], [update_at], [is_delete]) VALUES (47, N'Bình hoa thủy tinh', N'Bình thủy tinh họa tiết trái cây với chất liệu chính là thủy tinh borosilicate và nhựa ABS an toàn cho sức khỏe. Chiều cao 20cm. Đường kính 6,5cm.', 591000, N'/images/products/binh-thuy-tinh.jpg', 216, 8, CAST(N'2021-08-07T00:00:00.000' AS DateTime), CAST(N'2023-03-20T16:22:56.760' AS DateTime), 0)
INSERT [dbo].[Product] ([id], [title], [description], [recent_price], [thumbnail], [amount], [category_id], [create_at], [update_at], [is_delete]) VALUES (48, N'Bình hoa vẽ tay', N'Bình hoa gốm Bát Tràng cao cấp cắm hoa vẽ tay thủ công trên nền men mộc vintage trang trí phòng khách đẹp Mộc Gốm MG78', 255000, N'/images/products/binh-hoa-ve-tay.jpg', 114, 8, CAST(N'2021-07-07T00:00:00.000' AS DateTime), CAST(N'2023-03-20T16:22:56.760' AS DateTime), 0)
INSERT [dbo].[Product] ([id], [title], [description], [recent_price], [thumbnail], [amount], [category_id], [create_at], [update_at], [is_delete]) VALUES (49, N'gương treo tường', N'Mang kiểu dáng và hơi thở của nội thất châu Âu, gương tròn treo tường hoa hướng dương cổ điển được thiết kế tỉ mỉ, tinh tế đến từng chi tiết.', 970000, N'/images/products/guong-treo-tuong.jpg', 785, 9, CAST(N'2020-01-03T00:00:00.000' AS DateTime), CAST(N'2023-03-20T16:22:56.760' AS DateTime), 0)
INSERT [dbo].[Product] ([id], [title], [description], [recent_price], [thumbnail], [amount], [category_id], [create_at], [update_at], [is_delete]) VALUES (50, N'gương tròn nghệ thuật', N'Một nhà thiết kế lừng danh đã từng nói: “Không có đường biên giới hạn cho sáng tạo nghệ thuật”. Có lẽ bởi tinh thần ấy, mà trong ngành thiết kế nội thất, những mẫu mã sản phẩm luôn có sự vận động, thay đổi không ngừng. Đã qua rồi cách tư duy rập khuôn theo chức năng như gương chỉ để soi, bình chỉ để cắm hoa,… Giờ đây, bất cứ vật phẩm gì trong không gian nội thất cũng được truyền tải nét đẹp thẩm mỹ từ sáng tạo nghệ thuật. Trong bài viết này, chúng tôi muốn giới thiệu đến bạn đọc một sản phẩm như vậy. Đó chính là thiết kế gương nghệ thuật hình tròn – hội tụ tinh hoa của sáng tạo.', 702000, N'/images/products/guong-tron-nghe-thuat.jpg', 942, 9, CAST(N'2021-09-14T00:00:00.000' AS DateTime), CAST(N'2023-03-20T16:22:56.760' AS DateTime), 0)
INSERT [dbo].[Product] ([id], [title], [description], [recent_price], [thumbnail], [amount], [category_id], [create_at], [update_at], [is_delete]) VALUES (51, N'gương tròn', N'Mang kiểu dáng và hơi thở của nội thất châu Âu, gương tròn treo tường hoa hướng dương cổ điển được thiết kế tỉ mỉ, tinh tế đến từng chi tiết.', 119000, N'/images/products/guong-tron.jpg', 105, 9, CAST(N'2021-06-24T00:00:00.000' AS DateTime), CAST(N'2023-03-20T16:22:56.760' AS DateTime), 0)
INSERT [dbo].[Product] ([id], [title], [description], [recent_price], [thumbnail], [amount], [category_id], [create_at], [update_at], [is_delete]) VALUES (52, N'thảm trải sàn', N'Thảm rối đa hoạ tiết đặc biệt chỉ có kích thước 40x60(cm) nên thảm thích hợp đặt trước cửa nhà riêng, căn hộ, văn phòng, phòng riêng, nhà vệ sinh, phòng tắm,', 203000, N'/images/products/tham-trai-san.jpg', 673, 10, CAST(N'2021-10-10T00:00:00.000' AS DateTime), CAST(N'2023-03-20T16:22:56.760' AS DateTime), 0)
INSERT [dbo].[Product] ([id], [title], [description], [recent_price], [thumbnail], [amount], [category_id], [create_at], [update_at], [is_delete]) VALUES (53, N'Hồ cá mini', N'Nuôi cá cảnh mini với số lượng vừa đủ. Hồ cá mini nhỏ nên bạn chỉ nuôi vài con, tránh tình trạng cá chết do thiếu oxy và không đủ không gian bơi lội.', 988000, N'/images/products/ho-ca-mini.jpg', 52, 4, CAST(N'2020-03-25T00:00:00.000' AS DateTime), CAST(N'2023-03-20T16:22:56.760' AS DateTime), 0)
INSERT [dbo].[Product] ([id], [title], [description], [recent_price], [thumbnail], [amount], [category_id], [create_at], [update_at], [is_delete]) VALUES (54, N'Bàn tròn', N'Chiều cao bàn ăn tiêu chuẩn thường nhất quán (trung từ 71 – 76cm), Nhưng quý vị cần cân nhắc khoảng cách khi chúng ta kéo ghế ra ngồi ăn cơm. Đủ không gian cho mọi người ngồi vừa và bắt chéo chân, không quá cao gây cảm giác vướng, khó chịu. Nói chung, khoảng cách từ ghế và bàn ăn cách khoảng 30cm.', 408000, N'/images/products/ban-tron.jpg', 513, 1, CAST(N'2021-09-29T00:00:00.000' AS DateTime), CAST(N'2023-03-20T16:22:56.760' AS DateTime), 0)
SET IDENTITY_INSERT [dbo].[Product] OFF
GO
SET IDENTITY_INSERT [dbo].[Role] ON 

INSERT [dbo].[Role] ([id], [description]) VALUES (1, N'Admin')
INSERT [dbo].[Role] ([id], [description]) VALUES (2, N'Customer')
SET IDENTITY_INSERT [dbo].[Role] OFF
GO
SET IDENTITY_INSERT [dbo].[Status] ON 

INSERT [dbo].[Status] ([id], [title], [create_at], [update_at]) VALUES (1, N'Đã đặt đơn hàng', CAST(N'2023-03-20T16:22:56.927' AS DateTime), CAST(N'2023-03-20T16:22:56.927' AS DateTime))
INSERT [dbo].[Status] ([id], [title], [create_at], [update_at]) VALUES (2, N'Đang giao hàng', CAST(N'2023-03-20T16:22:56.927' AS DateTime), CAST(N'2023-03-20T16:22:56.927' AS DateTime))
INSERT [dbo].[Status] ([id], [title], [create_at], [update_at]) VALUES (3, N'Đã nhận hàng', CAST(N'2023-03-20T16:22:56.927' AS DateTime), CAST(N'2023-03-20T16:22:56.927' AS DateTime))
INSERT [dbo].[Status] ([id], [title], [create_at], [update_at]) VALUES (4, N'Đã huỷ đơn hàng', CAST(N'2023-03-20T16:22:56.927' AS DateTime), CAST(N'2023-03-20T16:22:56.927' AS DateTime))
SET IDENTITY_INSERT [dbo].[Status] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([id], [email], [password], [full_name], [phone], [address], [role_id], [create_at], [update_at], [is_delete], [EmailConfirmed], [EmailConfirmationToken], [EmailConfirmationSentAt], [IsPasswordResetRequired], [ResetPasswordToken], [ResetPasswordSentAt]) VALUES (1, N'Admin@gmail.com', N'1376c6cb014c2157d7dff060b756c812', N'', N'', N'', 1, CAST(N'2023-03-20T16:22:56.530' AS DateTime), CAST(N'2023-03-20T16:22:56.530' AS DateTime), 0, 1, N'', NULL, 0, N'', NULL)
INSERT [dbo].[User] ([id], [email], [password], [full_name], [phone], [address], [role_id], [create_at], [update_at], [is_delete], [EmailConfirmed], [EmailConfirmationToken], [EmailConfirmationSentAt], [IsPasswordResetRequired], [ResetPasswordToken], [ResetPasswordSentAt]) VALUES (2, N'Customer18@gmail.com', N'51d04a7b3c352b9468a29eb7deb1341e', N'Customer 18', N'07882231836', N'Bình Phước', 2, CAST(N'2023-03-20T16:22:56.617' AS DateTime), CAST(N'2023-03-20T16:22:56.617' AS DateTime), 0, 1, N'', NULL, 0, N'', NULL)
INSERT [dbo].[User] ([id], [email], [password], [full_name], [phone], [address], [role_id], [create_at], [update_at], [is_delete], [EmailConfirmed], [EmailConfirmationToken], [EmailConfirmationSentAt], [IsPasswordResetRequired], [ResetPasswordToken], [ResetPasswordSentAt]) VALUES (3, N'Customer35@gmail.com', N'769a5c7898f04a07e6d8ec0a45e58e0a', N'Customer 35', N'07882233570', N'Khánh Hòa', 2, CAST(N'2023-03-20T16:22:56.617' AS DateTime), CAST(N'2023-03-20T16:22:56.617' AS DateTime), 0, 1, N'', NULL, 0, N'', NULL)
INSERT [dbo].[User] ([id], [email], [password], [full_name], [phone], [address], [role_id], [create_at], [update_at], [is_delete], [EmailConfirmed], [EmailConfirmationToken], [EmailConfirmationSentAt], [IsPasswordResetRequired], [ResetPasswordToken], [ResetPasswordSentAt]) VALUES (4, N'Customer36@gmail.com', N'f4160b06595ca470800b49a8e874d1cd', N'Customer 36', N'07882233672', N'Kiên Giang', 2, CAST(N'2023-03-20T16:22:56.617' AS DateTime), CAST(N'2023-03-20T16:22:56.617' AS DateTime), 0, 1, N'', NULL, 0, N'', NULL)
INSERT [dbo].[User] ([id], [email], [password], [full_name], [phone], [address], [role_id], [create_at], [update_at], [is_delete], [EmailConfirmed], [EmailConfirmationToken], [EmailConfirmationSentAt], [IsPasswordResetRequired], [ResetPasswordToken], [ResetPasswordSentAt]) VALUES (5, N'Customer37@gmail.com', N'e722f630e719f7939723f4e0797ee697', N'Customer 37', N'07882233774', N'Kon Tum', 2, CAST(N'2023-03-20T16:22:56.617' AS DateTime), CAST(N'2023-03-20T16:22:56.617' AS DateTime), 0, 1, N'', NULL, 0, N'', NULL)
INSERT [dbo].[User] ([id], [email], [password], [full_name], [phone], [address], [role_id], [create_at], [update_at], [is_delete], [EmailConfirmed], [EmailConfirmationToken], [EmailConfirmationSentAt], [IsPasswordResetRequired], [ResetPasswordToken], [ResetPasswordSentAt]) VALUES (6, N'Customer38@gmail.com', N'9730b4905f0e12ad6fbbf34abee823bb', N'Customer 38', N'07882233876', N'Lai Châu', 2, CAST(N'2023-03-20T16:22:56.617' AS DateTime), CAST(N'2023-03-20T16:22:56.617' AS DateTime), 0, 1, N'', NULL, 0, N'', NULL)
INSERT [dbo].[User] ([id], [email], [password], [full_name], [phone], [address], [role_id], [create_at], [update_at], [is_delete], [EmailConfirmed], [EmailConfirmationToken], [EmailConfirmationSentAt], [IsPasswordResetRequired], [ResetPasswordToken], [ResetPasswordSentAt]) VALUES (7, N'Customer39@gmail.com', N'fdace71c0e17ba8d9326f47ebeb974fb', N'Customer 39', N'07882233978', N'Lâm Đồng', 2, CAST(N'2023-03-20T16:22:56.617' AS DateTime), CAST(N'2023-03-20T16:22:56.617' AS DateTime), 0, 1, N'', NULL, 0, N'', NULL)
INSERT [dbo].[User] ([id], [email], [password], [full_name], [phone], [address], [role_id], [create_at], [update_at], [is_delete], [EmailConfirmed], [EmailConfirmationToken], [EmailConfirmationSentAt], [IsPasswordResetRequired], [ResetPasswordToken], [ResetPasswordSentAt]) VALUES (8, N'Customer40@gmail.com', N'2dc0fbc05a2ffb6c7cf5ecb3a93385c2', N'Customer 40', N'07882234080', N'Lạng Sơn', 2, CAST(N'2023-03-20T16:22:56.617' AS DateTime), CAST(N'2023-03-20T16:22:56.617' AS DateTime), 0, 1, N'', NULL, 0, N'', NULL)
INSERT [dbo].[User] ([id], [email], [password], [full_name], [phone], [address], [role_id], [create_at], [update_at], [is_delete], [EmailConfirmed], [EmailConfirmationToken], [EmailConfirmationSentAt], [IsPasswordResetRequired], [ResetPasswordToken], [ResetPasswordSentAt]) VALUES (9, N'Customer41@gmail.com', N'626265b63b2b73b8ba93227b1454b233', N'Customer 41', N'07882234182', N'Lào Cai', 2, CAST(N'2023-03-20T16:22:56.617' AS DateTime), CAST(N'2023-03-20T16:22:56.617' AS DateTime), 0, 1, N'', NULL, 0, N'', NULL)
INSERT [dbo].[User] ([id], [email], [password], [full_name], [phone], [address], [role_id], [create_at], [update_at], [is_delete], [EmailConfirmed], [EmailConfirmationToken], [EmailConfirmationSentAt], [IsPasswordResetRequired], [ResetPasswordToken], [ResetPasswordSentAt]) VALUES (10, N'Customer42@gmail.com', N'b776bb2dd71284d142c7422aff2fc0c3', N'Customer 42', N'07882234284', N'Long An', 2, CAST(N'2023-03-20T16:22:56.617' AS DateTime), CAST(N'2023-03-20T16:22:56.617' AS DateTime), 0, 1, N'', NULL, 0, N'', NULL)
INSERT [dbo].[User] ([id], [email], [password], [full_name], [phone], [address], [role_id], [create_at], [update_at], [is_delete], [EmailConfirmed], [EmailConfirmationToken], [EmailConfirmationSentAt], [IsPasswordResetRequired], [ResetPasswordToken], [ResetPasswordSentAt]) VALUES (11, N'Customer43@gmail.com', N'6c26f625502cfee7390728cd6169917c', N'Customer 43', N'07882234386', N'Nam Định', 2, CAST(N'2023-03-20T16:22:56.617' AS DateTime), CAST(N'2023-03-20T16:22:56.617' AS DateTime), 0, 1, N'', NULL, 0, N'', NULL)
INSERT [dbo].[User] ([id], [email], [password], [full_name], [phone], [address], [role_id], [create_at], [update_at], [is_delete], [EmailConfirmed], [EmailConfirmationToken], [EmailConfirmationSentAt], [IsPasswordResetRequired], [ResetPasswordToken], [ResetPasswordSentAt]) VALUES (12, N'Customer44@gmail.com', N'9ae05b83bb084563b3949fb299dc3023', N'Customer 44', N'07882234488', N'Nghệ An', 2, CAST(N'2023-03-20T16:22:56.617' AS DateTime), CAST(N'2023-03-20T16:22:56.617' AS DateTime), 0, 1, N'', NULL, 0, N'', NULL)
INSERT [dbo].[User] ([id], [email], [password], [full_name], [phone], [address], [role_id], [create_at], [update_at], [is_delete], [EmailConfirmed], [EmailConfirmationToken], [EmailConfirmationSentAt], [IsPasswordResetRequired], [ResetPasswordToken], [ResetPasswordSentAt]) VALUES (13, N'Customer45@gmail.com', N'c30710dbbe88b4607aee08bac0c81398', N'Customer 45', N'07882234590', N'Ninh Bình', 2, CAST(N'2023-03-20T16:22:56.617' AS DateTime), CAST(N'2023-03-20T16:22:56.617' AS DateTime), 0, 1, N'', NULL, 0, N'', NULL)
INSERT [dbo].[User] ([id], [email], [password], [full_name], [phone], [address], [role_id], [create_at], [update_at], [is_delete], [EmailConfirmed], [EmailConfirmationToken], [EmailConfirmationSentAt], [IsPasswordResetRequired], [ResetPasswordToken], [ResetPasswordSentAt]) VALUES (14, N'Customer46@gmail.com', N'f690ae00be23615bab02af67c3252caa', N'Customer 46', N'07882234692', N'Ninh Thuận', 2, CAST(N'2023-03-20T16:22:56.617' AS DateTime), CAST(N'2023-03-20T16:22:56.617' AS DateTime), 0, 1, N'', NULL, 0, N'', NULL)
INSERT [dbo].[User] ([id], [email], [password], [full_name], [phone], [address], [role_id], [create_at], [update_at], [is_delete], [EmailConfirmed], [EmailConfirmationToken], [EmailConfirmationSentAt], [IsPasswordResetRequired], [ResetPasswordToken], [ResetPasswordSentAt]) VALUES (15, N'Customer47@gmail.com', N'cb73bf2de20125d76e8a800d5af300e9', N'Customer 47', N'07882234794', N'Phú Thọ', 2, CAST(N'2023-03-20T16:22:56.617' AS DateTime), CAST(N'2023-03-20T16:22:56.617' AS DateTime), 0, 1, N'', NULL, 0, N'', NULL)
INSERT [dbo].[User] ([id], [email], [password], [full_name], [phone], [address], [role_id], [create_at], [update_at], [is_delete], [EmailConfirmed], [EmailConfirmationToken], [EmailConfirmationSentAt], [IsPasswordResetRequired], [ResetPasswordToken], [ResetPasswordSentAt]) VALUES (16, N'Customer34@gmail.com', N'f39a1f0309b97072b89d83e46e32a53f', N'Customer 34', N'07882233468', N'Hưng Yên', 2, CAST(N'2023-03-20T16:22:56.617' AS DateTime), CAST(N'2023-03-20T16:22:56.617' AS DateTime), 0, 1, N'', NULL, 0, N'', NULL)
INSERT [dbo].[User] ([id], [email], [password], [full_name], [phone], [address], [role_id], [create_at], [update_at], [is_delete], [EmailConfirmed], [EmailConfirmationToken], [EmailConfirmationSentAt], [IsPasswordResetRequired], [ResetPasswordToken], [ResetPasswordSentAt]) VALUES (17, N'Customer48@gmail.com', N'c5a90c2fbbd3d7c0b84a8b859dc8b937', N'Customer 48', N'07882234896', N'Quảng Bình', 2, CAST(N'2023-03-20T16:22:56.617' AS DateTime), CAST(N'2023-03-20T16:22:56.617' AS DateTime), 0, 1, N'', NULL, 0, N'', NULL)
INSERT [dbo].[User] ([id], [email], [password], [full_name], [phone], [address], [role_id], [create_at], [update_at], [is_delete], [EmailConfirmed], [EmailConfirmationToken], [EmailConfirmationSentAt], [IsPasswordResetRequired], [ResetPasswordToken], [ResetPasswordSentAt]) VALUES (18, N'Customer50@gmail.com', N'95b1f882e039be1d3537199436198373', N'Customer 50', N'078822350100', N'Quảng Ngãi', 2, CAST(N'2023-03-20T16:22:56.617' AS DateTime), CAST(N'2023-03-20T16:22:56.617' AS DateTime), 0, 1, N'', NULL, 0, N'', NULL)
INSERT [dbo].[User] ([id], [email], [password], [full_name], [phone], [address], [role_id], [create_at], [update_at], [is_delete], [EmailConfirmed], [EmailConfirmationToken], [EmailConfirmationSentAt], [IsPasswordResetRequired], [ResetPasswordToken], [ResetPasswordSentAt]) VALUES (19, N'Customer51@gmail.com', N'f885d2685ccacfa534db76292cf0b49b', N'Customer 51', N'078822351102', N'Quảng Ninh', 2, CAST(N'2023-03-20T16:22:56.617' AS DateTime), CAST(N'2023-03-20T16:22:56.617' AS DateTime), 0, 1, N'', NULL, 0, N'', NULL)
INSERT [dbo].[User] ([id], [email], [password], [full_name], [phone], [address], [role_id], [create_at], [update_at], [is_delete], [EmailConfirmed], [EmailConfirmationToken], [EmailConfirmationSentAt], [IsPasswordResetRequired], [ResetPasswordToken], [ResetPasswordSentAt]) VALUES (20, N'Customer52@gmail.com', N'2cc5116d5efc47e937a0670f07646dea', N'Customer 52', N'078822352104', N'Quảng Trị', 2, CAST(N'2023-03-20T16:22:56.617' AS DateTime), CAST(N'2023-03-20T16:22:56.617' AS DateTime), 0, 1, N'', NULL, 0, N'', NULL)
INSERT [dbo].[User] ([id], [email], [password], [full_name], [phone], [address], [role_id], [create_at], [update_at], [is_delete], [EmailConfirmed], [EmailConfirmationToken], [EmailConfirmationSentAt], [IsPasswordResetRequired], [ResetPasswordToken], [ResetPasswordSentAt]) VALUES (21, N'Customer53@gmail.com', N'c94acbb8dae2b7cea1e2d066323fb1ea', N'Customer 53', N'078822353106', N'Sóc Trăng', 2, CAST(N'2023-03-20T16:22:56.617' AS DateTime), CAST(N'2023-03-20T16:22:56.617' AS DateTime), 0, 1, N'', NULL, 0, N'', NULL)
INSERT [dbo].[User] ([id], [email], [password], [full_name], [phone], [address], [role_id], [create_at], [update_at], [is_delete], [EmailConfirmed], [EmailConfirmationToken], [EmailConfirmationSentAt], [IsPasswordResetRequired], [ResetPasswordToken], [ResetPasswordSentAt]) VALUES (22, N'Customer54@gmail.com', N'7f91b54007c5cdf97b933caac5595de9', N'Customer 54', N'078822354108', N'Sơn La', 2, CAST(N'2023-03-20T16:22:56.617' AS DateTime), CAST(N'2023-03-20T16:22:56.617' AS DateTime), 0, 1, N'', NULL, 0, N'', NULL)
INSERT [dbo].[User] ([id], [email], [password], [full_name], [phone], [address], [role_id], [create_at], [update_at], [is_delete], [EmailConfirmed], [EmailConfirmationToken], [EmailConfirmationSentAt], [IsPasswordResetRequired], [ResetPasswordToken], [ResetPasswordSentAt]) VALUES (23, N'Customer55@gmail.com', N'81e3c872e1e971de382972692ff4c8f1', N'Customer 55', N'078822355110', N'Tây Ninh', 2, CAST(N'2023-03-20T16:22:56.617' AS DateTime), CAST(N'2023-03-20T16:22:56.617' AS DateTime), 0, 1, N'', NULL, 0, N'', NULL)
INSERT [dbo].[User] ([id], [email], [password], [full_name], [phone], [address], [role_id], [create_at], [update_at], [is_delete], [EmailConfirmed], [EmailConfirmationToken], [EmailConfirmationSentAt], [IsPasswordResetRequired], [ResetPasswordToken], [ResetPasswordSentAt]) VALUES (24, N'Customer56@gmail.com', N'00517774d140686fce6b9a0b2a972da0', N'Customer 56', N'078822356112', N'Thái Bình', 2, CAST(N'2023-03-20T16:22:56.617' AS DateTime), CAST(N'2023-03-20T16:22:56.617' AS DateTime), 0, 1, N'', NULL, 0, N'', NULL)
INSERT [dbo].[User] ([id], [email], [password], [full_name], [phone], [address], [role_id], [create_at], [update_at], [is_delete], [EmailConfirmed], [EmailConfirmationToken], [EmailConfirmationSentAt], [IsPasswordResetRequired], [ResetPasswordToken], [ResetPasswordSentAt]) VALUES (25, N'Customer57@gmail.com', N'9075d7e195edc07059cb330ba6cb9436', N'Customer 57', N'078822357114', N'Thái Nguyên', 2, CAST(N'2023-03-20T16:22:56.617' AS DateTime), CAST(N'2023-03-20T16:22:56.617' AS DateTime), 0, 1, N'', NULL, 0, N'', NULL)
INSERT [dbo].[User] ([id], [email], [password], [full_name], [phone], [address], [role_id], [create_at], [update_at], [is_delete], [EmailConfirmed], [EmailConfirmationToken], [EmailConfirmationSentAt], [IsPasswordResetRequired], [ResetPasswordToken], [ResetPasswordSentAt]) VALUES (26, N'Customer58@gmail.com', N'febc9d5ea096405dfb25f64392312cd3', N'Customer 58', N'078822358116', N'Thanh Hóa', 2, CAST(N'2023-03-20T16:22:56.617' AS DateTime), CAST(N'2023-03-20T16:22:56.617' AS DateTime), 0, 1, N'', NULL, 0, N'', NULL)
INSERT [dbo].[User] ([id], [email], [password], [full_name], [phone], [address], [role_id], [create_at], [update_at], [is_delete], [EmailConfirmed], [EmailConfirmationToken], [EmailConfirmationSentAt], [IsPasswordResetRequired], [ResetPasswordToken], [ResetPasswordSentAt]) VALUES (27, N'Customer59@gmail.com', N'13667dc434281e733b569aa2050d1fd6', N'Customer 59', N'078822359118', N'Thừa Thiên Huế', 2, CAST(N'2023-03-20T16:22:56.617' AS DateTime), CAST(N'2023-03-20T16:22:56.617' AS DateTime), 0, 1, N'', NULL, 0, N'', NULL)
INSERT [dbo].[User] ([id], [email], [password], [full_name], [phone], [address], [role_id], [create_at], [update_at], [is_delete], [EmailConfirmed], [EmailConfirmationToken], [EmailConfirmationSentAt], [IsPasswordResetRequired], [ResetPasswordToken], [ResetPasswordSentAt]) VALUES (28, N'Customer60@gmail.com', N'7761da8e52a77c32b9a85a6e202f9ba9', N'Customer 60', N'078822360120', N'Tiền Giang', 2, CAST(N'2023-03-20T16:22:56.617' AS DateTime), CAST(N'2023-03-20T16:22:56.617' AS DateTime), 0, 1, N'', NULL, 0, N'', NULL)
INSERT [dbo].[User] ([id], [email], [password], [full_name], [phone], [address], [role_id], [create_at], [update_at], [is_delete], [EmailConfirmed], [EmailConfirmationToken], [EmailConfirmationSentAt], [IsPasswordResetRequired], [ResetPasswordToken], [ResetPasswordSentAt]) VALUES (29, N'Customer61@gmail.com', N'e991c00d247ca2acf1e6aba87cc32f03', N'Customer 61', N'078822361122', N'Trà Vinh', 2, CAST(N'2023-03-20T16:22:56.617' AS DateTime), CAST(N'2023-03-20T16:22:56.617' AS DateTime), 0, 1, N'', NULL, 0, N'', NULL)
INSERT [dbo].[User] ([id], [email], [password], [full_name], [phone], [address], [role_id], [create_at], [update_at], [is_delete], [EmailConfirmed], [EmailConfirmationToken], [EmailConfirmationSentAt], [IsPasswordResetRequired], [ResetPasswordToken], [ResetPasswordSentAt]) VALUES (30, N'Customer62@gmail.com', N'2a5d9cad83b95cb0b0a57bf675e1165d', N'Customer 62', N'078822362124', N'Tuyên Quang', 2, CAST(N'2023-03-20T16:22:56.617' AS DateTime), CAST(N'2023-03-20T16:22:56.617' AS DateTime), 0, 1, N'', NULL, 0, N'', NULL)
INSERT [dbo].[User] ([id], [email], [password], [full_name], [phone], [address], [role_id], [create_at], [update_at], [is_delete], [EmailConfirmed], [EmailConfirmationToken], [EmailConfirmationSentAt], [IsPasswordResetRequired], [ResetPasswordToken], [ResetPasswordSentAt]) VALUES (31, N'Customer49@gmail.com', N'd55cec744dc717e6b73a7fecbd83f6c6', N'Customer 49', N'07882234998', N'Quảng Nam', 2, CAST(N'2023-03-20T16:22:56.617' AS DateTime), CAST(N'2023-03-20T16:22:56.617' AS DateTime), 0, 1, N'', NULL, 0, N'', NULL)
INSERT [dbo].[User] ([id], [email], [password], [full_name], [phone], [address], [role_id], [create_at], [update_at], [is_delete], [EmailConfirmed], [EmailConfirmationToken], [EmailConfirmationSentAt], [IsPasswordResetRequired], [ResetPasswordToken], [ResetPasswordSentAt]) VALUES (32, N'Customer33@gmail.com', N'b220712c6c50a34d45afbacb6190ca41', N'Customer 33', N'07882233366', N'Hòa Bình', 2, CAST(N'2023-03-20T16:22:56.617' AS DateTime), CAST(N'2023-03-20T16:22:56.617' AS DateTime), 0, 1, N'', NULL, 0, N'', NULL)
INSERT [dbo].[User] ([id], [email], [password], [full_name], [phone], [address], [role_id], [create_at], [update_at], [is_delete], [EmailConfirmed], [EmailConfirmationToken], [EmailConfirmationSentAt], [IsPasswordResetRequired], [ResetPasswordToken], [ResetPasswordSentAt]) VALUES (33, N'Customer32@gmail.com', N'2b9298683dd57d2cc66aee14eaf563a0', N'Customer 32', N'07882233264', N'Hậu Giang', 2, CAST(N'2023-03-20T16:22:56.617' AS DateTime), CAST(N'2023-03-20T16:22:56.617' AS DateTime), 0, 1, N'', NULL, 0, N'', NULL)
INSERT [dbo].[User] ([id], [email], [password], [full_name], [phone], [address], [role_id], [create_at], [update_at], [is_delete], [EmailConfirmed], [EmailConfirmationToken], [EmailConfirmationSentAt], [IsPasswordResetRequired], [ResetPasswordToken], [ResetPasswordSentAt]) VALUES (34, N'Customer31@gmail.com', N'0e682397acd419a75131c4ead5c81808', N'Customer 31', N'07882233162', N'Hải Phòng', 2, CAST(N'2023-03-20T16:22:56.617' AS DateTime), CAST(N'2023-03-20T16:22:56.617' AS DateTime), 0, 1, N'', NULL, 0, N'', NULL)
INSERT [dbo].[User] ([id], [email], [password], [full_name], [phone], [address], [role_id], [create_at], [update_at], [is_delete], [EmailConfirmed], [EmailConfirmationToken], [EmailConfirmationSentAt], [IsPasswordResetRequired], [ResetPasswordToken], [ResetPasswordSentAt]) VALUES (35, N'Customer17@gmail.com', N'cd9e5aa005bd8421531190f98fcd1cc3', N'Customer 17', N'07882231734', N'Bình Dương', 2, CAST(N'2023-03-20T16:22:56.617' AS DateTime), CAST(N'2023-03-20T16:22:56.617' AS DateTime), 0, 1, N'', NULL, 0, N'', NULL)
INSERT [dbo].[User] ([id], [email], [password], [full_name], [phone], [address], [role_id], [create_at], [update_at], [is_delete], [EmailConfirmed], [EmailConfirmationToken], [EmailConfirmationSentAt], [IsPasswordResetRequired], [ResetPasswordToken], [ResetPasswordSentAt]) VALUES (36, N'Customer16@gmail.com', N'e316750603a0eb7ea271b9f29ea23453', N'Customer 16', N'07882231632', N'Bình Định', 2, CAST(N'2023-03-20T16:22:56.617' AS DateTime), CAST(N'2023-03-20T16:22:56.617' AS DateTime), 0, 1, N'', NULL, 0, N'', NULL)
INSERT [dbo].[User] ([id], [email], [password], [full_name], [phone], [address], [role_id], [create_at], [update_at], [is_delete], [EmailConfirmed], [EmailConfirmationToken], [EmailConfirmationSentAt], [IsPasswordResetRequired], [ResetPasswordToken], [ResetPasswordSentAt]) VALUES (37, N'Customer15@gmail.com', N'159e9bd0aa4cacabff8cd77677fa3e68', N'Customer 15', N'07882231530', N'Bến Tre', 2, CAST(N'2023-03-20T16:22:56.617' AS DateTime), CAST(N'2023-03-20T16:22:56.617' AS DateTime), 0, 1, N'', NULL, 0, N'', NULL)
INSERT [dbo].[User] ([id], [email], [password], [full_name], [phone], [address], [role_id], [create_at], [update_at], [is_delete], [EmailConfirmed], [EmailConfirmationToken], [EmailConfirmationSentAt], [IsPasswordResetRequired], [ResetPasswordToken], [ResetPasswordSentAt]) VALUES (38, N'Customer14@gmail.com', N'5366803aff5a6e303e900bcb3ce0e69a', N'Customer 14', N'07882231428', N'Bắc Ninh', 2, CAST(N'2023-03-20T16:22:56.617' AS DateTime), CAST(N'2023-03-20T16:22:56.617' AS DateTime), 0, 1, N'', NULL, 0, N'', NULL)
INSERT [dbo].[User] ([id], [email], [password], [full_name], [phone], [address], [role_id], [create_at], [update_at], [is_delete], [EmailConfirmed], [EmailConfirmationToken], [EmailConfirmationSentAt], [IsPasswordResetRequired], [ResetPasswordToken], [ResetPasswordSentAt]) VALUES (39, N'Customer13@gmail.com', N'0205a9125c42b9980d02eef151b4d6f4', N'Customer 13', N'07882231326', N'Bạc Liêu', 2, CAST(N'2023-03-20T16:22:56.617' AS DateTime), CAST(N'2023-03-20T16:22:56.617' AS DateTime), 0, 1, N'', NULL, 0, N'', NULL)
INSERT [dbo].[User] ([id], [email], [password], [full_name], [phone], [address], [role_id], [create_at], [update_at], [is_delete], [EmailConfirmed], [EmailConfirmationToken], [EmailConfirmationSentAt], [IsPasswordResetRequired], [ResetPasswordToken], [ResetPasswordSentAt]) VALUES (40, N'Customer12@gmail.com', N'0f5be33fdcb2d449f30246cd12cf0239', N'Customer 12', N'07882231224', N'Bắc Kạn', 2, CAST(N'2023-03-20T16:22:56.617' AS DateTime), CAST(N'2023-03-20T16:22:56.617' AS DateTime), 0, 1, N'', NULL, 0, N'', NULL)
INSERT [dbo].[User] ([id], [email], [password], [full_name], [phone], [address], [role_id], [create_at], [update_at], [is_delete], [EmailConfirmed], [EmailConfirmationToken], [EmailConfirmationSentAt], [IsPasswordResetRequired], [ResetPasswordToken], [ResetPasswordSentAt]) VALUES (41, N'Customer11@gmail.com', N'2cf7f8978f065b439d22a83ac0d1f7c6', N'Customer 11', N'07882231122', N'Bắc Giang', 2, CAST(N'2023-03-20T16:22:56.617' AS DateTime), CAST(N'2023-03-20T16:22:56.617' AS DateTime), 0, 1, N'', NULL, 0, N'', NULL)
INSERT [dbo].[User] ([id], [email], [password], [full_name], [phone], [address], [role_id], [create_at], [update_at], [is_delete], [EmailConfirmed], [EmailConfirmationToken], [EmailConfirmationSentAt], [IsPasswordResetRequired], [ResetPasswordToken], [ResetPasswordSentAt]) VALUES (42, N'Customer10@gmail.com', N'efaec6707113edb5a3cd1bc5a7bfb8f0', N'Customer 10', N'07882231020', N'Bà Rịa - Vũng Tàu', 2, CAST(N'2023-03-20T16:22:56.617' AS DateTime), CAST(N'2023-03-20T16:22:56.617' AS DateTime), 0, 1, N'', NULL, 0, N'', NULL)
INSERT [dbo].[User] ([id], [email], [password], [full_name], [phone], [address], [role_id], [create_at], [update_at], [is_delete], [EmailConfirmed], [EmailConfirmationToken], [EmailConfirmationSentAt], [IsPasswordResetRequired], [ResetPasswordToken], [ResetPasswordSentAt]) VALUES (43, N'Customer9@gmail.com', N'3e609abfe65ae230795a201335c22a57', N'Customer 9', N'0788223918', N'An Giang', 2, CAST(N'2023-03-20T16:22:56.617' AS DateTime), CAST(N'2023-03-20T16:22:56.617' AS DateTime), 0, 1, N'', NULL, 0, N'', NULL)
INSERT [dbo].[User] ([id], [email], [password], [full_name], [phone], [address], [role_id], [create_at], [update_at], [is_delete], [EmailConfirmed], [EmailConfirmationToken], [EmailConfirmationSentAt], [IsPasswordResetRequired], [ResetPasswordToken], [ResetPasswordSentAt]) VALUES (44, N'Customer8@gmail.com', N'acce14a18df3e1c51529ff16f7a4d865', N'Customer 8', N'0788223816', N'Đồng Tháp', 2, CAST(N'2023-03-20T16:22:56.617' AS DateTime), CAST(N'2023-03-20T16:22:56.617' AS DateTime), 0, 1, N'', NULL, 0, N'', NULL)
INSERT [dbo].[User] ([id], [email], [password], [full_name], [phone], [address], [role_id], [create_at], [update_at], [is_delete], [EmailConfirmed], [EmailConfirmationToken], [EmailConfirmationSentAt], [IsPasswordResetRequired], [ResetPasswordToken], [ResetPasswordSentAt]) VALUES (45, N'Customer7@gmail.com', N'32fbc6b84b46f58db39903a10ab2c3b3', N'Customer 7', N'0788223714', N'Phú Yên', 2, CAST(N'2023-03-20T16:22:56.617' AS DateTime), CAST(N'2023-03-20T16:22:56.617' AS DateTime), 0, 1, N'', NULL, 0, N'', NULL)
INSERT [dbo].[User] ([id], [email], [password], [full_name], [phone], [address], [role_id], [create_at], [update_at], [is_delete], [EmailConfirmed], [EmailConfirmationToken], [EmailConfirmationSentAt], [IsPasswordResetRequired], [ResetPasswordToken], [ResetPasswordSentAt]) VALUES (46, N'Customer6@gmail.com', N'c81c82b67ce1e22ed0fc4ac3d081ce30', N'Customer 6', N'0788223612', N'Vĩnh Long', 2, CAST(N'2023-03-20T16:22:56.617' AS DateTime), CAST(N'2023-03-20T16:22:56.617' AS DateTime), 0, 1, N'', NULL, 0, N'', NULL)
INSERT [dbo].[User] ([id], [email], [password], [full_name], [phone], [address], [role_id], [create_at], [update_at], [is_delete], [EmailConfirmed], [EmailConfirmationToken], [EmailConfirmationSentAt], [IsPasswordResetRequired], [ResetPasswordToken], [ResetPasswordSentAt]) VALUES (47, N'Customer5@gmail.com', N'6c71043034553cb444461c4a82317328', N'Customer 5', N'0788223510', N'Cần Thơ', 2, CAST(N'2023-03-20T16:22:56.617' AS DateTime), CAST(N'2023-03-20T16:22:56.617' AS DateTime), 0, 1, N'', NULL, 0, N'', NULL)
INSERT [dbo].[User] ([id], [email], [password], [full_name], [phone], [address], [role_id], [create_at], [update_at], [is_delete], [EmailConfirmed], [EmailConfirmationToken], [EmailConfirmationSentAt], [IsPasswordResetRequired], [ResetPasswordToken], [ResetPasswordSentAt]) VALUES (48, N'Customer4@gmail.com', N'c7a5badae1d4b7f44b530a6721abeee5', N'Customer 4', N'078822348', N'Huế', 2, CAST(N'2023-03-20T16:22:56.617' AS DateTime), CAST(N'2023-03-20T16:22:56.617' AS DateTime), 0, 1, N'', NULL, 0, N'', NULL)
INSERT [dbo].[User] ([id], [email], [password], [full_name], [phone], [address], [role_id], [create_at], [update_at], [is_delete], [EmailConfirmed], [EmailConfirmationToken], [EmailConfirmationSentAt], [IsPasswordResetRequired], [ResetPasswordToken], [ResetPasswordSentAt]) VALUES (49, N'Customer3@gmail.com', N'8dffb9599ddc6760e798663b41155014', N'Customer 3', N'078822336', N'Đà Nẵng', 2, CAST(N'2023-03-20T16:22:56.617' AS DateTime), CAST(N'2023-03-20T16:22:56.617' AS DateTime), 0, 1, N'', NULL, 0, N'', NULL)
INSERT [dbo].[User] ([id], [email], [password], [full_name], [phone], [address], [role_id], [create_at], [update_at], [is_delete], [EmailConfirmed], [EmailConfirmationToken], [EmailConfirmationSentAt], [IsPasswordResetRequired], [ResetPasswordToken], [ResetPasswordSentAt]) VALUES (50, N'Customer2@gmail.com', N'2b2b346cac33fa2a7bb5a7a27fca785f', N'Customer 2', N'078822324', N'Hồ Chí Minh', 2, CAST(N'2023-03-20T16:22:56.617' AS DateTime), CAST(N'2023-03-20T16:22:56.617' AS DateTime), 0, 1, N'', NULL, 0, N'', NULL)
INSERT [dbo].[User] ([id], [email], [password], [full_name], [phone], [address], [role_id], [create_at], [update_at], [is_delete], [EmailConfirmed], [EmailConfirmationToken], [EmailConfirmationSentAt], [IsPasswordResetRequired], [ResetPasswordToken], [ResetPasswordSentAt]) VALUES (51, N'Customer1@gmail.com', N'bec3d53a9f7c6c66ab85385c17197413', N'Customer 1', N'078822312', N'Hà Nội', 2, CAST(N'2023-03-20T16:22:56.617' AS DateTime), CAST(N'2023-03-20T16:22:56.617' AS DateTime), 0, 1, N'', NULL, 0, N'', NULL)
INSERT [dbo].[User] ([id], [email], [password], [full_name], [phone], [address], [role_id], [create_at], [update_at], [is_delete], [EmailConfirmed], [EmailConfirmationToken], [EmailConfirmationSentAt], [IsPasswordResetRequired], [ResetPasswordToken], [ResetPasswordSentAt]) VALUES (52, N'Customer19@gmail.com', N'bb4986cbdae0d7aa4b25615991a0d95e', N'Customer 19', N'07882231938', N'Bình Thuận', 2, CAST(N'2023-03-20T16:22:56.617' AS DateTime), CAST(N'2023-03-20T16:22:56.617' AS DateTime), 0, 1, N'', NULL, 0, N'', NULL)
INSERT [dbo].[User] ([id], [email], [password], [full_name], [phone], [address], [role_id], [create_at], [update_at], [is_delete], [EmailConfirmed], [EmailConfirmationToken], [EmailConfirmationSentAt], [IsPasswordResetRequired], [ResetPasswordToken], [ResetPasswordSentAt]) VALUES (53, N'Customer20@gmail.com', N'3fe1a1d8a59d45af7d5138c1bdb7db8b', N'Customer 20', N'07882232040', N'Cà Mau', 2, CAST(N'2023-03-20T16:22:56.617' AS DateTime), CAST(N'2023-03-20T16:22:56.617' AS DateTime), 0, 1, N'', NULL, 0, N'', NULL)
INSERT [dbo].[User] ([id], [email], [password], [full_name], [phone], [address], [role_id], [create_at], [update_at], [is_delete], [EmailConfirmed], [EmailConfirmationToken], [EmailConfirmationSentAt], [IsPasswordResetRequired], [ResetPasswordToken], [ResetPasswordSentAt]) VALUES (54, N'Customer21@gmail.com', N'4bcf7c29a15069a42bf4abfe54c9cb5a', N'Customer 21', N'07882232142', N'Cao Bằng', 2, CAST(N'2023-03-20T16:22:56.617' AS DateTime), CAST(N'2023-03-20T16:22:56.617' AS DateTime), 0, 1, N'', NULL, 0, N'', NULL)
INSERT [dbo].[User] ([id], [email], [password], [full_name], [phone], [address], [role_id], [create_at], [update_at], [is_delete], [EmailConfirmed], [EmailConfirmationToken], [EmailConfirmationSentAt], [IsPasswordResetRequired], [ResetPasswordToken], [ResetPasswordSentAt]) VALUES (55, N'Customer22@gmail.com', N'ceeed30964f67ee63fa312446ede16de', N'Customer 22', N'07882232244', N'Đắk Lắk', 2, CAST(N'2023-03-20T16:22:56.617' AS DateTime), CAST(N'2023-03-20T16:22:56.617' AS DateTime), 0, 1, N'', NULL, 0, N'', NULL)
INSERT [dbo].[User] ([id], [email], [password], [full_name], [phone], [address], [role_id], [create_at], [update_at], [is_delete], [EmailConfirmed], [EmailConfirmationToken], [EmailConfirmationSentAt], [IsPasswordResetRequired], [ResetPasswordToken], [ResetPasswordSentAt]) VALUES (56, N'Customer23@gmail.com', N'89d1861d364aff93f1ff08fc93808741', N'Customer 23', N'07882232346', N'Đắk Nông', 2, CAST(N'2023-03-20T16:22:56.617' AS DateTime), CAST(N'2023-03-20T16:22:56.617' AS DateTime), 0, 1, N'', NULL, 0, N'', NULL)
INSERT [dbo].[User] ([id], [email], [password], [full_name], [phone], [address], [role_id], [create_at], [update_at], [is_delete], [EmailConfirmed], [EmailConfirmationToken], [EmailConfirmationSentAt], [IsPasswordResetRequired], [ResetPasswordToken], [ResetPasswordSentAt]) VALUES (57, N'Customer24@gmail.com', N'f9f63114bff60705ddb9049ffac6d590', N'Customer 24', N'07882232448', N'Điện Biên', 2, CAST(N'2023-03-20T16:22:56.617' AS DateTime), CAST(N'2023-03-20T16:22:56.617' AS DateTime), 0, 1, N'', NULL, 0, N'', NULL)
INSERT [dbo].[User] ([id], [email], [password], [full_name], [phone], [address], [role_id], [create_at], [update_at], [is_delete], [EmailConfirmed], [EmailConfirmationToken], [EmailConfirmationSentAt], [IsPasswordResetRequired], [ResetPasswordToken], [ResetPasswordSentAt]) VALUES (58, N'Customer25@gmail.com', N'ea386eaa0b1e78c02c7c6d3e10db605f', N'Customer 25', N'07882232550', N'Đồng Nai', 2, CAST(N'2023-03-20T16:22:56.617' AS DateTime), CAST(N'2023-03-20T16:22:56.617' AS DateTime), 0, 1, N'', NULL, 0, N'', NULL)
INSERT [dbo].[User] ([id], [email], [password], [full_name], [phone], [address], [role_id], [create_at], [update_at], [is_delete], [EmailConfirmed], [EmailConfirmationToken], [EmailConfirmationSentAt], [IsPasswordResetRequired], [ResetPasswordToken], [ResetPasswordSentAt]) VALUES (59, N'Customer26@gmail.com', N'52886a3f4389c75f23510740309a7ac5', N'Customer 26', N'07882232652', N'Gia Lai', 2, CAST(N'2023-03-20T16:22:56.617' AS DateTime), CAST(N'2023-03-20T16:22:56.617' AS DateTime), 0, 1, N'', NULL, 0, N'', NULL)
INSERT [dbo].[User] ([id], [email], [password], [full_name], [phone], [address], [role_id], [create_at], [update_at], [is_delete], [EmailConfirmed], [EmailConfirmationToken], [EmailConfirmationSentAt], [IsPasswordResetRequired], [ResetPasswordToken], [ResetPasswordSentAt]) VALUES (60, N'Customer27@gmail.com', N'bc1b00be0443dcff3cadf9c464df2b1a', N'Customer 27', N'07882232754', N'Hà Giang', 2, CAST(N'2023-03-20T16:22:56.617' AS DateTime), CAST(N'2023-03-20T16:22:56.617' AS DateTime), 0, 1, N'', NULL, 0, N'', NULL)
INSERT [dbo].[User] ([id], [email], [password], [full_name], [phone], [address], [role_id], [create_at], [update_at], [is_delete], [EmailConfirmed], [EmailConfirmationToken], [EmailConfirmationSentAt], [IsPasswordResetRequired], [ResetPasswordToken], [ResetPasswordSentAt]) VALUES (61, N'Customer28@gmail.com', N'1273bf9a721934c0f4a57383f91416ac', N'Customer 28', N'07882232856', N'Hà Nam', 2, CAST(N'2023-03-20T16:22:56.617' AS DateTime), CAST(N'2023-03-20T16:22:56.617' AS DateTime), 0, 1, N'', NULL, 0, N'', NULL)
INSERT [dbo].[User] ([id], [email], [password], [full_name], [phone], [address], [role_id], [create_at], [update_at], [is_delete], [EmailConfirmed], [EmailConfirmationToken], [EmailConfirmationSentAt], [IsPasswordResetRequired], [ResetPasswordToken], [ResetPasswordSentAt]) VALUES (62, N'Customer29@gmail.com', N'61682f78790b77879a56bdf05936a885', N'Customer 29', N'07882232958', N'Hà Tĩnh', 2, CAST(N'2023-03-20T16:22:56.617' AS DateTime), CAST(N'2023-03-20T16:22:56.617' AS DateTime), 0, 1, N'', NULL, 0, N'', NULL)
INSERT [dbo].[User] ([id], [email], [password], [full_name], [phone], [address], [role_id], [create_at], [update_at], [is_delete], [EmailConfirmed], [EmailConfirmationToken], [EmailConfirmationSentAt], [IsPasswordResetRequired], [ResetPasswordToken], [ResetPasswordSentAt]) VALUES (63, N'Customer30@gmail.com', N'2c0ff7d7e8c64fe10b0bbf2d613dd5d2', N'Customer 30', N'07882233060', N'Hải Dương', 2, CAST(N'2023-03-20T16:22:56.617' AS DateTime), CAST(N'2023-03-20T16:22:56.617' AS DateTime), 0, 1, N'', NULL, 0, N'', NULL)
INSERT [dbo].[User] ([id], [email], [password], [full_name], [phone], [address], [role_id], [create_at], [update_at], [is_delete], [EmailConfirmed], [EmailConfirmationToken], [EmailConfirmationSentAt], [IsPasswordResetRequired], [ResetPasswordToken], [ResetPasswordSentAt]) VALUES (64, N'Customer63@gmail.com', N'1da322267ff82f5d13b459e575f9a62d', N'Customer 63', N'078822363126', N'Vĩnh Phúc', 2, CAST(N'2023-03-20T16:22:56.617' AS DateTime), CAST(N'2023-03-20T16:22:56.617' AS DateTime), 0, 1, N'', NULL, 0, N'', NULL)
INSERT [dbo].[User] ([id], [email], [password], [full_name], [phone], [address], [role_id], [create_at], [update_at], [is_delete], [EmailConfirmed], [EmailConfirmationToken], [EmailConfirmationSentAt], [IsPasswordResetRequired], [ResetPasswordToken], [ResetPasswordSentAt]) VALUES (65, N'Customer64@gmail.com', N'6f03623f16c1cd92886fbc127f1b5146', N'Customer 64', N'078822364128', N'Yên Bái', 2, CAST(N'2023-03-20T16:22:56.617' AS DateTime), CAST(N'2023-03-20T16:22:56.617' AS DateTime), 0, 1, N'', NULL, 0, N'', NULL)
SET IDENTITY_INSERT [dbo].[User] OFF
GO
ALTER TABLE [dbo].[Cart]  WITH CHECK ADD  CONSTRAINT [FK__Cart__product_id__3C69FB99] FOREIGN KEY([product_id])
REFERENCES [dbo].[Product] ([id])
GO
ALTER TABLE [dbo].[Cart] CHECK CONSTRAINT [FK__Cart__product_id__3C69FB99]
GO
ALTER TABLE [dbo].[Cart]  WITH CHECK ADD  CONSTRAINT [FK__Cart__user_id__3D5E1FD2] FOREIGN KEY([user_id])
REFERENCES [dbo].[User] ([id])
GO
ALTER TABLE [dbo].[Cart] CHECK CONSTRAINT [FK__Cart__user_id__3D5E1FD2]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK__Order__status_id__36B12243] FOREIGN KEY([status_id])
REFERENCES [dbo].[Status] ([id])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK__Order__status_id__36B12243]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK__Order__user_id__35BCFE0A] FOREIGN KEY([user_id])
REFERENCES [dbo].[User] ([id])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK__Order__user_id__35BCFE0A]
GO
ALTER TABLE [dbo].[OrderDetail]  WITH CHECK ADD  CONSTRAINT [FK__OrderDeta__order__38996AB5] FOREIGN KEY([order_id])
REFERENCES [dbo].[Order] ([id])
GO
ALTER TABLE [dbo].[OrderDetail] CHECK CONSTRAINT [FK__OrderDeta__order__38996AB5]
GO
ALTER TABLE [dbo].[OrderDetail]  WITH CHECK ADD  CONSTRAINT [FK__OrderDeta__produ__37A5467C] FOREIGN KEY([product_id])
REFERENCES [dbo].[Product] ([id])
GO
ALTER TABLE [dbo].[OrderDetail] CHECK CONSTRAINT [FK__OrderDeta__produ__37A5467C]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK__Product__categor__33D4B598] FOREIGN KEY([category_id])
REFERENCES [dbo].[Category] ([id])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK__Product__categor__33D4B598]
GO
ALTER TABLE [dbo].[Review]  WITH CHECK ADD  CONSTRAINT [FK__Review__product___3A81B327] FOREIGN KEY([product_id])
REFERENCES [dbo].[Product] ([id])
GO
ALTER TABLE [dbo].[Review] CHECK CONSTRAINT [FK__Review__product___3A81B327]
GO
ALTER TABLE [dbo].[Review]  WITH CHECK ADD  CONSTRAINT [FK__Review__user_id__3B75D760] FOREIGN KEY([user_id])
REFERENCES [dbo].[User] ([id])
GO
ALTER TABLE [dbo].[Review] CHECK CONSTRAINT [FK__Review__user_id__3B75D760]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK__User__role_id__398D8EEE] FOREIGN KEY([role_id])
REFERENCES [dbo].[Role] ([id])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK__User__role_id__398D8EEE]
GO
