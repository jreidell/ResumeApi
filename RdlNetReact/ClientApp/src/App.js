import React, { Component } from 'react';
import { Route } from 'react-router';
import { Home } from './components/Home';
import { ResView } from './components/ResView';
import { ResPdf } from './components/ResPdf';
import { ResPrint } from './components/ResPrint';

export default class App extends Component {
  displayName = App.name

  render() {
      return (
        <div>
            <Route exact path='/' component={Home} />
            <Route path='/resview' component={ResView} />
            <Route path='/pdf' component={ResPdf} />
            <Route path='/print' component={ResPrint} />
        </div>
    );
  }
}
