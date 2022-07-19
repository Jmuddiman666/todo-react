import React from 'react';
import { render, screen } from '@testing-library/react';
import List from './List';
import { ListProps } from '../../Models/ListProps';
import { TodoType } from '../../Enums/TodoType';

test('renders a table', () => {
    let props: ListProps = { listItems:[] };
    props.listItems.push({
        id: 1,
        description: "",
        type: TodoType.Pending
    });

    render(<List key={1}  listItems={props.listItems} />);
    const tableHeader = screen.getByText('Pending');
    expect(tableHeader).toBeInTheDocument();
});