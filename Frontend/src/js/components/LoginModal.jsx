import "../../css/modal.css";
import { useState } from "react";
import { sha256 } from "js-sha256";

export default function LoginModal({
  setCookie,
  active,
  setActive,
  setAuth,
  setResponseUserName,
}) {
  const [userName, setUserName] = useState("");
  const [pass, setPass] = useState("");
  const [responseOk, setResponseOk] = useState(false);
  const [showErr, setShowErr] = useState(false);

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
      })
        .then((response) => {
          if (responseOk) {
            setResponseOk(true);
            setShowErr(false);
          } else {
            setResponseOk(false);
            setShowErr(true);
          }
          return response.json();
        })
        .then((data) => {
          setCookie("username", data.username, { maxAge: 43200 });
          setCookie("token", data.accessToken, { maxAge: 43200 });
          setResponseUserName(data.username);
          setAuth(true);
          setActive(false);
        });
    } catch (err) {
      console.log(err);
    }
  };

  return (
    <div
      className={active ? "modal active" : "modal"}
      onClick={() => {
        setActive(false);
        setShowErr(false);
      }}
    >
      <form
        className="modalContent"
        method="post"
        onClick={(event) => event.stopPropagation()}
        onSubmit={createNewUser}
      >
        <legend>Вход</legend>
        {!responseOk && showErr ? (
          <div className="logError">Проверьте введённые данные</div>
        ) : (
          <div></div>
        )}
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
