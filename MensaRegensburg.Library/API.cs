using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization.Json;

namespace MensaRegensburg.Library
{
    public class API
    {
        internal static DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(List<Item>));

        internal static string GetEndpoint(Weekday weekday) => "http://132.199.139.24:9001/mensa/uni/" + Item.WeekdayValuesMap[weekday];

        internal static string DownloadJson(Weekday weekday)
        {
            string json;
            using (var webClient = new System.Net.WebClient())
			{
				json = webClient.DownloadString(GetEndpoint(weekday));
            }

            // TODO: validate json
            Debug.WriteLine($"Downloaded menu for day={weekday}");
            return json;
        }

        internal static List<Item> ReadItemsFromJson(string json)
        {
            List<Item> items;
            using (MemoryStream stream = new MemoryStream(System.Text.Encoding.Default.GetBytes(json)))
			{
				items = (List<Item>)serializer.ReadObject(stream);
			}

            return items;
        }

        public static Menu GetMenu(Weekday weekday)
        {
            string json = DownloadJson(weekday);

            List<Item> items = ReadItemsFromJson(json);
            
            Debug.WriteLine($"Menu for day={weekday} has item count={items.Count}");
            return new Menu(weekday, items);
        }
    }
}