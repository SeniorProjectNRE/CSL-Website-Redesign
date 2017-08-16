USE [CSL]
GO

/****** Object:  Table [dbo].[AddBlog]    Script Date: 8/16/2017 4:29:06 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[AddBlog](
	[BlogID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [varchar](100) NOT NULL,
	[Description] [varchar](max) NOT NULL,
	[Date] [datetime] NOT NULL,
 CONSTRAINT [PK_AddBlogID] PRIMARY KEY CLUSTERED 
(
	[BlogID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[AddBlog] ADD  CONSTRAINT [DF_AddBlog_Date]  DEFAULT (getdate()) FOR [Date]
GO

--4:30 8/16/17 matt ran to here