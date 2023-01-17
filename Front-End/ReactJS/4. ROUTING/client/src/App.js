import { Component } from "react";
import { Route, Routes } from "react-router-dom";

import postService from "./services/postService";

import Header from "./components/Header/Header";
import Main from "./components/Main/Main";
import Menu from "./components/Menu/Menu";
import "./App.css";
import About from "./components/About/About";
import ContactUs from "./components/ContactUs/ContactUs";
import Details from "./components/Details/Details";

class App extends Component {
    constructor(props) {
        super(props);

        this.state = {
            posts: [],
            selectedPost: null,
        };
    }

    componentDidMount() {
        postService.getAll().then((posts) => {
            this.setState((oldState) => (oldState.posts = posts));
        });
    }

    onMenuItemClick(id) {
        this.setState((oldState) => (oldState.selectedPost = id));
    }

    getPosts() {
        if (!this.state.selectedPost) {
            return this.state.posts;
        } else {
            return [this.state.posts.find((x) => x.id == this.state.selectedPost)];
        }
    }

    render() {
        return (
            <div className="app">
                <Header />
                <div className="container">
                    <Menu onMenuItemClick={this.onMenuItemClick.bind(this)} />

                    <Routes>
                            <Route index element={<Main posts={this.getPosts()} />} />
                            <Route path="about" element={<About />} />
                            <Route path="contact-us" element={<ContactUs />} />
                            <Route path="details/:name/:id?" element={<Details />} />
                            <Route path="*" element={<h1>Error page</h1>} />
                    </Routes>
                </div>
            </div>
        );
    }
}

export default App;
