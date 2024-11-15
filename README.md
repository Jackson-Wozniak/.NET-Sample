commands run to get database working:

if install needed (check with 'dotnet ef'):

```dotnet tool install --global dotnet-ef```

then:

```dotnet ef```

then:

```dotnet ef migrations add InitialCreate```

then:

```dotnet ef database update```