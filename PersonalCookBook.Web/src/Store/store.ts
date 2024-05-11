import { configureStore } from "@reduxjs/toolkit";
import { recipeSlice } from "./Recipe/RecipeSlice";
import { recipeHeadersSlice } from "./RecipesList/RecipeHeadersListSlice";

export const store = configureStore({
    reducer: {
        recipe: recipeSlice.reducer,
        recipeHeaders: recipeHeadersSlice.reducer
    }
})

export type RootState = ReturnType<typeof store.getState>
export type AppDispatch = typeof store.dispatch