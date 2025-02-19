using System;
using Bogus;
using DotNetEnv;
using Infrastructure.Models;

namespace Infrastructure.Factories
{
    public static class UserFactory
    {
        public static User GenerateInvalidUser()
        {
            Faker<User> _faker = new Faker<User>()
                .RuleFor(u => u.Username, f => f.Internet.UserName())
                .RuleFor(u => u.Password, f => f.Internet.Password());

            return _faker.Generate();
        }

        public static User GetValidUser()
        {
            Env.TraversePath().Load();           
            return new User
            (
                Env.GetString("SAUCE_USERNAME"),
                Env.GetString("SAUCE_PASSWORD"));
        }
    }
}