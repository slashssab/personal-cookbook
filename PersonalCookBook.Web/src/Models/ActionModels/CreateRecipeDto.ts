import { Ingredient } from "../Ingredient";

export interface CreateRecipeDto {
    name: string;
    description: string;
    ingredients: Ingredient[];
    steps: any[];
}