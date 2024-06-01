import { ChangeEvent, useCallback, useEffect, useState } from "react";
import { Ingredient } from "../../Models/Ingredient";
import { Button, Dialog, InputOnChangeData, Spinner, Title1, Toast, ToastBody, Toaster, ToastTitle, useId, useToastController } from "@fluentui/react-components";
import { AddIngredientDialog } from "../../Shared/AddProductDialog";
import { RecipeTree } from "../RecipePage/Components/RecipeTree";
import { useAppDispatch, useAppSelector } from "../../Store/hooks";
import { addIngredient, editRecipe, fetchRecipeById, selectRecipe, selectRecipeStatus, updateRecipeDescription, updateRecipeName } from "../../Store/Recipe/RecipeSlice";
import { useParams } from "react-router-dom";
import { TextInput } from "../../Shared/TextInput";
import { EditRecipeDto } from "../../Models/ActionModels/EditRecipeDto";

export const EditRecipePage = () => {
    const { id } = useParams();
    const toasterId = useId("toaster");
    const { dispatchToast } = useToastController(toasterId);
    const [openAddIngredientDialogState, setOpenAddIngredientDialogState] = useState<boolean>(false);
    const [canSubmitRecipe, setCanSubmitRecipe] = useState<boolean>(false);
    const recipe = useAppSelector(selectRecipe);
    const recipeStatus = useAppSelector(selectRecipeStatus);
    const dispatch = useAppDispatch()

    // const notifyRecipeUpdated = () =>
    //     dispatchToast(
    //         <Toast>
    //             <ToastTitle>Recipe updated!</ToastTitle>
    //             <ToastBody subtitle="Subtitle">Checkout the latest version.</ToastBody>
    //         </Toast>,
    //         { intent: "success" }
    //     );

    const recipeUpdatedCallback = useCallback(() => {
        dispatchToast(
            <Toast>
                <ToastTitle>Recipe updated!</ToastTitle>
                <ToastBody subtitle="Subtitle">Checkout the latest version.</ToastBody>
            </Toast>,
            { intent: "success" }
        );
    }, [dispatchToast])

    useEffect(() => {
        if (recipeStatus === 'idle') {
            const recipeId: number = +(id as string);
            dispatch(fetchRecipeById(recipeId))
        }
        if(recipeStatus === 'updated'){
            recipeUpdatedCallback();
        }
    }, [recipeStatus, dispatch, recipeUpdatedCallback, id])

    useEffect(() => {
        if (recipe.description
            && recipe.description !== ""
            && recipe.name !== ""
            && recipe.name !== ""
            && recipe.ingredients.length > 0
        ) {
            setCanSubmitRecipe(true);
        }
        else {
            setCanSubmitRecipe(false);
        }
    }, [recipe])


    const openAddIngredientDialog = (open: boolean) => {
        setOpenAddIngredientDialogState(open);
    }

    const addIngredientCalled = (ingredient: Ingredient) => {
        dispatch(addIngredient(ingredient));
        setOpenAddIngredientDialogState(false);
    }


    const handleNameChanged = (event: ChangeEvent<HTMLInputElement>, data: InputOnChangeData) => {
        dispatch(updateRecipeName(data.value));
    }

    const handleDescriptionChanged = (event: ChangeEvent<HTMLInputElement>, data: InputOnChangeData) => {
        dispatch(updateRecipeDescription(data.value));
    }

    const updateRecipeClicked = () => {
        const request = {
            id: recipe.id,
            name: recipe.name,
            description: recipe.description,
            ingredients: recipe.ingredients,
            steps: recipe.steps
        } as EditRecipeDto;
        dispatch(editRecipe(request));
    }

    return (
        <>
            {recipeStatus === 'updating'
                ? <Spinner />
                : <>
                    <Title1>Edit Recipe.</Title1>
                    <TextInput text="Name" value={recipe.name} onChange={handleNameChanged} />
                    <TextInput text="Description" value={recipe.description} onChange={handleDescriptionChanged} />
                    <RecipeTree recipe={recipe} />
                    <Button onClick={() => setOpenAddIngredientDialogState(true)} appearance="primary">Add ingredient</Button>
                    <Button onClick={() => updateRecipeClicked()} appearance="primary" disabled={!canSubmitRecipe}>Submit</Button>
                    <Toaster toasterId={toasterId} />
                    <Dialog open={openAddIngredientDialogState}>
                        <AddIngredientDialog openDialog={openAddIngredientDialog} addIngredient={addIngredientCalled} />
                    </Dialog>
                </>
            }
        </>

    )
}