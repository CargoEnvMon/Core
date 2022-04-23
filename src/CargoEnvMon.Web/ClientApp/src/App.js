import React, {Component} from 'react';
import {Route} from 'react-router';
import {Layout} from './components/Layout';
import {Main} from "./components/Main";

import './custom.css'
import {AppContextProvider} from "./AppContext";

export default class App extends Component {
  static displayName = App.name;

  render() {
    return (
      <AppContextProvider>
        <Layout>
          <Route exact path='/' component={Main}/>
        </Layout>
      </AppContextProvider>
    );
  }
}
