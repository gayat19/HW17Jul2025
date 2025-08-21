import { fireEvent, render,screen } from "@testing-library/react"

import ExampleButton from "../Components/ExampleButton"


test('button present',()=>{
    render(<ExampleButton/>)
    const button = screen.getByRole('button',{name:'Click Me'})
    fireEvent.click(button);
    expect(screen.getByText('Button Clicked')).toBeInTheDocument()
})