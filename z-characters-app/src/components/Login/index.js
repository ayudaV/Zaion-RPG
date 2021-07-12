import React, { useState } from 'react';
import { Link, Redirect } from 'react-router-dom';
import { connect } from 'react-redux'

import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faEnvelope, faLock, faExclamationTriangle } from '@fortawesome/free-solid-svg-icons';
import { Form, Button } from 'react-bootstrap';

import * as LoginActions from '../../store/actions/login'

import Logo from '../../assets/images/zaion_logo.png';

const Login = ({ dispatch }) => {
    const [email, setUsuario] = useState("");
    const [senha, setPassword] = useState("");
    const [user, setUser] = useState();
    const [erro, setErro] = useState('');

    function mostrarSenha() {
        var x = document.getElementById("senha");

        if (x.type === "password") {
            x.type = "text";
        } else {
            x.type = "password";
        }
    }

    const handleSubmit = async e => {
        e.preventDefault();

        const userForm = { email, senha };

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
            <Form onSubmit={handleSubmit}>
                <Form.Group controlId="formBasicEmail">
                    <FontAwesomeIcon icon={faEnvelope} className="icon" />
                    <Form.Label>Email address</Form.Label>
                    <Form.Control type="email" placeholder="Enter email" />
                </Form.Group>

                <Form.Group controlId="formBasicPassword">
                    <FontAwesomeIcon icon={faLock} className="icon" />
                    <Form.Label>Password</Form.Label>
                    <Form.Control type="password" placeholder="Password" value={email} onChange={({ target }) => setUsuario(target.value)} placeholder="E-mail" pattern=".+@" />
                </Form.Group>
                <Form.Group controlId="formBasicCheckbox" value={senha} onChange={({ target }) => setPassword(target.value)} placeholder="Senha" id="senha" >
                    <Form.Check type="checkbox" label="Check me out" onClick={mostrarSenha} />
                </Form.Group>
                <Button variant="primary" type="submit">
                    Submit
                </Button>
            </Form>
    )

};
export default connect()(Login);