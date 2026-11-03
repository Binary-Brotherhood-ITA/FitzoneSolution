using FitzoneConsoleApp.Interfaces;
using FitzoneConsoleApp.Frontend;
using FitzoneConsoleApp.Application;
using FitzoneConsoleApp.DataAccessLayer;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

internal class Program
{
    private static void Main(string[] args)
    {
        /* Indlæs konfigurationen fra JSON-filen DataAccessLayer\appsettings.Developer.json
         * Directory.GetCurrentDirectory() finder programmets aktuelle arbejdsmappe.
         * Path.Combine() tilføjer DataAccessLayer til stien.
         * AddJsonFile() finder JSON-filen dér.
         */
        IConfiguration configuration = new ConfigurationBuilder().SetBasePath(Path.Combine(Directory.GetCurrentDirectory(),"DataAccessLayer")).AddJsonFile("appsettings.Development.json", optional: false).Build();

        // Opret forbindelse til MongoDB
        string connectionString = configuration["MongoDb:ConnectionString"]!;
        IMongoClient mongoClient = new MongoClient(connectionString);

        // Opret repositories med de nødvendige argumenter
        IBookingRepository br = new BookingRepository(mongoClient, configuration);
        IMemberRepository mr = new MemberRepository(mongoClient, configuration);
        IFitnessClassRepository fc = new FitnessClassRepository(mongoClient, configuration);

        // Opret controlleren
        BookingController bookingController = new BookingController(br, mr, fc);

        // Opret brugergrænsefladen
        BookingUI ui = new BookingUI(bookingController);

        // Starter bookingmenuen
        ui.Run();

    }
}