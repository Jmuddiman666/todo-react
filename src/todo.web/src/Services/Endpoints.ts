import { ITodoItem } from '../Models/ITodoItem';
const { API_URL } = require('../constants').default;

export interface IEndpointClient {


    /**
     * Retrieve an array of todoItems
     * */
    getTodoList(): Promise<ITodoItem[]>;
}

export class EndpointApiClient implements IEndpointClient {
    baseUrl: string;
    constructor() {
        this.baseUrl = API_URL;
    }


    async getTodoList(): Promise<ITodoItem[]> {
        let url = this.baseUrl + '/api/todo';
        var response = await fetch(url);
        var data = response.json();
        return data;
    }
}