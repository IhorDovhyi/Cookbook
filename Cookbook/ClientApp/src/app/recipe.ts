import { RecipeHistory } from './recipeHistory';

export class Recipe
{
    constructor
    (
        public id?: number,
        public name?: string,
        public date?: Date,
        public description?: string,
        public childRecipes?: Recipe[],
        public recipeHistory?: RecipeHistory[]
    ) { }
}