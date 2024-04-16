import Auth from "./Auth";
import { useState } from "react";
import NewDishModal from "./NewDishModal";

export default function NavLinks({ setActiveDesc }) {
  const [auth, setAuth] = useState(false);
  const [newDishModalActive, setNewDishModalActive] = useState(false);
  let height = 0;
  setTimeout(() => (height = document.querySelector("img").height), 100);
  return (
    <>
      <nav className="navBar">
        <div className="navRouting">
          <button
            className="routingItemBtn"
            onClick={() =>
              window.scrollTo({ top: 0, left: 0, behavior: "smooth" })
            }
          >
            Главная
          </button>
          <button
            className="routingItemBtn"
            onClick={() => {
              window.scrollTo({ top: height, left: 0, behavior: "smooth" });
              setActiveDesc(true);
            }}
          >
            Анкета
          </button>
          <button
            className="routingItemBtn"
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
