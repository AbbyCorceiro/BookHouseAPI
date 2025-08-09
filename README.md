# BookHouse API

<h3>About the API:</h3>
<ul>
  <li>La API fue creada a partir de un challenge para desarrolladores trainee</li>
  <li>Implementa operaciones CRUD (Create, Read, Update, Delete) con los respectivos endpoints en el controllador (GET, POST, PUT, DELETE).</li>
  <li>Está diseñada con una arquitectura en capas para mayor legilibilidad del código y la organización del proyecto.</li>
  <li>Está intencionada a implementar el patrón de diseño de repositorio con un servicio.</li>
  <li>De momento el controlador utiliza la capa de Data para que los endpoints funcionen.</li> 
  <li>La idea principal es que el controller obtenga los datos desde la capa de business a través de un service, y que ese service obtenga esa información desde el repository que se encontrará en la capa de Data; ya que es el encargado de utilizar el context de la base de datos.</li>
</ul>

<h3>What's Next?</h3>
<ul>
  <li>[ ] Revisar el endpoint de PUT</li>
  <li>[ ] Implementar el repositorio con un service y migrar la lógica a la capa de business</li>
  <li>[ ] Acomodar los endpoints para el repository pattern</li>
</ul>



