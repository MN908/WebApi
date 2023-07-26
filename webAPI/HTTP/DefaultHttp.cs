using Microsoft.AspNetCore.Mvc.ActionConstraints;
using System;

public class MyHttpGetAttribute : Attribute, IActionConstraint
{
    public int Order => 0;

    public bool Accept(ActionConstraintContext context)
    {
        return context.RouteContext.HttpContext.Request.Method.Equals("GET", StringComparison.OrdinalIgnoreCase);
    }
}
