namespace BookShop
{
    using BookShop.Models;
    using BookShop.Models.Enums;
    using Data;
    using Initializer;
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();
            DbInitializer.ResetDatabase(db);
            //int command = int.Parse(Console.ReadLine());
            //string result = GetBooksByPrice(db);
            //Console.WriteLine(RemoveBooks(db));
        }

        //Task 2
        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            StringBuilder sb = new StringBuilder();
            AgeRestriction ageRestriction;
            bool parseSuccess = Enum.TryParse(command, true, out ageRestriction);
            if (!parseSuccess)
            {
                return String.Empty;
            }

            string[] bookTitles = context.Books
                .Where(b => b.AgeRestriction == ageRestriction)
                .Select(b => b.Title)
                .OrderBy(t => t)
                .ToArray();
            return String.Join(Environment.NewLine, bookTitles);
        }

        //Task 3
        public static string GetGoldenBooks(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            var goldenBooks = context.Books.Where(b => b.EditionType == EditionType.Gold && b.Copies < 5000).Select(b => new
            {
                b.Title,
                BookId = b.BookId
            }).OrderBy(b => b.BookId).ToArray();

            foreach (var book in goldenBooks)
            {
                sb.AppendLine(book.Title);
            }

            return sb.ToString().TrimEnd();
        }

        //Task 4
        public static string GetBooksByPrice(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            var books = context.Books.Where(b => b.Price > 40).Select(b => new
            {
                Title = b.Title,
                Price = b.Price,
            }).OrderByDescending(b => b.Price).ToList();

            foreach (var b in books)
            {
                sb.AppendLine($"{b.Title} - ${b.Price:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        //Task 5
        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            string[] bookTitles = context.Books
                .Where(b => b.ReleaseDate.Value.Year != year)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)
                .ToArray();

            return String.Join(Environment.NewLine, bookTitles);
        }

        //Task 6
        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            var categories = input.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.ToLower())
                .ToList();
            var books = context.Books.Where(b => b.BookCategories.Any(b => categories.Contains(b.Category.Name.ToLower())))
                .OrderBy(b => b.Title)
                .Select(b => b.Title)                
                .ToList();

            return String.Join(Environment.NewLine, books);
        }

        //Task 7
        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            var dargetDate = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);

            var books = context.Books
                .Where(b => b.ReleaseDate.Value < dargetDate)
                .Select(b => new
                {
                    Title = b.Title,
                    Price = b.Price,
                    Edition = b.EditionType,
                    ReleaseDate = b.ReleaseDate.Value
                })
                .OrderByDescending(b => b.ReleaseDate)
                .ToList();

            return String.Join(Environment.NewLine, books.Select(x => $"{x.Title} - {x.Edition} - ${x.Price:f2}"));
        }

        //Task 8 
        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            string[] authorNames = context.Authors
                .Where(a => a.FirstName.EndsWith(input))
                .Select(a => $"{a.FirstName} {a.LastName}")
                .ToArray()
                .OrderBy(n => n)
                .ToArray();

            return String.Join(Environment.NewLine, authorNames);
        }

        //Task 9 
        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            var books = context.Books
                .Where(b => b.Title.ToLower().Contains(input.ToLower()))
                .Select(b => b.Title)
                .OrderBy(b => b)
                .ToList();

            return String.Join(Environment.NewLine, books);
        }

        //Task 10
        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            var books = context.Books
               .Where(b => b.Author.LastName.ToLower().StartsWith(input.ToLower()))
               .Select(b => new
               {
                   Title = b.Title,
                   Author = $"{b.Author.FirstName} {b.Author.LastName}",
                   Id = b.BookId
               })
               .OrderBy(b => b.Id)
               .ToList();

            return String.Join(Environment.NewLine, books.Select(b => $"{b.Title} ({b.Author})"));
        }

        //Task 11
        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            var books = context.Books
                .Count(b => b.Title.Length > lengthCheck);

            return books;
        }

        //Task 12
        public static string CountCopiesByAuthor(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            var authors = context.Authors.Select(a => new
            {
                AuthorName = $"{a.FirstName} {a.LastName}",
                BookCopies = a.Books.Sum(b => b.Copies)
            })
                .OrderByDescending(a => a.BookCopies)
                .ToArray();
            foreach (var author in authors)
            {
                sb.AppendLine($"{author.AuthorName} - {author.BookCopies}");
            }

            return sb.ToString().TrimEnd();
        }

        //Task 13
        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            var categoriesPRofit = context.Categories.Select(c => new
            {
                c.Name,
                Profit = c.CategoryBooks.Sum(cb => cb.Book.Copies * cb.Book.Price)
            }).OrderByDescending(c => c.Profit).ThenBy(c => c.Name).ToArray();

            foreach (var category in categoriesPRofit)
            {
                sb.AppendLine($"{category.Name} ${category.Profit:f2}");
            }
            return sb.ToString().TrimEnd();
        }

        //Task 14
        public static string GetMostRecentBooks(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            var realiseDate = context.Categories.Select(c => new
            {
                c.Name,
                MostRecent = c.CategoryBooks.OrderByDescending(cb => cb.Book.ReleaseDate.Value).Select(cb => new
                {
                    BookTitle = cb.Book.Title,
                    BookReleaseYear = cb.Book.ReleaseDate.Value.Year
                }).Take(3).ToArray()
            }).OrderBy(c => c.Name).ToArray();

            foreach (var category in realiseDate)
            {
                sb.AppendLine($"--{category.Name}");
                foreach (var item in category.MostRecent)
                {
                    sb.AppendLine($"{item.BookTitle} ({item.BookReleaseYear})");
                }
            }
            return sb.ToString().TrimEnd();
        }

        //Task 15
        public static void IncreasePrices(BookShopContext context)
        {
            IQueryable<Book> bookBeforYear = context.Books.Where(b => b.ReleaseDate.Value.Year < 2010);
            foreach (var book in bookBeforYear)
            {
                book.Price += 5;
            }
            context.SaveChanges();
        }

        //Task 16
        public static int RemoveBooks(BookShopContext context)
        {
            var books = context.Books
              .Where(x => x.Copies < 4200)
              .ToList();

            context.Books.RemoveRange(books);

            context.SaveChanges();

            return books.Count();
        }
    }
}
