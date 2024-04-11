import "../../css/navBar.css";
import logo from "../../logo.png";

export default function Header() {
  return (
    <>
      <header>
        <nav className="navBar">
          <div className="navRouting">
            <a className="routingItem logoA" href="#">
              <img className="logoImg" src={logo} alt="logoHere" />
            </a>
            <a className="routingItem" href="#">
              Главная
            </a>
            <a className="routingItem" href="#">
              Новый рецепт
            </a>
          </div>
          <div className="authList">
            <a className="authItem" href="#">
              Вход
            </a>
            <a className="authItem" href="#">
              Регистрация
            </a>
          </div>
        </nav>
      </header>
    </>
  );
}
