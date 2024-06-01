
import { Tree, TreeItem, TreeItemLayout } from "@fluentui/react-components";
import { CreateRecipeDto } from "../../../Models/ActionModels/CreateRecipeDto";
import { RecipeIngredientsList } from "../../RecipePage/Components/RecipeProductsList";

interface ICreateRecipeTree {
    recipe: CreateRecipeDto;
}

export const CreateRecipeTree = (props: ICreateRecipeTree) => {
    return (
        <Tree>
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
                    <TreeItem itemType="leaf">
                        <TreeItemLayout> Total Kcal: {props.recipe.ingredients.length > 0 && props.recipe.ingredients.map(i => i.quantity * i.product.kcal / 100).reduce((sum, current) => sum + current)} Kcal.</TreeItemLayout>
                    </TreeItem>
                    <TreeItem itemType="leaf">
                        <TreeItemLayout> Total Proteins: {props.recipe.ingredients.length > 0 && props.recipe.ingredients.map(i => i.quantity * i.product.protein / 100).reduce((sum, current) => sum + current)} g.</TreeItemLayout>
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