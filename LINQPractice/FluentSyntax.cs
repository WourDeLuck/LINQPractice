using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQPractice
{
    /// <summary>
    /// Class of actions performed with fluent syntax of LINQ.
    /// </summary>
    public class FluentSyntax
    {
        /// <summary>
        /// 1. Get a list of users older than 40.
        /// </summary>
        /// <param name="userList">List of users.</param>
        /// <returns>List of users older than 40.</returns>
        public IEnumerable<User> GetUsers(List<User> userList)
        {
            var users = userList.Where(x => x.Age > 40);

            return users;
        }

        /// <summary>
        /// 2. Get list of users' full names, who's age is between 20 and 30
        /// </summary>
        /// <param name="userList">List of users.</param>
        /// <returns>Users' names who's age is between 20 and 30</returns>
        public IEnumerable<UserName> GetFullNames(List<User> userList)
        {
            var users = userList
                .Where(x => x.Age > 20 && x.Age < 30)
                .Select(n => new UserName { FirstName = n.FirstName, LastName = n.LastName });

            return users;
        }

        /// <summary>
        /// 3. Get list of users from both collections and find their min and max ages.
        /// </summary>
        /// <param name="l1">First list.</param>
        /// <param name="l2">Second list.</param>
        /// <returns>A pair of min and max values.</returns>
        public Tuple<int,int> GetUsersInCollections(List<User> l1, List<User> l2)
        {
            var duplicates = l1
                .Where(x => l2.Any(y => string.Equals(x.FirstName, y.FirstName)))
                .Concat(l2.Where(x => l1.Any(y => string.Equals(x.FirstName, y.FirstName))));

            var min = duplicates.Min(x => x.Age);
            var max = duplicates.Max(x => x.Age);

            return Tuple.Create(min,max);
        }

        /// <summary>
        /// 4. Get a string of users' last names.
        /// </summary>
        /// <param name="userList">Strinf of users' last names</param>
        /// <returns></returns>
        public string GetLastNames(List<User> userList)
        {
            var users = userList.Select(x => x.LastName);

            string result = null;

            foreach(var user in users)
            {
                result = user + ", ";
            }

            return result;
        }

        /// <summary>
        /// 5. Sort the collection by age descending, deleting repeating names and grouping by age
        /// </summary>
        /// <param name="userList">List of users.</param>
        /// <returns>Sorted and flatten collection.</returns>
        public IGrouping<int, User>[] Sort(List<User> userList)
        {
            var userUnique = userList
                .GroupBy(x => x.FirstName)
                .Where(y => y.Count() == 1)
                .SelectMany(z => z)
                .ToList();

            var groupped = userUnique
                .OrderBy(x => x.Age)
                .GroupBy(y => y.Age)
                .ToArray();

            return groupped;
        }

        /// <summary>
        /// 6. Transform list to a dictionary, where Key is ID and Value is users' Full Name
        /// </summary>
        /// <param name="userList"></param>
        /// <returns></returns>
        public Dictionary<int, UserName> Transform(List<User> userList)
        {
            var dict = userList
                .ToDictionary(p => p.Id, g => new UserName { FirstName = g.FirstName, LastName = g.LastName });

            return dict;
        }
    }
}
