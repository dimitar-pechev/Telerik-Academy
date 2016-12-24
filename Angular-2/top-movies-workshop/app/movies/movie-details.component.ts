import { Component, OnInit, Injectable } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

import { MoviesService } from '../data/movies.service';

import { Movie } from '../models/Movie';

@Injectable()
@Component({
    selector: 'mvdb-movie-details',
    templateUrl: './movie-details.component.html',
    styles: [
        `
        tr {
            cursor: pointer;
        }
        `
    ]
})
export class MovieDetailsComponent implements OnInit {
    movie: Movie;

    constructor(private moviesService: MoviesService, private route: ActivatedRoute) {
        this.movie = this.movie || new Movie();
    }

    createRange(len: number) {
        len = len || 0;
        return new Array(len);
    }

    ngOnInit() {
        this.route.params
            .switchMap((params: any) => this.moviesService.getMovieById(params.imdbId))
            .subscribe((mov: Movie) => this.movie = mov);
    }
}
