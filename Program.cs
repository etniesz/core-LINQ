List<Eruption> eruptions = new List<Eruption>()
{
    new Eruption("La Palma", 2021, "Canary Is", 2426, "Stratovolcano"),
    new Eruption("Villarrica", 1963, "Chile", 2847, "Stratovolcano"),
    new Eruption("Chaiten", 2008, "Chile", 1122, "Caldera"),
    new Eruption("Kilauea", 2018, "Hawaiian Is", 1122, "Shield Volcano"),
    new Eruption("Hekla", 1206, "Iceland", 1490, "Stratovolcano"),
    new Eruption("Taupo", 1910, "New Zealand", 760, "Caldera"),
    new Eruption("Lengai, Ol Doinyo", 1927, "Tanzania", 2962, "Stratovolcano"),
    new Eruption("Santorini", 46,"Greece", 367, "Shield Volcano"),
    new Eruption("Katla", 950, "Iceland", 1490, "Subglacial Volcano"),
    new Eruption("Aira", 766, "Japan", 1117, "Stratovolcano"),
    new Eruption("Ceboruco", 930, "Mexico", 2280, "Stratovolcano"),
    new Eruption("Etna", 1329, "Italy", 3320, "Stratovolcano"),
    new Eruption("Bardarbunga", 1477, "Iceland", 2000, "Stratovolcano")
};
// Example Query - Prints all Stratovolcano eruptions
IEnumerable<Eruption> stratovolcanoEruptions = eruptions.Where(c => c.Type == "Stratovolcano");
PrintEach(stratovolcanoEruptions, "Stratovolcano eruptions.");
// Execute Assignment Tasks here!
Console.WriteLine("\nUse LINQ to find the first eruption that is in Chile and print the result.");
Eruption firstEruptionInChile = eruptions.First(loc => loc.Location == "Chile");
Console.WriteLine(firstEruptionInChile);

Console.WriteLine("\nFind the first eruption from the Hawaiian Is location and print it. If none is found, print No Hawaiian Is Eruption found.");
Eruption firstEruptionInHawaii = eruptions.First(loc => loc.Location == "Hawaiian Is");
if (firstEruptionInHawaii != null)
{
    Console.WriteLine(firstEruptionInHawaii);
}
else
{
    Console.WriteLine("No Hawaiian Is Eruption found.");
}

Console.WriteLine("\nFind the first eruption that is after the year 1900 AND in New Zealand, then print it.");
Eruption firstEruptionNewZealand = eruptions.First(loc => loc.Location == "New Zealand" && loc.Year > 1900);
Console.WriteLine(firstEruptionNewZealand);

// Console.WriteLine("\nFind all eruptions where the volcano's elevation is over 2000m and print them.");
IEnumerable<Eruption> volcanoElevation = eruptions.Where(e => e.ElevationInMeters > 2000);
PrintEach(volcanoElevation, "Find all eruptions where the volcano's elevation is over 2000m and print them.");

IEnumerable<Eruption> eruptionsStartingWithL = eruptions.Where(c => c.Volcano.StartsWith("L"));
PrintEach(eruptionsStartingWithL, "Find all eruptions where the volcano's name starts with L and print them.");
Console.WriteLine($"Also print the number of eruptions found: {eruptionsStartingWithL.Count()}");

Console.WriteLine("\nFind the highest elevation, and print only that integer");
int highestElevation = eruptions.Max(c => c.ElevationInMeters);
Console.WriteLine(highestElevation);

Console.WriteLine("\nUse the highest elevation variable to find a print the name of the Volcano with that elevation.");
Eruption highestElevationEruption = eruptions.First(c => c.ElevationInMeters == highestElevation);
Console.WriteLine(highestElevationEruption.Volcano);


IEnumerable<string> volcanoNames = eruptions.Select(c => c.Volcano).OrderBy(c => c);
PrintEach(volcanoNames, "Print all Volcano names alphabetically.");

IEnumerable<Eruption> eruptionsBefore1000 = eruptions.Where(c => c.Year < 1000).OrderBy(c => c.Volcano);
PrintEach(eruptionsBefore1000, "Print all the eruptions that happened before the year 1000 CE alphabetically according to Volcano name.");

IEnumerable<string> volcanoNamesBefore1000 = eruptions.Where(c => c.Year < 1000).OrderBy(c => c.Volcano).Select(c => c.Volcano);
PrintEach(volcanoNamesBefore1000, "BONUS: Redo the last query, but this time use LINQ to only select the volcano's name so that only the names are printed.");

// Helper method to print each item in a List or IEnumerable.This should remain at the bottom of your class!
static void PrintEach(IEnumerable<dynamic> items, string msg = "")
{
    Console.WriteLine("\n" + msg);
    foreach (var item in items)
    {
        Console.WriteLine(item.ToString());
    }
}
