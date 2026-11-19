console.log("--- Завдання 1 ---");

let temperature = 32;

if (temperature >= 30) {
    console.log("Це жаркий день");
} else {
    console.log("Це не жаркий день");
}

console.log("\n--- Завдання 2 ---");

let grade = "B";

switch (grade) {
    case "A":
        console.log("Відмінно");
        break;
    case "B":
        console.log("Добре");
        break;
    case "C":
        console.log("Задовільно");
        break;
    case "D":
        console.log("Достатньо");
        break;
    case "F":
        console.log("Незадовільно");
        break;
    default:
        console.log("Невідома оцінка. Будь ласка, введіть значення від A до F.");
}

console.log("\n--- Завдання 3 ---");

let i = 1;

do {
    console.log(i);
    i++;
} while (i <= 10);