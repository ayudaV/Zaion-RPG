import { Redirect } from 'react-router-dom';
import { connect } from 'react-redux';

/*
import React, { useState } from 'react';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faEnvelope, faLock, faExclamationTriangle, faEye, faEyeSlash } from '@fortawesome/free-solid-svg-icons';
import { Form, Button, Figure, Col, Alert } from 'react-bootstrap';
import Logo from '../../assets/images/zaion_logo.png';
*/

import './homePage.scss';


const HomePage = ({ user }) => {
    console.log(user)
    var idJogador = user.idJogador
    var username = user.username
    return (
        idJogador !== "null" ? <div>{username}</div> :
        <Redirect to="/login" />
    )

};
export default connect(state => ({
    user: state.login.user,
}))(HomePage);