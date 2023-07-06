﻿         using BirdTrading.DataAccess;
using BirdTrading.Domain.Models;
using BirdTrading.Interface.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Runtime.CompilerServices;

namespace BirdTrading.Repository.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<User> CreateUserAsync(string username, string password, String fullname)
        {
            User user = await _context.Set<User>().FirstOrDefaultAsync(u => (u.Email == username || u.Phone == username));
            if (user == null)
            {
                user = new User
                {
                    Email = username.Contains("@") ? username : "",
                    Phone = username.Contains("@") ? "" : username,
                    Name = fullname,
                    Password = password,
                    Role = Domain.Enums.UserRole.Customer,
                    AvatarURL= "",
                    IsTempUser = false,
                    IsBlocked = false,
                    ShippingInforId = 0
                };
                 user.Id =  _context.Set<User>().Add(user).Entity.Id;
                _context.SaveChanges();
                return user; 
            }
            return null;
        }

        public async Task<User?> GetUserByEmailOrPhoneAndPasswordAsync(string username, string password)
        {
            return await _context.Set<User>().
                FirstOrDefaultAsync(x => (x.Email == username || x.Phone == username)
                && x.Password == password);
        }

        public async Task<User> ModifyShippingInformationAsync(ShippingInformation shippingInformation, int userId, int shippingInformationId)
        {
            var currentUser = await _context.Users
         .Include(u => u.ShippingInformations)
         .FirstOrDefaultAsync(u => u.Id == userId);

            if (currentUser != null)
            {
                try
                {
                    var shippingInformationsList = currentUser.ShippingInformations.ToList();

                    if (shippingInformationId == -1)
                    {
                        if (shippingInformation.IsDefaultAddress)
                        {
                            foreach (var address in shippingInformationsList)
                            {
                                address.IsDefaultAddress = false;
                            }
                        }
                        shippingInformationsList.Add(shippingInformation);
                      
                    }
                    else
                    {
                        foreach (var address in shippingInformationsList)
                        {
                            if (shippingInformation.IsDefaultAddress)
                            {
                                address.IsDefaultAddress = false;
                            }
                            if (address.Id == shippingInformationId)
                            {
                                address.Name = shippingInformation.Name;
                                address.Address = shippingInformation.Address;
                                address.City = shippingInformation.City;
                                address.Phone = shippingInformation.Phone;
                                address.IsDefaultAddress = shippingInformation.IsDefaultAddress;
                            }
                        }
                    }
                    _context.Entry(currentUser).State = EntityState.Modified;
                    currentUser.ShippingInformations = shippingInformationsList;
                    await _context.SaveChangesAsync();
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }              
            }
            return currentUser;
        }

        public async Task<IList<ShippingInformation>> SetDefaultShippingInformationUserAsync(int shippingInformationId, int userId)
        {

            var currentUser =  _context.Users.Include(u => u.ShippingInformations).FirstOrDefault(u => u.Id == userId);
            var shippingInformationsList = currentUser.ShippingInformations.ToList();
            foreach (var address in shippingInformationsList)
                {
                       address.IsDefaultAddress = false;
                if (address.Id == shippingInformationId)
                    {
                        address.IsDefaultAddress = true;
                    } 
                }
                currentUser.ShippingInformations = shippingInformationsList;
                _context.Entry(currentUser).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            return shippingInformationsList;
        }

        public async Task<User> UpdateImageAsync(string url, int userId)
        {
            var currentUser = await _context.Set<User>().FirstOrDefaultAsync(u => u.Id == userId);
            if (currentUser != null)
            {
                currentUser.AvatarURL = url;
                _context.Entry(currentUser).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            return currentUser;
        }

        public async Task<User> UpdatePasswordAsync(string password, int userId)
        {
            var currentUser = await _context.Set<User>().FirstOrDefaultAsync(u => u.Id == userId);
            if (currentUser != null)
            {
                currentUser.Password = password;
                _context.Entry(currentUser).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            return currentUser;
        }

        public async Task<User> UpdateUserAsync(User user)
        {
            var currentUser = await _context.Set<User>().FirstOrDefaultAsync(u => u.Id == user.Id);
            if (currentUser != null)
            {
                currentUser.Name = user.Name;
                currentUser.Email = user.Email;
                _context.Entry(currentUser).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return currentUser;
            }
            return null;
        }
        public async Task<User> UpdateUserRole(User user)
        {
            var currentUser = await _context.Set<User>().FirstOrDefaultAsync(u => u.Id == user.Id);
            if (currentUser != null)
            {
                currentUser.Role = Domain.Enums.UserRole.ShopOwner;
                _context.Entry(currentUser).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return currentUser;
            }
            return null;
        }
    }
}
