import InsurerList from "../Components/InsurerList";
import { InsurerProvider } from "../Context/InsurerProvider";
import { Container, Grid,Box } from "@mui/material";


import Form from "../Components/Form/Form";
 
const ManageInsurers = () => (

    
    <InsurerProvider>
       
        {/* <ChildModal/> */}

        <Grid container spacing={3}>
          

  
            <Grid item xs={12} sm={6}>
            <h1>Administra tus aseguradoras</h1>

               

                    <Form />

               
                </Grid>
                <Grid item xs={12} sm={6}>
                    <InsurerList />


              
            </Grid>
            </Grid>







        </InsurerProvider>
       
)

export default ManageInsurers; 