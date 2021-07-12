import React, { Component } from 'react';
import { Switch, Route, Redirect } from 'react-router';
import Login from './components/Login';

export default class Rotas extends Component {
    render() {
        return (
            <Switch>
                <Route exact path="/" component={Login} />
                <Redirect from='*' to='/' />
            </Switch>
        )
    }
}