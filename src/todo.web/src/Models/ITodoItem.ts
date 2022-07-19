import { TodoType } from "../Enums/TodoType";

export interface ITodoItem {
    id:number;
    description:string;
    type:TodoType
}