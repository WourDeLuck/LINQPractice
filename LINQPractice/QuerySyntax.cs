using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQPractice
{
    /// <summary>
    /// Class with actions performed with query syntax of LINQ.
    /// </summary>
    public class QuerySyntax
    {
        /// <summary>
        /// 1. Get a list of users older than 40.
        /// </summary>
        /// <param name="userList">List of users.</param>
        /// <returns>List of users of age upper than 40.</returns>
        public IEnumerable<User> GetUsers(List<User> userList)
        {
            IEnumerable<User> users =
                from usr in userList
                where usr.Age > 40
                select usr;

            return users;
        }

        /// <summary>
        /// 2. Get list of users' full names, who's age is between 20 and 30
        /// </summary>
        /// <param name="userList">List of users.</param>
        /// <returns>Full names of users, who's age is between 20 and 30.</returns>
        public IEnumerable<UserName> GetFullNames(List<User> userList)
        {
            var users =
                from usr in userList
                where (usr.Age > 20 && usr.Age < 30)
                select new UserName{ FirstName = usr.FirstName, LastName = usr.LastName};

            return users;
        }

        /// <summary>
        /// 3. Get list of users from both collections with same name and find their min and max ages.
        /// </summary>
        /// <param name="l1">First list</param>
        /// <param name="l2">Second list</param>
        /// <returns>Min and max ages.</returns>
        public Tuple<int,int> GetUsersInCollections(List<User> l1, List<User> l2)
        {
            var duplicates =
                (from us in l1
                 join ur in l2
                 on us.FirstName equals ur.FirstName
                 select us).Distinct();

            var min = duplicates.Min(x => x.Age);
            var max = duplicates.Max(x => x.Age);

            return Tuple.Create(min,max);
        }

        /// <summary>
        /// 4. Get a string of users' last names.
        /// </summary>
        /// <param name="userList">List of users.</param>
        /// <returns>String of users' lasn names.</returns>
        public string GetLastNames(List<User> userList)
        {
            var users =
                from usr in userList
                select usr.LastName;

            string result = null;

            foreach (var user in users)
            {
                result = user + ", ";
            }

            return result;
        }

        /// <summary>
        /// 5. Sort the collection by age descending, deleting repeating names and grouping by age
        /// </summary>
        /// <param name="">List of users.</param>
        /// <returns>Sorted collection.</returns>
        public IGrouping<int,User>[] Sort(List<User> userList)
        {        
            var usersUnique = 
                from usr in userList
                group usr by new {usr.FirstName}
                into unique
                select unique.FirstOrDefault();

            var result =
                (from usr in usersUnique
                 orderby usr.Age descending
                 group usr by usr.Age).ToArray();

            return result;
        }

        /// <summary>
        /// 6. Transform list to a dictionary, where Key is ID and Value is users' Full Name
        /// </summary>
        /// <param name="userList">List of users.</param>
        /// <returns>Dictionary.</returns>
        public Dictionary<int, UserName> Transform(List<User> userList)
        {
            Dictionary<int, UserName> dict = new Dictionary<int, UserName>();

            foreach(var user in userList)
            {
                dict.Add(user.Id, new UserName { FirstName = user.FirstName, LastName = user.LastName});
            }

            return dict;
        }    
    }
}
