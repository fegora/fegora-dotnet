# Fegora API Client
Es un conector o librería para clientes .NET4.5+ del API de Fegora. Permite crear facturas, notas de crédito, notas de débito, etc., utilizando las credenciales de servicio de Fegora. 

## Pre-requisitos
* Cuenta de emisor en Fegora. Al tener una cuenta de emisor, tiene credenciales de acceso (`clientId`, `clientSecret`, `username`, `password`).
* .NETFramework 4.5 o superior

## Instalación

### Package Manager Console
La librería es mantenida y actualizada [en nuget.org.](https://www.nuget.org/packages/Fegora.Servicios.Api).
Para instalarla desde Package Manager Console en Visual Studio, ejecute el comando
```shell
PM> Install-Package Fegora.Servicios.Api
```

### Build
1. Baje o clone el código
2. Compile la solución

## Uso 

### Autenticación
Para utilizar el cliente del Api de Fegora, debe instanciar el objeto `Fegora.Servicio.Api` con las credenciales de su cuenta. Ejemplo:
```c#
var fegora = new Api(clientId, clientSecret, userName, password);
```
También puede escribir estos valores directamente en su archivo de configuración (`app.config` o `web.config`). El cliente buscará estos valores automáticamente. Ejemplo:
```xml
<configuration>
  <appSettings>
    <add key="Fegora.Servicios.ClientId" value="apiApp"/>
    <add key="Fegora.Servicios.Username" value="11223344"/>
    <add key="Fegora.Servicios.Password" value="AMC2jF15OpSJDSdf"/>
  </appSettings>
  ...
```
Y en la instanciación del Api:
```
var fegora = new Api();
```

### Renovación de Token
El cliente maneja automáticamente la solicitud y renovación de tokens de acceso entre las llamadas, por lo que no es necesario que usted maneje esto. Es recomendable que mantenga la instancia del objeto `Api` en un contexto amplio, global, por el tiempo que dure su aplicación o la sesión de su usuario. 

### Creación de un documento
A continuación se muestra la creación de una factura comercial.
```C#
// construir el DTE
var dte = new Dte();
dte.Tipo = TipoDte.Factura;

dte.Receptor = new Receptor()
{
    Id = "CF",
    Nombre = "Distribuidora XYZ",
    Direccion = new DireccionEntidad()
    {
        Direccion = "2a CALLE 3-51 ZONA 9 GUATEMALA",
        Departamento = "Guatemala",
        Municipio = "Guatemala",
        Pais = Pais.GT,
        CodigoPostal = "01009"
    }
};

dte.Items = new List<Item>();
dte.Items.Add(new Item()
{
    Descripcion = "Bocina BX-456",
    PrecioUnitario = 1500
});

// ejecutar la creacion
var resp = fegora.Dtes.Crear(dte);
```

### Dte creado
Una vez creado el dte, puede utilizar las propiedades del objeto devuelto para guardar en su sistema, imprimir o lo que necesite. En el siguiente ejemplo, se imprimen en pantalla algunos datos relevantes del documento creado:

```c#
var resp = fegora.Dtes.Crear(dte);
var dteCreado = resp.Contenido;

Console.WriteLine("Documento creado");
Console.WriteLine("------------------");
Console.WriteLine("Tipo: {0}", dteCreado.Tipo);
Console.WriteLine("ID: {0}", dteCreado.Id);
Console.WriteLine("Serie: {0}", dteCreado.Serie);
Console.WriteLine("Numero: {0}", dteCreado.Numero);
Console.WriteLine("Archivo XML URI: {0}", dteCreado.ArchivoXmlUri);
Console.WriteLine();
Console.WriteLine("Datos adicionales");
Console.WriteLine("------------------");
foreach (var datoAdicional in dteCreado.DatoAdicionales)
{
    Console.WriteLine("{0} ({1}) : {2}", datoAdicional.Nombre, datoAdicional.Visible.Value ? "visible" : "no visible", datoAdicional.Valor);
}
```
El anterior código muestra algo similar a:
```shell
Documento creado
------------------
Tipo: Factura
ID: EBD0DC89-7D04-463D-9EA8-57F4C4931E64
Serie: EBD0DC89
Numero: 2097432125
Archivo XML URI: http://cdn.fegora.com/dtes/EBD0DC89-7D04-463D-9EA8-57F4C4931E64.xml

Datos adicionales
------------------
SAT-1-2 (visible) : Sujeto a retención definitiva ISR
```

### Más ejemplos
En el código de la solución se incluye un proyecto de test con más ejemplos relevantes. 

