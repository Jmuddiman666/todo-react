import { TodoType } from "../Enums/TodoType";
import { ITodoItem } from "./ITodoItem";

export interface ListItemProps extends ITodoItem {
    Id: number ;
    Description: string ;
    Type: TodoType ;
}