export class Movie {
    title: string;
    imdbId: string;
    poster: string;
    imdbRating: number;
    year: number;
    genre: string;
    director: string;
    actors: string;
    plot: string;
    starsCount: number;

    constructor(title?: string, imdbId?: string, poster?: string, imdbRating?: number, year?: number,
        genre?: string, director?: string, actors?: string, plot?: string) {
        this.title = title;
        this.imdbId = imdbId;
        this.poster = poster;
        this.imdbRating = imdbRating;
        this.year = year;
        this.genre = genre;
        this.director = director;
        this.actors = actors;
        this.plot = plot;
        this.starsCount = Math.round(this.imdbRating / 2);
    }
}
