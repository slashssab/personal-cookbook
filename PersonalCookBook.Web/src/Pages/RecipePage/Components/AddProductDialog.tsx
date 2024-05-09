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
            Id: 1,
            Name: "Chicken Breast",
            Kcal: 165,
            Protein: 31
        },
        {
            Id: 2,
            Name: "Pesto",
            Kcal: 414,
            Protein: 6.2
        },
        {
            Id: 3,
            Name: "Potato",
            Kcal: 100
        },
        {
            Id: 4,
            Name: "Tomato",
            Kcal: 100
        },
        {
            Id: 5,
            Name: "Water",
            Kcal: 100
        },
        {
            Id: 6,
            Name: "Olive oil",
            Kcal: 100
        },
        {
            Id: 7,
            Name: "Pasta",
            Kcal: 354,
            Protein: 12
        },
        {
            Id: 8,
            Name: "Brocoli",
            Kcal: 100
        },
        {
            Id: 9,
            Name: "Pasta",
            Kcal: 100
        },
        {
            Id: 10,
            Name: "Salmon",
            Kcal: 100
        }
    ] as Product[];

    const styles = useStyles();
    const [selectedProduct, setSelectedProduct] = useState<Product>();
    const [selectedProductQuantity, setSelectedProductQuantity] = useState<number>(0);
    const handleOptionSelect = (event: SelectionEvents, data: OptionOnSelectData) => {
        const selectedProduct = options.find(p => p.Name === data.optionText);
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
                Product: selectedProduct,
                Quantity: selectedProductQuantity
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
                        <span>Selected {selectedProduct?.Name}</span>
                        <Dropdown
                            aria-labelledby={dropdownId}
                            placeholder="product"
                            {...dialogProps}
                            onOptionSelect={handleOptionSelect}
                        >
                            {options.map((option) => (
                                <Option key={option.Id} disabled={option.Name === "Beef"}>
                                    {option.Name}
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