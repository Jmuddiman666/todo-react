export interface IForecast {
    date: Date;
    temperatureC: number;
    temperatureF: number;
    summary: string;
}

export interface IForecastState {
    forecasts:IForecast[];
    loading:boolean;
}