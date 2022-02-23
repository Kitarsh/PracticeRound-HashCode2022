namespace Practice_Round___Hash_Code_2022.Model;

public class Client
{
    private string[] DislikedIngredients;
    private string[] LikedIngredients;

    public Client(string unparsedLikIng, string unparsedDislikIng)
    {
        var parsedLikIng = unparsedLikIng.Split(" ");
        this.LikedIngredients = parsedLikIng.Skip(1).ToArray();
        var parsedDislikIng = unparsedDislikIng.Split(" ");
        this.DislikedIngredients = parsedDislikIng.Skip(1).ToArray();
    }

    public void SetDislikedIngredients(string[] dislikedIngredients)
    {
        this.DislikedIngredients = dislikedIngredients;
    }

    public void SetLikedIngredients(string[] likedIngredients)
    {
        this.LikedIngredients = likedIngredients;
    }
    
    public string[] GetDislikedIngredients() { 
        return DislikedIngredients;
    }

    internal bool IsPleased(string[] ingredients)
    {
        if(ingredients.Any(i => DislikedIngredients.Contains(i)))
        {
            // One disliked ingredient is in pizza.
            return false;
        }

        if(LikedIngredients.All(li => ingredients.Contains(li)))
        {
            // All liked ingredient are in pizza.
            return true;
        }

        return false;
    }

    public string[] GetLikedIngredients() {
        return LikedIngredients;
    }

}