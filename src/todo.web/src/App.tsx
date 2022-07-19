import React, { Component } from 'react';
import './App.css';
import List from './Components/List/List';
import { ITodoItem } from './Models/ITodoItem';
import { ITodoState } from './Models/ITodoState';
import { EndpointApiClient, IEndpointClient } from './Services/Endpoints';

export default class App extends Component<{}, ITodoState> {
    static displayName = App.name;

    constructor(props: {}) {
        super(props);
        this.state = { todos: [], loading: true };
    }
    static renderTodoList(todoItems: ITodoItem[]) {
        return (<List listItems={todoItems} />);
    }
    componentDidMount() {
        this.populateTodoList();
    }

    render() {
        let contents = this.state.loading ?
            <p><em>Loading... Please refresh once the ASP.NET backend has started. See <a href="https://aka.ms/jspsintegrationreact">https://aka.ms/jspsintegrationreact</a> for more details.</em></p>
            : App.renderTodoList(this.state.todos);
        return (
            <div>
                <h1 className='App-header'>Todo List</h1>
                <h2>{contents}</h2>
            </div>);
    }

    async populateTodoList() {
        const endpointClient: IEndpointClient = new EndpointApiClient();
        const data = await endpointClient.getTodoList();
        this.setState({ todos: data, loading: false });
    }

}