import { Injectable } from '@angular/core';
import { Headers, Http } from '@angular/http';
import { Hero } from '../models/Hero';

@Injectable()
export class HeroService {
    private heroesUrl = 'api/heroes';
    private headers = new Headers({ 'Content-Type': 'application/json' });

    constructor(private http: Http) { }

    getHeroes(): Promise<Hero[]> {
        return this.http.get(this.heroesUrl)
            .toPromise()
            .then(res => res.json().data as Hero[])
            .catch(console.log);
    }

    getHero(id: number): Promise<Hero> {
        return this.http.get(`${this.heroesUrl}/${id}`)
            .toPromise()
            .then(res => res.json().data as Hero)
            .catch(console.log);
    }

    updateHero(hero: Hero): Promise<Hero> {
        const url = `${this.heroesUrl}/${hero.id}`;
        return this.http.put(url, JSON.stringify(hero), { headers: this.headers })
            .toPromise()
            .then(() => hero)
            .catch(console.log);
    }

    createHero(name: string): Promise<Hero> {
        return this.http
            .post(this.heroesUrl, JSON.stringify({ name: name }), { headers: this.headers })
            .toPromise()
            .then(res => res.json().data)
            .catch(console.log);
    }

    deleteHero(id: number): Promise<void> {
        const url = `${this.heroesUrl}/${id}`;
        return this.http.delete(url, { headers: this.headers })
            .toPromise()
            .then(() => null)
            .catch(console.log);
    }
}
