import "../../css/dishesList.css";
import ShowFullCardModal from "./ShowFullCardModal";
import { useState } from "react";
import data from "bootstrap/js/src/dom/data";
export default function FoodCard({
  id,
  dishName,
  carbohydrates,
  fats,
  squirrels,
  calories,
  cookingTime,
}) {
  const [cardModalActive, setCardModalActive] = useState(false);
  const [fullCardResponse, setFullCardResponse] = useState({
    id: 0,
    idImageLow: 0,
    name: "",
    calories: "",
    carbohydrates: "",
    fats: "",
    squirrels: "",
    recipe: "",
    cookingTime: "",
    typeFood: "",
    ingredients: [],
  });
  const showFullCard = () => {
    getFullCard().then(() => setCardModalActive(true));
  };
  const getFullCard = async () => {
    await fetch(`/api/dishes/get-dish=${id}`, {
      method: "GET",
    })
      .then((response) => {
        return response.json();
      })
      .then((data) => {
        setFullCardResponse(data);
      });
  };
  const sendLikedDish = async (e) => {
    e.stopPropagation();
    e.target.classList.add("liked");
    await fetch(`api/dishes/like-dish=${id}`, {
      method: "POST",
      headers: {
        Authorization: "Bearer " + localStorage.getItem("token"),
      },
    });
  };
  return (
    <>
      <div className="dishCard" onClick={showFullCard}>
        <div className="dishTitle">{dishName}</div>
        <div className="dishInfo">Время приготовления: {cookingTime}</div>
        <div className="dishInfo">Количество калорий: {calories}</div>
        <div className="dishInfo">Жиры: {fats}г.</div>
        <div className="dishInfo">Белки: {squirrels}г.</div>
        <div className="dishInfo">Углеводы: {carbohydrates}г.</div>
        <button className="likeDish" onClick={sendLikedDish}>
          ♥
        </button>
      </div>
      {cardModalActive ? (
        <ShowFullCardModal
          fullCardResponse={fullCardResponse}
          cardModalActive={cardModalActive}
          setCardModalActive={setCardModalActive}
        ></ShowFullCardModal>
      ) : (
        <></>
      )}
    </>
  );
}
