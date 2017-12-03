using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LINQPractice;
using System.Collections.Generic;

namespace LINQPractice.Tests
{
    [TestClass]
    public class SQLtest
    {
        List<User> firstList;
        List<User> secondList;

        QuerySyntax sql = new QuerySyntax();

        [TestInitialize]
        public void Initialize()
        {
            firstList = new List<User>
            {
                new User(11, "Алексей", "Овчаренко", new DateTime(1969, 12, 24)),
                new User(12, "Алексей", "Овчаренко", new DateTime(1971, 04, 07)),
                new User(13, "Мария", "Крюкова", new DateTime(1964, 02, 22)),
                new User(14, "Владимир", "Федоров", new DateTime(1974, 05, 03)),
                new User(15, "Анна", "Шпагина", new DateTime(1967, 03, 13)),
                new User(16, "Павел", "Шаров", new DateTime(1976, 06, 01)),
                new User(17, "Анатолий", "Ковальчук", new DateTime(1972, 05, 18)),
                new User(18, "Ксения", "Астанова", new DateTime(1968, 09, 26)),
                new User(19, "Борис", "Тихий", new DateTime(1975, 11, 30)),
                new User(20, "Евгений", "Сыромятников", new DateTime(1959, 10, 11))
            };

            secondList = new List<User>
            {
                new User(21, "Владимир", "Федоров", new DateTime(1976, 12, 01)),
            new User(22, "Полина", "Белкина", new DateTime(1971, 07, 05)),
            new User(23, "Михаил", "Титов", new DateTime(1978, 03, 13)),
            new User(24, "Кирилл", "Кравченко", new DateTime(1977, 04, 14)),
            new User(25, "Анастасия", "Змей", new DateTime(1958, 08, 04)),
            new User(26, "Владислав", "Ильин", new DateTime(1972, 02, 17)),
            new User(27, "Никита", "Полянский", new DateTime(1968, 06, 21)),
            new User(28, "Владимир", "Гарин", new DateTime(1973, 11, 09)),
            new User(29, "Светлана", "Тимченко", new DateTime(1977, 07, 11)),
            new User(30, "Оксана", "Мельник", new DateTime(1965, 10, 29))
            };
        }

        [TestMethod]
        public void Query_GetUsersUpperThan40()
        {
            var result = sql.GetUsers(firstList);

            foreach (var res in result)
            {
                Assert.IsNotNull(res);
                Assert.IsTrue(res.Age > 40);
            }
        }

        [TestMethod]
        public void Query_GetFullNames()
        {
            var result = sql.GetFullNames(firstList);

            foreach (var res in result)
            {
                Assert.IsNotNull(res);
                Assert.IsInstanceOfType(res, typeof(UserName));
                Assert.IsTrue(res.FirstName is string);
                Assert.IsTrue(res.LastName is string);
            }
        }

        [TestMethod]
        public void Query_GetUsersAndTheirAges()
        {
            var result = sql.GetUsersInCollections(firstList, secondList);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Query_GetLastNames_Test()
        {
            var result = sql.GetLastNames(firstList);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Contains(","));
        }

        [TestMethod]
        public void Query_Sort_Test()
        {
            var result = sql.Sort(firstList);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Query_TransformToDictionary_Test()
        {
            var result = sql.Transform(firstList);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.ContainsKey(11));
        }
    }
}
