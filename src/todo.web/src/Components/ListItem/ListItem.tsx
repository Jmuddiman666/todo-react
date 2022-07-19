import { Card } from '@mui/material';
import React from 'react';
import { TodoType } from '../../Enums/TodoType';
import { ListItemProps } from '../../Models/ListItemProps';


export function ListItem(props: ListItemProps) {
    return (
        //<tr>
        //    <td>{props.id}</td>
        //    <td>{props.description}</td>
        //    <td>{props.type === TodoType.Completed ? 'Completed' : 'Pending'}</td>
        //</tr>   
        <li key={props.id}>{props.description}</li>
    );
}

export default ListItem;