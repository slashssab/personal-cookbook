import { createSlice, PayloadAction } from "@reduxjs/toolkit"
import { Recipe } from "../../Models/Recipe"
import { RecipeState } from "./RecipeState"
import { RootState } from "../store"
import { Ingredient } from "../../Models/Ingredient"

const initialState: RecipeState = {
    recipe: {
        Id: 0,
        Ingredients: []
    } as Recipe,
    status: 'idle',
    loading: false,
    error: {},
}

export const recipeSlice = createSlice({
    name: 'recipe',
    initialState,
    reducers: {
        addProduct: (state, action: PayloadAction<Ingredient>) => {
            state.recipe = { ...state.recipe, Ingredients: [...state.recipe.Ingredients, action.payload] }
        }
    }
})

export const { addProduct } = recipeSlice.actions

// Other code such as selectors can use the imported `RootState` type
export const selectRecipe = (state: RootState) => state.recipe.recipe

export default recipeSlice.reducer