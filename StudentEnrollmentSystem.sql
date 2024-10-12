USE [master]
GO
/****** Object:  Database [StudentEnrollmentSystem]    Script Date: 2024/10/12 下午 06:18:48 ******/
CREATE DATABASE [StudentEnrollmentSystem]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'StudentEnrollmentSystem', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.SQLEXPRESS\MSSQL\DATA\StudentEnrollmentSystem.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'StudentEnrollmentSystem_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.SQLEXPRESS\MSSQL\DATA\StudentEnrollmentSystem_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [StudentEnrollmentSystem] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [StudentEnrollmentSystem].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [StudentEnrollmentSystem] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [StudentEnrollmentSystem] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [StudentEnrollmentSystem] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [StudentEnrollmentSystem] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [StudentEnrollmentSystem] SET ARITHABORT OFF 
GO
ALTER DATABASE [StudentEnrollmentSystem] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [StudentEnrollmentSystem] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [StudentEnrollmentSystem] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [StudentEnrollmentSystem] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [StudentEnrollmentSystem] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [StudentEnrollmentSystem] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [StudentEnrollmentSystem] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [StudentEnrollmentSystem] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [StudentEnrollmentSystem] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [StudentEnrollmentSystem] SET  DISABLE_BROKER 
GO
ALTER DATABASE [StudentEnrollmentSystem] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [StudentEnrollmentSystem] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [StudentEnrollmentSystem] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [StudentEnrollmentSystem] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [StudentEnrollmentSystem] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [StudentEnrollmentSystem] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [StudentEnrollmentSystem] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [StudentEnrollmentSystem] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [StudentEnrollmentSystem] SET  MULTI_USER 
GO
ALTER DATABASE [StudentEnrollmentSystem] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [StudentEnrollmentSystem] SET DB_CHAINING OFF 
GO
ALTER DATABASE [StudentEnrollmentSystem] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [StudentEnrollmentSystem] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [StudentEnrollmentSystem] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [StudentEnrollmentSystem] SET QUERY_STORE = OFF
GO
USE [StudentEnrollmentSystem]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [StudentEnrollmentSystem]
GO
/****** Object:  Table [dbo].[Course]    Script Date: 2024/10/12 下午 06:18:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Course](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[courseName] [nchar](10) NULL,
	[professorId] [int] NULL,
	[createdTime] [datetime] NULL,
	[updatedTime] [datetime] NULL,
 CONSTRAINT [PK_Course] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Professor]    Script Date: 2024/10/12 下午 06:18:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Professor](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](10) NOT NULL,
	[email] [nvarchar](50) NULL,
	[createdTime] [datetime] NOT NULL,
	[updatedTime] [datetime] NOT NULL,
 CONSTRAINT [PK_Professor_1] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Student]    Script Date: 2024/10/12 下午 06:18:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Student](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](10) NOT NULL,
	[email] [nvarchar](50) NULL,
	[createdTime] [datetime] NOT NULL,
	[updatedTime] [datetime] NOT NULL,
 CONSTRAINT [PK_Student] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StudentCourse]    Script Date: 2024/10/12 下午 06:18:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StudentCourse](
	[id] [int] NOT NULL,
	[studentId] [int] NOT NULL,
	[courseId] [int] NOT NULL,
	[enrollDate] [date] NOT NULL,
 CONSTRAINT [PK_StudentCourse] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Course]  WITH CHECK ADD  CONSTRAINT [FK_Course_Professor] FOREIGN KEY([professorId])
REFERENCES [dbo].[Professor] ([id])
GO
ALTER TABLE [dbo].[Course] CHECK CONSTRAINT [FK_Course_Professor]
GO
ALTER TABLE [dbo].[StudentCourse]  WITH CHECK ADD  CONSTRAINT [FK_StudentCourse_Course] FOREIGN KEY([courseId])
REFERENCES [dbo].[Course] ([id])
GO
ALTER TABLE [dbo].[StudentCourse] CHECK CONSTRAINT [FK_StudentCourse_Course]
GO
ALTER TABLE [dbo].[StudentCourse]  WITH CHECK ADD  CONSTRAINT [FK_StudentCourse_Student] FOREIGN KEY([studentId])
REFERENCES [dbo].[Student] ([id])
GO
ALTER TABLE [dbo].[StudentCourse] CHECK CONSTRAINT [FK_StudentCourse_Student]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'唯一識別碼' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Course', @level2type=N'COLUMN',@level2name=N'id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'課程名稱' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Course', @level2type=N'COLUMN',@level2name=N'courseName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'授課教授Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Course', @level2type=N'COLUMN',@level2name=N'professorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'課程建立時間' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Course', @level2type=N'COLUMN',@level2name=N'createdTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'課程更新時間' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Course', @level2type=N'COLUMN',@level2name=N'updatedTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'唯一識別碼' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Professor', @level2type=N'COLUMN',@level2name=N'id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'教授姓名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Professor', @level2type=N'COLUMN',@level2name=N'name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'電子郵件地址' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Professor', @level2type=N'COLUMN',@level2name=N'email'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'帳號建立時間' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Professor', @level2type=N'COLUMN',@level2name=N'createdTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'帳號更新時間' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Professor', @level2type=N'COLUMN',@level2name=N'updatedTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'唯一識別碼' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Student', @level2type=N'COLUMN',@level2name=N'id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'學生姓名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Student', @level2type=N'COLUMN',@level2name=N'name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'電子郵件地址' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Student', @level2type=N'COLUMN',@level2name=N'email'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'帳號建立時間' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Student', @level2type=N'COLUMN',@level2name=N'createdTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'帳號更新時間' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Student', @level2type=N'COLUMN',@level2name=N'updatedTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'唯一識別碼' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'StudentCourse', @level2type=N'COLUMN',@level2name=N'id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'學生Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'StudentCourse', @level2type=N'COLUMN',@level2name=N'studentId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'課程Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'StudentCourse', @level2type=N'COLUMN',@level2name=N'courseId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'選課日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'StudentCourse', @level2type=N'COLUMN',@level2name=N'enrollDate'
GO
USE [master]
GO
ALTER DATABASE [StudentEnrollmentSystem] SET  READ_WRITE 
GO
