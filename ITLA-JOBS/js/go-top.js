export default class goToTop {
  constructor() {
    this.scrollToTop = document.getElementById("scroll-to-top");
    this.scrollToTop.addEventListener("click", this.goToTop);

    window.addEventListener("scroll", () => {
      if (window.scrollY >= 160) {
        this.scrollToTop.classList.add("scroll-to-top--show");
      } else {
        this.scrollToTop.classList.remove("scroll-to-top--show");
      }
    });
  }

  goToTop = () => {
    window.scroll(0, 0);
  };
}
