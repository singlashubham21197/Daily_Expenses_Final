INSERT INTO [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'1d6170fe-8a84-4e99-9c76-94f9d1d198e1', N'user', N'user', N'91ea02da-9cd1-4a39-abc8-a1778a660f0c')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'c0332d1b-a513-4132-a50b-53825f889e6d', N'admin', N'admin', N'14eb3783-447e-49e1-906f-baf33f79b5f8')
INSERT INTO [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'21326691-b792-4d99-9d6a-34a6d5ecbc5c', N'harry@expenses.com', N'HARRY@EXPENSES.COM', N'harry@expenses.com', N'HARRY@EXPENSES.COM', 1, N'AQAAAAEAACcQAAAAEHx3ygAFxqZP5a/hxvPCjWtfNkTuAwWP/G+YLsIC6wPFUBoRexUPVAfDOF5sEOxcrA==', N'XN5ZEUTB2KAMABBTJRGFV5B2TDOJYBBW', N'65d49e4b-5d1f-46f1-98de-d3b386b9e1db', NULL, 0, 0, NULL, 1, 0)
INSERT INTO [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'4f8e3103-90bd-40a7-9d28-966271857842', N'jane@expenses.com', N'JANE@EXPENSES.COM', N'jane@expenses.com', N'JANE@EXPENSES.COM', 1, N'AQAAAAEAACcQAAAAEBtIVdBmsaqRjcei3Gzdk+t5iKk5xgJW5bDuUDvP9Wlmh3vPNYzGJDEyYBG2/lpXUA==', N'LIX2XAO5V7SKHNRMNUUKDLYEDTH7A3NN', N'920d22fc-2138-4d13-b53b-62a623a5c036', NULL, 0, 0, NULL, 1, 0)
INSERT INTO [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'c8c2432c-dffe-4b03-aa99-762888a6c95b', N'admin@expenses.com', N'ADMIN@EXPENSES.COM', N'admin@expenses.com', N'ADMIN@EXPENSES.COM', 1, N'AQAAAAEAACcQAAAAEO7sHwzkg59yisRti8Nq4rwVz3IQk1xVLCq1fpLd5cvsJ5PZUezwfrx6mgGmywwb9g==', N'LOEFJBHAZ375G7XJFMSCBD5YFMAVQPRZ', N'f27c4fa9-e989-41f7-824b-e10346f10d2f', NULL, 0, 0, NULL, 1, 0)
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'21326691-b792-4d99-9d6a-34a6d5ecbc5c', N'1d6170fe-8a84-4e99-9c76-94f9d1d198e1')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'4f8e3103-90bd-40a7-9d28-966271857842', N'1d6170fe-8a84-4e99-9c76-94f9d1d198e1')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'c8c2432c-dffe-4b03-aa99-762888a6c95b', N'c0332d1b-a513-4132-a50b-53825f889e6d')
SET IDENTITY_INSERT [dbo].[UserAccount] ON
INSERT INTO [dbo].[UserAccount] ([Id], [Name], [Email]) VALUES (1, N'Harry Davidson', N'harry@expenses.com')
INSERT INTO [dbo].[UserAccount] ([Id], [Name], [Email]) VALUES (2, N'Jane Watson', N'jane@expenses.com')
SET IDENTITY_INSERT [dbo].[UserAccount] OFF
SET IDENTITY_INSERT [dbo].[ExpenseRecord] ON
INSERT INTO [dbo].[ExpenseRecord] ([Id], [UserAccountId], [Description], [Amount], [Date]) VALUES (1, 1, N'TV set ', CAST(900.00 AS Decimal(18, 2)), N'2020-04-10 00:00:00')
INSERT INTO [dbo].[ExpenseRecord] ([Id], [UserAccountId], [Description], [Amount], [Date]) VALUES (2, 1, N'Color wash ', CAST(400.00 AS Decimal(18, 2)), N'2020-04-16 00:00:00')
INSERT INTO [dbo].[ExpenseRecord] ([Id], [UserAccountId], [Description], [Amount], [Date]) VALUES (3, 1, N'party ', CAST(600.00 AS Decimal(18, 2)), N'2020-04-23 00:00:00')
INSERT INTO [dbo].[ExpenseRecord] ([Id], [UserAccountId], [Description], [Amount], [Date]) VALUES (4, 1, N'groceries ', CAST(40.00 AS Decimal(18, 2)), N'2020-04-18 00:00:00')
INSERT INTO [dbo].[ExpenseRecord] ([Id], [UserAccountId], [Description], [Amount], [Date]) VALUES (5, 1, N'water bill', CAST(150.00 AS Decimal(18, 2)), N'2020-04-25 00:00:00')
INSERT INTO [dbo].[ExpenseRecord] ([Id], [UserAccountId], [Description], [Amount], [Date]) VALUES (6, 1, N'Water bill', CAST(120.00 AS Decimal(18, 2)), N'2020-05-15 00:00:00')
INSERT INTO [dbo].[ExpenseRecord] ([Id], [UserAccountId], [Description], [Amount], [Date]) VALUES (7, 1, N'Groceries ', CAST(35.00 AS Decimal(18, 2)), N'2020-05-08 00:00:00')
INSERT INTO [dbo].[ExpenseRecord] ([Id], [UserAccountId], [Description], [Amount], [Date]) VALUES (8, 1, N'Mobile Top up', CAST(20.00 AS Decimal(18, 2)), N'2020-05-14 00:00:00')
INSERT INTO [dbo].[ExpenseRecord] ([Id], [UserAccountId], [Description], [Amount], [Date]) VALUES (9, 1, N'Travelling', CAST(25.00 AS Decimal(18, 2)), N'2020-05-22 00:00:00')
INSERT INTO [dbo].[ExpenseRecord] ([Id], [UserAccountId], [Description], [Amount], [Date]) VALUES (10, 2, N'Travel expense', CAST(50.00 AS Decimal(18, 2)), N'2020-05-22 00:00:00')
INSERT INTO [dbo].[ExpenseRecord] ([Id], [UserAccountId], [Description], [Amount], [Date]) VALUES (11, 2, N'Groceries ', CAST(40.00 AS Decimal(18, 2)), N'2020-05-22 00:00:00')
INSERT INTO [dbo].[ExpenseRecord] ([Id], [UserAccountId], [Description], [Amount], [Date]) VALUES (12, 2, N'Electricity Bill', CAST(100.00 AS Decimal(18, 2)), N'2020-04-17 00:00:00')
INSERT INTO [dbo].[ExpenseRecord] ([Id], [UserAccountId], [Description], [Amount], [Date]) VALUES (13, 2, N'Internet connection ', CAST(80.00 AS Decimal(18, 2)), N'2020-04-25 00:00:00')
SET IDENTITY_INSERT [dbo].[ExpenseRecord] OFF
SET IDENTITY_INSERT [dbo].[MontlyExpenseReport] ON
INSERT INTO [dbo].[MontlyExpenseReport] ([Id], [UserAccountId], [Year], [Month], [TotalExpenses]) VALUES (5, 1, 2020, 5, CAST(200.00 AS Decimal(18, 2)))
INSERT INTO [dbo].[MontlyExpenseReport] ([Id], [UserAccountId], [Year], [Month], [TotalExpenses]) VALUES (6, 1, 2020, 4 , CAST(2090.00 AS Decimal(18, 2)))
INSERT INTO [dbo].[MontlyExpenseReport] ([Id], [UserAccountId], [Year], [Month], [TotalExpenses]) VALUES (7, 2, 2020, 5, CAST(90.00 AS Decimal(18, 2)))
INSERT INTO [dbo].[MontlyExpenseReport] ([Id], [UserAccountId], [Year], [Month], [TotalExpenses]) VALUES (8, 2, 2020, 4, CAST(180.00 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[MontlyExpenseReport] OFF
