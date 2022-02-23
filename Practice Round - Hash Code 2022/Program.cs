// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

var fileName = "./../../../Inputs/a_an_example.in.txt";
// var fileName = "./../../../Inputs/b_basic.in.txt";

var inputs = Samples.GetInputs(fileName); // Get inputs from files

var output = Pizzeria.GetBestMenu(inputs); // Business is done in here

var nbOfClientWithThisMenu = Pizzeria.GetClientsFromMenu(output);
Console.WriteLine($"Nb of Clients : {nbOfClientWithThisMenu}");

Samples.WriteOutput(output); // Write in a txt file.