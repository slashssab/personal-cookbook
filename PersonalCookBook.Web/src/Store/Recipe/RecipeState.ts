import { Recipe } from "../../Models/Recipe";

export interface RecipeState {
    Recipe: Recipe;
    Loading: boolean;
    Error: Object;
}