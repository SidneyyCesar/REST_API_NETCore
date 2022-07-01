<h3>REST API NET Core </h3>

<h5>Sidney Cesar</h5>

Construção de uma REST API <br />

 &#10004; <b>Technologies</b>

* .NET Core 3.1
* RestFull
* C#
* DDD
* IoC
* Entity Framework

<br />

<b> &#10004; Helpers </b> <br />

Migrations <br />

add nova migration: - <b>dotnet ef migrations add </b><name> <br />
executar migration: -  <b>dotnet ef database update</b><name> <br />

Como esta aplicação utiliza DDD, a camada de infra (persistencia) precisa saber qual é a connectionstring da aplicação, que por sua vez esta definida no appsettings.json da aplicação start, portando precisamos executar os comandos do EF através da api, indicando a infra, da seguinte forma<br />

<b>dotnet ef</b> --startup-project .\api\api.csproj --project .\infra\Persistence\Infra.csproj database update

