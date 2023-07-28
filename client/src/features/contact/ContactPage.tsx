import { Button, ButtonGroup, Divider, Typography } from '@mui/material'
import { useAppDispatch, useAppSelector } from '../../app/store/configureStore';
import { decrement, increment } from './counterSlice';

export default function ContactPage() {
	// const { data, title } = useSelector((state: CounterState) => state);
	const { data, title } = useAppSelector(state => state.counter);
	const dispatch = useAppDispatch();
	return (
		<>
			<Typography variant='h2'>
				{title}
			</Typography>
			<Typography variant='h5'>
				The data is: {data}
			</Typography>
			<Divider sx={{ mb: 2 }} />
			<ButtonGroup>
				<Button onClick={() => dispatch(decrement(1))} variant='contained' color='error'>
					Decrement 1
				</Button>
				<Button onClick={() => dispatch(increment(1))} variant='contained' color='primary'>
					increment 1
				</Button>
				<Button onClick={() => dispatch(increment(5))} variant='contained' color='secondary'>
					increment 5
				</Button>
			</ButtonGroup>
		</>
	)
}
