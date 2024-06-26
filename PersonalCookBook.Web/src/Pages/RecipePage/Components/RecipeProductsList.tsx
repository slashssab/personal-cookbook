import { Table, TableHeader, TableRow, TableHeaderCell, TableBody, TableCell } from "@fluentui/react-components";
import { Ingredient } from "../../../Models/Ingredient";

interface IRecipeIngredientsListProperties {
    Products: Ingredient[]
}

const productTableColumns = [
    { columnKey: "productName", label: "Product name" },
    { columnKey: "baseKcal", label: "Kcal/100g" },
    { columnKey: "quantity", label: "Quantity(g)" },
    { columnKey: "totalCalories", label: "Total calories" }
];

export const RecipeIngredientsList = (props: IRecipeIngredientsListProperties) => {
    return (
        <Table noNativeElements aria-label="Table without semantic HTML elements">
            <TableHeader>
                <TableRow>
                    {productTableColumns.map((column) => (
                        <TableHeaderCell key={column.columnKey}>
                            {column.label}
                        </TableHeaderCell>
                    ))}
                </TableRow>
            </TableHeader>
            <TableBody>
                {props.Products.map((item) => (
                    <TableRow key={item.product.id}>
                        <TableCell>
                            {item.product.name}
                        </TableCell>
                        <TableCell>
                            {item.product.kcal} kcal
                        </TableCell>
                        <TableCell>
                            {item.quantity} g
                        </TableCell>
                        <TableCell>
                            {item.totalCalories} kcal
                        </TableCell>
                    </TableRow>
                ))}
            </TableBody>
        </Table>)
}