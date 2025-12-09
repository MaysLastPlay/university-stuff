// ConsoleLabApplication4.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
using namespace std;

// Прототип функції (змінив назву, щоб відповідала суті, або можна залишити minEl)
void processTask(int a[], int size);

int main()
{
    setlocale(LC_ALL, "uk_UA"); // Щоб бачити укр. текст
    int choice;

    cout << "Оберіть режим:\n1. Тестовий масив\n2. Введення з клавіатури\nВаш вибір: ";
    cin >> choice;

    if (choice == 1) {
        // 4.1 - Використання тестового набору з вашого коду
        int yes[] = { 1, 3, 7, 13, 21, 5, 8, 16, 11 };
        processTask(yes, 9);
    }
    else {
        // Введення вручну
        int n;
        cout << "Введіть розмір масиву: ";
        cin >> n;

        if (n < 2) {
            cout << "Потрібно мінімум 2 елементи." << endl;
        }
        else {
            int* arr = new int[n]; // Динамічний масив
            cout << "Введіть " << n << " чисел: ";
            for (int i = 0; i < n; i++) {
                cin >> arr[i];
            }
            processTask(arr, n);
            delete[] arr; // Очищення пам'яті
        }
    }

    return 0;
}

// Функція реалізації Варіанту 4
void processTask(int a[], int size) {
    // Ініціалізація великими числами
    int min1 = 2000000000, min2 = 2000000000;
    int idx1 = -1, idx2 = -1;

    // 1. Шукаємо два мінімуми та їх індекси
    for (int i = 0; i < size; ++i) {
        if (a[i] < min1) {
            min2 = min1;
            idx2 = idx1;
            min1 = a[i];
            idx1 = i;
        }
        else if (a[i] < min2 && i != idx1) {
            min2 = a[i];
            idx2 = i;
        }
    }

    // 2. Визначаємо межі "між" ними
    int start = (idx1 < idx2) ? idx1 : idx2;
    int end = (idx1 > idx2) ? idx1 : idx2;

    int sum = 0;
    int count = 0;

    // 3. Рахуємо суму та кількість
    for (int i = start + 1; i < end; ++i) {
        sum += a[i];
        count++;
    }

    // Вивід результатів
    cout << "\nРезультати:\n";
    cout << "1-й мінімум: " << min1 << " (індекс " << idx1 << ")\n";
    cout << "2-й мінімум: " << min2 << " (індекс " << idx2 << ")\n";
    cout << "Сума між ними: " << sum << "\n";
    cout << "Кількість між ними: " << count << endl;
}
            int arr[100]; // Створюємо масив із запасом (наприклад, на 100 елементів)

            // Бажано обмежити n, щоб не вийти за межі 100
            if (n > 100) n = 100; 

            cout << "Введіть " << n << " чисел: ";
            for (int i = 0; i < n; i++) {
                cin >> arr[i];
            }
            processTask(arr, n);
            // delete[] arr; // Видаляти не потрібно

