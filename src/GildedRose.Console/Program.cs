using System.Collections.Generic;

namespace GildedRose.Console
{
    public class Program
    {
        //IList<Item> Items;
        private List<Item> Items;

        public Program(List<Item> items)
        {
            this.Items = items;
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
                                              new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20, Kind = Types.Default},
                                              new Item {Name = "Aged Brie", SellIn = 2, Quality = 0, Kind = Types.AgedBrie},
                                              new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7, Kind = Types.Default},
                                              new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80, Kind = Types.Sulfuras},
                                              new Item
                                                  {
                                                      Name = "Backstage passes to a TAFKAL80ETC concert",
                                                      SellIn = 15,
                                                      Quality = 20,
                                                      Kind = Types.BackstagePasses
                                                  },
                                              new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6, Kind = Types.Conjured}
                                          }

                          };

            app.UpdateQuality();

            System.Console.ReadKey();

        }

        public void UpdateQuality()
        {
            for (var i = 0; i < Items.Count; i++)
            {
                UpdateItemByType(Items[i]);
            }
        }

        private void UpdateSellInDefault(Item item){

             item.SellIn -= 1;
            
        }

        private void UpdateQualityDecrease(Item item, int decrement){

            if (item.Quality - decrement >= 0){
                item.Quality -= decrement;
            }
        }

        private void UpdateExpiredItem(Item item)
        {
            UpdateQualityDecrease(item, 2);
            UpdateSellInDefault(item);

        }

        private void UpdateItemDefault(Item item){

            UpdateQualityDecrease(item, 1);
            UpdateSellInDefault(item);
        }


        private void UpdateQualityIncrease(Item item, int increment)
        {
            if (item.Quality + increment <= 50)
            {
                item.Quality += increment;
            }

        }

        private void UpdateQualityBackstagePasses(Item item)
        {
            if (item.SellIn > 10)
            {
                UpdateQualityIncrease(item, 1);
            }

            else if (item.SellIn <= 10 && item.SellIn > 5)
            {
                UpdateQualityIncrease(item, 2);
            }

            else if (item.SellIn <= 5 && item.SellIn > 0)
            {
                UpdateQualityIncrease(item, 3);
            }

            else
            {
                item.Quality = 0;
            }

            UpdateSellInDefault(item);

        }

        private void UpdateItemByType(Item item)
        {
            switch (item.Kind)
            {
                case Types.Default:
                    if (item.SellIn > 0)
                    {
                        UpdateItemDefault(item);
                    }
                    else
                    {
                        UpdateExpiredItem(item);
                    }
                    break;
                case Types.AgedBrie:
                    UpdateQualityIncrease(item, 1);
                    UpdateSellInDefault(item);
                    break;
                case Types.BackstagePasses:
                    UpdateQualityBackstagePasses(item);
                    break;
                case Types.Sulfuras:
                    break;
                case Types.Conjured:
                    UpdateQualityDecrease(item, 2);
                    UpdateSellInDefault(item);
                    break;

            }

           
        }

    }



    public class Item
    {
        public string Name { get; set; }

        public int SellIn { get; set; }

        public int Quality { get; set; }

        public Types Kind { get; set; }
    }

    public enum Types
    {
        AgedBrie,
        BackstagePasses,
        Sulfuras,
        Conjured,
        Default
    }

}
