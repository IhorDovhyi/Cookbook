import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Recipe } from './recipe';

@Injectable()
export class DataService {

    private url = "/api/recipes";

    constructor(private http: HttpClient) {}

    getRecipes()
    {
        return this.http.get(this.url);
    }

    getRecipe(id: number)
    {
        return this.http.get(this.url + '/' + id);
    }

    createRecipe(recipe: Recipe)
    {
        return this.http.post(this.url, recipe);
    }

    createRecipeChild(id: number, recipe: Recipe) {

        return this.http.put(this.url + '/' + id, recipe);
    }

    updateRecipe(recipe: Recipe)
    {
        return this.http.put(this.url, recipe);
    }

    deleteRecipe(id: number)
    {
        return this.http.delete(this.url + '/' + id);
    }
}