USE [QLSVSDS]
GO
/****** Object:  Table [dbo].[Diem]    Script Date: 7/15/2024 9:23:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Diem](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DiemQuaTrinh] [decimal](18, 0) NULL,
	[DiemThanhPhan] [decimal](18, 0) NULL,
	[Id_SinhVien] [int] NULL,
	[Id_MonHoc] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Khoas]    Script Date: 7/15/2024 9:23:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Khoas](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MaKhoas] [varchar](50) NOT NULL,
	[TenKhoas] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Lop]    Script Date: 7/15/2024 9:23:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Lop](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MaLop] [varchar](50) NOT NULL,
	[TenLop] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MonHoc]    Script Date: 7/15/2024 9:23:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MonHoc](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MaMonHoc] [varchar](50) NOT NULL,
	[TenMonHoc] [nvarchar](50) NOT NULL,
	[SoTietHoc] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SinhVien]    Script Date: 7/15/2024 9:23:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SinhVien](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MaSinhVien] [varchar](50) NOT NULL,
	[TenSinhVien] [nvarchar](50) NOT NULL,
	[GioiTinh] [int] NULL,
	[NgayThangNamSinh] [datetime] NULL,
	[Id_Lop] [int] NULL,
	[Id_khoas] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Diem] ON 

INSERT [dbo].[Diem] ([Id], [DiemQuaTrinh], [DiemThanhPhan], [Id_SinhVien], [Id_MonHoc]) VALUES (1, CAST(2 AS Decimal(18, 0)), CAST(5 AS Decimal(18, 0)), 1, 1)
INSERT [dbo].[Diem] ([Id], [DiemQuaTrinh], [DiemThanhPhan], [Id_SinhVien], [Id_MonHoc]) VALUES (2, CAST(8 AS Decimal(18, 0)), CAST(9 AS Decimal(18, 0)), 1, 2)
INSERT [dbo].[Diem] ([Id], [DiemQuaTrinh], [DiemThanhPhan], [Id_SinhVien], [Id_MonHoc]) VALUES (5, NULL, NULL, 8, 1)
INSERT [dbo].[Diem] ([Id], [DiemQuaTrinh], [DiemThanhPhan], [Id_SinhVien], [Id_MonHoc]) VALUES (6, NULL, NULL, 9, 1)
SET IDENTITY_INSERT [dbo].[Diem] OFF
GO
SET IDENTITY_INSERT [dbo].[Khoas] ON 

INSERT [dbo].[Khoas] ([Id], [MaKhoas], [TenKhoas]) VALUES (1, N'K2023', N'Khóa 2023')
INSERT [dbo].[Khoas] ([Id], [MaKhoas], [TenKhoas]) VALUES (2, N'K2024', N'Khóa 2024')
INSERT [dbo].[Khoas] ([Id], [MaKhoas], [TenKhoas]) VALUES (3, N'K2028', N'Khóa 2024')
SET IDENTITY_INSERT [dbo].[Khoas] OFF
GO
SET IDENTITY_INSERT [dbo].[Lop] ON 

INSERT [dbo].[Lop] ([Id], [MaLop], [TenLop]) VALUES (1, N'CNTT', N'Công Ngh? Thông Tin')
INSERT [dbo].[Lop] ([Id], [MaLop], [TenLop]) VALUES (2, N'TDH', N'Tự Động Hóa')
INSERT [dbo].[Lop] ([Id], [MaLop], [TenLop]) VALUES (3, N'TDH1', N'Tự Động Hóa')
INSERT [dbo].[Lop] ([Id], [MaLop], [TenLop]) VALUES (4, N'KTVT', N'Kinh Tế Vận Tải 2')
SET IDENTITY_INSERT [dbo].[Lop] OFF
GO
SET IDENTITY_INSERT [dbo].[MonHoc] ON 

INSERT [dbo].[MonHoc] ([Id], [MaMonHoc], [TenMonHoc], [SoTietHoc]) VALUES (1, N'IT01_OOP', N'Lập trình hướng đối tượng', 60)
INSERT [dbo].[MonHoc] ([Id], [MaMonHoc], [TenMonHoc], [SoTietHoc]) VALUES (2, N'IT01_CTDL', N'Cấu trúc dữ liệu', 60)
SET IDENTITY_INSERT [dbo].[MonHoc] OFF
GO
SET IDENTITY_INSERT [dbo].[SinhVien] ON 

INSERT [dbo].[SinhVien] ([Id], [MaSinhVien], [TenSinhVien], [GioiTinh], [NgayThangNamSinh], [Id_Lop], [Id_khoas]) VALUES (1, N'201200084', N'Phạm Công Định', 1, CAST(N'2002-04-08T00:00:00.000' AS DateTime), NULL, 1)
INSERT [dbo].[SinhVien] ([Id], [MaSinhVien], [TenSinhVien], [GioiTinh], [NgayThangNamSinh], [Id_Lop], [Id_khoas]) VALUES (8, N'201200088', N'Phạm Công A', 0, CAST(N'2002-01-01T00:00:00.000' AS DateTime), 1, 2)
INSERT [dbo].[SinhVien] ([Id], [MaSinhVien], [TenSinhVien], [GioiTinh], [NgayThangNamSinh], [Id_Lop], [Id_khoas]) VALUES (9, N'201200085', N'Phạm Công B', 0, CAST(N'2002-01-01T00:00:00.000' AS DateTime), NULL, NULL)
INSERT [dbo].[SinhVien] ([Id], [MaSinhVien], [TenSinhVien], [GioiTinh], [NgayThangNamSinh], [Id_Lop], [Id_khoas]) VALUES (10, N'2012000', N'Phạm Công A', 0, CAST(N'2002-01-01T00:00:00.000' AS DateTime), 1, 3)
SET IDENTITY_INSERT [dbo].[SinhVien] OFF
GO
ALTER TABLE [dbo].[Diem]  WITH CHECK ADD  CONSTRAINT [FK_Diem_MonHoc] FOREIGN KEY([Id_MonHoc])
REFERENCES [dbo].[MonHoc] ([Id])
GO
ALTER TABLE [dbo].[Diem] CHECK CONSTRAINT [FK_Diem_MonHoc]
GO
ALTER TABLE [dbo].[Diem]  WITH CHECK ADD  CONSTRAINT [FK_Diem_SinhVien] FOREIGN KEY([Id_SinhVien])
REFERENCES [dbo].[SinhVien] ([Id])
GO
ALTER TABLE [dbo].[Diem] CHECK CONSTRAINT [FK_Diem_SinhVien]
GO
ALTER TABLE [dbo].[SinhVien]  WITH CHECK ADD  CONSTRAINT [FK_SinhVien_Khoas] FOREIGN KEY([Id_khoas])
REFERENCES [dbo].[Khoas] ([Id])
GO
ALTER TABLE [dbo].[SinhVien] CHECK CONSTRAINT [FK_SinhVien_Khoas]
GO
ALTER TABLE [dbo].[SinhVien]  WITH CHECK ADD  CONSTRAINT [FK_SinhVien_Lop] FOREIGN KEY([Id_Lop])
REFERENCES [dbo].[Lop] ([Id])
GO
ALTER TABLE [dbo].[SinhVien] CHECK CONSTRAINT [FK_SinhVien_Lop]
GO
