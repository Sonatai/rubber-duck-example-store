import Grid from '@mui/material/Unstable_Grid2';

import { ProductCard } from '../components/ProductCard';
import { useGetAllProducts } from '../Hooks/useGetAllProducts';
import { RubberDuckContainer } from '../shared';
import { Typography } from '@mui/material';

export const ProductsPage = (): JSX.Element => {
    const { data } = useGetAllProducts();

    return (
        <RubberDuckContainer>
            <Typography variant="h1" component="h1" mb="2rem">
                Awesome Rubber Duck Store
            </Typography>
            <Grid container spacing={1}>
                {data?.map((product) => (
                    <Grid key={product.domainId} xs={4}>
                        <ProductCard
                            description={product.description}
                            domainId={product.domainId}
                            productName={product.productName}
                            price={product.price}
                            image={product.image}
                        />
                    </Grid>
                ))}
            </Grid>
        </RubberDuckContainer>
    );
};
