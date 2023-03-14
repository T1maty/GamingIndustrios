import {useState} from 'react';
import {Link} from "react-router-dom";

function Item(props) {

	const css = {
		body : {
			width: '200px',
			height: '350px',

			padding: '25px',

			backgroundColor: 'yellow',
			cursor: 'pointer',
			transition: '.3s',
			color: 'black',

		},
		bodyHover : {
			width: '200px',
			height: '350px',

			padding: '23px',

			backgroundColor: 'red',
			color: 'white',
			cursor: 'pointer',
			transition: '.3s'
		},
		link : {
			textDecoration: 'none',
			color: 'none',
		},

	}
	const [styleItem, setStyleItem] = useState(css.body)
	return (
		<Link to='/item' style={css.link} state={ props }>
			<div style={styleItem} onMouseOver={_=>setStyleItem(css.bodyHover)} onMouseLeave={_=>setStyleItem(css.body)}>
				Номер товара:{props.index},<br/>Value: {props.value}
			</div>
		</Link>
	);
}

export default Item;