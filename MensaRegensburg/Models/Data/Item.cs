using System;
namespace MensaRegensburg.Models.Data
{
    public class Item
    {
        public Item()
        {
        }

		private string name;
		private DateTime date;
		private string info;
		private Label[] labels;
		private string priceEmployee;
		private string priceGuest;
		private string priceStudent;
		private string priceAll;
		private string tag;
		private Type type;
    }
}
