# CursoSistemaVenta
Este archivo explica de forma mós detallada el funcionamiento de este software.

Este software es un sistema de gestion de ventas.

Se desarrollara utilizando una arquitectura en capas.
Consta de 4 capas: Capa de Entidad, Capa de Datos, Capa de Negocio y Capa de Presentación.

* CapaEntidad: Posee las clases con un estructura similar a las tablas de nuestra base de datos. 
				   Esta se limita a ser un puente de transporte de datos con las demós capas.
				   * Posee clases con una estructura similar a las tablas de la base de datos.
				   * Todas la demas capa poseen una referencia a la CapaEntidad


* CapaDatos: Esta la encargada de la comunicación con la base de datos, aqui se ejecutaran las accciones CRUD.
				   * Las clases que comienzan con CD_ pertenencen a la CapaDatos.
				     Para mós de detalles ver video [Video2] a partir del minuto 47:00

* CapaNegocio: Es la encargada de recibir las peticiones solicitadas por le usuario desde la capa presentación.
				* Existe a una llamada desde las clases de la CapaNegocio a cada una de las clases de la CapaDatos que le corresponde. Ejemplo CD_Usuario <-- CN_Usuario

* CapaPresentación: Es la encargada de interactura con el usuario, es decir son aquellas ventas mensajes, cuadros de diálogo,
					    formularios o paginas web que el usuario utiliza para comunicarse con la aplicación.
						* En el archivo App.config de la CapaPresentacion se espeficifica el string de conexion con la base de datos.
						  Para mós de detalles ver video [Video2] a partir del minuto 44:00


El sistema cuenta con diferentes modulos, estos modulos son: 
* Modulo Usuarios
* Modulo Mantenedor
* Modulo Clientes
* Modulo Proveedores 
* Modulo Compras
* Modulo Ventas
* Modulo Reportes

A continueación se especifica de forma detalla el proposito de cada modulo:

* Modulo Usuarios: 

* Modulo Mantenedor: 

* Modulo Clientes: 

* Modulo Proveedores: 

* Modulo Compras: 

* Modulo Ventas: 

* Modulo Reportes: 



Lista de Videos del Curso:

[Video1]: https://www.youtube.com/watch?v=ezYDeaMivH8&list=PLx2nia7-PgoDk8pZ1YG8wtw5A8LH2kz96&index=1
[Video2]: https://www.youtube.com/watch?v=G9guWqDiddo&list=PLx2nia7-PgoDk8pZ1YG8wtw5A8LH2kz96&index=2
