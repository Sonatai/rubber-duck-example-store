import { PropsWithChildren } from 'react';
import './container.styled.scss';

export const RubberDuckContainer = (
    props: PropsWithChildren<unknown>
): JSX.Element => {
    const { children } = props;

    return <div className="rubber-duck-container">{children} </div>;
};
