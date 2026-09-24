#include <iostream>
#include <cstring>
using namespace std;

struct ExportInfo {  // Оголошення структури для зберігання даних про експорт
    char name[30], country[30]; // Поля для назви товару та країни (до 30 символів)
    int quantity;               // Поле для кількості товару
};

void processCountries(ExportInfo* e, int n) {
    char seen[15][30]; // Масив для зберігання назв країн, які ми вже обробили
    int count = 0;     // Лічильник знайдених унікальних країн

    for (int i = 0; i < n; i++) { // Цикл по всіх записах експорту
        bool found = false;
        for (int j = 0; j < count; j++) // Перевірка, чи ця країна вже була оброблена
            if (strcmp(e[i].country, seen[j]) == 0) found = true;

        if (!found) { // Якщо країна зустрычається вперше у списку
            strcpy(seen[count++], e[i].country); // Додаємо її до списку "оброблених"
            int sum = 0;
            for (int j = 0; j < n; j++) // Шукаємо всі згадки цієї країни в основному масиві
                if (strcmp(e[j].country, e[i].country) == 0) sum += e[j].quantity; // Додаємо кількість
            cout << e[i].country << ": " << sum << " шт.\n"; // Виводимо підсумок для країни
        }
    }
}

void sortExports(ExportInfo* e, int n) {
    for (int i = 0; i < n - 1; i++) // Зовнішній цикл сортування
        for (int j = i + 1; j < n; j++) // Внутрішній цикл для порівняння
            // Порівнюємо перші 2 символи назв (strncmp)
            if (strncmp(e[i].name, e[j].name, 2) > 0) {
                ExportInfo t = e[i]; e[i] = e[j]; e[j] = t; // Обмін структур місцями
            }
}

int main() {
    const int N = 15; // Кількість записів у базі
    ExportInfo ex[N] = { // Ініціалізація масиву структур тестовими даними
        {"Nord Fridge", "Poland", 120}, {"LG TV", "Germany", 80},
        {"Samsung Phone", "France", 150}, {"Nord Fridge", "Germany", 60},
        {"Sony Camera", "Italy", 90}, {"Bosch Washer", "Poland", 70},
        {"Philips Lamp", "Spain", 100}, {"Asus Laptop", "France", 130},
        {"Dell Laptop", "Germany", 110}, {"Panasonic TV", "Poland", 95},
        {"Lenovo Tablet", "Italy", 85}, {"Nord Fridge", "Spain", 40},
        {"LG TV", "France", 60}, {"Samsung Phone", "Poland", 200},
        {"Bosch Washer", "Italy", 50}
    };

    cout << "Експорт по країнах:\n";
    processCountries(ex, N); // Виклик функції підрахунку по країнах

    sortExports(ex, N); // Виклик функції сортування
    cout << "\nУпорядковано:\n";
    for (int i = 0; i < N; i++) // Вивід відсортованого списку у вигляді таблиці
        cout << ex[i].name << " | " << ex[i].country << " | " << ex[i].quantity << endl;

    const char* target = "Nord Fridge"; // Товар для пошуку
    bool has = false;
    for (int i = 0; i < N; i++) // Лінійний пошук товару за назвою
        if (strcmp(ex[i].name, target) == 0) has = true;

    // Вивід результату пошуку за допомогою тернарного оператора
    cout << "\nТовар \"" << target << (has ? "\" є в списку.\n" : "\" відсутній.\n");

    system("pause");
}