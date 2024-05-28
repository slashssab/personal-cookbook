import { Button, DialogActions, DialogBody, DialogContent, DialogSurface, Option, DialogTitle, Dropdown, makeStyles, shorthands, useId, SelectionEvents, OptionOnSelectData, InputOnChangeData, Spinner } from "@fluentui/react-components"
import { ChangeEvent, useEffect, useState } from "react";
import { Ingredient } from "../Models/Ingredient";
import { Product } from "../Models/Product";
import { useAppSelector, useAppDispatch } from "../Store/hooks";
import { selectProducts, selectProductsStatus, fetchProducts } from "../Store/ProductsList/ProductsListSlice";
import { NumberInput } from "./NumberInput";

const useStyles = makeStyles({
    root: {
        // Stack the label above the field with a gap
        display: "grid",
        gridTemplateRows: "repeat(1fr)",
        justifyItems: "start",
        ...shorthands.gap("2px"),
        maxWidth: "400px",
    },
});

interface AddProductDialogProperties {
    openDialog(open: boolean): void;
    addIngredient(ingredient: Ingredient): void;
}

export const AddIngredientDialog = (dialogProps: AddProductDialogProperties) => {
    const dropdownId = useId("dropdown-default");


    const styles = useStyles();
    const [selectedProduct, setSelectedProduct] = useState<Product>();
    const [selectedProductQuantity, setSelectedProductQuantity] = useState<number>(0);
    const products = useAppSelector(selectProducts);
    const productsStatus = useAppSelector(selectProductsStatus);
    const dispatch = useAppDispatch()

    useEffect(() => {
        if (productsStatus === 'idle') {;
            dispatch(fetchProducts())
        }
    }, [productsStatus, dispatch])

    const handleOptionSelect = (event: SelectionEvents, data: OptionOnSelectData) => {
        const selectedProduct = products.find(p => p.name === data.optionText);
        setSelectedProduct(selectedProduct);
    }

    const handleQuantityChanged = (event: ChangeEvent<HTMLInputElement>, data: InputOnChangeData) => {
        setSelectedProductQuantity(Number(data.value));
    }

    const closeDialog = () => {
        dialogProps.openDialog(false);
    }

    const addProduct = () => {
        if (selectedProductQuantity === 0) {
            alert("Please provide quantity.")
        }
        else if (selectedProduct === undefined) {
            alert("Please select product.")
        }
        else {
            const ingredient = {
                product: selectedProduct,
                quantity: selectedProductQuantity
            }
            dialogProps.addIngredient(ingredient as Ingredient);
        }
    }

    return (
        <>
            {productsStatus !== 'succeed'
                ? <Spinner />
                :
                <DialogSurface>
                    <DialogBody>
                        <DialogTitle>Add ingredient</DialogTitle>
                        <DialogContent>
                            <div className={styles.root}>
                                <label id={dropdownId}>Select product</label>
                                <span>Selected {selectedProduct?.name}</span>
                                <Dropdown
                                    aria-labelledby={dropdownId}
                                    placeholder="product"
                                    {...dialogProps}
                                    onOptionSelect={handleOptionSelect}
                                >
                                    {products.map((product) => (
                                        <Option key={product.id} disabled={product.name === "Beef"}>
                                            {product.name}
                                        </Option>
                                    ))}
                                </Dropdown>
                            </div>
                            <NumberInput text={"Provide quantity (grams)"} onChange={handleQuantityChanged} />
                        </DialogContent>
                        <DialogActions>
                            <Button onClick={closeDialog} appearance="secondary">Close</Button>
                            <Button onClick={addProduct} appearance="primary">Add ingredient</Button>
                        </DialogActions>
                    </DialogBody>
                </DialogSurface>
            }
        </>
    )
}