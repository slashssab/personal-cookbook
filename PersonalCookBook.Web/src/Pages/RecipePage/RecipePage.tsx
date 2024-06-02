import { Button, Dialog, Spinner } from "@fluentui/react-components";
import { useParams } from "react-router-dom";
import { useEffect, useState } from "react";
import { useAppDispatch, useAppSelector } from "../../Store/hooks";
import { addIngredient, fetchRecipeById, selectRecipe, selectRecipeStatus } from "../../Store/Recipe/RecipeSlice";
import { Ingredient } from "../../Models/Ingredient";
import { RecipeTree } from "./Components/RecipeTree";
import { AddIngredientDialog } from "../../Shared/AddProductDialog";


export const RecipePage = () => {
    const { id } = useParams();
    const [openAddIngredientDialogState, setOpenAddIngredientDialogState] = useState<boolean>(false);
    const recipe = useAppSelector(selectRecipe);
    const recipeStatus = useAppSelector(selectRecipeStatus);
    const dispatch = useAppDispatch()

    useEffect(() => {
        if (recipeStatus === 'idle' ||  recipeStatus === 'created' || recipeStatus === 'updated') {
            const recipeId: number = +(id as string);
            dispatch(fetchRecipeById(recipeId))
        }
    }, [recipeStatus, dispatch, id])

    const openAddIngredientDialog = (open: boolean) => {
        setOpenAddIngredientDialogState(open);
    }

    const addIngredientCalled = (ingredient: Ingredient) => {
        dispatch(addIngredient(ingredient));
        setOpenAddIngredientDialogState(false);
    }

    return (
        <>
            {recipeStatus !== 'succeed'
                ? <Spinner />
                :
                <>
                    Recipe Id ({id}), Recipe Name ({recipe.name})
                    <RecipeTree recipe={recipe} />
                    <Button shape="square" onClick={() => setOpenAddIngredientDialogState(true)} appearance="primary">Add ingredient</Button>
                    <Dialog open={openAddIngredientDialogState}>
                        <AddIngredientDialog openDialog={openAddIngredientDialog} addIngredient={addIngredientCalled} />
                    </Dialog>
                </>
            }
        </>)
}