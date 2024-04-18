import { useState } from "react";
import { Form } from "react-bootstrap";
import "../../css/newDishModal.css";

export default function NewDishModal({
  cookies,
  newDishModalActive,
  setNewDishModalActive,
}) {
  const [responseOk, setResponseOk] = useState(false);
  const [dishAdd, setDishAdd] = useState(false);
  const data = {
    id: 0,
    idImageLow: 0,
    name: "",
    calories: 0,
    carbohydrates: 0,
    fats: 0,
    squirrels: 0,
    recipe: "",
    cookingTime: "",
    typeFood: "Завтрак",
    ingredients: [],
  };
  const sendNewDish = async (event) => {
    event.preventDefault();
    for (const eventElement of event.target.elements) {
      eventElement.value = "";
    }
    try {
      await fetch("api/dishes/create-dish", {
        method: "POST",
        headers: {
          Accept: "application/json",
          "Content-Type": "application/json",
          Authorization: "Bearer " + cookies.token,
        },
        body: JSON.stringify(data),
      }).then((response) => {
        if (response.ok) {
          console.log("added");
          setResponseOk(true);
          setDishAdd(true);
        } else {
          setResponseOk(false);
          setDishAdd(true);
          throw new Error("Error creating dish");
        }
      });
    } catch (err) {
      console.log(err);
    }
  };
  return (
    <div
      className={newDishModalActive ? "dishModal active" : "dishModal"}
      onClick={(e) => {
        setNewDishModalActive(false);
        setDishAdd(false);
      }}
    >
      <form
        className="dishModalContent"
        method="post"
        onClick={(e) => e.stopPropagation()}
        onSubmit={sendNewDish}
      >
        <label className="dishModalTitle">Новое блюдо</label>
        <label>
          Введите название блюда:
          <input
            type="text"
            required={true}
            onChange={(e) => {
              data.name = e.target.value;
            }}
          />
        </label>
        <label>
          Введите время приготовления:
          <input
            type="text"
            required={true}
            onChange={(e) => {
              data.cookingTime = e.target.value;
            }}
          />
        </label>
        <label>
          Введите тип блюда:
          <Form.Select
            required={true}
            className="dishFormInput"
            onChange={(e) => (data.typeFood = e.target.value)}
          >
            <option value="Завтрак">Завтрак</option>
            <option value="Обед">Обед</option>
            <option value="Ужин">Ужин</option>
          </Form.Select>
        </label>
        <label>
          Введите количество калорий:
          <input
            type="text"
            required
            onChange={(e) => (data.calories = e.target.value)}
          />
        </label>
        <label>
          Введите количество жиров:
          <input
            type="text"
            required
            onChange={(e) => (data.fats = e.target.value)}
          />
        </label>
        <label>
          Введите количество белков:
          <input
            type="text"
            required
            onChange={(e) => (data.squirrels = e.target.value)}
          />
        </label>
        <label>
          Введите количество углеводов:
          <input
            type="text"
            required
            onChange={(e) => (data.carbohydrates = e.target.value)}
          />
        </label>
        <label>
          Введите список ингредиентов (и кол-во):
          <input
            type="text"
            required
            onChange={(e) => (data.ingredients = e.target.value.split(";"))}
          />
        </label>
        <label>
          Введите рецепт блюда:
          <textarea
            required={true}
            onChange={(e) => (data.recipe = e.target.value)}
          ></textarea>
        </label>
        <button type="submit">Добавить</button>
        {responseOk && dishAdd ? (
          <div className="success">Блюдо успешно добавлено</div>
        ) : !responseOk && dishAdd ? (
          <div className="fail">Блюдо не добавлено</div>
        ) : (
          <div></div>
        )}
      </form>
    </div>
  );
}
