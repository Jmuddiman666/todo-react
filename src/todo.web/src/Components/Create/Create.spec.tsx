import React from 'react';
import { render, screen, queryByAttribute, getByTestId, } from '@testing-library/react';
import Create from './Create';
import * as jest from 'jest';
import exp from 'constants';

test('renders text input', () => {
    render(<Create dispatch={() => { }} text='test'/>);
    const textInput = screen.getByTestId('new-item-text');
    expect(textInput).toContainHTML('<input ');
});

test('renders create button', () => {
    render(<Create dispatch={() => { }} text='test' />);
    const createButton = screen.getByTestId('create-button');
    expect(createButton).toHaveValue('Create');
});