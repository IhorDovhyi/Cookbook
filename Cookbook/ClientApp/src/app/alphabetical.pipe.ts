import { Pipe, PipeTransform } from '@angular/core';
import { Recipe } from './recipe';

@Pipe({
    name: 'alphabetical'
})
export class AlphabeticalPipe implements PipeTransform {
    transform(array: Recipe[]): any {
        if(!array){ return; }
        return array.sort((a, b) => {
            if (a.name.toLowerCase() > b.name.toLowerCase()) {
                return 1;
            }
            if (a.name.toLowerCase() < b.name.toLowerCase()) {
                return -1;
            }
            return 0;
        });
    }
}