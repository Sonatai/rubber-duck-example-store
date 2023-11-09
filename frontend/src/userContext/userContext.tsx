import { PropsWithChildren, createContext, useState } from 'react';
import { UserContextType } from './userContext.types';
import { IUser } from '../shared/interfaces/user.interface';

export const UserContext = createContext<UserContextType | null>(null);

export const UserProvider = (props: PropsWithChildren<unknown>) => {
    const { children } = props;

    const [user, setUserState] = useState<IUser | null>(null);

    const removeUser = () => setUserState(null);
    const setUser = (user: IUser) => setUserState(user);

    return (
        <UserContext.Provider value={{ user, setUser, removeUser }}>
            {children}
        </UserContext.Provider>
    );
};
