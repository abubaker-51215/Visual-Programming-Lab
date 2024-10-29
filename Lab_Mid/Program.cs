using System;
using System.Collections.Generic;

class ClubRole
{
    public string Name { get; set; }
    public string Role { get; set; }
    public string ContactInfo { get; set; }

    public ClubRole(string name, string role, string contactInfo)
    {
        Name = name;
        Role = role;
        ContactInfo = contactInfo;
    }
}

class Society
{
    public string Name { get; set; }
    public string Contact { get; set; }
    protected List<string> Activities { get; set; }

    public Society(string name, string contact)
    {
        Name = name;
        Contact = contact;
        Activities = new List<string>();
    }

    public void AddActivity(string activity)
    {
        Activities.Add(activity);
    }

    public List<string> ListEvents()
    {
        return Activities;
    }
}
class FundedSociety : Society
{
    public float FundingAmount { get; set; }

    public FundedSociety(string name, string contact, double fundingAmount) : base(name, contact)
    {
        FundingAmount = fundingAmount;
    }
}
class UnfundedSociety : Society
{
    public UnfundedSociety(string name, string contact) : base(name, contact) { }
}
class StudentClub
{
    public double Budget { get; set; }
    public ClubRole President { get; set; }
    public ClubRole VicePresident { get; set; }
    public ClubRole GeneralSecretary { get; set; }
    public ClubRole FinanceSecretary { get; set; }
    public List<Society> Societies { get; private set; }

    public StudentClub(double budget, ClubRole president, ClubRole vicePresident, ClubRole generalSecretary, ClubRole financeSecretary)
    {
        Budget = budget;
        President = president;
        VicePresident = vicePresident;
        GeneralSecretary = generalSecretary;
        FinanceSecretary = financeSecretary;
        Societies = new List<Society>();
    }

    public void RegisterSociety(Society society)
    {
        Societies.Add(society);
    }

    public void AllocateFunding(string societyName, float amount)
    {
        foreach (var society in Societies)
        {
            if (society is FundedSociety fundedSociety && fundedSociety.Name == societyName)
            {
                fundedSociety.FundingAmount += amount;
                Budget -= amount;
                break;
            }
        }
    }

    public void DisplayFundingInfo()
    {
        foreach (var society in Societies)
        {
            if (society is FundedSociety fundedSociety)
            {
                Console.WriteLine($"{fundedSociety.Name} has received {fundedSociety.FundingAmount:C} in funding.");
            }
        }
    }

    public void DisplayEventsForSociety(string societyName)
    {
        foreach (var society in Societies)
        {
            if (society.Name == societyName)
            {
                var events = society.ListEvents();
                if (events.Count > 0)
                {
                    Console.WriteLine($"Events for {society.Name}: {string.Join(", ", events)}");
                }
                else
                {
                    Console.WriteLine($"No events found for {society.Name}.");
                }
            }
        }
    }
}
class Program
{
    private static float amount;

    static void Main()
    {

        var president = new ClubRole("Ahmad", "President", "ahmad@example.com");
        var vicePresident = new ClubRole("Umer", "Vice President", "umer@example.com");
        var generalSecretary = new ClubRole("Khan", "General Secretary", "khan@example.com");
        var financeSecretary = new ClubRole("Butt", "Finance Secretary", "butt@example.com");

        var club = new StudentClub(10000, president, vicePresident, generalSecretary, financeSecretary);

        while (true)
        {
            // Display menu
            Console.WriteLine("\nStudent Club Management System");
            Console.WriteLine("----------------------------------");
            Console.WriteLine("1. Register Society");
            Console.WriteLine("2. Allocate Funding to Societies");
            Console.WriteLine("3. Register an Event");
            Console.WriteLine("4. Display Society Funding Info");
            Console.WriteLine("5. Display Events for a Society");
            Console.WriteLine("6. Exit");
            Console.Write("Enter your choice: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:

                    Console.Write("Enter society name: ");
                    string name = Console.ReadLine();
                    Console.Write("Enter society contact: ");
                    string contact = Console.ReadLine();
                    Console.Write("Is the society funded (yes/no)? ");
                    bool funded = Console.ReadLine().ToLower() == "yes";
                    if (funded)
                    {
                        Console.Write("Enter funding amount: ");
                        float amount = float.Parse(Console.ReadLine());
                        var fundedSociety = new FundedSociety(name, contact, amount);
                        club.RegisterSociety(fundedSociety);
                    }
                    else
                    {
                        var unfundedSociety = new UnfundedSociety(name, contact);
                        club.RegisterSociety(unfundedSociety);
                    }
                    Console.WriteLine($"Society {name} registered successfully.");
                    break;

                case 2:
                    
                    Console.Write("Enter society name for funding: ");
                    name = Console.ReadLine();
                    Console.Write("Enter funding amount: ");
                    amount = float.Parse(Console.ReadLine());
                    club.AllocateFunding(name, amount);
                    Console.WriteLine($"Funded {amount:C} to {name}.");
                    break;

                case 3:
                    
                    Console.Write("Enter society name for the event: ");
                    name = Console.ReadLine();
                    Console.Write("Enter event description: ");
                    string activity = Console.ReadLine();
                    foreach (var society in club.Societies)
                    {
                        if (society.Name == name)
                        {
                            society.AddActivity(activity);
                            Console.WriteLine($"Event '{activity}' added to {name}.");
                            break;
                        }
                    }
                    break;

                case 4:
                    
                    club.DisplayFundingInfo();
                    break;

                case 5:
                    
                    Console.Write("Enter society name to display events: ");
                    name = Console.ReadLine();
                    club.DisplayEventsForSociety(name);
                    break;

                case 6:
                    
                    return;

                default:
                    Console.WriteLine("Invalid choice, please try again.");
                    break;
            }
        }
    }
}




