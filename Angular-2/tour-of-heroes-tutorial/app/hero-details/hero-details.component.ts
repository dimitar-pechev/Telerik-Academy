import { Component, Input, OnInit } from '@angular/core'
import { ActivatedRoute, Params } from '@angular/router';
import { Location } from '@angular/common';
import { Hero } from '../models/Hero';
import { HeroService } from '../shared/hero.service';
import 'rxjs/add/operator/switchMap';

@Component({
    selector: 'sh-hero-details',
    templateUrl: './hero-details.component.html',
    styleUrls: ['./hero-details.component.css']
})
export class HeroDetailsComponent implements OnInit {
    hero: Hero;

    constructor(
        private heroService: HeroService,
        private route: ActivatedRoute,
        private location: Location
    ) { }

    goBack() {
        this.location.back();
    }

    saveChanges() {
        this.heroService.updateHero(this.hero)
            .then(() => this.goBack());
    }

    ngOnInit() {
        this.route.params
            .switchMap(params => this.heroService.getHero(+params['id']))
            .subscribe((hero: Hero) => this.hero = hero);
    }
}