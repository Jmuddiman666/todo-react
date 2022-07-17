import React, { Component } from 'react';
import './App.css';
import { IForecast, IForecastState } from './Forecast';
import {EndpointApiClient,IEndpointClient} from './Services/Endpoints';

export default class App extends Component<{}, IForecastState> {
    static displayName = App.name;

    constructor(props: {}) {
        super(props);
        this.state = { forecasts: [], loading: true };
    }

    static renderForecastsTable(forecasts: IForecast[]) {

        return (
            <table className='table table-striped' aria-labelledby="tabelLabel">
                <thead>
                    <tr>
                        <th>Date</th>
                        <th>Temp. (C)</th>
                        <th>Temp. (F)</th>
                        <th>Summary</th>
                    </tr>
                </thead>
                <tbody>
                    {forecasts.map(forecast => {
                        let date = new Date(forecast.date);
                        return (
                            <tr key={date.toISOString()}>
                                <td>{date.toLocaleDateString()}</td>
                                <td>{forecast.temperatureC}</td>
                                <td>{forecast.temperatureF}</td>
                                <td>{forecast.summary}</td>
                            </tr>);
                    }
                    )}
                </tbody>
            </table>
        );
    }

    componentDidMount() {
        this.populateWeatherData();
    }

    render() {
        let contents = this.state.loading ?
            <p><em>Loading... Please refresh once the ASP.NET backend has started. See <a href="https://aka.ms/jspsintegrationreact">https://aka.ms/jspsintegrationreact</a> for more details.</em></p> : App.renderForecastsTable(this.state.forecasts);
        return (
            <div><h2>{contents}</h2></div>);
    }

    async populateWeatherData() {
        const endpointClient:IEndpointClient = new EndpointApiClient();
        const data = await endpointClient.getWeatherForecast();
        this.setState({ forecasts: data, loading: false });
    }

}