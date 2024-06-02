import './App.css';
import { RecipeListPage } from './Pages/RecipeListPage/RecipeListPage';
import { Route, Routes } from 'react-router-dom';
import { RecipePage } from './Pages/RecipePage/RecipePage';
import { ProductsListPage } from './Pages/ProductsListPage/ProductsListPage';
import { CreateRecipePage } from './Pages/CreateRecipePage/CreateRecipePage';
import { EditRecipePage } from './Pages/EditRecipePage/EditRecipePage';
import { NavigationBar } from './Shared/NavigationBar';

function App() {
  return (
    <div className="App">
      <NavigationBar />
      <Routes>
        <Route path="/recipe/:id" element={<RecipePage />} />
        <Route path="/" element={<RecipeListPage />} />
        <Route path="/products" element={<ProductsListPage />} />
        <Route path="/recipe/create" element={<CreateRecipePage />} />
        <Route path="/recipe/:id/edit" element={<EditRecipePage />} />
        <Route path="*" element={<div>404 not found 💔</div>} />
      </Routes>
    </div>
  );
}

export default App;
