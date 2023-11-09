import { Route, Routes } from 'react-router-dom';

import { ProductsPage } from './pages/ProductsPage';
import { LoginPage } from './pages/LoginPage';

export const App = (): JSX.Element => {
    return (
        <main>
            <Routes>
                <Route path="/" element={<LoginPage />} />
                <Route path="/products" element={<ProductsPage />} />
            </Routes>
        </main>
    );
};

export default App;
