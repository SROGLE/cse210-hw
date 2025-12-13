using System;

class Program
{
    static void Main(string[] args)
    {
        Address address1 = new Address("123 Conference Center", "New York", "NY", "USA");
        Lecture lecture = new Lecture(
            "Tech Innovation Summit",
            "Learn about the latest in AI and technology",
            "January 15, 2025",
            "2:00 PM",
            address1,
            "Dr. Sarah Johnson",
            200
        );

        Address address2 = new Address("456 Garden Plaza", "Los Angeles", "CA", "USA");
        Reception reception = new Reception(
            "Company Anniversary Celebration",
            "Celebrating 10 years of success",
            "February 20, 2025",
            "6:00 PM",
            address2,
            "rsvp@company.com"
        );

        Address address3 = new Address("789 Park Ave", "Seattle", "WA", "USA");
        OutdoorGathering gathering = new OutdoorGathering(
            "Summer Music Festival",
            "Live music and food trucks",
            "June 10, 2025",
            "4:00 PM",
            address3,
            "Sunny, 75°F"
        );

        Console.WriteLine("=== Standard Details ===");
        Console.WriteLine(lecture.GetStandardDetails());
        Console.WriteLine();

        Console.WriteLine("=== Full Details ===");
        Console.WriteLine(lecture.GetFullDetails());
        Console.WriteLine("\n" + new string('-', 50) + "\n");
        Console.WriteLine(reception.GetFullDetails());
        Console.WriteLine("\n" + new string('-', 50) + "\n");
        Console.WriteLine(gathering.GetFullDetails());
        Console.WriteLine();

        Console.WriteLine("\n=== Short Descriptions ===");
        Console.WriteLine(lecture.GetShortDescription());
        Console.WriteLine(reception.GetShortDescription());
        Console.WriteLine(gathering.GetShortDescription());
    }
}