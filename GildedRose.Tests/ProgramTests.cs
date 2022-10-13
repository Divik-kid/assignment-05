namespace GildedRose.Tests;
using GildedRose;
public class ProgramTests
{

    [Fact]
    public void Test_Item_Quality_SellPrice_Name()
    {
        //Arrange
        var i1 = Factory.createItem(); i1.Name = "+5 Dexterity Vest"; i1.SellIn = 10; i1.Quality = 20;
        //Act
        //Assert
        i1.Quality.Should().Be(20);
    }

    [Fact]
    public void Test_UpdateQuality()
    {
        //Arrange
        var app = new Program();
        var items = Factory.createList();
        var item0 = Factory.createItem(); item0.Name = "+5 Dexterity Vest"; item0.SellIn = 10; item0.Quality = 20;
        items.Add(item0);

        var item1 = Factory.createItem(); item1.Name = "Aged Brie"; item1.SellIn = 2; item1.Quality = 0;
        items.Add(item1);

        var item2 = Factory.createItem(); item2.Name = "Elixir of the Mongoose"; item2.SellIn = 5; item2.Quality = 7;
        items.Add(item2);

        var item3 = Factory.createItem(); item3.Name = "Sulfuras, Hand of Ragnaros"; item3.SellIn = 0; item3.Quality = 80;
        items.Add(item3);
        //Act
        app.UpdateQuality(items);

        //Assert
        items.Should().BeEquivalentTo(new List<Item>(){new Item { Name = "+5 Dexterity Vest", SellIn = 9, Quality = 19 },
        new Item { Name = "Aged Brie", SellIn = 1, Quality = 1 },
        new Item { Name = "Elixir of the Mongoose", SellIn = 4, Quality = 6 },
        new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 }
        });
    }

    [Fact]
    public void Test_Negative_SellIn()
    {
        //Arrange
        var app = new Program();
        var items = Factory.createList();
        var item0 = Factory.createItem(); item0.Name = "+5 Dexterity Vest"; item0.SellIn = -1; item0.Quality = 20;
        items.Add(item0);

        //Act
        app.UpdateQuality(items);

        //Assert
        items.Should().BeEquivalentTo(new List<IItem>(){new Item { Name = "+5 Dexterity Vest", SellIn = -2, Quality = 18 }
        });
    }

    [Fact]
    public void Test_Backstage_concert_sell_below_11()
    {
        //Arrange
        var app = new Program();
        var items = Factory.createList();
        //Act
        var item0 = Factory.createItem(); item0.Name = "Backstage passes to a TAFKAL80ETC concert"; item0.SellIn = 10; item0.Quality = 20;
        items.Add(item0);
        app.UpdateQuality(items);

        //Assert
        items.Should().BeEquivalentTo(new List<Item>() { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 9, Quality = 22 } });
    }

    [Fact]
    public void Test_Backstage_concert_sell_below_6()
    {
        //Arrange
        var app = new Program();
        var items = Factory.createList();
        var item = Factory.createItem(); item.Name = "Backstage passes to a TAFKAL80ETC concert"; item.SellIn = 4; item.Quality = 20;
        items.Add(item);

        //Act
        app.UpdateQuality(items);

        //Assert
        items.Should().BeEquivalentTo(new List<Item>() { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 3, Quality = 23 } });
    }

    [Fact]
    public void Test_Brie_SellIn_Below_0()
    {
        //Arrange 
        var app = new Program();
        var items = Factory.createList();
        var item = Factory.createItem(); item.Name = "Aged Brie"; item.SellIn = -2; item.Quality = 0;
        items.Add(item);

        //Act
        app.UpdateQuality(items);

        //Assert
        items.Should().BeEquivalentTo(new List<Item>() { new Item { Name = "Aged Brie", SellIn = -3, Quality = 2 } });
    }

    [Fact]
    public void Test_Backstage_concert_sell_below_0()
    {
        //Arrange
        var app = new Program();
        var items = Factory.createList();
        var item = Factory.createItem(); item.Name = "Backstage passes to a TAFKAL80ETC concert"; item.SellIn = -2; item.Quality = 20;
        items.Add(item);

        //Act
        app.UpdateQuality(items);

        //Assert
        items.Should().BeEquivalentTo(new List<Item>() { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = -3, Quality = 0 } });
    }

    [Fact]
    public void Test_sulfuras_sell_below_0()
    {
        //Arrange
        var app = new Program();
        var items = Factory.createList();
        var item = Factory.createItem(); item.Name = "Sulfuras, Hand of Ragnaros"; item.SellIn = -1; item.Quality = 80;
        items.Add(item);

        //Act
        app.UpdateQuality(items);

        //Assert
        items.Should().BeEquivalentTo(new List<Item>() { new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = -1, Quality = 80 } });
    }

        [Fact]
    public void Test_Conjured_sell_below_0()
    {
        //Arrange
        var app = new Program();
        var items = Factory.createList();
        var item = Factory.createItem(); item.Name = "Conjured Mana Cake"; item.SellIn = -1; item.Quality = 30;
        items.Add(item);
        //Act
        app.UpdateQuality(items);
        //Assert
        items.Should().BeEquivalentTo(new List<Item>(){ new Item { Name = "Conjured Mana Cake", SellIn = -2, Quality = 26 }});
    }

    [Fact]
    public void Test_Conjured_sell_above_0()
    {
        //Arrange
        var app = new Program();
        var items = Factory.createList();
        var item = Factory.createItem(); item.Name = "Conjured Mana Cake"; item.SellIn = 5; item.Quality = 30;
        items.Add(item);
        //Act
        app.UpdateQuality(items);
        //Assert
        items.Should().BeEquivalentTo(new List<Item>(){ new Item { Name = "Conjured Mana Cake", SellIn = 4, Quality = 28 }});
    }



}