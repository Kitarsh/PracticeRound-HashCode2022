// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

var inputs = Samples.GetInputs(); // Get inputs from files

var output = Pizzeria.GetBestMenu(inputs); // Business is done in here

var nbOfClientWithThisMenu = Pizzeria.GetClientsFromMenu(output);
Console.WriteLine($"Nb of Clients : {nbOfClientWithThisMenu}");

Samples.WriteOutput(output); // Write in a txt file.