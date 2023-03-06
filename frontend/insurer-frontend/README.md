
#Este es el proyecto frontend para gestionar aseguradoras; este permite agregar, editar, borrar y listar aseguradoras. 
Este proyecto consume una web API hecha en .NET Core y esta dividido de la siguiente forma: 

##Features: 
***************************************************************************************************************************************
Un archivo config para la configuracion del token header: ("1234").


Un Provider para implementar las operaciones Crud. 


Un Custom hook para hacer uso de dicho provider


El formulario que se divide en: 


Un componente Input Text para introducir datos de texto. 


Un InputNumber para introducir datos numericos.

Un checkbox component para ver si está activo o no.

Un formulario que se le pasan todos esos datos y algunas validaciones. 

Por otro lado tenemos un Component que es un CarBoard donde se mostrarían
los datos de la aseguradora. 

Y este CarBoard se conectaría con el componente lista el cual sería mostrado 
en el componente Page junto con el componente formulario. 

*********************************************************************************************


##Tecnologías usadas y que se requieren para hacer uso del proyecto: 
npm install vite@latest .

npm install @emotion/react, @emotion/styled, @mui/joy, @mui/styled-engine-sc de material UI.

npm install axios .

npm install styled-components.

******************************************************************************************************
Y el comando para correrlo seria npm run dev. 


