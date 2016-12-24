import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
    name: 'filter',
    pure: false
})
export class FilterPipe implements PipeTransform {
    transform(movies: any[], query: string) {
        if (!query || !query.trim()) {
            return movies;
        }

        return movies.filter(movie => movie.title.toLowerCase().includes(query.trim().toLowerCase()));
    }
}
