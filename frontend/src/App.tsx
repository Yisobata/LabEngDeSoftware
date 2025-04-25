import './App.css'
import { BrowserRouter, Routes, Route } from "react-router-dom";
import CadastroQuadraView from './view/CadastroQuadraView';

function App() {
  return (
    <BrowserRouter>
      <Routes>
        <Route path="/cadastro-quadra" element={<CadastroQuadraView />} />
      </Routes>
    </BrowserRouter>
  )
}

export default App