import "../../css/filterForm.css";
import { useState } from "react";
import { Form } from "react-bootstrap";
export default function FilterForm({ setActiveDesc, setFilterResponse }) {
  const [time, setTime] = useState("Завтрак");
  const [ccal, setCcal] = useState({ item1: 0, item2: 0 });
  const [required, setRequired] = useState([]);
  const [requiredNot, setRequiredNot] = useState([]);
  const sendFilter = async (e) => {
    e.preventDefault();
    const sendObj = {
      typefood: time,
      calories: ccal,
      listLoveIngred: required,
      listNotLoveIngred: requiredNot,
    };
    try {
      await fetch("api/dishes/filter", {
        method: "POST",
        headers: {
          Accept: "application/json",
          "Content-Type": "application/json",
        },
        body: JSON.stringify(sendObj),
      }).then((response) => {
        if (response.ok) {
          setActiveDesc(false);
          setFilterResponse(response.body);
        }
      });
    } catch (err) {
      console.error(err);
    }
  };

  return (
    <>
      <form className={"filterForm"} onSubmit={sendFilter}>
        <label className="formLabel">
          ВРЕМЯ ПРИЁМА ПИЩИ
          <Form.Select
            required={true}
            className="formInput"
            onChange={(e) => setTime(e.target.value)}
          >
            <option value="Завтрак">Завтрак</option>
            <option value="Обед">Обед</option>
            <option value="Ужин">Ужин</option>
          </Form.Select>
        </label>
        <label className="formLabel">
          КАЛОРИЙНОСТЬ
          <input
            className="formInput"
            type="text"
            placeholder="Указывается диапазон от и до (число-число)"
            required={true}
            onChange={(e) =>
              setCcal({
                item1: e.target.value.split("-")[0],
                item2: e.target.value.split("-")[1],
              })
            }
          />
        </label>
        <label className="formLabel">
          ЖЕЛАЕМЫЕ ПРОДУКТЫ
          <input
            className="formInput"
            type="text"
            required={true}
            onChange={(e) => setRequired(e.target.value.split(" "))}
          />
        </label>
        <label className="formLabel">
          НЕ ДОЛЖНО БЫТЬ
          <input
            className="formInput"
            type="text"
            onChange={(e) => setRequiredNot(e.target.value.split(" "))}
          />
        </label>
        <button className="formButton"> ПОДОБРАТЬ РЕЦЕПТ</button>
      </form>
    </>
  );
}
