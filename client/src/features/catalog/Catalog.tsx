import { useEffect } from "react";
import ProductList from "./ProductList";
import LoadingComponent from "../../app/layout/LoadingComponent";
import { useAppDispatch, useAppSelector } from "../../app/store/configureStore";
import { fetchProductsAsync, fetchFiltersAsync, productSelectors, setProductParams } from "./catalogSlice";
import { Box, Grid, Pagination, Paper, Typography } from "@mui/material";
import ProductSearch from "./ProductSearch";
import RadioButtonGroup from "../../app/components/RadioButtonGroup";
import CheckBoxButtons from "../../app/components/CheckBoxButtons";

const sortOptions = [
	{ value: 'name', label: 'Alphabetical' },
	{ value: 'priceDesc', label: 'Price - High to low' },
	{ value: 'price', label: 'Price - Low to high' },
]

export default function Catalog() {
	const products = useAppSelector(productSelectors.selectAll);
	const { productsLoaded, filtersLoaded, status, brands, types, productParams } = useAppSelector(state => state.catalog)
	const dispatch = useAppDispatch();

	useEffect(() => {
		if (!productsLoaded) dispatch(fetchProductsAsync());
	}, [dispatch, productsLoaded]);

	useEffect(() => {
		if (!filtersLoaded) dispatch(fetchFiltersAsync());
	}, [dispatch, filtersLoaded]);

	if (status.includes('pending')) return <LoadingComponent message='Loading products...' />

	return (
		<>
			<Grid container spacing={4}>
				<Grid item xs={3}>
					<Paper sx={{ mb: 2 }}>
						<ProductSearch />
					</Paper>
					<Paper sx={{ mb: 2, p: 2 }}>
						<RadioButtonGroup
							options={sortOptions}
							selectedValue={productParams.orderBy}
							onChange={(event) => dispatch(setProductParams({ orderBy: event.target.value }))}
						/>
					</Paper>
					<Paper sx={{ mb: 2, p: 2 }}>
						<CheckBoxButtons
							items={brands}
							checked={productParams.brands}
							onChange={(items: string[]) => dispatch(setProductParams({ brands: items }))}
						/>
					</Paper>
					<Paper sx={{ mb: 2, p: 2 }}>
						<CheckBoxButtons
							items={types}
							checked={productParams.types}
							onChange={(items: string[]) => dispatch(setProductParams({ types: items }))}
						/>
					</Paper>
				</Grid>
				<Grid item xs={9}>
					<ProductList products={products} />
				</Grid>
				<Grid item xs={3} />
				<Grid item xs={9}>
					<Box display='flex' justifyContent='space-between' alignItems='center'>
						<Typography>
							Displaying 1-6 of 20 items
						</Typography>
						<Pagination color="secondary" size="large" count={10} page={2} />
					</Box>
				</Grid>
			</Grid>
		</>
	);
}
