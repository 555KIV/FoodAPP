import "../../css/Description.css";
import FilterForm from "./FilterForm";

export default function Description({
  activeDesc,
  setActiveDesc,
  setFilterResponse,
}) {
  return (
    <>
      <div className={activeDesc ? "description active" : "description"}>
        <h2 className="descriptionTitle">
          НАДОЕЛО СЧИТАТЬ КАЛОРИИ? МЫ ЭТО СДЕЛАЛИ ЗА ТЕБЯ! ВКУСНЫЕ И ПРОСТЫЕ
          РЕЦЕПТЫ С УКАЗАННОЙ КАЛОРИЙНОСТЬЮ!
        </h2>
        <p className="descriptionText">
          Добро пожаловать в наш агрегатор! Просто укажите необходимые продукты,
          желаемую калорийность и время приема пищи, и мы подберем для вас
          оптимальный вариант. Наш сервис сэкономит время на поиск рецептов и
          предоставит разнообразное и полезное меню. Доверьтесь нам и
          наслаждайтесь каждым приемом пищи!
        </p>
        <FilterForm
          activeDesc={activeDesc}
          setActiveDesc={setActiveDesc}
          setFilterResponse={setFilterResponse}
        ></FilterForm>
      </div>
    </>
  );
}
