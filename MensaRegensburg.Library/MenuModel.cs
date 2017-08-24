using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using MensaRegensburg.Library;

namespace MensaRegensburg.Library
{
    [DataContract]
    public class Menu
    {
        public Menu(Weekday weekday, List<Item> items)
        {
            this.weekday = weekday;
            this.items = items;
        }
        public Weekday weekday { get; }
        
        [DataMember]
        public List<Item> items { get; }
    }
}