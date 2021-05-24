var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
import { Component } from '@angular/core';
import { Recipe } from './recipe';
let RecipeCreateChildComponent = class RecipeCreateChildComponent {
    constructor(dataService, router, activeRoute) {
        this.dataService = dataService;
        this.router = router;
        this.recipePerent = new Recipe();
        this.recipe = new Recipe();
        this.loaded = false;
        this.id = Number.parseInt(activeRoute.snapshot.params["id"]);
    }
    ngOnInit() {
        if (this.id)
            this.dataService.getRecipe(this.id)
                .subscribe((data) => {
                this.recipePerent = data;
                if (this.recipePerent != null)
                    this.loaded = true;
            });
    }
    save() {
        this.recipe.date = new Date();
        this.recipePerent.childRecipes.push(this.recipe);
        this.dataService.updateRecipe(this.recipePerent).subscribe(data => this.router.navigateByUrl("/"));
    }
};
RecipeCreateChildComponent = __decorate([
    Component({
        templateUrl: './recipe-create-child.component.html'
    })
], RecipeCreateChildComponent);
export { RecipeCreateChildComponent };
//# sourceMappingURL=recipe-create-child.component.js.map