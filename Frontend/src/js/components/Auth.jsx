import RegModal from "./RegModal";
import LoginModal from "./LoginModal";
import { useEffect, useState } from "react";

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

  useEffect(() => {
    if (cookies.token) {
      setResponseUserName(cookies.username);
      setAuth(true);
    }
  }, [cookies.token, cookies.username, setAuth]);

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
