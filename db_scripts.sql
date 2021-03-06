USE [ticketizer]
GO
/****** Object:  Table [dbo].[admins]    Script Date: 3/9/2017 3:59:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[admins](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](255) NULL,
	[login_name] [varchar](50) NULL,
	[password] [varchar](50) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[articles]    Script Date: 3/9/2017 3:59:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[articles](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[title] [varchar](255) NULL,
	[date_created] [datetime] NULL,
	[text] [text] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[departments]    Script Date: 3/9/2017 3:59:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[departments](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](255) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[notes]    Script Date: 3/9/2017 3:59:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[notes](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[date_created] [datetime] NULL,
	[admin_id] [int] NULL,
	[ticket_id] [int] NULL,
	[text] [text] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tickets]    Script Date: 3/9/2017 3:59:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tickets](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[ticket_number] [datetime] NULL,
	[product] [varchar](255) NULL,
	[department_id] [int] NULL,
	[severity] [varchar](255) NULL,
	[description] [text] NULL,
	[user_id] [int] NULL,
	[open_status] [tinyint] NULL,
	[status] [varchar](255) NULL,
	[converted_ticket_number] [varchar](255) NULL,
	[closed_date] [date] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tickets_admins]    Script Date: 3/9/2017 3:59:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tickets_admins](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[ticket_id] [int] NULL,
	[admin_id] [int] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tickets_articles]    Script Date: 3/9/2017 3:59:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tickets_articles](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[ticket_id] [int] NULL,
	[article_id] [int] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[users]    Script Date: 3/9/2017 3:59:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[users](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](255) NULL,
	[address] [varchar](255) NULL,
	[phone] [varchar](255) NULL,
	[email] [varchar](255) NULL
) ON [PRIMARY]

GO
