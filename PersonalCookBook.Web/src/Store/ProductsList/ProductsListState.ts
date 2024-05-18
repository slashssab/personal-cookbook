import { Product } from "../../Models/Product";

export interface ProductsListState {
    products: Product[];
    loading: boolean;
    status: 'idle' | 'loading' | 'succeed' | 'failed',
    error: Object;
}