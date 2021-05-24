import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { DataService } from './data.service';
import { Recipe } from './recipe';
import { RecipeHistory } from './recipeHistory';

@Component({
    selector: "recipe-history-page",
    templateUrl: './recipe-history.component.html',

})
export class RecipeHistoriPage implements OnInit {

    recipe: Recipe;
    recipeHistory: RecipeHistory[];
    loaded: boolean = false;
    id: number;

    constructor(private dataService: DataService, activeRoute: ActivatedRoute) {
        this.id = Number.parseInt(activeRoute.snapshot.params["id"]);
    }

    ngOnInit() {
        if (this.id)
            this.dataService.getRecipe(this.id)
                .subscribe((data: Recipe) => {
                    this.recipe = data;
                    if (this.recipe != null) this.loaded = true;
                });

      
        this.recipeHistory = this.recipe.recipeHistory;
       
    }
}