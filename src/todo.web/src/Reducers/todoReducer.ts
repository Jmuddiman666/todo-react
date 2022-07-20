import { TodoType } from "../Enums/TodoType";
import { ITodoItem } from "../Models/ITodoItem";

/**
 * Reducer for todo related state
 * @param state Current state
 * @param action Action type and payload
 */
function todoReducer(state: any, action: any) {
    switch (action.type) {
        case 'fetch-list': {
            return {
                ...state,
                loading: true
            };
        }
        case 'fetch-complete': {
            return {
                ...state,
                todos: action.payload,
                loading: false
            };
        }
        case 'create': {
            return {
                ...state,
                todos: [...state.todos, action.payload]
            };
        }
        case 'text-changed': {
            return {
                ...state,
                text: action.payload
            };
        }
        case 'move-to-pending': {
            let currentTodos: ITodoItem[] = state.todos;
            let index = currentTodos.findIndex(x => x.id == action.payload.id);
            let item = { ...action.payload, type: TodoType.Pending };
            return {
                ...state,
                todos: [...currentTodos.splice(index, 1), item]
            };
        }
        case 'move-to-complete': {
            let currentTodos: ITodoItem[] = state.todos;
            let index = currentTodos.findIndex(x => x.id == action.payload.id);
            let item = { ...action.payload, type: TodoType.Completed };
            return {
                ...state,
                todos: [...currentTodos.splice(index, 1), item]
            };
        }
        case 'reset-text': {
            return {
                ...state,
                text: ''
            };
        }
        default:
            return state;
    }
}
export default todoReducer;