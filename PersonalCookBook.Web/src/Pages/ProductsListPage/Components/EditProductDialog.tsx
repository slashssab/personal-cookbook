import { Button, DialogActions, DialogBody, DialogContent, DialogSurface, DialogTitle, InputOnChangeData } from "@fluentui/react-components";
import { ChangeEvent, useState } from "react";
import { NumberInput } from "../../../Shared/NumberInput";
import { Product } from "../../../Models/Product";

interface EditProductDialogProperties {
    product: Product;
    openDialog(open: boolean): void;
    editProduct(product: Product): void;
}

export const EditProductDialog = (dialogProps: EditProductDialogProperties) => {
    const [calories, setCalories] = useState<number>(dialogProps.product.kcal);
    const [proteins, setProteins] = useState<number>(dialogProps.product.protein);
    const [carbohydrates, setCarbohydrates] = useState<number>(dialogProps.product.carbs);

    const handleCaloriesChanged = (event: ChangeEvent<HTMLInputElement>, data: InputOnChangeData) => {
        setCalories(Number(data.value));
    }

    const handleProteinsChanged = (event: ChangeEvent<HTMLInputElement>, data: InputOnChangeData) => {
        setProteins(Number(data.value));
    }

    const handleCarbohydratesChanged = (event: ChangeEvent<HTMLInputElement>, data: InputOnChangeData) => {
        setCarbohydrates(Number(data.value));
    }

    const closeDialog = () => {
        dialogProps.openDialog(false);
    }

    const editProduct = () => {
        if (calories === undefined) {
            alert("Please provide calories.")
        }
        else if (proteins === undefined) {
            alert("Please select proteins.")
        }
        else if (carbohydrates === undefined) {
            alert("Please select carbohydrates.")
        }
        else {
            const editedProduct = Object.assign({}, dialogProps.product);
            editedProduct.kcal = calories;
            editedProduct.protein = proteins;
            editedProduct.carbs = carbohydrates;

            dialogProps.editProduct(editedProduct as Product);
        }
    }

    return (
        <DialogSurface>
            <DialogBody>
                <DialogTitle>Edit Product</DialogTitle>
                <DialogContent>
                    <NumberInput text={"Calories"} onChange={handleCaloriesChanged} value={calories.toString()} />
                    <NumberInput text={"Proteins"} onChange={handleProteinsChanged} value={proteins.toString()}/>
                    <NumberInput text={"Carbohydrates"} onChange={handleCarbohydratesChanged} value={carbohydrates.toString()} />
                </DialogContent>
                <DialogActions>
                    <Button onClick={closeDialog} appearance="secondary">Close</Button>
                    <Button onClick={editProduct} appearance="primary">Update</Button>
                </DialogActions>
            </DialogBody>
        </DialogSurface>
    )
}