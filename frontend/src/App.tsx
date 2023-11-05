import { Route, Routes } from 'react-router-dom';

import { StartPage } from './pages/StartPage';

export const App = (): JSX.Element => {
	return (
		<main>
			<Routes>
				<Route path='/' element={<StartPage />} />
			</Routes>
		</main>
	);
};

export default App;
