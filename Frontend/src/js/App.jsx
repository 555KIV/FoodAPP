import "../css/App.css";
import Header from "./components/Header";
import ScrollBtns from "./components/ScrollBtns";
import Description from "./components/Description";
import { useState } from "react";
import DishesList from "./components/DishesList";
export default function App() {
  const [activeDesc, setActiveDesc] = useState(true);
  const [filterResponse, setFilterResponse] = useState([
    {
      id: 1,
      name: "Салат",
      calories: 100,
      carbohydrates: 20,
      fats: 25,
      squirrels: 20,
      cookingTime: "5 мин",
      idImageLow: 1,
      typeFood: "Завтрак",
    },
    {
      id: 2,
      name: "Салат",
      calories: 100,
      carbohydrates: 20,
      fats: 25,
      squirrels: 20,
      cookingTime: "5 мин",
      idImageLow: 1,
      typeFood: "Завтрак",
    },
    {
      id: 3,
      name: "Салат",
      calories: 100,
      carbohydrates: 20,
      fats: 25,
      squirrels: 20,
      cookingTime: "5 мин",
      idImageLow: 1,
      typeFood: "Завтрак",
    },
    {
      id: 4,
      name: "Салат",
      calories: 100,
      carbohydrates: 20,
      fats: 25,
      squirrels: 20,
      cookingTime: "5 мин",
      idImageLow: 1,
      typeFood: "Завтрак",
    },
    {
      id: 5,
      name: "Салат",
      calories: 100,
      carbohydrates: 20,
      fats: 25,
      squirrels: 20,
      cookingTime: "5 мин",
      idImageLow: 1,
      typeFood: "Завтрак",
    },
    {
      id: 6,
      name: "Салат",
      calories: 100,
      carbohydrates: 20,
      fats: 25,
      squirrels: 20,
      cookingTime: "5 мин",
      idImageLow: 1,
      typeFood: "Завтрак",
    },
  ]);
  return (
    <>
      <Header activeDesc={activeDesc} setActiveDesc={setActiveDesc}></Header>
      {activeDesc ? (
        <Description
          activeDesc={activeDesc}
          setActiveDesc={setActiveDesc}
          setFilterResponse={setFilterResponse}
        ></Description>
      ) : (
        <DishesList filterResponse={filterResponse}></DishesList>
      )}
      <ScrollBtns></ScrollBtns>
    </>
  );
}
