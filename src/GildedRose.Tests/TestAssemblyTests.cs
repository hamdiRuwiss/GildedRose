using FluentAssertions;
using GildedRose.Console;
using System.Collections.Generic;
using Xunit;

namespace GildedRose.Tests
{
    public class TestAssemblyTests
    {
        [Fact]
        public void TestTheTruth()
        {
            Assert.True(true);
        }
        
        //At the end of each day our system lowers both values for every item
        [Fact]
        public void SystemLowersValues()
        {
            //arrange
            Item[] items = new Item[]
            {
                new Item{ Name="foo",SellIn=15,Quality=25 }
            };

            //act
            Console.Program app = new Program() { Items=items };
            app.UpdateQuality();
            //assert sellin
            
             Assert.Equal(14, app.Items[0].SellIn);
            //assert quality
            Assert.Equal(24, app.Items[0].Quality);
        }

        // Once the sell by date has passed, Quality degrades twice as fast
        [Fact]
        public void QualityDegradesTwiceAsFast()
        {
            Item[] items = new Item[]
                      {
                new Item{ Name="foo",SellIn=0,Quality=17 }
                      };
            Console.Program app = new Program() { Items = items };
            app.UpdateQuality();

            //assert quality
            Assert.Equal(-1, app.Items[0].SellIn);
            Assert.Equal(15, app.Items[0].Quality);
        }
        //The Quality of an item is never negative
        [Fact]
        public void QualityNeverNegative()
        {
            //arrange
            var sut = new Item[]
                      {
                      new Item { Name = "foo", SellIn = 10, Quality = 0 }
                      };
            //act
            Program app = new Program() { Items = sut };
            app.UpdateQuality();

            //assert
            Assert.Equal(0, app.Items[0].Quality);
        }

        //"Aged Brie" actually increases in Quality the older it gets
        [Fact]
        public void AgedBrieIncrease()
        {
            //arrange
            var items = new Item[]
                      {
                      new Item { Name = "Aged Brie", SellIn = 2, Quality = 1 }
                      };
            //act
            Program app = new Program() { Items = items };
            app.UpdateQuality();

            //assert
            Assert.Equal(1, app.Items[0].SellIn);
            Assert.Equal(2, app.Items[0].Quality);

        }

        //The Quality of an item is never more than 50

        [Fact]
        public void QualityNeverUpFifty()
        {
            //arrange
            var sut = new Item[]
                      {
                      new Item { Name = "foo", SellIn = 2, Quality = 50 }
                      };
            //act
            Program app = new Program() { Items = sut };
            app.UpdateQuality();

            //assert
            // Assert.Equal(1, app.Items[0].SellIn);
            Assert.Equal(49, app.Items[0].Quality);
        }
        ////- "Sulfuras", being a legendary item, never has to be sold or decreases in Quality

        [Fact]
        public void shouldNotIncreaseOrDecreaseQualityof_Sulfuras()
        {
            //arrange
            var sut = new Item[]
                      {
                      new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 }
                      };
            //act
            Program app = new Program() { Items = sut };
            app.UpdateQuality();

            //assert
            Assert.Equal(0, app.Items[0].SellIn);
            Assert.Equal(80, app.Items[0].Quality);
        }
        //- "Backstage passes", like aged brie, increases in Quality as it's SellIn value approaches; Quality increases by 2 when there are 10 days or less 
        //  and by 3 when there are 5 days or less but Quality drops to 0 after the concert
        [Fact]
        public void shouldIncreaseInQualityBy1_IfMoreThan10Days_BackstagePasses()
        {
            //arrange
            var sut = new Item[]
                      {
                      new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality =20 }
                      };
            //act
            Program app = new Program() { Items = sut };
            app.UpdateQuality();

            //assert
            Assert.Equal(14, app.Items[0].SellIn);
            Assert.Equal(21, app.Items[0].Quality);
        }
        [Fact]
        public void shouldIncreaseInQualityBy2_IfLessThanOrEqualTo10Days_BackstagePasses()
        {
            //arrange
            var sut = new Item[]
                      {
                      new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality =20 }
                      };
            //act
            Program app = new Program() { Items = sut };
            app.UpdateQuality();

            //assert
            Assert.Equal(9, app.Items[0].SellIn);
            Assert.Equal(22, app.Items[0].Quality);
        }
        [Fact]
        public void shouldIncreaseInQualityBy3_IfLessThanOrEqualTo5Days_BackstagePasses()
        {
            //arrange
            var sut = new Item[]
                      {
                      new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality =20 }
                      };
            //act
            Program app = new Program() { Items = sut };
            app.UpdateQuality();

            //assert

            Assert.Equal(23, app.Items[0].Quality);
        }
        //Quality of Backstage drops to 0 after the concert 
        [Fact]
        public void shouldQaulityDropAfterSellenBeZero_BackstagePasses()
        {
            //arrange
            var sut = new Item[]
                      {
                      new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality =20 }
                      };
            //act
            Program app = new Program() { Items = sut };
            app.UpdateQuality();

            //assert

            Assert.Equal(0, app.Items[0].Quality);
        }


        // "Conjured" items degrade in Quality twice as fast as normal items
        [Fact]
        public void ConjuredshouldDecreaseedQualitytwice()
        {
            //arrange
            var sut = new Item[]
                      {
                      new Item { Name = "Conjured Mana Cake", SellIn = 6, Quality =20 }
                      };
            //act
            Program app = new Program() { Items = sut };
            app.UpdateQuality();

            //assert

            Assert.Equal(18, app.Items[0].Quality);
        }

        [Fact]
        public void ConjuredshouldDecreaseedQualitytwice1()
        {
            //arrange
            var sut = new Item[]
                      {
                      new Item { Name = "Conjured Mana Cake", SellIn = 5, Quality =1 }
                      };
            //act
            Program app = new Program() { Items = sut };
            app.UpdateQuality();

            //assert

            Assert.Equal(0, app.Items[0].Quality);
        }

    }
}
