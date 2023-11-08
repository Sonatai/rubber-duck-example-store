import axios from 'axios';
import { useQuery } from 'react-query';

import { IProductsResponseDto } from '../shared/interfaces/product.interfaces';

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
