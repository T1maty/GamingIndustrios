import { useSate } from 'react';

fetch('api/Customer', {
    method: 'POST',
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify(customer)
}).then(() => {
    console.log('new Customer added');
})

return (
    <div className="customer">
        <h2> Add a Basket</h2>
        <form onSubmit={handleSubmit}>
            <label> Customer Title</label>
            <input
                type="text"
                required
                value={title}
                onChange={ (e) => setTitle(e.target.value)}
            />
            <label>Customer body:</label>
            <textarea
                required
                value={body}
                onChange={(e) => setBody(e.target.value)}
            ></textarea>
            <label>Customer Firstname</label>
            <select
                value={author}
                onChange={(e) => setFirstname(e.target.value) }
            >
                <option value="Ivan">ivan</option>
                <option value="Simonyan">simonyan</option>
            </select>
            <button>Add To Basket</button>
        </form>
    </div>

    )