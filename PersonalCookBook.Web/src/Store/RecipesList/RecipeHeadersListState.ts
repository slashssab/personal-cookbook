import { RecipeHeader } from "../../Models/RecipeHeader";

export interface RecipeHeadersListState {
    recipeHeaders: RecipeHeader[];
    loading: boolean;
    status: 'idle' | 'loading' | 'succeed' | 'failed',
    error: Object;
}