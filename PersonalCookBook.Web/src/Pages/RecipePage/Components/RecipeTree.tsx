import { Tree, TreeItem, TreeItemLayout } from "@fluentui/react-components";
import { Recipe } from "../../../Models/Recipe";
import { RecipeIngredientsList } from "./RecipeProductsList";
import { CreateRecipeDto } from "../../../Models/ActionModels/CreateRecipeDto";

interface IRecipeTree {
    recipe: Recipe | CreateRecipeDto;
}

export const RecipeTree = (props: IRecipeTree) => {
    return (
        <Tree>
            <TreeItem itemType="branch">
                <TreeItemLayout>Ingredients:</TreeItemLayout>
                <Tree>
                    {props.recipe.ingredients.length > 0 && <RecipeIngredientsList Products={props.recipe.ingredients} />}
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
                        <TreeItemLayout> Total Kcal: {props.recipe.ingredients.length > 0 && props.recipe.ingredients.map(i => i.quantity * i.product.kcal / 100).reduce((sum, current) => sum + current)} Kcal.</TreeItemLayout>
                    </TreeItem>
                    <TreeItem itemType="leaf">
                        <TreeItemLayout> Total Protein: {props.recipe.ingredients.length > 0 && props.recipe.ingredients.map(i => i.quantity * i.product.protein / 100).reduce((sum, current) => sum + current)} Kcal.</TreeItemLayout>
                    </TreeItem>
                </Tree>
            </TreeItem>
        </Tree>
    );
}