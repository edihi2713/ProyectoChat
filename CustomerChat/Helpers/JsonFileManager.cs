using CustomerChat.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;

namespace CustomerChat.Helpers
{
    public static class JsonFileManager
    {


        public static void saveRequests<T>(List<T>list, string path)
        {
            using (StreamWriter file = System.IO.File.CreateText(path))
            {
                JsonSerializer serializer = new JsonSerializer();
                //serialize object directly into file stream
                serializer.Serialize(file, list);
            }

        }
        public static void LoadJson<T>(ref List<T> list, string path)
        {


            if (!System.IO.File.Exists(path))
            {
                using (StreamWriter file = System.IO.File.CreateText(path))
                {
                    file.Close();
                }
            }

            Thread.Sleep(2000);


            using (StreamReader r = new StreamReader(path))
            {
                string json = r.ReadToEnd();

                if (!string.IsNullOrEmpty(json))
                {
                    list = JsonConvert.DeserializeObject<List<T>>(json);
                }

            }
        }

    }
}