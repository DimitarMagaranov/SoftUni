import { render, screen, fireEvent, waitFor } from '@testing-library/react';
import { BrowserRouter } from 'react-router-dom';

import PetCard from './PetCard';
import * as petService from '../../services/petService';

jest.mock('../../services/petService');

describe('PetCard Component', () => {
    it('Should display name', () => {
        render(
            <BrowserRouter>
                <PetCard data={{ name: 'Pesho' }} />
            </BrowserRouter>
        );

        expect(document.querySelector('h3').textContent).toBe('Name: Pesho');
    });

    it('Should increase likes when like button is pressed', async () => {
        petService.like.mockResolvedValue({likes: 6});

        render(
            <BrowserRouter>
                <PetCard data={{id: 'asd', likes: 5 }} />
            </BrowserRouter>
        );

        fireEvent.click(document.getElementById('asd'));

        await waitFor(() => document.getElementById('asd'));

        expect(document.querySelector('.pet-info span').textContent).toBe('6')
    })
});
