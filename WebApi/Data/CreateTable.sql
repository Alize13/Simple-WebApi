USE [TestAA]
GO

/****** Object:  Table [dbo].[Member]    Script Date: 2022/5/10 �U�� 10:27:46 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Member](
	[MemberID] [int] IDENTITY(1,1) NOT NULL,
	[MemberAccount] [varchar](30) NULL,
	[MemberPwd] [varchar](50) NULL,
	[MemberName] [nvarchar](70) NULL,
	[MemberEmail] [nvarchar](50) NULL,
	[MemberLevel] [smallint] NULL,
	[MemberSalaly] [decimal](16, 4) NULL,
	[MemberInterests] [varchar](200) NULL,
	[MemberStatus] [bit] NULL,
	[CreateUser] [varchar](30) NULL,
	[CreateDateTime] [datetime] NULL,
 CONSTRAINT [PK_Member] PRIMARY KEY CLUSTERED 
(
	[MemberID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Member] ADD  CONSTRAINT [DF_Member_MemberStatus]  DEFAULT ((1)) FOR [MemberStatus]
GO

ALTER TABLE [dbo].[Member] ADD  CONSTRAINT [DF_Member_CreateDateTime]  DEFAULT (getdate()) FOR [CreateDateTime]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�|���b��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Member', @level2type=N'COLUMN',@level2name=N'MemberAccount'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�|���K�X' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Member', @level2type=N'COLUMN',@level2name=N'MemberPwd'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�ʺ�' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Member', @level2type=N'COLUMN',@level2name=N'MemberName'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Email' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Member', @level2type=N'COLUMN',@level2name=N'MemberEmail'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�|������' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Member', @level2type=N'COLUMN',@level2name=N'MemberLevel'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�|�����J' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Member', @level2type=N'COLUMN',@level2name=N'MemberSalaly'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�|������' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Member', @level2type=N'COLUMN',@level2name=N'MemberInterests'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�b�����A0����1�ҥ�' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Member', @level2type=N'COLUMN',@level2name=N'MemberStatus'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�إߪ�' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Member', @level2type=N'COLUMN',@level2name=N'CreateUser'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�إߤ��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Member', @level2type=N'COLUMN',@level2name=N'CreateDateTime'
GO


CREATE TABLE [dbo].[MemberLevels](
	[LevelID] [tinyint] IDENTITY(1,1) NOT NULL,
	[MemberLevel] [smallint] NOT NULL,
	[LevelName] [nvarchar](50) NULL,
 CONSTRAINT [PK_MemberLevel] PRIMARY KEY CLUSTERED 
(
	[MemberLevel] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�|������' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MemberLevels', @level2type=N'COLUMN',@level2name=N'MemberLevel'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'���ŦW��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MemberLevels', @level2type=N'COLUMN',@level2name=N'LevelName'
GO

CREATE TABLE [dbo].[Interests](
	[InterestID] [tinyint] IDENTITY(1,1) NOT NULL,
	[Interest] [nvarchar](50) NULL,
 CONSTRAINT [PK_Interests] PRIMARY KEY CLUSTERED 
(
	[InterestID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO