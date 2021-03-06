USE [InventoryDB]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 17/04/2020 05:02:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[Productid] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NULL,
	[photo] [nvarchar](250) NULL,
	[price] [float] NULL,
	[lastupdated] [date] NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[Productid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Product] ON 

INSERT [dbo].[Product] ([Productid], [name], [photo], [price], [lastupdated]) VALUES (1, N'rice', N'rice.jpg', 15, CAST(N'2020-04-01' AS Date))
INSERT [dbo].[Product] ([Productid], [name], [photo], [price], [lastupdated]) VALUES (2, N'suger', N'ا.jpg', 23, CAST(N'2020-01-01' AS Date))
SET IDENTITY_INSERT [dbo].[Product] OFF
