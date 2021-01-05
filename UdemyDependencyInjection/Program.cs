using System;
using System.Threading.Tasks.Dataflow;

namespace UdemyDependencyInjection
{
    class Program
    {
        static void Main(string[] args)
        {
            IDataAccess dal = new DataAccess();
            IBusiness biz = new BusinessConstructorInjected(dal);
            var userInterface = new UserInterface(biz);
            userInterface.GetData();
        }
    }

    public class UserInterface
    {
        private readonly IBusiness _business;
        public UserInterface(IBusiness business)
        {
            _business = business;
        }
        public void GetData()
        {
            Console.WriteLine("Enter your username:");
            var userName = Console.ReadLine();

            Console.WriteLine("Enter your password:");
            var password = Console.ReadLine();

            _business.SignUp(userName, password);
        }
    }

    public interface IBusiness
    {
        void SignUp(string userName, string password);
    }

    public class BusinessCoupled : IBusiness
    {
        public void SignUp(string userName, string password)
        {
            // validation
            IDataAccess dataAccess = new DataAccess();
            dataAccess.Store(userName, password);
        }
    }

    public class BusinessConstructorInjected : IBusiness
    {
        private readonly IDataAccess _dataAccess;
        public BusinessConstructorInjected(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }
        public void SignUp(string userName, string password)
        {
            // validation
            _dataAccess.Store(userName, password);
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
