
Evaluación C# MySQL.
Wilmer Manotas
•
Vamos a realizar este proyecto de escritorio con windows form .net conectado a una base de datos local mysql .


Una clínica desea desarrollar un sistema de gestión para organizar toda su información y facilitar el registrode pacientes, citas y médicos.


La clínica cuenta con varios doctores especializados en diferentes áreas, y cada uno tiene un horario de atención específico. Los pacientes pueden solicitar citas con uno o varios doctores en diferentes fechas y horarios. Cada cita debe registrar la fecha, la hora, el
motivo y el estado (pendiente, confirmada, cancelada). Además, los pacientes pueden tener múltiples citas a lo largo del tiempo, y se requiere mantener un historial de todas ellas.

El sistema debe permitir que el personal administrativo inicie sesión con un usuario y contraseña para gestionar toda la información. Debe ser posible registrar nuevos pacientes, editar su información, eliminar registros y consultar los datos existentes. Deberá permitir la gestión de las EPS de los pacientes (cada paciente contará con una EPS. Las EPS podrán tener múltiples pacientes).

También deben poder gestionar los doctores, incluyendo su especialidad. La interfaz debe ofrecer la opción de cambiar el idioma de la aplicación entre español e inglés en tiempo de ejecución.

La solución deberá permitir gestionar otros usuarios (los cuales contaran con foto, id, password y otros datos), además podrá permitir el cambio de contraseña, y recuperación de la misma (se sugiere a través del envío de correo electrónico).

La solución contará con los siguientes filtros: buscar doctores por una especialidad dada por el usuario, buscar doctores por el nombre o apellido, buscar pacientes por géneros, buscar pacientes por una edad dada, buscar pacientes por una EPS dada, mostrar pacientes con una fecha de cita determinada, mostrar citas por un determinado estado (con los datos de los pacientes). Filtrar pacientes registrados en una determinada fecha (dada por el usuario).


Es fundamental que el sistema realice validaciones, como verificar que los campos obligatorios no queden vacíos, que las fechas y horas tengan un formato válido, y que los datos como el número de teléfono o el correo electrónico tengan un formato correcto. Además, debe manejar errores de conexión o consultas SQL de forma adecuada, informando al usuario sin que la aplicación se cierre inesperadamente.