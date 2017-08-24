using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;
using MensaRegensburg.Library;

namespace MensaRegensburg.Models
{
	public class IndexViewModel
	{
		public Dictionary<Weekday, Menu> MenuMap { get; set; } = new Dictionary<Weekday, Menu>();

		public IndexViewModel(params Weekday[] arrayOfWeekdaysToShow)
		{
			weekdaysToShow = arrayOfWeekdaysToShow;
			
			foreach (Weekday weekday in weekdaysToShow)
			{
				Menu menu = API.GetMenu(weekday);
				MenuMap[weekday] = menu;
			}
		}

		public Weekday[] weekdaysToShow { get; }

		public List<Item> GetItems(Weekday weekday) => MenuMap[weekday].items;

		public int GetPosition(Weekday weekday, Item item) => GetItems(weekday).IndexOf(item) + 1;
	}
}