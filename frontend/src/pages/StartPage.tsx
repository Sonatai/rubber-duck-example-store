import { useGetAllProducts } from '../Hooks/useGetAllProducts';

export const StartPage = () => {
	const { data } = useGetAllProducts();

	console.log('DATA', data);

	return <div>StartPage</div>;
};
