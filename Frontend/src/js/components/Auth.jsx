import RegModal from "./RegModal";
import LoginModal from "./LoginModal";
import { useState } from "react";
import { useCookies } from "react-cookie";

export default function Auth({
  auth,
  setAuth,
  cookies,
  setCookie,
  removeCookie,
}) {
  const [regModalActive, setRegModalActive] = useState(false);
  const [loginModalActive, setLoginModalActive] = useState(false);
  const [responseUserName, setResponseUserName] = useState("Гость");

  window.addEventListener("DOMContentLoaded", () => {
    if (cookies.token) {
      setResponseUserName(cookies.username);
      setAuth(true);
    }
  });

  const enter = () => {
    if (cookies.token) {
      setResponseUserName(cookies.username);
      setAuth(true);
    } else {
      setLoginModalActive(true);
    }
  };

  return (
    <>
      <div className={!auth ? "authList authActive" : "authList"}>
        <button className="authItem" onClick={enter}>
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
        setCookie={setCookie}
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
            removeCookie("username");
            removeCookie("token");
          }}
        >
          ×
        </button>
      </div>
    </>
  );
}
