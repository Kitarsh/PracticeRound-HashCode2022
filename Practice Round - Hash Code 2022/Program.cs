// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

// var fileName = "./../../../Inputs/a_an_example.in.txt";
// var fileName = "./../../../Inputs/b_basic.in.txt";
// var fileName = "./../../../Inputs/c_coarse.in.txt";
// var fileName = "./../../../Inputs/d_difficult.in.txt";
var fileName = "./../../../Inputs/e_elaborate.in.txt";

var inputs = Samples.GetInputs(fileName); // Get inputs from files

var bestOutput = Pizzeria.GetBestMenu(inputs); // Business is done in here
var nbOfClientWithThisMenu = Pizzeria.GetClientsFromMenu(bestOutput);

for (var ratio = 1.0; ratio > 0.5; ratio = ratio - 0.05)
{
    var output = Pizzeria.GetBestMenu(inputs, ratio);
    if (nbOfClientWithThisMenu < Pizzeria.GetClientsFromMenu(output))
    {
        nbOfClientWithThisMenu = Pizzeria.GetClientsFromMenu(output);
        Console.WriteLine($"Nb of Clients : {nbOfClientWithThisMenu}");
    }
}

Console.WriteLine($"Nb of Clients : {nbOfClientWithThisMenu}");

Samples.WriteOutput(bestOutput); // Write in a txt file.