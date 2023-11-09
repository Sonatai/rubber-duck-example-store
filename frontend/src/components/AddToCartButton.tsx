import { Button } from '@mui/material';
import React from 'react';

export const AddToCartButton = (): JSX.Element => {
    return (
        <Button onClick={() => alert('Add to cart in the future')}>
            Add to Cart
        </Button>
    );
};
