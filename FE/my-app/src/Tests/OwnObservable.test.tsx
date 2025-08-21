
import { render, waitFor,screen } from "@testing-library/react";
import OwnObservable from "../Components/OwnObservable";

jest.useFakeTimers();

test('observable test',async ()=>{

    render(<OwnObservable/>)

    jest.advanceTimersByTime(11000);
    await waitFor(()=>{
        expect(screen.getByText('count : 10')).toBeInTheDocument()  
    })
})