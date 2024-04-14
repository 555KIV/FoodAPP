import "../../css/modal.css";
import { useState } from "react";
import { sha256 } from "js-sha256";

export default function LoginModal({ active, setActive }) {
  const [userName, setUserName] = useState("");
  const [pass, setPass] = useState("");

  const createNewUser = async (event) => {
    event.preventDefault();
    const sendObj = {
      username: userName,
      password: sha256(pass),
    };
    try {
      const response = await fetch("api/auth/login", {
        method: "POST",
        headers: {
          Accept: "application/json",
          "Content-Type": "application/json",
        },
        body: JSON.stringify(sendObj)
      });
      console.log(response);
    } catch (err) {
      console.log(err);
    }
  };

  return (
    <div
      className={active ? "modal active" : "modal"}
      onClick={() => setActive(false)}
    >
      <form
        className="modalContent"
        method="post"
        onClick={(event) => event.stopPropagation()}
        onSubmit={createNewUser}
      >
        <legend>Вход</legend>
        <label>
          Введите имя пользователя:
          <input
            type="text"
            onChange={(e) => setUserName(e.target.value)}
            required
          />
        </label>
        <label>
          Введите пароль:
          <input
            type="password"
            onChange={(e) => setPass(e.target.value)}
            required
          />
        </label>
        <button>Войти</button>
      </form>
    </div>
  );
}
