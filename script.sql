USE [band_tracker]
GO
/****** Object:  Table [dbo].[bands]    Script Date: 8/5/2016 11:29:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[bands](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](255) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[venues]    Script Date: 8/5/2016 11:29:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[venues](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](255) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[venues_bands]    Script Date: 8/5/2016 11:29:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[venues_bands](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[venue_id] [int] NULL,
	[band_id] [int] NULL
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[bands] ON 

INSERT [dbo].[bands] ([id], [name]) VALUES (13, N'GnR')
INSERT [dbo].[bands] ([id], [name]) VALUES (14, N'Primus')
INSERT [dbo].[bands] ([id], [name]) VALUES (15, N'Metallica')
SET IDENTITY_INSERT [dbo].[bands] OFF
SET IDENTITY_INSERT [dbo].[venues] ON 

INSERT [dbo].[venues] ([id], [name]) VALUES (8, N'Paramont')
INSERT [dbo].[venues] ([id], [name]) VALUES (7, N'Rock Candy')
INSERT [dbo].[venues] ([id], [name]) VALUES (9, N'Pheonix')
SET IDENTITY_INSERT [dbo].[venues] OFF
SET IDENTITY_INSERT [dbo].[venues_bands] ON 

INSERT [dbo].[venues_bands] ([id], [venue_id], [band_id]) VALUES (1, 6, 5)
INSERT [dbo].[venues_bands] ([id], [venue_id], [band_id]) VALUES (2, 6, 2)
INSERT [dbo].[venues_bands] ([id], [venue_id], [band_id]) VALUES (3, 6, 3)
INSERT [dbo].[venues_bands] ([id], [venue_id], [band_id]) VALUES (4, 7, 1)
INSERT [dbo].[venues_bands] ([id], [venue_id], [band_id]) VALUES (5, 7, 3)
INSERT [dbo].[venues_bands] ([id], [venue_id], [band_id]) VALUES (6, 8, 13)
INSERT [dbo].[venues_bands] ([id], [venue_id], [band_id]) VALUES (7, 9, 15)
INSERT [dbo].[venues_bands] ([id], [venue_id], [band_id]) VALUES (8, 7, 14)
INSERT [dbo].[venues_bands] ([id], [venue_id], [band_id]) VALUES (9, 8, 14)
INSERT [dbo].[venues_bands] ([id], [venue_id], [band_id]) VALUES (10, 8, 15)
SET IDENTITY_INSERT [dbo].[venues_bands] OFF
