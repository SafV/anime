using AnimeContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeLogic
{
    public class Anime: IDomainObject
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public int Year { get; set; }
        public int Episodes { get; set; }

        public Anime()
        {
        }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="id"> айди</param>
        /// <param name="title">название</param>
        /// <param name="genre">жанр</param>
        /// <param name="year">год выпуска</param>
        /// <param name="episodes">количество серий</param>
        public Anime(int id, string title, string genre, int year, int episodes)
        {
            Id = id;
            Title = title;
            Genre = genre;
            Year = year;
            Episodes = episodes;
        }
        /// <summary>
        /// Вовращает строковое представление объекта аниме 
        /// </summary>
        /// <returns>возвращает строку</returns>
        public override string ToString()
        {
            return $"ID: {Id} | Название: {Title} | Жанр: {Genre} | " +
                   $"Год: {Year} | Серий: {Episodes}";
        }
    }
}
