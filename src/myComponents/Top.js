import React from 'react';

function Top(props) {
	const css = {
		body : {
			width: '100%',
			height: '70px',

			backgroundColor: 'red',

			display: 'flex',
			justifyContent: 'center',

			position: 'fixed',
			zIndex: '100',
			left: '0',
			top: '0',
		},
		bodyWorker : {
			marginTop: '70px',
		},
		logo : {
			width: '70px',
			height: '70px',

			backgroundColor: 'blue',
			cursor: 'pointer',

			position: 'absolute',
			top: '0',
			left: '0'
		},
		ul : {
			width: '380px',
			height: '70px',

			padding: '0',
			margin: '0',

			listStyleType: 'none',

			display: 'flex',
			justifyContent: 'space-between',
			alignItems: 'center'


		},
		li : {
			width: '110px',
			height: '30px',

			padding: '5px',

			backgroundColor: 'white',
			fontFamily: 'Arial',
			fontSize: '27px',
			borderRadius: '10px',
			cursor: 'pointer',


			display: 'flex',
			justifyContent: 'center',
			alignItems: 'center'
		}
	}
	return (
		<div style={css.bodyWorker}>
		<div style={css.body}>
			<div style={css.logo}>типа лого :3</div>
			<ul style={css.ul}>
				<li style={css.li}>Главная</li>
				<li style={css.li}>Товары</li>
				<li style={css.li}>О нас</li>
			</ul>
		</div>
		</div>
	);
}

export default Top;