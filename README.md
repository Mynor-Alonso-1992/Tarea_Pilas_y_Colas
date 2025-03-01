Como ejecutar el programa 
1. debe de tener instalado RabbitMQ.Client
2. debe de tener el servicio levantado de RabbitMO.Server (esto porque lo uso de manera local), se debe de levantar el servicio de RabbitMO.server y colocar las variables de entorno para que los comando se puedan ejecutar, para ver el status se usar el siguiente comando rabbitmqctl status.
3. debe de tener instalado AWSSDK.SQS para poder usar Amazon SQS
4. como es en la nube se debe de colocar credenciales de acceso a la cola, las credenciales ya están quemadas en la programación para evitar configurar el archivo de credenciales.
5. teniendo todo preparado y configurado se procede a la ejecución.

Explicación de cambio de proveedores.

El programa al ejecutar se muestra una ventana de comando de Windows 
donde se visualiza 2 opciones la primera es para usar Amazon SQS y la segunda para usar RabbitMQ. el mensaje que se envía es "Hola, esto es un mensaje de prueba.", entonces al escoger cualquier de las opciones ya se estaría realizando el cambio de proveedores, esto se realizo de esta manera pensando que en un futuro se puede tener un modulo donde se solicite que seleccione una opción dependiendo de las necesidades el usuario, esto es conlleva a que el sistema sea flexible.
