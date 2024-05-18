import { configureStore } from "@reduxjs/toolkit";
import { recipeSlice } from "./Recipe/RecipeSlice";
import { recipeHeadersSlice } from "./RecipesList/RecipeHeadersListSlice";
import { productsListSlice } from "./ProductsList/ProductsListSlice";

export const store = configureStore({
    reducer: {
        recipe: recipeSlice.reducer,
        recipeHeaders: recipeHeadersSlice.reducer,
        products: productsListSlice.reducer
    }
})

export type RootState = ReturnType<typeof store.getState>
export type AppDispatch = typeof store.dispatch