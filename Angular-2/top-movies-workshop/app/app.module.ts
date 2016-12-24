import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpModule } from '@angular/http';

import { AppRoutingModule } from './app-routing.module';

import { AppComponent } from './app.component';
import { MoviesListComponent } from './movies/movies-list.component';
import { MoviesComponentShort } from './movies/movies-short.component';
import { MovieDetailsComponent } from './movies/movie-details.component';

import { MoviesService } from './data/movies.service';

import { SortPipe } from './pipes/sort.pipe';
import { FilterPipe } from './pipes/filter.pipe';

@NgModule({
    declarations: [
        AppComponent,
        MoviesListComponent,
        MoviesComponentShort,
        MovieDetailsComponent,
        SortPipe,
        FilterPipe
    ],
    imports: [
        BrowserModule,
        HttpModule,
        AppRoutingModule
    ],
    providers: [
        MoviesService
    ],
    bootstrap: [AppComponent]
})
export class AppModule { }
