import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { DataService } from './data.service';
import { Recipe } from './recipe';

@Component({
    templateUrl: './recipe-create.component.html'
})
export class RecipeCreateComponent {

    recipe: Recipe = new Recipe(); 
    constructor(private dataService: DataService, private router: Router) { }
    save()
    {
        this.recipe.date = new Date();
        this.dataService.createRecipe(this.recipe).subscribe(data => this.router.navigateByUrl("/"));
    }
}