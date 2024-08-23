using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcMovie.Data;
using System;
using System.Linq;


namespace MvcMovie.Models;
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context=new MvcMovieContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MvcMovieContext>>()))
            {
                //look for any movies.
                if (context.Movie.Any())
                {
                    return;  //DB has been seeded
                }
                context.Movie.AddRange(
                    new Movie
                    {
                       Title = "When Harry Met Sally",
                       ReleaseDate = DateTime.Parse("1989-02-12"),
                       Genre = "Romantic Comedy",
                       Rating = "R",
                       Price = 7.99M
                       
                    },
                    new Movie
                    {
                        Title = "Ghostbusters",
                        ReleaseDate = DateTime.Parse("1984-03-13"),
                        Genre = "Comedy",
                        Rating = "RR",
                        Price = 8.99M
                    },
                    new Movie
                    {
                        Title = "Ghostbusters 2",
                        ReleaseDate = DateTime.Parse("1986-02-23"),
                        Genre = "Comedy",
                        Rating = "RRR",
                        Price = 9.99M
                    }, 
                    new Movie
                    {
                        Title = "Rio Bravo",
                        ReleaseDate = DateTime.Parse("1959-04-15"),
                        Genre = "Western",
                        Rating ="RRRR",
                        Price = 3.99M
                    }
                    );
                context.SaveChanges();
            }
        }
    }
