import React from 'react';
import { TodoType } from '../../Enums/TodoType';
import { ITodoItem } from '../../Models/ITodoItem';
import { EndpointApiClient, IEndpointClient } from '../../Services/Endpoints';

export interface CreateProps {
    text: string;
    dispatch: React.Dispatch<any>;
}
export function Create(props: CreateProps) {
    const { text } = props;
    const handleClick: any = async () => {
        if (text && text.length > 0) {

            const client: IEndpointClient = new EndpointApiClient();
            const response: ITodoItem = await client.createTodoItem({ id: 0, description: text, type: TodoType.Pending });
            props.dispatch({ type: 'create', payload: response });
            props.dispatch({ type: 'reset-text', payload: null });
        }
    };
    return (<>
        <input type="text" data-testid='new-item-text' onChange={e => props.dispatch({ type: 'text-changed', payload: e.target.value })} value={text} />
        <input type="submit" data-testid='create-button' value='Create' className="cta" onClick={handleClick} />
    </>);

}

export default Create;