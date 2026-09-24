using System;
using System.Collections.Generic;
using System.Text;
using Training.enums;

namespace Training.library.item
{
    internal class Item
    {
        public int Id { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public string Author { get; private set; }
        public LibraryItems Type { get; private set; }
        public decimal Price { get; private set; }

        public Item(int id, string title, string description, string author, LibraryItems type, decimal price)
        {
            Id = id;
            Title = title;
            Description = description;
            Author = author;
            Type = type;
            Price = price;
        }

        public override string ToString() => $"Id: {Id}, Title: {Title}, Description: {Description}, Author: {Author}, Type: {Type}, Price: ${Price}";
    }
}
