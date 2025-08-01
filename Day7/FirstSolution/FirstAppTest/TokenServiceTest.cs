using FirstAPI.Interfaces;
using FirstAPI.Models.DTOs;
using FirstAPI.Services;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstAppTest
{
    public class TokenServiceTest
    {
        ITokenService _tokenService;
        [SetUp]
        public void Setup()
        {
            var config = new ConfigurationBuilder()
                .AddInMemoryCollection(new Dictionary<string, string>
                {
                    ["Tokens:JWT"]="This is for unit testing purpose to ckec teh token"
                }).Build();
               
              _tokenService = new TokenService(config);
        }


        [Test]
        public async Task TokenServicePassTest()
        {
            //arrange
            var user = new TokenUser
            {
                Username = "Test",
                Role = "Tester"
            };
            //action
            var result = await _tokenService.GenerateToken(user);

            //assert
            Assert.That(result,Is.Not.Null);


        }

        [TearDown]
        public void TearDown()
        {
        }
    }
}
