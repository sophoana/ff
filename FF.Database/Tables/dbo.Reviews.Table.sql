CREATE TABLE [dbo].[Reviews](
	[ReviewId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[LocationId] [int] NOT NULL,
	[FruitId] [int] NOT NULL,
	[AquiredWhen] [datetime] NOT NULL,
	[UserRating] [int] NOT NULL,
	[Comment] [nvarchar](200) NULL,
	[Image] [varbinary](max) NULL,
	[RecordedWhen] [datetime] NOT NULL,
	[FreshnessScore] [float] NOT NULL,
	[VoteTally] [int] NOT NULL,
	[AddedBy] [int] NOT NULL,
	[AddedWhen] [datetime] NOT NULL,
	[UpdatedBy] [int] NOT NULL,
	[UpdatedWhen] [datetime] NOT NULL,
	[IsApproved] [bit] NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_Reviews] PRIMARY KEY CLUSTERED 
(
	[ReviewId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
ALTER TABLE [dbo].[Reviews] ADD  CONSTRAINT [DF_Reviews_AquiredWhen]  DEFAULT (getutcdate()) FOR [AquiredWhen]
GO
ALTER TABLE [dbo].[Reviews] ADD  CONSTRAINT [DF_Reviews_Quality]  DEFAULT ((0)) FOR [UserRating]
GO
ALTER TABLE [dbo].[Reviews] ADD  CONSTRAINT [DF_Reviews_RecordedWhen]  DEFAULT (getutcdate()) FOR [RecordedWhen]
GO
ALTER TABLE [dbo].[Reviews] ADD  CONSTRAINT [DF_Reviews_FreshnessScore]  DEFAULT ((0)) FOR [FreshnessScore]
GO
ALTER TABLE [dbo].[Reviews] ADD  CONSTRAINT [DF_Review_Votes]  DEFAULT ((0)) FOR [VoteTally]
GO
ALTER TABLE [dbo].[Reviews] ADD  CONSTRAINT [DF_Reviews_AddedWhen]  DEFAULT (getutcdate()) FOR [AddedWhen]
GO
ALTER TABLE [dbo].[Reviews] ADD  CONSTRAINT [DF_Reviews_UpdatedWhen]  DEFAULT (getutcdate()) FOR [UpdatedWhen]
GO
ALTER TABLE [dbo].[Reviews] ADD  CONSTRAINT [DF_Reviews_IsApproved]  DEFAULT ((1)) FOR [IsApproved]
GO
ALTER TABLE [dbo].[Reviews] ADD  CONSTRAINT [DF_Reviews_Active]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[Reviews]  WITH CHECK ADD  CONSTRAINT [FK_Reviews_Fruits] FOREIGN KEY([FruitId])
REFERENCES [dbo].[Fruits] ([FruitId])
GO
ALTER TABLE [dbo].[Reviews] CHECK CONSTRAINT [FK_Reviews_Fruits]
GO
ALTER TABLE [dbo].[Reviews]  WITH CHECK ADD  CONSTRAINT [FK_Reviews_Locations] FOREIGN KEY([LocationId])
REFERENCES [dbo].[Locations] ([LocationId])
GO
ALTER TABLE [dbo].[Reviews] CHECK CONSTRAINT [FK_Reviews_Locations]
GO
ALTER TABLE [dbo].[Reviews]  WITH CHECK ADD  CONSTRAINT [FK_Reviews_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[Reviews] CHECK CONSTRAINT [FK_Reviews_Users]
GO
