import React, { Component } from 'react';
import './App.css';

import TodoApp from './TodoApp';

export default class App extends Component {
    render() {
        return (
            <div>
                <h1 className='App-header'>Todo List</h1>
                <TodoApp />
            </div>);
    }
}