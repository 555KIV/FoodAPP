import "../../css/navBar.css";
import mainImg from "../../main.png";
import NavLinks from "./NavLinks";

export default function Header({
  activeDesc,
  setActiveDesc,
  cookies,
  setCookie,
  removeCookie,
}) {
  return (
    <>
      <img src={mainImg} alt="" className="mainImg" />
      <header>
        <NavLinks
          cookies={cookies}
          setCookie={setCookie}
          removeCookie={removeCookie}
          activeDesc={activeDesc}
          setActiveDesc={setActiveDesc}
        ></NavLinks>
        <div className="title">Что</div>
        <div className="title">готовим?</div>
      </header>
    </>
  );
}
