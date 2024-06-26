﻿using BettingPool.Application.Users.Abstractions;
using BettingPool.SharedKernel.Infrastructure;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BettingPool.Infrastructure.Authentication;

internal sealed class JwtProvider(IOptions<JwtOptions> options) : IJwtProvider
{
    private readonly JwtOptions _jwtOptions = options.Value;

    public string Generate(List<Claim> claims, List<string> roles)
    {
        var signingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_jwtOptions.SecretKey)),
            SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
                issuer: _jwtOptions.Issuer,
                audience: _jwtOptions.Audience,
                claims: GetClaims(claims, roles),
                notBefore: DateTime.UtcNow,
                expires: DateTime.UtcNow.AddDays(5),
                signingCredentials: signingCredentials
            );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    private static List<Claim> GetClaims(List<Claim> claims, List<string> roles)
    {
        claims.AddRoles(roles);

        return claims;
    }
}
