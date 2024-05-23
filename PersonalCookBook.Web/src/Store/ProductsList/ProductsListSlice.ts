import { createAsyncThunk, createSlice } from "@reduxjs/toolkit";
import { RootState } from "../store";
import { ProductsListState } from "./ProductsListState";
import { Product } from "../../Models/Product";
import { CreateProductDto } from "../../Models/ActionModels/CreateProductDto";
import { fetchEditProduct } from "../Product/ProductSlice";

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
            .addCase(fetchCreateProduct.pending, (state, action) => {
                state.status = 'loading';
            })
            .addCase(fetchCreateProduct.fulfilled, (state, action) => {
                state.status = 'succeed';
                state.products = [...state.products, action.payload];
            })
            .addCase(fetchCreateProduct.rejected, (state, action) => {
                state.status = 'failed';
                state.error = action.error;
            })
            .addCase(fetchEditProduct.fulfilled, (state, action) => {
                // Trigger fetching new products once product edited.
                state.status = 'idle';
            })
    }
})

export const fetchProducts = createAsyncThunk('products/get', async () => {
    const response = await fetchData();
    return response as Product[];
})

export const fetchCreateProduct = createAsyncThunk('products/new', async (request: CreateProductDto) => {
    const response = await fetchCreate(request);
    return response as Product;
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

        const products = result.products as Product[];
        return products;
    }
    catch (e) {
        console.error(e);
    }
}

const fetchCreate = async (body: CreateProductDto) => {
    const endpoint = process.env.REACT_APP_API_URL + "/Product";
    try {
        const response = await fetch(endpoint, {
            method: 'POST',
            body: JSON.stringify(body),
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
