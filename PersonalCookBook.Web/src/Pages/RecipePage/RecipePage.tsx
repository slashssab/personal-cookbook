import { Button, Dialog, Tree, TreeItem, TreeItemLayout } from "@fluentui/react-components";
import { useParams } from "react-router-dom";
import { AddProductDialog } from "./Components/AddProductDialog";
import { useState } from "react";
import { Product } from "../../Models/Product";
import { useAppDispatch, useAppSelector } from "../../Store/hooks";
import { addProduct, selectRecipe } from "../../Store/Recipe/RecipeSlice";


export const RecipePage = () => {
    const { id } = useParams();
    const [openAddIngredientDialogState, setOpenAddIngredientDialogState] = useState<boolean>(false);
    const recipe = useAppSelector(selectRecipe);
    const dispatch = useAppDispatch()

    const openAddIngredientDialog = (open: boolean) => {
        setOpenAddIngredientDialogState(open);
    }

    const addIngredient = (ingredient: Product) => {
        dispatch(addProduct(ingredient))
        setOpenAddIngredientDialogState(false);
    }

    return (
        <>
            Recipe Works! {id}
            <Tree>
                <TreeItem itemType="branch">
                    <TreeItemLayout>Ingredients:</TreeItemLayout>
                    <Tree>
                        {recipe.Ingredients?.map(ingredient => (
                            //Add appropriate key.
                            <TreeItem itemType="leaf" key={ingredient.Name}>
                                <TreeItemLayout>{ingredient.Name}</TreeItemLayout>
                            </TreeItem>))}
                    </Tree>
                </TreeItem>
            </Tree>
            <Button onClick={() => setOpenAddIngredientDialogState(true)} appearance="primary">Add ingredient</Button>
            <Dialog open={openAddIngredientDialogState}>
                <AddProductDialog openDialog={openAddIngredientDialog} addProduct={addIngredient} />
            </Dialog>
        </>)
}