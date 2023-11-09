import './productcard.style.scss';

import { useState } from 'react';

import {
    Button,
    Card,
    CardActions,
    CardContent,
    CardMedia,
    Input,
    TextField,
    Typography,
} from '@mui/material';

import { IProductsResponseDto } from '../shared/interfaces/product.interfaces';

export const ProductCard = (props: IProductsResponseDto): JSX.Element => {
    const { description, image, price, productName } = props;

    const [quantity, setQuantity] = useState(0);

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
                <Button onClick={() => alert('Add to cart in the future')}>
                    Add to Cart
                </Button>
            </CardActions>
        </Card>
    );
};
