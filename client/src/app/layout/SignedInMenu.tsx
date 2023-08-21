import { Button, Fade, Menu, MenuItem } from "@mui/material";
import React, { useState } from "react";
import { useAppDispatch, useAppSelector } from "../store/configureStore";
import { signOut } from "../../features/account/accountSlice";

export default function SignedInMenu() {
	const { user } = useAppSelector(state => state.account);
	const dispatch = useAppDispatch();
	const [anchorEl, setAnchorEl] = useState<null | HTMLElement>(null);
	const open = Boolean(anchorEl);
	const handleClick = (event: any) => {
		setAnchorEl(event.currentTarget);
	};
	const handleClose = () => {
		setAnchorEl(null);
	};

	return (
		<div>
			<Button
				color="inherit"
				onClick={handleClick}
				sx={{ typography: 'h6' }}
			>
				{user?.email}
			</Button>
			<Menu
				anchorEl={anchorEl}
				open={open}
				onClose={handleClose}
				TransitionComponent={Fade}
			>
				<MenuItem onClick={handleClose}>Profile</MenuItem>
				<MenuItem onClick={handleClose}>My orders</MenuItem>
				<MenuItem onClick={() => dispatch(signOut())}>Logout</MenuItem>
			</Menu>
		</div>
	);
}
