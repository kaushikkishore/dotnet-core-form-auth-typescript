function sayHello() {
    const compiler = (document.getElementById("compiler") as HTMLInputElement).value;
    const framework = (document.getElementById("framework") as HTMLInputElement).value;
    return `Hello from ${compiler} and ${framework}!`;
}

function test() {
    var one = 1;

    if (one === 1) {
        let one = 2;
        return one === 2;
    }

    return one === 1;
}