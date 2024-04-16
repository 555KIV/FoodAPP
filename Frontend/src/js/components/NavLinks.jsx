import Auth from "./Auth";
import { useState } from "react";
import NewDishModal from "./NewDishModal";

export default function NavLinks({ setActiveDesc }) {
  const [auth, setAuth] = useState(false);
  const [newDishModalActive, setNewDishModalActive] = useState(false);
  return (
    <>
      <nav className="navBar">
        <div className="navRouting">
          <a className="routingItem" href="/">
            Главная
          </a>
          <a
            className="routingItem"
            href="/"
            onClick={() => setActiveDesc(true)}
          >
            Анкета
          </a>
          <button
            className="routingItemBtn"
            href="/"
            onClick={() => setNewDishModalActive(true)}
          >
            Новый рецепт
          </button>
        </div>
        <NewDishModal
          newDishModalActive={newDishModalActive}
          setNewDishModalActive={setNewDishModalActive}
        ></NewDishModal>
        <Auth auth={auth} setAuth={setAuth}></Auth>
      </nav>
    </>
  );
}
