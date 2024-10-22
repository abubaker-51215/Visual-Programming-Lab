using System;
using System.Collections.Generic;

public class Customer
{
    public int CustomerId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Street { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string ZipCode { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}

public class CorporateCustomer : Customer
{
    public string CompanyName { get; set; }
    public string BillingAccountNo { get; set; }
    public string CreditCardType { get; set; }
    public string CreditCardNo { get; set; }
}

public class RetailCustomer : Customer
{
    public int FrequentFlyerPts { get; set; }
}

public class Flight
{
    public int FlightId { get; set; }
    public DateTime Date { get; set; }
    public string Origin { get; set; }
    public string Destination { get; set; }
    public TimeSpan DepartureTime { get; set; }
    public TimeSpan ArrivalTime { get; set; }
    public int SeatingCapacity { get; set; }
}

public class Seat
{
    public string SeatNo { get; set; }
    public decimal Price { get; set; }
    public string Status { get; set; }
}

public class Reservation
{
    public int ReservationNo { get; set; }
    public Customer Customer { get; set; }
    public Flight Flight { get; set; }
    public Seat Seat { get; set; }
    public DateTime Date { get; set; }
}

class Program
{
    static void Main()
    {
        // Example usage:
        CorporateCustomer corpCustomer = new CorporateCustomer
        {
            CustomerId = 1,
            FirstName = "AHmad",
            LastName = "alvi",
            CompanyName = "Corp",
            BillingAccountNo = "123456",
            CreditCardType = "Visa",
            CreditCardNo = "4111111111111111"
        };

        Flight flight = new Flight
        {
            FlightId = 101,
            Date = DateTime.Now,
            Origin = "New York",
            Destination = "Los Angeles",
            DepartureTime = new TimeSpan(10, 30, 0),
            ArrivalTime = new TimeSpan(13, 45, 0),
            SeatingCapacity = 150
        };

        Seat seat = new Seat
        {
            SeatNo = "1A",
            Price = 500.00m,
            Status = "Reserved"
        };

        Reservation reservation = new Reservation
        {
            ReservationNo = 1001,
            Customer = corpCustomer,
            Flight = flight,
            Seat = seat,
            Date = DateTime.Now
        };

        Console.WriteLine($"Reservation Details:\nReservation No: {reservation.ReservationNo}\nCustomer: {reservation.Customer.FirstName} {reservation.Customer.LastName}\nFlight: {reservation.Flight.Origin} to {reservation.Flight.Destination}\nSeat: {reservation.Seat.SeatNo}\nPrice: {reservation.Seat.Price:C}");
    }
}
