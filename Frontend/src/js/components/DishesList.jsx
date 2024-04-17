import "../../css/dishesList.css";
import FoodCard from "./FoodCard";
export default function DishesList({ filterResponse, cookies }) {
  return (
    <>
      <div className={"dishesList"}>
        {filterResponse.filterResponse.map((item) => {
          return (
            <FoodCard
              cookies={cookies}
              key={item.id}
              id={item.id}
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
