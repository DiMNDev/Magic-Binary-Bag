using FluentAssertions;
using Logic;

namespace Tests;
public class UnitTest1
{
    [Fact]
    public void ShouldInsertItemAsRootNode()
    {
        // Arrange
        Inventory inventory = new Inventory();
        Item item = new Item(00, "Sword of Light", EType.Weapon, ERarity.Rare, 100);
        // Act
        inventory.Insert(item);
        // Assert
        inventory.Root?.Data.Should().Be(item);
    }

    [Fact]
    public void RootNodeShouldHaveCorrectID()
    {
        // Arrange
        Inventory inventory = new Inventory();
        Item item = new Item(00, "Sword of Light", EType.Weapon, ERarity.Rare, 100);
        // Act
        inventory.Insert(item);
        // Assert
        inventory.Root?.Data.ID.Should().Be(item.ID);
    }

    [Fact]
    public void RootNodeShouldInsertRootOnLeft()
    {
        // Arrange
        Inventory inventory = new Inventory();
        Item item2 = new Item(00, "Sword of Darkness", EType.Weapon, ERarity.Rare, 100);
        Item item1 = new Item(01, "Sword of Light", EType.Weapon, ERarity.Rare, 100);
        // Act
        inventory.Insert(item1);
        inventory.Insert(item2);
        // Assert
        inventory.Root.Left.Should().NotBeNull();
    }

    [Fact]
    public void RootNodeShouldInsertRootOnRight()
    {
        // Arrange
        Inventory inventory = new Inventory();
        Item item1 = new Item(00, "Sword of Light", EType.Weapon, ERarity.Rare, 100);
        Item item2 = new Item(01, "Sword of Darkness", EType.Weapon, ERarity.Rare, 100);
        // Act
        inventory.Insert(item1);
        inventory.Insert(item2);
        // Assert
        inventory.Root.Right.Should().NotBeNull();
    }

    [Fact]
    public void ShouldDeleteItemFromInventory()
    {
        // Arrange
        Inventory inventory = new Inventory();
        Item item1 = new Item(00, "Sword of Light", EType.Weapon, ERarity.Rare, 100);
        Item item3 = new Item(01, "Shield of Hope", EType.Weapon, ERarity.Legendary, 1000);
        Item item2 = new Item(02, "Sword of Darkness", EType.Weapon, ERarity.Rare, 100);
        // Act
        inventory.Insert(item1);
        inventory.Insert(item2);
        inventory.Insert(item3);
        inventory.Delete(item3.ID);
        // Assert
        inventory.Root.Right.Left.Should().NotBe(item3);

    }

    [Fact]
    public void ShouldAddMultipleInstancesInProperStructure()
    {
        // Arrange
        Inventory inventory = new Inventory();
        Item Item01 = new Item(50, "Sword of Truth", EType.Weapon, ERarity.Legendary, 100);
        Item Item02 = new Item(25, "Potion of Healing", EType.Potion, ERarity.Common, 10);
        Item Item03 = new Item(75, "Shield of Valor", EType.Armor, ERarity.Rare, 50);
        Item Item04 = new Item(10, "Ring of Power", EType.Accessory, ERarity.Legendary, 200);
        Item Item05 = new Item(30, "Dagger of Shadows", EType.Weapon, ERarity.Rare, 80);
        Item Item06 = new Item(60, "Cloak of Invisibility", EType.Armor, ERarity.Legendary, 120);
        Item Item07 = new Item(80, "Staff of Wisdom", EType.Weapon, ERarity.Common, 30);
        Item Item08 = new Item(5, "Boots of Swiftness", EType.Accessory, ERarity.Rare, 40);
        // Act
        inventory.Insert(Item01);
        inventory.Insert(Item02);
        inventory.Insert(Item03);
        inventory.Insert(Item04);
        inventory.Insert(Item05);
        inventory.Insert(Item06);
        inventory.Insert(Item07);
        inventory.Insert(Item08);
        // Assert
        inventory.Root.Data.ID.Should().Be(Item01.ID);
        inventory.Root.Left.Data.ID.Should().Be(Item02.ID);
        inventory.Root.Right.Data.ID.Should().Be(Item03.ID);
        inventory.Root.Left.Left.Data.ID.Should().Be(Item04.ID);
        inventory.Root.Left.Right.Data.ID.Should().Be(Item05.ID);
        inventory.Root.Right.Left.Data.ID.Should().Be(Item06.ID);
        inventory.Root.Right.Right.Data.ID.Should().Be(Item07.ID);
        inventory.Root.Left.Left.Left.Data.ID.Should().Be(Item08.ID);
    }

