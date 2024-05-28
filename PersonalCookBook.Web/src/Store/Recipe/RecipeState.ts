import { Recipe } from "../../Models/Recipe";

export interface RecipeState {
    recipe: Recipe;
    loading: boolean;
    status: 'idle' | 'loading' | 'succeed' | 'failed' | 'creating' | 'created',
    error: Object;
}