// See https://aka.ms/new-console-template for more information
using DeserializeWithPrivateSetter;
using Newtonsoft.Json;

Console.WriteLine("Hello, World!");

string projectJSON = @"{
    'Id': 1,
    'Name': 'Project-ATA',
    'Description': 'Produce pure energy',
    'Price': 10000
}";

var settings = new JsonSerializerSettings
{
    ContractResolver = new PrivateSetterContracResolver()
};

var deserialized = JsonConvert.DeserializeObject<Project>(projectJSON, settings);

if (deserialized != null )
    Console.WriteLine("Price of the Project: {0}", deserialized.Price);

Console.ReadLine();