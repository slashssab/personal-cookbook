import { createAsyncThunk, createSlice, PayloadAction } from "@reduxjs/toolkit"
import { Recipe } from "../../Models/Recipe"
import { RecipeState } from "./RecipeState"
import { RootState } from "../store"
import { Ingredient } from "../../Models/Ingredient"
import { CreateRecipeDto } from "../../Models/ActionModels/CreateRecipeDto"

const initialState: RecipeState = {
    recipe: {
        id: 0,
        name: "",
        ingredients: []
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
            state.recipe = { ...state.recipe, ingredients: [...state.recipe.ingredients, action.payload] }
        }
    },
    extraReducers(builder) {
        builder
            .addCase(fetchRecipeById.pending, (state, action) => {
                state.status = 'loading';
            })
            .addCase(fetchRecipeById.fulfilled, (state, action) => {
                state.status = 'succeed';
                state.recipe = action.payload;
            })
            .addCase(fetchRecipeById.rejected, (state, action) => {
                state.status = 'failed';
                state.error = action.error;
            })
            .addCase(createRecipe.pending, (state, action) => {
                state.status = 'creating';
            })
            .addCase(createRecipe.fulfilled, (state, action) => {
                state.status = 'created';
                state.recipe = action.payload;
            })
            .addCase(createRecipe.rejected, (state, action) => {
                state.status = 'failed';
                state.error = action.error;
            })
    }
})

export const { addProduct } = recipeSlice.actions

// Other code such as selectors can use the imported `RootState` type
export const selectRecipe = (state: RootState) => state.recipe.recipe;
export const selectRecipeStatus = (state: RootState) => state.recipe.status;
export const selectRecipeId  = (state: RootState) => state.recipe.recipe.id;

export default recipeSlice.reducer

export const fetchRecipeById = createAsyncThunk('recipe/get', async (recipeId: number) => {
    const response = await fetchData(recipeId);
    return response as Recipe;
})

export const createRecipe = createAsyncThunk('recipe/new', async (newRecipe: CreateRecipeDto) => {
    const response = await fetchCreateRecipe(newRecipe);
    return response as Recipe;
})

const fetchData = async (recipeId: number) => {
    const endpoint = process.env.REACT_APP_API_URL + "/Recipe/" + recipeId;
    try {
        const response = await fetch(endpoint, {
            method: 'GET'
        })

        const result = await response.json();

        const recipes = result as Recipe;
        return recipes;
    }
    catch (e) {
        console.error(e);
    }
}

const fetchCreateRecipe = async (newRecipe: CreateRecipeDto) => {
    const endpoint = process.env.REACT_APP_API_URL + "/Recipe";
    try {
        const response = await fetch(endpoint, {
            method: 'POST',
            body: JSON.stringify(newRecipe),
            headers: {
                'Content-Type': 'application/json'
            }
        })

        const result = await response.json();

        const recipe = result as Recipe;
        return recipe;
    }
    catch (e) {
        console.error(e);
    }
}