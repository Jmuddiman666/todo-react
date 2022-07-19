import React from 'react';
import { ListItemProps } from '../../Models/ListItemProps';


export function ListItem(props: ListItemProps) {
    return (
        <li key={props.id}>{props.description}</li>
    );
}

export default ListItem;