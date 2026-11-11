using System;
using System.IO;

namespace Task3.services
{
    internal class TestingState
    {
        public static void RunTests()
        {
            var manager = new SongManager();

            string lyrics = File.Exists("lyrics.txt") ? File.ReadAllText("lyrics.txt") : "Sample lyrics text...";

            manager.AddSong(new Song("Yesterday", "Paul McCartney", "Lennon-McCartney", 1965, lyrics, new[] { "The Beatles" }));
            manager.AddSong(new Song("Bohemian Rhapsody", "Freddie Mercury", "Freddie Mercury", 1975, "Is this real life?", new[] { "Queen" }));

            manager.UpdateSong("Bohemian Rhapsody", manager.Search(s => s.title == "Bohemian Rhapsody")[0] with { year = 1975 });

            Console.WriteLine("Songs by Queen:");
            manager.GetSongsByPerformer("Queen").ForEach(Console.WriteLine);

            string file = "songs.txt";
            manager.SaveCollectionToFile(file);

            manager.RemoveSong("Yesterday");
            manager.LoadCollectionFromFile(file);

            Console.WriteLine($"\nReloaded successfully! Total songs: {manager.GetAllSongs().Count}");
        }
    }
}