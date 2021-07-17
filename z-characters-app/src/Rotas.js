import React, { Component } from 'react';
import { Switch, Route, Redirect } from 'react-router';
import HomePage from './components/HomePage';
import Login from './components/Login';
import Signup from './components/Signup';

export default class Rotas extends Component {
    render() {
        return (
            <Switch>
                <Route exact  path="/" component={props => <HomePage {...props} />} />
                <Route exact path="/login" component={props => <Login {...props} />} />
                <Route exact path="/signup" component={props => <Signup {...props} />} />

                <Redirect from='*' to='/' />
            </Switch>
        )
    }
}