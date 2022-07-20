import React from 'react';
import { render, screen } from '@testing-library/react';
import App from './App';
import Create from './Components/Create/Create';

test('renders app header', () => {
    render(<App />);
    const linkElement = screen.getByText(/Todo List/);
    expect(linkElement).toBeInTheDocument();
});

//test('renders create element', () => {
    
//    render(<App  />);
//    const createButton = screen.getByTestId('create');
//    expect(createButton).toBeInTheDocument();
//    //expect(createButton).toBeInstanceOf(<Create />)
//});
