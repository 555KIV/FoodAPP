import RegModal from "./RegModal";
import LoginModal from "./LoginModal";
import { useState } from "react";

export default function Auth({ auth, setAuth }) {
  const [regModalActive, setRegModalActive] = useState(false);
  const [loginModalActive, setLoginModalActive] = useState(false);
  const [responseUserName, setResponseUserName] = useState("Гость");
  document.addEventListener("DOMContentLoaded", () => {
    if (localStorage.getItem("token")) {
      setAuth(true);
      setResponseUserName(localStorage.getItem("userName"));
    }
  });

  return (
    <>
      <div className={!auth ? "authList authActive" : "authList"}>
        <button className="authItem" onClick={() => setLoginModalActive(true)}>
          Вход
        </button>
        <button className="authItem" onClick={() => setRegModalActive(true)}>
          Регистрация
        </button>
      </div>
      <RegModal
        active={regModalActive}
        login={setLoginModalActive}
        setActive={setRegModalActive}
      ></RegModal>
      <LoginModal
        setResponseUserName={setResponseUserName}
        setAuth={setAuth}
        active={loginModalActive}
        setActive={setLoginModalActive}
      ></LoginModal>
      <div className={auth ? "authUser authUserActive" : "authUser"}>
        Здравствуй, {responseUserName} |
        <button
          className="unAuthUserBtn"
          onClick={() => {
            setAuth(false);
            localStorage.removeItem("token");
            localStorage.removeItem("userName");
          }}
        >
          ×
        </button>
      </div>
    </>
  );
}
