import axios from 'axios';
import { useQuery } from 'react-query';

import { IProductsResponseDto } from '../shared/interfaces/product.interfaces';
import { ICart } from '../shared/interfaces/cart.interfaces';

const getCartByUserId = async (userId: string): Promise<ICart> => {
    const data = await axios.get(`http://localhost:4210/cart/user/${userId}`);
    console.log(data);
    return data.data;
};

interface IGetCartByUserId {
    userId: string;
}

export const useGetCartByUserId = (props: IGetCartByUserId) => {
    const { userId } = props;

    return useQuery<ICart>(userId, async () => await getCartByUserId(userId), {
        cacheTime: 60 * 60 * 24,
        staleTime: 60 * 60 * 24,
    });
};
