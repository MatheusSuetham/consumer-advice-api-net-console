using System.Text.Json;

const string apiUrl = "https://api.adviceslip.com/advice";

using HttpClient client = new();

try
{
    string json = await client.GetStringAsync(apiUrl);

    using JsonDocument document = JsonDocument.Parse(json);

    string advice = document.RootElement
        .GetProperty("slip")
        .GetProperty("advice")
        .GetString() ?? "Não foi possível obter o conselho.";

    Console.WriteLine("Conselho de Hoje:");
    Console.WriteLine(advice);
}
catch (HttpRequestException)
{
    Console.WriteLine("Não foi possível acessar a API de conselhos.");
}
catch (JsonException)
{
    Console.WriteLine("Não foi possível interpretar a resposta da API.");
}
