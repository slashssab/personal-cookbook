import { Ingredient } from "../Ingredient";
import { Step } from "../Step";

export interface CreateRecipeDto {
    name: string;
    description: string;
    ingredients: Ingredient[];
    steps: Step[];
}