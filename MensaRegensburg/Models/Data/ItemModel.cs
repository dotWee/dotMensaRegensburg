using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace MensaRegensburg.Models
{
    [DataContract]
    public class Menu
    {
        [DataMember]
        public List<Item> items { get; set; }
    }

    [DataContract]
	public class Item
    {
        public static Dictionary<Weekday, string> ValuesMap;

        static Item()
        {
            ValuesMap = new Dictionary<Weekday, string>();
			ValuesMap.Add(Weekday.MONDAY, "mo");
			ValuesMap.Add(Weekday.TUESDAY, "di");
			ValuesMap.Add(Weekday.WEDNESDAY, "mi");
			ValuesMap.Add(Weekday.THURSDAY, "do");
			ValuesMap.Add(Weekday.FRIDAY, "fr");
        }

        public Item()
        {
            
        }

        [DataMember]
		public string name { get; set; }

        [DataMember]
		public string day { get; set; }

        [DataMember]
		public string category { get; set; }

        [DataMember]
		public string labels { get; set; }

        [DataMember]
		public Cost cost { get; set; }

        [DataMember]
		public int id { get; set; }

        [DataMember]
		public int upvotes { get; set; }

        [DataMember]
		public int downvotes { get; set; }
    }

    [DataContract]
	public class Cost
	{
        [DataMember]
		public string students { get; set; }

        [DataMember]
		public string employees { get; set; }

        [DataMember]
		public string guests { get; set; }
	}
}
