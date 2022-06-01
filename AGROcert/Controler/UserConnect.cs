using Dapper;
using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows;
using AGROcert.Models;

namespace AGROcert.Controler
{
    public static class UserConnect
    {
 
        public static string connectionString = @"Data Source = SQL8003.site4now.net,1433; Initial Catalog = db_a878c3_tibiriumtype; User Id = db_a878c3_tibiriumtype_admin; Password=tibirium1;";
  

        public static void RegistrationUser(string email, string pass, string name, string surname, string phone)
        {
            if (CheckEmailUser(email)) MessageBox.Show("Пользователь с таким Email адресом уже существует");
            else
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    User registration = new User();
                    registration.UserEmail = email;
                    registration.UserName = name;
                    registration.UserSurname = surname;
                    registration.UserPhone = phone;
                    registration.UserPassword = Crypt.Generate(pass);
                    connection.Insert(registration);
                    MessageBox.Show("Вы успешно зарегестрированы!");
                }

                //using (SqlConnection connection = new SqlConnection(connectionString))
                //{
                //    Administrator registration = new Administrator();
                //    registration.AdmEmail = email;
                //    registration.AdmName = name;
                //    registration.AdmSurname = surname;
                //    registration.AdmPhone = phone;
                //    registration.AdmPassword = Crypt.Generate(pass);
                //    connection.Insert(registration);
                //    MessageBox.Show("Вы успешно зарегестрированы!");
                //}
            }
        }

        public static bool LoginAdministrator(string email, string pass)
        {
            bool check = false;
            foreach (var it in GetAdministrators())
            {
                if (it.AdmEmail == email && Crypt.Veryfy(pass, it.AdmPassword))
                {
                    check = true;
                }
            }
            return check;
        }

        public static bool LoginUser(string email, string pass)
        {
            bool check = false;
            foreach (var it in GetUsers())
            {
                if (it.UserEmail == email && Crypt.Veryfy(pass, it.UserPassword))
                {
                    check = true;
                }
            }
            return check;
        }

        public static bool CheckEmailUser(string email)
        {
            bool check = false;
            foreach (var it in GetUsers()) 
            {
                if (it.UserEmail == email)
                {
                    check = true;
                }
            }
            return check;
        }

        public static bool CheckPasswordUser(string pass)
        {
            bool check = false;
            foreach (var it in GetUsers())
            {
                if (Crypt.Veryfy(pass, it.UserPassword))
                {
                    check = true;
                }
            }
            return check;
        }

        public static bool CheckEmailAdministrator(string email)
        {
            bool check = false;
            foreach (var it in GetAdministrators())
            {
                if (it.AdmEmail == email)
                {
                    check = true;
                }
            }
            return check;
        }

        public static bool CheckPasswordAdministrator(string pass)
        {
            bool check = false;
            foreach (var it in GetAdministrators())
            {
                if (Crypt.Veryfy(pass, it.AdmPassword))
                {
                    check = true;
                }
            }
            return check;
        }

        public static List<Administrator> GetAdministrators()
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                return connection.Query<Administrator>($"SELECT * FROM Administrators").ToList();
            }
        }

        public static List<User> GetUsers()
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                return connection.Query<User>($"SELECT * FROM Users").ToList();
            }
        }
    }
}
