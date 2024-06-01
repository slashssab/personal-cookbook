import { Table, TableHeader, TableRow, TableHeaderCell, TableBody, TableCell, TableCellLayout, Avatar, Button } from "@fluentui/react-components";
import { Link } from "react-router-dom";
import { RecipeHeader } from "../../../Models/RecipeHeader";
import { Text } from "@fluentui/react-components";
import {Edit12Regular } from "@fluentui/react-icons";

interface IRecipeHeadersList {
    recipeHeaders: RecipeHeader[];
}

const columns = [
    { columnKey: "recipeName", label: "Recipe name" },
    { columnKey: "author", label: "Author" },
    { columnKey: "totalCalories", label: "Total calories" },
    { columnKey: "actions", label: "Actions" },
];

export const RecipeHeadersList = (props: IRecipeHeadersList) => {
    return (
        <>
            {props.recipeHeaders.length === 0
                ? <Text>No content to be displayed.</Text>
                : <Table noNativeElements aria-label="Table without semantic HTML elements">
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
                                        <Button shape="square" appearance="primary">Try it!</Button>
                                    </Link>
                                    <Link to={`/recipe/${item.id}/edit`}>
                                        <Button shape="square" appearance="outline" icon={<Edit12Regular />} iconPosition={'after'}>Edit</Button>
                                    </Link>
                                </TableCell>
                            </TableRow>
                        ))}
                    </TableBody>
                </Table>}
        </>
    )
}