SET IDENTITY_INSERT [dbo].[Actor] ON
INSERT INTO [dbo].[Actor] ([Id], [Name], [WebSite]) VALUES (1, N'Robert Patrick', N'http://www.robertpatrick.com')
INSERT INTO [dbo].[Actor] ([Id], [Name], [WebSite]) VALUES (2, N'Arnold Schwarzenegger', N'http://www.arnoldschwarzenegger.com')
INSERT INTO [dbo].[Actor] ([Id], [Name], [WebSite]) VALUES (3, N'Robert Downey Jr', N'http://www.robertjnr.com')
INSERT INTO [dbo].[Actor] ([Id], [Name], [WebSite]) VALUES (4, N'Chris Evans', N'http://www.chrisevans,com')
SET IDENTITY_INSERT [dbo].[Actor] OFF
SET IDENTITY_INSERT [dbo].[Director] ON
INSERT INTO [dbo].[Director] ([Id], [Name], [Website]) VALUES (1, N'Joe Johnston', N'http://www.joejohnson.com')
INSERT INTO [dbo].[Director] ([Id], [Name], [Website]) VALUES (2, N'James Cameron', N'http://www.jamescameron.com')
SET IDENTITY_INSERT [dbo].[Director] OFF
SET IDENTITY_INSERT [dbo].[Movie] ON
INSERT INTO [dbo].[Movie] ([Id], [Name], [Genres], [DirectorId], [ReleaseYear]) VALUES (1, N'Teminator 2 :Judgement Daydd', N'Action /Sci-Fi', 2, 1985)
INSERT INTO [dbo].[Movie] ([Id], [Name], [Genres], [DirectorId], [ReleaseYear]) VALUES (2, N'Captain America :The First Avenger', N'Action', 1, 2011)
SET IDENTITY_INSERT [dbo].[Movie] OFF
SET IDENTITY_INSERT [dbo].[MovieCastAssignment] ON
INSERT INTO [dbo].[MovieCastAssignment] ([Id], [ActorId], [MovieId]) VALUES (1, 1, 1)
INSERT INTO [dbo].[MovieCastAssignment] ([Id], [ActorId], [MovieId]) VALUES (2, 2, 1)
INSERT INTO [dbo].[MovieCastAssignment] ([Id], [ActorId], [MovieId]) VALUES (3, 4, 2)
SET IDENTITY_INSERT [dbo].[MovieCastAssignment] OFF
