import "../../css/modal.css";
import { useState } from "react";
import { sha256 } from "js-sha256";

export default function RegModal({ active, login, setActive }) {
  const [userName, setUserName] = useState("");
  const [pass, setPass] = useState("");
  const [confirmPass, setConfirmPass] = useState("");

  const createNewUser = async (event) => {
    event.preventDefault();
    if (confirmPass === pass) {
      document.querySelector(".error").style.display = "none";
      const sendObj = {
        username: userName,
        password: sha256(pass),
      };
      setActive(false);
      login(true);
      try {
        await fetch("api/auth/register", {
          method: "POST",
          headers: {
            Accept: "application/json",
            "Content-Type": "application/json",
          },
          body: JSON.stringify(sendObj)
        });
      } catch (err) {
        console.log(err);
      }
    } else {
      document.querySelector(".error").style.display = "flex";
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
        <legend>Регистрация</legend>
        <label className="error">Пароли не совпадают</label>
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
        <label>
          Подтвердите пароль:
          <input
            type="password"
            onChange={(e) => setConfirmPass(e.target.value)}
            required
          />
        </label>
        <button>Зарегистрироваться</button>
      </form>
    </div>
  );
}
