import { Ingredient } from "./Ingredient";
import { Step } from "./Step";

export interface Recipe {
    id: number;
    name: string;
    description: string;
    ingredients: Ingredient[];
    steps: Step[];
    totalCalories: number;
    totalProteins: number;
}