USE [master]
GO
/****** Object:  Database [Book]    Script Date: 2026/5/12 11:30:33 ******/
CREATE DATABASE [Book]
GO
USE [Book]
GO

CREATE TABLE [dbo].[tb_Book](
	[BookId] [varchar](50) NOT NULL,
	[Title] [varchar](255) NOT NULL,
	[Author] [varchar](100) NOT NULL,
	[Press] [varchar](50) NOT NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[Stock] [int] NOT NULL,
	[SaleCounts] [int] NOT NULL,
	[Photo] [varchar](100) NOT NULL,
	[Descriptions] [text] NOT NULL,
	[IsOnline] [bit] NOT NULL,
 CONSTRAINT [PK_tb_Book] PRIMARY KEY CLUSTERED 
(
	[BookId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_user]    Script Date: 2026/5/12 11:30:34 ******/

CREATE TABLE [dbo].[tb_user](
	[userid] [int] IDENTITY(1001,1) NOT NULL,
	[username] [varchar](20) NOT NULL,
	[pwd] [varchar](20) NOT NULL,
	[lastLoginTime] [datetime] NOT NULL,
	[loginTime] [datetime] NOT NULL,
	[loginCounts] [int] NOT NULL,
	[errorCounts] [int] NOT NULL,
	[isLocked] [bit] NOT NULL,
 CONSTRAINT [PK__tb_user__CBA1B257CAB0F5D3] PRIMARY KEY CLUSTERED 
(
	[userid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[tb_Book] ([BookId], [Title], [Author], [Press], [Price], [Stock], [SaleCounts], [Photo], [Descriptions], [IsOnline]) VALUES (N'9787121515866', N'人工智能：时代的机遇和挑战', N'中央广播电视总台财经节目中心', N'电子工业出版社', CAST(53.50 AS Decimal(18, 2)), 99, 4, N'1.jpg', N'《人工智能：时代的机遇和挑战》一书以央视财经节目中心推出的同名系列微纪录片为内容编写。从人工智能发展史切入，描绘了人工智能给人类社会带来的巨变，探索人工智能的发展路径，以及人类如何处理与人工智能的关系，并结合当前全球关于人工智能治理的实践，对产业未来发展进行更深远的思考。节目组采访了中国工程院院士、国内外人工智能领域专家及前沿行业的专业学者。他们权威地解读了当前人工智能发展的技术底座及未来的应用场景，同时也客观分析了全球共同面临的风险和挑战，并深入探讨中国为全球人工智能治理作出的重要贡献。', 1)
GO
INSERT [dbo].[tb_Book] ([BookId], [Title], [Author], [Press], [Price], [Stock], [SaleCounts], [Photo], [Descriptions], [IsOnline]) VALUES (N'9787122472144', N'体育是门必修课', N'李拼命', N'化学工业出版社', CAST(72.00 AS Decimal(18, 2)), 30, 1, N'5.jpg', N'"《体育是门必修课—青少年运动的方法论》以国际公认的体能训练方法论为核心，深入探讨体能训练对青少年全面均衡发展的重要性，不仅能改善目前普遍存在的青少年亚健康问题，更能有效提升其运动表现。', 1)
GO
INSERT [dbo].[tb_Book] ([BookId], [Title], [Author], [Press], [Price], [Stock], [SaleCounts], [Photo], [Descriptions], [IsOnline]) VALUES (N'9787302691471', N'DeepSeek 从入门到精通', N'文之易,?苏小文', N'清华大学出版社', CAST(78.40 AS Decimal(18, 2)), 25, 5, N'3.jpg', N'"《DeepSeek 从入门到精通（微课视频版）—提示词设计 多场景应用 工具深度融合》', 1)
GO
INSERT [dbo].[tb_Book] ([BookId], [Title], [Author], [Press], [Price], [Stock], [SaleCounts], [Photo], [Descriptions], [IsOnline]) VALUES (N'9787302706250', N'数织健康梦', N'陶永鹏', N'清华大学出版社', CAST(87.60 AS Decimal(18, 2)), 49, 4, N'6.jpg', N'本书系统讲述了辽宁地区在公共卫生方面的大数据研究与应用实践，涉及医疗大数据与健康中国2030战略、医疗大数据发展战略的具体实施、医疗数据共享的动机分析、中医现代化路径、老年人健康挑战及应对、数据驱动大健康产业以及地区大数据发展案例。本书特色是对辽宁当地情况有着较为深入的理解和探讨，切实说明了大数据的应用到卫生保健领域将会遇到什么样的挑战。本书不仅关注技术层面，还从政策、法律、社会心理等多角度进行了综合探讨，为读者提供了全面的视角。同时，对于中医药现代化发展、防疫及老龄化等问题也提出了有价值的观点和对策。', 1)
GO
INSERT [dbo].[tb_Book] ([BookId], [Title], [Author], [Press], [Price], [Stock], [SaleCounts], [Photo], [Descriptions], [IsOnline]) VALUES (N'9787573207388', N'古文观止译注', N'李梦生，史良昭?', N'上海古籍出版社', CAST(57.00 AS Decimal(18, 2)), 24, 4, N'4.jpg', N'本书以文学古籍刊行社1956年排印本《古文观止》（据映雪堂本排印）为底本，译注者用有关史书或别集校勘，择善而从，不出校记。同时，将原书前四卷中史料内容较强、缺乏散文美感的文章精简压缩，成为两卷；自第五卷后全部保留。入选之文多短小精彩，均是便于记诵的传世佳作。本书打破了以往此类书籍的常规模式，在原文上通篇标注拼音，省却了读者困难字、生僻字需查阅工具书的麻烦，使阅读畅行无阻。配以通俗流畅的全本译文，文义贯通，适于学习、理解古代优秀散文。对文言文的学习特别有帮助，是少儿国学入门读物。', 1)
GO
SET IDENTITY_INSERT [dbo].[tb_user] ON 
GO
INSERT [dbo].[tb_user] ([userid], [username], [pwd], [lastLoginTime], [loginTime], [loginCounts], [errorCounts], [isLocked]) VALUES (1007, N'li ming     ', N'000000', CAST(N'2026-04-20T10:58:27.073' AS DateTime), CAST(N'2026-04-20T11:09:43.413' AS DateTime), 6, 0, 0)
GO
INSERT [dbo].[tb_user] ([userid], [username], [pwd], [lastLoginTime], [loginTime], [loginCounts], [errorCounts], [isLocked]) VALUES (1008, N'zhang san', N'123456', CAST(N'2025-12-26T13:34:44.897' AS DateTime), CAST(N'2025-12-26T13:34:44.897' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[tb_user] ([userid], [username], [pwd], [lastLoginTime], [loginTime], [loginCounts], [errorCounts], [isLocked]) VALUES (1009, N'liming', N'123', CAST(N'2026-05-12T11:26:54.297' AS DateTime), CAST(N'2026-05-12T11:26:54.297' AS DateTime), 0, 0, 0)
GO
SET IDENTITY_INSERT [dbo].[tb_user] OFF
GO

create proc [dbo].[isExistID] @userid int,@flag bit output
as
begin
	if exists (select * from tb_user where userid=@userid)
		 set @flag=1
	else
		 set @flag=0
end

GO
/****** Object:  StoredProcedure [dbo].[isLockedID]    Script Date: 2026/5/12 11:30:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[isLockedID] @userid int,@flag bit output
as
begin
	select @flag=isLocked from tb_user where userid=@userid		
end
GO
/****** Object:  StoredProcedure [dbo].[isRightPwd]    Script Date: 2026/5/12 11:30:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[isRightPwd] @userid int,@pwd varchar(20),@flag bit output
as
begin
	if exists (select * from tb_user where userid=@userid and pwd=@pwd)
		 set @flag=1
	else
		 set @flag=0
end
GO
/****** Object:  StoredProcedure [dbo].[updateLoginInfo]    Script Date: 2026/5/12 11:30:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[updateLoginInfo] @userid int
as
begin
	update tb_user set logincounts=logincounts+1,errorcounts=0,lastlogintime=logintime,logintime=getdate() 
	where userid=@userid
end
GO
USE [master]
GO

