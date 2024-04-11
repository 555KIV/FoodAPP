import './App.css';
import {Component} from 'react';

class App extends Component {
  constructor() {
    super();
    this.state = {
      users: []
    }
  }

  getUsers = async () => {
    const response = await fetch(
      'api/users',
      {
        method: 'GET'
      }
    )

    const responseJSON = await response.json();
    this.setState({users: responseJSON})
  }

  render() {
    const users = this.state.users.map((item,index) => <li key={index}>{item.name}</li>)
    return (
      <div className="App">
        <button onClick={this.getUsers}>Загрузка пользователей</button>
        <ul>{users}</ul>
      </div>
    );
  }
}


export default App;
