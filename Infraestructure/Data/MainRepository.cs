﻿using Application.Models;
using Domain.Entities;
using Domain.Enums;
using Domain.Interfaces;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Infraestructure.Data
{
    public class MainRepository : IMainRepository
    {
        static int LastIdAssignedProduct = 30; //Revisar que el numero sea siempre el ultimo id asignado de la lista
        static List<Product> products = new List<Product>
        {
            new Product { Id = 1, Name = "Nydia", Price = 6, Description = "Unsp open wound of left cheek and TMJ area, init", Stock = 1, Image = "http://dummyimage.com/200x100.png/5fa2dd/ffffff", Category = "Salud", Brand = "HealthCo", Avaible = false },
            new Product { Id = 2, Name = "Waneta", Price = 61, Description = "Unsp open wound of left cheek and TMJ area, init", Stock = 2, Image = "http://dummyimage.com/200x100.png/5fa2dd/ffffff", Category = "Salud", Brand = "HealthCo", Avaible = true },
            new Product { Id = 3, Name = "Brew", Price = 66, Description = "Unsp open wound of left cheek and TMJ area, init", Stock = 3, Image = "http://dummyimage.com/200x100.png/dddddd/000000", Category = "Salud", Brand = "HealthCo", Avaible = true },
            new Product { Id = 4, Name = "Eryn", Price = 82, Description = "Unsp open wound of left cheek and TMJ area, init", Stock = 4, Image = "http://dummyimage.com/200x100.png/dddddd/000000", Category = "Salud", Brand = "HealthCo" , Avaible = true},
            new Product { Id = 5, Name = "Andre", Price = 43, Description = "Unsp open wound of left cheek and TMJ area, init", Stock = 5, Image = "http://dummyimage.com/200x100.png/ff4444/ffffff", Category = "Salud", Brand = "HealthCo", Avaible = true },
            new Product { Id = 6, Name = "Wilhelmina", Price = 60, Description = "Unsp open wound of left cheek and TMJ area, init", Stock = 6, Image = "http://dummyimage.com/200x100.png/cc0000/ffffff", Category = "Salud", Brand = "HealthCo", Avaible = true },
            new Product { Id = 7, Name = "Leonidas", Price = 13, Description = "Unsp open wound of left cheek and TMJ area, init", Stock = 7, Image = "http://dummyimage.com/200x100.png/cc0000/ffffff", Category = "Salud", Brand = "HealthCo", Avaible = true },
            new Product { Id = 8, Name = "Wilma", Price = 73, Description = "Unsp open wound of left cheek and TMJ area, init", Stock = 8, Image = "http://dummyimage.com/200x100.png/5fa2dd/ffffff", Category = "Salud", Brand = "HealthCo", Avaible = true },
            new Product { Id = 9, Name = "Leoine", Price = 97, Description = "Unsp open wound of left cheek and TMJ area, init", Stock = 9, Image = "http://dummyimage.com/200x100.png/5fa2dd/ffffff", Category = "Salud", Brand = "HealthCo", Avaible = true },
            new Product { Id = 10, Name = "Westbrook", Price = 51, Description = "Unsp open wound of left cheek and TMJ area, init", Stock = 10, Image = "http://dummyimage.com/200x100.png/dddddd/000000", Category = "Salud", Brand = "HealthCo", Avaible = true },
            new Product { Id = 11, Name = "Fons", Price = 75, Description = "Unsp open wound of left cheek and TMJ area, init", Stock = 11, Image = "http://dummyimage.com/200x100.png/cc0000/ffffff", Category = "Salud", Brand = "HealthCo", Avaible = true },
            new Product { Id = 12, Name = "Susanetta", Price = 37, Description = "Unsp open wound of left cheek and TMJ area, init", Stock = 12, Image = "http://dummyimage.com/200x100.png/cc0000/ffffff", Category = "Salud", Brand = "HealthCo", Avaible = true },
            new Product { Id = 13, Name = "Beret", Price = 62, Description = "Unsp open wound of left cheek and TMJ area, init", Stock = 13, Image = "http://dummyimage.com/200x100.png/ff4444/ffffff", Category = "Salud", Brand = "HealthCo", Avaible = true },
            new Product { Id = 14, Name = "Aida", Price = 13, Description = "Unsp open wound of left cheek and TMJ area, init", Stock = 14, Image = "http://dummyimage.com/200x100.png/5fa2dd/ffffff", Category = "Salud", Brand = "HealthCo", Avaible = true },
            new Product { Id = 15, Name = "Lucienne", Price = 70, Description = "Unsp open wound of left cheek and TMJ area, init", Stock = 15, Image = "http://dummyimage.com/200x100.png/5fa2dd/ffffff", Category = "Salud", Brand = "HealthCo", Avaible = true },
            new Product { Id = 16, Name = "Trev", Price = 2, Description = "Unsp open wound of left cheek and TMJ area, init", Stock = 16, Image = "http://dummyimage.com/200x100.png/5fa2dd/ffffff", Category = "Salud", Brand = "HealthCo", Avaible = true },
            new Product { Id = 17, Name = "Conny", Price = 19, Description = "Unsp open wound of left cheek and TMJ area, init", Stock = 17, Image = "http://dummyimage.com/200x100.png/ff4444/ffffff", Category = "Salud", Brand = "HealthCo", Avaible = true },
            new Product { Id = 18, Name = "Kelby", Price = 92, Description = "Unsp open wound of left cheek and TMJ area, init", Stock = 18, Image = "http://dummyimage.com/200x100.png/cc0000/ffffff", Category = "Salud", Brand = "HealthCo", Avaible = true },
            new Product { Id = 19, Name = "Coleen", Price = 22, Description = "Unsp open wound of left cheek and TMJ area, init", Stock = 19, Image = "http://dummyimage.com/200x100.png/5fa2dd/ffffff", Category = "Salud", Brand = "HealthCo", Avaible = true },
            new Product { Id = 20, Name = "Nicol", Price = 84, Description = "Unsp open wound of left cheek and TMJ area, init", Stock = 20, Image = "http://dummyimage.com/200x100.png/cc0000/ffffff", Category = "Salud", Brand = "HealthCo", Avaible = true },
            new Product { Id = 21, Name = "Alex", Price = 15, Description = "Proin eu mi nulla ac", Stock = 21, Image = "http://dummyimage.com/200x100.png/0000ff/ffffff", Category = "Tecnología", Brand = "TechWorld", Avaible = true },
            new Product { Id = 22, Name = "Sam", Price = 22, Description = "Vestibulum ac est lacinia nisi venenatis tristique", Stock = 22, Image = "http://dummyimage.com/200x100.png/008000/ffffff", Category = "Tecnología", Brand = "TechWorld", Avaible = true },
            new Product { Id = 23, Name = "Jamie", Price = 35, Description = "In congue etiam justo etiam pretium iaculis justo in hac habitasse platea dictumst", Stock = 23, Image = "http://dummyimage.com/200x100.png/ff0000/ffffff", Category = "Tecnología", Brand = "TechWorld", Avaible = true },
            new Product { Id = 24, Name = "Taylor", Price = 41, Description = "Nulla ut erat id mauris vulputate elementum nullam varius nulla", Stock = 24, Image = "http://dummyimage.com/200x100.png/ffff00/000000", Category = "Tecnología", Brand = "TechWorld", Avaible = true },
            new Product { Id = 25, Name = "Jordan", Price = 58, Description = "Nunc nisl duis bibendum felis sed interdum venenatis turpis enim blandit mi in porttitor pede justo eu massa donec dapibus duis at velit eu est congue elementum in hac habitasse platea dictumst", Stock = 25, Image = "http://dummyimage.com/200x100.png/000000/ffffff", Category = "Tecnología", Brand = "TechWorld", Avaible = true },
            new Product { Id = 26, Name = "Cameron", Price = 67, Description = "Etiam justo etiam pretium iaculis justo in hac habitasse platea dictumst", Stock = 26, Image = "http://dummyimage.com/200x100.png/ff00ff/ffffff", Category = "Tecnología", Brand = "TechWorld", Avaible = true },
            new Product { Id = 27, Name = "Harper", Price = 75, Description = "Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae mauris viverra diam vitae quam suspendisse potenti nullam porttitor lacus at turpis donec posuere metus vitae ipsum aliquam non mauris", Stock = 27, Image = "http://dummyimage.com/200x100.png/00ffff/000000", Category = "Tecnología", Brand = "TechWorld", Avaible = true },
            new Product { Id = 28, Name = "Morgan", Price = 88, Description = "Morbi sem mauris laoreet ut rhoncus aliquet pulvinar sed nisl nunc rhoncus dui vel sem sed sagittis nam congue risus semper porta volutpat quam pede lobortis ligula sit amet eleifend pede libero quis orci", Stock = 28, Image = "http://dummyimage.com/200x100.png/ffa500/ffffff", Category = "Tecnología", Brand = "TechWorld", Avaible = true },
            new Product { Id = 29, Name = "Charlie", Price = 96, Description = "Aliquam non mauris morbi non lectus aliquam sit amet diam in magna bibendum imperdiet nullam orci pede venenatis non sodales sed tincidunt eu felis fusce posuere felis sed lacus morbi sem mauris laoreet ut rhoncus aliquet pulvinar sed nisl nunc rhoncus dui vel sem sed sagittis nam congue risus semper porta volutpat quam pede lobortis ligula sit amet eleifend pede libero quis orci nullam molestie nibh in lectus pellentesque at nulla suspendisse potenti cras in purus eu magna vulputate luctus cum sociis natoque penatibus et magnis dis parturient montes nascetur ridiculus mus vivamus vestibulum sagittis sapien", Stock = 29, Image = "http://dummyimage.com/200x100.png/0000ff/000000", Category = "Tecnología", Brand = "TechWorld", Avaible = true },
            new Product { Id = 30, Name = "Dakota", Price = 100, Description = "Etiam faucibus cursus urna ut tellus nulla ut erat id mauris vulputate elementum nullam varius nulla facilisi cras non velit nec nisi vulputate nonummy maecenas tincidunt lacus at velit vivamus vel nulla eget eros elementum pellentesque quisque porta volutpat erat quisque erat eros viverra eget congue eget semper rutrum nulla nunc purus phasellus in felis donec semper sapien a libero nam dui proin leo odio porttitor id consequat in consequat ut nulla sed accumsan felis ut at dolor quis odio consequat varius integer ac leo pellentesque ultrices mattis odio donec vitae nisi nam ultrices libero non mattis pulvinar nulla pede ullamcorper augue a suscipit nulla elit ac nulla sed vel enim sit amet nunc viverra dapibus nulla suscipit ligula in lacus curabitur at ipsum ac tellus semper interdum mauris ullamcorper purus sit amet nulla", Stock = 30, Image = "http://dummyimage.com/200x100.png/ff0000/000000", Category = "Tecnología", Brand = "TechWorld", Avaible = true }
        };


        static int LastIdAssignedUser = 24; //Revisar que el numero sea siempre el ultimo id asignado de la lista
        static List<User> users = new List<User>
        {
            new User {Id = 1, Name = "Alejandro", LastName = "Di Stefano", Password = "a",Email = "a",UserName = "aleDiStefano",Adress = "Zeballos 1341",Orders = new List<Order>(),Products = new List<Product>(),UserType = UserType.Client,IsActive = true},
            new User {Id = 2, Name = "Marco", LastName = "Ruben", Password = "rc1",Email = "lakd@mail.com",UserName = "MarcoRuben",Adress = "Zeballos 1341",Orders = new List<Order>(),Products = new List<Product>(),UserType = UserType.Client,IsActive = true},
            new User {Id = 3,Name = "Gaston",LastName = "Koch",Password = "Gaston1",Email = "Gaston@mail.com",UserName = "GastonKoch",Adress = null,Orders = null,Products = null,UserType = UserType.Seller,IsActive = true},
            new User {Id = 4,Name = "Admin",LastName = "sysAdmin",Password = "admin",Email = "admin",UserName = "SysAdmin",Adress = null,Orders = null,Products = null,UserType = UserType.SysAdmin, IsActive = true},
        
            // Clientes
            new User {Id = 5, Name = "Marco", LastName = "Perez", Password = "jp1", Email = "juan.perez@mail.com", UserName = "JuanPerez", Adress = "Calle Falsa 123", Orders = new List<Order>(), Products = new List<Product>(), UserType = UserType.Client, IsActive = true},
            new User {Id = 6, Name = "Ana", LastName = "Gomez", Password = "ag2", Email = "ana.gomez@mail.com", UserName = "AnaGomez", Adress = "Avenida Siempreviva 456", Orders = new List<Order>(), Products = new List<Product>(), UserType = UserType.Client, IsActive = true},
            new User {Id = 7, Name = "Luis", LastName = "Martinez", Password = "lm3", Email = "luis.martinez@mail.com", UserName = "LuisMartinez", Adress = "Boulevard San Juan 789", Orders = new List<Order>(), Products = new List<Product>(), UserType = UserType.Client, IsActive = true},
            new User {Id = 8, Name = "Maria", LastName = "Rodriguez", Password = "mr4", Email = "maria.rodriguez@mail.com", UserName = "MariaRodriguez", Adress = "Pasaje del Sol 101", Orders = new List<Order>(), Products = new List<Product>(), UserType = UserType.Client, IsActive = true},
            new User {Id = 9, Name = "Carlos", LastName = "Lopez", Password = "cl5", Email = "carlos.lopez@mail.com", UserName = "CarlosLopez", Adress = "Camino de los Pinos 202", Orders = new List<Order>(), Products = new List<Product>(), UserType = UserType.Client, IsActive = true},
            new User {Id = 10, Name = "Elena", LastName = "Garcia", Password = "eg6", Email = "elena.garcia@mail.com", UserName = "ElenaGarcia", Adress = "Ruta 9 KM 33", Orders = new List<Order>(), Products = new List<Product>(), UserType = UserType.Client, IsActive = true},
            new User {Id = 11, Name = "Miguel", LastName = "Hernandez", Password = "mh7", Email = "miguel.hernandez@mail.com", UserName = "MiguelHernandez", Adress = "Calle de la Luna 404", Orders = new List<Order>(), Products = new List<Product>(), UserType = UserType.Client, IsActive = true},
            new User {Id = 12, Name = "Laura", LastName = "Fernandez", Password = "lf8", Email = "laura.fernandez@mail.com", UserName = "LauraFernandez", Adress = "Avenida de los Poetas 505", Orders = new List<Order>(), Products = new List<Product>(), UserType = UserType.Client, IsActive = true},
            new User {Id = 13, Name = "Pedro", LastName = "Ruiz", Password = "pr9", Email = "pedro.ruiz@mail.com", UserName = "PedroRuiz", Adress = "Calle de las Flores 606", Orders = new List<Order>(), Products = new List<Product>(), UserType = UserType.Client, IsActive = true},
            new User {Id = 14, Name = "Sofia", LastName = "Diaz", Password = "sd10", Email = "sofia.diaz@mail.com", UserName = "SofiaDiaz", Adress = "Plaza del Sol 707", Orders = new List<Order>(), Products = new List<Product>(), UserType = UserType.Client, IsActive = true},
            // Vendedores
            new User {Id = 15, Name = "Lucia", LastName = "Perez", Password = "AnaP123", Email = "ana.perez@mail.com", UserName = "AnaPerez", Adress = null, Orders = null, Products = null, UserType = UserType.Seller, IsActive = true},
            new User {Id = 16, Name = "Carla", LastName = "Lopez", Password = "CarlosL321", Email = "carlos.lopez@mail.com", UserName = "CarlosLopez", Adress = null, Orders = null, Products = null, UserType = UserType.Seller, IsActive = true},
            new User {Id = 17, Name = "Micaela", LastName = "Gomez", Password = "MariaG456", Email = "maria.gomez@mail.com", UserName = "MariaGomez", Adress = null, Orders = null, Products = null, UserType = UserType.Seller, IsActive = true},
            new User {Id = 18, Name = "Jose", LastName = "Fernandez", Password = "JorgeF654", Email = "jorge.fernandez@mail.com", UserName = "JorgeFernandez", Adress = null, Orders = null, Products = null, UserType = UserType.Seller, IsActive = true},
            new User {Id = 19, Name = "Jose", LastName = "Martinez", Password = "LuciaM789", Email = "lucia.martinez@mail.com", UserName = "LuciaMartinez", Adress = null, Orders = null, Products = null, UserType = UserType.Seller, IsActive = true},
            new User {Id = 20, Name = "Pedro", LastName = "Diaz", Password = "PedroD987", Email = "pedro.diaz@mail.com", UserName = "PedroDiaz", Adress = null, Orders = null, Products = null, UserType = UserType.Seller, IsActive = true},
            new User {Id = 21, Name = "Lucia", LastName = "Suarez", Password = "ElenaS123", Email = "elena.suarez@mail.com", UserName = "ElenaSuarez", Adress = null, Orders = null, Products = null, UserType = UserType.Seller, IsActive = true},
            new User {Id = 22, Name = "Gaston", LastName = "Mendez", Password = "RicardoM321", Email = "ricardo.mendez@mail.com", UserName = "RicardoMendez", Adress = null, Orders = null, Products = null, UserType = UserType.Seller, IsActive = true},
            new User {Id = 23, Name = "Natalia", LastName = "Ramirez", Password = "NataliaR456", Email = "natalia.ramirez@mail.com", UserName = "NataliaRamirez", Adress = null, Orders = null, Products = null, UserType = UserType.Seller, IsActive = true},
            new User {Id = 24, Name = "Victor", LastName = "Morales", Password = "VictorM654", Email = "victor.morales@mail.com", UserName = "VictorMorales", Adress = null, Orders = null, Products = null, UserType = UserType.Seller, IsActive = true}


        };

        static int LastIdAssignedOrder = 1;
        static List<Order> orders = new List<Order>
        {
            new Order{Id = 1, User = users[0], Products = products.Take(4).ToList() },
        };




        #region ORDERS
        public List<Order> GetOrders()
        {
            return orders.ToList();
        }


        public Order CreateOrder(Order order)
        {
            order.Id = ++LastIdAssignedOrder;
            orders.Add(order);
            return order;
        }

        public Order GetOrderById(int id)
        {
            return orders.FirstOrDefault(x => x.Id == id);
        }
        #endregion

        #region PRODUCTS
        public List<Product> GetProducts()
        {
            return products.ToList();
        }

        public List<Product> GetProductsDisponible()
        {
            return products.Where(p => p.Avaible == true).ToList();
        }

        public Product GetProductById(int id)
        {
            return products.FirstOrDefault(x => x.Id == id);
        }

        public Product GetProductByName(string name)
        {
            return products.FirstOrDefault(x => x.Name == name);
        }

        public Product CreateProduct(Product product)
        {
            product.Id = ++LastIdAssignedProduct;
            products.Add(product);
            return product;
        }

        public void UpdateProduct(Product product)
        {
            var obj = products.FirstOrDefault(x => x.Id == product.Id);
            obj.Name = product.Name;
        }

        public void UpdateProductDisponible(Product product)
        {
            var obj = products.FirstOrDefault(x => x.Id == product.Id);
            obj.Avaible = product.Avaible;
        }

        public void DeleteProduct(Product product)
        {
            products.Remove(product);
        }
        #endregion

        #region USER
        public List<User> GetUsers()
        {
            return users.ToList();
        }

        public User GetUserById(int id)
        {
            return users.FirstOrDefault(x => x.Id == id);
        }
        public User GetUserByEmail(string email)
        {
            return users.FirstOrDefault(x => x.Email == email);
        }

        public List<User> GetUsersByName(string name)
        {
            return users.Where(x => x.Name == name).ToList();
        }

        public List<User> GetUserByType(UserType type)
        {
            List<User> filteredUsers = users.Where(x => x.UserType == type).ToList();
            return filteredUsers;
        }

        public User CreateUser(User user)
        {
            user.Id = ++LastIdAssignedUser;
            users.Add(user);
            return user;
        }

        public void UpdateUser(User user)
        {
            var obj = users.FirstOrDefault(x => x.Id == user.Id);
            obj.Name = user.Name;
            obj.LastName = user.LastName;
            obj.Password = user.Password;
            obj.Email = user.Email;
            obj.UserName = user.UserName;
            obj.Adress = user.Adress;
        }

        public void DeleteUser(User user)
        {
            users.Remove(user);
        }

        public void ActiveUser(int id)
        {
            var obj = users.FirstOrDefault(x => x.Id == id);
            obj.IsActive = true;
        }

        public bool ValidateUserCredentials(string userEmail, string userPassword)
        {
            return users.Any(p => p.Email == userEmail && p.Password == userPassword);
        }

        public bool ValidateUserNickName(string userNickName)
        {
            return users.Any(p => p.UserName == userNickName);
        }

        public bool ValidateUserMail(string userMail)
        {
            return users.Any(p => p.Email == userMail);
        }
        #endregion

    }
}
