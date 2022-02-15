import Table from "./PeopleList.jsx";



class People extends React.Component {
    render() {
        console.log("load app")
        return (
            
            <div>
            <Table />
            </div>
                
        );
    }
}
 
ReactDOM.render(<People />, document.getElementById('content'));

