import { Button, Dialog } from "@fluentui/react-components";
import { useEffect, useState } from "react";
import { useAppSelector, useAppDispatch } from "../../Store/hooks";
import { selectProducts, selectProductsStatus, fetchProducts, fetchCreateProduct } from "../../Store/ProductsList/ProductsListSlice";
import { ProductsList } from "./Components/ProductsList";
import { EditProductDialog } from "./Components/EditProductDialog";
import { Product } from "../../Models/Product";
import { CreateProductDialog } from "./Components/CreateProductDialog";
import { CreateProductDto } from "../../Models/ActionModels/CreateProductDto";
import { fetchEditProduct } from "../../Store/Product/ProductSlice";
import { LazyContentLoader } from "../../Shared/LazyContentLoader";

export const ProductsListPage = () => {
    const [openEditProductDialogState, setEditProductDialogState] = useState<{ opened: boolean, product: Product }>({ opened: false, product: {} as Product });
    const [openCreateProductDialogState, setCreateProductDialogState] = useState<boolean>(false);
    const products = useAppSelector(selectProducts);
    const productsStatus = useAppSelector(selectProductsStatus);
    const dispatch = useAppDispatch()

    useEffect(() => {
        if (productsStatus === 'idle') {
            dispatch(fetchProducts())
        }
    }, [productsStatus, dispatch])

    const editProductClicked = (product: Product) => {
        setEditProductDialogState({
            opened: true,
            product: product
        });

    }

    const editProduct = (product: Product) => {
        dispatch(fetchEditProduct(product))
        setEditProductDialogState({ ...openEditProductDialogState, opened: false });
    }

    const createProduct = (product: CreateProductDto) => {
        dispatch(fetchCreateProduct(product))
        setCreateProductDialogState(false);
    }

    const setOpenEditProductDialogState = (open: boolean) => {
        setEditProductDialogState({ ...openEditProductDialogState, opened: open });
    }

    const setOpenCreateProductDialogState = (open: boolean) => {
        setCreateProductDialogState(open);
    }

    return (
        <>
            <LazyContentLoader status={productsStatus}>
                <ProductsList editProduct={editProductClicked} products={products} />
            </LazyContentLoader>

            <Button onClick={() => setOpenCreateProductDialogState(true)} appearance="primary">Add product</Button>
            <Dialog open={openCreateProductDialogState}>
                <CreateProductDialog openDialog={setOpenCreateProductDialogState} createProduct={createProduct} />
            </Dialog>
            <Dialog open={openEditProductDialogState.opened}>
                <EditProductDialog editProduct={editProduct} openDialog={setOpenEditProductDialogState} product={openEditProductDialogState.product} />
            </Dialog>
        </>
    );
};