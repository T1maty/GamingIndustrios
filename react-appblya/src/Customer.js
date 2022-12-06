import { useSate } from 'react';

fetch('https://localhost:7063/api/Customer', {
    method: 'POST',
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify(customer)
}).then(() => {
    console.log('new Customer added');
})