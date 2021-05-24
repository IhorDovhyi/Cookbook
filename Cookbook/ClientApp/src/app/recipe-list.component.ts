import { Component, OnInit } from '@angular/core';
import { DataService } from './data.service';
import { Recipe } from './recipe';

@Component({
    templateUrl: './recipe-list.component.html',
    styles: ['host:: ng-deep recipe-child-list  {tr class="table table-striped"}']
})
export class RecipeListComponent implements OnInit {

    recipes: Recipe[];
    constructor(private dataService: DataService) { }

    ngOnInit()
    {
        this.load();  
    }

    onChanged(increased: any) {
        if (increased == true)
            this.load();
    }

    load()
    {
        this.dataService.getRecipes().subscribe((data: Recipe[]) => this.recipes = data);
    }
}

