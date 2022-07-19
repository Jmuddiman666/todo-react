import { ITodoItem } from '../Models/ITodoItem';
const { API_URL } = require('../constants').default;

export interface IEndpointClient {


    /**
     * Retrieve an array of todoItems
     * */
    getTodoList(): Promise<ITodoItem[]>;
    /**
     * Create a new Todo Item
     * @param todoItem
     */
    createTodoItem(todoItem: ITodoItem): Promise<void>;
}

export class EndpointApiClient implements IEndpointClient {
    baseUrl: string;
    constructor() {
        this.baseUrl = API_URL;
    }

    /**
     * Create a new Todo Item
     * @param todoItem
     */
    createTodoItem(todoItem: ITodoItem): Promise<void> {
        let url = this.baseUrl + '/api/todo';

        let options = {
            method: 'POST',
            body: JSON.stringify(todoItem)
        };
        const response = fetch(url, options);
        console.info(response);
        return Promise.resolve();
    }

    /**
 * Retrieve an array of todoItems
 * */
    async getTodoList(): Promise<ITodoItem[]> {
        let url = this.baseUrl + '/api/todo';
        var response = await fetch(url);
        var data = response.json();
        return data;
    }
}