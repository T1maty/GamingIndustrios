import {useEffect, useState} from 'react';



function Slider({value}) {
	const [updateSlider, setUpdateSlider] = useState(false)
	const [actualImage, setActualImage] = useState(0)
	useEffect(_=>{
		setInterval(_=>{
			setUpdateSlider(!updateSlider)
		}, 10000)
	}, [])


	const css = {
		body : {
			width: '100%',
			height: '400px',

			backgroundImage: `url(${value[actualImage]})`,
			backgroundSize: 'cover',
			position: 'relative',
		},
		arrow1 : {
			width: '35px',
			height: '35px',

			backgroundColor: 'grey',
			borderRadius: '100px',
			fontFamily: 'Arial',
			fontSize: '20px',
			color: 'white',
			cursor: 'default',

			display: 'flex',
			justifyContent: 'center',
			alignItems: 'center',

			position: 'absolute',
			top: '182.5px',
			left: '0',
		},
		arrow2 : {
			width: '35px',
			height: '35px',

			backgroundColor: 'grey',
			borderRadius: '100px',
			fontFamily: 'Arial',
			fontSize: '20px',
			color: 'white',
			cursor: 'default',

			display: 'flex',
			justifyContent: 'center',
			alignItems: 'center',

			position: 'absolute',
			top: '182.5px',
			right: '0',
		}
	}
	const arrow1Click =_=>{
		if (actualImage !== 0) {
			setActualImage(actualImage - 1)
		} else {
			setActualImage(value.length - 1)
		}
	}
	const arrow2Click =_=>{
		if (actualImage !== value.length - 1) {
			setActualImage(actualImage + 1)
		} else {
			setActualImage(0)
		}
	}
	useEffect(_=>{
		if (actualImage === value.length - 1) {
			setActualImage(0)
		} else {
			setActualImage(actualImage + 1)
		}
	},[updateSlider])

	return (
		<div style={css.body}>
			<div style={css.arrow1} onClick={_=>arrow1Click()}>{`${'<'}`}</div>
			<div style={css.arrow2} onClick={_=>arrow2Click()}>{`${'>'}`}</div>
		</div>
	);
}

export default Slider;