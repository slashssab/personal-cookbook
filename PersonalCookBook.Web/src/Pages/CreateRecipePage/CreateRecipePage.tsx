import { ChangeEvent, useEffect, useState } from "react";
import { Ingredient } from "../../Models/Ingredient";
import { Button, Dialog, InputOnChangeData } from "@fluentui/react-components";
import { AddIngredientDialog } from "../../Shared/AddProductDialog";
import { TextInput } from "../../Shared/TextInput";
import { CreateRecipeDto } from "../../Models/ActionModels/CreateRecipeDto";
import { createRecipe, selectRecipeId, selectRecipeStatus } from "../../Store/Recipe/RecipeSlice";
import { useAppDispatch, useAppSelector } from "../../Store/hooks";
import { useNavigate } from "react-router-dom";
import { Title1 } from "@fluentui/react-components";
import { CreateRecipeTree } from "./Components/CreateRecipeTree";

export const CreateRecipePage = () => {
    const [openAddIngredientDialogState, setOpenAddIngredientDialogState] = useState<boolean>(false);
    const [canSubmitRecipe, setCanSubmitRecipe] = useState<boolean>(false);
    const recipeStatus = useAppSelector(selectRecipeStatus);
    const newRecipeId = useAppSelector(selectRecipeId);
    const dispatch = useAppDispatch()
    const navigate = useNavigate();
    const [recipe, updateRecipe] = useState<CreateRecipeDto>({
        name: '',
        description: '',
        ingredients: [],
        steps: []
    } as CreateRecipeDto);

    useEffect(() => {
        if (recipeStatus === 'created') {
            navigate(`../recipe/${newRecipeId}`, { replace: true });
        }
    }, [recipeStatus, dispatch, navigate, newRecipeId])

    const openAddIngredientDialog = (open: boolean) => {
        setOpenAddIngredientDialogState(open);
    }

    const addIngredient = (ingredient: Ingredient) => {
        updateRecipe({...recipe, ingredients: [...recipe.ingredients, ingredient]})
        setOpenAddIngredientDialogState(false);
        setCanSubmitRecipe(true);
    }

    const createRecipeClicked = () => {
        dispatch(createRecipe(recipe));
    }

    const handleNameChanged = (event: ChangeEvent<HTMLInputElement>, data: InputOnChangeData) => {
        updateRecipe({...recipe, name: data.value})
    }
    
    const handleDescriptionChanged = (event: ChangeEvent<HTMLInputElement>, data: InputOnChangeData) => {
        updateRecipe({...recipe, description: data.value})
    }

    return (
        <>
            <Title1>New Recipe.</Title1>
            <TextInput text="Name" onChange={handleNameChanged} />
            <TextInput text="Description" onChange={handleDescriptionChanged} />
            <CreateRecipeTree recipe={recipe} />
            <Button onClick={() => setOpenAddIngredientDialogState(true)} appearance="primary">Add ingredient</Button>
            <Button onClick={() => createRecipeClicked()} appearance="primary" disabled={!canSubmitRecipe}>Submit</Button>
            <Dialog open={openAddIngredientDialogState}>
                <AddIngredientDialog openDialog={openAddIngredientDialog} addIngredient={addIngredient} />
            </Dialog>
        </>)
}