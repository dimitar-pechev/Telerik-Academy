import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { Hero } from '../models/Hero';
import { HeroService } from '../shared/hero.service';

@Component({
    selector: 'sh-heroes',
    templateUrl: './heroes.component.html',
    styleUrls: ['./heroes.component.css']
})
export class HeroesComponent implements OnInit {
    heroes: Hero[];
    selectedHero: Hero;

    constructor(private heroService: HeroService, private router: Router) { }

    getHeroes() {
        this.heroService.getHeroes()
            .then(heroes => this.heroes = heroes)
            .catch(console.log);
    }

    onSelect(hero: Hero) {
        this.selectedHero = hero;
    }

    addHero(name: string) {
        name = name.trim();
        if (!name) {
            return;
        }

        this.heroService.createHero(name)
            .then(hero => {
                this.heroes.push(hero);
                this.selectedHero = null;
            });
    }

    deleteHero(hero: Hero) {
        this.heroService.deleteHero(hero.id)
            .then(() => {
                this.heroes = this.heroes.filter(x => x.name !== hero.name);
                if (this.selectedHero && this.selectedHero.name === hero.name) {
                    this.selectedHero = null;
                }
            });
    }

    ngOnInit() {
        this.getHeroes();
    }

    gotoDetails() {
        this.router.navigate(['/details', this.selectedHero.id]);
    }
}
