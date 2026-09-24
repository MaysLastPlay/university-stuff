#include <iostream>
#include <cstring>
#pragma warning(disable:4996)
using namespace std;

class Product { // Оголошення класу "Товар".
private: // Секція з приватними даними, доступними лише всередині класу.
    char* name;  // Вказівник на рядок (ім'я товару) у динамічній пам'яті.
    char* code;  // Вказівник на рядок (шифр товару) у динамічній пам'яті.
    char* country;
    int number;  // Ціле число для зберігання кількості товару.
    int price;


public:
    // Конструктор за замовчуванням: ініціалізує вказівники в nullptr, а число в 0.
    Product() : name(nullptr), code(nullptr), country(nullptr), price(0), number(0) {}

    // Конструктор з параметрами: створює об'єкт з конкретними даними.
    Product(const char* n, const char* c, const char* cc, int pr, int num) {
        name = new char[strlen(n) + 1]; // Виділяє пам'ять під ім'я (+1 для символу \0).
        strcpy(name, n);                // Копіює текст у виділену пам'ять.
        code = new char[strlen(c) + 1]; // Виділяє пам'ять під шифр.
        strcpy(code, c);                // Копіює шифр.
        country = new char[strlen(cc) + 1];
        strcpy(country, cc);
        price = pr;
        number = num;                   // Присвоює кількість.
    }

    // Конструктор копіювання: дозволяє правильно копіювати об'єкти (Deep Copy).
    Product(const Product& other) {
        name = new char[strlen(other.name) + 1]; // Виділяє нову пам'ять для копії імені.
        strcpy(name, other.name);
        code = new char[strlen(other.code) + 1]; // Виділяє нову пам'ять для копії коду.
        strcpy(code, other.code);
        country = new char[strlen(other.country) + 1];
        strcpy(country, other.country);
        price = other.price;
        number = other.number;
    }

    // Деструктор: автоматично звільняє динамічну пам'ять при видаленні об'єкта.
    ~Product() {
        delete[] name, code, country;
    }

    // Оператор присвоєння: викликається при виконанні p1 = p2.
    Product& operator=(const Product& other) {
        if (this == &other) return *this; // Перевірка на самоприсвоєння (наприклад, p1 = p1).

        delete[] name, code, country; // Видаляємо старі дані, щоб уникнути витоку пам'яті.

        name = new char[strlen(other.name) + 1]; // Виділяємо нову пам'ять.
        strcpy(name, other.name);
        code = new char[strlen(other.code) + 1];
        strcpy(code, other.code);
        country = new char[strlen(other.country) + 1];
        strcpy(country, other.country);
        price = other.price;
        number = other.number;

        return *this; // Повертаємо посилання на поточний об'єкт.
    }

    // Геттери (Getter methods): дозволяють отримати значення приватних полів.
    const char* getName() const { return name; }
    const char* getCode() const { return code; }
    const char* getCountry() const { return country; }
    int getPrice() const { return price; }
    int getNumber() const { return number; }

    // Сеттер для імені: змінює ім'я, перерозподіляючи пам'ять.
    void setName(const char* n) {
        delete[] name;
        name = new char[strlen(n) + 1];
        strcpy(name, n);
    }

    // Сеттер для коду: змінює шифр, перерозподіляючи пам'ять.
    void setCode(const char* c) {
        delete[] code;
        code = new char[strlen(c) + 1];
        strcpy(code, c);
    }

    void setCountry(const char* cc) {
        delete[] country;

        country = new char[strlen(cc) + 1];
        strcpy(country, cc);

    }

    void setPrice(int pr) { price = pr; }

    // Сеттер для кількості.
    void setNumber(int num) { number = num; }

    void input() {
        char buffer[256]; // Тимчасовий масив для зчитування тексту.
        cout << "Name: ";
        cin >> buffer;
        setName(buffer);  // Викликаємо сеттер для динамічного виділення пам'яті.
        cout << "Code: ";
        cin >> buffer;
        setCode(buffer);
        cout << "Country: ";
        cin >> buffer;
        setCountry(buffer);
        cout << "Price: ";
        cin >> price;
        cout << "Number: ";
        cin >> number;
    }

    // Метод для виведення інформації про товар на екран.
    void show() const {
        if (name && code) // Перевірка, чи вказівники не нульові.
            cout << "Product: " << name << " | Code: " << code << " | Country: " << country << " | Price: " << price << " | Quantity: " << number << endl;
    }
};

int main() {
    Product p1("Part1", "X-100", "Ukraine", 100, 10);
    p1.show(); // Виведення даних p1.

    Product p2 = p1;
    p2.show();

    // Створення об'єкта в динамічній пам'яті (через вказівник).
    Product* p3 = new Product("Part2", "Y-200", "USA", 250, 20);
    p3->show(); // Виклик методу через вказівник (використовується ->).
    delete p3;  // Обов'язкове видалення об'єкта, щоб викликати деструктор.

    const int size = 4;
    Product inventory[size]; // Масив об'єктів (викликається конструктор за замовчуванням).

    // Цикл для заповнення масиву даними користувача.
    for (int i = 0; i < size; i++) {
        inventory[i].input();
    }

    // Цикл для виведення всього масиву.
    for (int i = 0; i < size; i++) {
        inventory[i].show();
    }

    system("pause");
}