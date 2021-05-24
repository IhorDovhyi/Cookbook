import { Component, Input } from '@angular/core';
import { Recipe } from './recipe';
@Component({
    selector: "recipe-form",
    templateUrl: './recipe-form.component.html'
})
export class RecipeFormComponent {
    @Input() recipe: Recipe;
}