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

string name = pokemon.name;

Console.WriteLine("The Pokemon with ID " + userId + " is " + name.ToUpper());




public class Pokemon
{
    public string name { get; set; }
}