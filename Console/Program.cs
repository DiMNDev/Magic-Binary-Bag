// See https://aka.ms/new-console-template for more information
using Logic;
Console.Clear();
Inventory inventory = new Inventory();
/*--------------------------------------------------------------------------------------
ID: 50, Name: "Sword of Truth", Type: "Weapon", Rarity: "Legendary", Strength: 100
ID: 25, Name: "Potion of Healing", Type: "Potion", Rarity: "Common", Strength: 10
ID: 75, Name: "Shield of Valor", Type: "Armor", Rarity: "Rare", Strength: 50
ID: 10, Name: "Ring of Power", Type: "Accessory", Rarity: "Legendary", Strength: 200
ID: 30, Name: "Dagger of Shadows", Type: "Weapon", Rarity: "Rare", Strength: 80
ID: 60, Name: "Cloak of Invisibility", Type: "Armor", Rarity: "Legendary", Strength: 120
ID: 80, Name: "Staff of Wisdom", Type: "Weapon", Rarity: "Common", Strength: 30
ID: 5, Name: "Boots of Swiftness", Type: "Accessory", Rarity: "Rare", Strength: 40
--------------------------------------------------------------------------------------*/

Item Item01 = new Item(50, "Sword of Truth", EType.Weapon, ERarity.Legendary, 100);
Item Item02 = new Item(25, "Potion of Healing", EType.Potion, ERarity.Common, 10);
Item Item03 = new Item(75, "Shield of Valor", EType.Armor, ERarity.Rare, 50);
Item Item04 = new Item(10, "Ring of Power", EType.Accessory, ERarity.Legendary, 200);
Item Item05 = new Item(30, "Dagger of Shadows", EType.Weapon, ERarity.Rare, 80);
Item Item06 = new Item(60, "Cloak of Invisibility", EType.Armor, ERarity.Legendary, 120);
Item Item07 = new Item(80, "Staff of Wisdom", EType.Weapon, ERarity.Common, 30);
Item Item08 = new Item(5, "Boots of Swiftness", EType.Accessory, ERarity.Rare, 40);

inventory.Insert(Item01);
inventory.Insert(Item02);
inventory.Insert(Item03);
inventory.Insert(Item04);
inventory.Insert(Item05);
inventory.Insert(Item06);
inventory.Insert(Item07);
inventory.Insert(Item08);

inventory.InOrderTraversal(inventory.Root, new());

int leftHeight = inventory.GetHeight(inventory.Root.Left!);
int rightHeight = inventory.GetHeight(inventory.Root.Right!);
Console.WriteLine($"Left-Height: {leftHeight}");
Console.WriteLine($"Right-Height: {rightHeight}");

inventory.PreOrderTraversal(inventory.Root!);

bool isBalanced = inventory.CheckBalance();
Console.WriteLine(isBalanced);
inventory.Delete(Item01.ID);
inventory.Delete(Item07.ID);
isBalanced = inventory.CheckBalance();
Console.WriteLine(isBalanced);

inventory.PreOrderTraversal(inventory.Root!);

