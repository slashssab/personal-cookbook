import { Ingredient } from "../Ingredient";
import { Step } from "../Step";

export interface EditRecipeDto {
    id: number;
    name: string;
    description: string;
    ingredients: Ingredient[];
    steps: Step[];
}