import React from 'react';
import { render, screen } from '@testing-library/react';
import { ListItem } from './ListItem';
import { TodoType } from '../../Enums/TodoType';


test('renders description', () => {
    render(<ListItem Id={1}
        Description="complete to-do app"
        Type={TodoType.Pending} />);
    const tableContent = screen.getByText('complete to-do app');
    expect(tableContent).toBeInTheDocument();
});

test('renders type enum as text', () => {
    render(<ListItem Id={1}
        Description="todo-item"
        Type={TodoType.Completed }/>);
    const enumText = screen.getByText('Completed');
    expect(enumText).toBeInTheDocument();
})