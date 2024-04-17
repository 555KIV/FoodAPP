import "../css/App.css";
import Header from "./components/Header";
import ScrollBtns from "./components/ScrollBtns";
import Description from "./components/Description";
import { useState } from "react";
import DishesList from "./components/DishesList";
import { useCookies } from "react-cookie";
export default function App() {
  const [activeDesc, setActiveDesc] = useState(true);
  const [filterResponse, setFilterResponse] = useState([]);
  const [cookies, setCookie, removeCookie] = useCookies(["username", "token"]);

  return (
    <>
      <Header
        cookies={cookies}
        setCookie={setCookie}
        removeCookie={removeCookie}
        activeDesc={activeDesc}
        setActiveDesc={setActiveDesc}
      ></Header>
      {activeDesc ? (
        <Description
          activeDesc={activeDesc}
          setActiveDesc={setActiveDesc}
          setFilterResponse={setFilterResponse}
        ></Description>
      ) : (
        <DishesList
          cookies={cookies}
          filterResponse={filterResponse}
        ></DishesList>
      )}
      <ScrollBtns></ScrollBtns>
    </>
  );
}
