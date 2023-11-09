import { useContext, useEffect, useState } from 'react';
import { Navigate } from 'react-router-dom';

import { Button, Typography } from '@mui/material';
import Grid from '@mui/material/Unstable_Grid2';

import { ProductCard } from '../components/ProductCard';
import { useGetAllProducts } from '../Hooks/useGetAllProducts';
import { RubberDuckContainer } from '../shared';
import { UserContext } from '../userContext/userContext';
import { UserContextType } from '../userContext/userContext.types';
import { ICart } from '../shared/interfaces/cart.interfaces';
import axios, { AxiosResponse } from 'axios';
import './products.styles.scss';

const createCart = async (
    userId: string
): Promise<AxiosResponse<ICart, any>> => {
    return axios.post('http://localhost:4210/cart', {
        userId: userId,
    });
};

const getCartByUserId = async (
    userId: string
): Promise<AxiosResponse<ICart, any>> => {
    return axios.get(`http://localhost:4210/cart/user/${userId}`);
};

export const ProductsPage = (): JSX.Element => {
    const { data: products } = useGetAllProducts();

    const { user } = useContext(UserContext) as UserContextType;

    const [cart, setCart] = useState<ICart>({} as ICart);

    useEffect(() => {
        const initiateCart = async () => {
            if (user?.userId !== undefined && user.userId !== null) {
                getCartByUserId(user.userId)
                    .then((response) => {
                        if (response.status === 200) {
                            setCart(response.data);
                        } else if (response.status === 204) {
                            createCart(user.userId)
                                .then((response) => {
                                    setCart(response.data);
                                })
                                .catch(() => alert('Something went wrong :('));
                        }
                    })
                    .catch(() => alert('Something went wrong :('));
            }
        };

        initiateCart();
    }, [user?.userId]);

    useEffect(() => {
        console.log('CART');
        console.log(cart);
    }, [cart]);

    if (user?.userId === undefined || user?.userId === null) {
        return <Navigate to="/login" replace={true} />;
    }

    return (
        <RubberDuckContainer>
            <Typography variant="h1" component="h1" mb="2rem">
                Awesome Rubber Duck Store
            </Typography>
            <Button
                variant="outlined"
                onClick={() => alert(JSON.stringify(cart, null, 2))}
                className="cart-button"
            >
                Check Cart
            </Button>
            <Grid container spacing={1}>
                {products?.map((product) => (
                    <Grid key={product.domainId} xs={4}>
                        <ProductCard
                            product={{
                                description: product.description,
                                domainId: product.domainId,
                                productName: product.productName,
                                price: product.price,
                                image: product.image,
                            }}
                            cart={cart}
                            setCart={setCart}
                        />
                    </Grid>
                ))}
            </Grid>
        </RubberDuckContainer>
    );
};
