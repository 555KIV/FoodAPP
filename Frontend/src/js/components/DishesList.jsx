import "../../css/dishesList.css";
import FoodCard from "./FoodCard";
export default function DishesList(filterResponse) {
  return (
    <>
      <div className={"dishesList"}>
        {filterResponse.filterResponse.map((item) => {
          return (
            <FoodCard
              key={item.id}
              dishName={item.name}
              calories={item.calories}
              carbohydrates={item.carbohydrates}
              fats={item.fats}
              squirrels={item.squirrels}
              cookingTime={item.cookingTime}
            ></FoodCard>
          );
        })}
      </div>
    </>
  );
}
