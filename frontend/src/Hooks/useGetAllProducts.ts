import axios from 'axios';
import { useQuery } from 'react-query';

interface IProductsResponseDto {
	domainId: string;
	productName: string;
	description: string;
	price: number;
	image: string;
}

const getAllProducts = async (): Promise<IProductsResponseDto[]> => {
	const data = await axios('https://localhost:44342/products');

	return data.data.products;
};

export const useGetAllProducts = () => {
	return useQuery<IProductsResponseDto[]>(
		'AllProducts',
		async () => await getAllProducts(),
		{
			cacheTime: 60 * 60 * 24,
			staleTime: 60 * 60 * 24,
		}
	);
};
