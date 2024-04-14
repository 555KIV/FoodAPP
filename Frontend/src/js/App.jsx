import "../css/App.css";
import Header from "./components/Header";
import LoadUsersBtn from "./components/LoadUsersBtn";
import { useState } from "react";
export default function App() {
  return (
    <>
      <Header></Header>
      <LoadUsersBtn></LoadUsersBtn>
    </>
  );
}
