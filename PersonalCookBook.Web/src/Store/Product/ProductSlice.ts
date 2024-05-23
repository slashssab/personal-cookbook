import { createAsyncThunk, createSlice } from "@reduxjs/toolkit";
import { Product } from "../../Models/Product";
import { ProductState } from "./ProductState";

const initialState: ProductState = {
    product: {} as Product,
    status: 'idle',
    loading: false,
    error: {},
}

export const productSlice = createSlice({
    name: 'product',
    initialState,
    reducers: {},
    extraReducers(builder) {
        builder
            .addCase(fetchEditProduct.pending, (state, action) => {
                state.status = 'loading';
            })
            .addCase(fetchEditProduct.fulfilled, (state, action) => {
                state.status = 'succeed';
                state.product = action.payload;
            })
            .addCase(fetchEditProduct.rejected, (state, action) => {
                state.status = 'failed';
                state.error = action.error;
            })
    }
})

export const fetchEditProduct = createAsyncThunk('product/edit', async (request: Product, {dispatch}) => {
    const response = await fetchEdit(request);
    // dispatch(fetchProducts());
    return response as Product;
})

const fetchEdit = async (request: Product) => {
    const endpoint = process.env.REACT_APP_API_URL + "/Product/" + request.id + "/Edit";
    try {
        const response = await fetch(endpoint, {
            method: 'POST',
            body: JSON.stringify({
                name: request.name,
                kilocalories: request.kcal,
                proteins: request.protein,
                carbohydrates: request.carbs
            }),
            headers: {
                'Content-Type': 'application/json'
            }
        })

        const result = await response.json();

        const product = result as Product;
        return product;
    }
    catch (e) {
        console.error(e);
    }
}