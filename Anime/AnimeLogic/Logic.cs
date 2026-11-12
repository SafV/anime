using AnimeContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeLogic
{
    public class Logic
    {
        private IRepositoryAccess<Anime> repository;
        private List<Anime> favorites;
        
        public Logic(IRepositoryAccess<Anime> repository)
        {
            this.repository = repository;
            favorites = new List<Anime>();
            if (repository.ReadAll().Count == 0)
            {
                repository.Add(new Anime(1, "Наурто", "Приключения", 2002, 220));
                repository.Add(new Anime(2, "Тетрадь смерти", "Триллер", 2006, 37));
                repository.Add(new Anime(3, "Ванпис", "Приключения", 1999, 1100));
            }

        }

        /// <summary>
        /// Создание
        /// </summary>
        /// <param name="anime"> аниме </param>
        /// <returns> добавляет аниме в список и возвращает тру </returns>
        public bool AddAnime(Anime anime)
        {
            if (repository.ReadById(anime.Id) != null)
            {
                return false;
            }

            repository.Add(anime);
            return true;
        }

        /// <summary>
        /// Чтение
        /// </summary>
        /// <returns> возвращает список аниме </returns>
        public List<Anime> GetAllAnime()
        {
            return repository.ReadAll();
        }

        /// <summary>
        /// Изменение
        /// </summary>
        /// <param name="oldId"> старый айди </param>
        /// <param name="newId"> новый айди </param>
        /// <param name="title"> название </param>
        /// <param name="genre"> жанр </param>
        /// <param name="year"> год выпуска </param>
        /// <param name="episodes"> количество серий </param>
        /// <returns> возвращает тру если аниме успешно изменено </returns>
        public bool UpdateAnime(int oldId, int newId,
    string title, string genre, int year, int episodes)
        {
            Anime anime = repository.ReadById(oldId);

            if (anime == null)
            {
                return false;
            }

            // Запрещаем изменение ID
            if (oldId != newId)
            {
                return false;
            }

            anime.Title = title;
            anime.Genre = genre;
            anime.Year = year;
            anime.Episodes = episodes;

            repository.Update(anime);

            return true;
        }

        /// <summary>
        /// Удаление
        /// </summary>
        /// <param name="id"> айди аниме </param>
        /// <returns> удаляет аниме из всех списков возвращает тру если аниме успешно удалено </returns>
        public bool DeleteAnime(int id)
        {
            Anime anime = repository.ReadById(id);

            if (anime == null)
            {
                return false;
            }

            repository.Delete(id);
            favorites.RemoveAll(a => a.Id == id);
            return true;
        }

        /// <summary>
        /// Поиск аниме по жанру
        /// </summary>
        /// <param name="genre"> жанр </param>
        /// <returns> возвращает список аниме в которых жанр совпадает </returns>
        public List<Anime> GetAnimeByGenre(string genre)
        {
            return repository.ReadAll().Where(a => a.Genre.ToLower() == genre.ToLower()).ToList();
        }

        /// <summary>
        /// Поиск аниме по году
        /// </summary>
        /// <param name="year"> год </param>
        /// <returns> возвращает список аниме в которых год выпуска больше или равен </returns>
        public List<Anime> GetAnimeAfterYear(int year)
        {
            return repository.ReadAll().Where(a => a.Year >= year).ToList();
        }

        /// <summary>
        /// Добавление в избранное
        /// </summary>
        /// <param name="id"> айди аниме </param>
        /// <returns> возвращает тру если успешно добавлено в список избранных </returns>
        public bool AddToFavorites(int id)
        {
            Anime anime = repository.ReadById(id);

            if (anime == null)
            {
                return false;
            }

            if (favorites.Any(a => a.Id == id))
            {
                return false;
            }

            favorites.Add(anime);
            return true;
        }

        public List<Anime> GetFavorites()
        {
            return favorites;
        }
    }
}
