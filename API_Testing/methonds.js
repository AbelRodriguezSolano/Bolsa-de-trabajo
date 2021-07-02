//Probado en Postman
// Get Methonds
pm.test("Retorno OK",  ()=> {
    pm.response.to.have.status(200);
});
pm.test("Tiempo de respuesta menor a 500ms",  ()=> {
    pm.expect(pm.response.responseTime).to.be.below(500);
});

pm.test("Existe contenido en el body", ()=>{
     pm.response.to.be.withBody;
});

pm.test("Esta retornado un Json", ()=>{
    pm.response.to.be.json;
})

pm.test("El atributo  de retorno es nombre ", ()=>{
    pm.expect(pm.response.text()).to.include("nombre")
});

//Post Methonds

pm.test("Retorno Ok", function () {
    pm.response.to.have.status(200);
});
pm.test("Duracion de la peticion menor a 500ms", function () {
    pm.expect(pm.response.responseTime).to.be.below(500);
});
pm.test("Insercion de datos", function () {
    pm.expect(pm.response.code).to.be.oneOf([201, 202]);
});

// Put Methonds
pm.test("Retorno Ok", function () {
    pm.response.to.have.status(200);
});
pm.test("Duraccion de la peticion menor a 500ms", function () {
    pm.expect(pm.response.responseTime).to.be.below(500);
});

pm.test("Esta retornado un Json", ()=>{
    pm.response.to.be.json;
})
pm.test("Modificacion exitosa", function (){
    pm.response.to.not.have.jsonBody("error")
});


///Delete Methonds
pm.test("Retorno Ok", function () {
    pm.response.to.have.status(200);
});
pm.test("Duraccion de la peticion 600ms", function () {
    pm.expect(pm.response.responseTime).to.be.below(600);
});
pm.test("Content-Type esta presente", function () {
    pm.response.to.have.header("Content-Type");
});