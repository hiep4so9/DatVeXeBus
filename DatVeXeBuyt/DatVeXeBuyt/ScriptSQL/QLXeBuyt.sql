USE [QLXeBus]
GO
/****** Object:  StoredProcedure [dbo].[sp_DanhSachVe]    Script Date: 8/11/2022 2:51:29 PM ******/
DROP PROCEDURE IF EXISTS [dbo].[sp_DanhSachVe]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Xe]') AND type in (N'U'))
ALTER TABLE [dbo].[Xe] DROP CONSTRAINT IF EXISTS [FK_Xe_Tuyenxe]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[VeXe]') AND type in (N'U'))
ALTER TABLE [dbo].[VeXe] DROP CONSTRAINT IF EXISTS [FK_VeXe_Tuyenxe]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Phanhoi]') AND type in (N'U'))
ALTER TABLE [dbo].[Phanhoi] DROP CONSTRAINT IF EXISTS [FK_Phanhoi_Taikhoan]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Nhanvien]') AND type in (N'U'))
ALTER TABLE [dbo].[Nhanvien] DROP CONSTRAINT IF EXISTS [FK_Nhanvien_Taikhoan]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Khachhang]') AND type in (N'U'))
ALTER TABLE [dbo].[Khachhang] DROP CONSTRAINT IF EXISTS [FK_Khachhang_Taikhoan]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Hoadon]') AND type in (N'U'))
ALTER TABLE [dbo].[Hoadon] DROP CONSTRAINT IF EXISTS [FK_Hoadon_Khachhang]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CT_Xe]') AND type in (N'U'))
ALTER TABLE [dbo].[CT_Xe] DROP CONSTRAINT IF EXISTS [FK_CT_Xe_Xe]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CT_Xe]') AND type in (N'U'))
ALTER TABLE [dbo].[CT_Xe] DROP CONSTRAINT IF EXISTS [FK_CT_Xe_Nhanvien]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CT_Tuyenxe]') AND type in (N'U'))
ALTER TABLE [dbo].[CT_Tuyenxe] DROP CONSTRAINT IF EXISTS [FK_CT_Tuyenxe_Tuyenxe]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CT_Tuyenxe]') AND type in (N'U'))
ALTER TABLE [dbo].[CT_Tuyenxe] DROP CONSTRAINT IF EXISTS [FK_CT_Tuyenxe_Tramxe]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CT_Ngaylamviec]') AND type in (N'U'))
ALTER TABLE [dbo].[CT_Ngaylamviec] DROP CONSTRAINT IF EXISTS [FK_CT_Ngaylamviec_Xe]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CT_Ngaylamviec]') AND type in (N'U'))
ALTER TABLE [dbo].[CT_Ngaylamviec] DROP CONSTRAINT IF EXISTS [FK_CT_Ngaylamviec_Thoigianlamviec]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CT_Ngaylamviec]') AND type in (N'U'))
ALTER TABLE [dbo].[CT_Ngaylamviec] DROP CONSTRAINT IF EXISTS [FK_CT_Ngaylamviec_Nhanvien]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CT_Hoadon]') AND type in (N'U'))
ALTER TABLE [dbo].[CT_Hoadon] DROP CONSTRAINT IF EXISTS [FK_CT_Hoadon_VeXe]
GO
/****** Object:  Table [dbo].[Xe]    Script Date: 8/11/2022 2:51:29 PM ******/
DROP TABLE IF EXISTS [dbo].[Xe]
GO
/****** Object:  Table [dbo].[VeXe]    Script Date: 8/11/2022 2:51:29 PM ******/
DROP TABLE IF EXISTS [dbo].[VeXe]
GO
/****** Object:  Table [dbo].[Tuyenxe]    Script Date: 8/11/2022 2:51:29 PM ******/
DROP TABLE IF EXISTS [dbo].[Tuyenxe]
GO
/****** Object:  Table [dbo].[Tramxe]    Script Date: 8/11/2022 2:51:29 PM ******/
DROP TABLE IF EXISTS [dbo].[Tramxe]
GO
/****** Object:  Table [dbo].[Thoigianlamviec]    Script Date: 8/11/2022 2:51:29 PM ******/
DROP TABLE IF EXISTS [dbo].[Thoigianlamviec]
GO
/****** Object:  Table [dbo].[Taikhoan]    Script Date: 8/11/2022 2:51:29 PM ******/
DROP TABLE IF EXISTS [dbo].[Taikhoan]
GO
/****** Object:  Table [dbo].[Phanhoi]    Script Date: 8/11/2022 2:51:29 PM ******/
DROP TABLE IF EXISTS [dbo].[Phanhoi]
GO
/****** Object:  Table [dbo].[Nhanvien]    Script Date: 8/11/2022 2:51:29 PM ******/
DROP TABLE IF EXISTS [dbo].[Nhanvien]
GO
/****** Object:  Table [dbo].[Loaitaikhoan]    Script Date: 8/11/2022 2:51:29 PM ******/
DROP TABLE IF EXISTS [dbo].[Loaitaikhoan]
GO
/****** Object:  Table [dbo].[Khachhang]    Script Date: 8/11/2022 2:51:29 PM ******/
DROP TABLE IF EXISTS [dbo].[Khachhang]
GO
/****** Object:  Table [dbo].[Hoadon]    Script Date: 8/11/2022 2:51:29 PM ******/
DROP TABLE IF EXISTS [dbo].[Hoadon]
GO
/****** Object:  Table [dbo].[CT_Xe]    Script Date: 8/11/2022 2:51:29 PM ******/
DROP TABLE IF EXISTS [dbo].[CT_Xe]
GO
/****** Object:  Table [dbo].[CT_Tuyenxe]    Script Date: 8/11/2022 2:51:29 PM ******/
DROP TABLE IF EXISTS [dbo].[CT_Tuyenxe]
GO
/****** Object:  Table [dbo].[CT_Ngaylamviec]    Script Date: 8/11/2022 2:51:29 PM ******/
DROP TABLE IF EXISTS [dbo].[CT_Ngaylamviec]
GO
/****** Object:  Table [dbo].[CT_Hoadon]    Script Date: 8/11/2022 2:51:29 PM ******/
DROP TABLE IF EXISTS [dbo].[CT_Hoadon]
GO
/****** Object:  Table [dbo].[CT_Hoadon]    Script Date: 8/11/2022 2:51:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CT_Hoadon](
	[Mave] [int] NOT NULL,
	[MaHD] [int] NOT NULL,
	[Trangthai] [int] NULL,
	[Soluotsudung] [int] NULL,
	[QRcode] [nvarchar](max) NULL,
	[Id_CTHoadon] [int] IDENTITY(1,1) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_CTHoadon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CT_Ngaylamviec]    Script Date: 8/11/2022 2:51:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CT_Ngaylamviec](
	[Manhanvien] [int] NOT NULL,
	[Maxe] [int] NOT NULL,
	[Id_Thoigianlamviec] [int] NOT NULL,
	[Ngaylamviec] [datetime] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CT_Tuyenxe]    Script Date: 8/11/2022 2:51:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CT_Tuyenxe](
	[Matuyen] [int] NOT NULL,
	[Matram] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CT_Xe]    Script Date: 8/11/2022 2:51:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CT_Xe](
	[Manhanvien] [int] NOT NULL,
	[Maxe] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Hoadon]    Script Date: 8/11/2022 2:51:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Hoadon](
	[Ngaymua] [datetime] NULL,
	[Makhachhang] [int] NOT NULL,
	[Trangthai] [int] NULL,
	[MaHD] [int] IDENTITY(1,1) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaHD] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Khachhang]    Script Date: 8/11/2022 2:51:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Khachhang](
	[Makhachhang] [int] IDENTITY(1,1) NOT NULL,
	[Ten] [nvarchar](50) NULL,
	[Ngaysinh] [date] NULL,
	[CCCD] [char](12) NULL,
	[TheHSSV] [char](10) NULL,
	[Gioitinh] [bit] NULL,
	[Diachi] [nvarchar](100) NULL,
	[Id_Taikhoan] [int] NOT NULL,
 CONSTRAINT [PK_Khachhang] PRIMARY KEY CLUSTERED 
(
	[Makhachhang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Loaitaikhoan]    Script Date: 8/11/2022 2:51:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Loaitaikhoan](
	[Id_Loaitaikhoan] [int] IDENTITY(1,1) NOT NULL,
	[Ten] [nvarchar](50) NULL,
	[Maloai] [nvarchar](50) NULL,
 CONSTRAINT [PK_Loaitaikhoan] PRIMARY KEY CLUSTERED 
(
	[Id_Loaitaikhoan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Nhanvien]    Script Date: 8/11/2022 2:51:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Nhanvien](
	[Manhanvien] [int] IDENTITY(1,1) NOT NULL,
	[Ten] [nvarchar](50) NULL,
	[Ngaysinh] [date] NULL,
	[Diachi] [nvarchar](100) NULL,
	[Gioitinh] [bit] NULL,
	[Ngayvaolam] [date] NULL,
	[Chucvu] [nvarchar](50) NULL,
	[Luong] [decimal](18, 0) NULL,
	[CCCD] [char](12) NULL,
	[Id_Taikhoan] [int] NOT NULL,
 CONSTRAINT [PK_Nhanvien] PRIMARY KEY CLUSTERED 
(
	[Manhanvien] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Phanhoi]    Script Date: 8/11/2022 2:51:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Phanhoi](
	[Maphanhoi] [int] IDENTITY(1,1) NOT NULL,
	[Noidung] [nvarchar](150) NULL,
	[Ngayphanhoi] [datetime] NULL,
	[Id_Taikhoan] [int] NOT NULL,
 CONSTRAINT [PK_Phanhoi''] PRIMARY KEY CLUSTERED 
(
	[Maphanhoi] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Taikhoan]    Script Date: 8/11/2022 2:51:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Taikhoan](
	[Id_Taikhoan] [int] IDENTITY(1,1) NOT NULL,
	[Tentaikhoan] [nvarchar](50) NULL,
	[Matkhau] [nchar](50) NULL,
	[Email] [nchar](50) NULL,
	[Sodienthoai] [char](10) NULL,
	[Code] [int] NULL,
	[Tinhtrang] [nvarchar](100) NULL,
	[Sodu] [decimal](18, 0) NULL,
	[Maloai] [nchar](10) NULL,
 CONSTRAINT [PK_Taikhoan] PRIMARY KEY CLUSTERED 
(
	[Id_Taikhoan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Thoigianlamviec]    Script Date: 8/11/2022 2:51:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Thoigianlamviec](
	[Id_Thoigianlamviec] [int] IDENTITY(1,1) NOT NULL,
	[Thoigianbatdau] [time](7) NULL,
	[Thoigianketthuc] [time](7) NULL,
 CONSTRAINT [PK_Thoigianlamviec] PRIMARY KEY CLUSTERED 
(
	[Id_Thoigianlamviec] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tramxe]    Script Date: 8/11/2022 2:51:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tramxe](
	[Matram] [int] IDENTITY(1,1) NOT NULL,
	[Tentram] [nvarchar](100) NULL,
	[Tentuyenduong] [nvarchar](50) NULL,
	[Toado] [nvarchar](max) NULL,
	[Manhung] [nvarchar](max) NULL,
 CONSTRAINT [PK_Tramxe] PRIMARY KEY CLUSTERED 
(
	[Matram] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tuyenxe]    Script Date: 8/11/2022 2:51:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tuyenxe](
	[Matuyen] [int] IDENTITY(1,1) NOT NULL,
	[Tuyenso] [int] NULL,
	[Tentuyen] [nvarchar](100) NULL,
	[Thoigianbatdau] [time](7) NULL,
	[Thoigianketthuc] [time](7) NULL,
	[Luotdi] [nvarchar](200) NULL,
	[Luotve] [nvarchar](200) NULL,
	[Loaituyen] [varchar](50) NULL,
	[Thoigianchay] [nvarchar](50) NULL,
	[Giancachtuyen] [nvarchar](50) NULL,
	[Sochuyen] [int] NULL,
 CONSTRAINT [PK_Tuyenxe] PRIMARY KEY CLUSTERED 
(
	[Matuyen] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VeXe]    Script Date: 8/11/2022 2:51:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VeXe](
	[Mave] [int] IDENTITY(1,1) NOT NULL,
	[Ngayphathanh] [date] NULL,
	[Ngayhethan] [date] NULL,
	[Tinhtrang] [nvarchar](50) NULL,
	[Matuyen] [int] NOT NULL,
	[Loaive] [int] NULL,
	[Vethang] [bit] NULL,
	[Giatien] [decimal](18, 0) NULL,
 CONSTRAINT [PK_VeXe] PRIMARY KEY CLUSTERED 
(
	[Mave] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Xe]    Script Date: 8/11/2022 2:51:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Xe](
	[MaXe] [int] IDENTITY(1,1) NOT NULL,
	[Thoigianhoatdong] [time](7) NULL,
	[Thoigianchay] [time](7) NULL,
	[Bienso] [char](10) NULL,
	[Trangthai] [nvarchar](50) NULL,
	[Matuyen] [int] NOT NULL,
	[Sochongoi] [int] NULL,
 CONSTRAINT [PK_Xe] PRIMARY KEY CLUSTERED 
(
	[MaXe] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[CT_Hoadon]  WITH CHECK ADD  CONSTRAINT [FK_CT_Hoadon_VeXe] FOREIGN KEY([Mave])
REFERENCES [dbo].[VeXe] ([Mave])
GO
ALTER TABLE [dbo].[CT_Hoadon] CHECK CONSTRAINT [FK_CT_Hoadon_VeXe]
GO
ALTER TABLE [dbo].[CT_Ngaylamviec]  WITH CHECK ADD  CONSTRAINT [FK_CT_Ngaylamviec_Nhanvien] FOREIGN KEY([Manhanvien])
REFERENCES [dbo].[Nhanvien] ([Manhanvien])
GO
ALTER TABLE [dbo].[CT_Ngaylamviec] CHECK CONSTRAINT [FK_CT_Ngaylamviec_Nhanvien]
GO
ALTER TABLE [dbo].[CT_Ngaylamviec]  WITH CHECK ADD  CONSTRAINT [FK_CT_Ngaylamviec_Thoigianlamviec] FOREIGN KEY([Id_Thoigianlamviec])
REFERENCES [dbo].[Thoigianlamviec] ([Id_Thoigianlamviec])
GO
ALTER TABLE [dbo].[CT_Ngaylamviec] CHECK CONSTRAINT [FK_CT_Ngaylamviec_Thoigianlamviec]
GO
ALTER TABLE [dbo].[CT_Ngaylamviec]  WITH CHECK ADD  CONSTRAINT [FK_CT_Ngaylamviec_Xe] FOREIGN KEY([Maxe])
REFERENCES [dbo].[Xe] ([MaXe])
GO
ALTER TABLE [dbo].[CT_Ngaylamviec] CHECK CONSTRAINT [FK_CT_Ngaylamviec_Xe]
GO
ALTER TABLE [dbo].[CT_Tuyenxe]  WITH CHECK ADD  CONSTRAINT [FK_CT_Tuyenxe_Tramxe] FOREIGN KEY([Matram])
REFERENCES [dbo].[Tramxe] ([Matram])
GO
ALTER TABLE [dbo].[CT_Tuyenxe] CHECK CONSTRAINT [FK_CT_Tuyenxe_Tramxe]
GO
ALTER TABLE [dbo].[CT_Tuyenxe]  WITH CHECK ADD  CONSTRAINT [FK_CT_Tuyenxe_Tuyenxe] FOREIGN KEY([Matuyen])
REFERENCES [dbo].[Tuyenxe] ([Matuyen])
GO
ALTER TABLE [dbo].[CT_Tuyenxe] CHECK CONSTRAINT [FK_CT_Tuyenxe_Tuyenxe]
GO
ALTER TABLE [dbo].[CT_Xe]  WITH CHECK ADD  CONSTRAINT [FK_CT_Xe_Nhanvien] FOREIGN KEY([Manhanvien])
REFERENCES [dbo].[Nhanvien] ([Manhanvien])
GO
ALTER TABLE [dbo].[CT_Xe] CHECK CONSTRAINT [FK_CT_Xe_Nhanvien]
GO
ALTER TABLE [dbo].[CT_Xe]  WITH CHECK ADD  CONSTRAINT [FK_CT_Xe_Xe] FOREIGN KEY([Maxe])
REFERENCES [dbo].[Xe] ([MaXe])
GO
ALTER TABLE [dbo].[CT_Xe] CHECK CONSTRAINT [FK_CT_Xe_Xe]
GO
ALTER TABLE [dbo].[Hoadon]  WITH CHECK ADD  CONSTRAINT [FK_Hoadon_Khachhang] FOREIGN KEY([Makhachhang])
REFERENCES [dbo].[Khachhang] ([Makhachhang])
GO
ALTER TABLE [dbo].[Hoadon] CHECK CONSTRAINT [FK_Hoadon_Khachhang]
GO
ALTER TABLE [dbo].[Khachhang]  WITH CHECK ADD  CONSTRAINT [FK_Khachhang_Taikhoan] FOREIGN KEY([Id_Taikhoan])
REFERENCES [dbo].[Taikhoan] ([Id_Taikhoan])
GO
ALTER TABLE [dbo].[Khachhang] CHECK CONSTRAINT [FK_Khachhang_Taikhoan]
GO
ALTER TABLE [dbo].[Nhanvien]  WITH CHECK ADD  CONSTRAINT [FK_Nhanvien_Taikhoan] FOREIGN KEY([Id_Taikhoan])
REFERENCES [dbo].[Taikhoan] ([Id_Taikhoan])
GO
ALTER TABLE [dbo].[Nhanvien] CHECK CONSTRAINT [FK_Nhanvien_Taikhoan]
GO
ALTER TABLE [dbo].[Phanhoi]  WITH CHECK ADD  CONSTRAINT [FK_Phanhoi_Taikhoan] FOREIGN KEY([Id_Taikhoan])
REFERENCES [dbo].[Taikhoan] ([Id_Taikhoan])
GO
ALTER TABLE [dbo].[Phanhoi] CHECK CONSTRAINT [FK_Phanhoi_Taikhoan]
GO
ALTER TABLE [dbo].[VeXe]  WITH CHECK ADD  CONSTRAINT [FK_VeXe_Tuyenxe] FOREIGN KEY([Matuyen])
REFERENCES [dbo].[Tuyenxe] ([Matuyen])
GO
ALTER TABLE [dbo].[VeXe] CHECK CONSTRAINT [FK_VeXe_Tuyenxe]
GO
ALTER TABLE [dbo].[Xe]  WITH CHECK ADD  CONSTRAINT [FK_Xe_Tuyenxe] FOREIGN KEY([Matuyen])
REFERENCES [dbo].[Tuyenxe] ([Matuyen])
GO
ALTER TABLE [dbo].[Xe] CHECK CONSTRAINT [FK_Xe_Tuyenxe]
GO
/****** Object:  StoredProcedure [dbo].[sp_DanhSachVe]    Script Date: 8/11/2022 2:51:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[sp_DanhSachVe] 
	@makhachhang INT
AS
SELECT Hoadon.*, CT_Hoadon.Mave,CT_Hoadon.Trangthai,CT_Hoadon.Soluotsudung,CT_Hoadon.QRcode,CT_Hoadon.Id_CTHoadon FROM Hoadon
LEFT JOIN CT_Hoadon ON Hoadon.MaHD = CT_Hoadon.MaHD
WHERE Hoadon.Makhachhang = @makhachhang
GO
