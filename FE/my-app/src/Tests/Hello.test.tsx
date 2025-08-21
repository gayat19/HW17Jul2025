import { render, screen } from '@testing-library/react';
import Hello from '../Components/Hello';

test('render hello world', () => {
   render(<Hello/>)
   expect(screen.getByText('Hello World')).toBeInTheDocument();
})