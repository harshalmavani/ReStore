import { createSlice } from "@reduxjs/toolkit";

export interface CounterState {
	title: string;
	data: number;
}

const initialState: CounterState = {
	title: 'Yet another redux toolkit counter',
	data: 42
}

export const counterSlice = createSlice({
	name: 'counter',
	initialState,
	reducers: {
		increment: (state, action) => {
			state.data += action.payload
		},
		decrement: (state, action) => {
			state.data -= action.payload
		}
	}
	
})

export const {increment, decrement} = counterSlice.actions;