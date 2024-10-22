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
}
