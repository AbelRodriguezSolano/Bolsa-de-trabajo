export default class signup {
  constructor() {
    this.expresiones = {
      nombre: /^[a-zA-ZÀ-ÿ\s]{1,40}$/,
      password: /^.{4,12}$/,
      correo: /^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$/,
    };
    this.fromInputs = {
      name: false,
      surname: false,
      password: false,
      email: false,
    };
    this.form = document.getElementById("form-signup");
    this.btn = document.getElementById("btnsignup");

    this.form.addEventListener("submit", (e) => {
      e.preventDefault();
      if (
        this.fromInputs.name &&
        this.fromInputs.surname &&
        this.fromInputs.password &&
        this.fromInputs.email
      ) {
        this.form.reset();

        Swal.fire({
          icon: "success",
          title: "Your work has been saved",
          showConfirmButton: false,
          timer: 1500,
        });
        setTimeout(() => {
          location.href = "/";
        }, 2000);
      } else {
        Swal.fire({
          icon: "error",
          title: "Something went wrong",
          showConfirmButton: false,
          timer: 1500,
        });
      }
    });

    this.inputs = document.querySelectorAll(".form-control");

    this.inputs.forEach((input) => {
      input.addEventListener("keyup", this.validate);
      input.addEventListener("blur", this.validate);
    });
  }

  validateInput = (input, expresiones) => {
    if (expresiones.test(input.value)) {
      input.classList.remove("is-invalid");
      input.classList.add("is-valid");
      this.fromInputs[input.name] = true;
    } else {
      input.classList.add("is-invalid");
      this.fromInputs[input.name] = false;
    }
  };
  validate = (e) => {
    switch (e.target.name) {
      case "name":
        this.validateInput(e.target, this.expresiones.nombre);
        break;
      case "surname":
        this.validateInput(e.target, this.expresiones.nombre);
        break;
      case "email":
        this.validateInput(e.target, this.expresiones.correo);
        break;
      case "password":
        this.validateInput(e.target, this.expresiones.password);
        break;
    }
  };
}
