import { Button, DialogActions, DialogBody, DialogContent, DialogSurface, Option, DialogTitle, Dropdown, makeStyles, shorthands, useId, SelectionEvents, OptionOnSelectData } from "@fluentui/react-components"
import { useState } from "react";
import { Product } from "../../../Models/Product";
import { NumberInput } from "../../../Shared/NumberInput";

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
    addProduct(ingredient: Product): void;
}

export const AddProductDialog = (dialogProps: AddProductDialogProperties) => {
    const dropdownId = useId("dropdown-default");
    const options = [
        "Chicken",
        "Beef",
        "Potato",
        "Tomato",
        "Water",
        "Olive oil",
        "Fish",
        "Brocoli",
        "Pasta",
        "Salmon",
    ];
    const styles = useStyles();
    const [selectedProduct, setSelectedProduct] = useState<Product>();
    const handleOptionSelect = (event: SelectionEvents, data: OptionOnSelectData) => {
        setSelectedProduct({ Name: data.optionText } as Product);
    }

    const closeDialog = () => {
        dialogProps.openDialog(false);
    }

    const addProduct = () => {
        dialogProps.addProduct(selectedProduct as Product);
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
                                <Option key={option} disabled={option === "Beef"}>
                                    {option}
                                </Option>
                            ))}
                        </Dropdown>
                    </div>
                    <NumberInput />
                </DialogContent>
                <DialogActions>
                    <Button onClick={closeDialog} appearance="secondary">Close</Button>
                    <Button onClick={addProduct} appearance="primary">Add ingredient</Button>
                </DialogActions>
            </DialogBody>
        </DialogSurface>)
}