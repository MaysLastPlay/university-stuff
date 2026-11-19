console.log("--- Завдання 1 ---");

function isEven(number) {
    return number % 2 === 0;
}

console.log("Число 8 парне?", isEven(8));
console.log("Число 15 парне?", isEven(15));

console.log("\n--- Завдання 2 ---");

let book = {
    title: "Кобзар",
    author: "Тарас Шевченко",
    year: 1840
};

book.genre = "Поезія";

for (let key in book) {
    console.log(key + ": " + book[key]);
}

console.log("Додана властивість (жанр):", book.genre);

console.log("\n--- Завдання 3 ---");

let fruits = ["Яблуко", "Банан", "Апельсин", "Виноград", "Ківі"];

let fruitsLength = fruits.map(function(fruit) {
    return fruit.length;
});

console.log("Оригінальний масив фруктів:", fruits);
console.log("Масив довжин назв фруктів:", fruitsLength);