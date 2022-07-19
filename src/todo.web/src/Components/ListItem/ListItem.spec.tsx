import React from 'react';
import { render, screen } from '@testing-library/react';
import { ListItem } from './ListItem';
import { TodoType } from '../../Enums/TodoType';


test('renders description', () => {
    render(<ListItem id={1}
        description="complete to-do app"
        type={TodoType.Pending} />);
    const tableContent = screen.getByText('complete to-do app');
    expect(tableContent).toBeInTheDocument();
});

test('renders type enum as text', () => {
    render(<ListItem id={1}
        description="todo-item"
        type={TodoType.Completed }/>);
    const enumText = screen.getByText('Completed');
    expect(enumText).toBeInTheDocument();
})