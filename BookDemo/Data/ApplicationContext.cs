﻿using BookDemo.Models;

namespace BookDemo.Data
{
    public static class ApplicationContext
    {
        public static List<Book> Books { get; set; }

        static ApplicationContext()
        {
            Books = new List<Book>()
            {
                new Book(){ Id=1,Title="Karagöz ve Hacivat",Price=75},
                new Book(){ Id=2,Title="Yengeç Adımları",Price=75},
                new Book(){ Id=3,Title="Gülün Adı",Price=75},
            };
        }
    }
}
