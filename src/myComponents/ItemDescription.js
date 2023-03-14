import {useEffect, useState} from 'react';
import { useLocation } from 'react-router-dom'
import {Link} from "react-router-dom";

function ItemDescription(props) {
	const location = useLocation()
	let from = {index: 0, value: "Товар не найдено"}
	if (location.state !== null) {
		from = location.state
	}
	const [galleryFlex, setGalleryFlex] = useState('row')
	const css = {
		body : {
			width: '100%',

			backgroundColor: 'red',
		},
		nav : {
			width: '100%',
			height: '50px',

			fontSize: '27px',
			fontFamily: 'Arial',

			display: 'flex',
			justifyContent: 'center',
			alignItems: 'center',

			position: 'relative'
		},
		link : {
			textDecoration: 'none',
			color: 'black',

			position: 'absolute',
			left: '20px',
		},
		gallery : {
			width: '80%',
			height: '500px',

			padding: '0 10% 0 10%',

			backgroundColor: 'yellow',

			display: 'flex',
			flexDirection: galleryFlex,
			justifyContent: 'center',
			alignItems: 'center',

		},
		picture : {
			width: '35vw',
			maxWidth: '500px',
			minWidth: '250px',

			aspectRatio: '1/1',

			backgroundColor: 'blue',


		},
		description : {
			width: '400px',
			height: '500px',

			backgroundColor: 'purple',
			color: 'white',

		}

	}
	useEffect(_=>{
		resize()
	}, [])
	window.addEventListener("resize", _=>{
		resize()
	})
	const resize =_=>{
		if (window.innerWidth < 700) {
			setGalleryFlex('column')
		} else {
			setGalleryFlex('row')
		}
	}
	return (
		<div style={css.body}>
			<div style={css.nav}>
				<Link to="/" style={css.link}>{'<'}Назад</Link>
				<div>{from.value}</div>
			</div>
			<div style={css.gallery}>
				<div style={css.picture}>
					тут будет картинка, а в будущем и нормальная галерея
				</div>
				<div style={css.description}>
					Товарный номер: {from.index},<br />
					Сколько стоит и название :3 : {from.value}
				</div>
			</div>
		</div>
	);
}

export default ItemDescription;