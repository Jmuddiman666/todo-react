import React from 'react';
import { ListProps } from '../../Models/ListProps';
import ListItem from '../ListItem/ListItem';


function List(props: ListProps) {
    return (
        <table className='table table-striped' aria-labelledby="tabelLabel">
            <thead>
                <th>ID</th>
                <th>Description</th>
                <th>Type</th>
            </thead>
            <body>
                {props.listItems.map(listItem =>
                    <ListItem key={listItem.Id}
                        Id={listItem.Id}
                        Description={listItem.Description}
                        Type={listItem.Type} />)}
            </body>
        </table>
    );
}

export default List;