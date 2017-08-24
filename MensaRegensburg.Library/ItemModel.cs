using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using MensaRegensburg.Library;

namespace MensaRegensburg.Library
{
    [DataContract]
	public class Item
    {
        public static Dictionary<Weekday, string> WeekdayValuesMap;
        public static string[] WeekdayValues;

        static Item()
        {
            WeekdayValues = new string[5] { "mo", "di", "mi", "do", "fr" };

            WeekdayValuesMap = new Dictionary<Weekday, string>();
			WeekdayValuesMap.Add(Weekday.MONDAY, WeekdayValues[0]);
			WeekdayValuesMap.Add(Weekday.TUESDAY, WeekdayValues[1]);
			WeekdayValuesMap.Add(Weekday.WEDNESDAY, WeekdayValues[2]);
			WeekdayValuesMap.Add(Weekday.THURSDAY, WeekdayValues[3]);
			WeekdayValuesMap.Add(Weekday.FRIDAY, WeekdayValues[4]);
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
