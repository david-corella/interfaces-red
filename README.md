# InterfacesRed

Aplicación de consola en **C# (.NET 8)** que detecta y lista las **interfaces de red** del equipo con
sus datos básicos. Proyecto académico de la materia de Redes (UNISON).

## Qué muestra

Para cada adaptador de red detectado:

- **Descripción**, **nombre** y **tipo** de la interfaz.
- **Estado** de operación (activa/inactiva, coloreado en consola).
- **Dirección MAC** (formateada `AA:BB:CC:DD:EE:FF`; "No disponible" si no aplica).
- **Direcciones IP** IPv4 e IPv6 asignadas (o aviso si no tiene).

## Tecnologías

- **Lenguaje:** C#
- **Framework:** .NET 8
- **APIs:** `System.Net.NetworkInformation`, `System.Net`

## Requisitos

- [.NET 8 SDK](https://dotnet.microsoft.com/download) (o Visual Studio 2022)

## Ejecutar

```sh
dotnet run --project InterfacesRed
```

O abre `InterfacesRed.sln` en Visual Studio y ejecuta con **F5**.

## Estructura

- `Program.cs` — punto de entrada.
- `ListadoInterfaces.cs` — obtiene las interfaces (`NetworkInterface.GetAllNetworkInterfaces`) y
  recorre sus propiedades (estado, MAC, IPs) imprimiéndolas.

## Autor

**David Corella** — Ingeniero en Sistemas de Información (UNISON).
Portafolio: <https://david-corella.github.io/>
