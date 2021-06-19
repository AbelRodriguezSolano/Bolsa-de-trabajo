export default class postJob {
  constructor() {
    this.expresiones = {
      companyAndPosition: /^[a-zA-ZÀ-ÿ\s]{1,40}$/,
      correo: /^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$/,
      date: /^(19|20)[0-9]{2}(\-|\/)[0-1]?[0-9](\-|\/)[0-3]?[0-9]$/, //MM-dd-yyyy\
      location: /^[a-zA-Z0-9\s\#]{1,100}$/,
    };

    this.fromInputs = {
      company: false,
      position: false,
      date: false,
      email: false,
      location: false,
      description: false,
    };

    this.form = document.getElementById("formpost");

    this.btn = document.getElementById("btnpost");

    this.form.addEventListener("submit", (e) => {
      e.preventDefault();
      const radios = document.getElementsByName("jobtime");

      //   console.log(radios);
    });

    this.btn.addEventListener("click", (e) => {
      if (
        this.fromInputs.company &&
        this.fromInputs.position &&
        this.fromInputs.date &&
        this.fromInputs.email &&
        this.fromInputs.location &&
        this.fromInputs.description
      ) {
        const radios = document.getElementsByName("jobtime");
        const category = document.getElementById("category");

        console.log(category.value);

        for (const key of radios) {
          if (key.checked) {
            console.log(key.value);
          }
        }

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
      case "company":
        this.validateInput(e.target, this.expresiones.companyAndPosition);
        break;
      case "position":
        this.validateInput(e.target, this.expresiones.companyAndPosition);
        break;
      case "location":
        this.validateInput(e.target, this.expresiones.location);
        break;
      case "date":
        this.validateInput(e.target, this.expresiones.date);
        break;
      case "email":
        this.validateInput(e.target, this.expresiones.correo);
        break;
      case "description":
        this.validateInput(e.target, this.expresiones.location);
        break;
    }
  };
}
