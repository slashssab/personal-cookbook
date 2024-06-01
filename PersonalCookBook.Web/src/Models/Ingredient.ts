import { Product } from "./Product";

export interface Ingredient {
    product: Product;
    quantity: number;
    totalCalories: number;
    totalProteins: number;
}