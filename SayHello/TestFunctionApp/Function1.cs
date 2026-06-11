using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace TestFunctionApp;

public class Function1
{
    private readonly ILogger<Function1> _logger;

    public Function1(ILogger<Function1> logger)
    {
        _logger = logger;
    }

    [Function("SayHello")]
    public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequest req)
    {
        // Read body
        string requestBody = await new StreamReader(req.Body).ReadToEndAsync();

        Dictionary<string, string>? body = null;

        try
        {
            body = JsonSerializer.Deserialize<Dictionary<string, string>>(
                requestBody,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
            );
        }
        catch (JsonException ex)
        {
            return new BadRequestObjectResult("Invalid JSON body1." + ex.Message);
        }

        // Check if "Greet" key exists and has a value
        if (body == null || !body.TryGetValue("Greet", out string? greetValue)
                         || string.IsNullOrWhiteSpace(greetValue))
        {
            return new BadRequestObjectResult("Please provide a 'Greet' key with a value in the request body.");
        }

        // Determine time of day greeting
        string timeGreeting = GetTimeBasedGreeting();

        // Build response
        var result = new
        {
            Message = $"{timeGreeting}! Thanks for saying '{greetValue}'."
        };

        return new OkObjectResult(result);
    }

    private static string GetTimeBasedGreeting()
    {
        int hour = DateTime.Now.Hour; // Use DateTime.UtcNow if you want UTC

        return hour switch
        {
            >= 5 and < 12 => "Good Morning",
            >= 12 and < 17 => "Good Afternoon",
            >= 17 and < 21 => "Good Evening",
            _ => "Good Night"
        };
    }
}