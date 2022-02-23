public class Pizzeria
{
    private static double clientPleasedPercentage = 0.0;

    private static List<Ingredient> ingredients = new List<Ingredient>();

    private static List<Client> clients = new List<Client>();

    public static void PopulateClientsAndIngredients(List<Client> inputs)
    {
        clients = inputs;
        foreach (var client in inputs)
        {
            addIngredient(client.GetLikedIngredients(), true);
            addIngredient(client.GetDislikedIngredients(), false);
        }
    }

    public static string[] GetBestMenu(double acceptedRatio = 1.0)
    {
        var ingToUse = ingredients.OrderByDescending(i => i.Ratio)
                                  .Where(i => i.Ratio >= acceptedRatio)
                                  .Select(i => i.Name)
                                  .ToArray();

        return ingToUse;
    }

    public static void LogIngredients()
    {
        Console.WriteLine("Ingredients :");
        foreach (var i in ingredients)
        {
            Console.WriteLine($"{i.Name} : {i.Ratio}");
        }
    }

    internal static int GetPleasedClientsFromMenu(string[] ingredients)
    {
        var pleasedClients = clients.Where(c => c.IsPleased(ingredients)).ToList().Count;
        clientPleasedPercentage = (double)pleasedClients * 100.0 / (double)clients.Count;
        Console.WriteLine($"% clients pleased : {clientPleasedPercentage}");
        return pleasedClients;
    }

    private static void addIngredient(string[] ingredientsListOfClient, bool isLiked)
    {
        foreach (var ingredient in ingredientsListOfClient)
        {
            if (!ingredients.Any(i => i.Name == ingredient))
            {
                ingredients.Add(new Ingredient
                {
                    Name = ingredient,
                    NbOfLike = isLiked ? 1 : 0,
                    NbOfDislike = !isLiked ? 1 : 0,
                    Ratio = isLiked ? 1 : 0,
                    Composition = isLiked ? new List<int> { ingredientsListOfClient.Count() } : new List<int>(),
                });
            }
            else
            {
                var ing = ingredients.FirstOrDefault(i => i.Name == ingredient);
                if (isLiked)
                {
                    ing.NbOfLike++;
                    ing.Composition.Add(ingredientsListOfClient.Count());
                }
                else
                {
                    ing.NbOfDislike++;
                }
                //ing.Ratio = (ing.NbOfLike* ing.NbOfLike / (ing.NbOfLike* ing.NbOfLike + ing.NbOfDislike));
                ing.Ratio = (ing.NbOfLike + (double)ing.Composition.Count) / (ing.NbOfLike + (double)ing.Composition.Count + ing.NbOfDislike);
            }
        }
    }
}
