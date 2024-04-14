import "../../css/navBar.css";
import mainImg from "../../main.png";
import RegModal from "./RegModal";
import LoginModal from "./LoginModal";
import { useState } from "react";

export default function Header() {
  const [regModalActive, setRegModalActive] = useState(false);
  const [loginModalActive, setLoginModalActive] = useState(false);
  return (
    <>
      <img src={mainImg} alt="" className="mainImg" />
      <header>
        <nav className="navBar">
          <div className="navRouting">
            <a className="routingItem" href="http://localhost:3000/">
              Главная
            </a>
            <a className="routingItem" href="http://localhost:3000/">
              Анкета
            </a>
            <a className="routingItem" href="http://localhost:3000/">
              Новый рецепт
            </a>
          </div>
          <div className="authList">
            <button
              className="authItem"
              onClick={() => setLoginModalActive(true)}
            >
              Вход
            </button>
            <button
              className="authItem"
              onClick={() => setRegModalActive(true)}
            >
              Регистрация
            </button>
          </div>
        </nav>
        <div className="title">Что</div>
        <div className="title">готовим?</div>
      </header>
      <RegModal
        active={regModalActive}
        login={setLoginModalActive}
        setActive={setRegModalActive}
      ></RegModal>
      <LoginModal
        active={loginModalActive}
        setActive={setLoginModalActive}
      ></LoginModal>
    </>
  );
}
