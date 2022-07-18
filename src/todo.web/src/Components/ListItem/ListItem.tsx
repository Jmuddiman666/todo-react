import React from 'react';
import { TodoType } from '../../Enums/TodoType';
import { ListItemProps } from '../../Models/ListItemProps';


export function ListItem(props: ListItemProps) {
    return (
        <tr>
            <td>{props.Id}</td>
            <td>{props.Description}</td>
            <td>{props.Type === TodoType.Completed ? 'Completed' : 'Pending'}</td>
        </tr>);
}

export default ListItem;