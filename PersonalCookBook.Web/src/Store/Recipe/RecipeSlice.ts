import { createSlice, PayloadAction } from "@reduxjs/toolkit"
import { Recipe } from "../../Models/Recipe"
import { RecipeState } from "./RecipeState"
import { Product } from "../../Models/Product"
import { RootState } from "../store"

const initialState: RecipeState = {
    Recipe: {
        Id: 0,
        Ingredients: []
    } as Recipe,
    Loading: false,
    Error: {},
}

export const recipeSlice = createSlice({
    name: 'recipe',
    initialState,
    reducers: {
        addProduct: (state, action: PayloadAction<Product>) => {
            state.Recipe = { ...state.Recipe, Ingredients: [...state.Recipe.Ingredients, action.payload] }
        }
    }
})

export const { addProduct } = recipeSlice.actions

// Other code such as selectors can use the imported `RootState` type
export const selectRecipe = (state: RootState) => state.recipe.Recipe

export default recipeSlice.reducer