public class Pizzeria
{
    private static double clientPleasedPercentage = 0.0;

    private static List<Ingredient> ingredients = new List<Ingredient>();

    private static List<Client> clients = new List<Client>();

    private static double acceptedRatio = 1;

    public static string[] GetBestMenu(List<Client> inputs, double newAcceptedRatio = 1)
    {
        acceptedRatio = newAcceptedRatio;
        clients = inputs;
        foreach (var client in inputs)
        {
            addIngredient(client.GetLikedIngredients(), true);
            addIngredient(client.GetDislikedIngredients(), false);
        }

        Console.WriteLine("Ingredients :");
        foreach(var i in ingredients) 
        {
            Console.WriteLine($"{i.Name} : {i.Ratio}");
        }

        var ingToUse = ingredients.OrderByDescending(i => i.Ratio)
                                  .Where(i => i.Ratio >= acceptedRatio)
                                  .ToList();

        return ingToUse.Select(i => i.Name).ToArray();
    }

    internal static int GetClientsFromMenu(string[] ingredients)
    {
        var pleasedClients = clients.Where(c => c.IsPleased(ingredients)).ToList().Count;
        clientPleasedPercentage = pleasedClients / clients.Count;
        return pleasedClients;
    }

    private static void addIngredient(string[] ingredientsList, bool isLiked)
    {
        foreach (var ingredient in ingredientsList)
        {
            if (!ingredients.Any(i => i.Name == ingredient))
            {
                ingredients.Add(new Ingredient
                {
                    Name = ingredient,
                    NbOfLike = isLiked ? 1 : 0,
                    NbOfDislike = !isLiked ? 1 : 0,
                    Ratio = isLiked ? 1 : 0,
                });
            }
            else
            {
                var ing = ingredients.FirstOrDefault(i => i.Name == ingredient);
                if (isLiked)
                {
                    ing.NbOfLike++;
                }
                else
                {
                    ing.NbOfDislike++;
                }
                ing.Ratio = (ing.NbOfLike / (ing.NbOfLike + ing.NbOfDislike)); // / ingredients.Count;
            }
        }
    }
}
