using System;
using System.Collections.Generic;
using System.Text;

namespace Task3.services
{
    public record Song(
        string title,
        string author,
        string composer,
        int year,
        string lyrics,
        string[] performers)
    {
        public override string ToString()
        {
            string performersList = string.Join(", ", performers);
            return $"\"{title}\" ({year})\n" +
                   $"  Author:     {author}\n" +
                   $"  Composer:   {composer}\n" +
                   $"  Performers: {performersList}\n" +
                   $"  Lyrics:     {lyrics}";
        }
    }
}