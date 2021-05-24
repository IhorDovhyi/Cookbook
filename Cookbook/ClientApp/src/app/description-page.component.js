var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
import { Component } from '@angular/core';
let DescriptionPageComponent = class DescriptionPageComponent {
    constructor(dataService, router, activeRoute) {
        this.dataService = dataService;
        this.router = router;
        this.loaded = false;
        this.id = Number.parseInt(activeRoute.snapshot.params["id"]);
    }
    ngOnInit() {
        if (this.id)
            this.dataService.getRecipe(this.id)
                .subscribe((data) => {
                this.recipe = data;
                if (this.recipe != null)
                    this.loaded = true;
            });
    }
    edit() {
        this.router.navigateByUrl("/edit/" + this.recipe.id);
    }
};
DescriptionPageComponent = __decorate([
    Component({
        templateUrl: './description-page.component.html'
    })
], DescriptionPageComponent);
export { DescriptionPageComponent };
//# sourceMappingURL=description-page.component.js.map