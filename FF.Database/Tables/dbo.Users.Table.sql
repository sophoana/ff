CREATE TABLE [dbo].[Users](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[UserLevelId] [int] NOT NULL,
	[Username] [varchar](50) NOT NULL,
	[DisplayName] [varchar](50) NOT NULL,
	[HomeZipCode] [varchar](15) NULL,
	[HomeCoordinates] [geography] NULL,
	[AddedBy] [int] NOT NULL,
	[AddedWhen] [datetime] NOT NULL CONSTRAINT [DF_Users_AddedWhen]  DEFAULT (getutcdate()),
	[UpdatedBy] [int] NOT NULL,
	[UpdatedWhen] [datetime] NOT NULL CONSTRAINT [DF_Users_UpdatedWhen]  DEFAULT (getutcdate()),
	[IsApproved] [bit] NOT NULL CONSTRAINT [DF_Users_IsApproved_1]  DEFAULT ((1)),
	[IsActive] [bit] NOT NULL CONSTRAINT [DF_Users_IsActive]  DEFAULT ((1)),
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_UserLevels] FOREIGN KEY([UserLevelId])
REFERENCES [dbo].[UserLevels] ([UserLevelId])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_UserLevels]
GO
