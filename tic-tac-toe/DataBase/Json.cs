using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;


namespace tic_tac_toe.DataBase
{
    public static class Json
    {
        private static readonly JsonSerializerOptions Options = new()
            { ReferenceHandler = ReferenceHandler.IgnoreCycles, WriteIndented = true };

        private const string Filepath =
            @"C:\\Users\\User\\RiderProjects\\Project\\tic-tac-toe\\tic-tac-toe\\DataBase\\Info.json";


        public static DbContext Load()
        {
            var json = File.ReadAllText(Filepath);
            return JsonConvert.DeserializeObject<DbContext>(json);
        }

        public static void Save(DbContext dbContext)
        {
            var jsonString = JsonSerializer.Serialize(dbContext, Options);
            File.WriteAllText(Filepath, jsonString);
        }
    }
}