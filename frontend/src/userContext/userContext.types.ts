import { IUser } from '../shared/interfaces/user.interface';

export type UserContextType = {
    user: IUser | null;
    setUser: (user: IUser) => void;
    removeUser: () => void;
};
