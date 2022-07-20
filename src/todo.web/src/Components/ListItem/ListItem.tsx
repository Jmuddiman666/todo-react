import React from 'react';
import { TodoType } from '../../Enums/TodoType';
import { ListItemProps } from '../../Models/ListItemProps';


export function ListItem(props: ListItemProps) {
    let icon = props.type === TodoType.Pending ? 'move-to-complete' : 'move-to-pending';
    let title = props.type === TodoType.Pending ? 'Move to Complete' : 'Move to Pending';
    const handleOnClick = () => {
        
        props.callback(props.id);
    };
    return (
        <li key={props.id}>{props.description} <span /> <button data-testid='update-type' className={icon} onClick={handleOnClick} title={title} /> </li>
    );
}

export default ListItem;