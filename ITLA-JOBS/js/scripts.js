import GoToTop from "/js/go-top.js";
import PostJob from "/js/post-job.js";
import SignUp from "/js/signup.js";

document.addEventListener("DOMContentLoaded", () => {
  const goTop = new GoToTop();
  console.log(location.href);
  if (location.href === "http://127.0.0.1:5501/post-job.html") {
    const postJob = new PostJob();
  }
  if (location.href === "http://127.0.0.1:5501/signup.html") {
    const singup = new SignUp();
  }
});

// fetch("https://localhost:44333/api/Person")
//   .then((res) => res.json())
//   .then((res) => console.log(res));
