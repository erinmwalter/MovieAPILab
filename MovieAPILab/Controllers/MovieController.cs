using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieAPILab.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        MovieDAL mDB = new MovieDAL();

        //GET all movies
        //localhost/api/movie
        [HttpGet]
        public List<Movie> GetMovies() 
        {
            return mDB.GetMovies();
        }

        //Get one movie by id
        //localhost/api/movie/id
        [HttpGet("{id}")]
        public Movie GetMovie(int id) 
        {
            return mDB.GetMovie(id);
        }

        //search by genre
        //localhost/api/movie/genre=value
        [HttpGet("genre={value}")]
        public List<Movie> GetByGenre(string value) 
        {
            List<Movie> m = mDB.GetByGenre(value);
            if (m.Count == 0) 
            {
                m.Add(new Movie($"No Movies Found with Genre = {value}"));
            }
            return m;
        }

        //get random movie
        //localhost/api/movie/random/{numMovies}
        [HttpGet("random/{numMovies}")]
        public List<Movie> GetRandom(int numMovies) 
        {
            List<Movie> m = mDB.GetMovies();
            List<Movie> randomMovies = new List<Movie>();
            List<int> indices = new List<int>();
            Random r = new Random();

            if (numMovies > m.Count()) 
            {
                numMovies = m.Count();
            }

            for (int i = 1; i <= numMovies; i++) 
            {
                int random = r.Next(0, m.Count());
                while (indices.Contains(random)) 
                {
                    random = r.Next(0, m.Count());
                }
                indices.Add(random);
            }

            foreach (int i in indices) 
            {
                randomMovies.Add(m[i]);
            }

            return randomMovies;
        }

        //create new movie
        //localhost/api/movie/create
        [HttpPost("create")]
        public string CreateMovie(Movie m) 
        {
            mDB.CreateMovie(m);

            return $"{m.Title} successfully added";
        }

        //delete movie
        //localhost/api/movie/delete/id
        [HttpDelete("delete/{id}")]
        public string DeleteMovie(int id) 
        {
            mDB.DeleteMovie(id);

            return $"Movie {id} successfully deleted";
        }

        //update movie
        //localhost/api/movie/update/id
        [HttpPut("update/{id}")]
        public string UpdateMovie(int id, Movie newMovie) 
        {
            Movie oldMovie = mDB.GetMovie(id);
            if (newMovie.Title == null) 
            {
                newMovie.Title = oldMovie.Title;
            }
            if (newMovie.Genre == null)
            {
                newMovie.Genre = oldMovie.Genre;
            }

            mDB.UpdateMovie(id, newMovie);

            return $"{newMovie.Title} successfully updated";
        }

        //get random movie from specific genre
        //localhost/api/movie/random/{genre}
        [HttpGet("randombygenre/{genre}")]
        public Movie GetRandomByGenre(string genre) 
        {
            Movie m = mDB.GetRandomByGenre(genre);
            if (m == null) 
            {
                m = new Movie($"No movies with Genre: {genre}");
            }

            return m;
        } 
    }
}
