import { Component, OnInit, Injectable } from '@angular/core';
import { Http } from '@angular/http';

import { Movie } from '../models/Movie';

import { MoviesService } from '../data/movies.service';

@Injectable()
@Component({
    selector: 'mvdb-movies-list',
    templateUrl: './movies-list.component.html',
    styleUrls: ['./movies-list.component.css']
})
export class MoviesListComponent implements OnInit {
    movies: Movie[];
    pageTitle: string = 'Top 10 iMDB Movies';
    sortBy: string;
    order: string;
    filterQuery: string;

    constructor(private http: Http, private moviesService: MoviesService) { }

    ngOnInit() {
        this.movies = this.moviesService.getAllMovies();
    }

    updateSortingCriteria(criterion: string) {
        this.sortBy = criterion;
    }

    updateOrderCriteria(criterion: string) {
        this.order = criterion;
    }

    updateFilterQuery(query: string) {
        this.filterQuery = query;
    }
}
