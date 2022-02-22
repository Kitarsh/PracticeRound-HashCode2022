﻿// See https://aka.ms/new-console-template for more information
internal class Samples
{
    internal static object GetInputs()
    {
        var fileName = "./../../../Inputs/a_an_example.in.txt";
        string fileContent = File.ReadAllText(fileName);

        Console.WriteLine("Read from file !");
        Console.Write(fileContent);

        var lines = fileContent.Split("\n");
        int nbOfClient = Int32.Parse(lines[0]);
        Console.WriteLine(nbOfClient);

        List<Client> clients = new List<Client>();

        for (var i = 1; i <= nbOfClient; i++)
        {
            Console.WriteLine($"Client {i} likes : {lines[2 * i - 1]}");
            Console.WriteLine($"Client {i} dislikes : {lines[2 * i]}");

            clients.Add(new Client(lines[2 * i - 1], lines[2 * i]));
        }
        return clients;
    }

    internal static void WriteOutput(object output)
    {
        throw new NotImplementedException();
    }
}