import { InputOnChangeData, DialogSurface, DialogBody, DialogTitle, DialogContent, DialogActions, Button } from "@fluentui/react-components";
import { useState, ChangeEvent } from "react";
import { NumberInput } from "../../../Shared/NumberInput";
import { TextInput } from "../../../Shared/TextInput";
import { CreateProductDto } from "../../../Models/ActionModels/CreateProductDto";

interface CreateProductDialogProperties {
    openDialog(open: boolean): void;
    createProduct(product: CreateProductDto): void;
}

export const CreateProductDialog = (dialogProps: CreateProductDialogProperties) => {
    const [name, setName] = useState<string>('');
    const [calories, setCalories] = useState<number>(0);
    const [proteins, setProteins] = useState<number>(0);
    const [carbohydrates, setCarbohydrates] = useState<number>(0);

    const handleNameChanged = (event: ChangeEvent<HTMLInputElement>, data: InputOnChangeData) => {
        setName(data.value);
    }

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
        if (name.length === 0) {
            alert("Please provide name.")
        }
        else if (calories === undefined) {
            alert("Please provide calories.")
        }
        else if (proteins === undefined) {
            alert("Please select proteins.")
        }
        else if (carbohydrates === undefined) {
            alert("Please select carbohydrates.")
        }
        else {
            const newProduct = {
                name: name,
                kilocalories: calories,
                proteins: proteins,
                carbohydrates: carbohydrates
            } as CreateProductDto;

            dialogProps.createProduct(newProduct as CreateProductDto);
        }
    }

    return (
        <DialogSurface>
            <DialogBody>
                <DialogTitle>Create Product</DialogTitle>
                <DialogContent>
                    <TextInput text={"Name"} onChange={handleNameChanged} value={name.toString()} required/>
                    <NumberInput text={"Calories"} onChange={handleCaloriesChanged} value={calories.toString()} contentAfter="g" />
                    <NumberInput text={"Proteins"} onChange={handleProteinsChanged} value={proteins.toString()} contentAfter="g"  />
                    <NumberInput text={"Carbohydrates"} onChange={handleCarbohydratesChanged} value={carbohydrates.toString()} contentAfter="g"  />
                </DialogContent>
                <DialogActions>
                    <Button onClick={closeDialog} appearance="secondary">Close</Button>
                    <Button onClick={editProduct} appearance="primary">Create</Button>
                </DialogActions>
            </DialogBody>
        </DialogSurface>
    )
}