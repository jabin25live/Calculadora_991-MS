Crear en C# una calculadora científica con todos las funciones de una calculadora 991-MS, que funcione. luego realiza lo que te pido a continuación:

Ejercicios Prácticos de xUnit y Moq
Objetivos: pruebas unitarias, mocking con Moq, Verify, parámetros, casos exitosos y fallidos en
ASP.NET Core.

Práctica 1: Verificar que GetAsync retorna usuarios
Mockear GetAllAsync, retornar 3 usuarios, verificar OkObjectResult, verificar 3 usuarios y
Verify(Times.Once()).

Práctica 2: Verificar que GetByIdAsync retorna un usuario
Mockear GetByIdAsync(1), retornar un usuario, verificar OkObjectResult, Id=1 y parámetro
correcto.

Práctica 3: Verificar que GetByIdAsync retorna NotFound
Mockear GetByIdAsync para retornar null y verificar NotFoundResult.

Práctica 4: Verificar creación de usuario
Ejecutar CreateAsync, verificar CreatedAtActionResult y que CreateAsync fue invocado una vez.

Práctica 5: Verificar parámetros enviados
Usar Verify con It.Is(u => u.Email == 'john@test.com').

Práctica 6: Contar llamadas usando Callback
Incrementar un contador dentro de Callback y validar que sea igual a 1.

Práctica 7: Nivel Avanzado - DeleteAsync
Caso 1: Usuario existe => NoContentResult y DeleteAsync invocado. Caso 2: Usuario no existe =>

NotFoundResult y DeleteAsync nunca invocado.
Desafío Final
Validar el flujo: GetByIdAsync, CreateAsync y GetAllAsync, verificando que cada método fue
llamado exactamente una vez

Una vez halla terminado
haremos esto:

Competencias a Desarrollar

Diseño de pruebas unitarias con xUnit

Aplicación del patrón Arrange-Act-Assert

Uso de mocks y dobles de prueba

Medición de cobertura con Coverlet

Análisis estático con SonarQube

Implementación de pipelines CI/CD

Desarrollo guiado por pruebas (TDD)

Ejemplo del YAML que necesito:

name: .NET 10 Windows Service CI

on:
  push:
    branches: [ "main", "master" ]
  pull_request:
    branches: [ "main", "master" ]

env:
  ACTIONS_NODE_JS_FORCED_VERSION: 'node24'
  NODE_NO_WARNINGS: 1

jobs:
  build-and-publish:
    runs-on: windows-latest
    strategy:
      matrix:
        dotnet-version: ['8.0.x', '9.0.x', '10.0.x']

    steps:
    - name: Checkout de código
      uses: actions/checkout@v4

    - name: Configurar .NET 10 SDK
      uses: actions/setup-dotnet@v4
      with:
        dotnet-version: ${{ matrix.dotnet-version }}
        # dotnet-version: '10.0.x' 

# 1. Restauramos ambos proyectos (la API y los Tests)
    # Al apuntar a la carpeta contenedora 'MyApp', .NET buscará todo lo que esté adentro
    - name: Restaurar Dependencias
      run: dotnet restore MyApp/

    # 2. Compilamos toda la solución/proyectos dentro de MyApp
    - name: Compilar Proyecto
      run: dotnet build MyApp/ --no-restore 

    # 3. EJECUTAMOS LAS PRUEBAS apuntando al proyecto de tests real
    - name: Ejecutar Pruebas
      run: dotnet test MyApp/MyApp.Api.Tests/MyApp.Api.Tests.csproj --no-build