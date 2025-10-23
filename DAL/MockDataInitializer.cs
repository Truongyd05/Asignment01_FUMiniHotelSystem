using Models;

namespace DAL
{
    public static class MockDataInitializer
    {
        private static int _nextCustomerId = 1;
        private static int _nextRoomTypeId = 1;
        private static int _nextRoomId = 1;
        private static int _nextBookingId = 1;

        public static List<Customer> InitializeCustomers()
        {
            return new List<Customer>
            {
                new Customer
                {
                    CustomerID = _nextCustomerId++,
                    CustomerFullName = "Nguyen Van A",
                    Telephone = "0123456789",
                    EmailAddress = "nguyenvana@email.com",
                    CustomerBirthday = new DateTime(1990, 5, 15),
                    CustomerStatus = 1,
                    Password = "password123"
                },
                new Customer
                {
                    CustomerID = _nextCustomerId++,
                    CustomerFullName = "Tran Thi B",
                    Telephone = "0987654321",
                    EmailAddress = "tranthib@email.com",
                    CustomerBirthday = new DateTime(1985, 8, 22),
                    CustomerStatus = 1,
                    Password = "password456"
                },
                new Customer
                {
                    CustomerID = _nextCustomerId++,
                    CustomerFullName = "Le Van C",
                    Telephone = "0369258147",
                    EmailAddress = "levanc@email.com",
                    CustomerBirthday = new DateTime(1992, 12, 3),
                    CustomerStatus = 1,
                    Password = "password789"
                },
                new Customer
                {
                    CustomerID = _nextCustomerId++,
                    CustomerFullName = "Pham Thi D",
                    Telephone = "0741852963",
                    EmailAddress = "phamthid@email.com",
                    CustomerBirthday = new DateTime(1988, 3, 18),
                    CustomerStatus = 1,
                    Password = "passwordabc"
                },
                new Customer
                {
                    CustomerID = _nextCustomerId++,
                    CustomerFullName = "Hoang Van E",
                    Telephone = "0852741963",
                    EmailAddress = "hoangvane@email.com",
                    CustomerBirthday = new DateTime(1995, 7, 25),
                    CustomerStatus = 1,
                    Password = "passworddef"
                }
            };
        }

        public static List<RoomType> InitializeRoomTypes()
        {
            return new List<RoomType>
            {
                new RoomType
                {
                    RoomTypeID = _nextRoomTypeId++,
                    RoomTypeName = "Standard",
                    TypeDescription = "Standard room with basic amenities",
                    TypeNote = "Basic room type"
                },
                new RoomType
                {
                    RoomTypeID = _nextRoomTypeId++,
                    RoomTypeName = "Deluxe",
                    TypeDescription = "Deluxe room with premium amenities",
                    TypeNote = "Premium room type"
                },
                new RoomType
                {
                    RoomTypeID = _nextRoomTypeId++,
                    RoomTypeName = "Suite",
                    TypeDescription = "Luxury suite with full amenities",
                    TypeNote = "Luxury room type"
                },
                new RoomType
                {
                    RoomTypeID = _nextRoomTypeId++,
                    RoomTypeName = "Family",
                    TypeDescription = "Family room for multiple guests",
                    TypeNote = "Family-friendly room type"
                },
                new RoomType
                {
                    RoomTypeID = _nextRoomTypeId++,
                    RoomTypeName = "Executive",
                    TypeDescription = "Executive room for business travelers",
                    TypeNote = "Business room type"
                }
            };
        }

