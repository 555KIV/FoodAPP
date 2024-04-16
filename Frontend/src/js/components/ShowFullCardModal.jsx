import "../../css/fullCardModal.css";
export default function ShowFullCardModal({
  fullCardResponse,
  cardModalActive,
  setCardModalActive,
}) {
  return (
    <>
      <div
        className={cardModalActive ? "fullCardModal active" : "fullCardModal"}
        onClick={() => {
          setCardModalActive(false);
        }}
      >
        <div className="fullCardContent" onClick={(e) => e.stopPropagation()}>
          <div className="fullCardTitle">{fullCardResponse.name}</div>
          <div>
            Энергетическая ценность блюда: {fullCardResponse.calories} ккал.,{" "}
            {fullCardResponse.fats} г., {fullCardResponse.squirrels} г.,{" "}
            {fullCardResponse.carbohydrates} г.
          </div>
          <div>Когда подавать: {fullCardResponse.typeFood}</div>
          <div>Время приготовления: {fullCardResponse.cookingTime}</div>
          <div className="ingredients">
            Ингредиенты:{"  "}
            {fullCardResponse.ingredients.map((ingredient) => (
              <div className="ingredient">{ingredient}</div>
            ))}
          </div>
          <div>Рецепт: {fullCardResponse.recipe}</div>
        </div>
      </div>
    </>
  );
}
