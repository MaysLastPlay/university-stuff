#include <iostream>
#include <fstream>
#include <cstring>

using namespace std;

class Trip {
private:
    char destination[100];  // Статичний масив для пункту призначення (макс. 99 символів)
    char trainNumber[20];   // Статичний масив для номера поїзда
    char departureTime[10]; // Статичний масив для часу відправлення
    char** stops;           // Вказівник на вказівники (динамічний масив рядків) для зупинок
    int stopsCount;         // Кількість проміжних зупинок

public:
    // Конструктор за замовчуванням: ініціалізує порожні рядки та нульові вказівники
    Trip() : stops(nullptr), stopsCount(0) {
        strcpy(destination, "");
        strcpy(trainNumber, "");
        strcpy(departureTime, "");
    }

    // Конструктор з параметрами
    Trip(const char* dest, const char* number, const char* time, const char* stps[], int count) {
        strncpy(destination, dest, 99);   // Безпечне копіювання пункту призначення
        strncpy(trainNumber, number, 19); // Безпечне копіювання номера
        strncpy(departureTime, time, 9);  // Безпечне копіювання часу

        stopsCount = count;               // Встановлюємо кількість зупинок
        stops = new char* [stopsCount];   // Виділяємо пам'ять під масив вказівників
        for (int i = 0; i < stopsCount; i++) {
            stops[i] = new char[50];      // Для кожної зупинки виділяємо масив на 50 символів
            strncpy(stops[i], stps[i], 49); // Копіюємо назву зупинки
        }
    }

    // Деструктор: звільняє багаторівневу динамічну пам'ять
    ~Trip() {
        if (stops != nullptr) {
            for (int i = 0; i < stopsCount; i++) {
                delete[] stops[i];
            }
            delete[] stops;
        }
    }

    // Геттери для доступу до приватних даних
    const char* getDestination() const { return destination; }
    const char* getTrainNumber() const { return trainNumber; }

    // Метод перевірки: чи проходить поїзд через вказану станцію
    bool hasStation(const char* stationName) const {
        // Перевірка, чи є станція кінцевим пунктом
        if (strcmp(destination, stationName) == 0) return true;

        // Перевірка всіх проміжних зупинок у циклі
        for (int i = 0; i < stopsCount; i++) {
            if (strcmp(stops[i], stationName) == 0) return true;
        }
        return false;
    }
};

int main() {
    const char* s1[] = { "Фастів", "Козятин", "Вінниця" };
    const char* s2[] = { "Дарниця", "Полтава" };
    const char* s3[] = { "Львів", "Стрий", "Мукачево" };
    const char* s4[] = { "Бровари", "Ніжин" };

    Trip trains[8] = {
        Trip("Львів", "091К", "22:15", s1, 3),
        Trip("Харків", "722К", "06:45", s2, 2),
        Trip("Ужгород", "029К", "20:02", s3, 3),
        Trip("Чернігів", "894О", "08:20", s4, 2),
        Trip("Одеса", "105К", "21:05", s1, 2),
        Trip("Дніпро", "734Л", "17:35", s2, 1),
        Trip("Чорнобиль", "081К", "18:30", s3, 2),
        Trip("Тернопіль", "120Л", "15:10", s1, 3)
    };

    char searchStation[50];
    cout << "Введіть назву станції: ";
    cin >> searchStation;

    cout << "\nРезультати пошуку для станції \"" << searchStation << "\":" << endl;

    bool found = false;
    for (int i = 0; i < 8; i++) {
        // Виклик методу hasStation для кожного поїзда в масиві
        if (trains[i].hasStation(searchStation)) {
            cout << "Поїзд №" << trains[i].getTrainNumber()
                << " -> Напрямок: " << trains[i].getDestination() << endl;
            found = true;
        }
    }

    // Якщо після перевірки всіх поїздів прапор залишився false
    if (!found) cout << "Поїздів не знайдено." << endl;

    system("pause");
}