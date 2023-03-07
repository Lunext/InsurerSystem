
#Este proyecto fue desarrollado con una arquitectura N capas. 
*******************************************************
Ya que lo que se busca es que la aplicación por así decirlo esté lo más independiente posible por cada una de sus capas se crearon las siguientes:

##Persistence: En el persistence se encuentran las migraciones, dbContext y una extensión del dbContext para luego conectarlo con el API 
En esta capa se instalaron los siguientes paquetes: 

 <ItemGroup>
    <PackageReference Include="Microsoft.EntityFrameworkCore.Design" Version="6.0.14">
      <PrivateAssets>all</PrivateAssets>
      <IncludeAssets>runtime; build; native; contentfiles; analyzers; buildtransitive</IncludeAssets>
    </PackageReference>
    <PackageReference Include="Microsoft.EntityFrameworkCore.Sqlite" Version="6.0.14" />
  </ItemGroup>
  
 Y también se hizo referencia al proyecto que contiene los dominios (modelos). 
 ****************************************************************************************************************************************
 ##Domain: Aquí se hace uso del modelo que funcionaría como el intermediario para la transferencia de datos,
 este cuenta con 4 campos, uno para el Id, otro para el nombre, también para las comisiones y finalmente para saber si están activas o no. 

 En este proyecto solo se hace uso del 
 ###paquete:
  <ItemGroup>
    <PackageReference Include="Microsoft.EntityFrameworkCore" Version="6.0.14" />
  </ItemGroup>
  
  ***********************************************************************************************************************************
  ##BusinessLogic: En esta capa está como su nombre lo indica la lógica de negocio, para ello se hace uso de FluentValidation para validar
  los datos pasados del modelo, asegurandonos de que se cumpla con lo requerido; por otro lado también se uso el patrón de repositorio; 
  donde se creo una interfaz llamada IInsurerRepository y esta sería implementada por el InsurerRepository, Un feauture interesante en 
  el uso de Actualización del Cache para que el usuario tenga mejor performance. 
  ###Paquetes utilizados: 
  
  <ItemGroup>
    <PackageReference Include="FluentValidation.AspNetCore" Version="11.2.2" />
  </ItemGroup>
  ********************************************************************************************************************************************************
 ##API: El API básicamente sería el core del proyecto, donde se hace uso de un controlador que utilizaría los métodos implementados en el repository 
 y cada método del mismo cuenta con los tipos de respuestas que generaría. Además, se hace uso de un middleware que funciona para asegurarnos que 
 todos los usuarios que vayan a usar nuestra aplicación, introduzcan el token necesario para tener acceso. (1234). 
 ###Paquetes: 
   <ItemGroup>
    <PackageReference Include="Microsoft.AspNetCore.JsonPatch" Version="6.0.14" />
    <PackageReference Include="Swashbuckle.AspNetCore" Version="6.2.3" />
    <PackageReference Include="Swashbuckle.AspNetCore.Swagger" Version="6.5.0" />
  </ItemGroup>
*********************************************************************************************************************************************************
 

 
 ##APIUnitTest: A través del Unit Test, confirmamos que realmente estamos recibiendo la respuesta que esparamos, para ello se hicieron dos pruebas unitarias; 
 Una para confirmar que el método del controller GetInsurers estaba recibiendo la cantidad de elementos que se espera; 
 y otra para confirmar que dado  el método GetCustomerById, este reciba la respuesta 201, de que fue encontrado. 
 
 ###Paquetes utilizados: 
  <PackageReference Include="Moq" Version="4.18.4" />
  ****************************************************************************************************************************************
  ##Para correr el proyecto se deben tomanr en cuenta dos cosas: 
  La primera es que la base de datos ya que se está trabajando con migraciones es posible que deba ser actualizada :
  dotnet ef datasabe update
  
  Y la segunda es que este debe ser corrido en el API, puesto que ahí se encuentra el Program. 
  Este puede ser probado tanto en POSTMAN como en SwaggerUI (con su documentación de lugar). 
 
 
