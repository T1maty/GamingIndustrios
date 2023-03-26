import {useEffect, useState} from 'react';

import Item from "../myElements/Item";
import image from "../image";

function ItemGrid(props) {
	const [templateColumn, setTemplateColumn] = useState('1fr 1fr 1fr 1fr')
	const shop = [
		{name: "product", price: "300$", rate: "10", image: [image.brain], section: "useless products", description: "The description of product", comments: [], index: 0},
		{name: "product", price: "300$+10$", rate: "10", image: [image.brain], section: "useless products", description: "The description of product",
			comments: [{name: "Galya", text: "Very useless product, I like it"},{name: "Nie Galya", text: "Very useful product, I like it"}], index: 1},
		{name: "product", price: "300$+20$", rate: "10", image: [image.brain], section: "useless products", description: "The description of product",
			comments: [{name: "Galya", text: "Very useless product, I like it"},{name: "Nie Galya", text: "Very useful product, I like it"}], index: 2},
		{name: "product", price: "300$+30$", rate: "10", image: [image.brain], section: "useless products", description: "The description of product",
			comments: [{name: "Galya", text: "Very useless product, I like it"},{name: "Nie Galya", text: "Very useful product, I like it"}], index: 3},
		{name: "product", price: "300$+40$", rate: "10", image: [image.brain], section: "useless products", description: "The description of product",
			comments: [{name: "Galya", text: "Very useless product, I like it"},{name: "Nie Galya", text: "Very useful product, I like it"}], index: 4},
		{name: "product", price: "300$+50$", rate: "10", image: [image.brain], section: "useless products", description: "The description of product",
			comments: [{name: "Galya", text: "Very useless product, I like it"},{name: "Nie Galya", text: "Very useful product, I like it"}], index: 5},
		{name: "product", price: "300$+60$", rate: "10", image: [image.brain], section: "useless products", description: "The description of product",
			comments: [{name: "Galya", text: "Very useless product, I like it"},{name: "Nie Galya", text: "Very useful product, I like it"}], index: 6}
	]
	const css = {
		body : {
			width: '100%',

			padding: '8% 0 8% 0',
			margin: '0',

			backgroundColor: 'blue',
			listStyleType: 'none',

			display: 'grid',
			justifyItems: 'center',
			alignItems: 'center',
			gridTemplateColumns: templateColumn,
			gridGap: '1%'
		},


	}
	useEffect(_=>{
		resize()
	}, [])
	window.addEventListener("resize", _=>{
		resize()
	})
	const resize =_=>{
		if (window.innerWidth < 550) {
			setTemplateColumn('1fr 1fr')
		} else if (window.innerWidth < 800) {
			setTemplateColumn('1fr 1fr')
		} else if (window.innerWidth < 1100) {
			setTemplateColumn('1fr 1fr 1fr')
		} else if (window.innerWidth < 1430) {
			setTemplateColumn('1fr 1fr 1fr 1fr')
		} else if (window.innerWidth < 1650) {
			setTemplateColumn('1fr 1fr 1fr 1fr 1fr')
		}
	}
	return (
		<ul style={css.body}>
			{shop.map((value, index) => <li key={index}><Item props={value} /></li>)}
		</ul>

	);
}

export default ItemGrid;