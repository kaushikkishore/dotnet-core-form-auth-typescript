function sayHello() {
    var compiler = document.getElementById("compiler").value;
    var framework = document.getElementById("framework").value;
    return "Hello from " + compiler + " and " + framework + "!";
}
function test() {
    var one = 1;
    if (one === 1) {
        var one_1 = 2;
        return one_1 === 2;
    }
    return one === 1;
}
//# sourceMappingURL=app.js.map