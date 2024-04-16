import "../css/App.css";
import Header from "./components/Header";
import ScrollBtns from "./components/ScrollBtns";
import Description from "./components/Description";
import { useState } from "react";
import DishesList from "./components/DishesList";
export default function App() {
  const [activeDesc, setActiveDesc] = useState(true);
  const [filterResponse, setFilterResponse] = useState([]);
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
