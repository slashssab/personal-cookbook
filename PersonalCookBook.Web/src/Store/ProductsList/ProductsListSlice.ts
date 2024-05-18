import { createAsyncThunk, createSlice } from "@reduxjs/toolkit";
import { RootState } from "../store";
import { ProductsListState } from "./ProductsListState";
import { Product } from "../../Models/Product";

const initialState: ProductsListState = {
    products: [],
    status: 'idle',
    loading: false,
    error: {},
}

export const productsListSlice = createSlice({
    name: 'productsList',
    initialState,
    reducers: {},
    extraReducers(builder) {
        builder
            .addCase(fetchProducts.pending, (state, action) => {
                state.status = 'loading';
            })
            .addCase(fetchProducts.fulfilled, (state, action) => {
                state.status = 'succeed';
                state.products = action.payload;
            })
            .addCase(fetchProducts.rejected, (state, action) => {
                state.status = 'failed';
                state.error = action.error;
            })
    }
})

export const fetchProducts = createAsyncThunk('products/get', async () => {
    const response = await fetchData();
    return response as Product[];
})

export default productsListSlice.reducer

export const selectProducts = (state: RootState) => state.products.products
export const selectProductsStatus = (state: RootState) => state.products.status

const fetchData = async () => {
    const endpoint = process.env.REACT_APP_API_URL + "/Products";
    try {
        const response = await fetch(endpoint, {
            method: 'GET'
        })

        const result = await response.json();

        const recipes = result.products as Product[];
        return recipes;
    }
    catch (e) {
        console.error(e);
    }
}
