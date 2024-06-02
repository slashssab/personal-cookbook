import { makeStyles, shorthands, Title1, Title2 } from "@fluentui/react-components";
import { Link } from "react-router-dom";
import { NavigationRegular } from '@fluentui/react-icons';

const useStyles = makeStyles({
  root: {
    backgroundColor: "#479ef5",
    color: "#ebf3fc",
    display: "flex",
    textAlign: "center",
    justifyContent: "space-between",
    alignItems: "stretch",
    ...shorthands.gap("2rem"),
    ...shorthands.paddingInline("1rem"),
    ...shorthands.paddingBlock("0.5rem")
  },
  pageTitle: {
    fontSize: "2rem",
    color: "#ebf3fc",
    ...shorthands.textDecoration("none"),
    display: "flex",
    textAlign: "center",
    alignItems: "center",
  }
});

export const NavigationBar = () => {
  const styles = useStyles();
  return (
    <nav className={styles.root}>
      <Link className={styles.pageTitle} to="/" >
        <Title1>
          Personal Cookbook
        </Title1>
      </Link>
      <Link className={styles.pageTitle} to="/products" >
        <NavigationRegular />
      </Link>
    </nav>
  )
}