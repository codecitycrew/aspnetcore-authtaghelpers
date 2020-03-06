# Introduction

Asp.net core authorization tag helpers.

# Get Started

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
