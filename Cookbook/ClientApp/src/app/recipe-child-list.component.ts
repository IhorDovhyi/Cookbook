import { Component, Input, Output, EventEmitter } from '@angular/core';
import { DataService } from './data.service';
import { Recipe } from './recipe';
@Component({
    selector: "recipe-child-list",
    templateUrl: './recipe-child-list.component.html',
  
})
export class RecipeChildListComponent
{
    @Input() recipes: Recipe[];
    @Output() onChanged = new EventEmitter<boolean>();
    show: number = -1;
    constructor(private dataService: DataService) {}

    delete(id: number) {
        this.dataService.deleteRecipe(id).subscribe(data => this.change(true));
    }

    change(increased: any) {
        this.onChanged.emit(increased);
    }

    changeButton(button, id: number) {

        if (button.innerText === "Show child recipe") {
            button.innerText = "Hide child recipe";
            this.show = id;
        }
        else {
            button.innerText = "Show child recipe";
            this.show = -1;
        }
    }
}