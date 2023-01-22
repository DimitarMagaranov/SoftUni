import { Component } from "react";

import postService from './services/postService';

import Header from "./components/Header/Header";
import Main from "./components/Main/Main";
import Menu from "./components/Menu/Menu";
import "./App.css";

class App extends Component {
  constructor(props) {
    super(props);
    
    this.state = {
      posts: [],
      selectedPost: null
    }
  }

    componentDidMount() {
      postService.getAll()
        .then(posts => {
            this.setState(oldState => (oldState.posts = posts))
        })
    }

    onMenuItemClick(id) { 
       this.setState(oldState => (oldState.selectedPost = id));
    }

    getPosts() {
      if (!this.state.selectedPost) {
        return this.state.posts;
      } else {
        return [this.state.posts.find(x => x.id == this.state.selectedPost)];
      }
    }

    render() {
        return (
            <div className="app">
                <Header />
                <div className="container">
                    <Menu onMenuItemClick={this.onMenuItemClick.bind(this)}/>
                    <Main posts={this.getPosts()} />
                </div>
            </div>
        );
    }
}

export default App;
