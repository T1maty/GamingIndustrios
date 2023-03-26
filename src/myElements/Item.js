import {useState} from 'react';
import {Link} from "react-router-dom";

function Item({props}) {
	const css = {
		body : {
			width: '260px',
			height: '400px',

			backgroundColor: 'yellow',
			cursor: 'pointer',
			transition: '.3s',
			color: 'black',

			display: 'flex',
			flexDirection: 'column',
			justifyContent: 'space-between',
			alignItems: 'center',

		},
		bodyHover : {
			width: '255px',
			height: '395px',

			backgroundColor: 'red',
			color: 'white',
			cursor: 'pointer',
			transition: '.3s',

			display: 'flex',
			flexDirection: 'column',
			justifyContent: 'space-between',
			alignItems: 'center',
		},
		link : {
			textDecoration: 'none',
			color: 'none',
		},
		image : {
			width: '250px',
		}

	}
	const [styleItem, setStyleItem] = useState(css.body)
	return (
		<Link to='/item' style={css.link} state={ props }>
			<div style={styleItem} onMouseOver={_=>setStyleItem(css.bodyHover)} onMouseLeave={_=>setStyleItem(css.body)}>
				Номер товара:{props.index}<br/>Value: {props.name}<br />Price: {props.price}<br />Rate: {props.rate}<br /><img
				src={props.image} alt="product picture" style={css.image}/>
			</div>
		</Link>
	);
}

export default Item;