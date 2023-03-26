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

			paddingTop: '50px',

			backgroundColor: 'red',
		},
		nav : {
			width: '100%',
			height: '50px',


			fontSize: '27px',
			fontFamily: 'Arial',
			backgroundColor: 'red',

			display: 'flex',
			justifyContent: 'center',
			alignItems: 'center',

			position: 'fixed',
			top: '70px',
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

		},
		comments : {
			width: '100%',
			minHeight: '35px',
			paddingTop: '25px',

			backgroundColor: 'white',
		},
		comment : {
			width: 'calc(100% - 60px)',
			minHeight: '30px',
			padding: '15px',
			margin: '15px',

			backgroundColor: 'blue',

			display: 'flex',
			alignItems: 'center',
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
					<img src={from.image} alt="" style={css.picture}/>
				</div>
				<div style={css.description}>
					<h2>{from.name}</h2>
					Price: {from.price}<br />
					Rate: {from.rate}<br />
					Description: {from.description}<br />
					Section: {from.section}<br />
				</div>
			</div>
			<div style={css.comments}>
				{from.comments[0]?.name === undefined ? <div style={{color: 'black', textAlign: 'center'}}>No one comment this goods</div> :
					from.comments.map((value, index)=>
					<div style={css.comment}><span style={{color: 'red'}}>{value.name}</span>: {value.text}</div>
					)}
			</div>
		</div>
	);
}

export default ItemDescription;