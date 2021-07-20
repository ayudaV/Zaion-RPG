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

    const [nomeImagem, setNomeImagem] = useState("");
    const [imgSrc, setImgSrc] = useState(Logo);
    const [arquivoImagem, setArquivoImagem] = useState();

    const [user, setUser] = useState();
    const [erro, setErro] = useState('');
    const [errors, setErrors] = useState({});
    const [visible, setVisibility] = useState(faEyeSlash);
    const [passVisibility, setPassVisibility] = useState("password");
    const role = 'jogador';

    function mostrarSenha() {
        if (passVisibility === "password") {
            setPassVisibility("text");
            setVisibility(faEye)
        } else {
            setPassVisibility("password");
            setVisibility(faEyeSlash)
        }
    }

    const showPreview = e => {
        if (e.target.files && e.target.files[0]) {
            let imageFile = e.target.files[0];
            const reader = new FileReader();
            reader.onload = x => {
                console.log(imageFile)
                setArquivoImagem(imageFile)
                setImgSrc(x.target.result)
            }
            reader.readAsDataURL(imageFile)
        }
        else {
            setArquivoImagem(null)
            setImgSrc(Logo)
        }
    }

    const handleSubmit = async e => {
        e.preventDefault();
        if (validate()) {
            const userForm = { username, senha, nomeJogador, nomeImagem, descricao, role, arquivoImagem };
            console.log(userForm.arquivoImagem)
            console.log(JSON.stringify(userForm))
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
        }else{
            console.log("Erro de validação!")
        }
    }

    const validate = () => {
        let temp = {};
        temp.username = username === "" ? false : true;
        temp.senha = senha === "" ? false : true;
        temp.cSenha = cSenha !== senha || cSenha === "" ? false : true;
        temp.nomeJogador = nomeJogador === "" ? false : true;
        setErrors(temp)
        return Object.values(temp).every(x => x === true)
    }
    
    const applyErrorClass = field => ((field in errors && errors[field] === false) ? ' invalid-field' : '')


    return (
        user ? <Redirect to="/" /> :
            <div className="loginWindow">
                <Form onSubmit={handleSubmit} className="signupForm">
                    <table>
                        <tbody>
                            <tr>
                                <td rowSpan="3" width="20%">
                                    <Figure className="centralized">
                                        <img src={imgSrc} className="logo" alt="Logo Zaion" />
                                    </Figure>


                                </td>
                                <td width="10%">
                                    <FontAwesomeIcon icon={faUser} className="icon" style={{ fontSize: "20" }} />
                                </td>
                                <td colSpan="3">
                                    <Form.Control type="text" placeholder="Username" className={applyErrorClass('username')}
                                        value={username} onChange={({ target }) => setUsername(target.value)} />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <FontAwesomeIcon icon={faIdCard} className="icon" style={{ fontSize: "20" }} />
                                </td>
                                <td colSpan="3">
                                    <Form.Control type="text" placeholder="Full Name" className={applyErrorClass('nomeJogador')}
                                        value={nomeJogador} onChange={({ target }) => setNomeJogador(target.value)} />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <FontAwesomeIcon icon={faLock} className="icon" style={{ fontSize: "20" }} />
                                </td>
                                <td>
                                    <Form.Control type={passVisibility} placeholder="Password" className={applyErrorClass('senha')}
                                        value={senha} onChange={({ target }) => setPassword(target.value)}/>
                                </td>
                                <td>
                                    <Form.Control type={passVisibility} placeholder="Confirm Password" className={applyErrorClass('cSenha')}
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
                                <td colSpan="2">
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
                                <td colSpan="2">
                                    <Form.Control type="file" className="imgFileButton" onChange={showPreview} />
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