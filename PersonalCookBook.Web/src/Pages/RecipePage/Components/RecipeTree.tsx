import { Tree, TreeItem, TreeItemLayout } from "@fluentui/react-components";
import { Recipe } from "../../../Models/Recipe";
import { RecipeIngredientsList } from "./RecipeProductsList";

interface IRecipeTree {
    recipe: Recipe;
}

export const RecipeTree = (props: IRecipeTree) => {
    return (
        <Tree aria-label="RecipeTree">
            <TreeItem itemType="branch">
                <TreeItemLayout>Ingredients:</TreeItemLayout>
                <Tree>
                    {props.recipe.ingredients.length > 0 && <RecipeIngredientsList Products={props.recipe.ingredients} />}

                </Tree>
            </TreeItem>
            <TreeItem itemType="branch">
                <TreeItemLayout>Recipe:</TreeItemLayout>
                <Tree>
                    Recipe description.
                    {props.recipe.description}
                    <TreeItem itemType="leaf">
                        <TreeItemLayout> Total Kcal: {props.recipe.ingredients.length > 0 && props.recipe.totalCalories} Kcal.</TreeItemLayout>
                    </TreeItem>
                    <TreeItem itemType="leaf">
                        <TreeItemLayout> Total Proteins: {props.recipe.ingredients.length > 0 && props.recipe.totalProteins} g.</TreeItemLayout>
                    </TreeItem>
                </Tree>
            </TreeItem>
            <TreeItem itemType="branch">
                <TreeItemLayout>Steps:</TreeItemLayout>
                <Tree>
                    {props.recipe.steps.length > 0 && props.recipe.steps.map(step => <TreeItem itemType="leaf">
                        <TreeItemLayout>
                            {step.content}
                        </TreeItemLayout>
                    </TreeItem>)}
                </Tree>
            </TreeItem>
        </Tree>
    );
}