        public static List<RoomInformation> InitializeRooms(List<RoomType> roomTypes)
        {
            var rooms = new List<RoomInformation>();
            var random = new Random();

            // Standard rooms
            for (int i = 1; i <= 10; i++)
            {
                rooms.Add(new RoomInformation
                {
                    RoomID = _nextRoomId++,
                    RoomNumber = $"S{i:D3}",
                    RoomDetailDescription = $"Standard room {i} with basic amenities",
                    RoomMaxCapacity = 2,
                    RoomTypeID = roomTypes.First(rt => rt.RoomTypeName == "Standard").RoomTypeID,
                    RoomStatus = 1,
                    RoomPricePerDay = 500000 + random.Next(0, 100000)
                });
            }

            // Deluxe rooms
            for (int i = 1; i <= 8; i++)
            {
                rooms.Add(new RoomInformation
                {
                    RoomID = _nextRoomId++,
                    RoomNumber = $"D{i:D3}",
                    RoomDetailDescription = $"Deluxe room {i} with premium amenities",
                    RoomMaxCapacity = 3,
                    RoomTypeID = roomTypes.First(rt => rt.RoomTypeName == "Deluxe").RoomTypeID,
                    RoomStatus = 1,
                    RoomPricePerDay = 800000 + random.Next(0, 200000)
                });
            }

            // Suite rooms
            for (int i = 1; i <= 5; i++)
            {
                rooms.Add(new RoomInformation
                {
                    RoomID = _nextRoomId++,
                    RoomNumber = $"SU{i:D3}",
                    RoomDetailDescription = $"Luxury suite {i} with full amenities",
                    RoomMaxCapacity = 4,
                    RoomTypeID = roomTypes.First(rt => rt.RoomTypeName == "Suite").RoomTypeID,
                    RoomStatus = 1,
                    RoomPricePerDay = 1500000 + random.Next(0, 500000)
                });
            }

            // Family rooms
            for (int i = 1; i <= 6; i++)
            {
                rooms.Add(new RoomInformation
                {
                    RoomID = _nextRoomId++,
                    RoomNumber = $"F{i:D3}",
                    RoomDetailDescription = $"Family room {i} for multiple guests",
                    RoomMaxCapacity = 6,
                    RoomTypeID = roomTypes.First(rt => rt.RoomTypeName == "Family").RoomTypeID,
                    RoomStatus = 1,
                    RoomPricePerDay = 1000000 + random.Next(0, 300000)
                });
            }

            // Executive rooms
            for (int i = 1; i <= 4; i++)
            {
                rooms.Add(new RoomInformation
                {
                    RoomID = _nextRoomId++,
                    RoomNumber = $"E{i:D3}",
                    RoomDetailDescription = $"Executive room {i} for business travelers",
                    RoomMaxCapacity = 2,
                    RoomTypeID = roomTypes.First(rt => rt.RoomTypeName == "Executive").RoomTypeID,
                    RoomStatus = 1,
                    RoomPricePerDay = 1200000 + random.Next(0, 400000)
                });
            }

            return rooms;
        }

        public static List<BookingReservation> InitializeBookings(List<Customer> customers, List<RoomInformation> rooms)
        {
            var bookings = new List<BookingReservation>();
            var random = new Random();

            // Create some sample bookings
            for (int i = 0; i < 5; i++)
            {
                var customer = customers[random.Next(customers.Count)];
                var room = rooms[random.Next(rooms.Count)];
                var startDate = DateTime.Now.AddDays(random.Next(-30, 30));
                var endDate = startDate.AddDays(random.Next(1, 7));

                var booking = new BookingReservation
                {
                    BookingReservationID = _nextBookingId++,
                    BookingDate = DateTime.Now.AddDays(random.Next(-60, 0)),
                    TotalPrice = room.RoomPricePerDay * (decimal)(endDate - startDate).Days,
                    CustomerID = customer.CustomerID,
                    BookingStatus = 1
                };

                bookings.Add(booking);
            }

            return bookings;
        }

        public static List<BookingDetail> InitializeBookingDetails(List<BookingReservation> bookings, List<RoomInformation> rooms)
        {
            var bookingDetails = new List<BookingDetail>();
            var random = new Random();

            foreach (var booking in bookings)
            {
                var room = rooms[random.Next(rooms.Count)];
                var startDate = DateTime.Now.AddDays(random.Next(-30, 30));
                var endDate = startDate.AddDays(random.Next(1, 7));

                bookingDetails.Add(new BookingDetail
                {
                    BookingReservationID = booking.BookingReservationID,
                    RoomID = room.RoomID,
                    StartDate = startDate,
                    EndDate = endDate,
                    ActualPrice = room.RoomPricePerDay * (decimal)(endDate - startDate).Days
                });
            }

            return bookingDetails;
        }

        public static void ResetIds()
        {
            _nextCustomerId = 1;
            _nextRoomTypeId = 1;
            _nextRoomId = 1;
            _nextBookingId = 1;
        }
    }
}

