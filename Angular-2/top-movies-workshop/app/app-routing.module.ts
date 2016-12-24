import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { MoviesListComponent } from './movies/movies-list.component';
import { MovieDetailsComponent } from './movies/movie-details.component';

const routes: Routes = [
    { path: '', redirectTo: '/top', pathMatch: 'full' },
    { path: 'top', component: MoviesListComponent },
    { path: 'details/:imdbId', component: MovieDetailsComponent }
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})
export class AppRoutingModule { }