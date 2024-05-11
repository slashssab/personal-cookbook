import { createAsyncThunk, createSlice } from "@reduxjs/toolkit";
import { RecipeHeadersListState } from "./RecipeHeadersListState";
import { RecipeHeader } from "../../Models/RecipeHeader";
import { RootState } from "../store";

const initialState: RecipeHeadersListState = {
    recipeHeaders: [],
    status: 'idle',
    loading: false,
    error: {},
}

export const recipeHeadersSlice = createSlice({
    name: 'recipeHeaders',
    initialState,
    reducers: {},
    extraReducers(builder) {
        builder
            .addCase(fetchRecipeHeaders.pending, (state, action) => {
                state.status = 'loading';
            })
            .addCase(fetchRecipeHeaders.fulfilled, (state, action) => {
                state.status = 'succeed';
                state.recipeHeaders = action.payload;
            })
            .addCase(fetchRecipeHeaders.rejected, (state, action) => {
                state.status = 'failed';
                state.error = action.error;
            })
    }
})

export const fetchRecipeHeaders = createAsyncThunk('recipeHeaders/get', async () => {
    const response = await fetchData();
    return response as RecipeHeader[];
})

export default recipeHeadersSlice.reducer

export const selectRecipeHeaders = (state: RootState) => state.recipeHeaders.recipeHeaders
export const selectRecipeHeadersStatus = (state: RootState) => state.recipeHeaders.status

const fetchData = async () => {
    const endpoint = process.env.REACT_APP_API_URL + "/Recipes";
    try {
        const response = await fetch(endpoint, {
            method: 'GET'
        })

        const result = await response.json();

        const recipes = result.recipes as RecipeHeader[];
        return recipes;
    }
    catch (e) {
        console.error(e);
    }
}
