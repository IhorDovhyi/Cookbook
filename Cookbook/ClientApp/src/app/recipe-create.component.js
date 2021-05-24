var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
import { Component } from '@angular/core';
import { Recipe } from './recipe';
let RecipeCreateComponent = class RecipeCreateComponent {
    constructor(dataService, router) {
        this.dataService = dataService;
        this.router = router;
        this.recipe = new Recipe();
    }
    save() {
        this.recipe.date = new Date();
        this.dataService.createRecipe(this.recipe).subscribe(data => this.router.navigateByUrl("/"));
    }
};
RecipeCreateComponent = __decorate([
    Component({
        templateUrl: './recipe-create.component.html'
    })
], RecipeCreateComponent);
export { RecipeCreateComponent };
//# sourceMappingURL=recipe-create.component.js.map