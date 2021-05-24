export class RecipeHistory {
    constructor
    (
        public id?: number,
        public date?: Date,
        public name?: string,
        public description?: string,
        public child?: number
    ) { }
}