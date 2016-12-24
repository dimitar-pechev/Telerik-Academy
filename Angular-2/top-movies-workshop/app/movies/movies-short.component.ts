import { Component, Input } from '@angular/core';

import { Movie } from '../models/Movie';

@Component({
    selector: '[mvdb-movies-short]',
    templateUrl: './movies-short.component.html',
    styleUrls: ['./movies-short.component.css']
})
export class MoviesComponentShort {
    @Input() movie: Movie;

    createRange(len: number) {
        return new Array(len);
    }
}
