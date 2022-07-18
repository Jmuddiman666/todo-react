import { TodoType } from "../Enums/TodoType";

export interface ITodoItem {
    Id:number;
    Description:string;
    Type:TodoType
}