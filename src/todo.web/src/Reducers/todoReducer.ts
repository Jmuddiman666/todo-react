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