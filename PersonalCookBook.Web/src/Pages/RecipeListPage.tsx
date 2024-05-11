import {
  Spinner
} from "@fluentui/react-components";
import { useEffect } from "react";
import { useSelector } from "react-redux";
import { fetchRecipeHeaders, selectRecipeHeaders, selectRecipeHeadersStatus } from "../Store/RecipesList/RecipeHeadersListSlice";
import { useAppDispatch } from "../Store/hooks";
import { RecipeHeadersList } from "./RecipePage/Components/RecipeHeadersList";

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
      {recipeHeaders.length === 0
        ? <Spinner />
        : <RecipeHeadersList recipeHeaders={recipeHeaders} />
      }
    </>
  );
};