import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { Observable } from 'rxjs';

import { Hero } from '../models/Hero';

@Injectable()
export class HeroSearchService {
    constructor(private http: Http) { }

    search(query: string): Observable<Hero[]> {
        return this.http.get(`app/heroes/?name=${query}`)
            .map(response => response.json().data as Hero[]);
    }
}
