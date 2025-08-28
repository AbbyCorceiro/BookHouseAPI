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

<h3>For Testing the API</h3>
<h5>NuGetPackages Dependency:</h5>
<ul>
  <h5>For Entity Framework:</h5>
  <li>Microsoft.EntityFrameworkCore</li>
  <li>Microsoft.EntityFrameworkCore.SqlServer</li>
  <li>Microsoft.EntityFrameworkCore.Tools</li>

  <h5>For Swagger:</h5>
  <li>Swashbuckle.AspNetCore</li>
  <li>Swashbuckle.AspNetCore.Swagger</li>
</ul>

<h5>Http File</h5>
<ul>
  <li>Se puede descargar el repositorio y utilizar el archivo .http para testear los endpoints sin necesidad de utilizar Swagger</li>
  <li>El el archivo .http se encuentran todos los endpoints utilizados con algunas variables para testing</li>
  <br>

      @PresentationLayer_HostAddress = http://localhost:5059

      //Variables para testing
      @book_id = 2 
      @book_deleteId = 6

      //Gets all books in the database
      GET {{PresentationLayer_HostAddress}}/api/Book/all
      Accept: application/json

      ###

      //Gets a book by id
      GET {{PresentationLayer_HostAddress}}/api/Book/id?id={{book_id}} 
      Accept: application/json

      ###

      //Creates a new book in the database
      POST {{PresentationLayer_HostAddress}}/api/Book/add 
      Accept: application/json
      Content-Type: application/json
      {
        "id": 0,
        "title": "El Principito",
        "author": "Antoine de Saint-Exupéry",
        "yearPublication": 1951,
        "isbn": "9789876373487",
        "genre": "Novela Infantil",
        "available": true
      }

      ###

      //Modifies a book in the database
      PUT {{PresentationLayer_HostAddress}}/api/Book/modify?id={{book_id}} 
      Accept: application/json
      Content-Type: application/json
      {
        "id": {{book_id}},
        "title": "Harry Potter and the Philosopher's Stone",
        "author": "J. K. Rowling",
        "yearPublication": 1997,
        "isbn": "9780747532699",
        "genre": "Fantasy",
        "available": false 
      }    

      ###

      //Removes a book from the database
      DELETE {{PresentationLayer_HostAddress}}/api/Book/delete?id={{book_deleteId}}
      Accept: application/json

      ###  
  
</ul>

<h3>Endpoints</h3>
<ul>
  <li>Get All
    <ul><li>Obtiene todos los libros almacenados en la base de datos (No requiere parámetros)</li></ul>
    <br>
    <img width="1836" height="329" alt="Screenshot 2025-08-15 175508" src="https://github.com/user-attachments/assets/e636843b-6072-4ef5-ab51-b5a00a0d2bd2" />
    <br>
  </li>

###
  
  <li>Get By Id
    <ul>
      <li>Obtiene un libro en base a su número de Id</li>
      <li>Se introduce el número de id en la casilla de parámetro y devuelve el libro correspondiente a dicho id</li>
      <li>Si el libro no existe la API devuelve un código 404 Not Found</li>
    </ul>
    <br>
    <img width="1818" height="477" alt="Screenshot 2025-08-15 184611" src="https://github.com/user-attachments/assets/b9d7fb27-d4e5-40e7-8ed0-f484fd9edab2" />
    <br>
  </li>

###
  
  <li>Post Book
    <ul>
      <li>Crea un libro nuevo en la base de datos</li>
      <li>Requiere que se completen los datos del objeto libro que se va a crear</li>
    </ul>
    <br>
    <img width="1823" height="595" alt="Screenshot 2025-08-15 184813" src="https://github.com/user-attachments/assets/a8ee0c6f-9b54-499d-b755-64aabf502f73" />
    <br>
  </li>

###
  
  <li>Put Book
  <ul>
    <li>Modifica un libro existente en la base de datos</li>
    <li>Si el id del libro a modificar no existe devuelve un código 404 Not Found</li>
    <li>Si el id que paso por parámetro es diferente al id del los datos del libro a introducir entonces devuelve un código 400 Bad Request</li>
    <li>Requiere que el número de id del libro por parámetro, y el id del objeto libro que estoy modificando sean iguales y existentes en la base de datos para modificar el libro correctamente</li>
    </ul>
    <br>
    <img width="1823" height="823" alt="Screenshot 2025-08-15 184901" src="https://github.com/user-attachments/assets/eac94997-7218-4008-9e66-357898d325eb" />
    <br>
  </li>

###

<li>Delete Book
  <ul>
    <li>Elimina un libro existente de la base de datos en base a su número de Id</li>
    <li>Requiere el número de Id por parámetro</li>
    <li>Si el libro no existe devuelve un código 404 Not Found</li>
  </ul>
  <br>
  <img width="1818" height="475" alt="Screenshot 2025-08-15 184924" src="https://github.com/user-attachments/assets/0c2050cf-aefb-4e9c-9136-df49c0b08c91" />
  <br>
</li>
</ul>
<h3>To Do:</h3>
<ul>
  <li>[ ] Aplicar un Dto</li>
  <li>[ ] Añadir validaciones de modelo</li>
  <li>[ ] Agregar manejo de excepciones en el service</li>
  <li>[ ] Revisar el endpoint de PUT
    <ul>
      <li>[x] Se implementó un método para buscar si el id que se pasa por parámetro ya existe en la db</li>
      <li>[ ] Revisar la excepción de DbUpdateConcurrencyExcepcion a través del service</li>
    </ul>
  </li>
</ul>







