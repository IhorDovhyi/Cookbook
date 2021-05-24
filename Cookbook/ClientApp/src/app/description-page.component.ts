import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { DataService } from './data.service';
import { Recipe } from './recipe';

@Component({
    templateUrl: './description-page.component.html'
})
export class DescriptionPageComponent implements OnInit {

    id: number;
    recipe: Recipe;
    loaded: boolean = false;

    constructor(private dataService: DataService, private router: Router, activeRoute: ActivatedRoute) {
        this.id = Number.parseInt(activeRoute.snapshot.params["id"]);
    }

    ngOnInit() {
        if (this.id)
            this.dataService.getRecipe(this.id)
                .subscribe((data: Recipe) => {
                    this.recipe = data;
                    if (this.recipe != null) this.loaded = true;
                });
    }

    edit() {
        this.router.navigateByUrl("/edit/" + this.recipe.id);
    }
}