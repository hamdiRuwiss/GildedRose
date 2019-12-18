using System.Collections.Generic;

namespace GildedRose.Console
{
   public class Program
    {
        public IList<Item> Items;
        public int low_value_of_quality = 0;
        public int high_value_of_quality = 50;
        public int high_value_of_sellen = 0;

        public Program(List<Item> items) {
            Items = items;
        }
        public Program()
        {
            
        }
        static void Main(string[] args)
        {
            System.Console.WriteLine("OMGHAI!");

            var app = new Program()
                          {
                              Items = new List<Item>
                                          {
                                              new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
                                              new Item {Name = "Aged Brie", SellIn = 2, Quality = 0},
                                              new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
                                              new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
                                              new Item
                                                  {
                                                      Name = "Backstage passes to a TAFKAL80ETC concert",
                                                      SellIn = 15,
                                                      Quality = 20
                                                  },
                                              new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6}
                                          }

                          };

            app.UpdateQuality();

            System.Console.ReadKey();

        }

        public void UpdateQuality()
        {
            for (var i = 0; i < Items.Count; i++)
            {
                if (Items[i].Name == "Aged Brie") { decreasedSellen(i); AgedBrie(i); }
                if (Items[i].Name == "Sulfuras, Hand of Ragnaros") {  Sulfuras(i); }
                if (Items[i].Name == "Backstage passes to a TAFKAL80ETC concert") { decreasedSellen(i); Backstage(i); }
                if (Items[i].Name == "Conjured Mana Cake") { decreasedSellen(i); Conjured(i); }
                if (Items[i].Name != "Aged Brie" && Items[i].Name != "Backstage passes to a TAFKAL80ETC concert" && Items[i].Name !=
                    "Sulfuras, Hand of Ragnaros" && Items[i].Name != "Conjured Mana Cake")
                {   decreasedSellen(i);
                    if (Items[i].Quality > low_value_of_quality)
                    { decreasedQuality_one(i); }
                    if(Items[i].Quality > low_value_of_quality&& Items[i].SellIn < 0)
                    { decreasedQuality_one(i); }

                    
                }

            }

            
        }

        public void increaseQuality_by_one(int index)
        { Items[index].Quality = Items[index].Quality + 1; }

        public void decreasedQuality_one(int index)
        { Items[index].Quality = Items[index].Quality -1; }

        public void decreasedSellen(int index)
        { Items[index].SellIn = Items[index].SellIn - 1; }

        public void QualityNotAboveFifty(int index)
        {
            if (Items[index].Quality < high_value_of_quality)
            {
                increaseQuality_by_one(index);

            }
        }

        public void AgedBrie(int index) { QualityNotAboveFifty(index); }

        public void Sulfuras(int index) { }

        public void Backstage(int index)
        {
              QualityNotAboveFifty(index);
            if (Items[index].Quality < high_value_of_quality&& Items[index].SellIn < 11) { increaseQuality_by_one(index); }
            if (Items[index].Quality < high_value_of_quality && Items[index].SellIn < 6) { increaseQuality_by_one(index); }
            if (Items[index].Quality > low_value_of_quality && Items[index].SellIn < 0)
            { Items[index].Quality = Items[index].Quality - Items[index].Quality; }
        }

        public void Conjured(int index) {
            if (Items[index].Quality>low_value_of_quality)
            {//because quality can't be nagative 
                if (Items[index].Quality > 1) 
                {Items[index].Quality = Items[index].Quality - 2;
                   
                }
                else
                {//if quality become 1 decrease by one 
                    decreasedQuality_one(index); 
                }
            }
                }
        

    }

   

}
