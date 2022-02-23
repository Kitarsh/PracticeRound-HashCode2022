// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

// var fileName = "./../../../Inputs/a_an_example.in.txt";
// var fileName = "./../../../Inputs/b_basic.in.txt";
//var fileName = "./../../../Inputs/c_coarse.in.txt";
// var fileName = "./../../../Inputs/d_difficult.in.txt";
var fileName = "./../../../Inputs/e_elaborate.in.txt";

var inputs = Samples.GetInputs(fileName); // Get inputs from files

Pizzeria.PopulateClientsAndIngredients(inputs);

var bestOutput = Pizzeria.GetBestMenu(); // Business is done in here
var nbOfPleasedClientWithThisMenu = Pizzeria.GetPleasedClientsFromMenu(bestOutput);
var lastOutput = bestOutput;

var lastNbOfIngredients = bestOutput.Count();

for (var ratio = 1.0; ratio >= 0.2; ratio = ratio - 0.01)
{
    Console.WriteLine("--------------");
    Console.WriteLine($"Current ratio : {ratio}");
    var output = Pizzeria.GetBestMenu(ratio);
    if(output.Any(ing => !lastOutput.Contains(ing)))
    {
        var diffOutput = output.Where(ing => !lastOutput.Contains(ing)).ToList();
        Console.WriteLine($"Nb of nouveau ingrédients à rajouter : {diffOutput.Count}");
        var newOutput = lastOutput.ToList();
        foreach (var diffIng in diffOutput)
        {
            newOutput.Add(diffIng);
            Console.WriteLine($"Nb of ingredients : {newOutput.Count()}");
            var nbOfClients = Pizzeria.GetPleasedClientsFromMenu(newOutput.ToArray());
            if (nbOfPleasedClientWithThisMenu < nbOfClients)
            {
                nbOfPleasedClientWithThisMenu = nbOfClients;
                bestOutput = output;
                Console.WriteLine($"Nb of Clients : {nbOfPleasedClientWithThisMenu}");
            }
            else if (nbOfPleasedClientWithThisMenu > nbOfClients)
            {
                newOutput.Remove(diffIng);
            }
        }
        output = newOutput.ToArray();
    }
    lastNbOfIngredients = output.Count();
    lastOutput = output;
}

Console.WriteLine($"Nb of Clients : {nbOfPleasedClientWithThisMenu}");

Samples.WriteOutput(bestOutput); // Write in a txt file.