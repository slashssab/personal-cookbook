import { Table, TableHeader, TableRow, TableHeaderCell, TableBody, TableCell, Button } from "@fluentui/react-components";
import { Product } from "../../../Models/Product";

interface IProductsList {
    products: Product[];
    editProduct(product: Product): void;
}

const columns = [
    { columnKey: "productName", label: "Product name" },
    { columnKey: "kcal", label: "Kcal" },
    { columnKey: "proteins", label: "Proteins" },
    { columnKey: "carbohydrates", label: "Carbohydrates" },
    { columnKey: "actions", label: "Actions" },
];

export const ProductsList = (props: IProductsList) => {
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
                {props.products.map((item) => (
                    <TableRow key={item.id}>
                        <TableCell>{item.name} </TableCell>
                        <TableCell>{item.kcal}</TableCell>
                        <TableCell>{item.protein} g</TableCell>
                        <TableCell>{item.carbs} g</TableCell>
                        <TableCell>
                            <Button onClick={() => props.editProduct(item)} appearance="primary">Edit</Button>
                        </TableCell>
                    </TableRow>
                ))}
            </TableBody>
        </Table>
    )
}