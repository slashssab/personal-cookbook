import { Product } from "../../Models/Product";

export interface ProductState {
    product: Product;
    loading: boolean;
    status: 'idle' | 'loading' | 'succeed' | 'failed',
    error: Object;
}