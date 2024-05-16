import { Button, DialogActions, DialogBody, DialogContent, DialogSurface, Option, DialogTitle, Dropdown, makeStyles, shorthands, useId, SelectionEvents, OptionOnSelectData, InputOnChangeData } from "@fluentui/react-components"
import { ChangeEvent, useState } from "react";
import { Product } from "../../../Models/Product";
import { NumberInput } from "../../../Shared/NumberInput";
import { Ingredient } from "../../../Models/Ingredient";

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
    const options = [
        {
            id: 1,
            name: "Chicken Breast",
            kcal: 165,
            protein: 31
        },
        {
            id: 2,
            name: "Pesto",
            kcal: 414,
            protein: 6.2
        },
        {
            id: 3,
            name: "Turkey",
            Kcal: 130,
            protein: 21
        },
        {
            id: 4,
            name: "Knor Napoli",
            kcal: 135,
            protein: 5.7
        },
        {
            id: 5,
            name: "Water",
            kcal: 100
        },
        {
            id: 6,
            name: "Olive oil",
            kcal: 100
        },
        {
            id: 7,
            name: "Pasta",
            kcal: 354,
            Protein: 12
        },
        {
            id: 8,
            name: "Brocoli",
            kcal: 100
        },
        {
            id: 9,
            name: "Pasta",
            kcal: 100
        },
        {
            id: 10,
            name: "Salmon",
            kcal: 100
        }
    ] as Product[];

    const styles = useStyles();
    const [selectedProduct, setSelectedProduct] = useState<Product>();
    const [selectedProductQuantity, setSelectedProductQuantity] = useState<number>(0);
    const handleOptionSelect = (event: SelectionEvents, data: OptionOnSelectData) => {
        const selectedProduct = options.find(p => p.name === data.optionText);
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
        else if (selectedProduct === undefined){
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
                            {options.map((option) => (
                                <Option key={option.id} disabled={option.name === "Beef"}>
                                    {option.name}
                                </Option>
                            ))}
                        </Dropdown>
                    </div>
                    <NumberInput onChange={handleQuantityChanged}/>
                </DialogContent>
                <DialogActions>
                    <Button onClick={closeDialog} appearance="secondary">Close</Button>
                    <Button onClick={addProduct} appearance="primary">Add ingredient</Button>
                </DialogActions>
            </DialogBody>
        </DialogSurface>)
}