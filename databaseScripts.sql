/****** Object:  Table [dbo].[Customers]    Script Date: 9/18/2018 4:32:03 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Customers](
	[customerID] [int] IDENTITY(1,1) NOT NULL,
	[firstName] [varchar](16) NULL,
	[lastName] [varchar](50) NULL,
	[street] [varchar](50) NULL,
	[city] [varchar](50) NULL,
	[state] [varchar](2) NULL,
	[zip] [varchar](5) NULL,
	[email] [varchar](50) NULL,
 CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED 
(
	[customerID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


/****** Object:  Table [dbo].[Jobs]    Script Date: 9/18/2018 4:32:24 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Jobs](
	[jobID] [int] IDENTITY(1,1) NOT NULL,
	[customerID] [int] NOT NULL,
	[street] [varchar](50) NULL,
	[city] [varchar](50) NULL,
	[state] [varchar](2) NULL,
	[zip] [varchar](5) NULL,
	[startDate] [datetime] NULL,
	[estimatedCompletionDate] [datetime] NULL,
	[completionDate] [datetime] NULL,
	[estimatedJobCost] [float] NULL,
	[completedJobCost] [float] NULL,
 CONSTRAINT [PK_Jobs] PRIMARY KEY CLUSTERED 
(
	[jobID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[Transactions]    Script Date: 9/18/2018 4:32:38 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Transactions](
	[transactionID] [int] IDENTITY(1,1) NOT NULL,
	[jobID] [int] NOT NULL,
	[userID] [int] NOT NULL,
	[payment] [float] NULL,
	[originalJobCost] [float] NULL,
	[newJobCost] [float] NULL,
 CONSTRAINT [PK_Transactions] PRIMARY KEY CLUSTERED 
(
	[transactionID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[Users]    Script Date: 9/18/2018 4:32:56 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Users](
	[userID] [int] IDENTITY(1,1) NOT NULL,
	[firstName] [varchar](20) NULL,
	[lastName] [varchar](20) NULL,
	[accountName] [varchar](20) NULL,
	[password] [varchar](100) NULL,
	[salt] [varchar](50) NULL,
	[role] [int] NULL,
	[creationDate] [datetime] NULL,
	[passwordResetFlag] [bit] NULL,
	[email] [varchar](50) NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[userID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

