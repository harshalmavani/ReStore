import { Container, CssBaseline, ThemeProvider, createTheme } from "@mui/material";
import Header from "./Header";
import { useState } from "react";
import { Outlet } from "react-router-dom";

function App() {
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

  return (
    <>
      <ThemeProvider theme={theme}>
        <CssBaseline />
        <Header darkMode={darkMode} handleThemeChange={handleThemeChange}/>
        <Container>
          <Outlet/>
        </Container>
      </ThemeProvider>
    </>
  );
}

export default App;