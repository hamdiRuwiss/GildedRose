using Xunit;
using System.Collections.Generic;
using GildedRose.Console;
using System;

namespace GildedRose.Tests
{
    public class TestAssemblyTests
    {
        [Fact]
        public void TestTheTruth()
        {
            Assert.True(true);
        }
        [Fact]
        public void TestDefaultFunctionality()
        {
            List<Item> Items = new List<Item>() { new Item { Name = "random item", SellIn = 2, Quality = 5 , Kind = Types.Default } };
            var app = new Program(Items);
            app.UpdateQuality();

            int expectedSellin = 1;
            int expectedQuality = 4;

            Assert.Equal(expectedSellin, Items[0].SellIn);
            Assert.Equal(expectedQuality, Items[0].Quality);
        }

        [Fact]
        public void TestTwiceAsFastAfterSellByDate()
        {
            List<Item> Items = new List<Item>() { new Item { Name = "random item", SellIn = 0, Quality = 5 , Kind = Types.Default } };
            var app = new Program(Items);
            app.UpdateQuality();

            int expectedQuality = 3;

            Assert.Equal(expectedQuality, Items[0].Quality);
        }

        [Fact]
        public void TestQualityIsNeverNegative()
        {
            List<Item> Items = new List<Item>() { new Item { Name = "random item", SellIn = 0, Quality = 0 , Kind = Types.Default} };
            var app = new Program(Items);
            app.UpdateQuality();

            Assert.True(Items[0].Quality >= 0);
        }

        [Fact]
        public void TestAgedBrieQualityIncrease()
        {
            List<Item> Items = new List<Item>() { new Item { Name = "Aged Brie", SellIn = 7, Quality = 9 , Kind = Types.AgedBrie } };
            var app = new Program(Items);
            app.UpdateQuality();

            int expectedQuality = 10;

            Assert.Equal(expectedQuality, Items[0].Quality);
        }

        [Fact]
        public void TestQualityIsNeverMoreThanFifty()
        {
            List<Item> Items = new List<Item>() { new Item { Name = "Aged Brie", SellIn = 7, Quality = 50 , Kind = Types.AgedBrie} };
            var app = new Program(Items);
            app.UpdateQuality();

            Assert.True(Items[0].Quality <= 50);
        }
        
        [Fact]
        public void TestQualitySulfurasNeverDecreases()
        {
            List<Item> Items = new List<Item>() { new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 60, Kind = Types.Sulfuras } };
            var app = new Program(Items);
            app.UpdateQuality();

            int expectedSellin = 0;
            int expectedQuality = 60;

            Assert.Equal(expectedSellin, Items[0].SellIn);
            Assert.Equal(expectedQuality, Items[0].Quality);
        }

        [Fact]
        public void TestBackstageQualityTenDays()
        {
            List<Item> Items = new List<Item>() { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 5, Kind = Types.BackstagePasses } };
            var app = new Program(Items);
            app.UpdateQuality();

            int expectedQuality = 7;

            Assert.Equal(expectedQuality, Items[0].Quality);
        }

        [Fact]
        public void TestBackstageQualityLessTenDays()
        {
            List<Item> Items = new List<Item>() { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 9, Quality = 5, Kind = Types.BackstagePasses } };
            var app = new Program(Items);
            app.UpdateQuality();

            int expectedQuality = 7;

            Assert.Equal(expectedQuality, Items[0].Quality);
        }

        [Fact]
        public void TestBackstageQualityFiveDays()
        {
            List<Item> Items = new List<Item>() { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 5, Kind = Types.BackstagePasses } };
            var app = new Program(Items);
            app.UpdateQuality();

            int expectedQuality = 8;

            Assert.Equal(expectedQuality, Items[0].Quality);
        }

        [Fact]
        public void TestBackstageQualityLessFiveDays()
        {
            List<Item> Items = new List<Item>() { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 4, Quality = 5, Kind = Types.BackstagePasses } };
            var app = new Program(Items);
            app.UpdateQuality();

            int expectedQuality = 8;

            Assert.Equal(expectedQuality, Items[0].Quality);
        }

        [Fact]
        public void TestBackstageQualityConcertOver()
        {
            List<Item> Items = new List<Item>() { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = 5, Kind = Types.BackstagePasses} };
            var app = new Program(Items);
            app.UpdateQuality();

            int expectedQuality = 0;

            Assert.Equal(expectedQuality, Items[0].Quality);
        }
        [Fact]
        public void TestConjuredQualityDecreasesTwiceAsFast()
        {
            List<Item> Items = new List<Item>() { new Item { Name = "Conjured Mana Cake", SellIn = 4, Quality = 5, Kind = Types.Conjured } };
            var app = new Program(Items);
            app.UpdateQuality();

            int expectedQuality = 3;

            Assert.Equal(expectedQuality, Items[0].Quality);
        }

    }
}