import { IForecast } from '../Forecast';
const { API_URL } = require('../constants').default;

export interface IEndpointClient {

    getWeatherForecast(): Promise<IForecast[]>;
}

export class EndpointApiClient implements IEndpointClient {
    baseUrl: string;
    constructor() {
        this.baseUrl = API_URL ;
    }

    async getWeatherForecast(): Promise<IForecast[]> {
        let url = this.baseUrl + "/weatherforecast";
        var response = await fetch(url);
        var data = response.json();
        return data;

    }
}