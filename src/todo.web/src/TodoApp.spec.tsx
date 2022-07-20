import React from 'react';
import { render } from '@testing-library/react';
import TodoApp from './TodoApp';

test('renders todo app', () => {
   render(<TodoApp />);
});