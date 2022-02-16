const routes = {
    index: 0,
    details: 1
}

class People extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            people: [],
            route: routes.index,
            personId: null,
            isLoaded: false
        };
    }


    render() {
        console.log("load app");
        if (this.state.route !== routes.details) {
            return (
                <div className="people">
                    <Table
                        people={this.state.people}
                        isLoaded={this.state.isLoaded}
                        onPersonDetails={this.personDetails}
                    />
                    <CreateForm handleSubmit={this.handleSubmit} />
                </div>
            );
        } else {
            return (
                <div>
                    <div>
                        <button className={"btn btn-primary"} onClick={() => this.back()}>Back</button>
                    </div>
                    <h2>Details</h2>
                    <PersonDetails onPersonDelete={this.personDelete} personId={this.state.personId} />
                </div>
            );
        }
    }

    componentDidMount() { this.getPeople() }
    getPeople = () => {
        fetch("/React/GetPeople").then(response => response.json())
            .then((result1) => {
                this.setState({
                    isLoaded: true,
                    people: result1
                })
            });
    }

    back = () => {
        this.setState({
            route: routes.index
        })
    }

    personDetails = (id) => {
        this.setState({
            route: routes.details,
            personId: id
        });
    }

    personDelete = (id) => {
        const thatId = id;
        fetch("/React/DeletePerson/" + id, { method: 'DELETE' })
            .then(() => this.setState({
                route: routes.index,
                people: this.state.people.filter(function (person) {
                    return person.personId !== thatId
                })
            }));
    }

    handleSubmit = (person) => {
        const data = new FormData();
        data.append('name', person.name);
        data.append('phone', person.phone);
        data.append('cityId', person.cityId);
        for (var i = 0; i < person.languages.length; i++) {
            data.append("languages[]", person.languages[i]);
        }
        //data.append('languageId', person.languageId);
        fetch("/React/CreatePerson",
            { method: "Put", body: data })
            .then((response) => response.json())
            .then((person) => {
                this.setState(state => ({
                    people: state.people.concat(person),
                }))
            })
    }

}
class TableHeader extends React.Component {
    render() {
        return (
            <thead>
                <tr>
                    <th>Name <button className={"btn btn-sm"} onClick={this.props.sortTable}>&#8645;</button></th>
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
                            <tr key={person.personId}>
                                <td>{person.name} </td>
                                <td>{person.phone}</td>
                                <td><button className={"btn btn-primary"} onClick={() => this.props.onPersonDetails(person.personId)}>SHOW</button></td>
                            </tr>
                    )
                }
            </tbody>
        );
    }
}
class Table extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            sortDirection: 0
        };
    }
    render() {
        if (!this.props.isLoaded) {
            return <div>Loading table...</div>
        } else {
            return (
                <table className="table table-bordered">
                    <TableHeader sortTable={this.sortTable} />
                    <TableBody onPersonDetails={this.props.onPersonDetails} people={this.props.people} />
                </table>
            );
        }
    }

    sortTable = () => {
        let columnToSort = 'name';
        let sortDirection = this.state.sortDirection === -1 ? 1 : -1;

        this.props.people.sort((x1, x2) => x1[columnToSort] < x2[columnToSort] ? -1 * sortDirection : sortDirection);
        this.setState({
            sortDirection
        });
    }
}

//--------- form --------- //

class CitySelect extends React.Component {
    render() {
        return (
            <select id={this.props.id} name={this.props.name} className={"form-select"} onChange={this.props.onChange}
                required>
                <option value={""}>Select</option>
                {
                    this.props.data.map(country =>
                        <optgroup key={country.name} label={country.name}>
                            {
                                country.cities.map(city =>

                                    <option key={city.id} value={city.id}>{city.name}</option>
                                )
                            }
                        </optgroup>
                    )
                }
            </select>
        )
    }
}
class DataSelect extends React.Component {

    render() {
        console.log(this.props)
        return (
            <select multiple={this.props.multiple} id={this.props.Id} name={this.props.Name} className={"form-control"} onChange={this.props.onChange} required>
                <option value={""}>Select</option>
                {
                    this.props.data.map(item =>
                        <option key={item.id} value={item.id}>{item.name}</option>
                    )
                }
            </select>
        );
    }
}

