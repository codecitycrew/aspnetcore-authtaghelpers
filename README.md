# Introduction

Asp.net core authorization tag helpers.

# Get Started

### Install

```ps 
Install-Package CodeCityCrew.TagHelpers.Authorization -Version 1.0.2
```

### _ViewImports.cshtml

```C#
@addTagHelper *, Microsoft.AspNetCore.Mvc.TagHelpers
@addTagHelper *, CodeCityCrew.TagHelpers.Authorization
```

### Role
```html
<li class="nav-item" asp-role="administrator">
  <a class="nav-link text-dark" asp-area="" asp-controller="Admin" asp-action="Index">Home</a>
</li>
```

### Policy
```html
<li class="nav-item" asp-policy="user-administration">
  <a class="nav-link text-dark" asp-area="" asp-controller="User" asp-action="Index">Home</a>
</li>
```

### Resource
```html
<li class="nav-item" asp-resource="@Model" asp-policy="editor">
  <a class="nav-link text-dark" asp-area="" asp-controller="Home" asp-action="Edit">Home</a>
</li>
```

### Is User Signed
```html
<li asp-is-signed="false">
  <a asp-area="Identity" asp-page="/Account/Register">Register</a>
</li>
<li asp-is-signed="false">
  <a asp-area="Identity" asp-page="/Account/Login">Login</a>
</li>
 <li asp-is-signed="true">
    <form class="form-inline" asp-area="Identity" asp-page="/Account/Logout" asp-route-returnUrl="@Url.Action("Index", "Home", new {area = "Administration"})">
        <button type="submit" class="btn btn-success btn-sm">Logout</button>
    </form>
</li>
```
