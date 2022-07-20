import React, { useEffect, useReducer } from 'react';
import Create from './Components/Create/Create';
import List from './Components/List/List';
import { TodoType } from './Enums/TodoType';
import { ITodoItem } from './Models/ITodoItem';
import todoReducer from './Reducers/todoReducer';
import { EndpointApiClient, IEndpointClient } from './Services/Endpoints';

/**
 * TODO App - This is the functional component that renders the todo functionality.
 * */
function TodoApp() {
    const [state, dispatch] = useReducer(todoReducer, { todos: [], loading: true, text: '' });
    const { loading, todos, text } = state;
    const endpointClient: IEndpointClient = new EndpointApiClient();

    async function populateTodoList(): Promise<void> {
        const data = await endpointClient.getTodoList();
        dispatch({ type: 'fetch-complete', payload: data });
    };

    function renderTodoList(todoItems: ITodoItem[]): any {

        return (<>
            <Create data-testid='create' dispatch={dispatch} text={text} />
            <List listItems={todoItems} data-testid='todo-list' callback={changeTodoGroup} />
        </>);
    };

    const changeTodoGroup = (id: number) => {
        const todoItems: ITodoItem[] = todos;
        const item = todoItems.find(x => x.id === id);

        if (!item) return;
        endpointClient.updateTodoItem(
            {
                ...item,
                type: item.type === TodoType.Pending
                    ? TodoType.Completed
                    : TodoType.Pending
            })
            .then(updatedItem => {
                if (item.type === TodoType.Pending)
                    dispatch({ type: 'move-to-complete', payload: updatedItem });
                else {
                    dispatch({ type: 'move-to-pending', payload: updatedItem });
                }
            });

    };

    useEffect(() => { populateTodoList(); });

    let contents = loading ?
        <p><em>Loading... Please refresh once the ASP.NET backend has started. See <a href="https://aka.ms/jspsintegrationreact">https://aka.ms/jspsintegrationreact</a> for more details.</em></p>
        : renderTodoList(todos);
    return (
        <> {contents}</>
    );
}

export default TodoApp;