import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
    name: 'sort',
    pure: false
})
export class SortPipe implements PipeTransform {
     transform(movies: any[], options: string[]) {
        let property: string = options[0] || 'title',
            order: string = options[1] || 'asc';

        if (!movies || movies.length === 0) {
            return undefined;
        }

        const sorted = movies.sort((first: any, second: any) => {
            const comparison = first[property].localeCompare(second[property]);
            if (order === 'desc') {
                return -comparison;
            }

            return comparison;
        });

        return sorted;
    }
}
