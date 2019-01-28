# Admincco (Administración Centralizada de Contratos) 
> Admincco es una herramienta para el control de proyectos, permitiendo hacer un seguimiento en variables del tipo tiempo, costo, moneda y vigencia.

Admincco ha sido personalizada de acuerdo con los requerimientos del grupo de Administración de Contratos y del área Financiera de proyectos mayores de Pacific Rubiales Energy.

Usa la metodología cliente – servidor, permitiendo que múltiples usuarios puedan realizar transacciones o procesos al mismo tiempo, lo que permite tener información en tiempo real.


![Panel de Acceso Login](https://github.com/vhngroup/Admincco/blob/master/Images/Captura_1_Admincco.png)

## Instalación

Windows:
```sh
Carpeta: bin/Debug/app.publish/
Doble Clic Setup.exe
```

## Ejemplo de uso
### Diagrama secuencia de autorización
![Secuencia Logica Contrato Marco](https://github.com/vhngroup/Admincco/blob/master/Images/Flujos_de_Trabajo.png)
![Secuencia Logica Orden de Servicio](https://github.com/vhngroup/Admincco/blob/master/Images/Flujos_de_Trabajo2.png)

### Acceso, Roles y Funciones
AdminCCo  esta parametrizado de acuerdo a los roles y niveles de autorización que los usuarios tienen en los contratos a ejecutar, de acuerdo a ello, se habilitan o se deshabilitan las opciones y permisos a los que cada usuario tiene acceso. 
A continuación se relacionan algunos roles de acceso actuales.
> SPADMIN Soporte Administrativo de  contrato
> Administrador
> Coordinador análisis financiero
> Solicitante Orden de servicio
> Admin - Administrador de la herramienta

##Capturas Pantalla
![Panel Principal de Opcciones](https://github.com/vhngroup/Admincco/blob/master/Images/Captura_1_Admincco2.png)
![Modulo Creación Contrato Macro](https://github.com/vhngroup/Admincco/blob/master/Images/Flujos_de_Trabajo3.png)
![Modulo Creación Contrato Macro](https://github.com/vhngroup/Admincco/blob/master/Images/Flujos_de_Trabajo3.png)
![Modulo Creación Contrato Macro](https://github.com/vhngroup/Admincco/blob/master/Images/Flujos_de_Trabajo4.png)


## Development setup

Describe how to install all development dependencies and how to run an automated test-suite of some kind. Potentially do this for multiple platforms.

```sh
make install
npm test
```

## Release History

* 0.2.1
    * CHANGE: Update docs (module code remains unchanged)
* 0.2.0
    * CHANGE: Remove `setDefaultXYZ()`
    * ADD: Add `init()`
* 0.1.1
    * FIX: Crash when calling `baz()` (Thanks @GenerousContributorName!)
* 0.1.0
    * The first proper release
    * CHANGE: Rename `foo()` to `bar()`
* 0.0.1
    * Work in progress

## Meta

Your Name – [@YourTwitter](https://twitter.com/dbader_org) – YourEmail@example.com

Distributed under the XYZ license. See ``LICENSE`` for more information.

[https://github.com/yourname/github-link](https://github.com/dbader/)

## Contributing

1. Fork it (<https://github.com/yourname/yourproject/fork>)
2. Create your feature branch (`git checkout -b feature/fooBar`)
3. Commit your changes (`git commit -am 'Add some fooBar'`)
4. Push to the branch (`git push origin feature/fooBar`)
5. Create a new Pull Request

<!-- Markdown link & img dfn's -->
[npm-image]: https://img.shields.io/npm/v/datadog-metrics.svg?style=flat-square
[npm-url]: https://npmjs.org/package/datadog-metrics
[npm-downloads]: https://img.shields.io/npm/dm/datadog-metrics.svg?style=flat-square
[travis-image]: https://img.shields.io/travis/dbader/node-datadog-metrics/master.svg?style=flat-square
[travis-url]: https://travis-ci.org/dbader/node-datadog-metrics
[wiki]: https://github.com/yourname/yourproject/wiki
