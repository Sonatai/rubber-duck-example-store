import axios, { AxiosResponse } from 'axios';
import { useEffect, useState } from 'react';

import { Input } from '@mui/base';

import { RubberDuckContainer } from '../shared';
import { IUser } from '../shared/interfaces/user.interface';
import { Button, InputLabel, Typography } from '@mui/material';

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

export const LoginPage = () => {
    const [name, setName] = useState('');
    const [password, setPassword] = useState('');
    const [errorMessage, setErrorMessage] = useState<string | null>(null);

    useEffect(() => {
        setErrorMessage(null);
    }, []);

    const handleLogin = async () => {
        setErrorMessage('');

        if (name === '' || password === '') {
            setErrorMessage('Enter password and user name');
        } else {
            loginUser(name, password)
                .then(() => alert('you are logged in'))
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
                .then(() => alert('you are register'))
                .catch((data) => {
                    if (data.response.status === 422) {
                        setErrorMessage('User name already exists.');
                    } else {
                        alert('Something went wrong');
                    }
                });
        }
    };

    return (
        <RubberDuckContainer>
            <Typography variant="h1" component="h1" mb="2rem">
                Awesome Rubber Duck Store
            </Typography>
            <Typography variant="body1" mb="1rem">
                Please login to see our products.
            </Typography>
            <InputLabel itemID={name}>User Name</InputLabel>
            <Input
                name={name}
                value={name}
                onChange={(event: any) => setName(event.target.value)}
            />
            <InputLabel itemID={password}>Password</InputLabel>
            <Input
                name={password}
                value={password}
                onChange={(event: any) => setPassword(event.target.value)}
            />

            {errorMessage !== '' && (
                <Typography variant="body1">{errorMessage}</Typography>
            )}

            <Button variant="contained" onClick={handleLogin}>
                Login
            </Button>
            <Button onClick={handleRegister}>Register</Button>
        </RubberDuckContainer>
    );
};
