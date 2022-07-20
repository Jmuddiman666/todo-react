import React, { useState } from 'react';
import { TodoType } from '../../Enums/TodoType';
import { EndpointApiClient, IEndpointClient } from '../../Services/Endpoints';

export function Create() {
    const [text, setText] = useState('');


    const handleClick: any = (event: any) => {
        if (text && text.length > 0) {

            const client: IEndpointClient = new EndpointApiClient();
            client.createTodoItem({ id: 0, description: text, type: TodoType.Pending });
            //Need to refresh the list
        }
    };
    return (< >
        <input type="text" data-testid='new-item-text' onChange={e => setText(e.target.value)} />
        <input type="submit" data-testid='create-button' value='Create' className="cta" onClick={handleClick} /> </>);

}

export default Create;