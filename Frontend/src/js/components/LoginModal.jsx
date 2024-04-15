import "../../css/modal.css";
import { useState } from "react";
import { sha256 } from "js-sha256";

export default function LoginModal({
  active,
  setActive,
  setAuth,
  setResponseUserName,
}) {
  const [userName, setUserName] = useState("");
  const [pass, setPass] = useState("");

  const createNewUser = async (event) => {
    event.preventDefault();
    const sendObj = {
      username: userName,
      password: sha256(pass),
    };
    try {
      await fetch("api/auth/login", {
        method: "POST",
        headers: {
          Accept: "application/json",
          "Content-Type": "application/json",
        },
        body: JSON.stringify(sendObj),
      }).then((response) => {
        console.log(response);
        if (response.ok) {
          localStorage.setItem("token", response.body.accessToken);
          localStorage.setItem("userName", response.body.username);
          setAuth(true);
          setActive(false);
          setResponseUserName(response.body.username);
        }
        //localStorage.setItem("token", "123");
        //localStorage.setItem("userName", "Bob");
        //setActive(false);
        //setAuth(true);
      });
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
