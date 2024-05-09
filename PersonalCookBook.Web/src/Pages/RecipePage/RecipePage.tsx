import { Button, Dialog, Tree, TreeItem, TreeItemLayout } from "@fluentui/react-components";
import { useParams } from "react-router-dom";
import { AddIngredientDialog } from "./Components/AddProductDialog";
import { useState } from "react";
import { useAppDispatch, useAppSelector } from "../../Store/hooks";
import { addProduct, selectRecipe } from "../../Store/Recipe/RecipeSlice";
import { Ingredient } from "../../Models/Ingredient";
import { RecipeIngredientsList } from "./Components/RecipeProductsList";


export const RecipePage = () => {
    const { id } = useParams();
    const [openAddIngredientDialogState, setOpenAddIngredientDialogState] = useState<boolean>(false);
    const recipe = useAppSelector(selectRecipe);
    const dispatch = useAppDispatch()

    const openAddIngredientDialog = (open: boolean) => {
        setOpenAddIngredientDialogState(open);
    }

    const addIngredient = (ingredient: Ingredient) => {
        dispatch(addProduct(ingredient))
        setOpenAddIngredientDialogState(false);
    }

    return (
        <>
            Recipe Id ({id})
            <Tree>
                <TreeItem itemType="branch">
                    <TreeItemLayout>Ingredients:</TreeItemLayout>
                    <Tree>
                        {recipe.Ingredients.length > 0 && <RecipeIngredientsList Products={recipe.Ingredients} />}
                        {/* {recipe.Ingredients?.map(ingredient => (
                            //Add appropriate key.
                            <TreeItem itemType="leaf" key={ingredient.Product.Id}>
                                <TreeItemLayout>{ingredient.Product.Name} {ingredient.Quantity} {ingredient.Product.Kcal}</TreeItemLayout>
                            </TreeItem>))} */}
                    </Tree>
                </TreeItem>
                <TreeItem itemType="branch">
                    <TreeItemLayout>Recipe:</TreeItemLayout>
                    <Tree>
                        Recipe description.
                        <TreeItem itemType="leaf">
                            <TreeItemLayout> Total Kcal: {recipe.Ingredients.length > 0 && recipe.Ingredients.map(i => i.Quantity * i.Product.Kcal / 100).reduce((sum, current) => sum + current)} Kcal.</TreeItemLayout>
                        </TreeItem>
                        <TreeItem itemType="leaf">
                            <TreeItemLayout> Total Protein: {recipe.Ingredients.length > 0 && recipe.Ingredients.map(i => i.Quantity * i.Product.Protein / 100).reduce((sum, current) => sum + current)} Kcal.</TreeItemLayout>
                        </TreeItem>
                    </Tree>
                </TreeItem>
            </Tree>
            <Button onClick={() => setOpenAddIngredientDialogState(true)} appearance="primary">Add ingredient</Button>
            <Dialog open={openAddIngredientDialogState}>
                <AddIngredientDialog openDialog={openAddIngredientDialog} addIngredient={addIngredient} />
            </Dialog>
        </>)
}