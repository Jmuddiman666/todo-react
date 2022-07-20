import React, { useReducer } from 'react';
import { TodoType } from '../../Enums/TodoType';
import { ListProps } from '../../Models/ListProps';
import todoReducer from '../../Reducers/todoReducer';
import Create from '../Create/Create';
import ListItem from '../ListItem/ListItem';

function List(props: ListProps) {
    return (
        <>
            <div className='container'>
                <div className='left-column'>
                    <h2>Pending</h2>
                    {/*Pending Group*/}
                    <ul>
                        {props.listItems.filter(x => x.type === TodoType.Pending).map(listItem =>
                            <ListItem key={listItem.id}
                                id={listItem.id}
                                description={listItem.description}
                                type={listItem.type}
                                callback={props.callback} />)}
                    </ul>
                </div>
                <div className='right-column'>
                    <h2>Completed</h2>
                    {/*Completed Group*/}
                    <ul>
                        {props.listItems.filter(x => x.type !== TodoType.Pending).map(listItem =>
                            <ListItem key={listItem.id}
                                id={listItem.id}
                                description={listItem.description}
                                type={listItem.type}
                                callback={props.callback} />)}
                    </ul>
                </div>
            </div>
        </>
    );
}

export default List;