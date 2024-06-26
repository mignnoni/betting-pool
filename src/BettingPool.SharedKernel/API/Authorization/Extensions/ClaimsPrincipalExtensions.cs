﻿using System.Security.Claims;

namespace BettingPool.SharedKernel.API.Authorization.Extensions;

public static class ClaimsPrincipalExtensions
{
    public static Guid GetUserId(this ClaimsPrincipal claimsPrincipal)
    {
        var userId = claimsPrincipal.Claims.SingleOrDefault(claim => claim.Type == ClaimTypes.NameIdentifier)?.Value ?? string.Empty;

        if (string.IsNullOrWhiteSpace(userId) || string.IsNullOrEmpty(userId))
            return Guid.Empty;

        return Guid.Parse(userId);
    }

    public static Guid GetMemberId(this ClaimsPrincipal claimsPrincipal)
    {
        var memberId = claimsPrincipal.Claims.SingleOrDefault(claim => claim.Type == "MemberId")?.Value ?? string.Empty;

        if (string.IsNullOrWhiteSpace(memberId) || string.IsNullOrEmpty(memberId))
            return Guid.Empty;

        return Guid.Parse(memberId);
    }

    public static string GetUserRole(this ClaimsPrincipal claimsPrincipal) =>
        claimsPrincipal.Claims.SingleOrDefault(claim => claim.Type == ClaimTypes.Role)?.Value ?? string.Empty;
}
