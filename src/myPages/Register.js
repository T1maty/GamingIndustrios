import {useState} from 'react';
import image from "../image";

const Register = () => {
	// NOT MY
	const [email, setEmail] = useState('yabl@yabl.com');
	const [password, setPassword] = useState('123123');
	const handleEmailChange = (e) => {
		setEmail(e.target.value)
	}
	const handlePasswordChange = (e) => {
		setPassword(e.target.value)
	}
	const handleRegister = () => {
		if (validateEmail() && valudatePassword()) {
			/*registerUserApi(email, password)
				.then(response => console.log(response))
				.catch(error => console.log(error))*/
		} else {
			console.log('fff')
		}
	}
	const handleLogin = () => {
		if (validateEmail() && valudatePassword()) {
			/*loginUserApi(email, password)
				.then(response => console.log(response))
				.catch(error => console.log(error))*/
		} else {
			console.log('rfr')
		}
	}
	const handleHealth = () => {
		/*authHealthCheckApi()
			.then(response => console.log(response))
			.catch(error => console.log(error));*/
	}
	// ^ NOT MY
	// MY
	const validateEmail = () => {
		if (email === '') {
			return false
		} else if (/[!#$%^&*()<>,/{}/~"№:;'|]/.test(email)) {
			return false
		} else {
			let emailSplit = email.split('@')[1]
			if (email.split('@')[2] !== undefined) {
				return false
			} else if (emailSplit.split('.')[2] !== undefined) {
				return false
			}
		}
		return true

	}
	const valudatePassword = () => {
		if (password.length < 6) {
			return false
		} else if (/[!#$%^&*()<>,/{}/~"№:;'|.@]/.test(password)) {
			return false
		}
		return true
	}

	const css = {
		body : {
			width: '100vw',
			minHeight: '100vh',

			backgroundImage: `url(${image.wallpaper})`,
			backgroundSize: 'cover',

			display: 'flex',
		},
		content : {
			width: '60vw',
			height: 'calc(70vh - 60px)',

			maxWidth: '500px',
			maxHeight: '500px',
			minWidth: '300px',
			minHeight: '350px',


			padding: '50px 50px 0 50px',

			margin: 'auto',

			backgroundColor: 'rgb(219, 219, 219, 70%)',
			backdropFilter: 'blur(8px)',
			border: '2px solid rgb(219, 219, 219, 40%)',
			borderRadius: '40px',

			display: 'flex',
			flexDirection: 'column',
			justifyContent: 'space-between'


		},
		headerText : {
			fontSize: '36px',
			fontWeight: '700',
		},
		flexButton : {
			width: '100%',

			marginBottom: '60px',

			display: 'flex',
			justifyContent: 'space-around',

		},
		buttonReg : {
			width: '150px',
			height: '60px',

			background: 'rgb(90, 224, 81, 90%)',
			color: 'white',
			fontSize: '28px',
			border: '2px solid rgb(90, 224, 81, 85%)',
			borderRadius: '10px',
			transition: '0.3s'
		},
		buttonRegHover : {
			width: '150px',
			height: '60px',

			background: 'rgb(90, 224, 81, 100%)',
			color: 'white',
			fontSize: '32px',
			border: '2px solid rgb(90, 224, 81, 85%)',
			borderRadius: '12px',
			transition: '0.3s'
		},
		buttonRegActive : {
			width: '150px',
			height: '60px',

			background: 'rgb(73, 179, 66, 100%)',
			color: 'white',
			fontSize: '32px',
			border: '2px solid rgb(64, 156, 58, 85%)',
			borderRadius: '12px',
			boxShadow: 'inset 0 0 3px rgb(64, 156, 58, 85%)',
			transition: '0.3s'
		},
		buttonLog : {
			width: '150px',
			height: '60px',

			background: 'rgb(227, 203, 23, 90%)',
			color: 'white',
			fontSize: '28px',
			border: '2px solid rgb(227, 203, 23, 85%)',
			borderRadius: '10px',
			transition: '0.3s'
		},
		buttonLogHover : {
			width: '150px',
			height: '60px',

			background: 'rgb(227, 203, 23, 100%)',
			color: 'white',
			fontSize: '32px',
			border: '2px solid rgb(227, 203, 23, 85%)',
			borderRadius: '12px',
			transition: '0.3s'
		},
		buttonLogActive : {
			width: '150px',
			height: '60px',

			background: 'rgb(204, 165, 22, 100%)',
			color: 'white',
			fontSize: '32px',
			border: '2px solid rgb(191, 161, 10, 85%)',
			borderRadius: '12px',
			boxShadow: 'inset 0 0 3px rgb(191, 161, 10, 85%)',
			transition: '0.3s'
		},
		inputDiv : {
			width: '100%',
			height: '90px',

			display: 'flex',
			flexDirection: 'column',
			justifyContent: 'space-between',
		},
		inputLabel : {
			fontSize: '24px',
		},
		inputInput : {
			height: '40px',

			background: 'rgb(201, 201, 199, 100%)',
			border: '1px solid rgb(201, 201, 199, 95%)',
			outline: 'none',
			color: 'white',
			fontSize: '20px',
			borderRadius: '10px',
			transition: '0.3s'
		},
		inputInputActive : {
			height: '40px',

			background: 'rgb(201, 201, 199, 70%)',
			border: '1px solid rgb(201, 201, 199, 95%)',
			outline: 'none',
			color: 'white',
			fontSize: '20px',
			boxShadow: '0 0 10px rgb(201, 201, 199, 100%)',
			borderRadius: '7px',
			transition: '0.3s'
		},
		health : {
			width: '100px',
			height: '50px',

			background: 'rgb(201, 201, 199, 70%)',
			border: '1px solid rgb(201, 201, 199, 95%)',
			fontSize: '20px',
			position: 'absolute',
			right: '20px',
			bottom: '20px',
		},
	}
	const [registerButton, setRegisterButton] = useState(css.buttonReg)
	const [loginButton, setLoginButton] = useState(css.buttonLog)
	const [inputOne, setInputOne] = useState(css.inputInput)
	const [inputTwo, setInputTwo] = useState(css.inputInput)

	// ^ MY
	return (
		<div style={css.body}>
			<div style={css.content}>
				<text style={css.headerText}>Register</text>
				<div>
					<div style={css.inputDiv}>
						<label style={css.inputLabel}>Email: </label>
						<input type="email" value={email} placeholder="Email"
									 style={inputOne} onFocus={_ => setInputOne(css.inputInputActive)}
									 onBlur={_ => setInputOne(css.inputInput)}
									 onChange={(e) => handleEmailChange(e)} />
					</div>
					<br />
					<br />
					<div style={css.inputDiv}>
						<label style={css.inputLabel}>Password: </label>
						<input type="password" value={password} placeholder="Password"
									 style={inputTwo} onFocus={_ => setInputTwo(css.inputInputActive)}
									 onBlur={_ => setInputTwo(css.inputInput)}
									 onChange={(e) => handlePasswordChange(e)} />
					</div>
				</div>
				<br />
				<div style={css.flexButton}>
					<button type="submit" style={registerButton}
									onMouseEnter={_ => setRegisterButton(css.buttonRegHover)}
									onMouseLeave={_ => setRegisterButton(css.buttonReg)}
									onMouseUp={_ => setRegisterButton(css.buttonRegHover)}
									onMouseDown={_ => setRegisterButton(css.buttonRegActive)}
									onClick={() => handleRegister()}
					>Register</button>

					<button type="submit" style={loginButton}
									onMouseEnter={_ => setLoginButton(css.buttonLogHover)}
									onMouseLeave={_ => setLoginButton(css.buttonLog)}
									onMouseUp={_ => setLoginButton(css.buttonLogHover)}
									onMouseDown={_ => setLoginButton(css.buttonLogActive)}
									onClick={() => handleLogin()}
					>Login</button>
				</div>
			</div>
			<button onClick={() => handleHealth()} type="submit"
							style={css.health}>Health</button>
		</div>
	)
}

export default Register;