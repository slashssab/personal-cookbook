import './App.css';
import { RecipeListPage } from './Pages/RecipeListPage/RecipeListPage';
import { Route, Routes } from 'react-router-dom';
import { RecipePage } from './Pages/RecipePage/RecipePage';
import { ProductsListPage } from './Pages/ProductsListPage/ProductsListPage';
import { CreateRecipePage } from './Pages/CreateRecipePage/CreateRecipePage';
import { EditRecipePage } from './Pages/EditRecipePage/EditRecipePage';

function App() {
  return (
    <div className="App">
      <Routes>
        <Route path="/recipe/:id" element={<RecipePage />} />
        <Route path="/" element={<RecipeListPage />} />
        <Route path="/products" element={<ProductsListPage />} />
        <Route path="/recipe/create" element={<CreateRecipePage />} />
        <Route path="/recipe/:id/edit" element={<EditRecipePage />} />
      </Routes>
    </div>
  );
}

export default App;
