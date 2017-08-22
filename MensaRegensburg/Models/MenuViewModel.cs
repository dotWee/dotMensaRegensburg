using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;

namespace MensaRegensburg.Models
{
	public class MenuViewModel
	{
		public string[] WeekdayValues = new string[5] { "mo", "di", "mi", "do", "fr" };
		public Dictionary<Weekday, Menu> MenuMap { get; set; } = new Dictionary<Weekday, Menu>();

		public MenuViewModel(params Weekday[] arrayOfWeekdaysToShow)
		{
            weekdaysToShow = arrayOfWeekdaysToShow;
			DownloadMenus();
		}

        public Weekday[] weekdaysToShow { get; }

		public List<Item> GetItems(Weekday weekday)
		{
			return MenuMap[weekday].items;
		}

		private void DownloadMenus()
		{
            foreach (Weekday weekday in weekdaysToShow)
            {
				string value = Item.ValuesMap[weekday];

				string json;
				using (var webClient = new System.Net.WebClient())
				{
					json = webClient.DownloadString($"http://132.199.139.24:9001/mensa/uni/{value}");
				}

				Menu menu = new Menu();
				using (MemoryStream stream = new MemoryStream(System.Text.Encoding.Default.GetBytes(json)))
				{
					DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(List<Item>));
					List<Item> items = (List<Item>)serializer.ReadObject(stream);
					menu.items = items;
				}

				Console.WriteLine($"Downloaded menu for day={value} with count={menu.items.Count}");
				MenuMap[weekday] = menu;
            }
		}
	}
}
