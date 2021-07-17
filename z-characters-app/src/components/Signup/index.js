import React, { useState } from 'react';
import { Link, Redirect } from 'react-router-dom';
import { connect } from 'react-redux'

import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faUser, faLock, faExclamationTriangle, faEye, faEyeSlash, faIdCard, faBook, faCamera, faArrowLeft } from '@fortawesome/free-solid-svg-icons';
import { Form, Button, Figure, Alert } from 'react-bootstrap';
import './signup.scss';

import * as LoginActions from '../../store/actions/login'

import Logo from '../../assets/images/zaion_logo.png';

const Signup = ({ dispatch }) => {
    const [username, setUsername] = useState("");
    const [senha, setPassword] = useState("");
    const [cSenha, setCPassword] = useState("");
    const [nomeJogador, setNomeJogador] = useState("");
    const [descricao, setDescricao] = useState("");
    const [urlImagem, setUrlImagem] = useState("");

    const [user, setUser] = useState();
    const [erro, setErro] = useState('');
    const [visible, setVisibility] = useState(faEyeSlash);
    const [passVisibility, setPassVisibility] = useState("password");


    function mostrarSenha() {
        if (passVisibility === "password") {
            setPassVisibility("text");
            setVisibility(faEye)
        } else {
            setPassVisibility("password");
            setVisibility(faEyeSlash)
        }
    }

    const handleSubmit = async e => {
        e.preventDefault();
        if (senha !== cSenha) {
            setErro("As senhas não coincidem!")
        }
        const userForm = { username, senha, nomeJogador, descricao, urlImagem };

        await fetch(`http://localhost:5000/home/signup`, {
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
                        console.log('Nome de usuário já ultilizado ou servidor off-line.');
                        setErro("Nome de usuário já ultilizado ou servidor off-line.");
                    }
                })
            .catch(function (error) {
                console.log('There has been a problem with your fetch operation: ' + error.message);
            })
    }

    return (
        user ? <Redirect to="/" /> :
            <div className="loginWindow">
                <Form onSubmit={handleSubmit} className="signupForm">
                    <table>
                        <tbody>
                            <tr>
                                <td rowspan="3" width="20%">
                                    <Figure className="centralized">
                                        <Figure.Image
                                            className="logo"
                                            alt="Logo Zaion"
                                            src={Logo}
                                        />
                                    </Figure>
                                </td>
                                <td width="10%">
                                    <FontAwesomeIcon icon={faUser} className="icon" style={{ fontSize: "20" }} />
                                </td>
                                <td colspan="3">
                                    <Form.Control type="text" placeholder="Username"
                                        value={username} onChange={({ target }) => setUsername(target.value)} />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <FontAwesomeIcon icon={faIdCard} className="icon" style={{ fontSize: "20" }} />
                                </td>
                                <td colspan="3">
                                    <Form.Control type="text" placeholder="Full Name"
                                        value={nomeJogador} onChange={({ target }) => setNomeJogador(target.value)} />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <FontAwesomeIcon icon={faLock} className="icon" style={{ fontSize: "20" }} />
                                </td>
                                <td>
                                    <Form.Control type={passVisibility} placeholder="Password"
                                        value={senha} onChange={({ target }) => setPassword(target.value)} className="senha" />
                                </td>
                                <td>
                                    <Form.Control type={passVisibility} placeholder="Confirm Password"
                                        value={cSenha} onChange={({ target }) => setCPassword(target.value)} />
                                </td>
                                <td width="7%">
                                    <FontAwesomeIcon icon={visible} className="icon" style={{ fontSize: "20" }} onClick={mostrarSenha} />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <Button variant="light" className="btnSignup" type="submit">Cadastrar</Button>
                                </td>
                                <td>
                                    <FontAwesomeIcon icon={faBook} className="icon" style={{ fontSize: "20" }} />
                                </td>
                                <td colspan="2">
                                    <Form.Control as="textarea" aria-label="Description" value={descricao}
                                        onChange={({ target }) => setDescricao(target.value)} />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <Link to="/login"><FontAwesomeIcon icon={faArrowLeft} className="icon" style={{ marginRight: 5 }} />
                                        Voltar ao login</Link>
                                </td>
                                <td>
                                    <FontAwesomeIcon icon={faCamera} className="icon" style={{ fontSize: "20" }} />
                                </td>
                                <td colspan="2">
                                    <Form.Control type="file" className="imgFileButton"
                                        value={urlImagem} onChange={({ target }) => setUrlImagem(target.value)} />
                                </td>
                            </tr>
                        </tbody>
                    </table>
                    {erro ? <Alert sm="9" className="alertErro" variant='danger'>
                        <FontAwesomeIcon icon={faExclamationTriangle} className="icon" style={{ marginRight: 5 }} />
                        {erro}</Alert> :
                        <></>}
                </Form>
            </div>
    )

};
export default connect()(Signup);