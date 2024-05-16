import './App.css';
import { RecipeListPage } from './Pages/RecipeListPage/RecipeListPage';
import { Route, Routes } from 'react-router-dom';
import { RecipePage } from './Pages/RecipePage/RecipePage';

function App() {
  return (
    <div className="App">
      <Routes>
        <Route path="/recipe/:id" element={<RecipePage />} />
        <Route path="/" element={<RecipeListPage />} />
      </Routes>
    </div>
  );
}

export default App;