class CreateForm extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            name: '',
            phone: '',
            cityId: '',
            languageId:'',
            isLoaded: false
        };

        this.handleSubmit = this.handleSubmit.bind(this);
        this.handleNameChange = this.handleNameChange.bind(this);
        this.handlePhoneChange = this.handlePhoneChange.bind(this);
        this.handleCityChange = this.handleCityChange.bind(this);
        this.handleLanguageChange = this.handleLanguageChange.bind(this);
    }

    render() {
        if (!this.state.isLoaded) {
            return <div>Loading create form...</div>
        } else {
            return (
                <form onSubmit={this.handleSubmit}>
                    <div className={"mb-3"}>
                        <label htmlFor={"Name"}>Name</label>
                        <input id={"name"} name={"name"} type={"text"} className={"form-control"}
                            onChange={this.handleNameChange} required />
                    </div>
                    <div className={"mb-3"}>
                        <label htmlFor={"phone"}>Phone</label>
                        <input id={"phone"} name={"phone"} type={"text"} className={"form-control"}
                            onChange={this.handlePhoneChange} required />
                    </div>
                    <div className={"mb-3"}>
                        <label htmlFor={"cityId"}>City</label>
                        <CitySelect multiple={false} id={"cityId"} name={"cityId"} data={this.state.cityList}
                            onChange={this.handleCityChange} />
                    </div>
                    <div className={"mb-3"}>
                        <label htmlFor={"languageId"}>Language</label>
                        <DataSelect multiple={true} id={"languageId"} name={"languageId"} data={this.state.languageList}
                            onChange={this.handleLanguageChange} />
                    </div>
                    <div className={"mb-3"}>
                        <button type={"submit"} className={"mb-3 btn btn-primary"}>Add Person</button>
                    </div>
                </form>
            );
        }
    }

    handleNameChange(e) {
        this.setState({ name: e.target.value });
    }

    handleCityChange(e) {
        //console.log(e.target.value)
        this.setState({ cityId: e.target.value });
    }
    handleLanguageChange(e) {
        this.setState({ languageId: e.target.value });
    }

    handlePhoneChange(e) {
        this.setState({ phone: e.target.value });
    }

    handleSubmit(e) {
        e.preventDefault();
        this.props.handleSubmit({
            name: this.state.name,
            phone: this.state.phone,
            cityId: this.state.cityId,
            languageId: this.state.languageId
        });

        e.target.reset();
    }

    componentDidMount() {
        fetch("/React/GetFormData")
            .then(res => res.json())
            .then(
                (result) => {
                    this.setState({
                        isLoaded: true,
                        cityList: result.countries,
                        languageList: result.languages
                    })
                },
                (error) => {
                    this.setState({
                        isLoaded: true,
                        error
                    })
                }
            );
    }
    
}
//--------- end form --------- //

//--------- Details --------- //

class PersonDetailsTable extends React.Component {
    render() {
        const person = this.props.person;

        return (
            <table className="table">
                <thead>
                    <tr>
                        <th scope="col">#</th>
                        <th scope="col">Name</th>
                        <th scope="col">Phone</th>
                        <th scope="col">Language</th>
                        <th scope="col">City</th>
                        <th scope="col">Country</th>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td scope="col">{person.personId}</td>
                        <td scope="col">{person.name}</td>
                        <td scope="col">{person.phone}</td>
                        <td scope="col">{person.language.join(", ")}</td>
                        <td scope="col">{person.city}</td>
                        <td scope="col">{person.country}</td>
                    </tr>
                </tbody>
            </table>
        );
    }
}

class PersonDetails extends React.Component {
    state = {
        isLoaded: false,
        error: null,
        person: null
    }

    componentDidMount() {
        fetch("/React/GetPerson/" + this.props.personId)
            .then(res => res.json())
            .then(
                (result) => {
                    this.setState({
                        isLoaded: true,
                        person: result
                    })
                },
                (error) => {
                    this.setState({
                        isLoaded: true,
                        error
                    })
                }
            );
    }

    render() {
        if (!this.state.isLoaded) {
            return <div>Loading Person...</div>
        } else {
            return (
                <div>
                    <PersonDetailsTable person={this.state.person} />
                    <button className={"btn btn-danger"}
                        onClick={() => this.props.onPersonDelete(this.props.personId)}>Delete Person
                    </button>
                </div>
            );
        }
    }
}

ReactDOM.render(<People />, document.getElementById('content'));