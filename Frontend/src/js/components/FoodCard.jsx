import "../../css/dishesList.css";
export default function FoodCard({
  key,
  dishName,
  carbohydrates,
  fats,
  squirrels,
  calories,
  cookingTime,
}) {
  const sendLikedDish = async (e) => {
    e.target.classList.add("liked");
    await fetch(
      `api/dishes/like-dish=${localStorage.getItem("userName")};${key}`,
      {
        method: "POST",
        headers: {
          Authorization: "Bearer " + localStorage.getItem("token"),
        },
      },
    );
  };
  return (
    <>
      <div className="dishCard">
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
    </>
  );
}
