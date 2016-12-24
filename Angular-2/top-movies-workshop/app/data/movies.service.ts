import { Injectable } from '@angular/core';
import { Http, Response } from '@angular/http';
import { Movie } from '../models/Movie';

@Injectable()
export class MoviesService {
    constructor(private http: Http) { }

    getAllMovies(): Movie[] {
        let movies: Movie[] = [];

        this.http.get('../data/movies.json')
            .map((res: Response) => res.json())
            .subscribe(resMovies => {
                resMovies.forEach((movie: any) =>
                    movies.push(new Movie(movie.Title, movie.imdbID, movie.Poster, movie.imdbRating,
                        movie.Year, movie.Genre, movie.Director, movie.Actors, movie.Plot)));
                return movies;
            });

        return movies;
    }

    getMovieById(imdbId: string): Promise<Movie> {
        // Working pretty slow with the provided server. Use the version below for local tests.
        let templateUrl = `http://www.omdbapi.com/?i=${imdbId}&plot=full&r=json`;

        return this.http.get(templateUrl)
            .toPromise()
            .then((res: Response) => res.json())
            .then(targetMovie => {
                let movie = new Movie(targetMovie.Title, targetMovie.imdbID, targetMovie.Poster, targetMovie.imdbRating,
                    targetMovie.Year, targetMovie.Genre, targetMovie.Director, targetMovie.Actors, targetMovie.Plot);

                return movie;
            });

        /*return this.http.get('../data/movies.json')
            .toPromise()
            .then((res: Response) => res.json())
            .then(resMovies => {
                let targetMovie = resMovies.find((mov: any) => mov.imdbID === imdbId);
                let movie = new Movie(targetMovie.Title, targetMovie.imdbID, targetMovie.Poster, targetMovie.imdbRating,
                    targetMovie.Year, targetMovie.Genre, targetMovie.Director, targetMovie.Actors, targetMovie.Plot);

                return movie;
            });*/
    }
}
