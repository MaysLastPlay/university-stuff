using System.Collections;
using System.Collections.Generic;
using Task1.workspace;
using Task1.workspace.items;


Movies coolMovies = new Movies();
coolMovies.addMovie(new Movie("Inception", "Christopher Nolan", 2010, MoviesGenre.Action));
coolMovies.addMovie(new Movie("The Dark Knight", "Christopher Nolan", 2008, MoviesGenre.Action));
coolMovies.Print();

coolMovies.removeMovie(new Movie("Inception", "Christopher Nolan", 2010, MoviesGenre.Action));
coolMovies.Print();

//coolMovies.removeMovieAt(0);
//coolMovies.Print();

public record class Movie(string Title, string Director, int Year, MoviesGenre Genre);