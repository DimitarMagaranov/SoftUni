import { useParams, redirect } from "react-router-dom";
import { useState, useEffect, Component } from "react";

import CategoryNavigation from "./CategoryNavigation/CategoryNavigation";
import PetList from "../PetList/PetList";
import withRoouter from "../../hoc/withRouter";
import * as petService from "../../services/petService";

class Categories extends Component {
    constructor(props) {
        super(props);

        this.state = {
            pets: [],
            currCategory: 'All'
        };
    }

    componentDidMount() {
        petService.getAll().then(data => this.setState({ pets: data }));
        console.log(this.props.params.category);
    }

    componentDidUpdate() {
        if (this.state.currCategory !== this.props.params.category) {
            console.log(this.props.params.category);
            petService.getAll(this.props.params.category).then(data => {
                this.setState({ pets: data, currCategory: this.props.params.category})
            });
        }
    }

    render() {
        return (
            <section className="dashboard">
                <h1>Dashboard</h1>

                <CategoryNavigation />

                <PetList pets={this.state.pets} />
            </section>
        );
    }
}

export default withRoouter(Categories);
