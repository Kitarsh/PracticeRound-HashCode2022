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
    
    public string[] GetDislikedIngredients() { return DislikedIngredients; }

    public string[] GetLikedIngredients() { return LikedIngredients; }

}