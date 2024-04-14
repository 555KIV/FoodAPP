import { useState } from "react";

export default function LoadUsersBtn() {
  const [users, setUsers] = useState();
  const getUsers = async () => {
    const response = await fetch("api/users", {
      method: "GET",
    });
    const responseJSON = await response.json();
    setUsers(responseJSON);
  };
  return (
    <>
      <div className="App">
        <button onClick={getUsers}>Загрузка пользователей</button>
        <ul>{users}</ul>
      </div>
    </>
  );
}
