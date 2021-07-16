import React, { useState } from 'react';
import { Link, Redirect } from 'react-router-dom';
import { connect } from 'react-redux'

import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faEnvelope, faLock, faExclamationTriangle, faEye, faEyeSlash } from '@fortawesome/free-solid-svg-icons';
import { Form, Button, Figure, Col } from 'react-bootstrap';
import './login.scss';

import * as LoginActions from '../../store/actions/login'

import Logo from '../../assets/images/zaion_logo.png';

const Login = ({ dispatch }) => {
    const [email, setUsuario] = useState("");
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

        const userForm = { email, senha };

        await fetch(`http://localhost:5000/jogador/login`, {
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
                            console.log('data.user.email: ' + data.user.email);
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
                    <Form.Group>
                        <Form.Row controlId="formPlaintextPassword">
                            <Form.Label column sm="0.5">
                                <FontAwesomeIcon icon={faEnvelope} className="icon" style={{ fontSize: "20" }} />
                            </Form.Label>
                            <Col sm="9">
                                <Form.Control type="email" placeholder="Enter email"
                                    value={email} onChange={({ target }) => setUsuario(target.value)} />
                            </Col>
                        </Form.Row>
                    </Form.Group>

                    <Form.Group>
                        <Form.Row controlId="formPlaintextPassword">
                            <Form.Label column sm="0.5">
                                <FontAwesomeIcon icon={faLock} className="icon" style={{ fontSize: "20" }} />
                            </Form.Label>
                            <Col sm="9">
                                <Form.Control type="password" placeholder="Password"
                                    value={senha} onChange={({ target }) => setPassword(target.value)} id="senha" />
                            </Col>
                            <Col className="centralized" sm="1">
                                <FontAwesomeIcon icon={visible} className="icon" style={{margin:5}} onClick={mostrarSenha} />
                            </Col>
                        </Form.Row>
                    </Form.Group>

                    <Form.Group controlId="formBasicCheckbox">
                    </Form.Group>

                    <Button variant="light" className="btnLogin" type="submit">Login</Button>
                </Form>
            </div>
    )

};
export default connect()(Login);