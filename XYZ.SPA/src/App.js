import React from "react";
import { BrowserRouter as Router, Switch, Route, Link } from "react-router-dom";
import 'bootstrap/dist/css/bootstrap.min.css';
import './App.css';
// import Home from './home/home'
import Stocks from './stocks/stocks'
import CreateUser from './user/create-user/createuser'

export default function App() {
  return (
    <div className="main">
      <Router>
        <nav className="navbar navbar-expand-lg bg-light">
          <div className="container-fluid">
            <a className="navbar-brand" href="#">React App</a>
            <button className="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
              <span className="navbar-toggler-icon"></span>
            </button>
            <div className="collapse navbar-collapse" id="navbarSupportedContent">
              <ul className="navbar-nav me-auto mb-2 mb-lg-0">
                <li className="nav-item">
                  <Link className="nav-link active" aria-current="page" to="/">Home</Link>
                </li>
                <li className="nav-item">
                  <Link className="nav-link" to="/about">About</Link>
                </li>
                <li className="nav-item">
                  <Link className="nav-link" to="/users">Users</Link>
                </li>
                <li className="nav-item">
                  <Link className="nav-link" to="/user/create">Create Users</Link>
                </li>
                <li className="nav-item">
                  <Link className="nav-link" to="/stocks">Stocks</Link>
                </li>
              </ul>
            </div>
          </div>
        </nav>
        <div className="container-fluid">
          <Switch>
            <Route path="/users" name="User" component={Users} />
            <Route path="/user/create" name="CreateUser" component={CreateUser} />
            <Route path="/about" name="Home" component={About} />
            <Route path="/stocks" name="stocks" component={Stocks} />
            <Route path="/" name="Home" component={Home} />
          </Switch>
        </div>
      </Router>
    </div>
  );
}

function Home() {
  return <h2>My Home</h2>;
}

function About() {
  return <h2>About</h2>;
}

function Users() {
  return <h2>Users</h2>;
}
