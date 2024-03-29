﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memento
{
    public class Program
    {
        static void Main(string[] args)
        {
            Book book = new Book
            {
                Title = "Tutunamayanlar",
                Author = "Oguz Atay    <-",
                Isbn = "19258741"
            };
            book.ShowBook();
            Console.WriteLine();

            CareTaker history = new CareTaker();
            history.memento = book.CreateUndo();

            book.Isbn = "123456789";
            book.Author = "Oğuz Atay   <-";

            book.ShowBook();
            Console.WriteLine();

            book.RestoreFromUndo(history.memento);
            book.ShowBook();

            Console.ReadLine();
        }
    }

    class Book
    {
        private string _title;
        private string _author;
        private string _isbn;
        DateTime _lastEdited;
        public string Title
        {
            get { return _title; }
            set 
            { 
                _title = value;
                SetLastEdited();
            }
        }
        public string Author
        {
            get { return _author; }
            set 
            { 
                _author = value;
                SetLastEdited();
            }
        }
        public string Isbn
        {
            get { return _isbn; }
            set 
            {
                _isbn = value;
                SetLastEdited();
            }
        }

        private void SetLastEdited()
        {
            _lastEdited = DateTime.UtcNow;   
        }

        public Memento CreateUndo()
        {
            return new Memento(_title,_author,_isbn,_lastEdited);
        }

        public void RestoreFromUndo(Memento memento)
        {
            _title=memento.Title;
            _author=memento.Author;
            _isbn=memento.Isbn;
            _lastEdited=memento.LastEdited;
        }

        public void ShowBook()
        {
            Console.WriteLine("Book Title: {0}",Title);
            Console.WriteLine("Book Author: {0}",Author);
            Console.WriteLine("Book ISBN: {0}",Isbn);
            Console.WriteLine("Edited: {0}",_lastEdited);
        }
    }

    class Memento
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Isbn { get; set; }
        public DateTime LastEdited { get; set; }

        public Memento(string title, string author, string isbn, DateTime lastEdited) 
        {
            Isbn = isbn;
            Title = title;
            Author = author;
            LastEdited = lastEdited;
        }
    }

    class CareTaker
    {
        public Memento memento { get; set; }

    }
}
