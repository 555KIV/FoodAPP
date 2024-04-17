export default function ScrollBtns() {
  let height = 0;
  setTimeout(() => (height = document.querySelector("img").height), 100);
  let prevEventTime = 0;
  window.addEventListener("wheel", (ev) => {
    if (
      ev.target.localName === "form" ||
      ev.target.localName === "label" ||
      ev.target.localName === "button" ||
      ev.target.localName === "select" ||
      ev.target.localName === "textarea" ||
      ev.target.localName === "input"
    )
      return;
    const newEventTime = ev.timeStamp;
    if (newEventTime - prevEventTime > 500) {
      window.scrollBy({
        top: ev.deltaY * 4,
        left: 0,
        behavior: "smooth",
      });
      prevEventTime = newEventTime;
    }
  });
  return (
    <div className="scrollBtnsList">
      <button
        className="scrollBtn"
        onClick={() => {
          console.log(height);
          window.scrollTo({ top: 0, left: 0, behavior: "smooth" });
        }}
      >
        🡹
      </button>
      <button
        className="scrollBtn"
        onClick={() => {
          window.scrollBy({ top: height, left: 0, behavior: "smooth" });
        }}
      >
        🡻
      </button>
    </div>
  );
}