    [Fact]
    public void ShouldDeleteItem05Properly()
    {
        // Arrange
        Inventory inventory = new Inventory();
        Item Item01 = new Item(50, "Sword of Truth", EType.Weapon, ERarity.Legendary, 100);
        Item Item02 = new Item(25, "Potion of Healing", EType.Potion, ERarity.Common, 10);
        Item Item03 = new Item(75, "Shield of Valor", EType.Armor, ERarity.Rare, 50);
        Item Item04 = new Item(10, "Ring of Power", EType.Accessory, ERarity.Legendary, 200);
        Item Item05 = new Item(30, "Dagger of Shadows", EType.Weapon, ERarity.Rare, 80);
        Item Item06 = new Item(60, "Cloak of Invisibility", EType.Armor, ERarity.Legendary, 120);
        Item Item07 = new Item(80, "Staff of Wisdom", EType.Weapon, ERarity.Common, 30);
        Item Item08 = new Item(5, "Boots of Swiftness", EType.Accessory, ERarity.Rare, 40);
        // Act
        inventory.Insert(Item01);
        inventory.Insert(Item02);
        inventory.Insert(Item03);
        inventory.Insert(Item04);
        inventory.Insert(Item05);
        inventory.Insert(Item06);
        inventory.Insert(Item07);
        inventory.Insert(Item08);
        inventory.Delete(Item05.ID);
        // Assert
        inventory.Root.Data.ID.Should().Be(Item01.ID);
        inventory.Root.Left.Data.ID.Should().Be(Item02.ID);
        inventory.Root.Right.Data.ID.Should().Be(Item03.ID);
        inventory.Root.Left.Left.Data.ID.Should().Be(Item04.ID);
        inventory.Root.Left.Right.Should().Be(null);
        inventory.Root.Right.Left.Data.ID.Should().Be(Item06.ID);
        inventory.Root.Right.Right.Data.ID.Should().Be(Item07.ID);
        inventory.Root.Left.Left.Left.Data.ID.Should().Be(Item08.ID);
    }

    [Fact]
    public void ShouldNotBeBalanced()
    {
        // Arrange
        Inventory inventory = new Inventory();
        Item Item01 = new Item(50, "Sword of Truth", EType.Weapon, ERarity.Legendary, 100);
        Item Item02 = new Item(25, "Potion of Healing", EType.Potion, ERarity.Common, 10);
        Item Item03 = new Item(75, "Shield of Valor", EType.Armor, ERarity.Rare, 50);
        Item Item04 = new Item(10, "Ring of Power", EType.Accessory, ERarity.Legendary, 200);
        Item Item05 = new Item(30, "Dagger of Shadows", EType.Weapon, ERarity.Rare, 80);
        Item Item06 = new Item(60, "Cloak of Invisibility", EType.Armor, ERarity.Legendary, 120);
        Item Item07 = new Item(80, "Staff of Wisdom", EType.Weapon, ERarity.Common, 30);
        Item Item08 = new Item(5, "Boots of Swiftness", EType.Accessory, ERarity.Rare, 40);
        // Act
        inventory.Insert(Item04);
        inventory.Insert(Item08);
        inventory.Insert(Item01);
        inventory.Insert(Item02);
        inventory.Insert(Item03);
        inventory.Insert(Item07);
        inventory.Insert(Item05);
        inventory.Insert(Item06);
        // Assert
        inventory.CheckBalance().Should().Be(false);
        inventory.GetHeight(inventory.Root).Should().Be(3);
        inventory.GetHeight(inventory.Root.Left).Should().Be(0);
    }

    [Fact]
    public void ShouldBeBalanced()
    {
        // Arrange
        Inventory inventory = new Inventory();
        Item Item01 = new Item(50, "Sword of Truth", EType.Weapon, ERarity.Legendary, 100);
        Item Item02 = new Item(25, "Potion of Healing", EType.Potion, ERarity.Common, 10);
        Item Item03 = new Item(75, "Shield of Valor", EType.Armor, ERarity.Rare, 50);
        Item Item04 = new Item(10, "Ring of Power", EType.Accessory, ERarity.Legendary, 200);
        Item Item05 = new Item(30, "Dagger of Shadows", EType.Weapon, ERarity.Rare, 80);
        Item Item06 = new Item(60, "Cloak of Invisibility", EType.Armor, ERarity.Legendary, 120);
        Item Item07 = new Item(80, "Staff of Wisdom", EType.Weapon, ERarity.Common, 30);
        Item Item08 = new Item(5, "Boots of Swiftness", EType.Accessory, ERarity.Rare, 40);
        // Act
        inventory.Insert(Item01);
        inventory.Insert(Item02);
        inventory.Insert(Item03);
        inventory.Insert(Item04);
        inventory.Insert(Item05);
        inventory.Insert(Item06);
        inventory.Insert(Item07);
        // Assert
        inventory.CheckBalance().Should().Be(true);
    }

    [Fact]
    public void ShouldTraverseIDAscending()
    {
        // Arrange
        Inventory inventory = new Inventory();
        Item Item01 = new Item(50, "Sword of Truth", EType.Weapon, ERarity.Legendary, 100);
        Item Item02 = new Item(25, "Potion of Healing", EType.Potion, ERarity.Common, 10);
        Item Item03 = new Item(75, "Shield of Valor", EType.Armor, ERarity.Rare, 50);
        Item Item04 = new Item(10, "Ring of Power", EType.Accessory, ERarity.Legendary, 200);
        Item Item05 = new Item(30, "Dagger of Shadows", EType.Weapon, ERarity.Rare, 80);
        Item Item06 = new Item(60, "Cloak of Invisibility", EType.Armor, ERarity.Legendary, 120);
        Item Item07 = new Item(80, "Staff of Wisdom", EType.Weapon, ERarity.Common, 30);
        Item Item08 = new Item(5, "Boots of Swiftness", EType.Accessory, ERarity.Rare, 40);
        // Act
        inventory.Insert(Item01);
        inventory.Insert(Item02);
        inventory.Insert(Item03);
        inventory.Insert(Item04);
        inventory.Insert(Item05);
        inventory.Insert(Item06);
        inventory.Insert(Item07);
        inventory.Insert(Item08);
        // Assert
        foreach (var Item in inventory.InOrderTraversal(inventory.Root, new()))
        {
            Item.Data.ID.Should().BeLessThan(Item.Data.ID);
        }
    }
}
