import { InMemoryDbService } from 'angular-in-memory-web-api';

export class InMemoryDataService implements InMemoryDbService {
    createDb() {
        let heroes = [
            { id: 1, name: 'Michu' },
            { id: 2, name: 'Kimi Raikonen' },
            { id: 3, name: 'Velizarii' },
            { id: 4, name: 'Dubi' },
            { id: 5, name: 'Il Padre' },
            { id: 6, name: 'Ispnqta' }
        ];

        return { heroes };
    }
}
