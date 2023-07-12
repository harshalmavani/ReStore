import { Button, Container, Divider, Paper, Typography } from "@mui/material";
import { Link, useNavigate } from "react-router-dom";

export default function NotFound() {
	const navigate = useNavigate();
	return (
		<Container component={Paper} sx={{ height: 400 }}>
			<Typography gutterBottom variant="h3">Oops - we could not find what you are looking for</Typography>
			<Divider />
			<Button fullWidth component={Link} to='/catalog'>Go back to the store</Button>
		</Container>
	)
}
