import { Table, TableHeader, TableRow, TableHeaderCell, TableBody, TableCell, TableCellLayout, Avatar } from "@fluentui/react-components";
import { Link } from "react-router-dom";
import { RecipeHeader } from "../../../Models/RecipeHeader"

interface IRecipeHeadersList {
    recipeHeaders: RecipeHeader[];
}

const columns = [
    { columnKey: "recipeName", label: "Recipe name" },
    { columnKey: "author", label: "Author" },
    { columnKey: "totalCalories", label: "Total calories" },
    { columnKey: "time", label: "Time" },
];

export const RecipeHeadersList = (props: IRecipeHeadersList) => {
    return (
        <Table noNativeElements aria-label="Table without semantic HTML elements">
            <TableHeader>
                <TableRow>
                    {columns.map((column) => (
                        <TableHeaderCell key={column.columnKey}>
                            {column.label}
                        </TableHeaderCell>
                    ))}
                </TableRow>
            </TableHeader>
            <TableBody>
                {props.recipeHeaders.map((item) => (
                    <TableRow key={item.id}>
                        <TableCell>
                            {item.recipeName}
                        </TableCell>
                        <TableCell>
                            <TableCellLayout
                                media={
                                    <Avatar
                                        aria-label={item.author}
                                        name={item.author}
                                    // badge={{
                                    //   status: item.author.status as PresenceBadgeStatus,
                                    // }}
                                    />
                                }
                            >
                                {item.author}
                            </TableCellLayout>
                        </TableCell>
                        <TableCell>{item.totalCalories} Kcal</TableCell>
                        <TableCell>
                            <Link to={`/recipe/${item.id}`}>
                                Try it!
                            </Link>
                        </TableCell>
                    </TableRow>
                ))}
            </TableBody>
        </Table>
    )
}