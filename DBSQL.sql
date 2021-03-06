USE [ETM]
GO
/****** Object:  Table [dbo].[category]    Script Date: 12/19/2018 3:19:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[category](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_category] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[client]    Script Date: 12/19/2018 3:19:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[client](
	[client_id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NOT NULL,
	[address] [nvarchar](200) NULL,
 CONSTRAINT [PK_client] PRIMARY KEY CLUSTERED 
(
	[client_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[designation]    Script Date: 12/19/2018 3:19:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[designation](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NOT NULL,
	[category_id] [int] NULL,
 CONSTRAINT [PK_designation] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[employee]    Script Date: 12/19/2018 3:19:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[employee](
	[employee_id] [int] IDENTITY(1,1) NOT NULL,
	[employee_name] [varchar](50) NOT NULL,
	[designation_id] [int] NOT NULL,
	[date_of_join] [date] NOT NULL,
	[team_id] [int] NULL,
	[category_id] [int] NULL,
	[joining_ctc] [decimal](16, 2) NULL,
	[status] [int] NULL,
	[project_billing_status] [int] NULL,
	[experience_before_joining] [int] NULL,
	[technology_id] [int] NULL,
	[remarks] [ntext] NULL,
 CONSTRAINT [PK_employee] PRIMARY KEY CLUSTERED 
(
	[employee_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[employee_appraisal]    Script Date: 12/19/2018 3:19:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[employee_appraisal](
	[employee_id] [int] NOT NULL,
	[previous_designation] [int] NOT NULL,
	[new_designation] [int] NOT NULL,
	[previous_ctc] [decimal](18, 0) NOT NULL,
	[new_ctc] [decimal](18, 0) NOT NULL,
	[date] [datetime] NOT NULL,
	[comments] [nvarchar](250) NOT NULL,
 CONSTRAINT [PK_employee_appraisal] PRIMARY KEY CLUSTERED 
(
	[employee_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[employee_status]    Script Date: 12/19/2018 3:19:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[employee_status](
	[id] [int] NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[description] [nvarchar](150) NULL,
 CONSTRAINT [PK_status] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[employee_task]    Script Date: 12/19/2018 3:19:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[employee_task](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NULL,
	[task_type] [int] NULL,
 CONSTRAINT [PK_task] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[employee_technology]    Script Date: 12/19/2018 3:19:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[employee_technology](
	[employee_id] [int] NOT NULL,
	[technology_id] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[project]    Script Date: 12/19/2018 3:19:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[project](
	[project_id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NOT NULL,
	[project_manager_id] [int] NOT NULL,
	[client_id] [int] NOT NULL,
	[start_date] [date] NOT NULL,
	[end_date] [date] NOT NULL,
	[comments] [nvarchar](250) NULL,
 CONSTRAINT [PK_project] PRIMARY KEY CLUSTERED 
(
	[project_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[project_resources]    Script Date: 12/19/2018 3:19:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[project_resources](
	[project_id] [int] NOT NULL,
	[category_id] [int] NOT NULL,
	[number_of_resource] [int] NOT NULL,
	[designation_id] [int] NOT NULL,
	[isapproved] [tinyint] NOT NULL,
	[isshadow] [tinyint] NOT NULL,
	[comments] [nvarchar](250) NULL,
 CONSTRAINT [PK_project_resources] PRIMARY KEY CLUSTERED 
(
	[project_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[project_skills]    Script Date: 12/19/2018 3:19:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[project_skills](
	[project_id] [int] NOT NULL,
	[primary_skill_ids] [nvarchar](200) NULL,
	[seconday_skill_ids] [nvarchar](200) NULL,
 CONSTRAINT [PK_project_skills] PRIMARY KEY CLUSTERED 
(
	[project_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 12/19/2018 3:19:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[Id] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[task_team]    Script Date: 12/19/2018 3:19:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[task_team](
	[task_id] [int] NOT NULL,
	[team_id] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[team]    Script Date: 12/19/2018 3:19:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[team](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NOT NULL,
	[project_id] [int] NULL,
	[setup_date] [date] NULL,
 CONSTRAINT [PK_team] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[technology]    Script Date: 12/19/2018 3:19:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[technology](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NOT NULL,
	[isprimary] [tinyint] NULL,
 CONSTRAINT [PK_technology] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[timesheet]    Script Date: 12/19/2018 3:19:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[timesheet](
	[timesheet_id] [bigint] IDENTITY(1,1) NOT NULL,
	[employee_id] [int] NOT NULL,
	[task_id] [int] NOT NULL,
	[date] [date] NULL,
	[hour] [decimal](18, 2) NULL,
 CONSTRAINT [PK_timesheet] PRIMARY KEY CLUSTERED 
(
	[timesheet_id] ASC,
	[employee_id] ASC,
	[task_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 12/19/2018 3:19:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NULL,
	[LoggedOn] [nvarchar](50) NOT NULL
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[category] ON 

INSERT [dbo].[category] ([id], [name]) VALUES (1, N'QA')
INSERT [dbo].[category] ([id], [name]) VALUES (2, N'Development')
INSERT [dbo].[category] ([id], [name]) VALUES (3, N'Business Analysis')
INSERT [dbo].[category] ([id], [name]) VALUES (4, N'HR')
INSERT [dbo].[category] ([id], [name]) VALUES (5, N'Operation')
INSERT [dbo].[category] ([id], [name]) VALUES (6, N'Project Management')
INSERT [dbo].[category] ([id], [name]) VALUES (7, N'IT')
SET IDENTITY_INSERT [dbo].[category] OFF
SET IDENTITY_INSERT [dbo].[client] ON 

INSERT [dbo].[client] ([client_id], [name], [address]) VALUES (1, N'GHX', NULL)
INSERT [dbo].[client] ([client_id], [name], [address]) VALUES (2, N'SRS', NULL)
INSERT [dbo].[client] ([client_id], [name], [address]) VALUES (3, N'RSI', NULL)
INSERT [dbo].[client] ([client_id], [name], [address]) VALUES (4, N'PP', NULL)
INSERT [dbo].[client] ([client_id], [name], [address]) VALUES (5, N'Elemica', NULL)
INSERT [dbo].[client] ([client_id], [name], [address]) VALUES (6, N'ABC', NULL)
SET IDENTITY_INSERT [dbo].[client] OFF
SET IDENTITY_INSERT [dbo].[designation] ON 

INSERT [dbo].[designation] ([id], [name], [category_id]) VALUES (1, N'Software Developer', 2)
INSERT [dbo].[designation] ([id], [name], [category_id]) VALUES (2, N'Senior Software Developer', 2)
INSERT [dbo].[designation] ([id], [name], [category_id]) VALUES (3, N'Module Lead', 2)
INSERT [dbo].[designation] ([id], [name], [category_id]) VALUES (4, N'Team Lead', 2)
INSERT [dbo].[designation] ([id], [name], [category_id]) VALUES (5, N'Technical Lead', 2)
INSERT [dbo].[designation] ([id], [name], [category_id]) VALUES (6, N'Technical Manager', 6)
INSERT [dbo].[designation] ([id], [name], [category_id]) VALUES (8, N'Business Analyst', 3)
INSERT [dbo].[designation] ([id], [name], [category_id]) VALUES (9, N'Architect', 2)
INSERT [dbo].[designation] ([id], [name], [category_id]) VALUES (10, N'Scrum Master', 6)
INSERT [dbo].[designation] ([id], [name], [category_id]) VALUES (11, N'Project Manager', 6)
INSERT [dbo].[designation] ([id], [name], [category_id]) VALUES (12, N'Fresher', 2)
INSERT [dbo].[designation] ([id], [name], [category_id]) VALUES (13, N'Test Engineer', 1)
INSERT [dbo].[designation] ([id], [name], [category_id]) VALUES (14, N'Senior Test Engineer', 1)
INSERT [dbo].[designation] ([id], [name], [category_id]) VALUES (15, N'Test Lead', 1)
SET IDENTITY_INSERT [dbo].[designation] OFF
SET IDENTITY_INSERT [dbo].[employee] ON 

INSERT [dbo].[employee] ([employee_id], [employee_name], [designation_id], [date_of_join], [team_id], [category_id], [joining_ctc], [status], [project_billing_status], [experience_before_joining], [technology_id], [remarks]) VALUES (2, N'GGGGGGG', 5, CAST(N'2014-01-01' AS Date), 1, 2, CAST(1234.00 AS Decimal(16, 2)), 1, 1, 5, 1, NULL)
INSERT [dbo].[employee] ([employee_id], [employee_name], [designation_id], [date_of_join], [team_id], [category_id], [joining_ctc], [status], [project_billing_status], [experience_before_joining], [technology_id], [remarks]) VALUES (3, N'AAAAA', 6, CAST(N'2015-01-01' AS Date), 2, 6, CAST(1235.00 AS Decimal(16, 2)), 1, 1, 7, 1, NULL)
INSERT [dbo].[employee] ([employee_id], [employee_name], [designation_id], [date_of_join], [team_id], [category_id], [joining_ctc], [status], [project_billing_status], [experience_before_joining], [technology_id], [remarks]) VALUES (6, N'SSSSSSSS', 6, CAST(N'2014-01-01' AS Date), 3, 6, CAST(1236.00 AS Decimal(16, 2)), 1, 1, 5, 1, NULL)
INSERT [dbo].[employee] ([employee_id], [employee_name], [designation_id], [date_of_join], [team_id], [category_id], [joining_ctc], [status], [project_billing_status], [experience_before_joining], [technology_id], [remarks]) VALUES (10, N'BBBBBBBBB', 2, CAST(N'2014-01-01' AS Date), 2, 2, CAST(1234.00 AS Decimal(16, 2)), 1, 1, 3, 1, NULL)
INSERT [dbo].[employee] ([employee_id], [employee_name], [designation_id], [date_of_join], [team_id], [category_id], [joining_ctc], [status], [project_billing_status], [experience_before_joining], [technology_id], [remarks]) VALUES (11, N'RRRRR', 3, CAST(N'2014-01-01' AS Date), 2, 2, CAST(1234.00 AS Decimal(16, 2)), 1, 1, 6, 1, NULL)
INSERT [dbo].[employee] ([employee_id], [employee_name], [designation_id], [date_of_join], [team_id], [category_id], [joining_ctc], [status], [project_billing_status], [experience_before_joining], [technology_id], [remarks]) VALUES (12, N'QA Name', 14, CAST(N'2014-01-01' AS Date), 2, 1, CAST(1234.00 AS Decimal(16, 2)), 1, 0, 4, 1, NULL)
INSERT [dbo].[employee] ([employee_id], [employee_name], [designation_id], [date_of_join], [team_id], [category_id], [joining_ctc], [status], [project_billing_status], [experience_before_joining], [technology_id], [remarks]) VALUES (13, N'CCCCCCCC', 1, CAST(N'2014-01-01' AS Date), 2, 2, CAST(1234.00 AS Decimal(16, 2)), 1, 1, 2, 1, NULL)
INSERT [dbo].[employee] ([employee_id], [employee_name], [designation_id], [date_of_join], [team_id], [category_id], [joining_ctc], [status], [project_billing_status], [experience_before_joining], [technology_id], [remarks]) VALUES (14, N'GHX-PM', 6, CAST(N'2011-01-01' AS Date), 6, 6, CAST(1234.00 AS Decimal(16, 2)), 1, 1, 2, 1, NULL)
INSERT [dbo].[employee] ([employee_id], [employee_name], [designation_id], [date_of_join], [team_id], [category_id], [joining_ctc], [status], [project_billing_status], [experience_before_joining], [technology_id], [remarks]) VALUES (15, N'ABC-PM', 6, CAST(N'2011-01-01' AS Date), 17, 6, CAST(1234.00 AS Decimal(16, 2)), 1, 1, 2, 2, NULL)
SET IDENTITY_INSERT [dbo].[employee] OFF
SET IDENTITY_INSERT [dbo].[employee_task] ON 

INSERT [dbo].[employee_task] ([id], [name], [task_type]) VALUES (1, N'Analysis', 1)
INSERT [dbo].[employee_task] ([id], [name], [task_type]) VALUES (2, N'Coding', 1)
INSERT [dbo].[employee_task] ([id], [name], [task_type]) VALUES (3, N'Code Review', 1)
INSERT [dbo].[employee_task] ([id], [name], [task_type]) VALUES (4, N'Unit Testing', 1)
INSERT [dbo].[employee_task] ([id], [name], [task_type]) VALUES (5, N'Adhoc Meeting', 3)
INSERT [dbo].[employee_task] ([id], [name], [task_type]) VALUES (6, N'Daily Standup', 3)
INSERT [dbo].[employee_task] ([id], [name], [task_type]) VALUES (7, N'Test Case Creation', 2)
INSERT [dbo].[employee_task] ([id], [name], [task_type]) VALUES (8, N'Test Case Execution', 2)
INSERT [dbo].[employee_task] ([id], [name], [task_type]) VALUES (9, N'Temp Task', 1)
INSERT [dbo].[employee_task] ([id], [name], [task_type]) VALUES (10, N'Weekly Sync Up', 0)
INSERT [dbo].[employee_task] ([id], [name], [task_type]) VALUES (11, N'Sprint Review Meeting', 0)
INSERT [dbo].[employee_task] ([id], [name], [task_type]) VALUES (12, N'asd', 0)
SET IDENTITY_INSERT [dbo].[employee_task] OFF
SET IDENTITY_INSERT [dbo].[project] ON 

INSERT [dbo].[project] ([project_id], [name], [project_manager_id], [client_id], [start_date], [end_date], [comments]) VALUES (6, N'PT', 3, 4, CAST(N'2014-01-01' AS Date), CAST(N'2025-01-01' AS Date), NULL)
INSERT [dbo].[project] ([project_id], [name], [project_manager_id], [client_id], [start_date], [end_date], [comments]) VALUES (38, N'Lease', 3, 4, CAST(N'2012-12-12' AS Date), CAST(N'0001-01-01' AS Date), NULL)
INSERT [dbo].[project] ([project_id], [name], [project_manager_id], [client_id], [start_date], [end_date], [comments]) VALUES (39, N'CQM', 6, 2, CAST(N'0001-01-01' AS Date), CAST(N'0001-01-01' AS Date), NULL)
INSERT [dbo].[project] ([project_id], [name], [project_manager_id], [client_id], [start_date], [end_date], [comments]) VALUES (40, N'RX', 6, 2, CAST(N'2011-01-01' AS Date), CAST(N'2025-01-01' AS Date), NULL)
INSERT [dbo].[project] ([project_id], [name], [project_manager_id], [client_id], [start_date], [end_date], [comments]) VALUES (43, N'MESSEGING', 6, 2, CAST(N'2011-01-01' AS Date), CAST(N'2022-01-01' AS Date), NULL)
INSERT [dbo].[project] ([project_id], [name], [project_manager_id], [client_id], [start_date], [end_date], [comments]) VALUES (44, N'CS', 6, 2, CAST(N'2011-01-01' AS Date), CAST(N'2022-01-01' AS Date), NULL)
INSERT [dbo].[project] ([project_id], [name], [project_manager_id], [client_id], [start_date], [end_date], [comments]) VALUES (45, N'GHX-PRJ-1', 14, 1, CAST(N'2011-01-01' AS Date), CAST(N'2022-01-01' AS Date), NULL)
INSERT [dbo].[project] ([project_id], [name], [project_manager_id], [client_id], [start_date], [end_date], [comments]) VALUES (46, N'ABC-PRJ-1', 15, 6, CAST(N'2015-01-01' AS Date), CAST(N'2022-01-01' AS Date), NULL)
INSERT [dbo].[project] ([project_id], [name], [project_manager_id], [client_id], [start_date], [end_date], [comments]) VALUES (47, N'sdfsf', 2, 2, CAST(N'2018-12-13' AS Date), CAST(N'0001-01-01' AS Date), NULL)
INSERT [dbo].[project] ([project_id], [name], [project_manager_id], [client_id], [start_date], [end_date], [comments]) VALUES (51, N'asd', 2, 2, CAST(N'2018-12-14' AS Date), CAST(N'0001-01-01' AS Date), N'approved X + Shadow Y')
INSERT [dbo].[project] ([project_id], [name], [project_manager_id], [client_id], [start_date], [end_date], [comments]) VALUES (52, N'P1', 2, 2, CAST(N'2018-12-14' AS Date), CAST(N'0001-01-01' AS Date), N'Approved X + Y Shadow')
INSERT [dbo].[project] ([project_id], [name], [project_manager_id], [client_id], [start_date], [end_date], [comments]) VALUES (53, N'P1', 2, 2, CAST(N'2018-12-14' AS Date), CAST(N'0001-01-01' AS Date), N'Approved X + Y Shadow')
INSERT [dbo].[project] ([project_id], [name], [project_manager_id], [client_id], [start_date], [end_date], [comments]) VALUES (54, N'P1', 2, 2, CAST(N'2018-12-14' AS Date), CAST(N'0001-01-01' AS Date), N'Approved X + Y Shadow')
INSERT [dbo].[project] ([project_id], [name], [project_manager_id], [client_id], [start_date], [end_date], [comments]) VALUES (55, N'P1', 2, 2, CAST(N'2018-12-14' AS Date), CAST(N'0001-01-01' AS Date), N'Approved X + Y Shadow')
INSERT [dbo].[project] ([project_id], [name], [project_manager_id], [client_id], [start_date], [end_date], [comments]) VALUES (56, N'P1', 2, 2, CAST(N'2018-12-14' AS Date), CAST(N'0001-01-01' AS Date), N'Approved X + Y Shadow')
INSERT [dbo].[project] ([project_id], [name], [project_manager_id], [client_id], [start_date], [end_date], [comments]) VALUES (59, N'P1', 2, 2, CAST(N'2018-12-14' AS Date), CAST(N'0001-01-01' AS Date), N'Approved X + Y Shadow')
INSERT [dbo].[project] ([project_id], [name], [project_manager_id], [client_id], [start_date], [end_date], [comments]) VALUES (60, N'P1', 2, 2, CAST(N'2018-12-14' AS Date), CAST(N'0001-01-01' AS Date), N'Approved X + Y Shadow')
INSERT [dbo].[project] ([project_id], [name], [project_manager_id], [client_id], [start_date], [end_date], [comments]) VALUES (61, N'P1', 2, 2, CAST(N'2018-12-14' AS Date), CAST(N'0001-01-01' AS Date), N'Approved X + Y Shadow')
INSERT [dbo].[project] ([project_id], [name], [project_manager_id], [client_id], [start_date], [end_date], [comments]) VALUES (62, N'P1', 2, 2, CAST(N'2018-12-14' AS Date), CAST(N'0001-01-01' AS Date), N'Approved X + Y Shadow')
INSERT [dbo].[project] ([project_id], [name], [project_manager_id], [client_id], [start_date], [end_date], [comments]) VALUES (63, N'P1', 2, 2, CAST(N'2018-12-14' AS Date), CAST(N'0001-01-01' AS Date), N'Approved X + Y Shadow')
SET IDENTITY_INSERT [dbo].[project] OFF
INSERT [dbo].[task_team] ([task_id], [team_id]) VALUES (1, 3)
INSERT [dbo].[task_team] ([task_id], [team_id]) VALUES (2, 3)
INSERT [dbo].[task_team] ([task_id], [team_id]) VALUES (4, 3)
INSERT [dbo].[task_team] ([task_id], [team_id]) VALUES (5, 3)
INSERT [dbo].[task_team] ([task_id], [team_id]) VALUES (1, 7)
INSERT [dbo].[task_team] ([task_id], [team_id]) VALUES (3, 7)
INSERT [dbo].[task_team] ([task_id], [team_id]) VALUES (5, 7)
INSERT [dbo].[task_team] ([task_id], [team_id]) VALUES (1, 4)
INSERT [dbo].[task_team] ([task_id], [team_id]) VALUES (4, 4)
INSERT [dbo].[task_team] ([task_id], [team_id]) VALUES (5, 4)
INSERT [dbo].[task_team] ([task_id], [team_id]) VALUES (8, 4)
INSERT [dbo].[task_team] ([task_id], [team_id]) VALUES (1, 6)
INSERT [dbo].[task_team] ([task_id], [team_id]) VALUES (2, 6)
INSERT [dbo].[task_team] ([task_id], [team_id]) VALUES (3, 6)
INSERT [dbo].[task_team] ([task_id], [team_id]) VALUES (4, 6)
INSERT [dbo].[task_team] ([task_id], [team_id]) VALUES (5, 6)
INSERT [dbo].[task_team] ([task_id], [team_id]) VALUES (2, 17)
INSERT [dbo].[task_team] ([task_id], [team_id]) VALUES (9, 17)
INSERT [dbo].[task_team] ([task_id], [team_id]) VALUES (10, 17)
INSERT [dbo].[task_team] ([task_id], [team_id]) VALUES (7, 17)
INSERT [dbo].[task_team] ([task_id], [team_id]) VALUES (4, 17)
INSERT [dbo].[task_team] ([task_id], [team_id]) VALUES (2, 17)
INSERT [dbo].[task_team] ([task_id], [team_id]) VALUES (6, 7)
INSERT [dbo].[task_team] ([task_id], [team_id]) VALUES (2, 3)
INSERT [dbo].[task_team] ([task_id], [team_id]) VALUES (3, 3)
INSERT [dbo].[task_team] ([task_id], [team_id]) VALUES (5, 3)
INSERT [dbo].[task_team] ([task_id], [team_id]) VALUES (1, 9)
INSERT [dbo].[task_team] ([task_id], [team_id]) VALUES (2, 9)
INSERT [dbo].[task_team] ([task_id], [team_id]) VALUES (3, 9)
INSERT [dbo].[task_team] ([task_id], [team_id]) VALUES (4, 9)
INSERT [dbo].[task_team] ([task_id], [team_id]) VALUES (1, 13)
INSERT [dbo].[task_team] ([task_id], [team_id]) VALUES (2, 13)
INSERT [dbo].[task_team] ([task_id], [team_id]) VALUES (2, 12)
INSERT [dbo].[task_team] ([task_id], [team_id]) VALUES (1, 23)
INSERT [dbo].[task_team] ([task_id], [team_id]) VALUES (2, 23)
INSERT [dbo].[task_team] ([task_id], [team_id]) VALUES (3, 23)
INSERT [dbo].[task_team] ([task_id], [team_id]) VALUES (4, 23)
INSERT [dbo].[task_team] ([task_id], [team_id]) VALUES (5, 23)
INSERT [dbo].[task_team] ([task_id], [team_id]) VALUES (6, 23)
INSERT [dbo].[task_team] ([task_id], [team_id]) VALUES (1, 6)
INSERT [dbo].[task_team] ([task_id], [team_id]) VALUES (2, 11)
INSERT [dbo].[task_team] ([task_id], [team_id]) VALUES (1, 9)
INSERT [dbo].[task_team] ([task_id], [team_id]) VALUES (2, 9)
INSERT [dbo].[task_team] ([task_id], [team_id]) VALUES (3, 9)
INSERT [dbo].[task_team] ([task_id], [team_id]) VALUES (5, 13)
INSERT [dbo].[task_team] ([task_id], [team_id]) VALUES (10, 13)
INSERT [dbo].[task_team] ([task_id], [team_id]) VALUES (11, 13)
INSERT [dbo].[task_team] ([task_id], [team_id]) VALUES (1, 21)
INSERT [dbo].[task_team] ([task_id], [team_id]) VALUES (3, 21)
INSERT [dbo].[task_team] ([task_id], [team_id]) VALUES (3, 8)
INSERT [dbo].[task_team] ([task_id], [team_id]) VALUES (5, 8)
INSERT [dbo].[task_team] ([task_id], [team_id]) VALUES (2, 20)
INSERT [dbo].[task_team] ([task_id], [team_id]) VALUES (3, 20)
SET IDENTITY_INSERT [dbo].[team] ON 

INSERT [dbo].[team] ([id], [name], [project_id], [setup_date]) VALUES (1, N'Megatrons', 38, CAST(N'2018-11-27' AS Date))
INSERT [dbo].[team] ([id], [name], [project_id], [setup_date]) VALUES (2, N'Ultron', 6, CAST(N'2018-11-27' AS Date))
INSERT [dbo].[team] ([id], [name], [project_id], [setup_date]) VALUES (3, N'Proton', 38, CAST(N'2018-11-27' AS Date))
INSERT [dbo].[team] ([id], [name], [project_id], [setup_date]) VALUES (4, N'Jumbo', 38, CAST(N'2018-11-27' AS Date))
INSERT [dbo].[team] ([id], [name], [project_id], [setup_date]) VALUES (5, N'CommonPool', NULL, CAST(N'2018-11-27' AS Date))
INSERT [dbo].[team] ([id], [name], [project_id], [setup_date]) VALUES (6, N'Crux', 39, CAST(N'2018-11-27' AS Date))
INSERT [dbo].[team] ([id], [name], [project_id], [setup_date]) VALUES (7, N'Zenith', 43, CAST(N'2018-11-27' AS Date))
INSERT [dbo].[team] ([id], [name], [project_id], [setup_date]) VALUES (8, N'Tekninja', 40, CAST(N'2018-11-27' AS Date))
INSERT [dbo].[team] ([id], [name], [project_id], [setup_date]) VALUES (9, N'Pinnacle', 44, CAST(N'2018-11-27' AS Date))
INSERT [dbo].[team] ([id], [name], [project_id], [setup_date]) VALUES (10, N'P-suite', 45, CAST(N'2018-11-27' AS Date))
INSERT [dbo].[team] ([id], [name], [project_id], [setup_date]) VALUES (11, N'XEP', 45, CAST(N'2018-11-27' AS Date))
INSERT [dbo].[team] ([id], [name], [project_id], [setup_date]) VALUES (12, N'Nuvia', 45, CAST(N'2018-11-27' AS Date))
INSERT [dbo].[team] ([id], [name], [project_id], [setup_date]) VALUES (13, N'ODAP', 45, CAST(N'2018-11-27' AS Date))
INSERT [dbo].[team] ([id], [name], [project_id], [setup_date]) VALUES (14, N'CCX', 45, CAST(N'2018-11-27' AS Date))
INSERT [dbo].[team] ([id], [name], [project_id], [setup_date]) VALUES (15, N'XEP', 45, CAST(N'2018-11-27' AS Date))
INSERT [dbo].[team] ([id], [name], [project_id], [setup_date]) VALUES (16, N'Nexus', 45, CAST(N'2018-11-27' AS Date))
INSERT [dbo].[team] ([id], [name], [project_id], [setup_date]) VALUES (17, N'ABC', 46, CAST(N'2018-11-27' AS Date))
INSERT [dbo].[team] ([id], [name], [project_id], [setup_date]) VALUES (18, N'Bravo', 46, CAST(N'2018-11-27' AS Date))
INSERT [dbo].[team] ([id], [name], [project_id], [setup_date]) VALUES (19, N'Titans', 46, CAST(N'2018-11-27' AS Date))
INSERT [dbo].[team] ([id], [name], [project_id], [setup_date]) VALUES (20, N'Charlie', 46, CAST(N'2018-11-27' AS Date))
INSERT [dbo].[team] ([id], [name], [project_id], [setup_date]) VALUES (21, N'Jaguars', 46, CAST(N'2018-11-27' AS Date))
INSERT [dbo].[team] ([id], [name], [project_id], [setup_date]) VALUES (22, N'Daredevils', 46, CAST(N'2018-11-27' AS Date))
INSERT [dbo].[team] ([id], [name], [project_id], [setup_date]) VALUES (23, N'Rangers', 46, CAST(N'2018-11-27' AS Date))
INSERT [dbo].[team] ([id], [name], [project_id], [setup_date]) VALUES (24, N'Autoboots', 46, CAST(N'2018-11-27' AS Date))
INSERT [dbo].[team] ([id], [name], [project_id], [setup_date]) VALUES (25, N'Test', 46, CAST(N'2018-12-13' AS Date))
SET IDENTITY_INSERT [dbo].[team] OFF
SET IDENTITY_INSERT [dbo].[technology] ON 

INSERT [dbo].[technology] ([id], [name], [isprimary]) VALUES (1, N'C#.Net', 1)
INSERT [dbo].[technology] ([id], [name], [isprimary]) VALUES (2, N'Java', 1)
INSERT [dbo].[technology] ([id], [name], [isprimary]) VALUES (3, N'EDI', 1)
INSERT [dbo].[technology] ([id], [name], [isprimary]) VALUES (4, N'UI', 1)
INSERT [dbo].[technology] ([id], [name], [isprimary]) VALUES (5, N'QA Automation
', 1)
INSERT [dbo].[technology] ([id], [name], [isprimary]) VALUES (6, N'QA Manual
', 1)
INSERT [dbo].[technology] ([id], [name], [isprimary]) VALUES (11, N'Database', 2)
INSERT [dbo].[technology] ([id], [name], [isprimary]) VALUES (12, N'Agile-Scrum', 2)
SET IDENTITY_INSERT [dbo].[technology] OFF
SET IDENTITY_INSERT [dbo].[timesheet] ON 

INSERT [dbo].[timesheet] ([timesheet_id], [employee_id], [task_id], [date], [hour]) VALUES (1, 2, 1, CAST(N'2018-11-19' AS Date), CAST(1.00 AS Decimal(18, 2)))
INSERT [dbo].[timesheet] ([timesheet_id], [employee_id], [task_id], [date], [hour]) VALUES (2, 2, 2, CAST(N'2018-11-20' AS Date), CAST(1.00 AS Decimal(18, 2)))
INSERT [dbo].[timesheet] ([timesheet_id], [employee_id], [task_id], [date], [hour]) VALUES (3, 2, 3, CAST(N'2018-11-21' AS Date), CAST(1.00 AS Decimal(18, 2)))
INSERT [dbo].[timesheet] ([timesheet_id], [employee_id], [task_id], [date], [hour]) VALUES (4, 2, 4, CAST(N'2018-11-22' AS Date), CAST(1.00 AS Decimal(18, 2)))
INSERT [dbo].[timesheet] ([timesheet_id], [employee_id], [task_id], [date], [hour]) VALUES (5, 2, 5, CAST(N'2018-11-23' AS Date), CAST(1.00 AS Decimal(18, 2)))
INSERT [dbo].[timesheet] ([timesheet_id], [employee_id], [task_id], [date], [hour]) VALUES (6, 2, 6, CAST(N'2018-11-24' AS Date), CAST(1.00 AS Decimal(18, 2)))
INSERT [dbo].[timesheet] ([timesheet_id], [employee_id], [task_id], [date], [hour]) VALUES (7, 2, 7, CAST(N'2018-11-25' AS Date), CAST(1.00 AS Decimal(18, 2)))
INSERT [dbo].[timesheet] ([timesheet_id], [employee_id], [task_id], [date], [hour]) VALUES (8, 2, 1, CAST(N'2018-11-19' AS Date), CAST(4.00 AS Decimal(18, 2)))
INSERT [dbo].[timesheet] ([timesheet_id], [employee_id], [task_id], [date], [hour]) VALUES (9, 2, 2, CAST(N'2018-11-20' AS Date), CAST(4.00 AS Decimal(18, 2)))
INSERT [dbo].[timesheet] ([timesheet_id], [employee_id], [task_id], [date], [hour]) VALUES (10, 2, 3, CAST(N'2018-11-21' AS Date), CAST(4.00 AS Decimal(18, 2)))
INSERT [dbo].[timesheet] ([timesheet_id], [employee_id], [task_id], [date], [hour]) VALUES (11, 2, 4, CAST(N'2018-11-22' AS Date), CAST(4.00 AS Decimal(18, 2)))
INSERT [dbo].[timesheet] ([timesheet_id], [employee_id], [task_id], [date], [hour]) VALUES (12, 2, 5, CAST(N'2018-11-23' AS Date), CAST(4.00 AS Decimal(18, 2)))
INSERT [dbo].[timesheet] ([timesheet_id], [employee_id], [task_id], [date], [hour]) VALUES (13, 2, 6, CAST(N'2018-11-24' AS Date), CAST(4.00 AS Decimal(18, 2)))
INSERT [dbo].[timesheet] ([timesheet_id], [employee_id], [task_id], [date], [hour]) VALUES (14, 2, 7, CAST(N'2018-11-25' AS Date), CAST(4.00 AS Decimal(18, 2)))
INSERT [dbo].[timesheet] ([timesheet_id], [employee_id], [task_id], [date], [hour]) VALUES (15, 2, 1, CAST(N'2018-11-19' AS Date), CAST(1.00 AS Decimal(18, 2)))
INSERT [dbo].[timesheet] ([timesheet_id], [employee_id], [task_id], [date], [hour]) VALUES (16, 2, 2, CAST(N'2018-11-20' AS Date), CAST(1.00 AS Decimal(18, 2)))
INSERT [dbo].[timesheet] ([timesheet_id], [employee_id], [task_id], [date], [hour]) VALUES (17, 2, 3, CAST(N'2018-11-21' AS Date), CAST(1.00 AS Decimal(18, 2)))
INSERT [dbo].[timesheet] ([timesheet_id], [employee_id], [task_id], [date], [hour]) VALUES (18, 2, 4, CAST(N'2018-11-22' AS Date), CAST(1.00 AS Decimal(18, 2)))
INSERT [dbo].[timesheet] ([timesheet_id], [employee_id], [task_id], [date], [hour]) VALUES (19, 2, 5, CAST(N'2018-11-23' AS Date), CAST(1.00 AS Decimal(18, 2)))
INSERT [dbo].[timesheet] ([timesheet_id], [employee_id], [task_id], [date], [hour]) VALUES (20, 2, 6, CAST(N'2018-11-24' AS Date), CAST(1.00 AS Decimal(18, 2)))
INSERT [dbo].[timesheet] ([timesheet_id], [employee_id], [task_id], [date], [hour]) VALUES (21, 2, 7, CAST(N'2018-11-25' AS Date), CAST(1.00 AS Decimal(18, 2)))
INSERT [dbo].[timesheet] ([timesheet_id], [employee_id], [task_id], [date], [hour]) VALUES (22, 2, 1, CAST(N'2018-11-19' AS Date), CAST(1.00 AS Decimal(18, 2)))
INSERT [dbo].[timesheet] ([timesheet_id], [employee_id], [task_id], [date], [hour]) VALUES (23, 2, 2, CAST(N'2018-11-20' AS Date), CAST(1.00 AS Decimal(18, 2)))
INSERT [dbo].[timesheet] ([timesheet_id], [employee_id], [task_id], [date], [hour]) VALUES (24, 2, 3, CAST(N'2018-11-21' AS Date), CAST(1.00 AS Decimal(18, 2)))
INSERT [dbo].[timesheet] ([timesheet_id], [employee_id], [task_id], [date], [hour]) VALUES (25, 2, 4, CAST(N'2018-11-22' AS Date), CAST(1.00 AS Decimal(18, 2)))
INSERT [dbo].[timesheet] ([timesheet_id], [employee_id], [task_id], [date], [hour]) VALUES (26, 2, 5, CAST(N'2018-11-23' AS Date), CAST(1.00 AS Decimal(18, 2)))
INSERT [dbo].[timesheet] ([timesheet_id], [employee_id], [task_id], [date], [hour]) VALUES (27, 2, 6, CAST(N'2018-11-24' AS Date), CAST(1.00 AS Decimal(18, 2)))
INSERT [dbo].[timesheet] ([timesheet_id], [employee_id], [task_id], [date], [hour]) VALUES (28, 2, 7, CAST(N'2018-11-25' AS Date), CAST(1.00 AS Decimal(18, 2)))
INSERT [dbo].[timesheet] ([timesheet_id], [employee_id], [task_id], [date], [hour]) VALUES (29, 2, 1, CAST(N'2018-11-19' AS Date), CAST(1.00 AS Decimal(18, 2)))
INSERT [dbo].[timesheet] ([timesheet_id], [employee_id], [task_id], [date], [hour]) VALUES (30, 2, 2, CAST(N'2018-11-20' AS Date), CAST(1.00 AS Decimal(18, 2)))
INSERT [dbo].[timesheet] ([timesheet_id], [employee_id], [task_id], [date], [hour]) VALUES (31, 2, 3, CAST(N'2018-11-21' AS Date), CAST(1.00 AS Decimal(18, 2)))
INSERT [dbo].[timesheet] ([timesheet_id], [employee_id], [task_id], [date], [hour]) VALUES (32, 2, 4, CAST(N'2018-11-22' AS Date), CAST(1.00 AS Decimal(18, 2)))
INSERT [dbo].[timesheet] ([timesheet_id], [employee_id], [task_id], [date], [hour]) VALUES (33, 2, 5, CAST(N'2018-11-23' AS Date), CAST(1.00 AS Decimal(18, 2)))
INSERT [dbo].[timesheet] ([timesheet_id], [employee_id], [task_id], [date], [hour]) VALUES (34, 2, 6, CAST(N'2018-11-24' AS Date), CAST(1.00 AS Decimal(18, 2)))
INSERT [dbo].[timesheet] ([timesheet_id], [employee_id], [task_id], [date], [hour]) VALUES (35, 2, 7, CAST(N'2018-11-25' AS Date), CAST(1.00 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[timesheet] OFF
ALTER TABLE [dbo].[designation]  WITH CHECK ADD  CONSTRAINT [FK_designation_category] FOREIGN KEY([category_id])
REFERENCES [dbo].[category] ([id])
GO
ALTER TABLE [dbo].[designation] CHECK CONSTRAINT [FK_designation_category]
GO
ALTER TABLE [dbo].[employee]  WITH CHECK ADD  CONSTRAINT [FK_employee_designation] FOREIGN KEY([employee_id])
REFERENCES [dbo].[designation] ([id])
GO
ALTER TABLE [dbo].[employee] CHECK CONSTRAINT [FK_employee_designation]
GO
ALTER TABLE [dbo].[employee]  WITH CHECK ADD  CONSTRAINT [FK_employee_team] FOREIGN KEY([team_id])
REFERENCES [dbo].[team] ([id])
GO
ALTER TABLE [dbo].[employee] CHECK CONSTRAINT [FK_employee_team]
GO
ALTER TABLE [dbo].[employee_appraisal]  WITH CHECK ADD  CONSTRAINT [FK_employee_appraisal_employee] FOREIGN KEY([employee_id])
REFERENCES [dbo].[employee] ([employee_id])
GO
ALTER TABLE [dbo].[employee_appraisal] CHECK CONSTRAINT [FK_employee_appraisal_employee]
GO
ALTER TABLE [dbo].[project]  WITH CHECK ADD  CONSTRAINT [FK_project_client] FOREIGN KEY([client_id])
REFERENCES [dbo].[client] ([client_id])
GO
ALTER TABLE [dbo].[project] CHECK CONSTRAINT [FK_project_client]
GO
ALTER TABLE [dbo].[project]  WITH CHECK ADD  CONSTRAINT [FK_project_employee] FOREIGN KEY([project_manager_id])
REFERENCES [dbo].[employee] ([employee_id])
GO
ALTER TABLE [dbo].[project] CHECK CONSTRAINT [FK_project_employee]
GO
ALTER TABLE [dbo].[project_resources]  WITH CHECK ADD  CONSTRAINT [FK_project_resources_project] FOREIGN KEY([project_id])
REFERENCES [dbo].[project] ([project_id])
GO
ALTER TABLE [dbo].[project_resources] CHECK CONSTRAINT [FK_project_resources_project]
GO
ALTER TABLE [dbo].[task_team]  WITH CHECK ADD  CONSTRAINT [FK_task_team_task] FOREIGN KEY([task_id])
REFERENCES [dbo].[employee_task] ([id])
GO
ALTER TABLE [dbo].[task_team] CHECK CONSTRAINT [FK_task_team_task]
GO
ALTER TABLE [dbo].[task_team]  WITH CHECK ADD  CONSTRAINT [FK_task_team_team] FOREIGN KEY([team_id])
REFERENCES [dbo].[team] ([id])
GO
ALTER TABLE [dbo].[task_team] CHECK CONSTRAINT [FK_task_team_team]
GO
ALTER TABLE [dbo].[team]  WITH CHECK ADD  CONSTRAINT [FK_team_project] FOREIGN KEY([project_id])
REFERENCES [dbo].[project] ([project_id])
GO
ALTER TABLE [dbo].[team] CHECK CONSTRAINT [FK_team_project]
GO
ALTER TABLE [dbo].[timesheet]  WITH CHECK ADD  CONSTRAINT [FK_timesheet_employee] FOREIGN KEY([employee_id])
REFERENCES [dbo].[employee] ([employee_id])
GO
ALTER TABLE [dbo].[timesheet] CHECK CONSTRAINT [FK_timesheet_employee]
GO
ALTER TABLE [dbo].[timesheet]  WITH CHECK ADD  CONSTRAINT [FK_timesheet_task] FOREIGN KEY([task_id])
REFERENCES [dbo].[employee_task] ([id])
GO
ALTER TABLE [dbo].[timesheet] CHECK CONSTRAINT [FK_timesheet_task]
GO
