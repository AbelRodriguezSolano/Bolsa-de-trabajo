const scrollToTop = document.getElementById("scroll-to-top");
let canScroll = false;

const goToTop = () => {
  window.scroll(0, 0);
};

scrollToTop.addEventListener("click", goToTop);

window.addEventListener("scroll", () => {
  if (window.scrollY >= 160) {
    canScroll = true;
    scrollToTop.classList.add("scroll-to-top--show");
  } else {
    scrollToTop.classList.remove("scroll-to-top--show");
    canScroll = false;
  }
});

fetch("https://localhost:44333/api/Person")
  .then((res) => res.json())
  .then((res) => console.log(res));
