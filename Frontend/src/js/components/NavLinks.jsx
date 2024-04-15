import Auth from "./Auth";
import { useState } from "react";

export default function NavLinks({ setActiveDesc }) {
  const [auth, setAuth] = useState(false);
  return (
    <>
      <nav className="navBar">
        <div className="navRouting">
          <a className="routingItem" href="http://localhost:3000/">
            Главная
          </a>
          <a
            className="routingItem"
            href="http://localhost:3000/"
            onClick={() => setActiveDesc(true)}
          >
            Анкета
          </a>
          <a className="routingItem" href="http://localhost:3000/">
            Новый рецепт
          </a>
        </div>
        <Auth auth={auth} setAuth={setAuth}></Auth>
      </nav>
    </>
  );
}
