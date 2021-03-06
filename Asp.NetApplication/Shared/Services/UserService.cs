﻿using AutoMapper;
using DAL;
using Microsoft.EntityFrameworkCore;
using Shared.Models;
using System.Collections.Generic;
using System.Linq;

namespace Shared.Services
{
    public class UserService : IUserService
    {
        private EfContext efContext;
        private IMapper mapper;

        public UserService(EfContext efContext, IMapper mapper)
        {
            this.efContext = efContext;
            this.mapper = mapper;
        }

        public UserModel GetUser(int id)
        {
            var user = this.efContext.Users
                            .Where(u => u.Id == id)
                            .Include(u => u.MembershipType)
                            .FirstOrDefault();
            var userModel = this.mapper.Map<User, UserModel>(user);
            return userModel;
        }

        public List<UserModel> GetAllUsers()
        {
            var users = this.efContext
                            .Users
                            .Include(u => u.MembershipType)
                            .ToList();
            var userModels = this.mapper.Map<List<User>, List<UserModel>>(users);
            return userModels;
        }

        public int AddUser(UserModel newUser)
        {
            var user = this.mapper.Map<UserModel, User>(newUser);
            this.efContext.Users.Add(user);
            var totalStateEntriesWritten = this.efContext.SaveChanges();
            return totalStateEntriesWritten;
        }

        public int UpdateUser(UserModel selectedUser)
        {
            var dbUser = this.efContext.Users.Include(user => user.MembershipType).Single(user => user.Id == selectedUser.Id);
            dbUser = this.mapper.Map<UserModel, User>(selectedUser, dbUser);

            var totalStateEntriesWritten = this.efContext.SaveChanges();
            return totalStateEntriesWritten;
        }

        public int DeleteUser(int userId)
        {
            var dbUser = this.efContext.Users.SingleOrDefault(user => user.Id == userId);

            if (dbUser == null)
            {
                return 0;
            }

            this.efContext.Users.Remove(dbUser);

            var totalStateEntriesWritten = this.efContext.SaveChanges();
            return totalStateEntriesWritten;
        }
    }
}
