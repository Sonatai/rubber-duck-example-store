import './productcard.style.scss';

import { useEffect, useState } from 'react';

import {
    Button,
    Card,
    CardActions,
    CardContent,
    CardMedia,
    TextField,
    Typography,
} from '@mui/material';

import { IProductsResponseDto } from '../shared/interfaces/product.interfaces';
import { ICart } from '../shared/interfaces/cart.interfaces';
import axios, { AxiosResponse } from 'axios';

const updateCart = async (cart: ICart): Promise<AxiosResponse<ICart, any>> => {
    return axios.post(`http://localhost:4210/cart/update`, cart);
};

interface IProductCart {
    product: IProductsResponseDto;
    setCart: any;
    cart: ICart;
}

export const ProductCard = (props: IProductCart): JSX.Element => {
    const { product, setCart, cart } = props;
    const { description, image, price, productName, domainId } = product;

    const [quantity, setQuantity] = useState(0);

    useEffect(() => {
        const product = cart.selectedProducts.filter(
            (p) => p.domainId === domainId
        );
        if (product.length === 1) {
            setQuantity(product[0].quantity);
        }
    }, []);

    const selectProduct = async (productId: string, quantity: number) => {
        let clonedCart = structuredClone(cart);

        if (quantity === 0) {
            const products = clonedCart.selectedProducts.filter(
                (product) => product.domainId !== productId
            );

            clonedCart.selectedProducts = products;
        } else {
            const product = clonedCart.selectedProducts.filter(
                (product) => product.domainId == productId
            );

            if (product.length === 0) {
                clonedCart.selectedProducts.push({
                    domainId: productId,
                    quantity: quantity,
                });
            } else {
                product[0].quantity = quantity;
                const products = clonedCart.selectedProducts.filter(
                    (product) => product.domainId !== productId
                );
                products.push(product[0]);
                clonedCart.selectedProducts = products;
            }
        }

        setCart(clonedCart);
        await updateCart(clonedCart);
    };

    return (
        <Card variant="outlined" className="product-style">
            <CardContent>
                <Typography variant="h4" component="h2" mb="1rem">
                    {productName}
                </Typography>
                <CardMedia
                    component="img"
                    image={`data:image/png;base64,${image}`}
                />
                <Typography mt="1rem" mb="0.5rem">
                    {description}
                </Typography>
                <Typography>Price: € {price}</Typography>
            </CardContent>
            <CardActions classes={{ root: 'product-style--action' }}>
                <TextField
                    value={quantity}
                    onChange={(event: any) =>
                        setQuantity(Number(event.target.value))
                    }
                    type="number"
                    InputProps={{ inputProps: { min: 0, max: 10 } }}
                />
                <Button
                    onClick={async () =>
                        await selectProduct(domainId, quantity)
                    }
                >
                    Add to Cart
                </Button>
            </CardActions>
        </Card>
    );
};
