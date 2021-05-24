var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
import { Component, Input, Output, EventEmitter } from '@angular/core';
let RecipeChildListComponent = class RecipeChildListComponent {
    constructor(dataService) {
        this.dataService = dataService;
        this.onChanged = new EventEmitter();
        this.show = -1;
    }
    delete(id) {
        this.dataService.deleteRecipe(id).subscribe(data => this.change(true));
    }
    change(increased) {
        this.onChanged.emit(increased);
    }
    changeButton(button, id) {
        if (button.innerText === "Show child recipe") {
            button.innerText = "Hide child recipe";
            this.show = id;
        }
        else {
            button.innerText = "Show child recipe";
            this.show = -1;
        }
    }
};
__decorate([
    Input()
], RecipeChildListComponent.prototype, "recipes", void 0);
__decorate([
    Output()
], RecipeChildListComponent.prototype, "onChanged", void 0);
RecipeChildListComponent = __decorate([
    Component({
        selector: "recipe-child-list",
        templateUrl: './recipe-child-list.component.html',
    })
], RecipeChildListComponent);
export { RecipeChildListComponent };
//# sourceMappingURL=recipe-child-list.component.js.map