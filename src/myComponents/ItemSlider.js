import React from 'react';
import ItemMini from "../myElements/ItemMini";

function ItemSlider(props) {

	const array = [500,1000,1500,2000,2500,3000,3500,4000,4500,5000]
	const css = {
		body : {
			width: '100%',
			height: '100px',

			margin: '0',
			padding: '3px 0 3px 0',

			backgroundColor: 'red',
			listStyleType: 'none',
			overflow: 'scroll',

			display: 'flex',


		},

	}
	return (
		<ul style={css.body}>
			{array.map((value, index) => <li><ItemMini index={index} value={value} key={index} /></li>)}
		</ul>
	);
}

export default ItemSlider;