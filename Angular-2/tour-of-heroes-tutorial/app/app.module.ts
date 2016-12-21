import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpModule } from '@angular/http';
import { FormsModule } from '@angular/forms';

import { InMemoryWebApiModule } from 'angular-in-memory-web-api';
import { InMemoryDataService } from './shared/in-memory-data.service';

import { AppRoutingModule } from './app-routing.module';

import { HeroSearchService } from './hero-search/hero-search.service';
import { HeroService } from './shared/hero.service';

import { AppComponent } from './app.component';
import { HeroesComponent } from './heroes/heroes.component';
import { HeroDetailsComponent } from './hero-details/hero-details.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { HeroSearchComponent } from './hero-search/hero-search.component';

@NgModule({
    declarations: [
        AppComponent,
        HeroDetailsComponent,
        HeroesComponent,
        DashboardComponent,
        HeroSearchComponent
    ],
    providers: [
        HeroService,
        HeroSearchService
    ],
    imports: [
        BrowserModule,
        FormsModule,
        HttpModule,
        AppRoutingModule,
        InMemoryWebApiModule.forRoot(InMemoryDataService)
    ],
    bootstrap: [
        AppComponent
    ]
})
export class AppModule { }
