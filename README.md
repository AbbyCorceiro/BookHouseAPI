# BookHouse API

<h3>About the API:</h3>
<ul>
  <li>La API fue creada a partir de un challenge para desarrolladores trainee</li>
  <li>Utiliza Entity Framework para la migración a la base de datos en SQL Server, y Swagger para el testing</li>
  <li>Implementa operaciones CRUD (Create, Read, Update, Delete) con los respectivos endpoints en el controllador (GET, POST, PUT, DELETE).</li>
  <li>Está diseñada con una arquitectura en capas para mayor legilibilidad del código y la organización del proyecto.</li>
  <li>Implementa el patrón de diseño de repositorio con un servicio.</li>
</ul>

<h3>Documentation</h3>
<ul>
  <li>Se creó el proyecto como Web Api y se añadieron dos proyectos a la solución (capas BusinnesLayer y DataLayer) del tipo library.</li>
  <li>Se creó el modelo de la entidad en la capa de Data.</li>
  <li>Se añadió el context desde el cuál se genera el DbSet de la entidad.</li>
  <li>Se creó el connection string para la conexión con la base de datos en el appsettings.json y se configuró en Program.cs</li>
  <li>Se realizaron las migraciones a la base de datos a través de Entity Framework y utilizando SQL Server</li>
  <li>Se creó el repositorio en la DataLayer desde la cuál se manejan los datos obtenidos de la db y son enviados al Service de la capa de Business.</li>
  <li>Se creó el servicio en la BusinessLayer encargado de devolver un resultado al controllador de la capa de presentación.</li>
  <li>Desde el controlador de la capa de presentación se acomodaron los enpoints para recibir un resultado desde el service y devolver el status correspondiente en base a dicho resultado.</li>
</ul>

<h3>What's Next?</h3>
<ul>
  <li>[ ] Revisar el endpoint de PUT</li>
  <li>[x] Implementar el repositorio con un service y migrar la lógica del código</li>
  <li>[x] Acomodar los endpoints para el repository pattern</li>
</ul>






