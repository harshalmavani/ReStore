import { Container, CssBaseline, ThemeProvider, createTheme } from "@mui/material";
import Header from "./Header";
import { useEffect, useState, useCallback } from "react";
import { Outlet } from "react-router-dom";
import { ToastContainer } from "react-toastify";
import 'react-toastify/dist/ReactToastify.css';
import LoadingComponent from "./LoadingComponent";
import { useAppDispatch } from "../store/configureStore";
import { fetchBasketAsync } from "../../features/basket/basketSlice";
import { fetchCurrentUserAsync } from "../../features/account/accountSlice";

function App() {
	const dispatch = useAppDispatch();
	const [loading, setLoading] = useState(true);

	const initApp = useCallback(async () => {
		try {
			dispatch(fetchCurrentUserAsync());
			dispatch(fetchBasketAsync());
		} catch (error: any) {
			console.log(error);
		}
	}, [dispatch])

	useEffect(() => {
		initApp().then(() => setLoading(false));
	}, [initApp])

	const [darkMode, setDarkMode] = useState(false);
	const paleteeType = darkMode ? 'dark' : 'light';
	const theme = createTheme({
		palette: {
			mode: paleteeType,
			background: {
				default: paleteeType === 'light' ? '#eaeaea' : '#121212'
			}
		},
	});

	const handleThemeChange = () => {
		setDarkMode(!darkMode);
	};


	if (loading) return <LoadingComponent message="Initialising app..." />

	return (
		<>
			<ThemeProvider theme={theme}>
				<ToastContainer position="bottom-right" hideProgressBar theme="colored" />
				<CssBaseline />
				<Header darkMode={darkMode} handleThemeChange={handleThemeChange} />
				<Container>
					<Outlet />
				</Container>
			</ThemeProvider>
		</>
	);
}

export default App;