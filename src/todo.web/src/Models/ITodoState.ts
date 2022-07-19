import { ITodoItem } from "./ITodoItem";

export interface ITodoState {
    todos: ITodoItem[];
    loading: boolean;
}