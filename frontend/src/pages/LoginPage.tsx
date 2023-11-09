import './login.styles.scss';

import axios, { AxiosResponse } from 'axios';
import { useContext, useEffect, useState } from 'react';
import { Navigate } from 'react-router';

import { Button, TextField, Typography } from '@mui/material';

import { RubberDuckContainer } from '../shared';
import { IUser } from '../shared/interfaces/user.interface';
import { UserContext } from '../userContext/userContext';
import { UserContextType } from '../userContext/userContext.types';

const registerUser = async (
    name: string,
    password: string
): Promise<AxiosResponse<IUser, any>> => {
    return axios.post('http://localhost:4220/register', {
        name: name,
        password: password,
    });
};

const loginUser = async (
    name: string,
    password: string
): Promise<AxiosResponse<IUser, any>> => {
    return await axios.post('http://localhost:4220/login', {
        name: name,
        password: password,
    });
};

export const LoginPage = (): JSX.Element => {
    const [name, setName] = useState('');
    const [password, setPassword] = useState('');
    const [errorMessage, setErrorMessage] = useState<string | null>(null);

    const { user, setUser } = useContext(UserContext) as UserContextType;

    useEffect(() => {
        setErrorMessage(null);
    }, []);

    const handleLogin = async () => {
        setErrorMessage('');

        if (name === '' || password === '') {
            setErrorMessage('Enter password and user name');
        } else {
            loginUser(name, password)
                .then((response) => setUser({ userId: response.data.userId }))
                .catch((data) => {
                    if (data.response.status === 422) {
                        setErrorMessage('User name or password is wrong');
                    } else {
                        alert('Something went wrong');
                    }
                });
        }
    };

    const handleRegister = async () => {
        setErrorMessage('');

        if (name === '' || password === '') {
            setErrorMessage('Enter password and user name');
        } else {
            registerUser(name, password)
                .then((response) => setUser({ userId: response.data.userId }))
                .catch((data) => {
                    if (data.response.status === 422) {
                        setErrorMessage('User name already exists.');
                    } else {
                        alert('Something went wrong');
                    }
                });
        }
    };

    if (user?.userId !== undefined && user?.userId !== null) {
        return <Navigate to="/" />;
    }

    return (
        <RubberDuckContainer>
            <div className="login" />
            <Typography variant="h1" component="h1" mb="2rem">
                Awesome Rubber Duck Store
            </Typography>
            <Typography variant="body1" mb="1rem">
                Please login to see our products.
            </Typography>
            <div className="login__input-group">
                <TextField
                    label="User Name"
                    name={name}
                    value={name}
                    onChange={(event: any) => setName(event.target.value)}
                    className="login__input-group__input"
                />
                <TextField
                    label="Password"
                    name={password}
                    value={password}
                    onChange={(event: any) => setPassword(event.target.value)}
                    className="login__input-group__input"
                />
            </div>

            {errorMessage !== '' && (
                <Typography variant="body1">{errorMessage}</Typography>
            )}

            <Button
                variant="contained"
                onClick={handleLogin}
                className="login__button"
            >
                Login
            </Button>
            <Button onClick={handleRegister}>Register</Button>
        </RubberDuckContainer>
    );
};
