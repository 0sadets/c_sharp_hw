using System;
using System.Collections;
using System.Collections.Generic;

namespace HW8_Standart_Interface
{
    enum Genre
    {
        Comedy, Horror, Adventure, Drama
    }
    class Director: ICloneable
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public override string ToString()
        {
            return $"Director: {FirstName} {LastName}, {Age} y.o.";
        }
        public object Clone()
        {
            Director copy = this.MemberwiseClone() as Director;
            return copy;
        }
    }
    class Movie : ICloneable, IComparable<Movie>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public Director director;
        public string Country { get; set; }
        public Genre genre;
        public int Year { get; set; }
        public short Rating { get; set; }

        public override string ToString()
        {
            return $"Title: {Title} {Year}, Director: {director}\nGenre: {genre}\nDescription: {Description}\nCountry: {Country}\nRating: {Rating}";
        }
        public object Clone()
        {
            Movie copy = this.MemberwiseClone() as Movie;
            return copy;
        }
        public int CompareTo(Movie? movie)
        {
            return this.Year.CompareTo(movie.Year);
        }
    }


    class Cinema : IEnumerable 
    {
        Movie[] movies;
        public string Adress;
        public Cinema()
        {
            movies = new Movie[]
            {
                new Movie
            {
                Title = "Title1",
                Description = "Description1",
                director = new Director { FirstName = "Firstname1", LastName = "Lastname1", Age = 50},
                Country = "Country1",
                genre = Genre.Comedy,
                Year = 2024,
                Rating = 5

            },
            new Movie
            {
                Title = "Title2",
                Description = "Description2",
                director = new Director { FirstName = "Firstname2", LastName = "Lastname2", Age = 40 },
                Country = "Country2",
                genre = Genre.Comedy,
                Year = 2018,
                Rating = 3

            }
            };
            
        }
        public IEnumerator GetEnumerator()
        {
            return movies.GetEnumerator();
        }
        public void Print()
        {
            foreach (Movie movie in movies)
            {
                Console.WriteLine(movie);
            }
        }
        public void Sort()
        {
            Array.Sort(movies);
        }
        public void Sort(IComparer<Movie> comparer)
        {
            Array.Sort(movies, comparer);
        }

    }

    class RatingComparer : IComparer<Movie>
    {
        public int Compare(Movie x, Movie y)
        {
            return x.Rating.CompareTo(y.Rating);
        }
    }
    class YearComparer : IComparer<Movie>
    {
        public int Compare(Movie x, Movie y)
        {
            return x.Year.CompareTo(y.Year);
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Cinema cinema = new Cinema();
            //cinema.Print();

            Console.WriteLine("Name Sort");
            cinema.Sort();
            foreach(var m in cinema)
            {
                Console.WriteLine(m);
            }

            Console.WriteLine("Year Sort");
            cinema.Sort(new YearComparer());
            foreach (var m in cinema)
            {
                Console.WriteLine(m);
            }

            Console.WriteLine("Rating Sort");
            cinema.Sort(new RatingComparer());
            foreach (var m in cinema)
            {
                Console.WriteLine(m);
            }
        }
    }
}