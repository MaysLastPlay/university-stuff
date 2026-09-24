using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using Task1.workspace.items;

namespace Task1.workspace
{
    internal class Movies
    {
        private protected List<Movie> movies { get; set; } = new List<Movie>();
        public Movies()
        {
        }

        public Movies(List<Movie> list)
        {
           movies = list;
        }
        public void addMovie(Movie movie)
        {
            if (movies == null)
            {
                Console.WriteLine("No movie found with this name");
                return;
            }

            if (movies.Contains(movie))
            {
                Console.WriteLine("Movie already exists in the list");
                return;
            }

            movies.Add(movie);
        }

        public void removeMovie(Movie movie)
        {
            if (movie == null || !movies.Contains(movie))
                throw new ArgumentException("You don't have this movie there, wanna add it first?");

            movies.Remove(movie);
        }

        public void removeMovieAt(int index)
        {
            if (index < 0 || index >= movies.Count)
                throw new ArgumentOutOfRangeException("Index is out of range.");

            movies.RemoveAt(index);
        }

        public void Print()
        {
            if (movies == null || movies.Count == 0)
                throw new ArgumentException("Seems like you don't have anything here. Wanna try using addMovie() function?");

            foreach (var thingy in movies)
            {
                Console.WriteLine($"Title: {thingy.Title}, Director: {thingy.Director}, Year: {thingy.Year}, Genre: {thingy.Genre}");
            }
        }
    }
}
