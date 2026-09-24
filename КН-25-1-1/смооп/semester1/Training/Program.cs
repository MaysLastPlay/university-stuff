using Training.library.item;
using Training.library;
using Training.enums;

Library library = new Library("My Library", 3);
Item item1 = new Item(1, "The Great Gatsby", "A novel by F. Scott Fitzgerald", "F. Scott Fitzgerald", LibraryItems.Books, 10.99m);
Item item2 = new Item(2, "Watchmen", "A graphic novel by Alan Moore", "Alan Moore", LibraryItems.Comics, 14.99m);
library.AddItem(item1);
library.AddItem(item2);
library.GetId(item1.Id);
library.GetId(item2.Id);
library.DisplayItems();
library.RemoveItem(item1);
