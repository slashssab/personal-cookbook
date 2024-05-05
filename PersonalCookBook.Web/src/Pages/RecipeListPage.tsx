import {
  EditRegular,
  OpenRegular,
  PeopleRegular,
} from "@fluentui/react-icons";
import {
  PresenceBadgeStatus,
  Avatar,
  TableBody,
  TableCell,
  TableRow,
  Table,
  TableHeader,
  TableHeaderCell,
  TableCellLayout
} from "@fluentui/react-components";
import { Link } from "react-router-dom";

// const items = [
//   {
//     file: { label: "Meeting notes", icon: <DocumentRegular /> },
//     author: { label: "Max Mustermann", status: "available" },
//     lastUpdated: { label: "7h ago", timestamp: 1 },
//     lastUpdate: {
//       label: "You edited this",
//       icon: <EditRegular />,
//     },
//   },
//   {
//     file: { label: "Thursday presentation", icon: <FolderRegular /> },
//     author: { label: "Erika Mustermann", status: "busy" },
//     lastUpdated: { label: "Yesterday at 1:45 PM", timestamp: 2 },
//     lastUpdate: {
//       label: "You recently opened this",
//       icon: <OpenRegular />,
//     },
//   },
//   {
//     file: { label: "Training recording", icon: <VideoRegular /> },
//     author: { label: "John Doe", status: "away" },
//     lastUpdated: { label: "Yesterday at 1:45 PM", timestamp: 2 },
//     lastUpdate: {
//       label: "You recently opened this",
//       icon: <OpenRegular />,
//     },
//   },
//   {
//     file: { label: "Purchase order", icon: <DocumentPdfRegular /> },
//     author: { label: "Jane Doe", status: "offline" },
//     lastUpdated: { label: "Tue at 9:30 AM", timestamp: 3 },
//     lastUpdate: {
//       label: "You shared this in a Teams chat",
//       icon: <PeopleRegular />,
//     },
//   },
// ];

// const columns = [
//   { columnKey: "file", label: "File" },
//   { columnKey: "author", label: "Author" },
//   { columnKey: "lastUpdated", label: "Last updated" },
//   { columnKey: "lastUpdate", label: "Last update" },
// ];

const items = [
  {
    id: 1,
    recipeName: "Recipe name 1",
    author: { label: "Max Mustermann", status: "available" },
    lastUpdated: { label: "7h ago", timestamp: 1 },
    lastUpdate: {
      label: "You edited this",
      icon: <EditRegular />,
    },
  },
  {
    id: 2,
    recipeName: "Recipe name 2",
    author: { label: "Erika Mustermann", status: "busy" },
    lastUpdated: { label: "Yesterday at 1:45 PM", timestamp: 2 },
    lastUpdate: {
      label: "You recently opened this",
      icon: <OpenRegular />,
    },
  },
  {
    id: 3,
    recipeName: "Recipe name 3",
    author: { label: "John Doe", status: "away" },
    lastUpdated: { label: "Yesterday at 1:45 PM", timestamp: 2 },
    lastUpdate: {
      label: "You recently opened this",
      icon: <OpenRegular />,
    },
  },
  {
    id: 4,
    recipeName: "Recipe name 4",
    author: { label: "Jane Doe", status: "offline" },
    lastUpdated: { label: "Tue at 9:30 AM", timestamp: 3 },
    lastUpdate: {
      label: "You shared this in a Teams chat",
      icon: <PeopleRegular />,
    },
  },
];

const columns = [
  { columnKey: "recipeName", label: "Recipe name" },
  { columnKey: "author", label: "Author" },
  { columnKey: "totalCalories", label: "Total calories" },
  { columnKey: "time", label: "Time" },
];

export const RecipeListPage = () => {
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
        {items.map((item) => (
          <TableRow key={item.id}>
            <TableCell>
              {item.recipeName}
            </TableCell>
            <TableCell>
              <TableCellLayout
                media={
                  <Avatar
                    aria-label={item.author.label}
                    name={item.author.label}
                    badge={{
                      status: item.author.status as PresenceBadgeStatus,
                    }}
                  />
                }
              >
                {item.author.label}
              </TableCellLayout>
            </TableCell>
            <TableCell>{item.lastUpdated.label}</TableCell>
            <TableCell>
              <Link to={`/recipe/${item.id}`}>
                Try it!
              </Link>
            </TableCell>
          </TableRow>
        ))}
      </TableBody>
    </Table>
  );
};