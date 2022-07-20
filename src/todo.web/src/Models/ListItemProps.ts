import React from "react";
import { TodoType } from "../Enums/TodoType";
import { ITodoItem } from "./ITodoItem";

export interface ListItemProps extends ITodoItem {
    id: number;
    description: string;
    type: TodoType;
    callback: Function;
}