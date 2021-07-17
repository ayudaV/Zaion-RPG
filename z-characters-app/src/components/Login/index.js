import React, { useState } from 'react';
import { Link, Redirect } from 'react-router-dom';
import { connect } from 'react-redux'

import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faUser, faLock, faExclamationTriangle, faEye, faEyeSlash } from '@fortawesome/free-solid-svg-icons';
import { Form, Button, Figure, Alert } from 'react-bootstrap';
import './login.scss';

import * as LoginActions from '../../store/actions/login'

import Logo from '../../assets/images/zaion_logo.png';

const Login = ({ dispatch }) => {
    const [username, setUsername] = useState("");
    const [senha, setPassword] = useState("");
    const [user, setUser] = useState();
    const [erro, setErro] = useState('');
    const [visible, setVisibility] = useState(faEyeSlash);


    function mostrarSenha() {
        var x = document.getElementById("senha");
        if (x.type === "password") {
            x.type = "text";
            setVisibility(faEye)
        } else {
            x.type = "password";
            setVisibility(faEyeSlash)
        }
    }

    const handleSubmit = async e => {
        e.preventDefault();

        const userForm = { username, senha };

        await fetch(`http://localhost:5000/home/login`, {
            method: "POST",
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(userForm)
        })
            .then(
                resp => {
                    if (resp.ok) {
                        // console.log(resp.json());
                        resp.json().then((data) => {
                            console.log('data.user: ' + data.user);
                            setUser(data);
                            dispatch(LoginActions.setLogin(data.user))
                        })
                    }
                    else {
                        console.log('Usuário inexistente ou servidor off-line.');
                        setErro("Usuário inexistente ou servidor off-line.");
                    }
                })
            .catch(function (error) {
                console.log('There has been a problem with your fetch operation: ' + error.message);
            })
    }

    return (
        user ? <Redirect to="/" /> :
            <div className="loginWindow">
                <Form onSubmit={handleSubmit} className="loginForm">
                    <Figure className="centralized">
                        <Figure.Image
                            className="logo"
                            alt="Logo Zaion"
                            src={Logo}
                        />
                    </Figure>
                    <table>
                        <tbody>
                            <tr>
                                <td>
                                    <FontAwesomeIcon icon={faUser} className="icon" style={{ fontSize: "20" }} />
                                </td>
                                <td>
                                    <Form.Control type="text" placeholder="Username"
                                        value={username} onChange={({ target }) => setUsername(target.value)} />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <FontAwesomeIcon icon={faLock} className="icon" style={{ fontSize: "20" }} />
                                </td>
                                <td>
                                    <Form.Control type="password" placeholder="Password"
                                        value={senha} onChange={({ target }) => setPassword(target.value)} id="senha" />
                                </td>
                                <td width="10%">
                                    <FontAwesomeIcon icon={visible} className="icon" style={{ fontSize: "20" }} onClick={mostrarSenha}/>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                    <Button variant="light" className="btnLogin" type="submit">Login</Button>

                    {erro ? <Alert sm="9" className="alertErro" variant='danger'>
                        <FontAwesomeIcon icon={faExclamationTriangle} className="icon" style={{ marginRight: 5 }} />
                        {erro}</Alert> :
                        <></>}

                    <p className="cadastro">Não possui uma conta? <Link to="/signup">Cadastre-se!</Link></p>
                </Form>
            </div>
    )

};
export default connect()(Login);