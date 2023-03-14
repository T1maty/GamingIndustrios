import {useState} from 'react';
import {Link} from "react-router-dom";

function Item(props) {

	const css = {
		body : {
			width: '60px',
			height: '100px',

			padding: '0 13px 0 13px',
			margin: '0 7px 0 7px',

			backgroundColor: 'yellow',
			cursor: 'pointer',
			transition: '.3s',
			color: 'black',

		},
		bodyHover : {
			width: '60px',
			height: '100px',

			padding: '0 15px 0 15px',
			margin: '0 10px 0 10px',

			backgroundColor: 'blue',
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