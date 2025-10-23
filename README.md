# FUMiniHotelSystem - PRN212 Assignment 01

## 🎯 Mô tả dự án
Dự án **FUMiniHotelSystem** là một ứng dụng quản lý khách sạn mini được phát triển bằng **WPF + LINQ** với kiến trúc **3-layer + MVVM + Repository + Singleton**.

## 🏗️ Kiến trúc dự án

### Solution Structure
```
PhungDangTruong_SE19B2_A01.sln
├── Models/                    # Business Objects
├── DAL/                      # Data Access Layer (Repository Pattern)
├── BLL/                      # Business Logic Layer (Services)
└── PhungDangTruongWPF/       # Presentation Layer (WPF + MVVM)
```

### Project References
- `DAL` → references `Models`
- `BLL` → references `DAL`, `Models`
- `PhungDangTruongWPF` → references `BLL`, `Models`

## 🚀 Cách chạy dự án

### Yêu cầu hệ thống
- .NET 9.0 hoặc cao hơn
- Visual Studio 2022 hoặc VS Code

### Các bước chạy
1. Mở terminal/command prompt
2. Navigate đến thư mục dự án
3. Chạy lệnh: `dotnet run --project PhungDangTruongWPF`

## 🔐 Thông tin đăng nhập

### Admin Account
- **Email**: admin@FUMiniHotelSystem.com
- **Password**: @@abc123@@

### Customer Accounts (Dữ liệu mẫu)
- **Email**: nguyenvana@email.com | **Password**: password123
- **Email**: tranthib@email.com | **Password**: password456
- **Email**: levanc@email.com | **Password**: password789

## 📋 Tính năng chính

### 🔑 Đăng nhập
- Đăng nhập Admin: Truy cập đầy đủ các chức năng quản lý
- Đăng nhập Customer: Truy cập các chức năng cơ bản

### 👥 Quản lý khách hàng (Admin)
- ✅ CRUD operations (Create, Read, Update, Delete)
- 🔍 Tìm kiếm khách hàng
- 📊 Hiển thị danh sách khách hàng

### 🏨 Quản lý phòng (Admin)
- ✅ CRUD operations cho phòng và loại phòng
- 🔍 Tìm kiếm phòng
- 📊 Hiển thị thông tin phòng chi tiết

### 📊 Báo cáo (Admin)
- 📈 Xem báo cáo đặt phòng theo khoảng thời gian
- 💰 Tính tổng doanh thu
- 📋 Sắp xếp theo ngày giảm dần

### 👤 Chức năng khách hàng
- ✏️ Cập nhật thông tin cá nhân
- 📜 Xem lịch sử đặt phòng

## 🗄️ Dữ liệu

### In-Memory Database
- Dự án sử dụng **In-Memory List<T>** thay vì cơ sở dữ liệu thật
- Không sử dụng Entity Framework, SQL Server, hay bất kỳ ORM nào
- Dữ liệu được khởi tạo bằng `MockDataInitializer`

### Dữ liệu mẫu
- **3 khách hàng** với thông tin đầy đủ
- **3 loại phòng**: Standard, Deluxe, Suite
- **5 phòng** với giá và mô tả khác nhau
- **4 bản ghi booking** mẫu cho báo cáo

## 🎨 Design Patterns

### MVVM Pattern
- **Model**: Business objects (Customer, Room, RoomType)
- **View**: XAML files với code-behind
- **ViewModel**: Logic xử lý và data binding

### Repository Pattern
- Interface-based repository cho từng entity
- Singleton pattern cho Repository instances
- Separation of concerns giữa data access và business logic

### Singleton Pattern
- Repository instances được quản lý bằng Singleton
- Đảm bảo chỉ có một instance duy nhất

## 📁 Cấu trúc file quan trọng

### Models
- `Customer.cs` - Model khách hàng
- `Room.cs` - Model phòng
- `RoomType.cs` - Model loại phòng
- `MockDataInitializer.cs` - Khởi tạo dữ liệu mẫu

### DAL (Data Access Layer)
- `ICustomerRepository.cs` - Interface repository khách hàng
- `IRoomRepository.cs` - Interface repository phòng
- `IRoomTypeRepository.cs` - Interface repository loại phòng
- `CustomerRepository.cs` - Implementation repository khách hàng
- `RoomRepository.cs` - Implementation repository phòng
- `RoomTypeRepository.cs` - Implementation repository loại phòng

### BLL (Business Logic Layer)
- `CustomerService.cs` - Service xử lý logic khách hàng
- `RoomService.cs` - Service xử lý logic phòng
- `ReportService.cs` - Service xử lý báo cáo

### WPF (Presentation Layer)
- `Views/` - Các màn hình XAML
- `ViewModels/` - Logic xử lý và data binding
- `Commands/` - RelayCommand implementation
- `Services/` - Dialog và Navigation services

## ✅ Kiểm tra yêu cầu

- ✅ Không sử dụng Entity Framework Core
- ✅ Không sử dụng SQL Server
- ✅ Không có ConnectionStrings trong appsettings.json
- ✅ CRUD hoạt động hoàn toàn bằng LINQ to Objects
- ✅ Dữ liệu lưu tạm trong List/ObservableCollection
- ✅ MVVM binding hoạt động đúng
- ✅ Solution build và chạy thành công
- ✅ Kiến trúc 3-layer + MVVM + Repository + Singleton

## 🎓 Thông tin dự án
- **Môn học**: PRN212 - Programming with C# and .NET Framework
- **Assignment**: Assignment 01 - WPF + LINQ
- **Sinh viên**: Phung Dang Truong - SE19B2
- **Giảng viên**: [Tên giảng viên]

---
**Lưu ý**: Dự án này được phát triển theo yêu cầu của Assignment 01, sử dụng In-Memory Database và không kết nối với cơ sở dữ liệu thật.
