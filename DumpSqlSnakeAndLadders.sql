/****** Создание таблицы рейтинг ******/
CREATE TABLE [dbo].[Rating](
	[idRating] [int] IDENTITY(1,1) NOT NULL,
	[idUsers] [int] NOT NULL,
 CONSTRAINT [PK_Rating] PRIMARY KEY CLUSTERED 
(
	[idRating] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Создание таблицы пользователи ******/

CREATE TABLE [dbo].[Users](
	[idUser] [int] IDENTITY(1,1) NOT NULL,
	[Login] [varchar](32) NOT NULL,
	[Score] [int] NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[idUser] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Users] ON 
/****** Данные в изначальной таблице ******/
INSERT [dbo].[Users] ([idUser], [Login], [Score]) VALUES (1, N'Romanza', 100000000)
INSERT [dbo].[Users] ([idUser], [Login], [Score]) VALUES (2, N'Andrey', 0)
INSERT [dbo].[Users] ([idUser], [Login], [Score]) VALUES (3, N'Artem', 100000)
INSERT [dbo].[Users] ([idUser], [Login], [Score]) VALUES (4, N'Nikita', 5000000)
INSERT [dbo].[Users] ([idUser], [Login], [Score]) VALUES (5, N'Name', 0)
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_Score]  DEFAULT ((0)) FOR [Score]
GO
ALTER TABLE [dbo].[Rating]  WITH CHECK ADD  CONSTRAINT [FK_Rating_Users] FOREIGN KEY([idUsers])
REFERENCES [dbo].[Users] ([idUser])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Rating] CHECK CONSTRAINT [FK_Rating_Users]
GO

