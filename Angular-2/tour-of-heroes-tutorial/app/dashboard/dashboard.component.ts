import { Component, OnInit } from '@angular/core';

import { Hero } from '../models/Hero';
import { HeroService } from '../shared/hero.service';

@Component({
    selector: 'sh-dashboard',
    templateUrl: './dashboard.component.html',
    styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {
    heroes: Hero[];

    constructor(private heroService: HeroService) { }

    ngOnInit() {
        this.heroService.getHeroes()
            .then(heroes => this.heroes = heroes.slice(1, 5))
            .catch(console.log);
    }
}
