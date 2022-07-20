import { ITodoItem } from "./ITodoItem";

export interface ListProps {
    listItems: ITodoItem[];
    callback: (id: number) => void;
}