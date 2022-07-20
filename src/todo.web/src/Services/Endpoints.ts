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
    createTodoItem(todoItem: ITodoItem): Promise<ITodoItem>;
    /**
     * Update an existing Todo Item.
     * @param todoItem
     */
    updateTodoItem(todoItem: ITodoItem): Promise<ITodoItem>;

}

export class EndpointApiClient implements IEndpointClient {
    baseUrl: string;
    constructor() {
        this.baseUrl = API_URL;
    }
    updateTodoItem(todoItem: ITodoItem): Promise<ITodoItem> {
        let url = this.baseUrl + '/api/todo';

        var myHeaders = new Headers();
        myHeaders.append("Accept", "application/json");
        myHeaders.append("Content-Type", "application/json");
        var requestOptions: RequestInit = {
            method: 'PUT',
            headers: myHeaders,
            body: JSON.stringify(todoItem),
        };

        //Getting a 415 here locally.
        var response = fetch(url, requestOptions)
            .then(response => response.json())
            .then(result => {
                console.log(result);
                return result;
            })
            .catch(error => console.log('error', error));
        return response;
    }

    /**
     * Create a new Todo Item
     * @param todoItem
     */
    createTodoItem(todoItem: ITodoItem): Promise<ITodoItem> {
        let url = this.baseUrl + '/api/todo';

        var myHeaders = new Headers();
        myHeaders.append("Accept", "application/json");
        myHeaders.append("Content-Type", "application/json");
        var requestOptions: RequestInit = {
            method: 'POST',
            headers: myHeaders,
            body: JSON.stringify(todoItem),
        };

        //Getting a 415 here locally.
        var response = fetch(url, requestOptions)
            .then(response => response.json())
            .then(result => {
                console.log(result);
                return result;
            })
            .catch(error => console.log('error', error));
        return response;
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