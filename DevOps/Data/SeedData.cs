using DevOps.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Identity;
using DevOps.Constants;

namespace DevOps.Data
{
    public class SeedData
    {
        public static void SeedUserAndRoles(ModelBuilder builder, ILoggerFactory loggerFactory)
        {
            try
            {
                string password = "_Aa123456789";
                string passwordAfterHash = SeedData.PasswordHash(password);
                var userId = Guid.NewGuid().ToString();
                    
                builder.Entity<BaseUser>(entity =>
                {
                    entity.HasData(
                                   new BaseUser()
                                   {
                                       Id = userId,
                                       UserName ="admin@admin.com",
                                       FirstName = "admin",
                                       LastName = "admin",
                                       Email = "admin@admin.com",
                                       FullName = "Ahmed Khaled",
                                       EmailConfirmed = true,
                                       PhoneNumber = "+201100811024",
                                       PasswordHash = passwordAfterHash
                                   }
                                  );
                });

                string adminRoleId = Guid.NewGuid().ToString();
                string consumerRoleId = Guid.NewGuid().ToString();
                builder.Entity<IdentityRole>(entity =>
                {
                    entity.HasData(
                        new IdentityRole()
                        {
                            Id = adminRoleId,
                            Name = Roles.Admin,
                            NormalizedName = Roles.Admin
                        },
                        new IdentityRole()
                        {
                            Id = consumerRoleId,
                            Name = Roles.Consumer,
                            NormalizedName = Roles.Consumer
                        });
                });


                builder.Entity<IdentityUserRole<string>>(entity =>
                {
                    entity.HasData(
                        new IdentityUserRole<string>()
                        {
                            RoleId = adminRoleId,
                            UserId = userId
                        });
                });
            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<SeedData>();
                logger.LogError(ex.Message);
            }
        }

        private static string PasswordHash(string password)
        {
            // generate a 128-bit salt using a cryptographically strong random sequence of nonzero values
            byte[] salt = new byte[128 / 8];

            // derive a 256-bit subkey (use HMACSHA256 with 100,000 iterations)
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 100000,
                numBytesRequested: 256 / 8));

            return hashed;
        }


    }
}
