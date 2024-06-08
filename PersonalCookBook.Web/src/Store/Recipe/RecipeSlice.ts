import { createAsyncThunk, createSlice, PayloadAction } from "@reduxjs/toolkit"
import { Recipe } from "../../Models/Recipe"
import { RecipeState } from "./RecipeState"
import { RootState } from "../store"
import { Ingredient } from "../../Models/Ingredient"
import { CreateRecipeDto } from "../../Models/ActionModels/CreateRecipeDto"
import { EditRecipeDto } from "../../Models/ActionModels/EditRecipeDto"
import { Step } from "../../Models/Step"

const initialState: RecipeState = {
    recipe: {
        id: 0,
        name: "",
        description: "",
        ingredients: [],
        steps: [],
        totalCalories: 0,
        totalProteins: 0
    } as Recipe,
    status: 'idle',
    loading: false,
    error: {},
}

export const recipeSlice = createSlice({
    name: 'recipe',
    initialState,
    reducers: {
        addIngredient: (state, action: PayloadAction<Ingredient>) => {
            state.recipe = { ...state.recipe, ingredients: [...state.recipe.ingredients, action.payload] }
        },
        addStep: (state, action: PayloadAction<Step>) => {
            state.recipe = { ...state.recipe, steps: [...state.recipe.steps, action.payload] }
        },
        updateName: (state, action: PayloadAction<string>) => {
            state.recipe = { ...state.recipe, name: action.payload }
        },
        updateDescription: (state, action: PayloadAction<string>) => {
            state.recipe = { ...state.recipe, description: action.payload }
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
            .addCase(editRecipe.pending, (state, action) => {
                state.status = 'updating';
            })
            .addCase(editRecipe.fulfilled, (state, action) => {
                state.status = 'updated';
                state.recipe = action.payload;
            })
            .addCase(editRecipe.rejected, (state, action) => {
                state.status = 'failed';
                state.error = action.error;
            })
    }
})

export const { addIngredient, addStep } = recipeSlice.actions;
export const { updateName: updateRecipeName } = recipeSlice.actions;
export const { updateDescription: updateRecipeDescription } = recipeSlice.actions;

// Other code such as selectors can use the imported `RootState` type
export const selectRecipe = (state: RootState) => state.recipe.recipe;
export const selectRecipeStatus = (state: RootState) => state.recipe.status;
export const selectRecipeId = (state: RootState) => state.recipe.recipe.id;

export default recipeSlice.reducer

export const fetchRecipeById = createAsyncThunk('recipe/get', async (recipeId: number) => {
    const response = await fetchData(recipeId);
    return response as Recipe;
})

export const createRecipe = createAsyncThunk('recipe/new', async (newRecipe: CreateRecipeDto) => {
    const response = await fetchCreateRecipe(newRecipe);
    return response as Recipe;
})

export const editRecipe = createAsyncThunk('recipe/edit', async (newRecipe: EditRecipeDto) => {
    const response = await fetchEditRecipe(newRecipe);
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

const fetchEditRecipe = async (newRecipe: EditRecipeDto) => {
    const endpoint = process.env.REACT_APP_API_URL + "/Recipe/" + newRecipe.id + "/Edit";
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