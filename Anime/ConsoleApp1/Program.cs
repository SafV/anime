using AnimeLogic;
using System;
using System.Collections.Generic;
using System.Xml.Linq;
using DataAccessLayer;

namespace ConsoleApp1
{
    public class Program
    {
        static Logic logic = new Logic(new EntityRepository<Anime>());

        /// <summary>
        /// Главное меню программы.
        /// </summary>
        /// <param name="args">аргументы</param>
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();

                Console.WriteLine("        МЕНЮ");
                Console.WriteLine("1. Добавить аниме");
                Console.WriteLine("2. Удалить аниме");
                Console.WriteLine("3. Показать все аниме");
                Console.WriteLine("4. Изменить аниме");
                Console.WriteLine("5. Поиск по жанру");
                Console.WriteLine("6. Поиск по году");
                Console.WriteLine("7. Добавить в избранное");
                Console.WriteLine("8. Показать избранное");
                Console.WriteLine("9. Выход");
                Console.Write("Выберите действие: ");

                string choice = Console.ReadLine() ?? "";

                Console.Clear();

                switch (choice)
                {
                    case "1":
                        AddAnime();
                        break;

                    case "2":
                        DeleteAnime();
                        break;

                    case "3":
                        ShowAllAnime();
                        break;

                    case "4":
                        UpdateAnime();
                        break;

                    case "5":
                        SearchByGenre();
                        break;

                    case "6":
                        SearchByYear();
                        break;

                    case "7":
                        AddToFavorites();
                        break;

                    case "8":
                        ShowFavorites();
                        break;

                    case "9":
                        return;

                    default:
                        Console.WriteLine("Неверный пункт меню.");
                        Pause();
                        break;
                }
            }
        }

        /// <summary>
        /// Считывает целое число в заданном диапазоне
        /// </summary>
        /// <param name="message">сообщение</param>
        /// <param name="minValue">мин знач</param>
        /// <param name="maxValue">макс знач</param>
        /// <returns>номерок</returns>
        static int ReadInt(string message, int minValue, int maxValue)
        {
            while (true)
            {
                Console.Write(message);
                string input = Console.ReadLine() ?? "";

                if (int.TryParse(input, out int number) && number >= minValue && number <= maxValue)
                {
                    return number;
                }

                Console.WriteLine($"Введите целое число от {minValue} до {maxValue}.");
            }
        }

        /// <summary>
        /// Считывает текст, который не должен быть пустым
        /// </summary>
        /// <param name="message">сообщение</param>
        /// <returns>непустая строчка</returns>
        static string ReadText(string message)
        {
            while (true)
            {
                Console.Write(message);
                string input = (Console.ReadLine() ?? "").Trim();

                if (!string.IsNullOrWhiteSpace(input))
                {
                    return input;
                }

                Console.WriteLine("Поле не должно быть пустым.");
            }
        }

        /// <summary>
        /// Добавляет новое аниме.
        /// </summary>
        static void AddAnime()
        {
            Console.WriteLine("ДОБАВЛЕНИЕ АНИМЕ");

            int id = ReadInt("Введите ID: ", 1, int.MaxValue);
            string title = ReadText("Введите название: ");
            string genre = ReadText("Введите жанр: ");
            int year = ReadInt("Введите год: ", 1, DateTime.Now.Year);
            int episodes = ReadInt("Введите количество серий: ", 1, int.MaxValue);

            Anime anime = new Anime(id, title, genre, year, episodes);
            bool result = logic.AddAnime(anime);

            Console.WriteLine();

            if (result)
            {
                Console.WriteLine("Аниме успешно добавлено.");
            }
            else
            {
                Console.WriteLine("Аниме с таким ID уже существует.");
            }

            Pause();
        }

        /// <summary>
        /// Удаляет аниме по ID
        /// </summary>
        static void DeleteAnime()
        {
            Console.WriteLine(" УДАЛЕНИЕ АНИМЕ ");
            List<Anime> animes = logic.GetAllAnime();
            if (animes.Count == 0)
            {
                Console.WriteLine("Список аниме пуст.");
            }
            else
            {
                foreach (Anime anime in animes)
                {
                    Console.WriteLine(anime);
                }
            }

            int id = ReadInt("Введите ID аниме: ", 1, int.MaxValue);

            bool result = logic.DeleteAnime(id);


            Console.WriteLine();

            if (result)
            {
                Console.WriteLine("Аниме успешно удалено.");
            }
            else
            {
                Console.WriteLine("Аниме с таким ID не найдено.");
            }

            Pause();
        }

        /// <summary>
        /// Показывает список всех аниме
        /// </summary>
        static void ShowAllAnime()
        {
            Console.WriteLine("ВСЕ АНИМЕ");

            List<Anime> animes = logic.GetAllAnime();

            if (animes.Count == 0)
            {
                Console.WriteLine("Список аниме пуст.");
            }
            else
            {
                foreach (Anime anime in animes)
                {
                    Console.WriteLine(anime);
                }
            }

            Pause();
        }

        /// <summary>
        /// Изменяет данные аниме, включая его ID
        /// </summary>
        static void UpdateAnime()
        {
            Console.WriteLine("ИЗМЕНЕНИЕ АНИМЕ");
            List<Anime> animes = logic.GetAllAnime();
            if (animes.Count == 0)
            {
                Console.WriteLine("Список аниме пуст.");
            }
            else
            {
                foreach (Anime anime in animes)
                {
                    Console.WriteLine(anime);
                }
            }

            int oldId = ReadInt("Введите текущий ID аниме: ", 1, int.MaxValue);
            bool exists = animes.Exists(a => a.Id == oldId);

            if (!exists)
            {
                Console.WriteLine("Аниме с таким ID не найдено.");
                Pause();
                return;
            }

            int newId = ReadInt("Введите новый ID аниме: ", 1, int.MaxValue);
            string title = ReadText("Введите новое название: ");
            string genre = ReadText("Введите новый жанр: ");
            int year = ReadInt("Введите новый год: ", 1, DateTime.Now.Year);
            int episodes = ReadInt("Введите новое количество серий: ", 1, int.MaxValue);

            bool result = logic.UpdateAnime(oldId, newId, title, genre, year, episodes);
            Console.WriteLine();

            if (result)
            {
                Console.WriteLine("Аниме успешно изменено.");
            }
            else
            {
                Console.WriteLine("Не удалось изменить аниме. Возможно, новый ID занят.");
            }

            Pause();
        }

        /// <summary>
        /// Ищет аниме по жанру
        /// </summary>
        static void SearchByGenre()
        {
            Console.WriteLine("ПОИСК ПО ЖАНРУ");
            List<Anime> animes = logic.GetAllAnime();
            if (animes.Count == 0)
            {
                Console.WriteLine("Список аниме пуст.");
            }
            else
            {
                foreach (Anime anime in animes)
                {
                    Console.WriteLine(anime);
                }
            }

            string genre = ReadText("Введите жанр: ");

            List<Anime> result = logic.GetAnimeByGenre(genre);

            Console.WriteLine();

            if (result.Count == 0)
            {
                Console.WriteLine("Аниме с таким жанром не найдено.");
            }
            else
            {
                foreach (Anime anime in result)
                {
                    Console.WriteLine(anime);
                }
            }

            Pause();
        }

        /// <summary>
        /// Ищет аниме, выпущенные в указанном году или позже
        /// </summary>
        static void SearchByYear()
        {
            Console.WriteLine("ПОИСК ПО ГОДУ");
            int year = ReadInt("Введите год: ", 1, DateTime.Now.Year);

            List<Anime> result = logic.GetAnimeAfterYear(year);

            Console.WriteLine();

            if (result.Count == 0)
            {
                Console.WriteLine("Аниме за этот год или позже не найдено.");
            }
            else
            {
                foreach (Anime anime in result)
                {
                    Console.WriteLine(anime);
                }
            }

            Pause();
        }

        /// <summary>
        /// Добавляет аниме в избранное по его ID
        /// </summary>
        static void AddToFavorites()
        {
            Console.WriteLine("ДОБАВЛЕНИЕ В ИЗБРАННОЕ");
            List<Anime> animes = logic.GetAllAnime();
            if (animes.Count == 0)
            {
                Console.WriteLine("Список аниме пуст.");
            }
            else
            {
                foreach (Anime anime in animes)
                {
                    Console.WriteLine(anime);
                }
            }

            int id = ReadInt("Введите ID аниме: ", 1, int.MaxValue);

            bool result = logic.AddToFavorites(id);

            Console.WriteLine();

            if (result)
            {
                Console.WriteLine("Аниме добавлено в избранное.");
            }
            else
            {
                Console.WriteLine("Не удалось добавить аниме. Проверьте ID: ");
            }

            Pause();
        }

        /// <summary>
        /// Показывает все аниме, добавленные в избранное
        /// </summary>
        static void ShowFavorites()
        {
            Console.WriteLine("ИЗБРАННОЕ");

            List<Anime> favorites = logic.GetFavorites();

            if (favorites.Count == 0)
            {
                Console.WriteLine("Избранное пока пусто.");
            }
            else
            {
                foreach (Anime anime in favorites)
                {
                    Console.WriteLine(anime);
                }
            }

            Pause();
        }

        /// <summary>
        /// Ждёт нажатия клавиши перед возвращением в главное меню
        /// </summary>
        static void Pause()
        {
            Console.WriteLine("Нажмите любую клавишу для продолжения...");
            Console.ReadLine();
        }
    }
}