# .NET Core DI (injeção de dependência) 
Esse repositório contem um projeto .NET 5, com alguns exemplos práticos demonstrando como trabalhar com DI.

## Vida útil de um serviço

A seguir você tem os tipos de serviços e uma breve descrição que nós podemos trabalhar com .NET:

* Singleton: O *AddSingleton* é instanciado apenas uma vez;
* Scoped: O *AddScoped*  adiciona uma instancia dentro do escopo de cada requisição;
* Transient: O *AddTransient* cria uma nova instancia a cada requisição;

### Testando os escopos

Para validar cada um dos escopos eu criei uma interface que retorna Datetime.Now, dessa forma nós conseguimos validar a data/hora/min/seg:

```Csharp
public interface ILifecycleService
{
  DateTime DataAtual();
}
```

Depois eu criei dois services que implementam essa interface: *LifecycleService* e *Lifecycle2Service*. E para verificar o retorna de cada uma delas eu alterei a chamada na classe StartUp:


```Csharp
//Singleton
services.AddSingleton<ILifecycleService, LifecycleService>();
services.AddSingleton<Lifecycle2Service>();

//Resultado:
[
  "2021-03-01T20:55:02.0663019-03:00",
  "2021-03-01T20:55:02.0663019-03:00"
]
```

```Csharp
//Transient
 services.AddTransient<ILifecycleService, LifecycleService>();
services.AddTransient<Lifecycle2Service>();

//Resultado:
[
  "2021-03-01T20:56:07.081288-03:00",
  "2021-03-01T20:56:07.081622-03:00"
]
```
Note que nós temos uma alteração nos milissegundos.

```Csharp
//Scoped
services.AddScoped<ILifecycleService, LifecycleService>();
services.AddScoped<Lifecycle2Service>();

//Resultado:
[
  "2021-03-01T20:56:34.198563-03:00",
  "2021-03-01T20:56:34.198563-03:00"
]
```