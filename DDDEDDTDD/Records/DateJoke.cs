using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Records
{

    /****
     * 
     * 
     * A record in C# is a new data type that was introduced in C# 9. It is a lightweight, immutable data type that is similar to a class, but with some key differences. Records are thread-safe, and because they are immutable, you cannot change them after they are created. Records also have built-in support for equality and formatting.
     * 
     */
    public record DateJoke
    {
        public string Question { get; init; }
        public string Answer { get; init; }
    }


    public record Joke
    {
        public string Setup { get; init; }
        public string Punchline { get; init; }
    }

    /***
     * This record represents a person with a name and an age. It is humble because it does not have any special properties or methods. It is simply a data structure that can be used to store information about a person.
     */

    public record Peson(string Name, int Age, string Address);


    /**
     * 
     * This record represents a book with a title, an author, and a number of pages. It is humble because it does not have any special properties or methods. It is simply a data structure that can be used to store information about a book.
     ***/

    public record Book(string Title, string Author, int Pages);
}
