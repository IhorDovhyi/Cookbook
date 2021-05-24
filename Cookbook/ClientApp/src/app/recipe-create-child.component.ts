import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { DataService } from './data.service';
import { Recipe } from './recipe';

@Component({
    templateUrl: './recipe-create-child.component.html'
})
export class RecipeCreateChildComponent implements OnInit {

    id: number;
    recipePerent: Recipe = new Recipe();
    recipe: Recipe = new Recipe();
    loaded: boolean = false;

    constructor(private dataService: DataService, private router: Router, activeRoute: ActivatedRoute) {
        this.id = Number.parseInt(activeRoute.snapshot.params["id"]);
    }

    ngOnInit() {
        if (this.id)
            this.dataService.getRecipe(this.id)
                .subscribe((data: Recipe) => {
                    this.recipePerent = data;
                    if (this.recipePerent != null) this.loaded = true;
                });
    }

    save() {
        this.recipe.date = new Date();
        this.recipePerent.childRecipes.push(this.recipe);
        this.dataService.updateRecipe(this.recipePerent).subscribe(data => this.router.navigateByUrl("/"));
    }
}