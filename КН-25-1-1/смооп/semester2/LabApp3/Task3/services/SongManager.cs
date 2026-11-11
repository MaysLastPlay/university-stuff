using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Task3.services
{
    internal class SongManager
    {
        private List<Song> _songs = new List<Song>();

        public static string GetFile(string filePath)
        {
            while (!File.Exists(filePath))
            {
                Console.Write($"Enter the path to the file ({filePath} not found): ");
                filePath = Console.ReadLine()?.Trim().Trim('"') ?? string.Empty;
            }
            return filePath;
        }

        public void AddSong(Song song) => _songs.Add(song);

        public bool RemoveSong(string title)
        {
            Song? song = _songs.FirstOrDefault(s => s.title.Equals(title, StringComparison.OrdinalIgnoreCase));
            if (song is null) return false;
            return _songs.Remove(song);
        }

        public bool UpdateSong(string oldTitle, Song updatedSong)
        {
            int index = _songs.FindIndex(s => s.title.Equals(oldTitle, StringComparison.OrdinalIgnoreCase));
            if (index == -1) return false;

            _songs[index] = updatedSong;
            return true;
        }

        public List<Song> Search(Func<Song, bool> predicate) => _songs.Where(predicate).ToList();

        public List<Song> GetSongsByPerformer(string performer)
        {
            return _songs.Where(s => s.performers.Any(p =>
                p.Contains(performer, StringComparison.OrdinalIgnoreCase))).ToList();
        }

        public static string LoadLyricsFromFile(string filePath)
        {
            string validPath = GetFile(filePath);
            return File.ReadAllText(validPath);
        }

        public void SaveCollectionToFile(string filePath)
        {
            List<string> lines = new List<string>();

            foreach (Song s in _songs)
            {
                string safeLyrics = s.lyrics.Replace("\r", "").Replace("\n", "\\n");
                string performersStr = string.Join(",", s.performers);
                string line = $"{s.title}|{s.author}|{s.composer}|{s.year}|{safeLyrics}|{performersStr}";
                lines.Add(line);
            }

            File.WriteAllLines(filePath, lines);
        }
        public void LoadCollectionFromFile(string filePath)
        {
            string validPath = GetFile(filePath);
            string[] lines = File.ReadAllLines(validPath);
            _songs.Clear();

            foreach (string line in lines)
            {
                if (string.IsNullOrWhiteSpace(line)) continue;

                string[] parts = line.Split('|');
                if (parts.Length == 6)
                {
                    string title = parts[0];
                    string author = parts[1];
                    string composer = parts[2];
                    int year = int.Parse(parts[3]);
                    string lyrics = parts[4].Replace("\\n", Environment.NewLine);
                    string[] performers = parts[5].Split(',', StringSplitOptions.RemoveEmptyEntries);

                    _songs.Add(new Song(title, author, composer, year, lyrics, performers));
                }
            }
        }

        public List<Song> GetAllSongs() => _songs;
    }
}