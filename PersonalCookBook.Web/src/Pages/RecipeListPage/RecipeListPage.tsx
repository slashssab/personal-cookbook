import { useEffect } from "react";
import { useSelector } from "react-redux";
import { fetchRecipeHeaders, selectRecipeHeaders, selectRecipeHeadersStatus } from "../../Store/RecipesList/RecipeHeadersListSlice";
import { useAppDispatch } from "../../Store/hooks";
import { RecipeHeadersList } from "./Components/RecipeHeadersList";
import { LazyContentLoader } from "../../Shared/LazyContentLoader";
import { Link } from "react-router-dom";
import { Button } from "@fluentui/react-components";

export const RecipeListPage = () => {
  const dispatch = useAppDispatch()
  const recipeHeaders = useSelector(selectRecipeHeaders)
  const recipeHeadersStatus = useSelector(selectRecipeHeadersStatus)
  useEffect(() => {
    if (recipeHeadersStatus === 'idle') {
      dispatch(fetchRecipeHeaders())
    }
  }, [recipeHeadersStatus, dispatch])

  return (
    <>
      <LazyContentLoader status={recipeHeadersStatus}>
        <RecipeHeadersList recipeHeaders={recipeHeaders} />
      </LazyContentLoader>

      <Link to={`/recipe/create`}>
        <Button shape="square" appearance="primary">New recipe</Button>
      </Link>
    </>

  );
};