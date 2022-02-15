////import { extend } from "jquery";
import * as React from "react";

//const { Component } = require("react");

class TableHeader extends React.Component {
    render() {
        return (
            <thead>
                <tr>
                <th>Name</th>
                <th>Phone</th> 
                <th>Details</th>
                </tr>
            </thead>
        );
    }
}
class TableBody extends React.Component {
    render() {
        return (
            <tbody>
                {
                    this.props.people.map(
                        person =>
                            <tr key={person.id}>
                            <td>{person.name} </td>
                            <td>{person.phone}</td>
                            
                        </tr>
                    )
                
                }
                
            </tbody>
        );
    }
}
class Table extends React.Component {

    state = {
        people: [],
        isLoaded: false
    };

    componentDidMount() {
        fetch("React/GetPeople").then(result => result.json())
            .then((result1) => {
                this.setState({
                    isLoaded: true,
                    people: result1
                })
            });
    }
    render() {
        return (
            <table className="table table-bordered">
                <TableHeader />
                <TableBody />
            </table>
        );
    }
}
export default Table;