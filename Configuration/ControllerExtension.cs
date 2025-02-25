using System.Runtime.CompilerServices;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;

namespace Server.Configuration;

public static class ControllerExtension
{
    public static Guid? GetUserId(this ClaimsPrincipal User){
        var claim = User.FindFirst(ClaimTypes.NameIdentifier);

        if (claim == null)
            return null;

        if (!Guid.TryParse(claim.Value, out var id))
            return null;

        return id;
  
    }
}