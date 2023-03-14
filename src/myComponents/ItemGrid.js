import {useEffect, useState} from 'react';

import Item from "../myElements/Item";

function ItemGrid(props) {
	const [templateColumn, setTemplateColumn] = useState('1fr 1fr 1fr 1fr')
	const array = [500,1000,1500,2000,2500,3000,3500,4000,4500,5000]
	const css = {
		body : {
			width: '100%',
			height: '1000px',

			margin: '0',
			padding: '0',

			backgroundColor: 'blue',
			listStyleType: 'none',

			display: 'grid',
			justifyItems: 'center',
			alignItems: 'center',
			gridTemplateColumns: templateColumn,
			gridGap: '3%',
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
			{array.map((value, index) => <li><Item index={index} value={value} key={index} /></li>)}
		</ul>

	);
}

export default ItemGrid;