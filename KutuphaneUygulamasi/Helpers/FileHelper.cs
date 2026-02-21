using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace KutuphaneUygulamasi.Helpers
{
    public static class FileHelper
    {
        public static List<T> LoadData<T>(string filePath)
        {
            if (File.Exists(filePath))
            {
                var jsonData = File.ReadAllText(filePath);
                return JsonConvert.DeserializeObject<List<T>>(jsonData) ?? new List<T>();
            }
            return new List<T>();
        }


        public static void SaveData<T>(string filePath, List<T> data)
        {
            var jsonData = JsonConvert.SerializeObject(data, Formatting.Indented);
            File.WriteAllText(filePath, jsonData);
        }
    }
}
