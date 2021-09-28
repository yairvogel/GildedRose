using System;

namespace GildedRose.Console.ItemUpdaters
{
    class CustomItemUpdaterAttribute : Attribute
    {
        public string LinkedName { get; set; }

        public CustomItemUpdaterAttribute(string linkedName)
        {
            LinkedName = linkedName;
        }
    }
}
