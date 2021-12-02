import React from "react";
import { BrowserRouter as Router, Switch, Route, Link } from "react-router-dom";
import logo from './logo.svg';
import './App.css';
import Home from './home/home'
import Stocks from './stocks/stocks'

export default function App() {
  return (
    <div className="App">
      <Router>
        <div>
          <nav>
            <ul>
              <li>
                <Link to="/">Home</Link>
              </li>
              <li>
                <Link to="/about">About</Link>
              </li>
              <li>
                <Link to="/users">Users</Link>
              </li>
			   <li>
                <Link to="/stocks">Users</Link>
              </li>
            </ul>
          </nav>
          <header className="App-header">
            <img src={logo} className="App-logo" alt="logo" />
              <Switch>
                <Route path="/about">
                  <About />
                </Route>
                <Route path="/users">
                  <Users />
                </Route>
				<Route path="/stocks">
                  <Stocks />
                </Route>
                <Route path="/">
                  <Home />
                </Route>
              </Switch>
            </header>
        </div>
      </Router>
    </div>
  );
}

function About() {
  return <p><h2>About</h2></p>;
}

function Users() {
  return <p><h2>Users</h2></p>;
}
