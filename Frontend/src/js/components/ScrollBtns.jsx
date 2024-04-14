export default function ScrollBtns() {
  let height = 0;
  setTimeout(() => (height = document.querySelector("img").height), 100);
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
