using Newtonsoft.Json;

string ApiUrl = $"https://evilinsult.com/generate_insult.php?lang=en&type=json";

using (var client = new HttpClient())
{
    try
    {
        Console.WriteLine("Write next to see a joke");
        while (true)
        {
            string UserResponse = Console.ReadLine();
            if (UserResponse == "next")
            {
                HttpResponseMessage response = await client.GetAsync(ApiUrl);
                response.EnsureSuccessStatusCode();

                string ResponseBody = await response.Content.ReadAsStringAsync();

                dynamic EvilJoke = JsonConvert.DeserializeObject(ResponseBody);
                var Insult = EvilJoke.insult;
                Console.WriteLine($"{Insult} \n");
            }
            else
            {
                Console.WriteLine("U won t any jokes? u make me cry (");
            }
        }
    }
    catch (HttpRequestException ex)
    {
        Console.WriteLine($"Error with sending");
    }
}
