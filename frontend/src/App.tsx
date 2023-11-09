import { Route, Routes } from 'react-router-dom';

import { ProductsPage } from './pages/ProductsPage';
import { LoginPage } from './pages/LoginPage';
import { UserProvider } from './userContext/userContext';

export const App = (): JSX.Element => {
    return (
        <UserProvider>
            <main>
                <Routes>
                    <Route path="/login" element={<LoginPage />} />
                    <Route path="/" element={<ProductsPage />} />
                </Routes>
            </main>
        </UserProvider>
    );
};

export default App;
