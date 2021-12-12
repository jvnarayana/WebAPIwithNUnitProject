using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;
using WebApplication2;
using WebApplication2.Controllers;
using WebApplication2.Services;
using static System.Net.WebRequestMethods;

namespace TestProject1
{
   [TestFixture]
    public class Tests
    {
        private  BookService _bookservice;
        [SetUp]
        public void Setup()
        {
            _bookservice = new BookService();

        }

        [Test]

        public void Test1()
        {
            var controller = new BooksController(_bookservice);
            var response = controller.Get();
            Assert.IsNotNull(response);
          
        }
    }
}