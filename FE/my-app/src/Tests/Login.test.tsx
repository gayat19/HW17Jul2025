
import { useAuth } from "../Misc/AuthContext";
import { useNavigate } from "react-router-dom";
 import { userLogin } from "../Services/AuthenticationAPIService";
import { render,fireEvent,screen, waitFor } from "@testing-library/react";
import Login from "../Components/Login";

jest.mock("../Services/AuthenticationAPIService");
jest.mock("react-router-dom",()=>({
    ...jest.requireActual("react-router-dom"),
    useNavigate: jest.fn(),
}));
jest.mock("../Misc/AuthContext",()=>({
    useAuth:jest.fn()
}));

const mockNavigate = jest.fn();
const mockLogin = jest.fn();

beforeEach(()=>{
    (useNavigate as jest.Mock).mockReturnValue(mockNavigate);
    (useAuth as jest.Mock).mockReturnValue({login:mockLogin});
});

test('login success', async()=>{
    const mockToken = "mockToken";
    const mockResponse = {
        status: 200,
        data: {
            accessToken: mockToken,
        },
    };
    (userLogin as jest.Mock).mockResolvedValue(mockResponse);
    window.alert = jest.fn();
    
    render(<Login/>);
    const loginButton = screen.getByRole('button', { name: 'Login' });
    fireEvent.click(loginButton);

    await waitFor(()=>{
        expect(userLogin).toHaveBeenCalledWith({username:'emilys',password:'emilyspass'});
        expect(window.alert).toHaveBeenCalledWith('login success');
        expect(mockLogin).toHaveBeenCalledWith(mockToken);
        expect(mockNavigate).toHaveBeenCalledWith('/obs');
    });

});