﻿using System;
using System.Threading.Tasks.Dataflow;

namespace UdemyDependencyInjection
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    public class UserInterface
    {
        public void GetData()
        {
            Console.WriteLine("Enter your username:");
            var userName = Console.ReadLine();

            Console.WriteLine("Enter your password:");
            var password = Console.ReadLine();

            // IBusiness business = new Business();
            IBusiness business = new BusinessV2();
            business.SignUp(userName, password);
        }
    }

    public interface IBusiness
    {
        void SignUp(string userName, string password);
    }

    public class Business : IBusiness
    {
        public void SignUp(string userName, string password)
        {
            // validation
            IDataAccess dataAccess = new DataAccess();
            dataAccess.Store(userName, password);
        }
    }

    public class BusinessV2 : IBusiness
    {
        public void SignUp(string userName, string password)
        {
            // validation
            IDataAccess dataAccess = new DataAccess();
            dataAccess.Store(userName, password);
        }
    }
    public interface IDataAccess
    {
        void Store(string userName, string password);
    }

    public class DataAccess : IDataAccess
    {
        public void Store(string userName, string password)
        {
            // write the data to the db
        }
    }
}
