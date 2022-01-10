using Dapper;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieAPILab
{
    public class MovieDAL
    {
        //CREATE
        public void CreateMovie(Movie m)
        {
            string sql = $"insert into movies values(0, \"{m.Title}\", '{m.Genre}')";

            using (var connect = new MySqlConnection(Secret.Connection)) 
            {
                connect.Open();
                connect.Query<Movie>(sql);
                connect.Close();
            }
        }

        //READ
        //read one movie by id
        public Movie GetMovie(int id) 
        {
            string sql = $"select * from movies where id={id}";

            using (var connect = new MySqlConnection(Secret.Connection))
            {
                connect.Open();
                Movie m = connect.Query<Movie>(sql).FirstOrDefault();
                connect.Close();

                return m;
            }

        }

        //read by category
        public List<Movie> GetByGenre(string value) 
        {
            string sql = $"select * from movies where genre='{value}'";

            using (var connect = new MySqlConnection(Secret.Connection))
            {
                connect.Open();
                List<Movie> m = connect.Query<Movie>(sql).ToList();
                connect.Close();

                return m;
            }

        }

        public Movie GetRandomByGenre(string genre) 
        {
            string sql = $"select * from movies where genre='{genre}'";

            using (var connect = new MySqlConnection(Secret.Connection))
            {
                connect.Open();
                List<Movie> m = connect.Query<Movie>(sql).ToList();
                connect.Close();

                Random r = new Random();
                int random = r.Next(0, m.Count());
                return m[random];
            }
        }

        //read all movies from DB
        public List<Movie> GetMovies() 
        {
            string sql = $"select * from movies";

            using (var connect = new MySqlConnection(Secret.Connection))
            {
                connect.Open();
                List<Movie> m = connect.Query<Movie>(sql).ToList();
                connect.Close();

                return m;
            }
        }

        //UPDATE
        public void UpdateMovie(int id, Movie m)
        {
            string sql = $"update movies set title=\"{m.Title}\", genre='{m.Genre}' where id={id}";

            using (var connect = new MySqlConnection(Secret.Connection))
            {
                connect.Open();
                connect.Query<Movie>(sql);
                connect.Close();

            }

        }

        //DELETE
        public void DeleteMovie(int id)
        {
            string sql = $"delete from movies where id={id}";

            using (var connect = new MySqlConnection(Secret.Connection))
            {
                connect.Open();
                connect.Query<Movie>(sql);
                connect.Close();

            }

        }

    }
}
