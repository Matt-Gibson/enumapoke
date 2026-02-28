using System.Text.Json
;

HttpClient client = new HttpClient();


int userId = 1;



Console.WriteLine("Hello, and Welcome to the World of Pokemon");
Console.WriteLine("Enter a Id Number between 1 and 151 to Identify one of the OGs!!!");

userId = int.Parse(Console.ReadLine());

Console.WriteLine();

string apiString = "https://pokeapi.co/api/v2/pokemon/" + userId + "/";

string jsonResponse = client.GetStringAsync(apiString).Result;

Pokemon pokemon = JsonSerializer.Deserialize<Pokemon>(jsonResponse);

WeightCategory weightCategory;

if (pokemon.weight < 50)
    weightCategory = WeightCategory.VeryLight;
else if (pokemon.weight < 100)
    weightCategory = WeightCategory.Light;
else if (pokemon.weight < 200)
    weightCategory = WeightCategory.Medium;
else if (pokemon.weight < 400)
    weightCategory = WeightCategory.Heavy;
else
    weightCategory = WeightCategory.VeryHeavy;


string name = pokemon.name;
int weight = pokemon.weight;

Console.WriteLine("The Pokemon with ID " + userId + " is " + name.ToUpper());
Console.WriteLine("It weighs " + weight + " hectograms, a " + weightCategory.ToString() + " weight!");


public enum WeightCategory
{
    VeryLight,
    Light,
    Medium,
    Heavy,
    VeryHeavy
}

public class Pokemon
{
    public string name { get; set; }
    public int weight { get; set; }
}